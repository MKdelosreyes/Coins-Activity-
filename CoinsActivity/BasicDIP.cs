using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcess2;

namespace DIP_Activity
{
    static class BasicDIP
    {
        public static void Hist(ref Bitmap a,  ref Bitmap b)
        {
            Color sample;
            Color gray;
            Byte graydata;

            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }

            int[] histData = new int[256];
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    histData[sample.R]++;
                }

            b = new Bitmap(256, 800);
            for(int x = 0; x < 256; x++)
                for(int y = 0; y < 800; y++)
                {
                    b.SetPixel(x, y, Color.White);
                }

            //Plotting points based from histData
            for (int x = 0; x < 256; x++)
                for (int y = 0; y < Math.Min(histData[x] / 5, b.Height - 1); y++)
                {
                    b.SetPixel(x, (b.Height - 1)-y, Color.Black);
                }
        }

        public static void Brightness(ref Bitmap a, ref Bitmap b, int value)
        {
            b = new Bitmap(a.Width, a.Height);
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    Color temp = a.GetPixel(x, y);
                    Color changed;
                    if (value > 0)
                        changed = Color.FromArgb(Math.Min(temp.R + value, 255), Math.Min(temp.G + value, 255), Math.Min(temp.B + value, 255));
                    else
                        changed = Color.FromArgb(Math.Max(temp.R + value, 0), Math.Max(temp.G + value, 0), Math.Max(temp.B + value, 0));
                    b.SetPixel(x, y, changed);
                }
        }

        public static void Equalisation(ref Bitmap a, ref Bitmap b, int degree)
        {
            int height = a.Height;
            int width = a.Width;
            int numSamples, histSum;
            int[] Ymap = new int[256];
            int[] hist = new int[256];
            int percent = degree;

            //Compute the histogram from the sub-image
            Color nakuha;
            Color gray;
            Byte graydata;

            //Compute grayscale
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    nakuha = a.GetPixel(x, y);
                    graydata = (byte)((nakuha.R + nakuha.G + nakuha.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }

            //Histogram id data
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    nakuha = a.GetPixel(x, y);
                    hist[nakuha.R]++;
                }

            //remap the Ys, use the maximum contrast (percent == 100)
            //based on histogram equalization
            numSamples = (a.Width * a.Height);
            histSum = 0;
            for(int h = 0; h < 256; h++)
            {
                histSum += hist[h];
                Ymap[h] = histSum * 255 / numSamples;
            }

            //if desired contrast is not maximum (percent < 100), then adjusting the mapping
            if(percent < 100)
            {
                for(int h = 0; h < 256 ;h++)
                {
                    Ymap[h] = h + ((int)Ymap[h] - h) * percent / 100;
                }
            }

            b = new Bitmap(a.Width, a.Height);
            //enchance the region by remapping intensities
            for(int y = 0; y < a.Height; y++)
                for(int x = 0; x < a.Width; x++)
                {
                    //set the new value of the gray value
                    Color temp = Color.FromArgb(Ymap[a.GetPixel(x, y).R], Ymap[a.GetPixel(x, y).G], Ymap[a.GetPixel(x, y).B]);
                    b.SetPixel(x, y, temp);
                }
        }

        public static void Threshold(ref Bitmap a, int thresholdNum)
        {
            // Apply Grayscale to image
            BitmapFilter.GrayScale(a);

            if (thresholdNum < 0 || thresholdNum > 255)
                return;

            int dstHeight = a.Height;
            int dstWidth = a.Width;

            BitmapData bmA = a.LockBits(
                new Rectangle(0, 0, dstWidth, dstHeight),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb
                );

            unsafe
            {
                int paddingA = bmA.Stride - dstWidth * 3;

                byte* pA = (byte*)bmA.Scan0;

                for (int i = 0;
                    i < a.Height;
                    i++, pA += paddingA, pA += paddingA)

                    for (int j = 0;
                        j < a.Width;
                        j++, pA += 3)
                        pA[0] = pA[1] = pA[2] = (byte)(pA[0] < thresholdNum ? 0 : 255);
            }

            a.UnlockBits(bmA);
        }
    }
}
