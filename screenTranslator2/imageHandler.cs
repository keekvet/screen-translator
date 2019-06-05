using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenTranslator2
{
    class imageHandler
    {
        public Bitmap ImageToSend(ref byte[] bytes)
        {

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

            bitmap = new Bitmap(bitmap, 1680, 1050);

            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                bytes = ms.ToArray();
            }
            return bitmap;
        }
        public Image GetImage(byte[] bytes)
        {
            var ms = new MemoryStream(bytes);
            ms.Position = 0;

            return Image.FromStream(ms);
        }

        //public Bitmap ImageToSend(List<byte[]> bytes)
        //{
        //    byte[] picInBytes;
        //    byte[] packetCount;
        //    byte[] buffPacket;

        //    Rectangle bounds = Screen.GetBounds(Point.Empty);
        //    Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

        //    bitmap = new Bitmap(bitmap, 1680, 1050);

        //    using (var ms = new MemoryStream())
        //    {
        //        bitmap.Save(ms, ImageFormat.Jpeg);
        //        picInBytes = ms.ToArray();
        //    }

        //    packetCount = new byte[] { (byte)(picInBytes.Length / 64000 + 1) };

        //    bytes.Add(packetCount);

        //    for (int i = 0; i < packetCount[0]; i++)
        //    {
        //        if (i == packetCount[0] - 1) {
        //            buffPacket = new byte[picInBytes.Length % 64000];
        //            Array.Copy(picInBytes, 64000 * i, buffPacket, 0, buffPacket.Length);
        //        }
        //        else {
        //            buffPacket = new byte[64000];
        //            Array.Copy(picInBytes, 64000 * i, buffPacket, 0, 64000);
        //        }
        //        bytes.Add(buffPacket);
        //    }
        //    return bitmap;
        //}
        //public Image GetImage(List<byte[]> bytes)
        //{
        //    bytes.RemoveAt(0);
        //    int bytesLen = 0;
        //    byte[] conectedBytes;
        //    int counter = 0;

        //    foreach (byte[] buff in bytes)
        //    {
        //        bytesLen += buff.Length;
        //    }

        //    conectedBytes = new byte[bytesLen];

        //    foreach (byte[] buff in bytes)
        //    {
        //        int i;
        //        for (i = 0; i < buff.Length; i++)
        //        {
        //            conectedBytes[counter+i] = buff[i]; 
        //        }
        //        counter += i;
        //    }

        //    var ms = new MemoryStream(conectedBytes);
        //    ms.Position = 0;

        //    return Image.FromStream(ms);
        //}


    }
}
