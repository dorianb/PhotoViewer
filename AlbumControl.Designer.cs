namespace photoViewer
{
    partial class AlbumControl
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
            this.AlbumCentreImg = new System.Windows.Forms.PictureBox();
            this.AlbumLeftImg = new System.Windows.Forms.PictureBox();
            this.AlbumRightImg = new System.Windows.Forms.PictureBox();
            this.AlbumCentreName = new System.Windows.Forms.Label();
            this.AlbumLeftName = new System.Windows.Forms.Label();
            this.AlbumRightName = new System.Windows.Forms.Label();
            this.PreviousAlbum = new photoViewer.CustomButton();
            this.NextAlbum = new photoViewer.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCentreImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumLeftImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumRightImg)).BeginInit();
            this.SuspendLayout();
            // 
            // AlbumCentreImg
            // 
            this.AlbumCentreImg.Location = new System.Drawing.Point(179, 15);
            this.AlbumCentreImg.Name = "AlbumCentreImg";
            this.AlbumCentreImg.Size = new System.Drawing.Size(100, 110);
            this.AlbumCentreImg.TabIndex = 0;
            this.AlbumCentreImg.TabStop = false;
            this.AlbumCentreImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlbumCentreImg_MouseDown);
            this.AlbumCentreImg.MouseLeave += new System.EventHandler(this.AlbumCentreImg_MouseLeave);
            this.AlbumCentreImg.MouseHover += new System.EventHandler(this.AlbumCentreImg_MouseHover);
            // 
            // AlbumLeftImg
            // 
            this.AlbumLeftImg.Location = new System.Drawing.Point(61, 15);
            this.AlbumLeftImg.Name = "AlbumLeftImg";
            this.AlbumLeftImg.Size = new System.Drawing.Size(90, 100);
            this.AlbumLeftImg.TabIndex = 1;
            this.AlbumLeftImg.TabStop = false;
            this.AlbumLeftImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumLeftImg_DragEnter);
            this.AlbumLeftImg.MouseLeave += new System.EventHandler(this.AlbumLeftImg_MouseLeave);
            this.AlbumLeftImg.MouseHover += new System.EventHandler(this.AlbumLeftImg_MouseHover);
            // 
            // AlbumRightImg
            // 
            this.AlbumRightImg.Location = new System.Drawing.Point(307, 15);
            this.AlbumRightImg.Name = "AlbumRightImg";
            this.AlbumRightImg.Size = new System.Drawing.Size(90, 100);
            this.AlbumRightImg.TabIndex = 2;
            this.AlbumRightImg.TabStop = false;
            this.AlbumRightImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.AlbumRightImg_DragEnter);
            this.AlbumRightImg.MouseLeave += new System.EventHandler(this.AlbumRightImg_MouseLeave);
            this.AlbumRightImg.MouseHover += new System.EventHandler(this.AlbumRightImg_MouseHover);
            // 
            // AlbumCentreName
            // 
            this.AlbumCentreName.AutoSize = true;
            this.AlbumCentreName.Location = new System.Drawing.Point(213, 128);
            this.AlbumCentreName.Name = "AlbumCentreName";
            this.AlbumCentreName.Size = new System.Drawing.Size(0, 13);
            this.AlbumCentreName.TabIndex = 3;
            // 
            // AlbumLeftName
            // 
            this.AlbumLeftName.AutoSize = true;
            this.AlbumLeftName.Location = new System.Drawing.Point(89, 118);
            this.AlbumLeftName.Name = "AlbumLeftName";
            this.AlbumLeftName.Size = new System.Drawing.Size(0, 13);
            this.AlbumLeftName.TabIndex = 4;
            // 
            // AlbumRightName
            // 
            this.AlbumRightName.AutoSize = true;
            this.AlbumRightName.Location = new System.Drawing.Point(339, 118);
            this.AlbumRightName.Name = "AlbumRightName";
            this.AlbumRightName.Size = new System.Drawing.Size(0, 13);
            this.AlbumRightName.TabIndex = 5;
            // 
            // PreviousAlbum
            // 
            this.PreviousAlbum.Image = global::photoViewer.Properties.Resources.Prev;
            this.PreviousAlbum.ImageName = "Prev.png";
            this.PreviousAlbum.Location = new System.Drawing.Point(17, 70);
            this.PreviousAlbum.Name = "PreviousAlbum";
            this.PreviousAlbum.Size = new System.Drawing.Size(40, 25);
            this.PreviousAlbum.TabIndex = 7;
            this.PreviousAlbum.Text = "Previous";
            this.PreviousAlbum.UseVisualStyleBackColor = true;
            // 
            // NextAlbum
            // 
            this.NextAlbum.Image = global::photoViewer.Properties.Resources.Next;
            this.NextAlbum.ImageName = "Next.png";
            this.NextAlbum.Location = new System.Drawing.Point(403, 70);
            this.NextAlbum.Name = "NextAlbum";
            this.NextAlbum.Size = new System.Drawing.Size(40, 25);
            this.NextAlbum.TabIndex = 6;
            this.NextAlbum.Text = "Next";
            this.NextAlbum.UseVisualStyleBackColor = true;
            // 
            // AlbumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.PreviousAlbum);
            this.Controls.Add(this.NextAlbum);
            this.Controls.Add(this.AlbumRightName);
            this.Controls.Add(this.AlbumLeftName);
            this.Controls.Add(this.AlbumCentreName);
            this.Controls.Add(this.AlbumRightImg);
            this.Controls.Add(this.AlbumLeftImg);
            this.Controls.Add(this.AlbumCentreImg);
            this.Name = "AlbumControl";
            this.Size = new System.Drawing.Size(460, 184);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCentreImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumLeftImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumRightImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox AlbumCentreImg;
        public System.Windows.Forms.PictureBox AlbumLeftImg;
        public System.Windows.Forms.PictureBox AlbumRightImg;
        private System.Windows.Forms.Label AlbumCentreName;
        private System.Windows.Forms.Label AlbumLeftName;
        private System.Windows.Forms.Label AlbumRightName;
        public CustomButton NextAlbum;
        public CustomButton PreviousAlbum;
    }
}
