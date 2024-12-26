using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace hotelManagementSystem
{
    public partial class staff_bookRoom : UserControl
    {
        public staff_bookRoom()
        {
            InitializeComponent();
            displayRooms();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayRooms();
        }
        public void displayRooms()
        {
            roomsData rData = new roomsData();
            List<roomsData> listData = rData.roomsDataList();
            dataGridView1.DataSource = listData;
        }

        private int getID = 0;
        private decimal regprice = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                bookRoom_roomID.Text = row.Cells[1].Value.ToString();
                bookRoom_roomType.Text = row.Cells[2].Value.ToString();
                bookRoom_roomName.Text = row.Cells[3].Value.ToString();
                bookRoom_regPrice.Text = (Convert.ToInt32(row.Cells[4].Value)).ToString("0.00");

                regprice = Convert.ToDecimal(row.Cells[4].Value);
                bookRoom_imageView.ImageLocation = row.Cells[5].Value.ToString();
                bookRoom_status.Text = row.Cells[6].Value.ToString();

            }
        }

        private void bookRoom_scheduleBtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = bookRoom_from.Value.Date;
            DateTime toDate = bookRoom_to.Value.Date;
            DateTime currentDate = DateTime.Now.Date;

            // Kiểm tra ngày từ phải lớn hơn hoặc bằng ngày hiện tại
            if (fromDate < currentDate)
            {
                MessageBox.Show("Start date must be today or later.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bookRoom_total.Text = "0.00";
                return;
            }

            // Kiểm tra ngày đến phải lớn hơn ngày từ
            if (toDate <= fromDate)
            {
                MessageBox.Show("End date must be later than start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bookRoom_total.Text = "0.00";
                return;
            }

            // Tính toán giá tiền
            TimeSpan countDays = toDate - fromDate;
            int days = countDays.Days;
            decimal totalPrice = (days * regprice);

            // Hiển thị giá tiền
            if (totalPrice == 0)
            {
                bookRoom_total.Text = regprice.ToString("0.00");
            }
            else
            {
                bookRoom_total.Text = totalPrice.ToString("0.00");
            }
        }


        private void bookRoom_bookBtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = bookRoom_from.Value.Date;
            DateTime toDate = bookRoom_to.Value.Date;
            DateTime currentDate = DateTime.Now.Date;

            // Kiểm tra ngày từ phải lớn hơn hoặc bằng ngày hiện tại
            if (fromDate < currentDate)
            {
                MessageBox.Show("Start date must be today or later.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày đến phải lớn hơn ngày từ
            if (toDate <= fromDate)
            {
                MessageBox.Show("End date must be later than start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá trị regprice và trạng thái phòng
            if (regprice == 0 || bookRoom_total.Text == "0.00")
            {
                MessageBox.Show("Please enter the correct information.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bookRoom_status.Text.Trim() != "Available")
            {
                MessageBox.Show("The room is not available.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                hotelData.roomID = bookRoom_roomID.Text;
                hotelData.fromDate = fromDate;
                hotelData.toDate = toDate;
                hotelData.price = bookRoom_total.Text;

                // Mở form clientinfor và truyền đối tượng staff_bookRoom
                Form formbg = new Form();
                try
                {
                    using (clientinfor ciForm = new clientinfor())
                    {
                        ciForm.Owner = formbg;
                        ciForm.SetParentBookRoomForm(this); // Gọi phương thức để truyền đối tượng staff_bookRoom
                        ciForm.ShowDialog();
                        formbg.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception error." + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    formbg.Dispose();
                }
            }
        }

        public void clearFields()
        {
            bookRoom_roomID.Text = "----------";
            bookRoom_roomType.Text = "----------";
            bookRoom_roomName.Text = "----------";
            bookRoom_status.Text = "----------";
            bookRoom_total.Text = "0.00";
            bookRoom_regPrice.Text = "0.00";

            bookRoom_imageView.Image = null;
            regprice = 0;
        }

        private void updateRoomStatus(int roomID, string newStatus)
        {
            string connectionString = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Câu lệnh SQL UPDATE
            string query = "UPDATE Rooms SET Status = @Status WHERE ID = @RoomID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@RoomID", roomID);

                    // Mở kết nối và thực thi câu lệnh UPDATE
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Room status updated to 'Occupied'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room status update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bookRoom_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void checkBoxAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAvailable.Checked)
            {
                // Hiển thị chỉ các phòng có status = "Available"
                displayRooms(true);
            }
            else
            {
                // Hiển thị tất cả các phòng
                displayRooms(false);
            }
        }
        public void displayRooms(bool onlyAvailable = false)
        {
            roomsData rData = new roomsData();
            List<roomsData> listData = rData.roomsDataList();

            // Lọc danh sách nếu CheckBox được chọn
            if (onlyAvailable)
            {
                listData = listData.Where(r => r.Status == "Available").ToList();
            }

            dataGridView1.DataSource = listData;
        }

    }
}
