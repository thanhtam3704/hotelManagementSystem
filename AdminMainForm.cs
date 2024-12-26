using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelManagementSystem
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = true;
            admin_addUser1.Visible = false;
            admin_rooms1.Visible = false;
            admin_customers1.Visible = false;

            admin_dashboard adDashboard = admin_dashboard1 as admin_dashboard;
            if (adDashboard != null)
            {
                adDashboard.refreshData();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirmation message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void addUser_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            admin_addUser1.Visible = true;
            admin_rooms1.Visible = false;
            admin_customers1.Visible = false;
            staff_bookRoom1.Visible = false;

            admin_addUser adAddUser = admin_addUser1 as admin_addUser;
            if (adAddUser != null)
            {
                adAddUser.refreshData();
            }
        }

        private void rooms_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            admin_addUser1.Visible = false;
            admin_rooms1.Visible = true;
            admin_customers1.Visible = false;
            staff_bookRoom1.Visible = false;

            admin_rooms adrooms = admin_rooms1 as admin_rooms;
            if (adrooms != null)
            {
                adrooms.refreshData();
            }
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            admin_addUser1.Visible = false;
            admin_rooms1.Visible = false;
            admin_customers1.Visible = true;
            staff_bookRoom1.Visible = false;

            admin_customers adCustomer = admin_customers1 as admin_customers;
            if (adCustomer != null)
            {
                adCustomer.refreshData();
            }
        }

        private void bookHotel_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            admin_addUser1.Visible = false;
            admin_rooms1.Visible = false;
            admin_customers1.Visible = false;
            staff_bookRoom1.Visible = true;

            staff_bookRoom bookHotel = staff_bookRoom1 as staff_bookRoom;
            if (bookHotel != null)
            {
                bookHotel.refreshData();
            }
        }
    }
}
