using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    internal class BookCover
    {
        public Image image = Image.FromFile("../../../../../assets/icons/image_L.png");
        public Color borderColor = Color.Black;


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

        public void GetBookImage(Book book)
        {
            if (book == null) return;
            string imgPath = "../../../../../assets/LImgs/temp" + book.index + ".jpg";
            try
            {
                // if the image does not exist, then get it
                if (!File.Exists(imgPath))
                {
                    using (Stream stream = LoaderFromURL(book.lURL))
                    {
                        Image image = Image.FromStream(stream);
                        if (image.Height <= 300)
                        {
                            image = Image.FromStream(LoaderFromURL(book.mURL));
                            if (image.Height <= 100)
                            {
                                image = Image.FromStream(LoaderFromURL(book.sURL));
                            }
                        }
                        image.Save(imgPath);
                    }
                }

                //load image to tha label

                if (Image.FromFile(imgPath).Height >= 50)
                    this.image = Image.FromFile(imgPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get book image error: {ex.Message}");
            }
        }

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

        private Color GetBorder()
        {
            borderColor = CalculateAverageColor(GetBorderColors(new Bitmap(image), image.Size));

            return borderColor;
        }
    }
}
