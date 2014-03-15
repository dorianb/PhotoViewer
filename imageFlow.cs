using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoViewer
{

    delegate EventHandler clickPicture(object sender, EventArgs ev);


    public partial class imageFlow : UserControl
    {
       public List<PictureBox> pictures;
       public int maxWidth;
       public int maxHeight;

        public imageFlow()
        {
            InitializeComponent();
            pictures = new List<PictureBox>();
            this.ResumeLayout(false);
            maxHeight = 90;
            maxWidth = 90;

            flowLayoutPanel1.AllowDrop = true;
           
            
        }

        public void dealloc()
        {
            foreach (PictureBox p in pictures)
            {
                p.Dispose();

            }
        }

        public void organize(int w, int h)
        {
            this.Width = (w * 5 )/ 12;
            this.Height = (h / 3) * 2-50;

            flowLayoutPanel1.Width = this.Width;
            flowLayoutPanel1.Height = this.Height - 10;



        }

        public void addImage(Picture p)
        {

            PictureBox pic= new PictureBox();
            Image im = Image.FromFile(p.getPath());           
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Image = resizeImage(im);
            pic.SetBounds(0, 0, 90, 90);
            pic.GetPreferredSize(new Size(90,90));
           
            pic.BackColor = Color.Black;
            pictures.Add(pic);

            im.Dispose();

        }

        #region ImageProcessing

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

                tempX = maxWidth;
                tempY = (int)(tempX / ratio);

                while (tempY > maxHeight)
                {
                    tempX--;
                    tempY = (int)(tempX * ratio);

                }

            }
            else
            {

                ratio = ((float)im.Size.Width/(float)im.Size.Height);
                tempX = 0;
                tempY = 0;

                tempY = maxHeight;
                tempX = (int)(tempY * ratio);

                while (tempX > maxWidth)
                {
                    tempY--;
                    tempX = (int)(tempY * ratio);

                }


            }

            Bitmap newImage=new Bitmap(im,tempX,tempY);

            return newImage;

        }

        #endregion



        public void deletePicture(int index)
        {
            this.pictures.ElementAt(index).Dispose();


        }
        
        
        public void DisplayImages(Album album)
        {
            label1.Text = album.getName();
            foreach (PictureBox p in pictures)
            {
                p.Dispose();
            }
            

            pictures.Clear();

            LoadingBar load = new LoadingBar(this.Width, this.Height, album.listImage.Count);

            this.Controls.Add(load);
           
            foreach (Picture picture in album.listImage)
            {
                addImage(picture);
                load.setValue();
            }

            load.Dispose();

            foreach (PictureBox p in pictures)
            {
                p.MouseHover += hoverPicture;
                p.MouseLeave += leavePicture;
                p.MouseDown += beginDrag;
                

                this.flowLayoutPanel1.Controls.Add(p);
            }
        }

        #region EventHandler

        private void hoverPicture(object sender, EventArgs ev)
        {
            PictureBox p = sender as PictureBox;
            p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            p.SetBounds(0, 0, 91, 91);
        }
        private void leavePicture(object sender, EventArgs ev)
        {
            PictureBox p = sender as PictureBox;
            p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            p.SetBounds(0, 0, 90, 90);   
        }
        
        #endregion

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                  string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                  foreach (string fileLoc in filePaths)
                  {
                      Console.WriteLine("Image flow function flowLayoutPanel1_DragEnter" + System.IO.Path.GetFullPath(fileLoc));

                  }
                e.Effect = DragDropEffects.Copy;

            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void beginDrag(object sender, EventArgs e)
        {

            Console.WriteLine("beginDrag");

            PictureBox pic=sender as PictureBox;

            pic.DoDragDrop(pictures.IndexOf(pic).ToString(), DragDropEffects.Copy |DragDropEffects.Move);

        }

        private void imageFlow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
