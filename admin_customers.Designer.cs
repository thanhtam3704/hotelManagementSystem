namespace hotelManagementSystem
{
    partial class admin_customers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel = new System.Windows.Forms.Panel();
            this.chkCheckedOut = new System.Windows.Forms.CheckBox();
            this.chkCheckedIn = new System.Windows.Forms.CheckBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.chkNotCheckIn = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.client_bookBtn = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.chkCheckedOut);
            this.panel.Controls.Add(this.chkCheckedIn);
            this.panel.Controls.Add(this.btnExportToExcel);
            this.panel.Controls.Add(this.chkNotCheckIn);
            this.panel.Controls.Add(this.BtnCancel);
            this.panel.Controls.Add(this.btnCheckOut);
            this.panel.Controls.Add(this.client_bookBtn);
            this.panel.Controls.Add(this.btnSearch);
            this.panel.Controls.Add(this.txtSearch);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.dataGridView1);
            this.panel.Location = new System.Drawing.Point(13, 14);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(980, 681);
            this.panel.TabIndex = 1;
            // 
            // chkCheckedOut
            // 
            this.chkCheckedOut.AutoSize = true;
            this.chkCheckedOut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckedOut.Location = new System.Drawing.Point(818, 564);
            this.chkCheckedOut.Name = "chkCheckedOut";
            this.chkCheckedOut.Size = new System.Drawing.Size(146, 25);
            this.chkCheckedOut.TabIndex = 26;
            this.chkCheckedOut.Text = "Checked Out";
            this.chkCheckedOut.UseVisualStyleBackColor = true;
            this.chkCheckedOut.CheckedChanged += new System.EventHandler(this.chkCheckedOut_CheckedChanged);
            // 
            // chkCheckedIn
            // 
            this.chkCheckedIn.AutoSize = true;
            this.chkCheckedIn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckedIn.Location = new System.Drawing.Point(630, 564);
            this.chkCheckedIn.Name = "chkCheckedIn";
            this.chkCheckedIn.Size = new System.Drawing.Size(132, 25);
            this.chkCheckedIn.TabIndex = 25;
            this.chkCheckedIn.Text = "Checked In";
            this.chkCheckedIn.UseVisualStyleBackColor = true;
            this.chkCheckedIn.CheckedChanged += new System.EventHandler(this.chkCheckedIn_CheckedChanged);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExportToExcel.FlatAppearance.BorderSize = 0;
            this.btnExportToExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.btnExportToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportToExcel.Location = new System.Drawing.Point(754, 608);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(210, 39);
            this.btnExportToExcel.TabIndex = 24;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // chkNotCheckIn
            // 
            this.chkNotCheckIn.AutoSize = true;
            this.chkNotCheckIn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotCheckIn.Location = new System.Drawing.Point(426, 564);
            this.chkNotCheckIn.Name = "chkNotCheckIn";
            this.chkNotCheckIn.Size = new System.Drawing.Size(146, 25);
            this.chkNotCheckIn.TabIndex = 23;
            this.chkNotCheckIn.Text = "Not Check In";
            this.chkNotCheckIn.UseVisualStyleBackColor = true;
            this.chkNotCheckIn.CheckedChanged += new System.EventHandler(this.chkNotCheckIn_CheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(499, 608);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(210, 39);
            this.BtnCancel.TabIndex = 22;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.btnCheckOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(257, 608);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(213, 39);
            this.btnCheckOut.TabIndex = 21;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // client_bookBtn
            // 
            this.client_bookBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.client_bookBtn.FlatAppearance.BorderSize = 0;
            this.client_bookBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.client_bookBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.client_bookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.client_bookBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_bookBtn.ForeColor = System.Drawing.Color.White;
            this.client_bookBtn.Location = new System.Drawing.Point(19, 608);
            this.client_bookBtn.Name = "client_bookBtn";
            this.client_bookBtn.Size = new System.Drawing.Size(192, 39);
            this.client_bookBtn.TabIndex = 20;
            this.client_bookBtn.Text = "Check In";
            this.client_bookBtn.UseVisualStyleBackColor = false;
            this.client_bookBtn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(834, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 30);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(481, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(324, 34);
            this.txtSearch.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "All Customers";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(19, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(945, 474);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // admin_customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "admin_customers";
            this.Size = new System.Drawing.Size(1010, 714);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button client_bookBtn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox chkNotCheckIn;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.CheckBox chkCheckedOut;
        private System.Windows.Forms.CheckBox chkCheckedIn;
    }
}
