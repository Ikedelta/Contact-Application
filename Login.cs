using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Application
{
    public partial class Login : Form
    {
        string microsoftAccessDatabaseConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\a\\Documents\\ContactApp.accdb";
        public OleDbConnection microsoftAccessDatabaseConnection = null;
        private object lblGenerated;
        private object txtAdminPassword;

        public Login()
        {
            microsoftAccessDatabaseConnection = new OleDbConnection(microsoftAccessDatabaseConnectionString);

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            try
            {
                microsoftAccessDatabaseConnection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if username and password fields are empty
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get the entered password and username
                string enteredPassword = txtPassword.Text;
                string enteredUsername = txtUsername.Text;

                // SQL query to check if username and password match
                string query = "SELECT COUNT(*) FROM [AdminInfo] WHERE [Username]=@Username AND [Password]=@Password";

                using (OleDbCommand command = new OleDbCommand(query, microsoftAccessDatabaseConnection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@Username", enteredUsername);
                    command.Parameters.AddWithValue("@Password", enteredPassword);

                    if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                    {
                        microsoftAccessDatabaseConnection.Open();
                    }

                    // Execute the query to check if the credentials are valid
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");
                        this.Hide();
                        Form1 form1 = new Form1();
                        form1.Show();


                        // Proceed with what you want to do after successful login
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (microsoftAccessDatabaseConnection.State == ConnectionState.Open)
                {
                    microsoftAccessDatabaseConnection.Close();
                }
            }
        }


        private static void radPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the Application", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
    }
}
