using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode2Win
{
    public partial class CheckPrice: Form
    {
        private DataTable barcodeTable = new DataTable();
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barcode;Integrated Security=True;";

        public CheckPrice()
        {
            InitializeComponent();

        }


        //The Code inserted here

        private void LoadData(string searchQuery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ID, ProductName, 
                            CONVERT(VARCHAR, ProductPrice) AS ProductPrice 
                     FROM BarcodeTable 
                     WHERE ProductName LIKE @Search OR BarcodeData LIKE @Search";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            barcodeTable.Clear();
                            adapter.Fill(barcodeTable);

                            datagridcashier.DataSource = null;
                            datagridcashier.DataSource = barcodeTable;
                            AdjustColumnWidths();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Cashier_Load(object sender, EventArgs e)
        {
            barcodeTable.Clear();
            datagridcashier.DataSource = barcodeTable;
        }



        //

        private void AdjustColumnWidths()
        {
            datagridcashier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust columns to fill the grid
        }


        // End of the inserted code
        private void searchCashier_TextChanged(object sender, EventArgs e)
        {

            string searchText = searchCashier.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                barcodeTable.Clear();
                datagridcashier.DataSource = null;
            }
            else
            {
                LoadData(searchText);
            }

        }
    }
}
