using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace hotelManagementSystem
{
    public partial class admin_dashboard : UserControl
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
        private Timer chartUpdateTimer; // Timer để cập nhật biểu đồ

        public admin_dashboard()
        {
            InitializeComponent();
            refreshData();

            // Khởi tạo Timer để cập nhật biểu đồ mỗi 10 giây
            chartUpdateTimer = new Timer();
            chartUpdateTimer.Interval = 10000; // 10 giây (10000 milliseconds)
            chartUpdateTimer.Tick += (sender, e) =>
            {
                chartUpdateTimer.Stop(); // Dừng Timer để tránh xung đột
                displayChart(); // Gọi phương thức không tham số
                chartUpdateTimer.Start(); // Bắt đầu lại sau khi cập nhật
            };
            chartUpdateTimer.Start(); // Bắt đầu Timer
        }

        public void refreshData()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                displayTotalStaff(connect);
                displayAvailableRooms(connect);
                displayProfitToday(connect);
                displayProfitTotal(connect);
                displayChart(connect); // Cập nhật biểu đồ khi refresh
            }
        }

        public void displayTotalStaff(SqlConnection connect)
        {
            string selectData = "SELECT COUNT(id) FROM users WHERE role = 'Staff'";
            using (SqlCommand cmd = new SqlCommand(selectData, connect))
            {
                object result = cmd.ExecuteScalar();
                totalStaff.Text = result != DBNull.Value ? result.ToString() : "0";
            }
        }

        public void displayAvailableRooms(SqlConnection connect)
        {
            string selectData = "SELECT COUNT(id) FROM rooms WHERE status = 'Active' OR status = 'Available'";
            using (SqlCommand cmd = new SqlCommand(selectData, connect))
            {
                object result = cmd.ExecuteScalar();
                AvailableRooms.Text = result != DBNull.Value ? result.ToString() : "0";
            }
        }

        public void displayProfitToday(SqlConnection connect)
        {
            string selectData = "SELECT SUM(price) FROM customer WHERE date_book = @dbook";
            using (SqlCommand cmd = new SqlCommand(selectData, connect))
            {
                cmd.Parameters.AddWithValue("@dbook", DateTime.Today);
                object result = cmd.ExecuteScalar();
                profitToday.Text = result != DBNull.Value ? result.ToString() + ".00" : "0.00";
            }
        }

        public void displayProfitTotal(SqlConnection connect)
        {
            string selectData = "SELECT SUM(price) FROM customer";
            using (SqlCommand cmd = new SqlCommand(selectData, connect))
            {
                object result = cmd.ExecuteScalar();
                totalProfit.Text = result != DBNull.Value ? result.ToString() + ".00" : "0.00";
            }
        }

        // Phương thức thêm mới: displayChart không cần tham số
        public void displayChart()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                displayChart(connect); // Gọi phương thức cũ với tham số
            }
        }

        public void displayChart(SqlConnection connect)
        {
            // Danh sách lưu dữ liệu từ cơ sở dữ liệu
            List<DateTime> dates = new List<DateTime>();
            List<decimal> totalPrices = new List<decimal>();

            string selectData = @"
                SELECT CAST(date_from AS DATE) AS BookingDate, SUM(price) AS TotalPrice
                FROM customer
                GROUP BY CAST(date_from AS DATE)
                ORDER BY BookingDate";

            using (SqlCommand cmd = new SqlCommand(selectData, connect))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["BookingDate"] != DBNull.Value)
                            dates.Add(reader.GetDateTime(reader.GetOrdinal("BookingDate")));

                        if (reader["TotalPrice"] != DBNull.Value)
                            totalPrices.Add(reader.GetDecimal(reader.GetOrdinal("TotalPrice")));
                    }
                }
            }

            // Cấu hình biểu đồ
            chart1.Series.Clear(); // Xóa các series cũ

            // Tạo series cho biểu đồ
            var series = new Series("Daily Revenue")
            {
                ChartType = SeriesChartType.Column, // Kiểu cột (Column Chart)
                BorderWidth = 2
            };

            // Thêm dữ liệu vào series
            for (int i = 0; i < dates.Count; i++)
            {
                series.Points.AddXY(dates[i], totalPrices[i]);
            }

            // Thêm series vào biểu đồ
            chart1.Series.Add(series);

            // Cấu hình trục X
            chart1.ChartAreas[0].AxisX.Title = "Date";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd MMM yyyy"; // Hiển thị ngày theo định dạng
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả các nhãn

            // Cấu hình trục Y
            chart1.ChartAreas[0].AxisY.Title = "Total Revenue";
        }
    }
}
