using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        //RGB 3 byte STUFF ONLY!!!!

        public static List<Rectangle> FastFinder(Bitmap bigBmp, Bitmap smallBmp, double tolerance)
        {
            BitmapData smallData =
      smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
               System.Drawing.Imaging.ImageLockMode.ReadOnly,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData =
              bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            List<Rectangle> rs = new List<Rectangle>();

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            if (!matchFound)
                            {
                                break; 
                            }

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            rs.Add(location);
                            matchFound = false;
                        }

                        pBig = pBigBackup;
                        pSmall = pSmallBackup;
                        pBig += 3;
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return rs;
        }

    }
}