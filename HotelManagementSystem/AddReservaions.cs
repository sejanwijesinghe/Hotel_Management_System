using Guna.UI2.WinForms;
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
    public partial class AddReservaions : Form
    {
        private int? reservationId = null;

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");

        public AddReservaions()
        {
            InitializeComponent();
            LoadCustomerList();
            LoadRoomList();

        }

        private void LoadCustomerList()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CustomerID, FirstName + ' ' + LastName AS CustomerName FROM Customers", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerID";
                comboBoxCustomer.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoadRoomList()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RoomID FROM Rooms", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //comboBoxRoom.DisplayMember = "RoomNumber";
                comboBoxRoom.ValueMember = "RoomID";
                comboBoxRoom.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public AddReservaions(int reservationId = 0, int customerId = 0, int roomId = 0, DateTime? checkInDate = null, DateTime? checkOutDate = null, decimal totalAmount = 0)
        {

            InitializeComponent();
            LoadCustomerList();
            LoadRoomList();

            if (reservationId > 0)
            {
                this.reservationId = reservationId;
                comboBoxCustomer.SelectedValue = customerId;
                comboBoxRoom.SelectedValue = roomId;
                guna2DateTimePicker1.Value = checkInDate ?? DateTime.Now;
                guna2DateTimePicker2.Value = checkOutDate ?? DateTime.Now.AddDays(1);

                textAdvance.Text = totalAmount.ToString("F2");
            }
        }    
           
        private void UpdateReservation(int reservationId, int customerId, int roomId, DateTime checkInDate, DateTime checkOutDate, decimal totalAmount)
        {
            try
            {
                con.Open();
                string query = @"
            UPDATE Reservations
            SET CustomerID = @CustomerID,
                RoomID = @RoomID,
                CheckInDate = @CheckInDate,
                CheckOutDate = @CheckOutDate,
                TotalAmount = @TotalAmount
            WHERE ReservationID = @ReservationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@RoomID", roomId);
                    cmd.Parameters.AddWithValue("@CheckInDate", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@CheckOutDate", guna2DateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Reservation successfully updated.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SaveReservation()
        {
            try
            {
                con.Open();

                string query = @"
            INSERT INTO Reservations (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalAmount, DateOfReservation) 
            VALUES (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate, @TotalAmount, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(comboBoxCustomer.SelectedValue)); // Get the selected customer ID
                    cmd.Parameters.AddWithValue("@RoomID", Convert.ToInt32(comboBoxRoom.SelectedValue)); // Get the selected room ID
                                                                                                         // cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(textCheckIn.Text));
                                                                                                         //cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(textCheckOut.Text));
                    cmd.Parameters.AddWithValue("@CheckInDate", guna2DateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@CheckOutDate", guna2DateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(textAdvance.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Reservation successfully added.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding reservation: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddReservaions_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2DateTimePicker2.Value = DateTime.Now.AddDays(1);


        }

        private void CalculateTotalCharge()
        {
            try
            {
                if (int.TryParse(comboBoxRoom.Text, out int roomId) &&
                    DateTime.TryParse(guna2DateTimePicker1.Text, out DateTime checkInDate) &&
                    DateTime.TryParse(guna2DateTimePicker2.Text, out DateTime checkOutDate))
                {
                  /*  if (checkInDate == checkOutDate)
                    {
                        MessageBox.Show("Check-Out Date must be later than Check-In Date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }*/

                    decimal pricePerNight = GetRoomPrice(roomId);
                    if (pricePerNight == -1)
                    {
                        MessageBox.Show("Please select a valid Room ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int days = (checkOutDate - checkInDate).Days;
                    decimal totalCharge = days * pricePerNight;

                    textBoxtotal.Text = totalCharge.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please provide valid Room ID and Dates.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetRoomPrice(int roomId)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";
            decimal pricePerNight = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PricePerNight FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        pricePerNight = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return pricePerNight;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (reservationId.HasValue)
                {
                    UpdateReservation(reservationId.Value,
                                      (int)comboBoxCustomer.SelectedValue,
                                      (int)comboBoxRoom.SelectedValue,
                                      guna2DateTimePicker1.Value,
                                      guna2DateTimePicker2.Value,
                                      decimal.Parse(textAdvance.Text));
                }
                else
                {
                    SaveReservation();
                }
            }

        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(comboBoxCustomer.Text))
            {
                errorProvider6.SetError(comboBoxCustomer, "Please enter customer ID.");
                isValid = false;
            }
            else
            {
                errorProvider6.SetError(comboBoxCustomer, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(comboBoxRoom.Text))
            {
                errorProvider6.SetError(comboBoxRoom, "Please enter room ID.");
                isValid = false;
            }
            else
            {
                errorProvider6.SetError(comboBoxRoom, string.Empty);
            }

            if (!decimal.TryParse(textAdvance.Text, out decimal price))
            {
                errorProvider6.SetError(textAdvance, "Please enter valid payment.");
                isValid = false;
            }
            else
            {
                errorProvider6.SetError(textAdvance, string.Empty);
            }

            return isValid;

        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalCharge();

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalCharge();

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalCharge();

        }

        private void textBoxtotal_TextChanged(object sender, EventArgs e)
        {
        }

        private void textAdvance_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (decimal.TryParse(textBoxtotal.Text, out decimal totalCharge) &&
                    decimal.TryParse(textAdvance.Text, out decimal advancePayment))
                {
                    if (advancePayment > totalCharge)
                    {
                        MessageBox.Show("Please enter a valid advance payment.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal balance = totalCharge - advancePayment;
                    textBalance.Text = balance.ToString("F2");
                }
                else
                {
                    textBalance.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
