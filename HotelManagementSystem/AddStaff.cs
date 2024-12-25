using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace HotelManagementSystem
{
    public partial class AddStaff : Form
    {
        private int? staffId;

        public AddStaff()
        {
            InitializeComponent();
        }
        public AddStaff(int staffId, string firstName, string lastName, string position, string hiredate, string email, string phone, string idNumber)
        {
            InitializeComponent();

            this.staffId = staffId;

            textFname.Text = firstName;
            textLname.Text = lastName;
            textPosition.Text = position;
            textHiredate.Text = hiredate;
            textEmail.Text = email;
            textPhone.Text = phone;
            textID.Text = idNumber;

        }


        private void AddNewStaffToDatabase(string firstName, string lastName, string position, string hiredate, string email, string phone, string idNumber)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Staff (FirstName, LastName, Position, HireDate, Email, PhoneNumber, IDNumber) VALUES (@FirstName, @LastName, @Position, @HireDate, @Email, @PhoneNumber, @IDNumber)", con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@HireDate", hiredate);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Staff member successfully added.");


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
            textPosition.Clear();
            textHiredate.Clear();
            textEmail.Clear();
            textPhone.Clear();
            textID.Clear();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textFname.Text)||!System.Text.RegularExpressions.Regex.IsMatch(textFname.Text, @"^[a-zA-Z]+$"))
            {
                errorProvider.SetError(textFname, "First name is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textFname, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textLname.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textLname.Text, @"^[a-zA-Z]+$"))
            {
                errorProvider.SetError(textLname, "Last name is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textLname, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textPhone.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textPhone.Text, @"^\d{10}$"))
            {
                errorProvider.SetError(textPhone, "Phone number must be 10 digits.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textPhone, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textEmail.Text) || !textEmail.Text.Contains("@") ||!textEmail.Text.Contains("."))
            {
                errorProvider.SetError(textEmail, "Invalid email address.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textEmail, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(textID.Text))
            {
                errorProvider.SetError(textID, "ID number is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textFname, string.Empty);
            }

            return isValid;
        }
        private void UpdateStaffInDatabase(int staffId, string firstName, string lastName, string position, string hiredate, string email, string phone, string idNumber)
        {
            string connectionString = "Data Source=LAPTOP-SUS67EQG;Initial Catalog=HotelManagementSystem;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Staff SET FirstName = @FirstName, LastName = @LastName, Position = @Position, HireDate = @HireDate, Email = @Email, PhoneNumber = @PhoneNumber, IDNumber = @IDNumber WHERE StaffID = @StaffID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@HireDate", hiredate);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phone);
                        command.Parameters.AddWithValue("@IDNumber", idNumber);
                        command.Parameters.AddWithValue("@StaffID", staffId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Staff record updated successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (staffId.HasValue)
                {
                    UpdateStaffInDatabase(staffId.Value, textFname.Text, textLname.Text, textPosition.Text, textHiredate.Text, textEmail.Text, textPhone.Text, textID.Text);
                }
                else
                {
                    AddNewStaffToDatabase(textFname.Text, textLname.Text, textPosition.Text, textHiredate.Text, textEmail.Text, textPhone.Text, textID.Text);

                }
            }
        }

        private void textHiredate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
