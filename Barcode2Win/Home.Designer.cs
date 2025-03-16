namespace Barcode2Win
{
    partial class Admin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.SalesReports = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.ProductManagement = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.TextBox();
            this.AddData = new System.Windows.Forms.Button();
            this.panelContent.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelContent.Controls.Add(this.Logout);
            this.panelContent.Controls.Add(this.Settings);
            this.panelContent.Controls.Add(this.SalesReports);
            this.panelContent.Controls.Add(this.Dashboard);
            this.panelContent.Controls.Add(this.ProductManagement);
            this.panelContent.Location = new System.Drawing.Point(12, 12);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(156, 426);
            this.panelContent.TabIndex = 0;
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(0, 352);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(156, 62);
            this.Logout.TabIndex = 6;
            this.Logout.Text = "Logout ";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(0, 284);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(156, 62);
            this.Settings.TabIndex = 5;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // SalesReports
            // 
            this.SalesReports.Location = new System.Drawing.Point(0, 216);
            this.SalesReports.Name = "SalesReports";
            this.SalesReports.Size = new System.Drawing.Size(156, 62);
            this.SalesReports.TabIndex = 4;
            this.SalesReports.Text = "Sales Reports";
            this.SalesReports.UseVisualStyleBackColor = true;
            this.SalesReports.Click += new System.EventHandler(this.SalesReports_Click);
            // 
            // Dashboard
            // 
            this.Dashboard.Location = new System.Drawing.Point(0, 83);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(156, 59);
            this.Dashboard.TabIndex = 2;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.UseVisualStyleBackColor = true;
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // ProductManagement
            // 
            this.ProductManagement.Location = new System.Drawing.Point(0, 148);
            this.ProductManagement.Name = "ProductManagement";
            this.ProductManagement.Size = new System.Drawing.Size(156, 62);
            this.ProductManagement.TabIndex = 3;
            this.ProductManagement.Text = " Product Management";
            this.ProductManagement.UseVisualStyleBackColor = true;
            this.ProductManagement.Click += new System.EventHandler(this.ProductManagement_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.AddData);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(174, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 382);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(637, 338);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(174, 30);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(162, 20);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // AddData
            // 
            this.AddData.Location = new System.Drawing.Point(269, 347);
            this.AddData.Name = "AddData";
            this.AddData.Size = new System.Drawing.Size(93, 23);
            this.AddData.TabIndex = 1;
            this.AddData.Text = "Add";
            this.AddData.UseVisualStyleBackColor = true;
            this.AddData.Click += new System.EventHandler(this.AddData_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 448);
            this.Controls.Add(this.search);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelContent);
            this.Name = "Admin";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panelContent.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SalesReports;
        private System.Windows.Forms.Button Dashboard;
        private System.Windows.Forms.Button ProductManagement;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddData;
    }
}