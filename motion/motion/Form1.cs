using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using motion;

namespace motion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SerialPropeties()
        {
            Servo_SerialPort.PortName = cbPortName.Text;
            Servo_SerialPort.BaudRate = Convert.ToInt32(cbBaudRate.Text);
            Servo_SerialPort.DataBits = 0x08;
            Servo_SerialPort.Parity = Parity.None;
            Servo_SerialPort.StopBits = StopBits.One;           
        }
        private void SendData()
        {
            System.Text.Encoding.Default.GetBytes(tbSpeed.Text);
            Servo_SerialPort.Write(tbSpeed.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            SerialPropeties();            
            
            if(!Servo_SerialPort.IsOpen)
            {
                Servo_SerialPort.Open();
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(Servo_SerialPort.IsOpen)
            {
                SendData();
            }
        }
    }
}
