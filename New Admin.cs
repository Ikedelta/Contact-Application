using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Application
{
    public partial class New_Admin : Form
    {
        string microsoftAccessDatabaseConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\a\\Documents\\ContactApp.accdb";
        string selectAllDataFromUser_Info = "SELECT * FROM [AdminInfo] ";

        public OleDbConnection microsoftAccessDatabaseConnection = null;



        public New_Admin()
        {
            microsoftAccessDatabaseConnection = new OleDbConnection(microsoftAccessDatabaseConnectionString);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string year = "@2024";
                string firstTwo = txtAdminFirstname.Text;
                string lastTwo = txtAdminLastname.Text;
                string generated = firstTwo.Substring(0, 2) + lastTwo.Substring(0, 2) + year;
                lblGenerated.Text = generated;


            }
            catch
            {
                MessageBox.Show("Enter New Admin Credentials", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtAdminFirstname.Text) && (string.IsNullOrEmpty(txtAdminLastname.Text)))
            {
                MessageBox.Show("Enter New Admin Info", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM [AdminInfo] WHERE [Last Name]=@Last_Name AND [First Name]=@First_Name AND [Username]=@Username AND [Password]=@Password";

                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, microsoftAccessDatabaseConnection))
                {
                    checkCommand.Parameters.AddWithValue("@Last_Name", txtAdminLastname.Text);
                    checkCommand.Parameters.AddWithValue("@First_Name", txtAdminFirstname.Text);
                    checkCommand.Parameters.AddWithValue("@Username", lblGenerated.Text);
                    checkCommand.Parameters.AddWithValue("@Password", txtAdminPassword.Text);

                    if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                    {
                        microsoftAccessDatabaseConnection.Open();
                    }

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("New Admin Info Already Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [AdminInfo] ([Username], [Password], [First Name], [Last Name]) VALUES (@Username, @Password, @First_Name, @Last_Name)";

                        using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, microsoftAccessDatabaseConnection))
                        {
                            insertCommand.Parameters.AddWithValue("@Username", string.IsNullOrEmpty(lblGenerated.Text) ? DBNull.Value : (object)lblGenerated.Text);
                            insertCommand.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(txtAdminPassword.Text) ? DBNull.Value : (object)txtAdminPassword.Text);
                            insertCommand.Parameters.AddWithValue("@First_Name", txtAdminFirstname.Text);
                            insertCommand.Parameters.AddWithValue("@Last_Name", string.IsNullOrEmpty(txtAdminLastname.Text) ? DBNull.Value : (object)txtAdminLastname.Text);

                            try
                            {
                                if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                                {
                                    microsoftAccessDatabaseConnection.Open();
                                }

                                int dataInserted = insertCommand.ExecuteNonQuery();

                                if (dataInserted > 0)
                                {
                                    MessageBox.Show("New Admin Successfully Added");
                                    // Clear the textboxes and labels
                                }

                                txtAdminFirstname.Clear();
                                txtAdminLastname.Clear();
                                lblGenerated.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error saving data: " + ex.Message);
                            }
                            finally
                            {
                                if (microsoftAccessDatabaseConnection.State == ConnectionState.Open)
                                {
                                    microsoftAccessDatabaseConnection.Close();
                                }
                            }
                        }
                    }



                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
            finally
            {
                if (microsoftAccessDatabaseConnection.State == ConnectionState.Open)
                {
                    microsoftAccessDatabaseConnection.Close();
                }
            }
        }


    }
}
