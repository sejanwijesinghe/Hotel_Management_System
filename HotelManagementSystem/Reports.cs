using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reportViewer report = new reportViewer();
            report.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            reportViewer2 report = new reportViewer2();
            report.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            reportViewer3 report = new reportViewer3();
            report.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            reportViewer4 report = new reportViewer4();
            report.Show();
        }
    }
}
