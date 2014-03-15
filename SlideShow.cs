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

namespace photoViewer
{
    public partial class SlideShow : UserControl
    {
        private List<Picture> pictures;
        private int ImageIndex;
        private bool isFullScreen;

        private System.Windows.Forms.Timer diapoTimer;

        public event UserControlClickHandler fullScreenClick;
        public delegate void UserControlClickHandler(object sender, EventArgs e);

        #region constructor, dealloc and organization

        public SlideShow()
        {
            InitializeComponent();

            this.ImageIndex = 0;

            //set the timer
            this.diapoTimer = new System.Windows.Forms.Timer();
            this.diapoTimer.Interval = 1000;

            this.diapoTimer.Tick += new System.EventHandler(this.diapoTimer_Tick);
            this.timerSet.timerClick += new timerControl.UserControlClickHandler(this.timerSet_Click);      
        }

        //dispose the diapoPicture
        public void dealloc()
        {
            try
            {
                this.diapoPicture.Image.Dispose();
                this.diapoPicture.Image = null;
                //this.pictures.Clear();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Dealloc: " + e.Message);
            }      
        }

        //organise the slideShow Dimension
        public void organize(int w, int h)
        {
            this.Width = (w * 5) / 11;
            this.Height = h;

            this.diapoPicture.Size = new Size(w, 3*(h/4));
        }

        

        #endregion

        #region diapo Management

        private void UpdateImageView()
        {
            try
            {
                if ((this.diapoPicture.Image != null) && (this.pictures.Count > 0))
                {
                    this.diapoPicture.Image.Dispose();
                }

                FileStream monImage = new FileStream(this.pictures.ElementAt(this.ImageIndex).getPath(), FileMode.Open);
                this.diapoPicture.Image = resizeImage(Image.FromStream(monImage));
                monImage.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Update Image View: " + e.Message);
            }
        }

        public void fullScreenPressed()
        {
            this.fullScreen_Click(null, null);
        }

        public void GoNext()
        {
            this.ImageIndex++;

            try
            {
                if (this.ImageIndex == this.pictures.Count)
                {
                    this.ImageIndex = 0;
                }

                this.UpdateImageView();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("erreur dans SlideShow.cs function GoNext " + ex);
            }      
        }

        public void GoPrevious()
        {
            try
            {
                if (this.ImageIndex == 0)
                {
                    this.ImageIndex = this.pictures.Count;
                }
                this.ImageIndex--;

                this.UpdateImageView();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("erreur dans SlideShow.cs function GoPrevious " + ex);
            }
        }

        public void selectImage(int index)
        {
            this.ImageIndex = index;
            this.UpdateImageView();
        }

        #endregion diapo Management

        #region Events Management

        public void SlideShow_Load(List<Picture> pictures)
        {
            dealloc();
            this.pictures = pictures;
            if (diapoPicture.Image != null) diapoPicture.Image.Dispose();
           
            if (this.pictures.Count != 0)
            {
                this.ImageIndex = 0;
            }

            this.UpdateImageView();
        }
        

        private void fullScreen_Click(object sender, EventArgs e)
        {
            if (this.fullScreenClick != null)
            {
                if (isFullScreen)
                {
                    this.diapoPicture.SizeMode = PictureBoxSizeMode.CenterImage;
                    this.diapo.Panel1.Dock = System.Windows.Forms.DockStyle.None;
                    this.fullScreenClick(sender, e);
                    this.isFullScreen = false;
                    this.UpdateImageView();
                }
                else
                {
                    this.diapoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.diapo.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.fullScreenClick(sender, e);
                    this.isFullScreen = true;
                    this.UpdateImageView();
                }   
            }
        }

        private void nextPicture_Click(object sender, EventArgs e)
        {
            this.GoNext();
        }

        private void previousPicture_Click(object sender, EventArgs e)
        {
            this.GoPrevious();
        }

        private void diapoButton_Click(object sender, EventArgs e)
        {
            this.diapoTimer.Enabled = !this.diapoTimer.Enabled;
        }

        private void diapoTimer_Tick(object sender, EventArgs e)
        {
            this.GoNext();
        }

        private void timerSet_Click(int intValue)
        {
            this.diapoTimer.Interval = intValue * 1000;
        }

        #endregion Events Management

        #region accessors

        public void stopTimer()
        {
            this.diapoTimer.Enabled=false;

        }

        #endregion

        #region Image Processing

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

                tempX = diapoPicture.Width;
                tempY = (int)(tempX / ratio);

                while (tempY > diapoPicture.Height)
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

                tempY = diapoPicture.Height;
                tempX = (int)(tempY * ratio);

                while (tempX > diapoPicture.Width)
                {
                    tempY--;
                    tempX = (int)(tempY * ratio);

                }


            }

            Bitmap newImage = new Bitmap(im, tempX, tempY);

            return newImage;

        }

        #endregion 

        private void diapoPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
