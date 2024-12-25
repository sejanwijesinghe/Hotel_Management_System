using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace HotelManagementSystem
{
    public partial class SplashScreen : Form
    {

     
        public SplashScreen()
        {
            InitializeComponent();
            BorderStyle.ApplyRoundedBorder(this, 25);
            circularProgressBar1.Value = 0;

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";

            if ( circularProgressBar1.Value == 100 )
            {
                timer1.Enabled = false;
                Login form = new Login();
                form.Show();
                this.Hide();
            }
        }
    }
}
