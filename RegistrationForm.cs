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
using System.Security.Cryptography;

namespace hotelManagementSystem
{
    public partial class RegistrationForm : Form
    {
        private string conn = @"Data Source=DESKTOP-I7PF7E5;Initial Catalog=hotel;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cpassword.Text == "")
            {
                MessageBox.Show("Please fill in all the required information.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();
                    string checkUsern = "SELECT username FROM users WHERE username = @usern";
                    using (SqlCommand checkU = new SqlCommand(checkUsern, connect))
                    {
                        checkU.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkU);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count != 0)
                        {
                            string tempEmail = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                            MessageBox.Show($"{tempEmail} already exists.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (register_password.Text.Length < 8)
                        {
                            MessageBox.Show("The password must be more than 8 characters.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (register_password.Text != register_cpassword.Text)
                        {
                            MessageBox.Show("The password does not match.", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query = "INSERT INTO users (username, password, role, status, date_register)" +
                                            "VALUES(@usern, @pass, @role, @status, @regDate)";
                            using (SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", HashPassword(register_password.Text.Trim())); // Mã hóa mật khẩu
                                cmd.Parameters.AddWithValue("@role", "Staff");
                                cmd.Parameters.AddWithValue("@status", "Active");

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@regDate", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registration successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form1 loginForm = new Form1();
                                loginForm.Show();
                                this.Hide();
                            }
                        }
                }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cpassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_signinBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
