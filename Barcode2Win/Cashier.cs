using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode2Win
{
    public partial class Cashier: Form
    {


        public Cashier()
        {
            InitializeComponent();
                 
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CheckPrice());
        }

        private void Home_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadFormIntoPanel(Form form)
        {
            panelright.Controls.Clear(); // Clear previous form
            form.TopLevel = false; // Make it a child control
            form.FormBorderStyle = FormBorderStyle.None; // Remove title bar
            form.Dock = DockStyle.Fill; // Fit inside the panel
            panelright.Controls.Add(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin Open = new Admin();
            Open.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
