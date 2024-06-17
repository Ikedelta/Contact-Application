namespace Contact_Application
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            label3 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            txtEditLastName = new TextBox();
            txtEditFirstName = new TextBox();
            txtEditAddress = new TextBox();
            txtEditContact = new TextBox();
            txtEditOtherContact = new TextBox();
            txtEditEmailAddress = new TextBox();
            txtEditOtherEmail = new TextBox();
            txtEditOccupation = new TextBox();
            cmbEditGender = new ComboBox();
            button1 = new Button();
            picEditProfile = new PictureBox();
            picEditIcon = new PictureBox();
            button2 = new Button();
            txtEditNote = new TextBox();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEditProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEditIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(445, 41);
            label3.Name = "label3";
            label3.Size = new Size(191, 33);
            label3.TabIndex = 2;
            label3.Text = "EDIT RECORD";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 450);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.Blue;
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(197, 57);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(380, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // txtEditLastName
            // 
            txtEditLastName.Anchor = AnchorStyles.None;
            txtEditLastName.Location = new Point(220, 123);
            txtEditLastName.Multiline = true;
            txtEditLastName.Name = "txtEditLastName";
            txtEditLastName.PlaceholderText = "Last Name";
            txtEditLastName.Size = new Size(188, 34);
            txtEditLastName.TabIndex = 1;
            // 
            // txtEditFirstName
            // 
            txtEditFirstName.Anchor = AnchorStyles.None;
            txtEditFirstName.Location = new Point(220, 174);
            txtEditFirstName.Multiline = true;
            txtEditFirstName.Name = "txtEditFirstName";
            txtEditFirstName.PlaceholderText = "First Name";
            txtEditFirstName.Size = new Size(188, 34);
            txtEditFirstName.TabIndex = 2;
            // 
            // txtEditAddress
            // 
            txtEditAddress.Anchor = AnchorStyles.None;
            txtEditAddress.Location = new Point(220, 223);
            txtEditAddress.Multiline = true;
            txtEditAddress.Name = "txtEditAddress";
            txtEditAddress.PlaceholderText = "Address";
            txtEditAddress.Size = new Size(188, 34);
            txtEditAddress.TabIndex = 3;
            // 
            // txtEditContact
            // 
            txtEditContact.Anchor = AnchorStyles.None;
            txtEditContact.Location = new Point(220, 263);
            txtEditContact.Multiline = true;
            txtEditContact.Name = "txtEditContact";
            txtEditContact.PlaceholderText = "Contact";
            txtEditContact.Size = new Size(188, 34);
            txtEditContact.TabIndex = 4;
            // 
            // txtEditOtherContact
            // 
            txtEditOtherContact.Anchor = AnchorStyles.None;
            txtEditOtherContact.Location = new Point(220, 303);
            txtEditOtherContact.Multiline = true;
            txtEditOtherContact.Name = "txtEditOtherContact";
            txtEditOtherContact.PlaceholderText = "Other Contact";
            txtEditOtherContact.Size = new Size(188, 34);
            txtEditOtherContact.TabIndex = 5;
            // 
            // txtEditEmailAddress
            // 
            txtEditEmailAddress.Anchor = AnchorStyles.None;
            txtEditEmailAddress.Location = new Point(436, 123);
            txtEditEmailAddress.Multiline = true;
            txtEditEmailAddress.Name = "txtEditEmailAddress";
            txtEditEmailAddress.PlaceholderText = "Email Address";
            txtEditEmailAddress.Size = new Size(188, 34);
            txtEditEmailAddress.TabIndex = 6;
            // 
            // txtEditOtherEmail
            // 
            txtEditOtherEmail.Anchor = AnchorStyles.None;
            txtEditOtherEmail.Location = new Point(436, 174);
            txtEditOtherEmail.Multiline = true;
            txtEditOtherEmail.Name = "txtEditOtherEmail";
            txtEditOtherEmail.PlaceholderText = "Oher Email";
            txtEditOtherEmail.Size = new Size(188, 34);
            txtEditOtherEmail.TabIndex = 7;
            // 
            // txtEditOccupation
            // 
            txtEditOccupation.Anchor = AnchorStyles.None;
            txtEditOccupation.Location = new Point(436, 263);
            txtEditOccupation.Multiline = true;
            txtEditOccupation.Name = "txtEditOccupation";
            txtEditOccupation.PlaceholderText = "Occupation";
            txtEditOccupation.Size = new Size(188, 34);
            txtEditOccupation.TabIndex = 9;
            // 
            // cmbEditGender
            // 
            cmbEditGender.Anchor = AnchorStyles.None;
            cmbEditGender.FormattingEnabled = true;
            cmbEditGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbEditGender.Location = new Point(436, 228);
            cmbEditGender.Name = "cmbEditGender";
            cmbEditGender.Size = new Size(188, 23);
            cmbEditGender.TabIndex = 8;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Blue;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Montserrat", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(220, 385);
            button1.Name = "button1";
            button1.Size = new Size(188, 53);
            button1.TabIndex = 12;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // picEditProfile
            // 
            picEditProfile.Anchor = AnchorStyles.None;
            picEditProfile.BackColor = Color.White;
            picEditProfile.Location = new Point(654, 123);
            picEditProfile.Name = "picEditProfile";
            picEditProfile.Size = new Size(134, 174);
            picEditProfile.SizeMode = PictureBoxSizeMode.Zoom;
            picEditProfile.TabIndex = 8;
            picEditProfile.TabStop = false;
            // 
            // picEditIcon
            // 
            picEditIcon.Anchor = AnchorStyles.None;
            picEditIcon.BackColor = Color.White;
            picEditIcon.Image = Properties.Resources.Image;
            picEditIcon.Location = new Point(698, 189);
            picEditIcon.Name = "picEditIcon";
            picEditIcon.Size = new Size(57, 50);
            picEditIcon.TabIndex = 9;
            picEditIcon.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Blue;
            button2.Location = new Point(654, 303);
            button2.Name = "button2";
            button2.Size = new Size(134, 52);
            button2.TabIndex = 11;
            button2.Text = "Update Image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtEditNote
            // 
            txtEditNote.Location = new Point(437, 307);
            txtEditNote.Multiline = true;
            txtEditNote.Name = "txtEditNote";
            txtEditNote.PlaceholderText = "Note";
            txtEditNote.Size = new Size(187, 63);
            txtEditNote.TabIndex = 10;
            // 
            // button3
            // 
            button3.BackColor = Color.Crimson;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(445, 385);
            button3.Name = "button3";
            button3.Size = new Size(168, 53);
            button3.TabIndex = 13;
            button3.Text = "      Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Crimson;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.__Trash;
            pictureBox2.Location = new Point(475, 397);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Blue;
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(247, 399);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(29, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button3);
            Controls.Add(txtEditNote);
            Controls.Add(button2);
            Controls.Add(picEditIcon);
            Controls.Add(picEditProfile);
            Controls.Add(button1);
            Controls.Add(cmbEditGender);
            Controls.Add(txtEditOccupation);
            Controls.Add(txtEditOtherEmail);
            Controls.Add(txtEditEmailAddress);
            Controls.Add(txtEditOtherContact);
            Controls.Add(txtEditContact);
            Controls.Add(txtEditAddress);
            Controls.Add(txtEditFirstName);
            Controls.Add(txtEditLastName);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditForm";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEditProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEditIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private TextBox txtEditLastName;
        private TextBox txtEditFirstName;
        private TextBox txtEditAddress;
        private TextBox txtEditContact;
        private TextBox txtEditOtherContact;
        private TextBox txtEditEmailAddress;
        private TextBox txtEditOtherEmail;
        private TextBox textBox6;
        private TextBox txtEditOccupation;
        private ComboBox cmbEditGender;
        private Button button1;
        private PictureBox picEditProfile;
        private PictureBox picEditIcon;
        private Button button2;
        private Button btnBack;
        private TextBox txtEditNote;
        private Button button3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}