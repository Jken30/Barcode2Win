namespace Barcode2Win
{
    partial class CheckPrice
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
            this.datagridcashier = new System.Windows.Forms.DataGridView();
            this.searchCashier = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcashier)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridcashier
            // 
            this.datagridcashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridcashier.Location = new System.Drawing.Point(13, 49);
            this.datagridcashier.Name = "datagridcashier";
            this.datagridcashier.Size = new System.Drawing.Size(461, 342);
            this.datagridcashier.TabIndex = 0;
            // 
            // searchCashier
            // 
            this.searchCashier.Location = new System.Drawing.Point(13, 23);
            this.searchCashier.Name = "searchCashier";
            this.searchCashier.Size = new System.Drawing.Size(232, 20);
            this.searchCashier.TabIndex = 1;
            this.searchCashier.TextChanged += new System.EventHandler(this.searchCashier_TextChanged);
            // 
            // CheckPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 401);
            this.Controls.Add(this.searchCashier);
            this.Controls.Add(this.datagridcashier);
            this.Location = new System.Drawing.Point(161, 0);
            this.Name = "CheckPrice";
            this.Text = "CheckPrice";
            ((System.ComponentModel.ISupportInitialize)(this.datagridcashier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridcashier;
        private System.Windows.Forms.TextBox searchCashier;
    }
}