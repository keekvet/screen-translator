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
        public Bitmap ImageToSend(ref byte[] bytes)
        {

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

            bitmap = new Bitmap(bitmap, 600, 400);

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
    }
}
