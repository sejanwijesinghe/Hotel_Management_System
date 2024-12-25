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
    public partial class Rooms : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public Rooms()
        {
            InitializeComponent();
        }

        private void Populate()
        {

            con.Open();
            string query = "SELECT * FROM Rooms";
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
            AddRooms form = new AddRooms();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Populate();
            }
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            this.roomsTableAdapter1.Fill(this.hotelManagementSystemDataSet7.Rooms);
            this.roomsTableAdapter.Fill(this.hotelManagementSystemDataSet4.Rooms);

            Populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var roomID = dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value;

                string roomNo = dataGridView1.Rows[e.RowIndex].Cells["RoomNo"].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                string type = dataGridView1.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                string maxOccupancy = dataGridView1.Rows[e.RowIndex].Cells["MaxOccupancy"].Value.ToString();
                string pricePerNight = dataGridView1.Rows[e.RowIndex].Cells["PricePerNight"].Value.ToString();


                AddRooms form = new AddRooms((int)roomID, roomNo, status, type, maxOccupancy, pricePerNight);
                form.ShowDialog();

                Populate();
            }


            if (e.ColumnIndex == 7)
            {
                var roomID = dataGridView1.Rows[e.RowIndex].Cells["RoomID"].Value;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the room record with ID: {roomID}?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    DeleteRoomsFromDatabase((int)roomID);
                }

            }
        }

        private void DeleteRoomsFromDatabase(object roomID)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomID", roomID);
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

                string query = "SELECT * FROM Rooms WHERE RoomID LIKE @searchText OR RoomNo LIKE @searchText";

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
