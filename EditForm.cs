using iText.IO.Colors;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Application
{
    public partial class EditForm : Form
    {




        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string OtherContact { get; set; }
        public string EmailAddress { get; set; }
        public string OtherEmail { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Note { get; set; }


        private void EditForm_Load(object sender, EventArgs e)
        {

        }



        public EditForm(int id, string lastName, string firstName, string address, string contact, string otherContact,
                    string emailAddress, string otherEmail, string gender, string occupation, string note)
        {
            InitializeComponent();
            // Assign the passed-in values to the form fields
            ID = id;
            txtEditLastName.Text = lastName;
            txtEditFirstName.Text = firstName;
            txtEditAddress.Text = address;
            txtEditContact.Text = contact;
            txtEditOtherContact.Text = otherContact;
            txtEditEmailAddress.Text = emailAddress;
            txtEditOtherEmail.Text = otherEmail;
            cmbEditGender.SelectedItem = gender;
            txtEditOccupation.Text = occupation;
            txtEditNote.Text = note;


            // Set the Gender ComboBox value
            if (gender != null)
            {
                cmbEditGender.SelectedItem = gender;
            }
            else
            {
                cmbEditGender.SelectedIndex = -1; // Clear selection if gender is null
            }


        }
        private byte[] selectedImageBytes;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Update Image";
            openFileDialog.Filter = "ImageFiles|*.Jpeg; *.Jpg; *.Png| All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                MessageBox.Show("Selected Image: " + selectedImagePath);
                picEditIcon.Hide();

                selectedImageBytes = File.ReadAllBytes(selectedImagePath);

                try
                {
                    picEditProfile.Image = new System.Drawing.Bitmap(selectedImagePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }


            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (picEditProfile.Image != null)
            {
                string imageName = $"{txtEditLastName.Text}_{txtEditFirstName.Text}.png";
                string imagePath = Path.Combine(@"C:\Users\a\Desktop\USER PROFILE", imageName);
                picEditProfile.Image.Save(imagePath, ImageFormat.Jpeg);
            }
            Refresh();
            UpdateContactInDatabase();
        }

        private void UpdateContactInDatabase()
        {
            try
            {
                // Establish connection - Use your actual database connection string
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\a\\Documents\\ContactApp.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // UPDATE query to update the record with the specified ID
                    string updateQuery = @"UPDATE [User Info] SET [LastName]=@LastName, [FirstName]=@FirstName,
                [Address]=@Address, [Contact]=@Contact, [Other Contact]=@OtherContact, 
                [Email Address]=@EmailAddress, [Other Email]=@OtherEmail, [Gender]=@Gender,
                [Occupation]=@Occupation, [Note]=@Note WHERE [ID]=@ID";


                    Console.WriteLine(updateQuery); // Debugging
                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        // Parameters for the UPDATE query
                        command.Parameters.AddWithValue("@LastName", txtEditLastName.Text);
                        command.Parameters.AddWithValue("@FirstName", txtEditFirstName.Text);
                        command.Parameters.AddWithValue("@Address", txtEditAddress.Text);
                        command.Parameters.AddWithValue("@Contact", txtEditContact.Text);
                        command.Parameters.AddWithValue("@OtherContact", txtEditOtherContact.Text);
                        command.Parameters.AddWithValue("@EmailAddress", txtEditEmailAddress.Text);
                        command.Parameters.AddWithValue("@OtherEmail", txtEditOtherEmail.Text);
                        command.Parameters.AddWithValue("@Gender", cmbEditGender.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@Occupation", txtEditOccupation.Text);
                        command.Parameters.AddWithValue("@Note", txtEditNote.Text);
                        command.Parameters.AddWithValue("@ID", ID);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No record updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }


       

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                               "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Establish connection - Use your actual database connection string
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\a\\Documents\\ContactApp.accdb"; ;
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        // DELETE query to remove the record with the specified ID
                        string deleteQuery = "DELETE FROM [User Info] WHERE ID=@ID";

                        using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                        {
                            // Parameter for the ID
                            command.Parameters.AddWithValue("@ID", ID);

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully!");
                                this.Close(); // Close the form after deletion
                            }
                            else
                            {
                                MessageBox.Show("No record deleted.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }   }
    }
}
