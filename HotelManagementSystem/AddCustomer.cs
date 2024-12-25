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
using System.Windows.Navigation;

namespace HotelManagementSystem
{
    public partial class AddCustomer : Form
    {

        private int? customerId;

        public AddCustomer()
        {
            InitializeComponent();
        }

        
        public AddCustomer(int customerId, string firstName, string lastName, string email, string phone, string address, string nationality, string idNumber)
        {
            InitializeComponent();
            this.customerId = customerId;

            textFname.Text = firstName;
            textLname.Text = lastName;
            textEmail.Text = email;
            textPhone.Text = phone;
            textAddress.Text = address;
            textNationality.Text = nationality;
            textID.Text = idNumber;

        }

     

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (customerId.HasValue)
                {
                    UpdateCustomerInDatabase(customerId.Value, textFname.Text, textLname.Text, textEmail.Text, textPhone.Text, textAddress.Text, textNationality.Text, textID.Text);
                }
                else
                {
                    AddNewCustomerToDatabase(textFname.Text, textLname.Text, textEmail.Text, textPhone.Text, textAddress.Text, textNationality.Text, textID.Text);

                }
            }
        }

        //////
        ///
        private void AddNewCustomerToDatabase(string firstName, string lastName, string email, string phone, string address, string nationality, string idNumber)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Nationality, IDNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @Nationality, @IDNumber)", con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Nationality", nationality);
                    cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer successfully added.");


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
            textFname.Clear();
            textLname.Clear();
            textEmail.Clear();
            textPhone.Clear();
            textAddress.Clear();
            textNationality.Clear();
            textID.Clear();
        }
        private void UpdateCustomerInDatabase(int customerId, string firstName, string lastName, string email, string phone, string address, string nationality, string idNumber)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, Nationality = @Nationality, IDNumber = @IDNumber WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phone);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Nationality", nationality);
                        command.Parameters.AddWithValue("@IDNumber", idNumber);
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Customer record updated successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textFname.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textFname.Text, @"^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(textFname, "First name is invalid.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textFname, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textLname.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textLname.Text, @"^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(textLname, "Last name is invalid.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textLname, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textPhone.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textPhone.Text, @"^\d{10}$"))
            {
                errorProvider1.SetError(textPhone, "Phone number must be 10 digits.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textPhone, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textEmail.Text) || !textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
            {
                errorProvider1.SetError(textEmail, "Invalid email address.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textEmail, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textID.Text))
            {
                errorProvider1.SetError(textID, "ID number is required.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(textFname, string.Empty);
            }


            return isValid;
        }
    }
}
