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
    public partial class timerControl : UserControl
    {
        private int timerInterval;
        public event UserControlClickHandler timerClick;
        public delegate void UserControlClickHandler(int intValue);

        #region Constructor

        public timerControl()
        {
            InitializeComponent();

            this.timerInterval = 1;
            this.timerValue.Text = this.timerInterval.ToString();
        }

        #endregion 

        #region EventManagement

        public void plus_Click(object sender, EventArgs e)
        {
            if (this.timerInterval < 9)
            {
                this.timerInterval++;
                this.timerValue.Text = this.timerInterval.ToString();

                if (this.timerClick != null)
                {
                    this.timerClick(timerInterval);
                }
            }            
        }

        public void moins_Click(object sender, EventArgs e)
        {
            if(this.timerInterval>1)
            {
                this.timerInterval--;
                this.timerValue.Text = this.timerInterval.ToString();

                if (this.timerClick != null)
                {
                    this.timerClick(timerInterval);
                }
            }
        }

        #endregion
    }
}
