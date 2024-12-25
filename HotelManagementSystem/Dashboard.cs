using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using TheArtOfDevHtmlRenderer.Adapters.Entities;

namespace HotelManagementSystem
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildform;
        public Dashboard()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 73);
            panel1.Controls.Add(leftBorderBtn);



        }

        private struct RGBColours
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);

        }

        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                currentChildFormIcon.IconChar = currentBtn.IconChar;
                currentChildFormIcon.IconColor = color;
            }

        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(83, 83, 121);
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildform != null)
            {
                currentChildform.Close();
            }
            currentChildform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleChildForm.Text = childForm.Text;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int availableRooms = GetAvailableRoomCount();
            label1.Text = $"Available Rooms: {availableRooms}";
            lblOutstandingPayments.Text = $"Outstanding Payments: {GetOutstandingPayments():N}";
            lblTotalRevenue.Text = $"Total Revenue: {GetTotalRevenue():N}";
        }

        private int GetAvailableRoomCount()
        {
            int availableRoomCount = 0;

            try
            {
                string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
                string query = "SELECT COUNT(*) FROM Rooms WHERE Status = 'Occupied'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    availableRoomCount = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return availableRoomCount;
        }

        private decimal GetOutstandingPayments()
        {
            string query = "SELECT SUM(TotalAmount) FROM Billing WHERE PaymentStatus = 'Pending'";
            return ExecuteScalarQueryDecimal(query);
        }

        private decimal GetTotalRevenue()
        {
            string query = "SELECT SUM(TotalAmount) FROM Billing WHERE PaymentStatus = 'Paid'";
            return ExecuteScalarQueryDecimal(query);
        }

        private decimal ExecuteScalarQueryDecimal(string query)
        {
            decimal result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        object value = command.ExecuteScalar();
                        result = value != DBNull.Value ? Convert.ToDecimal(value) : 0;
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;

        }



        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color1);
            if (currentChildform != null)
            {
                currentChildform.Close();
                currentChildform = null;
            }
            Reset();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color2);
            OpenChildForm(new Customer());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color3);
            OpenChildForm(new Reservations());

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color4);
            OpenChildForm(new Billing());

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color5);
            OpenChildForm(new Rooms());

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.color6);
            OpenChildForm(new Staff());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildform != null)
            {
                currentChildform.Close();
                currentChildform = null;
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            currentChildFormIcon.IconChar = IconChar.Home;
            currentChildFormIcon.IconColor = SystemColors.GradientActiveCaption;
            labelTitleChildForm.Text = "Dashboard";
        }


        //Form Dragging

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.Show();
        }
    }
}
