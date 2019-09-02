using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace screenTranslator2
{
    class UDPImageClient : UdpClient
    {
        const int PACK_LEN = 65500;
        IPEndPoint iPEndPoint = null;
        int max;
        public byte[] result;
        byte[] buff;
        byte[] tmp;
        public bool canRead;
        int packCount;
        byte[] lenInByte = new byte[PACK_LEN-1];

        public UDPImageClient() : base() { }
        public UDPImageClient(int port) : base(port) { }


        public void SendLongArr(byte[] arr, IPEndPoint endPoint)
        {
            byte[] buff = new byte[PACK_LEN];
            int len = arr.Length;
            packCount = (len / PACK_LEN) + 1;
            lenInByte[0] = (byte)packCount;
            if (max < packCount)
            {
                max = packCount;
                Console.WriteLine(max);
            }
            for (int i = 0; i < packCount; i++)
            {
                if (i < packCount - 1)
                    Array.Copy(arr, i * PACK_LEN, buff, 0, PACK_LEN);
                else
                {
                    buff = new byte[PACK_LEN];
                    Array.Copy(arr, i * PACK_LEN, buff, 0, len % PACK_LEN);
                }
                Thread.Sleep(17);

                Send(buff, buff.Length, endPoint);
            }
            Thread.Sleep(17);

            Send(buff, 1, endPoint);

        }

        public void GetImageInByte()
        {
            result = new byte[PACK_LEN * 10];
            
            int i = 0;
            while (true)
            {
                if (i == 0)
                    result = new byte[PACK_LEN * 10];
                
                buff = Receive(ref iPEndPoint);

                if (buff.Length < PACK_LEN || i > 9)
                {
                    Console.WriteLine("break");
                    i = 0;
                    canRead = true;
                    while (canRead) { Thread.Sleep(5); }
                    continue;
                }
                Console.WriteLine(buff.Length + " " + buff[0] + " " + i);
                Array.Copy(buff, 0, result, i * PACK_LEN, buff.Length);
                i++;
            }
        }




            //public void SendLongArr(byte[] arr, IPEndPoint endPoint)
            //{
            //    byte[] buff = new byte[PACK_LEN];
            //    int len = arr.Length;
            //    int packCount = len / PACK_LEN + 1;
            //    lenInByte[0] = (byte)packCount;
            //    Send(lenInByte, PACK_LEN-1, endPoint);

            //    for (int i = 0; i < packCount; i++)
            //    {
            //        if(i < packCount-1)
            //            Array.Copy(arr, i * PACK_LEN, buff, 0, PACK_LEN);
            //        else
            //        {
            //            buff = new byte[PACK_LEN];
            //            Array.Copy(arr, i * PACK_LEN, buff, 0, len % PACK_LEN);
            //        }
            //        Console.WriteLine(buff.Length);
            //        Send(buff, buff.Length, endPoint);
            //    }
            //}

            //public void GetImageInByte()
            //{

            //    while (true)
            //    {
            //        while (tmp == null || tmp.Length == PACK_LEN)
            //        {
            //            Console.WriteLine("skip");
            //            tmp = Receive(ref iPEndPoint);
            //        }
            //        byte packCount = tmp[0];
            //        Console.WriteLine(tmp.Length + " " + tmp[0] + " " + packCount);
            //        result = new byte[PACK_LEN * packCount];

            //        for (int i = 0; i < packCount; i++)
            //        {
            //            buff = Receive(ref iPEndPoint);
            //            if (buff.Length < PACK_LEN)
            //            {
            //                Console.WriteLine("break");
            //                break;
            //            }
            //            Console.WriteLine(buff.Length + " " + buff[0] + " " + i);
            //            Array.Copy(buff, 0, result, i * PACK_LEN, buff.Length);
            //        }
            //        canRead = true;
            //        while (canRead) { }
            //    }

            //}

            //------------------------------------------------------------------------
            //public byte[] Get()
            //{

            //    while (tmp == null || tmp.Length > 1)
            //    {
            //        tmp = Receive(ref iPEndPoint);
            //    }
            //    byte packCount = tmp[0];

            //    Console.WriteLine(tmp.Length + " " + tmp[0]);

            //    result = new byte[PACK_LEN * packCount];

            //    for (int i = 0; i < packCount; i++)
            //    {
            //        buff = Receive(ref iPEndPoint);
            //        if (buff.Length == 1)
            //            return null;
            //        Console.WriteLine(buff.Length+" "+buff[0]);
            //        Array.Copy(buff,0,result,i * PACK_LEN, buff.Length);
            //    }

            //    return result;
            //}

        }
}
