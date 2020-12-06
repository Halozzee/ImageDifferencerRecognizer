using FastBitmapLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDifferencer
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseImage1Btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            sourceImageBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void chooseImage2Btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            sourceImageBox2.ImageLocation = openFileDialog1.FileName;
        }

        public static Bitmap PaintOn32bpp(Image image)
        {
            Bitmap bp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(bp))
                gr.DrawImage(image, new Rectangle(0, 0, bp.Width, bp.Height));
            return bp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(resultImageBox.Image != null)
                resultImageBox.Image.Dispose();

            Bitmap img1         = (Bitmap)sourceImageBox1.Image.Clone();
            Bitmap img2         = (Bitmap)sourceImageBox2.Image.Clone();

            double ValidatePercent = 1 - (double)(percentageAccuracyNumericUpDown.Value / 100);

            Bitmap result = Differencer.GetDifferenceColoredBitmap(img1, img2, ValidatePercent);
            long DifferenceCounter = Differencer.CountPixelDifferences(img1, img2, ValidatePercent);

            label1.Text = "Difference: " + ((double)DifferenceCounter / (result.Width * result.Height) * 100).ToString("0.00") + "%";
            resultImageBox.Image = ((Bitmap)result.Clone());
            resultImageBox.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (resultImageBox.Image != null)
                resultImageBox.Image.Dispose();

            Bitmap img1 = (Bitmap)sourceImageBox1.Image.Clone();
            Bitmap img2 = (Bitmap)sourceImageBox2.Image.Clone();

            double ValidatePercent = 1 - (double)(percentageAccuracyNumericUpDown.Value / 100);

            List<KeyValuePair<Point, Point>> Lpoint;

            FragmentFinder.FindImage(img1, img2, ValidatePercent, out Lpoint);

            ImageWorks.DrawRectangles(img1, Lpoint);
            ImageWorks.NameRectangles(img1, Lpoint, fragmentNameTextBox.Text);

            resultImageBox.Image = ((Bitmap)img1.Clone());
            resultImageBox.Refresh();
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resultImageBox.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resultImageBox.Image != null)
                resultImageBox.Image.Dispose();

            Bitmap img1 = (Bitmap)sourceImageBox1.Image.Clone();
            Bitmap img2 = (Bitmap)sourceImageBox2.Image.Clone();

            double ValidatePercent = 1 - (double)(percentageAccuracyNumericUpDown.Value / 100);

            var f = FragmentFinder.FastFinder(img1, img2, ValidatePercent);

            ImageWorks.DrawRectangles(img1, f);
            ImageWorks.NameRectangles(img1, f, fragmentNameTextBox.Text);

            resultImageBox.Image = ((Bitmap)img1.Clone());
            resultImageBox.Refresh();
        }
    }
}