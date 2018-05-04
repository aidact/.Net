using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
//using System.Drawing.Image;
using System.IO;
//using System.Drawing.Bitmap;
using System.Drawing.Imaging;

namespace Far
{
    class Compress
    {
        public const string JPEG = ".jpeg";
        public const string PNG = ".png";
        public const string JPG = ".jpg";

        private Bitmap bitmap;
        private Image img;
        
        public static Image CompressImage(Image src, int width, int height)
        {
            Image dest = new Bitmap(width, height);

            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcWidth = src.Width;
                float srcHeight = src.Height;
                float dstWidth = width;
                float dstHeight = height;

                // Original image is less than distinct
                if (srcWidth <= dstWidth && srcHeight <= dstHeight)
                {
                    int left = (width - src.Width) / 2;
                    int top = (height - src.Height) / 2;
                    gr.DrawImage(src, left, top, src.Width, src.Height);

                }
                    // Original image's proportioms wider
                else if (srcWidth / srcHeight > dstWidth / dstHeight)
                {
                    float cy = srcHeight / srcWidth * dstWidth;
                    float top = ((float)dstHeight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(src, 0, top, dstWidth, cy);
                }
                    //Original image's proportions tighter
                else
                {
                    float cx = srcWidth / srcHeight * dstHeight;
                    float left = ((float)dstWidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(src, left, 0, cx, dstHeight);
                }
                return dest;
            }
        }

        internal void CompressImage(string p1, int p2, int p3)
        {
            throw new NotImplementedException();
        }
    }
}
