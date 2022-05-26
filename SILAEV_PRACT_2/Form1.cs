using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILAEV_PRACT_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private Bitmap []image1 = new Bitmap[0];
        private int imageCount = 0;
        private int timerCount = 0;
        private bool check = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                }
                try
                {
                    //image1.Append(new Bitmap(filePath, true));
                    Array.Resize(ref image1, image1.Length + 1);
                    image1[imageCount] = new Bitmap(filePath, true);
                    pictureBox1.Image = image1[imageCount];
                    imageCount++;
                }
                catch (ArgumentException)
                {
                    imageCount--;
                    MessageBox.Show("Ошибка!\nПроверьте путь к файлу.");
                }
                label2.Text = "";
                label2.Text = (imageCount).ToString();
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            check = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if(timerCount == imageCount)
                {
                    timerCount = 0;
                }
                pictureBox1.Image = image1[timerCount];
                timerCount++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check = false;
        }
    }
}
