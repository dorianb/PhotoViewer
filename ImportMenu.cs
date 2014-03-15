using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace photoViewer
{
    public partial class ImportMenu : UserControl
    {

        private Point finalPoint;
        private Point tempPoint;

        #region initialization

        public ImportMenu()
        {
            InitializeComponent();
        }

        public ImportMenu(int w, int h,String type)
        {
            InitializeComponent();

            if (type == "album")
            {
                label2.Text = "Album:";
                textBox1.Dispose();
                browseButton.Dispose();
                label1.Dispose();
            }
            else label1.Text = "Image:";
            
            this.organize(w,h);
          

        }

        #endregion

        #region display functions
        private void organize(int w, int h)
        {

            this.Width = w / 2;
            this.Height = h / 3;

            finalPoint = new Point(w / 2 - this.Width / 2, 0);


            textBox1.Width = this.Width -100;
            textBox2.Width = this.Width - 100;
            browseButton.Location=new Point(textBox1.Location.X+textBox1.Width,browseButton.Location.Y);
            addButton.Location = new Point(this.Width -addButton.Width- 10, this.Height -addButton.Height- 5);
            cancelButton.Location = new Point(10, this.Height-cancelButton.Height - 5);
            this.Location=new Point(w / 2 - this.Width / 2, -this.Height);
            tempPoint = new Point(w / 2 - this.Width / 2, -this.Height);
            

        }

        private void slide()
        {
            do
            {
                tempPoint.Y += 1;
                this.Location = tempPoint;

                Thread.Sleep(1);

            }
            while (this.Location.Y < finalPoint.Y);
        }

        private void deslide()
        {
            tempPoint = this.Location;
            do
            {
                tempPoint.Y -= 1;
                this.Location = tempPoint;

                Thread.Sleep(1);

            }
            while (this.Location.Y > -this.Height);


        }

        #endregion

        #region accessors

        public String getAddress()
        {
            return textBox1.Text;

        }

        public String getName()
        {
            return textBox2.Text;

        }
        #endregion

        #region event Handlers
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                openFileDialog1.ShowDialog();

                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);


                String s = openFileDialog1.FileName;

                textBox1.Text = s;

                sr.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("erreur dans button1_Click " + ex);
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
                {
                    
                    if((getName()!="")&&(getAddress()!=""))
                        this.deslide();
                   
                }

        private void button3_Click(object sender, EventArgs e)
        {

            deslide();
            
            this.Dispose();
            
        }

        private void ImportMenu_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            slide();
        }


        #endregion
    }
}
