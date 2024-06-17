namespace Contact_Application
{
    partial class New_Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Admin));
            label1 = new Label();
            txtAdminFirstname = new TextBox();
            txtAdminLastname = new TextBox();
            txtAdminPassword = new TextBox();
            lblGenerated = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(397, 39);
            label1.Name = "label1";
            label1.Size = new Size(238, 33);
            label1.TabIndex = 0;
            label1.Text = "ADD NEW ADMIN";
            // 
            // txtAdminFirstname
            // 
            txtAdminFirstname.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminFirstname.ForeColor = Color.Blue;
            txtAdminFirstname.Location = new Point(312, 98);
            txtAdminFirstname.Multiline = true;
            txtAdminFirstname.Name = "txtAdminFirstname";
            txtAdminFirstname.PlaceholderText = "Enter First Name";
            txtAdminFirstname.Size = new Size(343, 42);
            txtAdminFirstname.TabIndex = 1;
            // 
            // txtAdminLastname
            // 
            txtAdminLastname.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminLastname.ForeColor = Color.Blue;
            txtAdminLastname.Location = new Point(312, 157);
            txtAdminLastname.Margin = new Padding(5, 3, 3, 10);
            txtAdminLastname.Multiline = true;
            txtAdminLastname.Name = "txtAdminLastname";
            txtAdminLastname.PlaceholderText = "Enter Last Name";
            txtAdminLastname.Size = new Size(343, 42);
            txtAdminLastname.TabIndex = 2;
            // 
            // txtAdminPassword
            // 
            txtAdminPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminPassword.ForeColor = Color.Blue;
            txtAdminPassword.Location = new Point(312, 212);
            txtAdminPassword.Multiline = true;
            txtAdminPassword.Name = "txtAdminPassword";
            txtAdminPassword.PlaceholderText = "Enter Password";
            txtAdminPassword.Size = new Size(343, 42);
            txtAdminPassword.TabIndex = 3;
            // 
            // lblGenerated
            // 
            lblGenerated.BackColor = Color.Lavender;
            lblGenerated.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGenerated.ForeColor = Color.FromArgb(0, 0, 64);
            lblGenerated.Location = new Point(312, 292);
            lblGenerated.Name = "lblGenerated";
            lblGenerated.Size = new Size(343, 46);
            lblGenerated.TabIndex = 4;
            lblGenerated.TextAlign = ContentAlignment.MiddleCenter;
            lblGenerated.Click += label2_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Lavender;
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(219, 450);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 192, 255);
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Blue;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(216, 52);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Blue;
            button2.Location = new Point(298, 360);
            button2.Name = "button2";
            button2.Size = new Size(176, 51);
            button2.TabIndex = 6;
            button2.Text = "GENERATE USERNAME";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Blue;
            button3.Location = new Point(491, 360);
            button3.Name = "button3";
            button3.Size = new Size(176, 51);
            button3.TabIndex = 6;
            button3.Text = "ADD ADMIN";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(316, 267);
            label2.Name = "label2";
            label2.Size = new Size(176, 17);
            label2.TabIndex = 7;
            label2.Text = "Username is Auto Generated";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(339, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // New_Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblGenerated);
            Controls.Add(txtAdminPassword);
            Controls.Add(txtAdminLastname);
            Controls.Add(txtAdminFirstname);
            Controls.Add(label1);
            Name = "New_Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New_Admin";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAdminFirstname;
        private TextBox txtAdminLastname;
        private TextBox txtAdminPassword;
        private Label lblGenerated;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private PictureBox pictureBox1;
    }
}