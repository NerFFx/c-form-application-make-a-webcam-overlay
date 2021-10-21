using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace test
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection webcam; 

        private VideoCaptureDevice cam; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new

           FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo item in webcam)

            {

                comboBox1.Items.Add(item.Name);

            }

            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new

           VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString); 

            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

            cam.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

          

        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)

        {

            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            pictureBox1.Image = bmp;

        }
        private void Cek_Click(object sender, EventArgs e)

        {

           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog swf = new SaveFileDialog();

            swf.Filter = "(*.jpg)|*.jpg|Bitma*p(*.bmp)|*.bmp";

            DialogResult dialog = swf.ShowDialog();


            if (dialog == DialogResult.OK)

            {

                pictureBox1.Image.Save(swf.FileName);

            }

        }
    }
}
