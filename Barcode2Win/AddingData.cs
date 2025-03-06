using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Barcode2Win
{
    public partial class AddingData : Form
    {

        private TcpListener tcpListener;
        private Thread listenerThread;
        private const int Port = 12345;
        private bool isListening = false;
        private string scannedBarcode = string.Empty;


        public AddingData()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            tcpListener.Start();

            isListening = true; 

            // Start a new thread to listen for incoming connections
            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();


            toolStripStatusLabel.Text = "Waiting for barcode data...";



        }

        private void ListenForClients()
        {
            while (isListening)
            {
                try
                {
                    // Accept incoming client connections
                    if (tcpListener.Pending()) // Check if there's any client pending
                    {
             
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();
                                Console.WriteLine("Client connected");


                        NetworkStream networkStream = tcpClient.GetStream();

                        byte[] buffer = new byte[1024]; // Buffer to store incoming data
                        int bytesRead;

                        while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            string barcodeData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            Console.WriteLine("Barcode Data Received: " + barcodeData);
                            UpdateBarcodeDisplay(barcodeData);
                        }

                        tcpClient.Close();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }

        private void UpdateBarcodeDisplay(string barcodeData)
        {
            // Use Invoke to update UI elements on the main thread
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateBarcodeDisplay), barcodeData);
            }
            else
            {
                // Update the Label with the received barcode data
                scannedBarcode = barcodeData; // Save the barcode data
                labelDisplay.Text = "Scanned Barcode: " + barcodeData;
                toolStripStatusLabel.Text = "Barcode received successfully!";

              
                MessageBox.Show("Barcode data received: " + barcodeData);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               
                isListening = false;

                
                if (tcpListener != null)
                {
                    tcpListener.Stop();
                }

                
                if (listenerThread != null && listenerThread.IsAlive)
                {
                    listenerThread.Join();
                }

                
            }
            finally
            {
                
                Environment.Exit(0);  
            }
        }


        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string barcode = textBoxBarcode.Text.Trim(); // Get the barcode text from the TextBox

            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("No barcode entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get product details from the TextBox controls
            string productName = textProductName.Text.Trim(); // Assuming textBoxProductName is the TextBox for product name
            decimal productPrice = 0m;
            int productQuantity = 0;

            // Validate the product price and quantity inputs
            if (!decimal.TryParse(textBoxProductPrice.Text, out productPrice))
            {
                MessageBox.Show("Invalid product price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxProductQuantity.Text, out productQuantity))
            {
                MessageBox.Show("Invalid product quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Send the barcode and product details to the database
            try
            {
                InsertBarcodeToDatabase(barcode, productName, productPrice, productQuantity);
                MessageBox.Show("Barcode data successfully sent to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                textBoxBarcode.Clear(); 
                textProductName.Clear(); 
                textBoxProductPrice.Clear(); 
                textBoxProductQuantity.Clear(); 


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending barcode data to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertBarcodeToDatabase(string barcode, string productName, decimal productPrice, int productQuantity)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barcode;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BarcodeTable (BarcodeData, ProductName, ProductPrice, ProductQuantity, ScannedAt) VALUES (@BarcodeData, @ProductName, @ProductPrice, @ProductQuantity, @ScannedAt)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@BarcodeData", barcode);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
                    cmd.Parameters.AddWithValue("@ProductQuantity", productQuantity);
                    cmd.Parameters.AddWithValue("@ScannedAt", DateTime.Now);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxProductPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxProductQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
