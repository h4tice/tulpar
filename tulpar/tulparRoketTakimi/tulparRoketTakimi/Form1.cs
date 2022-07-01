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

namespace tulparRoketTakimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string data;//veri almak icin tanımlama yapildi.
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            string[] ports = SerialPort.GetPortNames();//port cekme islemi
            foreach(string port in ports)
            {
                comboBox1.Items.Add(port);//portlarımızı comboBox1'e ekledik.
            }
            serialPort1.DataReceived +=new SerialDataReceivedEventHandler(SerialPort_DataReceived);//Data alma eventi
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {//event olusturma islemi
            data = serialPort1.ReadLine();//data okuma islemi
            this.Invoke(new EventHandler(displaydata));//dataları  textBox'a yazdırmak için olusturduk

        }

        private void displaydata(object sender, EventArgs e)
        {
            string[] value = data.Split('/'); //deger ayarma islemi
            textBox2.Text = value[0];//irtifa
            textBox3.Text = value[1];//ivme-x
            textBox4.Text = value[2];//ivme-y
            textBox5.Text = value[3];//ivme-z
            textBox6.Text = value[4];//nem
            textBox7.Text = value[5];//basınc
            textBox8.Text = value[6];//sıcaklık
            textBox9.Text = value[7];//enlem
            textBox10.Text = value[8];//boylam
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Enabled = false;
                button2.Enabled = true;
                label15.Text = "Bağlantı Açık.";
                label15.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,("hata:"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort1.Close();
                button1.Enabled = true;
                button2.Enabled = false;
                label15.Text = "Bağlantı Kapalı.";
                label15.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ("hata:"));
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
    }
}
