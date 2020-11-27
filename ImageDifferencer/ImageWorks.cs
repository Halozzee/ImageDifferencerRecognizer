using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDifferencer
{
    public static class ImageWorks
    {
        public static Bitmap PaintOn32bpp(Image image)
        {
            Bitmap bp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(bp))
                gr.DrawImage(image, new Rectangle(0, 0, bp.Width, bp.Height));
            return bp;
        }
    }
}