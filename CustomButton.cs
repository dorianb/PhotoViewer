using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace photoViewer
{
    public class CustomButton : Button
    {
        #region Internal context

        #region Image

        protected Bitmap BackgroundBmp;
        protected ImageAttributes ImageAttr = new ImageAttributes();
        protected Boolean PushEffect = false;

        private int PreviousImageWidth = -1;
        private int PreviousImageHeight = -1;

        #endregion Image

        #endregion Internal context

        #region Properties

        public String ImageName { get; set; }

        #endregion Properties

        #region Constructor

        public CustomButton()
        {
        }

        #endregion Constructor

        #region Image Painting management

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle imgRect; //image rectangle

            // Bitmap for double buffering management
            if ((this.PreviousImageWidth != ClientSize.Width)
              || (this.PreviousImageHeight != ClientSize.Height)
              || (this.BackgroundBmp == null))
            {
                if (this.BackgroundBmp != null)
                {
                    this.BackgroundBmp.Dispose();
                }
                this.BackgroundBmp = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppRgb);
                this.PreviousImageHeight = ClientSize.Height;
                this.PreviousImageWidth = ClientSize.Width;
            }

            using (Graphics gxBuffer = Graphics.FromImage(BackgroundBmp))
            {
                gxBuffer.Clear(this.BackColor);

                if (this.ImageName != null)
                {
                    // The button was pressed and is enabled
                    if (this.PushEffect)
                    {
                        // Shift the image by one pixel
                        imgRect = new Rectangle(1, 1, this.Width - 1, this.Height - 1);
                    }
                    else
                    {
                        imgRect = new Rectangle(0, 0, this.Width, this.Height);
                    }


                   
                    Image TheImage = new Bitmap(this.Image);
                   
                    
                    
                    

                    if (TheImage != null)
                    {
                        gxBuffer.DrawImage(TheImage,
                                            imgRect,
                                            0,
                                            0,
                                            TheImage.Width,
                                            TheImage.Height,
                                            GraphicsUnit.Pixel,
                                            ImageAttr);
                    }
                }

                //Draw from the memory bitmap
                pe.Graphics.DrawImage(BackgroundBmp, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Do nothing
        }

        #endregion Image Painting management

        #region Event handlers

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Graphical special effect
            this.PushEffect = true;
            this.Invalidate();

            // Base update
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Graphical special effect
            this.PushEffect = false;
            this.Invalidate();

            // Base update
            base.OnMouseUp(e);
        }

        #endregion Event handlers
    }
}
