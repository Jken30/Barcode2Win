using System;
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
    public partial class Form1 : Form
    {

        private TcpListener tcpListener;
        private const int Port = 12345; // You can choose any available port.
        private string scannedBarcode = string.Empty; // To hold the scanned barcode data


        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();

            // Start a new thread to listen for incoming connections
            Thread listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();

            // Update status message
            toolStripStatusLabel.Text = "Waiting for barcode data...";
        }

        private void ListenForClients()
        {
            while (true)
            {
                // Accept incoming client connections
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Console.WriteLine("Client connected");

                // Get the stream for reading data
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

        private void UpdateBarcodeDisplay(string barcodeData)
        {
            // Use Invoke to update UI elements on the main thread
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

                // Debugging - Show a message box with the barcode data
                MessageBox.Show("Barcode data received: " + barcodeData);
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the TCP listener when the form is closing
            if (tcpListener != null)
            {
                tcpListener.Stop();
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

            // Send the barcode to the database
            try
            {
                InsertBarcodeToDatabase(barcode); // Use the barcode from the TextBox
                MessageBox.Show("Barcode data successfully sent to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending barcode data to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertBarcodeToDatabase(string barcode)
        {
            // Define your connection string (make sure to replace the placeholders with actual values)
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barcode;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BarcodeTable (BarcodeData, ScannedAt) VALUES (@BarcodeData, @ScannedAt)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BarcodeData", barcode);
                    cmd.Parameters.AddWithValue("@ScannedAt", DateTime.Now);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
