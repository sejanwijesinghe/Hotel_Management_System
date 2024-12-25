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
    public partial class Billing : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public Billing()
        {
            InitializeComponent();
            Populate();

        }

        private void Populate()
        {
            con.Open();
            string query = "SELECT * FROM Billing";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void AddBill_Click(object sender, EventArgs e)
        {
            AddBill form = new AddBill();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }



        private void Billing_Load(object sender, EventArgs e)
        {
            this.billingTableAdapter.Fill(this.hotelManagementSystemDataSet6.Billing);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) 
            {
                int billingId = (int)dataGridView1.Rows[e.RowIndex].Cells["BillingID"].Value;
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int reservationId = (int)selectedRow.Cells["ReservationID"].Value;
                decimal totalAmount = (decimal)selectedRow.Cells["TotalAmount"].Value;
                string paymentStatus = selectedRow.Cells["PaymentStatus"].Value.ToString();
                string paymentMethod = selectedRow.Cells["PaymentMethod"].Value.ToString();


                AddBill form = new AddBill(billingId, reservationId, totalAmount,  paymentStatus, paymentMethod);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Populate();
                }
            }
            else if (e.ColumnIndex == 7) 
            {
                int billingId = (int)dataGridView1.Rows[e.RowIndex].Cells["BillingID"].Value;
                DialogResult result = MessageBox.Show($"Are you sure you want to delete bill {billingId}?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteBill(billingId);
                    Populate();
                }
            }
        }

        private void DeleteBill(int billingId)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM Billing WHERE BillingID = @BillingID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BillingID", billingId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Bill deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting bill: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddBill form = new AddBill();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                string query = "SELECT * FROM Billing WHERE BillingID LIKE @searchText OR ReservationID LIKE @searchText";

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
