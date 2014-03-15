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
    public partial class LoadingBar : UserControl
    {

        #region Constructors
        public LoadingBar()
        {
            InitializeComponent();
            
        }
        
        public LoadingBar(int w, int h,int prog)
        {
            InitializeComponent();
            this.Location = new Point(w / 2 - this.Width / 2, h / 2 - this.Height / 2);
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = prog;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            label1.Visible = true;
            label2.Visible = true;
            this.BringToFront();

        }
        #endregion

        public void setValue()
        {
            progressBar1.PerformStep();
        }

        private void LoadingBar_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        
    }
}
