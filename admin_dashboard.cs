using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace hotelManagementSystem
{
    public partial class admin_dashboard : UserControl
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private Timer chartUpdateTimer; // Timer để cập nhật biểu đồ

        public admin_dashboard()
        {
            InitializeComponent();
            displayTotalStaff();
            displayAvailableRooms();
            displayProfitToday();
            displayProfitTotal();
            displayChart(); // Gọi phương thức để hiển thị biểu đồ

            // Khởi tạo Timer để cập nhật biểu đồ mỗi 10 giây
            chartUpdateTimer = new Timer();
            chartUpdateTimer.Interval = 10000; // Đặt thời gian là 10 giây (10000 milliseconds)
            chartUpdateTimer.Tick += (sender, e) => displayChart(); // Mỗi khi tick, gọi displayChart để cập nhật
            chartUpdateTimer.Start(); // Bắt đầu Timer
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayTotalStaff();
            displayAvailableRooms();
            displayProfitToday();
            displayProfitTotal();
            displayChart(); // Cập nhật biểu đồ khi refresh
        }

        public void displayTotalStaff()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT COUNT(id) FROM users WHERE role = 'Staff'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalStaff.Text = result.ToString();
                    }
                }
            }
        }

        public void displayAvailableRooms()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT COUNT(id) FROM rooms WHERE status = 'Active' OR status = 'Available'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        AvailableRooms.Text = result.ToString();
                    }
                }
            }
        }

        public void displayProfitToday()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT SUM(price) FROM customer WHERE date_book = @dbook";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@dbook", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        profitToday.Text = result.ToString() + ".00";
                    }
                }
            }
        }

        public void displayProfitTotal()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT SUM(price) FROM customer";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalProfit.Text = result.ToString() + ".00";
                    }
                }
            }
        }

        // Phương thức để lấy dữ liệu và hiển thị biểu đồ
        public void displayChart()
        {
            // Danh sách lưu dữ liệu từ cơ sở dữ liệu
            List<DateTime> dates = new List<DateTime>();
            List<decimal> totalPrices = new List<decimal>(); // Tổng tiền cho từng ngày

            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                // Truy vấn nhóm dữ liệu theo ngày và tính tổng tiền
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
                            {
                                // Lấy ngày từ dữ liệu
                                dates.Add(reader.GetDateTime(reader.GetOrdinal("BookingDate")));
                            }

                            if (reader["TotalPrice"] != DBNull.Value)
                            {
                                // Lấy tổng tiền
                                totalPrices.Add(reader.GetDecimal(reader.GetOrdinal("TotalPrice")));
                            }
                        }
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
                series.Points.AddXY(dates[i], totalPrices[i]); // Thêm ngày và tổng tiền
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (chartUpdateTimer != null)
        //        {
        //            chartUpdateTimer.Stop(); // Dừng Timer khi không còn sử dụng
        //            chartUpdateTimer.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}
    }


}

