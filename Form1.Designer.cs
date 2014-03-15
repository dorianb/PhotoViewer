namespace photoViewer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trashPicture = new System.Windows.Forms.PictureBox();
            this.settings = new System.Windows.Forms.PictureBox();
            this.slideShow = new photoViewer.SlideShow();
            this.webView = new photoViewer.CustomButton();
            this.addPicture = new photoViewer.CustomButton();
            this.addAlbum = new photoViewer.CustomButton();
            this.imageFlow1 = new photoViewer.imageFlow();
            this.albumControl1 = new photoViewer.AlbumControl();
            ((System.ComponentModel.ISupportInitialize)(this.trashPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).BeginInit();
            this.SuspendLayout();
            // 
            // trashPicture
            // 
            this.trashPicture.Image = ((System.Drawing.Image)(resources.GetObject("trashPicture.Image")));
            this.trashPicture.Location = new System.Drawing.Point(649, 563);
            this.trashPicture.Name = "trashPicture";
            this.trashPicture.Size = new System.Drawing.Size(100, 100);
            this.trashPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trashPicture.TabIndex = 15;
            this.trashPicture.TabStop = false;
            this.trashPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.trash_drop);
            this.trashPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.trash_Enter);
            // 
            // settings
            // 
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.Location = new System.Drawing.Point(649, 457);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(100, 100);
            this.settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settings.TabIndex = 12;
            this.settings.TabStop = false;
            this.settings.DragDrop += new System.Windows.Forms.DragEventHandler(this.settings_DragDrop);
            this.settings.DragEnter += new System.Windows.Forms.DragEventHandler(this.settings_DragEnter);
            // 
            // slideShow
            // 
            this.slideShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.slideShow.Location = new System.Drawing.Point(755, 0);
            this.slideShow.Name = "slideShow";
            this.slideShow.Size = new System.Drawing.Size(607, 741);
            this.slideShow.TabIndex = 8;
            // 
            // webView
            // 
            this.webView.Image = ((System.Drawing.Image)(resources.GetObject("webView.Image")));
            this.webView.ImageName = "webView.jpg";
            this.webView.Location = new System.Drawing.Point(649, 224);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(100, 100);
            this.webView.TabIndex = 13;
            this.webView.Text = "customButton1";
            this.webView.UseVisualStyleBackColor = true;
            this.webView.Click += new System.EventHandler(this.webView_Click);
            // 
            // addPicture
            // 
            this.addPicture.Image = ((System.Drawing.Image)(resources.GetObject("addPicture.Image")));
            this.addPicture.ImageName = "addPicture.jpg";
            this.addPicture.Location = new System.Drawing.Point(649, 118);
            this.addPicture.Name = "addPicture";
            this.addPicture.Size = new System.Drawing.Size(100, 100);
            this.addPicture.TabIndex = 10;
            this.addPicture.Text = "customButton1";
            this.addPicture.UseVisualStyleBackColor = true;
            this.addPicture.Click += new System.EventHandler(this.addPicture_Click);
            // 
            // addAlbum
            // 
            this.addAlbum.Image = ((System.Drawing.Image)(resources.GetObject("addAlbum.Image")));
            this.addAlbum.ImageName = "addAlbum.jpg";
            this.addAlbum.Location = new System.Drawing.Point(649, 12);
            this.addAlbum.Name = "addAlbum";
            this.addAlbum.Size = new System.Drawing.Size(100, 100);
            this.addAlbum.TabIndex = 9;
            this.addAlbum.Text = "customButton1";
            this.addAlbum.UseVisualStyleBackColor = true;
            this.addAlbum.Click += new System.EventHandler(this.addAlbum_Click);
            // 
            // imageFlow1
            // 
            this.imageFlow1.Location = new System.Drawing.Point(12, 202);
            this.imageFlow1.Name = "imageFlow1";
            this.imageFlow1.Size = new System.Drawing.Size(618, 539);
            this.imageFlow1.TabIndex = 7;
            // 
            // albumControl1
            // 
            this.albumControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.albumControl1.Location = new System.Drawing.Point(12, 12);
            this.albumControl1.Name = "albumControl1";
            this.albumControl1.Size = new System.Drawing.Size(618, 196);
            this.albumControl1.TabIndex = 6;
            this.albumControl1.SizeChanged += new System.EventHandler(this.albumControl1_SizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.slideShow);
            this.Controls.Add(this.trashPicture);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.addPicture);
            this.Controls.Add(this.addAlbum);
            this.Controls.Add(this.imageFlow1);
            this.Controls.Add(this.albumControl1);
            this.Name = "Form1";
            this.Text = "Photo Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.trashPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AlbumControl albumControl1;
        private imageFlow imageFlow1;
        private SlideShow slideShow;
        private CustomButton addAlbum;
        private CustomButton addPicture;
        private System.Windows.Forms.PictureBox settings;
        private CustomButton webView;
        private System.Windows.Forms.PictureBox trashPicture;
    }
}

