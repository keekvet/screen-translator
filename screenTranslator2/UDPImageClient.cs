using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace screenTranslator2
{
    class UDPImageClient : UdpClient
    {
        const int PACK_LEN = 64000;
        IPEndPoint iPEndPoint = null;
        public UDPImageClient() : base() { }
        public UDPImageClient(int port) : base(port) { }
        public void SendLongArr(byte[] arr, IPEndPoint endPoint)
        {
            byte[] buff = new byte[PACK_LEN];
            int len = arr.Length;
            int packCount = len / PACK_LEN + 1;
            Send(new byte[] { (byte)packCount }, 1, endPoint);
            for (int i = 0; i < packCount; i++)
            {
                if(i!=packCount-1)
                    Array.Copy(arr, i * PACK_LEN, buff, 0, PACK_LEN);
                else
                {
                    buff = new byte[PACK_LEN];
                    Array.Copy(arr, i * PACK_LEN, buff, 0, len % PACK_LEN);
                }

                Send(buff, buff.Length, endPoint);
            }


        }
        public byte[] Get()
        {
            byte[] result;
            byte[] buff = new byte[PACK_LEN];
            byte[] tmp = Receive(ref iPEndPoint);
            byte packCount = 0;
            packCount = tmp[0];
            Console.WriteLine(packCount);
            result = new byte[PACK_LEN * packCount];
            for (int i = 0; i < packCount; i++)
            {
                buff = Receive(ref iPEndPoint);
                Console.WriteLine(buff.Length);
                Array.Copy(buff,0,result,i * PACK_LEN, buff.Length);
            }

            return result;
        }

    }
}
