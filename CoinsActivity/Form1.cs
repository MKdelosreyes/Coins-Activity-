using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ImageProcess2;
using DIP_Activity;

namespace DigitalImageProcessing
{
    public partial class CoinsForm : Form
    {
        Bitmap coinsImage, processedImage;
        public CoinsForm()
        {
            InitializeComponent();
        }

        private void Coins_Load(object sender, EventArgs e)
        {
            String coinsImagePath = System.IO.Path.Combine(Application.StartupPath, "..", "media", "coins.jpeg");
            coinsImage = new Bitmap(coinsImagePath);
            pictureBox1.Image = coinsImage;

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void Coins_Closing(object sender, EventArgs e)
        {
            (this.Owner).Dispose();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            coinsImage = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = coinsImage;
        }

        private void btnCountCoins_Click(object sender, EventArgs e)
        {
            // Prepare Image for counting
            processedImage = (Bitmap)coinsImage.Clone();

            // Apply thresholding in hopes of turning the coins color to Black,
            // and the background as White
            BasicDIP.Threshold(ref processedImage, 200);

            pictureBox2.Image = processedImage;

            CountCoins(processedImage);
        }

        List<List<Point>> coins;
        bool[,] visited;
        int p5, p1, c5, c10, c25;

        private void CountCoins(Bitmap a)
        {
            // initialize lists
            coins = new List<List<Point>>();
            visited = new bool[processedImage.Width, processedImage.Height];

            // storing count and total value of coins
            int coinCount = 0;
            int totalValue = 0;
            p5 = p1 = c5 = c10 = c25 = 0;

            // go through image, if the pixel is black, do bfs
            // for every visited points, visitedPoints[x,y] = true
            // classify coin etc etc;
            for (int x = 0; x < processedImage.Width; x++)
            {
                for (int y = 0; y < processedImage.Height; y++)
                {
                    // Get pixel
                    Color pixel = processedImage.GetPixel(x, y);

                    if (pixel.R == 0 && !visited[x, y])
                    {
                        // if the point is not yet visited, we've encountered a coin
                        // we have to get the entire coin through bfs and store them in the list
                        List<Point> coin;
                        int coinSize;

                        (coin, coinSize) = GetCoin(x, y);

                        if (coinSize < 20)
                        {
                            continue; // do not count small dots
                        }

                        coins.Add(coin);
                        coinCount++;
                        int coinValue = GetCoinValue(coinSize);
                        totalValue += coinValue;
                        listBox1.Items.Add("Coin " + coinCount + ": " + coinSize + " ( " + (double)coinValue / 100 + " )");

                        break;
                    }
                }
            }

            tbNumCoins.Text = coinCount.ToString();
            tbTotalValue.Text = (totalValue / 100) + "." + totalValue % 100;

            listBox2.Items.Add("5 peso: " + p5);
            listBox2.Items.Add("1 peso: " + p1);
            listBox2.Items.Add("25 cents: " + c25);
            listBox2.Items.Add("10 cents: " + c10);
            listBox2.Items.Add("5 cents: " + c5);
        }

        private (List<Point>, int) GetCoin(int x, int y)
        {
            List<Point> coinPoints = new List<Point>();
            Bitmap img = (Bitmap)processedImage.Clone();

            int coinSize = 0;
            int width = img.Width;
            int height = img.Height;

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));

            while (queue.Count > 0)
            {
                Point currPoint = queue.Dequeue();
                coinPoints.Add(currPoint);
                int px = currPoint.X;
                int py = currPoint.Y;

                if (visited[px, py])
                    continue;

                coinSize++;

                visited[px, py] = true;

                Color pixel = img.GetPixel(px, py);

                // To visit a Point, it must be color black and has not been visited
                // left 
                if (px - 1 >= 0 && pixel.R == 0 && !visited[px - 1, py])
                {
                    queue.Enqueue(new Point(px - 1, py));
                }

                // right 
                if (px + 1 < width && pixel.R == 0 && !visited[px + 1, py])
                {
                    queue.Enqueue(new Point(px + 1, py));
                }

                // up
                if (py - 1 >= 0 && pixel.R == 0 && !visited[px, py - 1])
                {
                    queue.Enqueue(new Point(px, py - 1));
                }

                // down
                if (py + 1 < height && pixel.R == 0 && !visited[px, py + 1])
                {
                    queue.Enqueue(new Point(px, py + 1));
                }
            }

            return (coinPoints, coinSize);
        }

        private int GetCoinValue(int coinSize)
        {
            if (coinSize > 8000)
            {
                p5++;
                return 500; // 5 peso
            }

            if (coinSize > 6000)
            {
                p1++;
                return 100; // 1 peso
            }

            if (coinSize > 4000)
            {
                c25++;
                return 25; // 25 cents
            }

            if (coinSize > 3500)
            {
                c10++;
                return 10; // 10 cents
            }

            c5++;
            return 5; // 5 cents
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            int selectedItem = listBox1.SelectedIndex;

            // Create a new bitmap to avoid modifying the original image
            Bitmap bitmap = new Bitmap(processedImage);

            using (Graphics g = Graphics.FromImage(bitmap))
            using (Brush brush = new SolidBrush(Color.Red))
            {
                // Draw points associated with the selected item
                foreach (Point point in coins[selectedItem])
                {
                    g.FillEllipse(brush, point.X - 2, point.Y - 2, 4, 4); // Small circle at each point
                }
            }

            // Update the PictureBox with the new image
            pictureBox2.Image = bitmap;

        }

        private void tbNumCoins_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
