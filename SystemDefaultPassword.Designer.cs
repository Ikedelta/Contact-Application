namespace Contact_Application
{
    partial class SystemDefaultPasswordAdmin
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemDefaultPasswordAdmin));
            btnVerify = new Button();
            txtDefaultPassword = new TextBox();
            toolTip1 = new ToolTip(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnVerify
            // 
            btnVerify.Anchor = AnchorStyles.None;
            btnVerify.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.Blue;
            btnVerify.Location = new Point(137, 122);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(224, 50);
            btnVerify.TabIndex = 0;
            btnVerify.Text = "VERIFY";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // txtDefaultPassword
            // 
            txtDefaultPassword.Anchor = AnchorStyles.None;
            txtDefaultPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDefaultPassword.ForeColor = Color.FromArgb(0, 0, 64);
            txtDefaultPassword.Location = new Point(104, 53);
            txtDefaultPassword.Multiline = true;
            txtDefaultPassword.Name = "txtDefaultPassword";
            txtDefaultPassword.Size = new Size(286, 54);
            txtDefaultPassword.TabIndex = 1;
            txtDefaultPassword.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(txtDefaultPassword, "Enter System Default Password to Add New Admin");
            txtDefaultPassword.TextChanged += txtDefaultPassword_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.Key;
            pictureBox2.Location = new Point(115, 62);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // SystemDefaultPasswordAdmin
            // 
            AcceptButton = btnVerify;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(489, 196);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(txtDefaultPassword);
            Controls.Add(btnVerify);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SystemDefaultPasswordAdmin";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SystemDefaultPassword Admin";
            TransparencyKey = Color.FromArgb(255, 224, 192);
            Load += SystemDefaultPasswordAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVerify;
        private TextBox txtDefaultPassword;
        private ToolTip toolTip1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}