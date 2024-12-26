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

using System.IO;
namespace hotelManagementSystem
{
    public partial class admin_rooms : UserControl
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public admin_rooms()
        {
            InitializeComponent();
            displayRoomData();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayRoomData();
        }
        public void displayRoomData()
        {
            roomsData rData = new roomsData();
            List<roomsData> listD = rData.roomsDataList();
            dataGridView1.DataSource = listD;

        }
        public bool isEmpty()
        {
            if (string.IsNullOrEmpty(rooms_type.Text) || string.IsNullOrEmpty(rooms_roomName.Text)
                || rooms_type.SelectedIndex == -1 || string.IsNullOrEmpty(rooms_price.Text)
                || rooms_status.SelectedIndex == -1 || rooms_picture.Image == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void rooms_addBtn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please fill in all information", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không tiếp tục xử lý nếu thiếu thông tin
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();
                    string checkRoomID = "SELECT room_ID FROM rooms WHERE room_ID = @roomID";
                    using (SqlCommand checkRID = new SqlCommand(checkRoomID, connect))
                    {
                        checkRID.Parameters.AddWithValue("@roomID", rooms_roomID.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkRID);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show($"{rooms_roomID.Text.Trim()} already exists. Please enter a different Room ID.",
                                "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Không tiếp tục xử lý nếu Room ID đã tồn tại
                        }
                        else
                        {
                            string insertData = "INSERT INTO rooms (room_id,type,room_name,price,image_path,status,date_register)" +
                                "VALUES(@roomID,@type,@name,@price,@path,@status,@date_reg)";

                            string path = Path.Combine(@"C:\Users\ADMIN\source\repos\HotelManagementSystem\room_directory\",
                                $"{rooms_roomID.Text.Trim()}.jpg");
                            string directoryPath = Path.GetDirectoryName(path);
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            File.Copy(rooms_picture.ImageLocation, path, true);

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@roomID", rooms_roomID.Text.Trim());
                                cmd.Parameters.AddWithValue("@type", rooms_type.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@name", rooms_roomName.Text.Trim());
                                cmd.Parameters.AddWithValue("@price", rooms_price.Text.Trim());
                                cmd.Parameters.AddWithValue("@path", path);
                                cmd.Parameters.AddWithValue("@status", rooms_status.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@date_reg", DateTime.Today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Room added successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Chỉ xóa thông tin khi thêm thành công
                                clearFields();
                                displayRoomData();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void rooms_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                string imagePath = "";
                file.Filter = "Image Files(*.jpg; *.png|*.jpg;*.png";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    imagePath = file.FileName;
                    rooms_picture.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex} ", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rooms_updateBtn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please select the room you want to update", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Do you want to update ID: " + id + " ?", "Confirmation message "
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection connect = new SqlConnection(conn))
                        {
                            connect.Open();
                            string updateData = "UPDATE rooms SET type = @type, room_name =@name,price = @price" +
                                " ,status = @status, date_update =@update WHERE id = @id";
                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@room_id", rooms_roomID.Text.Trim());
                                cmd.Parameters.AddWithValue("@type", rooms_type.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@name", rooms_roomName.Text.Trim());
                                cmd.Parameters.AddWithValue("@price", rooms_price.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", rooms_status.SelectedItem.ToString());

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@update", today);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                                clearFields();
                                displayRoomData();

                                MessageBox.Show("Update successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Exception error", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = (int)row.Cells[0].Value;
                rooms_roomID.Text = row.Cells[1].Value.ToString();
                rooms_type.Text = row.Cells[2].Value.ToString();
                rooms_roomName.Text = row.Cells[3].Value.ToString();
                rooms_price.Text = row.Cells[4].Value.ToString();

                rooms_picture.ImageLocation = row.Cells[5].Value.ToString();
                rooms_status.Text = row.Cells[6].Value.ToString();

            }
        }

        public void clearFields()
        {
            rooms_roomID.Text = "";
            rooms_type.SelectedIndex = -1;
            rooms_roomName.Text = "";
            rooms_price.Text = "";
            rooms_picture.Image = null;
            rooms_status.SelectedIndex = -1;
        }
        private void rooms_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void rooms_deleteBtn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please select the room you want to delete", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Do you want to delete the room with ID: " + id + " ?", "Confirmation message "
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection connect = new SqlConnection(conn))
                        {
                            connect.Open();
                            string updateData = "UPDATE rooms SET date_delete =@delete WHERE id = @id";
                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@delete", today);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                                clearFields();
                                displayRoomData();

                                MessageBox.Show("Delete successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Exception error ", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
