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
        TcpClient client;
        TcpListener server;
        imageHandler imageHandler = new imageHandler();
        NetworkStream ns;
        NetworkStream clientStream;
        Task task;
        bool conected = false;
        byte[] imagInBytes;
        byte[] buff;
        int count = 0;


        public form()
        {
            InitializeComponent();
        }

        private void ConectBtn_Click(object sender, EventArgs e)
        {
            if (!conected)
            {
                conected = true;
                if (!clientCheck.Checked)
                {
                    statLabel.Text = "wait for clients";
                    server = new TcpListener(IPAddress.Parse(ipTB.Text), Convert.ToInt32(portTb.Text));
                    server.Start();
                    //    new Task(waitConection).Start();
                    tryConect();
                    screenShotTimer.Start();
                 }
                else
                {

                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(ipTB.Text), Convert.ToInt32(portTb.Text));

                    statLabel.Text = "conected";

                    clientStream = client.GetStream();

                    Thread.SpinWait(200);

                    timerGet.Start();

                }
            }
        }

        void tryConect()
        {
            client = server.AcceptTcpClient();
            ns = client.GetStream();
        }

        void waitConection()
        {
            task = new Task(tryConect);
            task.Start();
            Task.WaitAll(task);
        }

        private void DisconectBtn_Click(object sender, EventArgs e)
        {
            closeConection();
            
        }

        private void ScreenShotTimer_Tick(object sender, EventArgs e)
        {
            if (client.Connected)
            {

                pictureBox.Image = imageHandler.ImageToSend(ref imagInBytes);

                byte[] len = BitConverter.GetBytes(imagInBytes.Length);

                ns.Write(len, 0, len.Length);
                ns.Write(imagInBytes, 0, imagInBytes.Length);
                statLabel.Text = imagInBytes.Length.ToString();
            }
            else
            {
                statLabel.Text = "lost conection";
                closeConection();
            }
        } 

        private void TimerGet_Tick(object sender, EventArgs e)
        {
            if (client.Connected&&clientStream.DataAvailable)
            {
                count = 0;
                byte[] lenInBytes = new byte[4];

                clientStream.Read(lenInBytes, 0, lenInBytes.Length);

                int len = BitConverter.ToInt32(lenInBytes, 0);

                statLabel.Text = len.ToString();

                try
                {
                    buff = new byte[len];

                    clientStream.Read(buff, 0, buff.Length);

                    pictureBox.Image = imageHandler.GetImage(buff);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                statLabel.Text = "no input data";
                if (count == 10)
                    closeConection();
                count++;
            }
        }

        void closeConection()
        {
            conected = false;
            if (clientCheck.Checked)
            {
                timerGet.Stop();
                if(clientStream != null)
                    clientStream.Close();
                if(client != null)
                    client.Close();
            }
            else
            {
                screenShotTimer.Stop();
                if(ns!=null)
                    ns.Close();
                if(server != null)
                    server.Stop();
            }
            statLabel.Text = "conection closed";
            pictureBox.Image = new Bitmap(1600, 1050);

        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeConection();
        }
    }
}
