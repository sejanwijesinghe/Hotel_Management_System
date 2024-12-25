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
    public partial class Reservations : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public Reservations()
        {
            InitializeComponent();
        }

        private void Populate()
        {

            try
            {
                con.Open();

                string query = @"
                    SELECT 
                        Reservations.ReservationID,
                        Reservations.CustomerID,
                        Customers.FirstName + ' ' + Customers.LastName AS CustomerName,
                        Reservations.RoomID,
                        Reservations.CheckInDate,
                        Reservations.CheckOutDate,
                        Reservations.TotalAmount,
                        Reservations.DateOfReservation
                    FROM 
                        Reservations
                    JOIN 
                        Customers ON Reservations.CustomerID = Customers.CustomerID
                    JOIN 
                        Rooms ON Reservations.RoomID = Rooms.RoomID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }


        private void Reservations_Load(object sender, EventArgs e)
        {
            this.reservationsTableAdapter.Fill(this.hotelManagementSystemDataSet5.Reservations);
            Populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddReservaions form = new AddReservaions();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var reservationId = (int)dataGridView1.Rows[e.RowIndex].Cells["ReservationID"].Value;
                int customerId = (int)dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value;
                int roomId = (int)dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value;
                DateTime checkInDate = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["CheckInDate"].Value;
                DateTime checkOutDate = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["CheckOutDate"].Value;
                decimal totalAmount = (decimal)dataGridView1.Rows[e.RowIndex].Cells["TotalAmount"].Value;

                AddReservaions form = new AddReservaions((int)reservationId, customerId, roomId, checkInDate, checkOutDate, totalAmount);
                form.ShowDialog();
                Populate();
            }


            if (e.ColumnIndex == 8)
            {
                var reservationId = (int)dataGridView1.Rows[e.RowIndex].Cells["ReservationID"].Value;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the reservation record with ID: {reservationId}?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    DeleteReservationFromDatabase((int)reservationId);
                }

            }
        }

        private void DeleteReservationFromDatabase(object reservationId)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReservationID", reservationId);
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

                string query = "SELECT * FROM Reservations WHERE ReservationID LIKE @searchText OR CustomerID LIKE @searchText";

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
