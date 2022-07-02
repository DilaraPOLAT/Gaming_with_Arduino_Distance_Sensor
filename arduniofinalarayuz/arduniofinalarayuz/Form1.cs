using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace arduniofinalarayuz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String data;
        private bool buton = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
          
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displaydata));
        }
        private const int v = 10;
        private void displaydata(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(data);
            label3.Text ="Mesafe :"+ data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Enabled=false;
                button2.Enabled = true;
                label2.Text = "Bağlantı Açık";
                label2.ForeColor = Color.Green;
                timer1.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                timer1.Stop();
                button1.Enabled = true;
                button2.Enabled = false;
                label2.Text = "Bağlantı Kapalı";
                label2.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top = 493;
           
            if (pictureBox2.Left>=800 || pictureBox2.Left <= 10)
            {

                pictureBox2.Left =0;
            }
           
            if(Convert.ToInt32(data)>30)
            {
                pictureBox2.Left -= 10;
            }
            else if(Convert.ToInt32(data) > 6 && Convert.ToInt32(data) < 30)
            {
                pictureBox2.Left -= 10;
            }
            else
            {
                pictureBox2.Left += 10;
            }
             if (buton==true)
            {
                pictureBox1.Top -= 50;
                buton = false;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            buton = true;
        }
    }
}
