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
    public partial class Customer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public Customer()
        {
            InitializeComponent();
        }

        private void Populate()
        {

            con.Open();
            string query = "SELECT * FROM Customers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds); 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddCustomer form = new AddCustomer();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Customer_Load_1(object sender, EventArgs e)
        {
            Populate(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) 
            {
                var customerId = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value;

                string firstName = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lastName = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string phone = dataGridView1.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                string address = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                string nationality = dataGridView1.Rows[e.RowIndex].Cells["Nationality"].Value.ToString();
                string idNumber = dataGridView1.Rows[e.RowIndex].Cells["IDNumber"].Value.ToString();

                AddCustomer form = new AddCustomer((int)customerId, firstName, lastName, email, phone, address, nationality, idNumber);
                form.ShowDialog();

                Populate();
            }


            if (e.ColumnIndex == 9) 
            {
                var customerId = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the student record with ID: {customerId}?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    DeleteCustomerFromDatabase(customerId);
                }
            }
        }

        private void DeleteCustomerFromDatabase(object customerId)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
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

                string query = "SELECT * FROM Customers WHERE FirstName LIKE @searchText OR LastName LIKE @searchText";

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
