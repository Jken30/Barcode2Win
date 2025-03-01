using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

                // Get the stream for reading data
                NetworkStream networkStream = tcpClient.GetStream();

                byte[] buffer = new byte[1024]; // Buffer to store incoming data
                int bytesRead;

                while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string barcodeData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    UpdateBarcodeDisplay(barcodeData);
                }

                tcpClient.Close();
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
                labelDisplay.Text = "Scanned Barcode: " + barcodeData;
                toolStripStatusLabel.Text = "Barcode received successfully!";
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
    }
}
