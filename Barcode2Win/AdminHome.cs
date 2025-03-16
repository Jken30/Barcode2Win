using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlTypes;

namespace Barcode2Win
{
    public partial class Admin : Form
    {

        private DataTable barcodeTable = new DataTable();
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barcode;Integrated Security=True;";

        public Admin()
        {
            InitializeComponent();
           
        }



        // The inserted code here 


        private void LoadData(string searchQuery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ID, BarcodeData, ProductName, 
                                    CONVERT(VARCHAR, ProductPrice) AS ProductPrice, 
                                    ProductQuantity, 
                                    CONVERT(VARCHAR, ScannedAt, 120) AS ScannedAt 
                             FROM BarcodeTable 
                             WHERE ProductName LIKE @Search OR BarcodeData LIKE @Search";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            barcodeTable.Clear();
                            adapter.Fill(barcodeTable);

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = barcodeTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            barcodeTable.Clear(); // ❌ Don't load data initially
            dataGridView1.DataSource = barcodeTable;
        }


        // End of inserted code

        private void Dashboard_Click(object sender, EventArgs e)
        {

        }

        private void ProductManagement_Click(object sender, EventArgs e)
        {

        }

        private void SalesReports_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void search_TextChanged(object sender, EventArgs e)
        {

            string searchText = search.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                barcodeTable.Clear(); // 🧹 If search box is empty, clear the table
                dataGridView1.DataSource = null;
            }
            else
            {
                LoadData(searchText); // 🔍 Otherwise, fetch results dynamically
            }

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddData_Click(object sender, EventArgs e)
        {
            AddingData Open = new AddingData(); // Create an instance of the new form
            Open.Show(); // Open without closing the main form
        }
    }
}
