using static WinForms.EffectBlur;
using System.Runtime.InteropServices;

namespace WinForms
{
    partial class UserForm
    {

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        private uint _blurOpacity;
        public double BlurOpacity
        {
            get { return _blurOpacity; }
            set { _blurOpacity = (uint)value; EnableBlur(); }
        }

        private uint _blurBackgroundColor = 0x990000;

        internal void EnableBlur()
        {
            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND;
            accent.GradientColor = (_blurOpacity << 24) | (_blurBackgroundColor & 0xFFFFFF);
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);
            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;
            SetWindowCompositionAttribute(this.Handle, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }

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
            //SingleTextView singleTextView2 = new TSkin.ST.SingleTextView();
            //SingleTextView singleTextView3 = new TSkin.ST.SingleTextView();
            //SingleTextView singleTextView4 = new TSkin.ST.SingleTextView();
            //SingleTextView singleTextView5 = new TSkin.ST.SingleTextView();
            //SingleTextView singleTextView6 = new TSkin.ST.SingleTextView();
            //SingleTextView singleTextView7 = new TSkin.ST.SingleTextView();
            roundedProfilePicture = new Winforms.RJButton();
            profilePicturePanel = new Panel();
            bottomMaskProfilePicture = new GradientPanel();
            topMaskProfilePicture = new GradientPanel();
            roundedUsername = new Winforms.RJButton();
            usernameLabel = new Label();
            usernameTextBox = new TSkin.ST.STTextBox();
            firstNameTextBox = new TSkin.ST.STTextBox();
            firstNameLabel = new Label();
            roundedFirstName = new Winforms.RJButton();
            lastNameTextbox = new TSkin.ST.STTextBox();
            lastNameLabel = new Label();
            roundedLastName = new Winforms.RJButton();
            birthDateLabel = new Label();
            roundedBirthDate = new Winforms.RJButton();
            genderLabel = new Label();
            roundedGender = new Winforms.RJButton();
            genderComboBox = new ComboBox();
            genderValue = new Label();
            label1 = new Label();
            birthDatePicker = new DateTimePicker();
            birthDay = new Label();
            locationTextBox = new TSkin.ST.STTextBox();
            locationLabel = new Label();
            roundedLocation = new Winforms.RJButton();
            nationValue = new Label();
            nationComboBox = new ComboBox();
            nationLabel = new Label();
            roundedNation = new Winforms.RJButton();
            userIdLabel = new Label();
            emailTextBox = new TSkin.ST.STTextBox();
            emailLabel = new Label();
            roundedEmail = new Winforms.RJButton();
            phoneTextBox = new TSkin.ST.STTextBox();
            phoneLabel = new Label();
            roundedPhone = new Winforms.RJButton();
            profilePictureLinkTextBox = new TSkin.ST.STTextBox();
            profilePictureLinkLabel = new Label();
            roundedProfilePictureLink = new Winforms.RJButton();
            exitButton = new Winforms.RJButton();
            saveButton = new Winforms.RJButton();
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
            usernameTextBox.Size = new Size(314, 29);
            usernameTextBox.TabIndex = 4;
            usernameTextBox.Visible = false;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.AllowScrollBar = false;
            firstNameTextBox.BackColor = Color.Transparent;
            firstNameTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            firstNameTextBox.ForeColor = SystemColors.ButtonHighlight;
            firstNameTextBox.Location = new Point(394, 141);
            firstNameTextBox.Name = "firstNameTextBox";
            //firstNameTextBox.SetTextView = singleTextView2;
            firstNameTextBox.Size = new Size(140, 29);
            firstNameTextBox.TabIndex = 7;
            firstNameTextBox.Visible = false;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            firstNameLabel.ForeColor = SystemColors.ButtonHighlight;
            firstNameLabel.Location = new Point(336, 102);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(105, 25);
            firstNameLabel.TabIndex = 6;
            firstNameLabel.Text = "First name";
            // 
            // roundedFirstName
            // 
            roundedFirstName.BackColor = Color.Transparent;
            roundedFirstName.BackgroundColor = Color.Transparent;
            roundedFirstName.BorderColor = Color.DeepPink;
            roundedFirstName.BorderRadius = 25;
            roundedFirstName.BorderSize = 2;
            roundedFirstName.FlatAppearance.BorderSize = 0;
            roundedFirstName.FlatStyle = FlatStyle.Flat;
            roundedFirstName.ForeColor = Color.IndianRed;
            roundedFirstName.Location = new Point(336, 130);
            roundedFirstName.Name = "roundedFirstName";
            roundedFirstName.Size = new Size(52, 50);
            roundedFirstName.TabIndex = 5;
            roundedFirstName.Text = "  ❕";
            roundedFirstName.TextAlign = ContentAlignment.MiddleLeft;
            roundedFirstName.TextColor = Color.IndianRed;
            roundedFirstName.UseVisualStyleBackColor = false;
            // 
            // lastNameTextbox
            // 
            lastNameTextbox.AllowScrollBar = false;
            lastNameTextbox.BackColor = Color.Transparent;
            lastNameTextbox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            lastNameTextbox.ForeColor = SystemColors.ButtonHighlight;
            lastNameTextbox.Location = new Point(650, 141);
            lastNameTextbox.Name = "lastNameTextbox";
            //lastNameTextbox.SetTextView = singleTextView3;
            lastNameTextbox.Size = new Size(140, 29);
            lastNameTextbox.TabIndex = 10;
            lastNameTextbox.Visible = false;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            lastNameLabel.ForeColor = SystemColors.ButtonHighlight;
            lastNameLabel.Location = new Point(592, 102);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(101, 25);
            lastNameLabel.TabIndex = 9;
            lastNameLabel.Text = "Last name";
            // 
            // roundedLastName
            // 
            roundedLastName.BackColor = Color.Transparent;
            roundedLastName.BackgroundColor = Color.Transparent;
            roundedLastName.BorderColor = Color.DeepPink;
            roundedLastName.BorderRadius = 25;
            roundedLastName.BorderSize = 2;
            roundedLastName.FlatAppearance.BorderSize = 0;
            roundedLastName.FlatStyle = FlatStyle.Flat;
            roundedLastName.ForeColor = Color.IndianRed;
            roundedLastName.Location = new Point(592, 130);
            roundedLastName.Name = "roundedLastName";
            roundedLastName.Size = new Size(52, 50);
            roundedLastName.TabIndex = 8;
            roundedLastName.Text = "  ❕";
            roundedLastName.TextAlign = ContentAlignment.MiddleLeft;
            roundedLastName.TextColor = Color.IndianRed;
            roundedLastName.UseVisualStyleBackColor = false;
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            birthDateLabel.ForeColor = SystemColors.ButtonHighlight;
            birthDateLabel.Location = new Point(592, 180);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(85, 25);
            birthDateLabel.TabIndex = 15;
            birthDateLabel.Text = "Birthday";
            // 
            // roundedBirthDate
            // 
            roundedBirthDate.BackColor = Color.Transparent;
            roundedBirthDate.BackgroundColor = Color.Transparent;
            roundedBirthDate.BorderColor = Color.DeepPink;
            roundedBirthDate.BorderRadius = 25;
            roundedBirthDate.BorderSize = 2;
            roundedBirthDate.FlatAppearance.BorderSize = 0;
            roundedBirthDate.FlatStyle = FlatStyle.Flat;
            roundedBirthDate.ForeColor = Color.IndianRed;
            roundedBirthDate.Location = new Point(592, 208);
            roundedBirthDate.Name = "roundedBirthDate";
            roundedBirthDate.Size = new Size(52, 50);
            roundedBirthDate.TabIndex = 14;
            roundedBirthDate.Text = "  ❕";
            roundedBirthDate.TextAlign = ContentAlignment.MiddleLeft;
            roundedBirthDate.TextColor = Color.IndianRed;
            roundedBirthDate.UseVisualStyleBackColor = false;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            genderLabel.ForeColor = SystemColors.ButtonHighlight;
            genderLabel.Location = new Point(336, 180);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(74, 25);
            genderLabel.TabIndex = 12;
            genderLabel.Text = "Gender";
            // 
            // roundedGender
            // 
            roundedGender.BackColor = Color.Transparent;
            roundedGender.BackgroundColor = Color.Transparent;
            roundedGender.BorderColor = Color.DeepPink;
            roundedGender.BorderRadius = 25;
            roundedGender.BorderSize = 2;
            roundedGender.FlatAppearance.BorderSize = 0;
            roundedGender.FlatStyle = FlatStyle.Flat;
            roundedGender.ForeColor = Color.IndianRed;
            roundedGender.Location = new Point(336, 208);
            roundedGender.Name = "roundedGender";
            roundedGender.Size = new Size(52, 50);
            roundedGender.TabIndex = 11;
            roundedGender.Text = "  ❕";
            roundedGender.TextAlign = ContentAlignment.MiddleLeft;
            roundedGender.TextColor = Color.IndianRed;
            roundedGender.UseVisualStyleBackColor = false;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Male", "Female", "Other" });
            genderComboBox.Location = new Point(394, 219);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(95, 28);
            genderComboBox.TabIndex = 17;
            genderComboBox.Visible = false;
            // 
            // genderValue
            // 
            genderValue.AutoSize = true;
            genderValue.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            genderValue.ForeColor = SystemColors.ButtonHighlight;
            genderValue.Location = new Point(394, 222);
            genderValue.Name = "genderValue";
            genderValue.Size = new Size(0, 25);
            genderValue.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(643, 295);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 19;
            label1.Text = "label1";
            // 
            // birthDatePicker
            // 
            birthDatePicker.Format = DateTimePickerFormat.Short;
            birthDatePicker.Location = new Point(650, 217);
            birthDatePicker.MaxDate = new DateTime(2020, 2, 25, 0, 0, 0, 0);
            birthDatePicker.MinDate = new DateTime(1800, 2, 25, 0, 0, 0, 0);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.RightToLeft = RightToLeft.No;
            birthDatePicker.Size = new Size(122, 27);
            birthDatePicker.TabIndex = 20;
            birthDatePicker.Value = new DateTime(2020, 2, 25, 0, 0, 0, 0);
            birthDatePicker.Visible = false;
            // 
            // birthDay
            // 
            birthDay.AutoSize = true;
            birthDay.BackColor = Color.Transparent;
            birthDay.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            birthDay.ForeColor = SystemColors.ButtonHighlight;
            birthDay.Location = new Point(650, 217);
            birthDay.Name = "birthDay";
            birthDay.Size = new Size(0, 25);
            birthDay.TabIndex = 21;
            // 
            // locationTextBox
            // 
            locationTextBox.AllowScrollBar = false;
            locationTextBox.BackColor = Color.Transparent;
            locationTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            locationTextBox.ForeColor = SystemColors.ButtonHighlight;
            locationTextBox.Location = new Point(650, 306);
            locationTextBox.Name = "locationTextBox";
            //locationTextBox.SetTextView = singleTextView4;
            locationTextBox.Size = new Size(157, 29);
            locationTextBox.TabIndex = 24;
            locationTextBox.Visible = false;
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            locationLabel.ForeColor = SystemColors.ButtonHighlight;
            locationLabel.Location = new Point(592, 267);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(84, 25);
            locationLabel.TabIndex = 23;
            locationLabel.Text = "Location";
            // 
            // roundedLocation
            // 
            roundedLocation.BackColor = Color.Transparent;
            roundedLocation.BackgroundColor = Color.Transparent;
            roundedLocation.BorderColor = Color.DeepPink;
            roundedLocation.BorderRadius = 25;
            roundedLocation.BorderSize = 2;
            roundedLocation.FlatAppearance.BorderSize = 0;
            roundedLocation.FlatStyle = FlatStyle.Flat;
            roundedLocation.ForeColor = Color.IndianRed;
            roundedLocation.Location = new Point(592, 295);
            roundedLocation.Name = "roundedLocation";
            roundedLocation.Size = new Size(52, 50);
            roundedLocation.TabIndex = 22;
            roundedLocation.Text = "  ❕";
            roundedLocation.TextAlign = ContentAlignment.MiddleLeft;
            roundedLocation.TextColor = Color.IndianRed;
            roundedLocation.UseVisualStyleBackColor = false;
            // 
            // nationValue
            // 
            nationValue.AutoSize = true;
            nationValue.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            nationValue.ForeColor = SystemColors.ButtonHighlight;
            nationValue.Location = new Point(394, 305);
            nationValue.Name = "nationValue";
            nationValue.Size = new Size(0, 25);
            nationValue.TabIndex = 28;
            // 
            // nationComboBox
            // 
            nationComboBox.FormattingEnabled = true;
            nationComboBox.Items.AddRange(new object[] { "Male", "Female", "Other" });
            nationComboBox.Location = new Point(400, 307);
            nationComboBox.Name = "nationComboBox";
            nationComboBox.Size = new Size(134, 28);
            nationComboBox.TabIndex = 27;
            nationComboBox.Visible = false;
            // 
            // nationLabel
            // 
            nationLabel.AutoSize = true;
            nationLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            nationLabel.ForeColor = SystemColors.ButtonHighlight;
            nationLabel.Location = new Point(336, 267);
            nationLabel.Name = "nationLabel";
            nationLabel.Size = new Size(68, 25);
            nationLabel.TabIndex = 26;
            nationLabel.Text = "Nation";
            // 
            // roundedNation
            // 
            roundedNation.BackColor = Color.Transparent;
            roundedNation.BackgroundColor = Color.Transparent;
            roundedNation.BorderColor = Color.DeepPink;
            roundedNation.BorderRadius = 25;
            roundedNation.BorderSize = 2;
            roundedNation.FlatAppearance.BorderSize = 0;
            roundedNation.FlatStyle = FlatStyle.Flat;
            roundedNation.ForeColor = Color.IndianRed;
            roundedNation.Location = new Point(336, 295);
            roundedNation.Name = "roundedNation";
            roundedNation.Size = new Size(52, 50);
            roundedNation.TabIndex = 25;
            roundedNation.Text = "  ❕";
            roundedNation.TextAlign = ContentAlignment.MiddleLeft;
            roundedNation.TextColor = Color.IndianRed;
            roundedNation.UseVisualStyleBackColor = false;
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            userIdLabel.ForeColor = SystemColors.ButtonHighlight;
            userIdLabel.Location = new Point(92, 306);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new Size(121, 25);
            userIdLabel.TabIndex = 29;
            userIdLabel.Text = "User ID; ###";
            // 
            // emailTextBox
            // 
            emailTextBox.AllowScrollBar = false;
            emailTextBox.BackColor = Color.Transparent;
            emailTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            emailTextBox.ForeColor = SystemColors.ButtonHighlight;
            emailTextBox.Location = new Point(394, 384);
            emailTextBox.Name = "emailTextBox";
            //emailTextBox.SetTextView = singleTextView5;
            emailTextBox.Size = new Size(378, 29);
            emailTextBox.TabIndex = 32;
            emailTextBox.Visible = false;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.ButtonHighlight;
            emailLabel.Location = new Point(336, 345);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(61, 25);
            emailLabel.TabIndex = 31;
            emailLabel.Text = "Email";
            // 
            // roundedEmail
            // 
            roundedEmail.BackColor = Color.Transparent;
            roundedEmail.BackgroundColor = Color.Transparent;
            roundedEmail.BorderColor = Color.DeepPink;
            roundedEmail.BorderRadius = 25;
            roundedEmail.BorderSize = 2;
            roundedEmail.FlatAppearance.BorderSize = 0;
            roundedEmail.FlatStyle = FlatStyle.Flat;
            roundedEmail.ForeColor = Color.IndianRed;
            roundedEmail.Location = new Point(336, 373);
            roundedEmail.Name = "roundedEmail";
            roundedEmail.Size = new Size(52, 50);
            roundedEmail.TabIndex = 30;
            roundedEmail.Text = "  ❕";
            roundedEmail.TextAlign = ContentAlignment.MiddleLeft;
            roundedEmail.TextColor = Color.IndianRed;
            roundedEmail.UseVisualStyleBackColor = false;
            // 
            // phoneTextBox
            // 
            phoneTextBox.AllowScrollBar = false;
            phoneTextBox.BackColor = Color.Transparent;
            phoneTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            phoneTextBox.ForeColor = SystemColors.ButtonHighlight;
            phoneTextBox.Location = new Point(83, 384);
            phoneTextBox.Name = "phoneTextBox";
            //phoneTextBox.SetTextView = singleTextView6;
            phoneTextBox.Size = new Size(215, 29);
            phoneTextBox.TabIndex = 35;
            phoneTextBox.Visible = false;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            phoneLabel.ForeColor = SystemColors.ButtonHighlight;
            phoneLabel.Location = new Point(25, 345);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(65, 25);
            phoneLabel.TabIndex = 34;
            phoneLabel.Text = "Phone";
            // 
            // roundedPhone
            // 
            roundedPhone.BackColor = Color.Transparent;
            roundedPhone.BackgroundColor = Color.Transparent;
            roundedPhone.BorderColor = Color.DeepPink;
            roundedPhone.BorderRadius = 25;
            roundedPhone.BorderSize = 2;
            roundedPhone.FlatAppearance.BorderSize = 0;
            roundedPhone.FlatStyle = FlatStyle.Flat;
            roundedPhone.ForeColor = Color.IndianRed;
            roundedPhone.Location = new Point(25, 373);
            roundedPhone.Name = "roundedPhone";
            roundedPhone.Size = new Size(52, 50);
            roundedPhone.TabIndex = 33;
            roundedPhone.Text = "  ❕";
            roundedPhone.TextAlign = ContentAlignment.MiddleLeft;
            roundedPhone.TextColor = Color.IndianRed;
            roundedPhone.UseVisualStyleBackColor = false;
            // 
            // profilePictureLinkTextBox
            // 
            profilePictureLinkTextBox.AllowScrollBar = false;
            profilePictureLinkTextBox.BackColor = Color.Transparent;
            profilePictureLinkTextBox.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            profilePictureLinkTextBox.ForeColor = SystemColors.ButtonHighlight;
            profilePictureLinkTextBox.Location = new Point(83, 476);
            profilePictureLinkTextBox.Name = "profilePictureLinkTextBox";
            //profilePictureLinkTextBox.SetTextView = singleTextView7;
            profilePictureLinkTextBox.Size = new Size(378, 29);
            profilePictureLinkTextBox.TabIndex = 38;
            profilePictureLinkTextBox.Visible = false;
            // 
            // profilePictureLinkLabel
            // 
            profilePictureLinkLabel.AutoSize = true;
            profilePictureLinkLabel.Font = new Font("Exo ExtraBold", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            profilePictureLinkLabel.ForeColor = SystemColors.ButtonHighlight;
            profilePictureLinkLabel.Location = new Point(25, 437);
            profilePictureLinkLabel.Name = "profilePictureLinkLabel";
            profilePictureLinkLabel.Size = new Size(61, 25);
            profilePictureLinkLabel.TabIndex = 37;
            profilePictureLinkLabel.Text = "Email";
            // 
            // roundedProfilePictureLink
            // 
            roundedProfilePictureLink.BackColor = Color.Transparent;
            roundedProfilePictureLink.BackgroundColor = Color.Transparent;
            roundedProfilePictureLink.BorderColor = Color.DeepPink;
            roundedProfilePictureLink.BorderRadius = 25;
            roundedProfilePictureLink.BorderSize = 2;
            roundedProfilePictureLink.FlatAppearance.BorderSize = 0;
            roundedProfilePictureLink.FlatStyle = FlatStyle.Flat;
            roundedProfilePictureLink.ForeColor = Color.IndianRed;
            roundedProfilePictureLink.Location = new Point(25, 465);
            roundedProfilePictureLink.Name = "roundedProfilePictureLink";
            roundedProfilePictureLink.Size = new Size(52, 50);
            roundedProfilePictureLink.TabIndex = 36;
            roundedProfilePictureLink.Text = "  ❕";
            roundedProfilePictureLink.TextAlign = ContentAlignment.MiddleLeft;
            roundedProfilePictureLink.TextColor = Color.IndianRed;
            roundedProfilePictureLink.UseVisualStyleBackColor = false;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.LavenderBlush;
            exitButton.BackgroundColor = Color.LavenderBlush;
            exitButton.BorderColor = Color.PaleVioletRed;
            exitButton.BorderRadius = 20;
            exitButton.BorderSize = 0;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            exitButton.ForeColor = Color.IndianRed;
            exitButton.Location = new Point(772, 487);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(83, 42);
            exitButton.TabIndex = 39;
            exitButton.Text = "Exit";
            exitButton.TextColor = Color.IndianRed;
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.Honeydew;
            saveButton.BackgroundColor = Color.Honeydew;
            saveButton.BorderColor = Color.PaleVioletRed;
            saveButton.BorderRadius = 20;
            saveButton.BorderSize = 0;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.ForeColor = Color.SpringGreen;
            saveButton.Location = new Point(690, 487);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(82, 42);
            saveButton.TabIndex = 40;
            saveButton.Text = "Save";
            saveButton.TextColor = Color.SpringGreen;
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Visible = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(867, 541);
            Controls.Add(saveButton);
            Controls.Add(exitButton);
            Controls.Add(profilePictureLinkTextBox);
            Controls.Add(profilePictureLinkLabel);
            Controls.Add(roundedProfilePictureLink);
            Controls.Add(phoneTextBox);
            Controls.Add(phoneLabel);
            Controls.Add(roundedPhone);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(roundedEmail);
            Controls.Add(userIdLabel);
            Controls.Add(nationValue);
            Controls.Add(nationComboBox);
            Controls.Add(nationLabel);
            Controls.Add(roundedNation);
            Controls.Add(locationTextBox);
            Controls.Add(locationLabel);
            Controls.Add(roundedLocation);
            Controls.Add(birthDay);
            Controls.Add(birthDatePicker);
            Controls.Add(label1);
            Controls.Add(genderValue);
            Controls.Add(genderComboBox);
            Controls.Add(birthDateLabel);
            Controls.Add(roundedBirthDate);
            Controls.Add(genderLabel);
            Controls.Add(roundedGender);
            Controls.Add(lastNameTextbox);
            Controls.Add(lastNameLabel);
            Controls.Add(roundedLastName);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(roundedFirstName);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(roundedUsername);
            Controls.Add(profilePicturePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserForm";
            Load += UserForm_LoadAsync;
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
        private TSkin.ST.STTextBox firstNameTextBox;
        private Label firstNameLabel;
        private Winforms.RJButton roundedFirstName;
        private TSkin.ST.STTextBox lastNameTextbox;
        private Label lastNameLabel;
        private Winforms.RJButton roundedLastName;
        private Label birthDateLabel;
        private Winforms.RJButton roundedBirthDate;
        private Label genderLabel;
        private Winforms.RJButton roundedGender;
        private ComboBox genderComboBox;
        private Label genderValue;
        private Label label1;
        private DateTimePicker birthDatePicker;
        private Label birthDay;
        private TSkin.ST.STTextBox locationTextBox;
        private Label locationLabel;
        private Label nationValue;
        private Winforms.RJButton roundedLocation;
        private Label label3;
        private ComboBox nationComboBox;
        private Label nationLabel;
        private Winforms.RJButton roundedNation;
        private Label userIdLabel;
        private TSkin.ST.STTextBox emailTextBox;
        private Label emailLabel;
        private Winforms.RJButton roundedEmail;
        private TSkin.ST.STTextBox phoneTextBox;
        private Label phoneLabel;
        private Winforms.RJButton roundedPhone;
        private TSkin.ST.STTextBox profilePictureLinkTextBox;
        private Label profilePictureLinkLabel;
        private Winforms.RJButton roundedProfilePictureLink;
        private Winforms.RJButton exitButton;
        private Winforms.RJButton saveButton;
    }
}