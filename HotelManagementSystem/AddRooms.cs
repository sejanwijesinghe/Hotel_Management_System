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
using static System.Net.Mime.MediaTypeNames;

namespace HotelManagementSystem
{
    public partial class AddRooms : Form
    {

        private int? roomID;

        public AddRooms()
        {
            InitializeComponent();
        }

        public AddRooms(int roomID, string roomNo, string status, string type, string occupancy, string pricePerNight)
        {
            InitializeComponent();

            this.roomID = roomID;

            textRoomNo.Text = roomNo;
            guna2ComboBoxStatus.Text = status;
            guna2ComboBoxType.Text = type;
            guna2ComboBoxSize.Text = occupancy;
            textPrice.Text = pricePerNight;
            

        }


        private void AddNewRoomsToDatabase(string roomNo, string status, string type, string maxOccupancy, string pricePerNight)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Rooms (RoomNo, Status, Type, MaxOccupancy, PricePerNight) VALUES (@RoomNo, @Status, @Type, @MaxOccupancy, @PricePerNight)", con);
                    cmd.Parameters.AddWithValue("@RoomNo", roomNo);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@MaxOccupancy", maxOccupancy);
                    cmd.Parameters.AddWithValue("@PricePerNight", decimal.Parse(pricePerNight));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room is successfully added.");


                    ClearFormFields();

                    this.DialogResult = DialogResult.OK;
                    // this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void ClearFormFields()
        {
            textRoomId.Clear();
            textRoomNo.Clear();
            guna2ComboBoxStatus.SelectedIndex = -1;
            guna2ComboBoxType.SelectedIndex = -1;
            guna2ComboBoxSize.SelectedIndex = -1;
            textPrice.Clear();
        }
        private void UpdateRoomsInDatabase(int roomID,string roomNo, string status, string type, string maxOccupancy, string pricePerNight)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Rooms SET RoomNo = @RoomNo, Status = @Status, Type = @Type, MaxOccupancy = @MaxOccupancy, PricePerNight = @PricePerNight WHERE RoomID = @RoomID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomID", roomID);
                        command.Parameters.AddWithValue("@RoomNo", roomNo);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@MaxOccupancy", maxOccupancy);
                        command.Parameters.AddWithValue("@PricePerNight", pricePerNight);

                        //decimal price = decimal.Parse(pricePerNight);
                       // command.Parameters.AddWithValue("@PricePerNight", price);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Room record updated successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void AddRooms_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (roomID.HasValue)
                {
                    UpdateRoomsInDatabase(roomID.Value, textRoomNo.Text, guna2ComboBoxStatus.Text, guna2ComboBoxType.Text, guna2ComboBoxSize.Text, textPrice.Text);
                }
                else
                {
                    AddNewRoomsToDatabase(textRoomNo.Text, guna2ComboBoxStatus.Text, guna2ComboBoxType.Text, guna2ComboBoxSize.Text, textPrice.Text);

                }
            }
        }
           private bool ValidateInputs()
           {
               bool isValid = true;

               if (string.IsNullOrWhiteSpace(textRoomNo.Text)/* || !System.Text.RegularExpressions.Regex.IsMatch(textRoomNo.Text, @"^[a-zA-Z]+$")*/)
               {
                   errorProvider2.SetError(textRoomNo, "Room number is required.");
                   isValid = false;
               }
               else
               {
                    errorProvider2.SetError(textRoomNo, string.Empty);
               }

               if (string.IsNullOrWhiteSpace(guna2ComboBoxType.Text) || !System.Text.RegularExpressions.Regex.IsMatch(guna2ComboBoxType.Text, @"^[a-zA-Z]+$"))
               {
                    errorProvider2.SetError(guna2ComboBoxType, "Type is required.");
                    isValid = false;
               }
               else
               {
                    errorProvider2.SetError(guna2ComboBoxType, string.Empty);
               }

               if (string.IsNullOrWhiteSpace(guna2ComboBoxStatus.Text))
               {
                    errorProvider2.SetError(guna2ComboBoxStatus, "Room status is required.");
                    isValid = false;
               }
               else
               {
                    errorProvider2.SetError(guna2ComboBoxStatus, string.Empty);
               }

               if (string.IsNullOrWhiteSpace(guna2ComboBoxSize.Text))
               {
                    errorProvider2.SetError(guna2ComboBoxSize, "Please enter a value.");
                    isValid = false;
               }
               else
               {
                    errorProvider2.SetError(guna2ComboBoxSize, string.Empty);
               }

               if (string.IsNullOrWhiteSpace(textPrice.Text) || !decimal.TryParse(textPrice.Text, out decimal price) || price <= 0)
               {
                    errorProvider2.SetError(textPrice, "Valid price is required.");
                    isValid = false;
               }
               else
               {
                    errorProvider2.SetError(textPrice, string.Empty);
               }

               return isValid;
           }
           
    }
}
