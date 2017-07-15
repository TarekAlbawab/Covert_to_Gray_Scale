using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using Image = System.Drawing.Image;
namespace Grayscale
{
    public partial class Form1 : Form
    {
        private Bitmap _Image;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog(); //prompts the user to open file
            //To enable the user to add a picture
            Openfile.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (Openfile.ShowDialog() == DialogResult.OK) //Put the image selected into the value 
            //the global variable _image
            {
                _Image = (Bitmap)Image.FromFile(Openfile.FileName);
                pictureBox1.Image = _Image;//Display the image in the pictureBox1
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Savefile = new SaveFileDialog(); //prompts the user to open file
            //To enable the user to add a picture

            Savefile.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (Savefile.ShowDialog() == DialogResult.OK) //Put the image selected into the value 
            //the global variable _image
            {
                _Image.Save(Savefile.FileName);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        { //get image dimension
            int width = _Image.Width;
            int height = _Image.Height;

            //Colour of pixel
            Color p;

            //Grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = _Image.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    // Find Average 
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    _Image.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
                // Load grayscale image in picturebox2
                pictureBox2.Image = _Image;
            }

        }
    }
}
