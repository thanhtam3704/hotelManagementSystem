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
    public partial class staffMainForm : Form
    {
        public staffMainForm()
        {
            InitializeComponent();
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
        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = true;
            staff_bookRoom1.Visible = false;
            admin_customers1.Visible = false;

            admin_dashboard adDashboard = admin_dashboard1 as admin_dashboard;
            if (adDashboard != null)
            {
                adDashboard.refreshData();
            }
        }

        private void bookHotel_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            staff_bookRoom1.Visible = true;
            admin_customers1.Visible = false;

            staff_bookRoom bookHotel = staff_bookRoom1 as staff_bookRoom;
            if (bookHotel != null)
            {
                bookHotel.refreshData();
            }
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            staff_bookRoom1.Visible = false;
            admin_customers1.Visible = true;

            admin_customers adCustomer = admin_customers1 as admin_customers;
            if (adCustomer != null)
            {
                adCustomer.refreshData();
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void staff_bookRoom1_Load(object sender, EventArgs e)
        {

        }

        private void staff_bookRoom1_Load_1(object sender, EventArgs e)
        {

        }

        
    }
}
