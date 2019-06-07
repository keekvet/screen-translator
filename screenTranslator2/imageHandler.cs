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
    class ImageHandler
    {
        Image image;
        Image lastImag;
        public Bitmap ImageToSend(ref byte[] bytes)
        {

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

            bitmap = new Bitmap(bitmap, 1440, 900);

            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                bytes = ms.ToArray();
            }

            return bitmap;
        }
        public Image GetImage(byte[] bytes)
        {
            if (bytes != null)
            {
                var ms = new MemoryStream(bytes);
                ms.Position = 0;
                try
                {
                    image = Image.FromStream(ms);
                    lastImag = image;
                }
                catch (Exception e)
                {
                    Console.WriteLine("iamge skipped");
                    image = lastImag;
                }
            }
            if (image == null)
            {
                image = new Bitmap(200, 200);
            }
            
            return image; 
        }
    }
}
