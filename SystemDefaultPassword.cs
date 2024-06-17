using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Application
{
    public partial class SystemDefaultPasswordAdmin : Form
    {
        string defaultUsername = "ADMIN@";
        string defaultPassword = "ADMIN@";

        public SystemDefaultPasswordAdmin()
        {
            InitializeComponent();
        }

        private void txtDefaultPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultPassword.Text))
            {
                MessageBox.Show("Enter System Default Password");
                return;
            }
            if (txtDefaultPassword.Text == defaultPassword)
            {
                this.Close();

            }
            else
            {
                MessageBox.Show("Incorrect System Default Password...");
                return;
            }
            New_Admin new_Admin = new New_Admin();
            new_Admin.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void SystemDefaultPasswordAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
