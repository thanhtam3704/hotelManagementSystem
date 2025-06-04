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
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

        public Form1()
        {
            InitializeComponent();
        }

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
                    string hashedPassword = HashPassword(login_password.Text.Trim());
                    string selectData = "SELECT role FROM users WHERE username = @usern AND password = @pass";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", hashedPassword); // Sử dụng mật khẩu đã mã hóa
                        object roleObj = cmd.ExecuteScalar();
                        if (roleObj != null) 
                        {
                            string userRole = roleObj.ToString();
                            MessageBox.Show("Login successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
