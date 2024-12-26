using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace hotelManagementSystem
{
    public partial class Form1 : Form
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        // Mã hóa mật khẩu bằng SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_registerBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill in all the required information.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    // Mã hóa mật khẩu nhập vào
                    string hashedPassword = HashPassword(login_password.Text.Trim());

                    string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", hashedPassword); // Sử dụng mật khẩu đã mã hóa

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();

                        adapter.Fill(table);
                        if (table.Rows.Count != 0)
                        {
                            MessageBox.Show("Login successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Lấy vai trò của người dùng
                            string selectRole = "SELECT role FROM users WHERE username = @usern AND password = @pass";
                            using (SqlCommand getRole = new SqlCommand(selectRole, connect))
                            {
                                getRole.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                                getRole.Parameters.AddWithValue("@pass", hashedPassword); // Mã hóa mật khẩu cho câu lệnh role

                                string userRole = getRole.ExecuteScalar() as string;

                                if (userRole == "Admin")
                                {
                                    AdminMainForm admin_Form = new AdminMainForm();
                                    admin_Form.Show();
                                    this.Hide();
                                }
                                else if (userRole == "Staff")
                                {
                                    staffMainForm staff_Form = new staffMainForm();
                                    staff_Form.Show();
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
