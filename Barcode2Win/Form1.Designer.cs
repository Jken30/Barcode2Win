namespace Barcode2Win
{
    partial class Form1
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
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(15, 79);
            this.textBoxBarcode.Multiline = true;
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(170, 20);
            this.textBoxBarcode.TabIndex = 0;
            this.textBoxBarcode.TextChanged += new System.EventHandler(this.textBoxBarcode_TextChanged);
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Location = new System.Drawing.Point(12, 50);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(170, 13);
            this.labelDisplay.TabIndex = 1;
            this.labelDisplay.Text = "Scanned Barcode will appear here";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 127);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(204, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel.Text = "\"Waiting for barcode...\"";
            this.toolStripStatusLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 149);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.textBoxBarcode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

