using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System;

namespace crudManceira
{
    internal class PokemonImage
    {
        // private const string _remoteImageUrl = "http://s2.glbimg.com/bI1iOC6Wk_hKypdLYDJYTZw7Jzo=/1200x/smart/filters:cover():strip_icc()/i.s3.glbimg.com/v1/AUTH_ba3db981e6d14e54bb84be31c923b00c/internal_photos/bs/2021/h/3/2priFtRwykPwl34XyDkA/2018-05-18-shrek.jpg";

        private const int _asciiWidth = 64;
        private static string[] _asciiChars = { " ", "#", "@", "%", "=", "+", "=", ":", "-", ".", " " };

        public static void ConvertImg(string _remoteImageUrl)
        {
            Bitmap image = GetBitmapFromUrl(_remoteImageUrl);

            string ascii = ConvertImageToAsciiArt(image);
            Console.Write(ascii);
        }
        private static Bitmap GetBitmapFromUrl(string remoteImageUrl)
        {
            WebRequest request = WebRequest.Create(remoteImageUrl);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream);
            return bitmap;
        }
        private static string ConvertImageToAsciiArt(Bitmap image)
        {
            image = GetReSizedImage(image, _asciiWidth);

            //Convert the resized image into ASCII
            string ascii = ConvertToAscii(image);
            return ascii;
        }
        private static Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth)
        {
            int asciiHeight = 0;
            //Calculate the new Height of the image from its width
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);

            //Create a new Bitmap and define its resolution
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            //The interpolation mode produces high quality images 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }
        private static string ConvertToAscii(Bitmap image)
        {
            Boolean toggle = false;
            StringBuilder sb = new StringBuilder();
            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    //Average out the RGB components to find the Gray Color
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(red, green, blue);

                    //Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_asciiChars[index]);
                    }
                }
                if (!toggle)
                {
                    sb.Append(Environment.NewLine);
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }
            }
            return sb.ToString();
        }
    }
}