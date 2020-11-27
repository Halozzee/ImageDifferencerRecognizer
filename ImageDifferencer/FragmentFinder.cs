using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDifferencer
{
   
    public static class FragmentFinder
    {
        public static void FindImage(Bitmap Base, Bitmap LookFor, double requiredToPass, out List<KeyValuePair<Point, Point>> Lpoint) 
        {
            Bitmap b = ImageWorks.PaintOn32bpp((Bitmap)Base.Clone());
            Bitmap l = ImageWorks.PaintOn32bpp((Bitmap)LookFor.Clone());

            FastBitmap bs = new FastBitmap(b);
            FastBitmap lf = new FastBitmap(l);

            Lpoint = new List<KeyValuePair<Point, Point>>();

            bs.Lock();
            lf.Lock();

            for (int i = 0; i < Base.Width; i++)
            {
                for (int j = 0; j < Base.Height; j++)
                {
                    int g = i;
                    int t = j;

                    int r = 0;
                    int e = 0;

                    bool preBreaked = false;
                    long comparedGood = 0;

                    while (Differencer.WiseRGBDifferencePercent(bs.GetPixel(g, t), lf.GetPixel(r, e), requiredToPass))
                    {
                        if (g + 1 == Base.Width || t + 1 == Base.Height || t - j + 1 == lf.Height)
                        {
                            preBreaked = true;
                            break;
                        }
                        comparedGood++;

                        g++; 
                        r++;

                        if (g - i == lf.Width)
                        {
                            g = i;
                            t++;
                        }

                        if (r == lf.Width)
                        {
                            r = 0;
                            e++;
                        }
                    }

                    if (!preBreaked)
                    {
                        if((double)comparedGood >= lf.Width * lf.Height / 100)
                            Lpoint.Add(new KeyValuePair<Point, Point>(new Point(i, j), new Point(i + lf.Width, j + lf.Height)));
                    }
                }
            }

            bs.Unlock();
            lf.Unlock();
        }
        public static void DrawRectangles(Bitmap bm, List<KeyValuePair<Point, Point>> Lpoint) 
        {
            foreach (var item in Lpoint)
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawRectangle(new Pen(Color.Green), new Rectangle(item.Key.X, item.Key.Y, 
                        Math.Abs(item.Key.X - item.Value.X), Math.Abs(item.Key.Y - item.Value.Y)));
                    g.Save();
                }
            }
        }
    }
}