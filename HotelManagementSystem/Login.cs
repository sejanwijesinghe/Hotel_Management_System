using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            BorderStyle.ApplyRoundedBorder(this, 20);
            BorderStyle.ApplyRoundedBorder(guna2Panel1, 20);
            BorderStyle.ApplyRoundedBorder(pictureBox1, 20);

            textBox2.PasswordChar = '•';
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");


            try
            {
                string query = "SELECT COUNT(*) FROM UserData WHERE Username=@username AND Password=@password\r\n";


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    //MessageBox.Show("Login successful!");

                    this.Hide();

                    Dashboard dashboardForm = new Dashboard();
                    dashboardForm.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                textBox1.Focus();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '•';

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Register registerForm = new Register();
            registerForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}   

