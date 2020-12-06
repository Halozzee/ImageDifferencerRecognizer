using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;

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

        public static void DrawRectangles(Bitmap bm, List<KeyValuePair<Point, Point>> Lpoint)
        {
            foreach (var item in Lpoint)
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawRectangle(new Pen(Color.Red), new Rectangle(item.Key.X, item.Key.Y,
                        Math.Abs(item.Key.X - item.Value.X), Math.Abs(item.Key.Y - item.Value.Y)));
                    g.Save();
                }
            }
        }

        public static void DrawRectangles(Bitmap bm, List<Rectangle> rs)
        {
            foreach (var item in rs)
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawRectangle(new Pen(Color.Red), item);
                    g.Save();
                }
            }
        }

        public static void NameRectangles(Bitmap bm, List<KeyValuePair<Point, Point>> Lpoint, string text) 
        {
            foreach (var item in Lpoint)
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawString(text, new Font("Arial", 16), Brushes.Red, 
                        new PointF((item.Key.X + item.Value.X)/2, item.Value.Y + 10));
                    g.Save();
                }
            }
        }

        public static void NameRectangles(Bitmap bm, List<Rectangle> rs, string text)
        {
            foreach (var item in rs)
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawString(text, new Font("Arial", 16), Brushes.Red,
                        new PointF((item.Location.X + item.Location.X + item.Width) / 2, item.Bottom + 10));
                    g.Save();
                }
            }
        }
        public static int RGBToGreyScale(Color c)
        {
            return (int)(c.R * 0.2126 + c.B * 0.7152 + c.G * 0.0722);
        }
        public static Bitmap ToGrayScale(this Bitmap bm) 
        {
            Bitmap res = ImageWorks.PaintOn32bpp((Bitmap)bm.Clone());
            FastBitmap fbm = new FastBitmap(res);

            fbm.Lock();

            for (int i = 0; i < fbm.Width; i++)
            {
                for (int j = 0; j < fbm.Height; j++)
                {
                    Color c = fbm.GetPixel(i, j);
                    int greyVal = RGBToGreyScale(c);
                    fbm.SetPixel(i, j, Color.FromArgb(greyVal, greyVal, greyVal));
                }
            }

            fbm.Unlock();
            return res;
        }
    }
}