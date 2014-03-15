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
using System.Resources;
using System.Reflection;

namespace photoViewer
{
    public partial class AlbumControl : UserControl
    {        
        private List<Album> alb;
        private Album albumLeft;
        private Album albumCentre;
        private Album albumRight;

        #region Constructeur

        public AlbumControl()
        {
            InitializeComponent();

            this.AlbumLeftImg.AllowDrop = true;
            this.AlbumRightImg.AllowDrop = true;
            this.AlbumCentreImg.AllowDrop = true;
        }

        #endregion

        #region organize

        public void OrganizeAlbumControl(int w, int h)
        {
            this.Width = (w * 5) / 12;
            this.Height = (h / 4);
            int x, y;

            //button Previous
            x = (int)(Math.Round(0.04 * this.Width,2));
            y = (int)(Math.Round(0.38 * this.Height,2));
            this.PreviousAlbum.Location = new System.Drawing.Point(x,y);
            x = (int)(Math.Round(0.08*this.Width,2));
            y = (int)(Math.Round(0.13*this.Height,2));
            this.PreviousAlbum.Size = new System.Drawing.Size(x,y);
            

            //Image+titre Album Left
            x = (int)(Math.Round(0.13 * this.Width, 2));
            y = (int)(Math.Round(0.08 * this.Height, 2));
            this.AlbumLeftImg.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.18 * this.Width, 2));
            y = (int)(Math.Round(0.65 * this.Height, 2));
            this.AlbumLeftImg.Size = new System.Drawing.Size(x, y);
            //Titre
            x = (int)(this.AlbumLeftImg.Location.X - (this.AlbumLeftName.Width / 2) + (Math.Round(this.AlbumLeftImg.Width * 0.5, 2)));
            y = this.AlbumLeftImg.Location.Y + this.AlbumLeftImg.Height + 5;
            this.AlbumLeftName.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.20 * this.Width, 2));
            y = (int)(Math.Round(0.1 * this.Height, 2));
            this.AlbumLeftName.Size = new System.Drawing.Size(x, y);

            //Image+titre Album Centre
            x = (int)(Math.Round(0.38 * this.Width, 2));
            y = (int)(Math.Round(0.08 * this.Height, 2));
            this.AlbumCentreImg.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.22 * this.Width,2));
            y = (int)(Math.Round(0.74 * this.Height,2));
            this.AlbumCentreImg.Size = new System.Drawing.Size(x, y);
            //Titre
            x = (int)(this.AlbumCentreImg.Location.X - (this.AlbumCentreName.Width / 2) + (Math.Round(this.AlbumCentreImg.Width * 0.5, 2)));
            y = this.AlbumCentreImg.Location.Y + this.AlbumCentreImg.Height + 5;
            this.AlbumCentreName.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.20 * this.Width, 2));
            y = (int)(Math.Round(0.1 * this.Height, 2));
            this.AlbumCentreName.Size = new System.Drawing.Size(x, y);

            //Image+titre Album Right
            x = (int)(Math.Round(0.67 * this.Width, 2));
            y = (int)(Math.Round(0.08 * this.Height, 2));
            this.AlbumRightImg.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.18 * this.Width, 2));
            y = (int)(Math.Round(0.65 * this.Height, 2));
            this.AlbumRightImg.Size = new System.Drawing.Size(x, y);
            //Titre
            x = (int)(this.AlbumRightImg.Location.X - (this.AlbumRightName.Width/2) + (Math.Round(this.AlbumRightImg.Width * 0.5, 2)));
            y = this.AlbumRightImg.Location.Y + this.AlbumRightImg.Height + 5;
            this.AlbumRightName.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.20 * this.Width, 2));
            y = (int)(Math.Round(0.1 * this.Height, 2));
            this.AlbumRightName.Size = new System.Drawing.Size(x, y);



            //button Right
            x = (int)(Math.Round(0.88 * this.Width, 2));
            y = (int)(Math.Round(0.38 * this.Height, 2));
            this.NextAlbum.Location = new System.Drawing.Point(x, y);
            x = (int)(Math.Round(0.08 * this.Width, 2));
            y = (int)(Math.Round(0.13 * this.Height, 2));
            this.NextAlbum.Size = new System.Drawing.Size(x, y);
        }

        #endregion

        #region Load Control

        

        public void LoadAlbumControl(List<Album> ListAlb)
        {
            int NbAlbum = ListAlb.Count;
            this.alb = ListAlb;
            this.albumRight = null;
            this.albumCentre = null;
            this.albumLeft = null;

            try
            {
                if (AlbumCentreImg.Image != null)
                {
                    this.AlbumCentreImg.Image.Dispose();
                }
                if (this.AlbumLeftImg.Image != null)
                {
                    this.AlbumLeftImg.Image.Dispose();
                }
                if (this.AlbumRightImg.Image != null)
                {
                    this.AlbumRightImg.Image.Dispose();
                }

                if (NbAlbum == 0) //Si il y a 0 album toutes les picture box sont vide
                {
                    //Centre
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumCentreImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumCentreName.Text = "No Album";

                    //Right
                    AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumRightImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumRightName.Text = "No Album";

                    //Left
                    AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumLeftImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumLeftName.Text = "No Album";
                }
                else if (NbAlbum == 1) // si il n'y a que un album les icture box right & left sont vide
                {
                    //Centre
                    if (ListAlb[NbAlbum - 1].getAllImages().Count == 0)
                    {
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    }            
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 1].getPath() + ListAlb[NbAlbum - 1].getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }

                    AlbumCentreName.Text = ListAlb[NbAlbum - 1].getName();
                    albumCentre = ListAlb[NbAlbum - 1];

                    //Right
                    AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumRightImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumRightName.Text = "No Album";

                    //Left
                    AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumLeftImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumLeftName.Text = "No Album";
                }

                else if (NbAlbum == 2) // si il n'y a que deux album le left est vide
                {
                    //Centre
                    if (ListAlb[NbAlbum - 2].getAllImages().Count == 0)
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 2].getPath() + ListAlb[NbAlbum - 2].getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }

                    AlbumCentreName.Text = ListAlb[NbAlbum - 2].getName();
                    albumCentre = ListAlb[NbAlbum - 2];

                    //Right
                    if (ListAlb[NbAlbum - 1].getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 1].getPath() + ListAlb[NbAlbum - 1].getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                  
                    AlbumRightName.Text = ListAlb[NbAlbum - 1].getName();
                    albumRight = ListAlb[NbAlbum - 1];

                    //Left
                    AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    AlbumLeftImg.SizeMode = PictureBoxSizeMode.StretchImage;
                    AlbumLeftName.Text = "No Album";
                }

                else // sinon ils sont tous plein
                {
                    //Centre
                    if (ListAlb[NbAlbum - 2].getAllImages().Count == 0)
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 2].getPath() + ListAlb[NbAlbum - 2].getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumCentreName.Text = ListAlb[NbAlbum - 2].getName();
                    albumCentre = ListAlb[NbAlbum - 2];

                    //Right
                    if (ListAlb[NbAlbum - 1].getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 1].getPath() + ListAlb[NbAlbum - 1].getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                   
                    AlbumRightName.Text = ListAlb[NbAlbum - 1].getName();
                    albumRight = ListAlb[NbAlbum - 1];

                    //Left
                    if (ListAlb[NbAlbum - 3].getAllImages().Count == 0)
                        AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(ListAlb[NbAlbum - 3].getPath() + ListAlb[NbAlbum - 3].getFrontPic(), FileMode.Open);
                        AlbumLeftImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumLeftName.Text = ListAlb[NbAlbum - 3].getName();
                    albumLeft = ListAlb[NbAlbum - 3];
                }
            }
            catch(Exception e)
            {

            }
            AlbumCentreImg.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumRightImg.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumLeftImg.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        #endregion

        #region Update Control

        public void UpdateAlbumControl(List<Album> ListAlb)
        {
            int NbAlbum = ListAlb.Count;

            this.alb = ListAlb;

            if (AlbumCentreImg.Image != null)
            {
                this.AlbumCentreImg.Image.Dispose();
            }
            if (this.AlbumLeftImg.Image != null)
            {
                this.AlbumLeftImg.Image.Dispose();
            }
            if (this.AlbumRightImg.Image != null)
            {
                this.AlbumRightImg.Image.Dispose();
            }

            if (NbAlbum == 0) //Si il y a 0 album toutes les picture box sont vide
            {

                //Centre
                AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumCentreName.Text = "No Album";

                //Right
                AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumRightName.Text = "No Album";

                //Left
                AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumLeftName.Text = "No Album";
            }
            else if (NbAlbum == 1) // si il n'y a que un album les icture box right & left sont vide
            {
                //Centre
                if (albumCentre != null)
                {
                    if (albumCentre.getAllImages().Count == 0)
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumCentre.getPath() + albumCentre.getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumCentreName.Text = albumCentre.getName();
                }
                else
                {
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }

                //Right
                AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumRightName.Text = "No Album";

                //Left
                AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumLeftName.Text = "No Album";
            }

            else if (NbAlbum == 2) // si il n'y a que deux album le left est vide
            {
                //Centre
                if (albumCentre != null)
                {
                    if (albumCentre.getAllImages().Count == 0)
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumCentre.getPath() + albumCentre.getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumCentreName.Text = albumCentre.getName();
                }
                else
                {
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }

                //Right
                if (albumRight != null)
                {
                    if (albumRight.getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumRight.getPath() + albumRight.getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumRightName.Text = albumRight.getName();
                }
                else
                {
                    AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }

                //Left
                AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                AlbumLeftName.Text = "No Album";
            }

            else // sinon ils sont tous plein
            {
                //Centre
                if (albumCentre != null)
                {
                    if (albumCentre.getAllImages().Count == 0)
                        AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumCentre.getPath() + albumCentre.getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }

                    AlbumCentreName.Text = albumCentre.getName();
                }
                else
                {
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }

                //Right
                if (albumRight != null)
                {
                    if (albumRight.getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumRight.getPath() + albumRight.getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }

                    AlbumRightName.Text = albumRight.getName();
                }
                else
                {
                    AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }

                //Left
                if (albumLeft != null)
                {
                    if (albumLeft.getAllImages().Count == 0)
                        AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                        else
                    {
                        FileStream monImage = new FileStream(albumLeft.getPath() + albumLeft.getFrontPic(), FileMode.Open);
                        AlbumLeftImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumLeftName.Text = albumLeft.getName();
                }
                else
                {
                    AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                }
            }
            AlbumCentreImg.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumRightImg.SizeMode = PictureBoxSizeMode.StretchImage;
            AlbumLeftImg.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        #endregion

        #region Event Management

        private void AlbumCentreImg_MouseDown(object sender, MouseEventArgs e)
        {

            AlbumCentreImg.DoDragDrop("album", DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void AlbumLeftImg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void AlbumRightImg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void AlbumLeftImg_MouseHover(object sender, EventArgs e)
        {
            AlbumLeftImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void AlbumLeftImg_MouseLeave(object sender, EventArgs e)
        {
            AlbumLeftImg.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void AlbumCentreImg_MouseLeave(object sender, EventArgs e)
        {
            AlbumCentreImg.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void AlbumCentreImg_MouseHover(object sender, EventArgs e)
        {
            AlbumCentreImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void AlbumRightImg_MouseHover(object sender, EventArgs e)
        {
            AlbumRightImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void AlbumRightImg_MouseLeave(object sender, EventArgs e)
        {
            AlbumRightImg.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        #endregion

        #region navigate

        public void GoNextAlbum(List<Album> ListAlb)
        {
            Album albumRightTmp = albumRight;
            Album albumLeftTmp = albumLeft;
            Album albumCentreTmp = albumCentre;

        //***Right
            albumLeft = albumCentreTmp;
            if (albumLeft != null)
            {
                if (albumLeft.getAllImages().Count == 0)
                    AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumCentreTmp.getPath() + albumCentreTmp.getFrontPic(), FileMode.Open);
                        AlbumLeftImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                
                AlbumLeftName.Text = albumCentreTmp.getName();
            }
            else
            {
                AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

        //***Centre
            albumCentre = albumRightTmp;
            if (albumCentre != null)
            {
                if (albumCentre.getAllImages().Count == 0)
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumRightTmp.getPath() + albumRightTmp.getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                
                AlbumCentreName.Text = albumRightTmp.getName();
            }
            else
            {
                AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

        //***Right
            if (albumRight != null)
            {
                if (this.getAlbumIndex(albumRight) == alb.Count - 1)
                {
                    albumRight = alb.ElementAt(0);
                    if (albumRight.getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                        else
                    {
                        FileStream monImage = new FileStream(albumRight.getPath() + albumRight.getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumRightName.Text = albumRight.getName();
                }
                else
                {
                    albumRight = alb.ElementAt(this.getAlbumIndex(albumRight) + 1);
                    if (albumRight.getAllImages().Count == 0)
                        AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumRight.getPath() + albumRight.getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumRightName.Text = albumRight.getName();
                }
            }
            else
            {
                AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

            UpdateAlbumControl(ListAlb);
        }

        public void GoPreviousAlbum(List<Album> ListAlb)
        {
            Album albumRightTmp = albumRight;
            Album albumLeftTmp = albumLeft;
            Album albumCentreTmp = albumCentre;

        //***Left
            if (albumLeft != null)
            {
                if (this.getAlbumIndex(albumLeft) == 0)
                {
                    albumLeft = alb[alb.Count - 1];
                    if (albumLeft.getAllImages().Count == 0)
                        AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumLeft.getPath() + albumLeft.getFrontPic(), FileMode.Open);
                        AlbumLeftImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumLeftName.Text = albumLeft.getName();
                }
                else
                {
                    albumLeft = alb[this.getAlbumIndex(albumLeft) - 1];
                    if (albumLeft.getAllImages().Count == 0)
                        AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumLeft.getPath() + albumLeft.getFrontPic(), FileMode.Open);
                        AlbumLeftImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                    
                    AlbumLeftName.Text = albumLeft.getName();
                }
            }
            else
            {
                AlbumLeftImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

        //***Centre
            albumCentre = albumLeftTmp;
            if (albumCentre != null)
            {
                if (albumCentre.getAllImages().Count == 0)
                    AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumLeftTmp.getPath() + albumLeftTmp.getFrontPic(), FileMode.Open);
                        AlbumCentreImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
               
                AlbumCentreName.Text = albumLeftTmp.getName();
            }
            else
            {
                AlbumCentreImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

        //***Right
            albumRight = albumCentreTmp;
            if (albumRight != null)
            {
                if (albumRight.getAllImages().Count == 0)
                    AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
                    else
                    {
                        FileStream monImage = new FileStream(albumCentreTmp.getPath() + albumCentreTmp.getFrontPic(), FileMode.Open);
                        AlbumRightImg.Image = Image.FromStream(monImage);
                        monImage.Close();
                    }
                AlbumRightName.Text = albumCentreTmp.getName();
            }
            else
            {
                AlbumRightImg.Image = global::photoViewer.Properties.Resources.addAlbum;//image par defaut
            }

            UpdateAlbumControl(ListAlb);
        }

        #endregion

        #region getters

        public int getAlbumSelected(List<Album> ListAlb)
        {
            int IndexAlbumSelected = -1;

            foreach (Album al in ListAlb)
            {
                if (al.getName() == AlbumCentreName.Text)
                {
                    IndexAlbumSelected = ListAlb.IndexOf(al);
                }
            }
            return IndexAlbumSelected;
        }

        public int getAlbumLeft(List<Album> ListAlb)
        {
            int IndexAlbumLeft = -1;

            foreach (Album al in ListAlb)
            {
                if (al.getName() == AlbumLeftName.Text)
                {
                    IndexAlbumLeft = ListAlb.IndexOf(al);
                }
            }
            return IndexAlbumLeft;
        }

        public int getAlbumRight(List<Album> ListAlb)
        {
            int IndexAlbumRight = -1;

            foreach (Album al in ListAlb)
            {
                if (al.getName() == AlbumRightName.Text)
                {
                    IndexAlbumRight = alb.IndexOf(al);
                }
            }
            return IndexAlbumRight;
        }

        public int getAlbumIndex(Album al)
        {
            return alb.IndexOf(al);
        }

        #endregion

    }
}
