namespace photoViewer
{
    partial class timerControl
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
            this.timerValue = new System.Windows.Forms.Label();
            this.plus = new photoViewer.CustomButton();
            this.moins = new photoViewer.CustomButton();
            this.SuspendLayout();
            // 
            // timerValue
            // 
            this.timerValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.timerValue.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerValue.Location = new System.Drawing.Point(9, 38);
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(24, 26);
            this.timerValue.TabIndex = 0;
            this.timerValue.Text = "1";
            // 
            // plus
            // 
            this.plus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.plus.Image = global::photoViewer.Properties.Resources.plus;
            this.plus.ImageName = "plus.jpg";
            this.plus.Location = new System.Drawing.Point(2, -2);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(35, 34);
            this.plus.TabIndex = 3;
            this.plus.Text = "plus";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // moins
            // 
            this.moins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.moins.Image = global::photoViewer.Properties.Resources.moins;
            this.moins.ImageName = "moins.jpg";
            this.moins.Location = new System.Drawing.Point(3, 67);
            this.moins.Name = "moins";
            this.moins.Size = new System.Drawing.Size(35, 34);
            this.moins.TabIndex = 3;
            this.moins.Text = "moins";
            this.moins.UseVisualStyleBackColor = true;
            this.moins.Click += new System.EventHandler(this.moins_Click);
            // 
            // timerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.moins);
            this.Name = "timerControl";
            this.Size = new System.Drawing.Size(41, 104);
            this.ResumeLayout(false);

        }

        private CustomButton plus;
        private CustomButton moins;
        private System.Windows.Forms.Label timerValue;

        #endregion

    }
}
