namespace WinForms
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            //SingleTextView singleTextView1 = new TSkin.ST.SingleTextView();
            roundedProfilePicture = new Winforms.RJButton();
            profilePicturePanel = new Panel();
            bottomMaskProfilePicture = new GradientPanel();
            topMaskProfilePicture = new GradientPanel();
            roundedUsername = new Winforms.RJButton();
            usernameLabel = new Label();
            usernameTextBox = new TSkin.ST.STTextBox();
            profilePicturePanel.SuspendLayout();
            SuspendLayout();
            // 
            // roundedProfilePicture
            // 
            roundedProfilePicture.BackColor = Color.Black;
            roundedProfilePicture.BackgroundColor = Color.Black;
            roundedProfilePicture.BackgroundImage = (Image)resources.GetObject("roundedProfilePicture.BackgroundImage");
            roundedProfilePicture.BackgroundImageLayout = ImageLayout.Stretch;
            roundedProfilePicture.BorderColor = Color.PaleVioletRed;
            roundedProfilePicture.BorderRadius = 135;
            roundedProfilePicture.BorderSize = 0;
            roundedProfilePicture.FlatAppearance.BorderSize = 0;
            roundedProfilePicture.FlatStyle = FlatStyle.Flat;
            roundedProfilePicture.ForeColor = Color.Gray;
            roundedProfilePicture.Location = new Point(0, 0);
            roundedProfilePicture.Margin = new Padding(0);
            roundedProfilePicture.Name = "roundedProfilePicture";
            roundedProfilePicture.Size = new Size(260, 260);
            roundedProfilePicture.TabIndex = 0;
            roundedProfilePicture.TextColor = Color.Gray;
            roundedProfilePicture.UseVisualStyleBackColor = false;
            roundedProfilePicture.Click += rjButton1_Click;
            // 
            // profilePicturePanel
            // 
            profilePicturePanel.BackgroundImage = (Image)resources.GetObject("profilePicturePanel.BackgroundImage");
            profilePicturePanel.BackgroundImageLayout = ImageLayout.Stretch;
            profilePicturePanel.Controls.Add(roundedProfilePicture);
            profilePicturePanel.Controls.Add(bottomMaskProfilePicture);
            profilePicturePanel.Controls.Add(topMaskProfilePicture);
            profilePicturePanel.Location = new Point(25, 24);
            profilePicturePanel.Margin = new Padding(0);
            profilePicturePanel.Name = "profilePicturePanel";
            profilePicturePanel.Size = new Size(260, 260);
            profilePicturePanel.TabIndex = 1;
            // 
            // bottomMaskProfilePicture
            // 
            bottomMaskProfilePicture.BackColor = Color.Transparent;
            bottomMaskProfilePicture.BackgroundImageLayout = ImageLayout.Center;
            bottomMaskProfilePicture.Dock = DockStyle.Bottom;
            bottomMaskProfilePicture.GradientAngle = 270F;
            bottomMaskProfilePicture.GradientPrimaryColor = Color.DimGray;
            bottomMaskProfilePicture.GradientSecondaryColor = Color.Transparent;
            bottomMaskProfilePicture.Location = new Point(0, 159);
            bottomMaskProfilePicture.Name = "bottomMaskProfilePicture";
            bottomMaskProfilePicture.Size = new Size(260, 101);
            bottomMaskProfilePicture.TabIndex = 1;
            // 
            // topMaskProfilePicture
            // 
            topMaskProfilePicture.BackColor = Color.Transparent;
            topMaskProfilePicture.BackgroundImageLayout = ImageLayout.Stretch;
            topMaskProfilePicture.Dock = DockStyle.Top;
            topMaskProfilePicture.GradientAngle = 90F;
            topMaskProfilePicture.GradientPrimaryColor = Color.DimGray;
            topMaskProfilePicture.GradientSecondaryColor = Color.Transparent;
            topMaskProfilePicture.Location = new Point(0, 0);
            topMaskProfilePicture.Name = "topMaskProfilePicture";
            topMaskProfilePicture.Size = new Size(260, 93);
            topMaskProfilePicture.TabIndex = 0;
            // 
            // roundedUsername
            // 
            roundedUsername.BackColor = Color.Transparent;
            roundedUsername.BackgroundColor = Color.Transparent;
            roundedUsername.BorderColor = Color.DeepPink;
            roundedUsername.BorderRadius = 25;
            roundedUsername.BorderSize = 2;
            roundedUsername.FlatAppearance.BorderSize = 0;
            roundedUsername.FlatStyle = FlatStyle.Flat;
            roundedUsername.ForeColor = Color.IndianRed;
            roundedUsername.Location = new Point(336, 52);
            roundedUsername.Name = "roundedUsername";
            roundedUsername.Size = new Size(52, 50);
            roundedUsername.TabIndex = 2;
            roundedUsername.Text = "  ❕";
            roundedUsername.TextAlign = ContentAlignment.MiddleLeft;
            roundedUsername.TextColor = Color.IndianRed;
            roundedUsername.UseVisualStyleBackColor = false;
            roundedUsername.Click += roundedUsername_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            usernameLabel.ForeColor = SystemColors.ButtonHighlight;
            usernameLabel.Location = new Point(336, 24);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(99, 25);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            usernameTextBox.AllowScrollBar = false;
            usernameTextBox.BackColor = Color.Transparent;
            usernameTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            usernameTextBox.ForeColor = SystemColors.ButtonHighlight;
            usernameTextBox.Location = new Point(394, 63);
            usernameTextBox.Name = "usernameTextBox";
           //usernameTextBox.SetTextView = singleTextView1;
            usernameTextBox.Size = new Size(254, 29);
            usernameTextBox.TabIndex = 4;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(867, 575);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(roundedUsername);
            Controls.Add(profilePicturePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            profilePicturePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Winforms.RJButton roundedProfilePicture;
        private Panel profilePicturePanel;
        private GradientPanel topMaskProfilePicture;
        private GradientPanel bottomMaskProfilePicture;
        private Winforms.RJButton roundedUsername;
        private Label usernameLabel;
        private TSkin.ST.STTextBox usernameTextBox;
    }
}