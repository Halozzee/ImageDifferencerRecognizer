using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDifferencer
{
    public static class Differencer
    {
        private static int RGBToGreyScale(Color c)
        {
            return (int)(c.R * 0.2126 + c.B * 0.7152 + c.G * 0.0722);
        }

        public static double DifferencePercent(int SumA, int SumB)
        {
            double val = (double)Math.Abs(SumA - SumB) / 100;
            return val;
        }

        public static bool ValidateRGBDIfferencePercent(Color c1, Color c2, double RequiredToPass)
        {
            int frst = RGBToGreyScale(c1);
            int scnd = RGBToGreyScale(c2);
            return DifferencePercent(frst, scnd) <= RequiredToPass;
        }

        public static bool WiseRGBDifferencePercent(Color c1, Color c2, double RequiredToPass) 
        {
            return DifferencePercent(c1.R, c2.R) <= RequiredToPass 
                && DifferencePercent(c1.G, c2.G) <= RequiredToPass 
                && DifferencePercent(c1.B, c2.B) <= RequiredToPass;
        }

        private static void CollectGarbage() 
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static Bitmap GetDifferenceColoredBitmap(Bitmap frst, Bitmap scnd, double RequiredToPass) 
        {
            if (frst.Width != scnd.Width || frst.Height != scnd.Height)
                throw new Exception("Not matching size!");

            Bitmap result = ImageWorks.PaintOn32bpp((Bitmap)frst.Clone());
            Bitmap img1 = ImageWorks.PaintOn32bpp((Bitmap)frst.Clone());
            Bitmap img2 = ImageWorks.PaintOn32bpp((Bitmap)scnd.Clone());

            FastBitmap res = new FastBitmap(result);
            FastBitmap bm1 = new FastBitmap(img1);
            FastBitmap bm2 = new FastBitmap(img2);

            double ValidatePercent = RequiredToPass;

            res.Lock();
            bm1.Lock();
            bm2.Lock();

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    Color c1 = bm1.GetPixel(i, j);
                    Color c2 = bm2.GetPixel(i, j);

                    if (!Differencer.ValidateRGBDIfferencePercent(c1, c2, ValidatePercent))
                    {
                        res.SetPixel(i, j, Color.Red);
                    }
                }
            }

            res.Unlock();
            bm1.Unlock();
            bm2.Unlock();
            CollectGarbage();

            return result;
        }
        public static long CountPixelDifferences(Bitmap frst, Bitmap scnd, double RequiredToPass) 
        {
            if (frst.Width != scnd.Width || frst.Height != scnd.Height)
                throw new Exception("Not matching size!");

            Bitmap result = ImageWorks.PaintOn32bpp((Bitmap)frst.Clone());
            Bitmap img1 = ImageWorks.PaintOn32bpp((Bitmap)frst.Clone());
            Bitmap img2 = ImageWorks.PaintOn32bpp((Bitmap)scnd.Clone());

            FastBitmap res = new FastBitmap(result);
            FastBitmap bm1 = new FastBitmap(img1);
            FastBitmap bm2 = new FastBitmap(img2);

            double ValidatePercent = RequiredToPass;
            long DifferenceCounter = 0;

            res.Lock();
            bm1.Lock();
            bm2.Lock();

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    Color c1 = bm1.GetPixel(i, j);
                    Color c2 = bm2.GetPixel(i, j);

                    if (!Differencer.ValidateRGBDIfferencePercent(c1, c2, ValidatePercent))
                    {
                        DifferenceCounter++;
                    }
                }
            }

            res.Unlock();
            bm1.Unlock();
            bm2.Unlock();
            CollectGarbage();

            return DifferenceCounter;
        }
    }
}