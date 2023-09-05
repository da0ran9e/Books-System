using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    internal class ImageProcessor
    {
        public Image bookCover = Image.FromFile("../../../../../assets/icons/image_L.png");

        //
        // Resize image
        //
        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        //
        //This also resize image base on given height
        //
        public Image SetHeight(Image imgToResize, int height)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int width = (height * w / h);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        public Image SetWidth(Image imgToResize, int width)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int height = (width * h / w);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        public Stream LoaderFromURL(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStreamAsync().Result;
            }
            catch
            {
                return null;
            }
        }

        //public Image GetBookImage(int index)
        //{
        //    Image img = Image.FromFile("../../../../../assets/icons/image_L.png");
        //    string imgPath = "../../../../../assets/LImgs/temp" + index + ".jpg";
        //    try
        //    {
        //        Book book = MainForm.GetBookInformation(index);
        //        // if the image does not exist, then get it
        //        if (!File.Exists(imgPath))
        //        {
        //            using (Stream stream = LoaderFromURL(book.lURL))
        //            {
        //                Image image = Image.FromStream(stream);
        //                if (image.Height <= 20)
        //                {
        //                    image = Image.FromStream(LoaderFromURL(book.mURL));
        //                }
        //                image.Save(imgPath);
        //            }
        //        }

        //        //load image to tha label

        //        if (Image.FromFile(imgPath).Height >= 70)
        //            return img = Image.FromFile(imgPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Get book image error: {ex.Message}");
        //    }
        //    return img;
        //}


        //
        //Gather color of image border by pixels
        //
        private Color[] GetBorderColors(Bitmap image, Size size)
        {
            int width = image.Width;
            int height = image.Height;

            Color[] borderColors = new Color[(size.Width * 2) + (size.Height * 2)]; // 4 edges

            for (int i = 0; i < size.Height; i++)
            {
                borderColors[i] = image.GetPixel(0, i); // left edge
                borderColors[i + size.Height] = image.GetPixel(width - 1, i); // right edge
            }
            for (int i = 0; i < size.Width; i++)
            {
                borderColors[i + size.Height * 2] = image.GetPixel(i, 0); // top edge
                borderColors[i + size.Height * 2 + size.Width] = image.GetPixel(i, height - 1); // bottom edge
            }

            return borderColors;
        }

        //
        //Analyze color
        //
        private Color CalculateAverageColor(Color[] colors)
        {
            int totalR = 0, totalG = 0, totalB = 0;

            foreach (Color color in colors)
            {
                totalR += color.R;
                totalG += color.G;
                totalB += color.B;
            }

            int averageR = totalR / colors.Length;
            int averageG = totalG / colors.Length;
            int averageB = totalB / colors.Length;

            return Color.FromArgb(averageR, averageG, averageB);
        }
    }
}
