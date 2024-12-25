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
    public partial class AddBill : Form
    {
        private int? billingId;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True");


        public AddBill(int? billingId = null, int reservationId = 0, decimal TotalAmount = 0, string paymentStatus = "", string paymentMethod = "")
        {
            InitializeComponent();
            this.billingId = billingId;
            LoadReservations();

            if (billingId.HasValue)
            {
                guna2ComboBox1Reservation.SelectedValue = reservationId;
                textBoxMainPayment.Text = TotalAmount.ToString("F2");
                guna2ComboBoxStatus.Text = paymentStatus;
                guna2ComboBoxMethod.Text = paymentMethod;

            }
        }

        private void LoadReservations()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ReservationID FROM Reservations", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2ComboBox1Reservation.DataSource = dt;
            guna2ComboBox1Reservation.ValueMember = "ReservationID";
            con.Close();
        }

        private void SaveBill()
        {
            try
            {
                con.Open();
                string query;
                if (billingId.HasValue)
                {
                    query = @"UPDATE Billing SET ReservationID = @ReservationID, TotalAmount = @TotalAmount, PaymentStatus = @PaymentStatus, PaymentMethod = @PaymentMethod WHERE BillingID = @BillingID";
                }
                else
                {
                    query = @"INSERT INTO Billing (ReservationID, TotalAmount, PaymentStatus, PaymentMethod) VALUES (@ReservationID, @TotalAmount, @PaymentStatus, @PaymentMethod)";
                }
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", (int)guna2ComboBox1Reservation.SelectedValue);
                    cmd.Parameters.AddWithValue("@TotalAmount", decimal.Parse(textBoxMainPayment.Text));
                    cmd.Parameters.AddWithValue("@PaymentStatus", guna2ComboBoxStatus.Text);
                    cmd.Parameters.AddWithValue("@PaymentMethod", guna2ComboBoxMethod.Text);


                    if (billingId.HasValue)
                        cmd.Parameters.AddWithValue("@BillingID", billingId.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(billingId.HasValue ? "Bill updated successfully." : "Bill added successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving bill: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        
        public AddBill()
        {
            InitializeComponent();
            LoadReservations();
        }

        private void AddBill_Load(object sender, EventArgs e)
        {

        }

        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveBill();
            }
        }

        private void LoadAdvanceCharge(int reservationId)
        {
            try
            {
                con.Open();
                string query = "SELECT TotalAmount FROM Reservations WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textAdvance.Text = reader["TotalAmount"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (!decimal.TryParse(textBoxMainPayment.Text, out decimal price))
            {
                errorProvider5.SetError(textBoxMainPayment, "Please enter valid payment.");
                isValid = false;
            }
            else
            {
                errorProvider5.SetError(textBoxMainPayment, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(guna2ComboBoxStatus.Text))
            {
                errorProvider5.SetError(guna2ComboBoxStatus, "Payment status is required.");
                isValid = false;
            }
            else
            {
                errorProvider5.SetError(guna2ComboBoxStatus, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(guna2ComboBoxMethod.Text))
            {
                errorProvider5.SetError(guna2ComboBoxMethod, "Payment method is required.");
                isValid = false;
            }
            else
            {
                errorProvider5.SetError(guna2ComboBoxMethod, string.Empty);
            }

            return isValid;

        }

        private void guna2ComboBox1Reservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1Reservation.SelectedValue != null && int.TryParse(guna2ComboBox1Reservation.SelectedValue.ToString(), out int reservationId))
            {
                LoadAdvanceCharge(reservationId);
            }
        }
    }
}
