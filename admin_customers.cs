using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

// Alias cho các namespace có sự xung đột
using ExcelApp = Microsoft.Office.Interop.Excel.Application;
using ExcelDataTable = Microsoft.Office.Interop.Excel.DataTable;
using SystemDataTable = System.Data.DataTable;


namespace hotelManagementSystem
{
    public partial class admin_customers : UserControl
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public admin_customers()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  // Chọn toàn bộ dòng
            dataGridView1.CellClick += dataGridView1_CellClick;  // Thêm sự kiện CellClick
            dataGridView1.ReadOnly = true;  // Ngăn không cho chỉnh sửa dữ liệu trong DataGridView
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; // Ngăn chỉnh sửa qua bàn phím
            displayCustomers();
            CancelExpiredBookings();  // Kiểm tra và hủy các khách hàng không check-in đúng hạn
        }




        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            displayCustomers(keyword);
        }

        public void displayCustomers(string keyword = "")
        {
            customersData cData = new customersData();

            // Lấy danh sách khách hàng
            List<customersData> listData = cData.customerListData();

            // Nếu có từ khóa, lọc danh sách
            if (!string.IsNullOrEmpty(keyword))
            {
                listData = listData.Where(c =>
                    c.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Email.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0||c.ContactNum.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) .ToList();
            }

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo rằng khi nhấn vào một ô, dòng đó được chọn
            if (e.RowIndex >= 0) // Kiểm tra nếu không phải là tiêu đề cột
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to check-in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin của khách hàng đã chọn
            var selectedRow = dataGridView1.SelectedRows[0];
            string roomID = selectedRow.Cells["RoomID"].Value.ToString(); // Sử dụng tên cột đúng
            string currentStatus = selectedRow.Cells["Status"].Value.ToString(); // Lấy trạng thái khách hàng
            DateTime checkInDate = Convert.ToDateTime(selectedRow.Cells["CheckIn"].Value); // Lấy ngày check-in

            // Kiểm tra nếu trạng thái không phải là "Not Check In"
            if (currentStatus != "Not Check In")
            {
                MessageBox.Show($"Customer cannot check-in because the current status is '{currentStatus}'.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra nếu ngày check-in không phải là hôm nay
            if (checkInDate.Date != DateTime.Today.Date)
            {
                MessageBox.Show("Check-in date is not today.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu thỏa mãn cả hai điều kiện, thực hiện check-in
            UpdateRoomAndCustomerStatus(roomID);
        }


        private void UpdateRoomAndCustomerStatus(string room_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Cập nhật trạng thái phòng thành "Occupied"
                    string updateRoomQuery = "UPDATE rooms SET status = 'Occupied' WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateRoomQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", room_id);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật trạng thái khách hàng thành "Checked In"
                    string updateCustomerQuery = "UPDATE customer SET status = 'Checked In' WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", room_id);
                        cmd.ExecuteNonQuery();
                    }

                    // Gọi lại phương thức để làm mới dữ liệu trong DataGridView
                    displayCustomers();

                    MessageBox.Show("Check-in successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when updating data: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to check-out.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin của khách hàng đã chọn
                var selectedRow = dataGridView1.SelectedRows[0];
                string roomID = selectedRow.Cells["RoomID"].Value.ToString();  // Sử dụng tên cột đúng

                string currentStatus = selectedRow.Cells["Status"].Value.ToString(); // Lấy trạng thái của khách hàng

                if (currentStatus == "Checked In")
                {
                    // Nếu trạng thái là Checked In, thực hiện check-out
                    UpdateRoomAndCustomerStatusForCheckOut(roomID);
                }
                else
                {
                    // Nếu không phải là Checked In, thông báo trạng thái hiện tại
                    MessageBox.Show($"Customer is currently in '{currentStatus}' status.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        private void UpdateRoomAndCustomerStatusForCheckOut(string room_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Cập nhật trạng thái phòng thành "Available"
                    string updateRoomQuery = "UPDATE rooms SET status = 'Available' WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateRoomQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", room_id);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật trạng thái khách hàng thành "Checked Out"
                    string updateCustomerQuery = "UPDATE customer SET status = 'Checked Out' WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", room_id);
                        cmd.ExecuteNonQuery();
                    }

                    // Gọi lại phương thức để làm mới dữ liệu trong DataGridView
                    displayCustomers();

                    MessageBox.Show("Check-out successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when updating data:{ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CancelExpiredBookings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Lấy danh sách khách hàng có ngày check-in trong quá khứ mà không thực hiện check-in
                    string query = "SELECT room_id, full_name, date_from FROM customer WHERE status = 'Not Check In' AND date_from < @today";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@today", DateTime.Today.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roomID = reader["room_id"].ToString();
                                string fullName = reader["full_name"].ToString();

                                // Cập nhật trạng thái khách hàng thành "Cancelled"
                                string updateCustomerQuery = "UPDATE customer SET status = 'Cancelled' WHERE room_id = @room_id";
                                using (SqlCommand updateCmd = new SqlCommand(updateCustomerQuery, connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@room_id", roomID);
                                    updateCmd.ExecuteNonQuery();
                                }

                                // Cập nhật trạng thái phòng thành "Available"
                                string updateRoomQuery = "UPDATE rooms SET status = 'Available' WHERE room_id = @room_id";
                                using (SqlCommand updateCmd = new SqlCommand(updateRoomQuery, connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@room_id", roomID);
                                    updateCmd.ExecuteNonQuery();
                                }

                                MessageBox.Show($"ustomer {fullName} has been cancelled for failing to check-in on time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when checking expired customers: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to cancel.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin khách hàng đã chọn
            var selectedRow = dataGridView1.SelectedRows[0];
            string roomID = selectedRow.Cells["RoomID"].Value.ToString();  // Sử dụng tên cột đúng
            string fullName = selectedRow.Cells["FullName"].Value.ToString(); // Lấy tên khách hàng
            string currentStatus = selectedRow.Cells["Status"].Value.ToString(); // Lấy trạng thái của khách hàng

            // Kiểm tra nếu trạng thái không phải là "Checked Out"
            if (currentStatus == "Checked Out")
            {
                MessageBox.Show("Cannot cancel a customer who has already checked out.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Cập nhật trạng thái khách hàng thành "Cancelled" và giá thành 0
                    string updateCustomerQuery = "UPDATE customer SET status = 'Cancelled', price = 0 WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", roomID);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật trạng thái phòng thành "Available"
                    string updateRoomQuery = "UPDATE rooms SET status = 'Available' WHERE room_id = @room_id";
                    using (SqlCommand cmd = new SqlCommand(updateRoomQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@room_id", roomID);
                        cmd.ExecuteNonQuery();
                    }

                    // Làm mới dữ liệu trong DataGridView
                    displayCustomers();

                    MessageBox.Show($"Customer {fullName}'s booking has been cancelled.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when updating data: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkNotCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            FilterCustomersBasedOnStatus();
        }

        private void chkCheckedIn_CheckedChanged(object sender, EventArgs e)
        {
            FilterCustomersBasedOnStatus();
        }

        private void chkCheckedOut_CheckedChanged(object sender, EventArgs e)
        {
            FilterCustomersBasedOnStatus();
        }

        // Phương thức lọc khách hàng dựa trên trạng thái đã chọn
        private void FilterCustomersBasedOnStatus()
        {
            // Tạo một danh sách để lưu các trạng thái đã chọn
            List<string> selectedStatuses = new List<string>();

            // Thêm trạng thái vào danh sách nếu checkbox được chọn
            if (chkNotCheckIn.Checked)
                selectedStatuses.Add("Not Check In");
            if (chkCheckedIn.Checked)
                selectedStatuses.Add("Checked In");
            if (chkCheckedOut.Checked)
                selectedStatuses.Add("Checked Out");

            // Nếu không có trạng thái nào được chọn, hiển thị tất cả khách hàng
            if (selectedStatuses.Count == 0)
            {
                displayCustomers();
            }
            else
            {
                // Hiển thị khách hàng theo các trạng thái đã chọn
                displayCustomersWithStatuses(selectedStatuses);
            }
        }

        public void displayCustomersWithStatuses(List<string> statuses)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Xây dựng câu truy vấn SQL dựa trên các trạng thái đã chọn
                    string query = "SELECT * FROM customer WHERE status IN (@statuses)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Tạo câu truy vấn với tham số cho nhiều trạng thái
                        string statusList = string.Join(",", statuses.Select(s => $"'{s}'"));
                        cmd.CommandText = $"SELECT * FROM customer WHERE status IN ({statusList})";

                        System.Data.DataTable dt = new System.Data.DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng Excel Application
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not installed correctly.");
                    return;
                }

                // Tạo một Workbook mới
                Workbook workBook = excelApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)workBook.Worksheets[1];

                // Xuất tiêu đề cột ra Excel
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từ DataGridView ra Excel
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            workSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Hiển thị Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when exporting data:: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
  }


