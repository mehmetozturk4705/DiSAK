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

namespace DisAK
{
    public partial class DiPOD : Form
    {
        public DiPOD()
        {
            InitializeComponent();
        }
        private double yaw = 0, pitch = 0, roll = 0,yawraw = 0, pitchraw = 0, rollraw = 0,
            yawoff = 0, pitchoff = 0, rolloff = 0
            ;
        Imlec fare = new Imlec();
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            try
            {
                comboBox1.Text = SerialPort.GetPortNames()[0];
            }
            catch(Exception exc)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text.Equals(""))
                MessageBox.Show("Lütfen bir port seçiniz");
            else
            {
                serialPort1.BaudRate = 9600;
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                timer1.Enabled = true;
            }
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            serialPort1.DataReceived -= data_received;
            serialPort1.Close();
            timer1.Enabled = false;
            
        }

        private void data_received(object sender, SerialDataReceivedEventArgs e)
        {
            String cevap = serialPort1.ReadLine();
           
            if (cevap.StartsWith("*"))
            {
                label1.Invoke((Action)delegate
                {
                    cevap = cevap.Substring(1);
                    String yawstr = "",pitchstr  = "", rollstr = "";
                    yawstr = cevap.Substring(0, cevap.IndexOf('|'));
                    cevap = cevap.Substring(cevap.IndexOf('|') + 1);
                    pitchstr = cevap.Substring(0, cevap.IndexOf('|'));
                    cevap = cevap.Substring(cevap.IndexOf('|') + 1);
                    rollstr = cevap.Substring(0, cevap.IndexOf('|'));
                    yawraw = double.Parse(yawstr,System.Globalization.CultureInfo.InvariantCulture);
                    pitchraw = double.Parse(pitchstr, System.Globalization.CultureInfo.InvariantCulture);
                    rollraw = double.Parse(rollstr, System.Globalization.CultureInfo.InvariantCulture);
                    
                    
                });
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            yaw = hesapla(yawraw, yawoff, true);
            pitch= hesapla(pitchraw, pitchoff, false);
            roll = rollraw;
            yaw = Math.Round(yaw, 2);
            pitch = Math.Round(pitch, 2);
            fare.feed((float)(-yaw*2), (float)(-pitch*2),10);

            fare.calistir(true);
            label1.Text = "Yaw:" + yaw + " Pitch:" + pitch + " Roll:" + roll;
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            serialPort1.Close();
            timer1.Enabled = false;

        }
        private double hesapla(double raw,double offset, bool butunleyen){
            double sinir=90;
            if(butunleyen)sinir=180;
            double sonuc = raw + offset;

            if(sonuc>sinir)
            {
                sonuc = -(sinir - (Math.Abs(sonuc)-sinir));
            }
            if(sonuc<-sinir)
            {
                sonuc = -(sinir - (Math.Abs(sonuc)-sinir));
            }

           


            return sonuc;
            
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yawoff = -yawraw;
            pitchoff = -pitchraw;
        }

        private void keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1) button4_Click(sender, new EventArgs());
        }
    }
}
