


using iText.Forms.Form.Element;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Contact_Application
{
    public partial class Form1 : Form
    {
        string microsoftAccessDatabaseConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\a\\Documents\\ContactApp.accdb";
        string selectAllDataFromUser_Info = "SELECT * FROM [User Info] ";

        public OleDbConnection microsoftAccessDatabaseConnection = null;
        private object txtAdminFirstname;
        private object totalRecords;
        private string txtAdminPassword;

        private string txtDefaultPassword;


        public Form1()
        {
            microsoftAccessDatabaseConnection = new OleDbConnection(microsoftAccessDatabaseConnectionString);
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DateTime currentDateTime = DateTime.Now;
            lblDateTime.Text = currentDateTime.ToString("MMMM dd, yyyy");
            txtLastname.Focus();
            try
            {
                microsoftAccessDatabaseConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            populateDataGridViewFromMicrosoftAccessDatabase();

        }

        private void populateDataGridViewFromMicrosoftAccessDatabase()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows before populating

            try
            {

                OleDbCommand populateDataGridviewFromMicrosoftAccessDatabaseOleDbCommand = new OleDbCommand(selectAllDataFromUser_Info, microsoftAccessDatabaseConnection);
                OleDbDataReader reader = populateDataGridviewFromMicrosoftAccessDatabaseOleDbCommand.ExecuteReader();

                while (reader.Read())
                {
                    // Add rows to the DataGridView
                    dataGridView1.Rows.Add(reader["ID"], reader["LastName"], reader["FirstName"], reader["Address"], reader["Contact"], reader["Other Contact"], reader["Email Address"], reader["Other Email"], reader["Gender"], reader["Occupation"], reader["Note"]);
                }

                reader.Close();

                // Scroll to the last row (newly added row) to ensure it's visible
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
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




        private byte[] selectedImageBytes;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select an image File";
            openFileDialog1.Filter = "imageFiles|*.Jpg;* .Jpeg*;*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog1.FileName;
                MessageBox.Show("Selected Image: " + selectedImagePath);
                picIcon.Hide();

                // Read the image file into a byte array
                selectedImageBytes = File.ReadAllBytes(selectedImagePath);

                try
                {
                    picProfile.Image = new System.Drawing.Bitmap(selectedImagePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            populateDataGridViewFromMicrosoftAccessDatabase();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                MessageBox.Show("Enter First Name", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for a valid email address
            string gmail = txtEmailAddress.Text.ToLower();

            if (!gmail.Contains("@gmail.com") && !gmail.Contains("@yahoo.com"))
            {
                MessageBox.Show("Please enter a valid Gmail or Yahoo address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM [User Info] WHERE [LastName]=@Last_Name AND [FirstName]=@First_Name ";

                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, microsoftAccessDatabaseConnection))
                {
                    checkCommand.Parameters.AddWithValue("@Last_Name", txtLastname.Text);
                    checkCommand.Parameters.AddWithValue("@First_Name", txtFirstname.Text);

                    if (txtContact.Text.Length != 10)
                    {
                        MessageBox.Show("Contact Must be 10", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Contact Validation... The contact must integers and also the contact must be 10 digits
                    if (!int.TryParse(txtContact.Text, out int contact))
                    {
                        MessageBox.Show("Contact Must be integers Only", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Open the connection only when necessary
                    if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                    {
                        microsoftAccessDatabaseConnection.Open();
                    }


                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Data already exists for this Last Name and First Name combination.");
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [User Info] ([LastName], [FirstName], [Address], [Contact], [Other Contact], [Other Email], [Email Address], [Gender], [Occupation], [Note]) VALUES (@Last_Name, @First_Name, @Address, @Contact, @Other_Contact, @Email_Address, @Other_Email, @Gender, @Occupation, @Note)";
                        using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, microsoftAccessDatabaseConnection))
                        {
                            insertCommand.Parameters.AddWithValue("@Last_Name", txtLastname.Text);
                            insertCommand.Parameters.AddWithValue("@First_Name", txtFirstname.Text);
                            insertCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
                            insertCommand.Parameters.AddWithValue("@Contact", txtContact.Text);
                            insertCommand.Parameters.AddWithValue("@Other_Contact", txtContact2.Text);
                            insertCommand.Parameters.AddWithValue("@Email_Address", txtEmailAddress.Text);
                            insertCommand.Parameters.AddWithValue("@Other_Email", txtEmail2.Text);

                            insertCommand.Parameters.AddWithValue("@Gender", cmbGender.Text);
                            insertCommand.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                            insertCommand.Parameters.AddWithValue("@Note", txtNote.Text);
                           // insertCommand.Parameters.AddWithValue("@Profile", selectedImageBytes);

                            if (picProfile.Image != null)
                            {
                                string imageName = $"{txtLastname.Text}_{txtFirstname.Text}.png";
                                string imagePath = Path.Combine(@"C:\Users\a\Desktop\USER PROFILE", imageName);
                                picProfile.Image.Save(imagePath, ImageFormat.Jpeg);
                            }

                            int dataInserted = insertCommand.ExecuteNonQuery();

                            if (dataInserted > 0)
                            {
                                MessageBox.Show("Detail Saved Successfully");

                                // Insert the new row at the top of the DataGridView
                                dataGridView1.Rows.Insert(0, txtLastname.Text, txtFirstname.Text, txtAddress.Text, txtContact2.Text, txtContact, txtEmailAddress.Text, txtEmail2.Text, cmbGender.Text, txtOccupation.Text, txtNote.Text);

                                // Clear the input fields
                                txtAddress.Clear();
                                txtContact.Clear();
                                txtContact2.Clear();
                                cmbGender.Text = "";
                                txtOccupation.Clear();
                                txtEmailAddress.Clear();
                                txtEmail2.Clear();
                                txtLastname.Clear();
                                txtFirstname.Clear();
                                txtNote.Clear();
                                picProfile.Image = null;

                                RefreshDataGridView();
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


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eXPORTDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }


        private void LogError(string filePath, string errorMessage)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.WriteLine("Error occurred at: " + DateTime.Now.ToString());
                    writer.WriteLine("Error message: " + errorMessage);
                    writer.WriteLine("--------------------------------------------------");
                }
            }
            catch (Exception)
            {
                // Failed to log error, do nothing
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Input Needed", "");


            var result = MessageBox.Show("Are you Sure you Want to clear the Information", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {

                    string clearQuery = "DELETE FROM [User Info]";
                    microsoftAccessDatabaseConnection.Open();
                    using (OleDbCommand clearCommand = new OleDbCommand(clearQuery, microsoftAccessDatabaseConnection))
                    {
                        clearCommand.ExecuteNonQuery();
                    }

                    string resetAutoIncrementQuery = "ALTER TABLE [User Info] ALTER COLUMN ID COUNTER(1,1)";
                    using (OleDbCommand resetCommand = new OleDbCommand(resetAutoIncrementQuery, microsoftAccessDatabaseConnection))
                    {
                        resetCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Cleared Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing data: " + ex.Message);
                }
                finally
                {
                    if (microsoftAccessDatabaseConnection.State == ConnectionState.Open)
                    {
                        microsoftAccessDatabaseConnection.Close();
                    }
                }
                RefreshDataGridView();
            }
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }


        //...////.......................//////////////////////////////


        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the selected row from the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the data from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string lastName = Convert.ToString(selectedRow.Cells["LastName"].Value);
                string firstName = Convert.ToString(selectedRow.Cells["FirstName"].Value);
                string address = Convert.ToString(selectedRow.Cells["Address"].Value);
                string contact = Convert.ToString(selectedRow.Cells["Contact"].Value);
                string otherContact = Convert.ToString(selectedRow.Cells["OtherContact"].Value); // Ensure correct column name
                string emailAddress = Convert.ToString(selectedRow.Cells["EmailAddress"].Value); // Ensure correct column name
                string otherEmail = Convert.ToString(selectedRow.Cells["OtherEmail"].Value); // Ensure correct column name
                string gender = Convert.ToString(selectedRow.Cells["Gender"].Value);
                string occupation = Convert.ToString(selectedRow.Cells["Occupation"].Value);
                string note = Convert.ToString(selectedRow.Cells["Note"].Value);

                // Open the EditForm with the selected data
                EditForm editForm = new EditForm(id, lastName, firstName, address, contact, otherContact,
                                                  emailAddress, otherEmail, gender, occupation, note);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        //private void EnableAllControls(bool enable)
        //{
        //    txtLastname.Enabled = enable;
        //    txtFirstname.Enabled = enable;
        //    txtAddress.Enabled = enable;
        //    txtContact.Enabled = enable;
        //    txtEmailAddress.Enabled = enable;
        //    cmbGender.Enabled = enable;
        //    txtOccupation.Enabled = enable;
        //    txtNote.Enabled = enable;

        //}

        private void SearchInDatabase(string keyword)
        {
            try
            {
                string query = "SELECT * FROM [User Info] WHERE [LastName] LIKE @Keyword OR [FirstName] LIKE @Keyword OR [Address] LIKE @Keyword OR [Email Address] LIKE @Keyword OR [Occupation] LIKE @Keyword";

                using (OleDbCommand command = new OleDbCommand(query, microsoftAccessDatabaseConnection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear existing rows in the DataGridView
                    dataGridView1.Rows.Clear();

                    // Add search results to the DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Add rows to the DataGridView with correct column mapping
                        dataGridView1.Rows.Add(
                            row["ID"],
                            row["LastName"],
                            row["FirstName"],
                            row["Address"],
                            row["Contact"],
                            row["Other Contact"],
                            row["Email Address"],
                            row["Other Email"],
                            row["Gender"],
                            row["Occupation"],
                            row["Note"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching database: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void nEWENTRYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                MessageBox.Show("Enter First Name", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for a valid email address
            if (!txtEmailAddress.Text.Contains("@gmail.com") && !txtEmailAddress.Text.Contains("@yahoo.com"))
            {
                MessageBox.Show("Please enter a valid Gmail or Yahoo address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM [User Info] WHERE [LastName]=@Last_Name AND [FirstName]=@First_Name ";

                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, microsoftAccessDatabaseConnection))
                {
                    checkCommand.Parameters.AddWithValue("@Last_Name", txtLastname.Text);
                    checkCommand.Parameters.AddWithValue("@First_Name", txtFirstname.Text);

                    if (txtContact.Text.Length != 10)
                    {
                        MessageBox.Show("Contact Must be 10", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Contact Validation... The contact must integers and also the contact must be 10 digits
                    if (!int.TryParse(txtContact.Text, out int contact))
                    {
                        MessageBox.Show("Contact Must be integers Only", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Open the connection only when necessary
                    if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                    {
                        microsoftAccessDatabaseConnection.Open();
                    }

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Data already exists for this Last Name and First Name combination.");
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [User Info] ([LastName], [FirstName], [Address], [Contact], [Email Address], [Gender], [Occupation], [Note]) VALUES (@Last_Name, @First_Name, @Address, @Contact, @Email_Address, @Gender, @Occupation, @Note)";
                        using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, microsoftAccessDatabaseConnection))
                        {
                            insertCommand.Parameters.AddWithValue("@Last_Name", txtLastname.Text);
                            insertCommand.Parameters.AddWithValue("@First_Name", txtFirstname.Text);
                            insertCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
                            insertCommand.Parameters.AddWithValue("@Contact", txtContact.Text);
                            insertCommand.Parameters.AddWithValue("@Email_Address", txtEmailAddress.Text);
                            insertCommand.Parameters.AddWithValue("@Gender", cmbGender.Text);
                            insertCommand.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                            insertCommand.Parameters.AddWithValue("@Note", txtNote.Text);

                            int dataInserted = insertCommand.ExecuteNonQuery();

                            if (dataInserted > 0)
                            {
                                MessageBox.Show("Detail Saved Successfully");
                                txtAddress.Clear();
                                txtContact.Clear();
                                cmbGender.Text = "";
                                txtOccupation.Clear();
                                txtEmailAddress.Clear();
                                txtLastname.Clear();
                                txtFirstname.Clear();
                                txtNote.Clear();

                                RefreshDataGridView();
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




        private void aDDNEWADMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultUsername = "ADMIN@";
            string defaultPassword = "ADMIN@";
            SystemDefaultPasswordAdmin systemDefaultPassword = new SystemDefaultPasswordAdmin();
            systemDefaultPassword.Show();


            if (txtDefaultPassword == defaultPassword)
            {
                New_Admin new_Admin = new New_Admin();
                new_Admin.Show();
            }
            return;


        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            string searchKeyword = txtFind.Text.Trim();

            // Call a method to search the database
            SearchInDatabase(searchKeyword);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        ///..../
        private void ExportToExcel(string filePath)
        {
            try
            {
                // Create Excel package
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Add a worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("User Info");

                    // Fetch data from the database
                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=your_database.accdb;";
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        string selectQuery = "SELECT * FROM [User Info]";
                        using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                // Populate headers
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                }

                                // Populate data
                                int row = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        worksheet.Cells[row, i + 1].Value = reader[i].ToString();
                                    }
                                    row++;
                                }
                            }
                        }
                    }

                    // Save the Excel package
                    package.SaveAs(new System.IO.FileInfo(filePath));
                }

                MessageBox.Show("Data exported to Excel successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aSEXCELSHEETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    // Get the directory where the application is running
                    string currentDirectory = Environment.CurrentDirectory;

                    // Construct the full path for the Excel file
                    string excelFilePath = Path.Combine(currentDirectory, fileName);

                    ExportToExcel(excelFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void lblIDDisplay_Click(object sender, EventArgs e)
        {

        }


        private void PrintDataGridView()
        {
            // Create a PrintDocument
            PrintDocument pd = new PrintDocument();

            // Set the PrintPage event handler
            pd.PrintPage += (sender, e) =>
            {
                // Create a Bitmap to hold the DataGridView
                Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);

                // Draw the DataGridView onto the Bitmap
                dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

                // Calculate the margins
                int marginLeft = e.MarginBounds.Left;
                int marginTop = e.MarginBounds.Top;
                int bmpWidth = bmp.Width;
                int bmpHeight = bmp.Height;

                // Check if the image is wider than the printable area
                if (bmpWidth > e.MarginBounds.Width)
                {
                    // Scale the image to fit the printable area
                    float scale = (float)e.MarginBounds.Width / bmpWidth;
                    bmpWidth = (int)(bmpWidth * scale);
                    bmpHeight = (int)(bmpHeight * scale);
                }

                // Draw the image on the PrintPageEventArgs
                e.Graphics.DrawImage(bmp, marginLeft, marginTop, bmpWidth, bmpHeight);
            };

            // Create a PrintPreviewDialog and set its Document property to the PrintDocument
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = pd;

            // Show the Print Preview Dialog
            printPreviewDialog1.ShowDialog();
        }


        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            PrintDataGridView();


        }

        private void btnData_Click(object sender, EventArgs e)
        {

            tabPage1.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Show();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {



            var result = MessageBox.Show("Are you Sure you Want to clear the Information", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {


                try
                {
                    using (OleDbConnection connection = new OleDbConnection(microsoftAccessDatabaseConnectionString))
                    {
                        string clearQuery = "DELETE FROM [User Info]";
                        string resetAutoIncrementQuery = "ALTER TABLE [User Info] ALTER COLUMN ID COUNTER(1,1)";

                        using (OleDbCommand clearCommand = new OleDbCommand(clearQuery, connection))
                        {
                            connection.Open();
                            clearCommand.ExecuteNonQuery();
                        }

                        using (OleDbCommand resetCommand = new OleDbCommand(resetAutoIncrementQuery, connection))
                        {
                            resetCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data Cleared Successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing data: " + ex.Message);
                }
                finally
                {
                    RefreshDataGridView(); // Always refresh the DataGridView

                    // Since we are using 'using' statement for the connection, it will be automatically closed and disposed
                }
                RefreshDataGridView();
            }
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aBOUTDEVELOPERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (microsoftAccessDatabaseConnection.State != ConnectionState.Open)
                microsoftAccessDatabaseConnection.Open();
            RefreshDataGridView();
            microsoftAccessDatabaseConnection.Close();
        }
    }
}
