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

namespace screenTranslator2
{
    public partial class form : Form
    {
        UDPImageClient client;
        IPEndPoint iPEndPoint = null;
        ImageHandler imageHandler = new ImageHandler();
        int i;
        byte[] bytes;

        public form()
        {
            InitializeComponent();
        }

        private void ConectBtn_Click(object sender, EventArgs e)
        {

            if (clientCheck.Checked)
            {
                client = new UDPImageClient();

                screenShotTimer.Start();
            }
            else
            {
                client = new UDPImageClient(Convert.ToInt32(portTb.Text));
                client.JoinMulticastGroup(IPAddress.Parse(ipTB.Text),50);

                timerGet.Start();
            }
        }

        
        private void DisconectBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ScreenShotTimer_Tick(object sender, EventArgs e)
        {
            i++;
            string str = "first message";
            str += i.ToString();
            Console.WriteLine("sending" + i);
            pictureBox.Image = imageHandler.ImageToSend(ref bytes);
            client.SendLongArr(bytes, new IPEndPoint(IPAddress.Parse(ipTB.Text), Convert.ToInt32(portTb.Text)));   
            
        }

        private void TimerGet_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("recive");
            pictureBox.Image = imageHandler.GetImage( client.Get());
        }

        void closeConection()
        {
    
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
