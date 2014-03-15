namespace photoViewer
{
    partial class SlideShow
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.diapo = new System.Windows.Forms.SplitContainer();
            this.diapoPicture = new System.Windows.Forms.PictureBox();
            this.timerSet = new photoViewer.timerControl();
            this.diapoButton = new photoViewer.CustomButton();
            this.nextPicture = new photoViewer.CustomButton();
            this.previousPicture = new photoViewer.CustomButton();
            this.fullScreen = new photoViewer.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.diapo)).BeginInit();
            this.diapo.Panel1.SuspendLayout();
            this.diapo.Panel2.SuspendLayout();
            this.diapo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diapoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // diapo
            // 
            this.diapo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.diapo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diapo.IsSplitterFixed = true;
            this.diapo.Location = new System.Drawing.Point(0, 0);
            this.diapo.Name = "diapo";
            this.diapo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // diapo.Panel1
            // 
            this.diapo.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.diapo.Panel1.Controls.Add(this.diapoPicture);
            // 
            // diapo.Panel2
            // 
            this.diapo.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.diapo.Panel2.Controls.Add(this.timerSet);
            this.diapo.Panel2.Controls.Add(this.diapoButton);
            this.diapo.Panel2.Controls.Add(this.nextPicture);
            this.diapo.Panel2.Controls.Add(this.previousPicture);
            this.diapo.Panel2.Controls.Add(this.fullScreen);
            this.diapo.Size = new System.Drawing.Size(570, 469);
            this.diapo.SplitterDistance = 361;
            this.diapo.SplitterWidth = 1;
            this.diapo.TabIndex = 0;
            // 
            // diapoPicture
            // 
            this.diapoPicture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.diapoPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diapoPicture.Location = new System.Drawing.Point(0, 0);
            this.diapoPicture.Name = "diapoPicture";
            this.diapoPicture.Size = new System.Drawing.Size(570, 361);
            this.diapoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.diapoPicture.TabIndex = 0;
            this.diapoPicture.TabStop = false;
            this.diapoPicture.Click += new System.EventHandler(this.diapoPicture_Click);
            // 
            // timerSet
            // 
            this.timerSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerSet.Location = new System.Drawing.Point(481, 11);
            this.timerSet.Name = "timerSet";
            this.timerSet.Size = new System.Drawing.Size(53, 99);
            this.timerSet.TabIndex = 4;
            // 
            // diapoButton
            // 
            this.diapoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.diapoButton.Image = global::photoViewer.Properties.Resources.Diaporama;
            this.diapoButton.ImageName = "Diaporama.jpg";
            this.diapoButton.Location = new System.Drawing.Point(345, 35);
            this.diapoButton.Name = "diapoButton";
            this.diapoButton.Size = new System.Drawing.Size(60, 72);
            this.diapoButton.TabIndex = 3;
            this.diapoButton.Text = "customButton1";
            this.diapoButton.UseVisualStyleBackColor = true;
            this.diapoButton.Click += new System.EventHandler(this.diapoButton_Click);
            // 
            // nextPicture
            // 
            this.nextPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nextPicture.Image = global::photoViewer.Properties.Resources.Next;
            this.nextPicture.ImageName = "Next.jpg";
            this.nextPicture.Location = new System.Drawing.Point(230, 35);
            this.nextPicture.Name = "nextPicture";
            this.nextPicture.Size = new System.Drawing.Size(60, 78);
            this.nextPicture.TabIndex = 2;
            this.nextPicture.Text = "customButton1";
            this.nextPicture.UseVisualStyleBackColor = true;
            this.nextPicture.Click += new System.EventHandler(this.nextPicture_Click);
            // 
            // previousPicture
            // 
            this.previousPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.previousPicture.Image = global::photoViewer.Properties.Resources.Prev;
            this.previousPicture.ImageName = "Prev.jpg";
            this.previousPicture.Location = new System.Drawing.Point(164, 31);
            this.previousPicture.Name = "previousPicture";
            this.previousPicture.Size = new System.Drawing.Size(60, 78);
            this.previousPicture.TabIndex = 1;
            this.previousPicture.Text = "customButton1";
            this.previousPicture.UseVisualStyleBackColor = true;
            this.previousPicture.Click += new System.EventHandler(this.previousPicture_Click);
            // 
            // fullScreen
            // 
            this.fullScreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fullScreen.Image = global::photoViewer.Properties.Resources.FullScreen;
            this.fullScreen.ImageName = "FullScreen.jpg";
            this.fullScreen.Location = new System.Drawing.Point(43, 22);
            this.fullScreen.Name = "fullScreen";
            this.fullScreen.Size = new System.Drawing.Size(80, 80);
            this.fullScreen.TabIndex = 0;
            this.fullScreen.Text = "customButton1";
            this.fullScreen.UseVisualStyleBackColor = true;
            this.fullScreen.Click += new System.EventHandler(this.fullScreen_Click);
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diapo);
            this.Name = "SlideShow";
            this.Size = new System.Drawing.Size(570, 469);
            this.diapo.Panel1.ResumeLayout(false);
            this.diapo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diapo)).EndInit();
            this.diapo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diapoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer diapo;
        private CustomButton fullScreen;
        private CustomButton previousPicture;
        private CustomButton nextPicture;
        private CustomButton diapoButton;
        private System.Windows.Forms.PictureBox diapoPicture;
        private timerControl timerSet;

        #endregion

    }
}
