using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace photoViewer
{
    public partial class ModifyElement : UserControl
    {
        private Point finalPoint;
        private Point tempPoint;
        public int ImageIndex;
        public FileInfo file;

        #region Constructors & getter

        public ModifyElement()
        {
            InitializeComponent();
        }

        public ModifyElement(int w, int h, Picture p,int index)
        {
            InitializeComponent();
            this.ImageIndex = index;
            label2.Text = p.getName();
            pictureBox1.BackColor = Color.Black;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            file = new FileInfo(p.getPath());


            FileStream monImage = new FileStream(p.getPath(), FileMode.Open);
            pictureBox1.Image = Image.FromStream(monImage);
            monImage.Close();

            textBox1.Text = p.getName();
            organize(w, h);
        }

        public ModifyElement(int w, int h, Album album)
        {
            InitializeComponent();
            this.ImageIndex = -1;
            label1.Text = "Album:";
            label3.Text = album.getName();
            pictureBox1.BackColor = Color.Black;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Image = resizeImage(Image.FromFile(album.getPath()+album.getFrontPic()));
            textBox1.Text = album.getName();
            organize(w, h);
        }

        public String getName()
        {

            return this.textBox1.Text;

        }

        #endregion

        #region Load

        private void ModifyElement_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.slide();
        }

        #endregion

        #region display

        private void organize(int w, int h)
        {
            int myWidth=w/5;
            int myHeight=h;
            this.SetBounds(-myWidth, 0, myWidth, myHeight);

            finalPoint = new Point(0, 0);

        }

        private void slide()
        {
            tempPoint = this.Location;

            do
            {
                tempPoint.X += 2;
                this.Location = tempPoint;

                Thread.Sleep(1);

            }
            while (this.Location.X < finalPoint.X);
        }

        private void deslide()
        {
            tempPoint = this.Location;
            do
            {
                tempPoint.X -= 2;
                this.Location = tempPoint;

                Thread.Sleep(1);

            }
            while (this.Location.X > -this.Width);


        }

        private Image resizeImage(Image im)
        {

            int tempX = 0;
            int tempY = 0;
            float ratio;
            if (im.Size.Width > im.Size.Height)
            {
                ratio = (float)((float)im.Size.Width / (float)im.Size.Height);
                tempX = 0;
                tempY = 0;

                tempX = pictureBox1.Width;
                tempY = (int)(tempX / ratio);

                while (tempY > pictureBox1.Height)
                {
                    tempX--;
                    tempY = (int)(tempX * ratio);

                }

            }
            else
            {

                ratio = ((float)im.Size.Width / (float)im.Size.Height);
                tempX = 0;
                tempY = 0;

                tempY = pictureBox1.Height;
                tempX = (int)(tempY * ratio);

                while (tempX > pictureBox1.Width)
                {
                    tempY--;
                    tempX = (int)(tempY * ratio);

                }


            }

            Bitmap newImage = new Bitmap(im, tempX, tempY);

            return newImage;

        }

        

        #endregion

        #region Event Management

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.deslide();
            this.Dispose();
        }

        #endregion
    }
}
