using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Staff : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public Staff()
        {
            InitializeComponent();
        }

        private void Populate()
        {

            con.Open();
            string query = "SELECT * FROM Staff";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {
            this.staffTableAdapter1.Fill(this.hotelManagementSystemDataSet3.Staff);

            Populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddStaff form = new AddStaff();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                var staffId = dataGridView1.Rows[e.RowIndex].Cells["StaffID"].Value;

                string firstName = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lastName = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string position = dataGridView1.Rows[e.RowIndex].Cells["Position"].Value.ToString();
                string hireDate = dataGridView1.Rows[e.RowIndex].Cells["HireDate"].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string phone = dataGridView1.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                string idNumber = dataGridView1.Rows[e.RowIndex].Cells["IDNumber"].Value.ToString();

                AddStaff form = new AddStaff((int)staffId, firstName, lastName, position, hireDate, email, phone, idNumber);
                form.ShowDialog();

                Populate();
            }


            if (e.ColumnIndex == 9)
            {
                var staffId = dataGridView1.Rows[e.RowIndex].Cells["StaffID"].Value;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the staff record with ID: {staffId}?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    DeleteStaffFromDatabase((int)staffId);
                }

            }
        }

        private void DeleteStaffFromDatabase(object staffId)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Staff WHERE StaffID = @StaffID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffID", staffId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = "SELECT * FROM Staff WHERE FirstName LIKE @searchText OR LastName LIKE @searchText";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue("@searchText", textSearch.Text.Trim() + "%");

                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

}
