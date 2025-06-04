namespace hotelManagementSystem
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bookHotel_btn = new System.Windows.Forms.Button();
            this.logout_btn = new System.Windows.Forms.Button();
            this.customers_btn = new System.Windows.Forms.Button();
            this.addUser_btn = new System.Windows.Forms.Button();
            this.rooms_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.admin_customers1 = new hotelManagementSystem.admin_customers();
            this.staff_bookRoom1 = new hotelManagementSystem.staff_bookRoom();
            this.admin_rooms1 = new hotelManagementSystem.admin_rooms();
            this.admin_addUser1 = new hotelManagementSystem.admin_addUser();
            this.admin_dashboard1 = new hotelManagementSystem.admin_dashboard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // panel1
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 41);
            this.panel1.TabIndex = 0;
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hotel Management System";
            // close
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(1239, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(17, 17);
            this.close.TabIndex = 3;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // panel2
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.panel2.Controls.Add(this.bookHotel_btn);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.customers_btn);
            this.panel2.Controls.Add(this.addUser_btn);
            this.panel2.Controls.Add(this.rooms_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 714);
            this.panel2.TabIndex = 2;
            // bookHotel_btn
            this.bookHotel_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.bookHotel_btn.FlatAppearance.BorderSize = 0;
            this.bookHotel_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bookHotel_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bookHotel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookHotel_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookHotel_btn.ForeColor = System.Drawing.Color.White;
            this.bookHotel_btn.Location = new System.Drawing.Point(0, 371);
            this.bookHotel_btn.Name = "bookHotel_btn";
            this.bookHotel_btn.Size = new System.Drawing.Size(258, 47);
            this.bookHotel_btn.TabIndex = 22;
            this.bookHotel_btn.Text = "Book Room";
            this.bookHotel_btn.UseVisualStyleBackColor = false;
            this.bookHotel_btn.Click += new System.EventHandler(this.bookHotel_btn_Click);
            // logout_btn
            this.logout_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Location = new System.Drawing.Point(25, 649);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(209, 39);
            this.logout_btn.TabIndex = 21;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // customers_btn
            this.customers_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.customers_btn.FlatAppearance.BorderSize = 0;
            this.customers_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.customers_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customers_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_btn.ForeColor = System.Drawing.Color.White;
            this.customers_btn.Location = new System.Drawing.Point(0, 424);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(258, 47);
            this.customers_btn.TabIndex = 20;
            this.customers_btn.Text = "Customers";
            this.customers_btn.UseVisualStyleBackColor = false;
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // addUser_btn
            this.addUser_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.addUser_btn.FlatAppearance.BorderSize = 0;
            this.addUser_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addUser_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addUser_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUser_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUser_btn.ForeColor = System.Drawing.Color.White;
            this.addUser_btn.Location = new System.Drawing.Point(0, 265);
            this.addUser_btn.Name = "addUser_btn";
            this.addUser_btn.Size = new System.Drawing.Size(258, 47);
            this.addUser_btn.TabIndex = 19;
            this.addUser_btn.Text = "Add User";
            this.addUser_btn.UseVisualStyleBackColor = false;
            this.addUser_btn.Click += new System.EventHandler(this.addUser_btn_Click);
            // rooms_btn
            this.rooms_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.rooms_btn.FlatAppearance.BorderSize = 0;
            this.rooms_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rooms_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rooms_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rooms_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rooms_btn.ForeColor = System.Drawing.Color.White;
            this.rooms_btn.Location = new System.Drawing.Point(0, 318);
            this.rooms_btn.Name = "rooms_btn";
            this.rooms_btn.Size = new System.Drawing.Size(258, 47);
            this.rooms_btn.TabIndex = 18;
            this.rooms_btn.Text = "Rooms";
            this.rooms_btn.UseVisualStyleBackColor = false;
            this.rooms_btn.Click += new System.EventHandler(this.rooms_btn_Click);
            // dashboard_btn
            this.dashboard_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.dashboard_btn.FlatAppearance.BorderSize = 0;
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Location = new System.Drawing.Point(0, 212);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(258, 47);
            this.dashboard_btn.TabIndex = 3;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(56, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Welcome, User";
            // pictureBox1
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 80);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false; 
            // panel3
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.admin_dashboard1);
            this.panel3.Controls.Add(this.admin_addUser1);
            this.panel3.Controls.Add(this.admin_rooms1);
            this.panel3.Controls.Add(this.staff_bookRoom1);
            this.panel3.Controls.Add(this.admin_customers1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(258, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1010, 714);
            this.panel3.TabIndex = 3;
            // admin_customers1
            this.admin_customers1.Location = new System.Drawing.Point(0, 0);
            this.admin_customers1.Name = "admin_customers1";
            this.admin_customers1.Size = new System.Drawing.Size(1010, 714);
            this.admin_customers1.TabIndex = 0;
            // staff_bookRoom1
            this.staff_bookRoom1.Location = new System.Drawing.Point(0, 0);
            this.staff_bookRoom1.Name = "staff_bookRoom1";
            this.staff_bookRoom1.Size = new System.Drawing.Size(1010, 786);
            this.staff_bookRoom1.TabIndex = 1;
            // admin_rooms1
            this.admin_rooms1.Location = new System.Drawing.Point(0, 0);
            this.admin_rooms1.Name = "admin_rooms1";
            this.admin_rooms1.Size = new System.Drawing.Size(1010, 714);
            this.admin_rooms1.TabIndex = 2;
            // admin_addUser1
            this.admin_addUser1.Location = new System.Drawing.Point(0, 0);
            this.admin_addUser1.Name = "admin_addUser1";
            this.admin_addUser1.Size = new System.Drawing.Size(1010, 714);
            this.admin_addUser1.TabIndex = 3;
            // admin_dashboard1
            this.admin_dashboard1.Location = new System.Drawing.Point(0, 0);
            this.admin_dashboard1.Name = "admin_dashboard1";
            this.admin_dashboard1.Size = new System.Drawing.Size(1010, 714);
            this.admin_dashboard1.TabIndex = 4;
            // AdminMainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1268, 755);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button customers_btn;
        private System.Windows.Forms.Button addUser_btn;
        private System.Windows.Forms.Button rooms_btn;
        private System.Windows.Forms.Panel panel3;
        private admin_customers admin_customers1;
        private System.Windows.Forms.Button bookHotel_btn;
        private admin_dashboard admin_dashboard1;
        private admin_addUser admin_addUser1;
        private admin_rooms admin_rooms1;
        private staff_bookRoom staff_bookRoom1;
    }
}
