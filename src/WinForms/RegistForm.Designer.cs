namespace WinForms
{
    partial class RegistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            minimize = new Label();
            maximize = new Label();
            Close = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            welcome = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            signIn = new Label();
            mainBody = new FlowLayoutPanel();
            usernamePanel = new FlowLayoutPanel();
            usernameLabel = new Label();
            username = new TextBox();
            usernameNotification = new FlowLayoutPanel();
            lastnamePanel = new FlowLayoutPanel();
            lastNameLabel = new Label();
            lastName = new TextBox();
            lastnameNotification = new FlowLayoutPanel();
            firstNamePanel = new FlowLayoutPanel();
            firstNameLabel = new Label();
            firstName = new TextBox();
            firstnameNotification = new FlowLayoutPanel();
            emailPanel = new FlowLayoutPanel();
            emailLabel = new Label();
            email = new TextBox();
            emailNotification = new FlowLayoutPanel();
            phonePanel = new FlowLayoutPanel();
            label1 = new Label();
            phone = new TextBox();
            phoneNotification = new FlowLayoutPanel();
            locationPanel = new FlowLayoutPanel();
            locationLabel = new Label();
            location = new TextBox();
            locationNotification = new FlowLayoutPanel();
            nationPanel = new FlowLayoutPanel();
            nationLabel = new Label();
            nation = new ComboBox();
            nationNotification = new FlowLayoutPanel();
            birthDatePanel = new FlowLayoutPanel();
            birthdateLabel = new Label();
            birthDate = new DateTimePicker();
            birthdateNotification = new FlowLayoutPanel();
            imageUrlPanel = new FlowLayoutPanel();
            imgUrlLabel = new Label();
            imgUrl = new TextBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            genderPanel = new FlowLayoutPanel();
            genderLabel = new Label();
            gender = new ComboBox();
            genderNotification = new FlowLayoutPanel();
            passwordPanel = new FlowLayoutPanel();
            passwordLabel = new Label();
            password = new TextBox();
            passwordNotification = new FlowLayoutPanel();
            confirmPanel = new FlowLayoutPanel();
            confirmLabel = new Label();
            confirm = new TextBox();
            confirmNotification = new FlowLayoutPanel();
            donePanel = new Panel();
            login = new Label();
            done = new Label();
            doneIco = new Label();
            panel1 = new Panel();
            label2 = new Label();
            step = new Label();
            first = new Label();
            finish = new Label();
            previous = new Label();
            topBar = new Panel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            mainBody.SuspendLayout();
            usernamePanel.SuspendLayout();
            lastnamePanel.SuspendLayout();
            firstNamePanel.SuspendLayout();
            emailPanel.SuspendLayout();
            phonePanel.SuspendLayout();
            locationPanel.SuspendLayout();
            nationPanel.SuspendLayout();
            birthDatePanel.SuspendLayout();
            imageUrlPanel.SuspendLayout();
            genderPanel.SuspendLayout();
            passwordPanel.SuspendLayout();
            confirmPanel.SuspendLayout();
            donePanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(previous, 0, 0);
            tableLayoutPanel1.Controls.Add(topBar, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
            tableLayoutPanel1.Size = new Size(1022, 491);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(minimize);
            flowLayoutPanel1.Controls.Add(maximize);
            flowLayoutPanel1.Controls.Add(Close);
            flowLayoutPanel1.Location = new Point(943, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(76, 21);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // minimize
            // 
            minimize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            minimize.Cursor = Cursors.Hand;
            minimize.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point);
            minimize.ForeColor = SystemColors.ButtonHighlight;
            minimize.Location = new Point(3, 0);
            minimize.Name = "minimize";
            minimize.Size = new Size(19, 20);
            minimize.TabIndex = 3;
            minimize.Text = "➖";
            minimize.TextAlign = ContentAlignment.BottomLeft;
            minimize.Click += minimize_Click;
            // 
            // maximize
            // 
            maximize.Image = (Image)resources.GetObject("maximize.Image");
            maximize.Location = new Point(28, 0);
            maximize.Name = "maximize";
            maximize.Size = new Size(20, 20);
            maximize.TabIndex = 4;
            maximize.Click += maximize_Click;
            // 
            // Close
            // 
            Close.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Close.Cursor = Cursors.Hand;
            Close.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Close.ForeColor = SystemColors.ControlLightLight;
            Close.Location = new Point(51, 0);
            Close.Margin = new Padding(0);
            Close.Name = "Close";
            Close.Size = new Size(25, 20);
            Close.TabIndex = 2;
            Close.Text = "✖";
            Close.TextAlign = ContentAlignment.TopRight;
            Close.Click += Close_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.Controls.Add(welcome, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel2.Controls.Add(panel1, 1, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(36, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.Size = new Size(901, 361);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // welcome
            // 
            welcome.AutoSize = true;
            welcome.Dock = DockStyle.Fill;
            welcome.Font = new Font("Arial Rounded MT Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            welcome.ForeColor = Color.Lavender;
            welcome.Location = new Point(63, 0);
            welcome.Name = "welcome";
            welcome.Size = new Size(775, 50);
            welcome.TabIndex = 0;
            welcome.Text = "Welcome!";
            welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(signIn, 0, 0);
            tableLayoutPanel3.Controls.Add(mainBody, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(63, 53);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(775, 272);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // signIn
            // 
            signIn.AutoSize = true;
            signIn.Dock = DockStyle.Fill;
            signIn.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            signIn.ForeColor = Color.MediumTurquoise;
            signIn.Location = new Point(3, 0);
            signIn.Name = "signIn";
            signIn.Size = new Size(769, 50);
            signIn.TabIndex = 0;
            signIn.Text = "Sign in";
            signIn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainBody
            // 
            mainBody.AllowDrop = true;
            mainBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainBody.AutoScroll = true;
            mainBody.AutoSize = true;
            mainBody.Controls.Add(usernamePanel);
            mainBody.Controls.Add(lastnamePanel);
            mainBody.Controls.Add(firstNamePanel);
            mainBody.Controls.Add(emailPanel);
            mainBody.Controls.Add(phonePanel);
            mainBody.Controls.Add(locationPanel);
            mainBody.Controls.Add(nationPanel);
            mainBody.Controls.Add(birthDatePanel);
            mainBody.Controls.Add(imageUrlPanel);
            mainBody.Controls.Add(genderPanel);
            mainBody.Controls.Add(passwordPanel);
            mainBody.Controls.Add(confirmPanel);
            mainBody.Controls.Add(donePanel);
            mainBody.Cursor = Cursors.Hand;
            mainBody.FlowDirection = FlowDirection.RightToLeft;
            mainBody.Location = new Point(3, 53);
            mainBody.Name = "mainBody";
            mainBody.Size = new Size(769, 216);
            mainBody.TabIndex = 1;
            mainBody.Click += flowLayoutPanel2_Onclick;
            mainBody.Paint += flowLayoutPanel2_Paint;
            // 
            // usernamePanel
            // 
            usernamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            usernamePanel.BackColor = Color.LightCyan;
            usernamePanel.Controls.Add(usernameLabel);
            usernamePanel.Controls.Add(username);
            usernamePanel.Controls.Add(usernameNotification);
            usernamePanel.Location = new Point(73, 3);
            usernamePanel.Name = "usernamePanel";
            usernamePanel.Size = new Size(672, 87);
            usernamePanel.TabIndex = 0;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Dock = DockStyle.Left;
            usernameLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            usernameLabel.ForeColor = SystemColors.ActiveCaptionText;
            usernameLabel.Location = new Point(3, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(85, 51);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            usernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            username.Font = new Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            username.Location = new Point(94, 3);
            username.Name = "username";
            username.PlaceholderText = "Username";
            username.Size = new Size(457, 45);
            username.TabIndex = 1;
            username.TextAlign = HorizontalAlignment.Center;
            username.KeyDown += username_TextChanged;
            // 
            // usernameNotification
            // 
            usernameNotification.Location = new Point(3, 54);
            usernameNotification.Name = "usernameNotification";
            usernameNotification.Size = new Size(607, 32);
            usernameNotification.TabIndex = 2;
            // 
            // lastnamePanel
            // 
            lastnamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lastnamePanel.BackColor = Color.LightCyan;
            lastnamePanel.Controls.Add(lastNameLabel);
            lastnamePanel.Controls.Add(lastName);
            lastnamePanel.Controls.Add(lastnameNotification);
            lastnamePanel.Location = new Point(411, 96);
            lastnamePanel.Name = "lastnamePanel";
            lastnamePanel.Size = new Size(334, 87);
            lastnamePanel.TabIndex = 1;
            lastnamePanel.Visible = false;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lastNameLabel.ForeColor = SystemColors.ActiveCaptionText;
            lastNameLabel.Location = new Point(3, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(83, 22);
            lastNameLabel.TabIndex = 0;
            lastNameLabel.Text = "Last Name";
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lastName
            // 
            lastName.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lastName.Location = new Point(92, 3);
            lastName.Name = "lastName";
            lastName.PlaceholderText = "Your last name";
            lastName.Size = new Size(181, 34);
            lastName.TabIndex = 1;
            lastName.TextAlign = HorizontalAlignment.Center;
            lastName.KeyDown += lastName_TextChanged;
            // 
            // lastnameNotification
            // 
            lastnameNotification.Location = new Point(3, 43);
            lastnameNotification.Name = "lastnameNotification";
            lastnameNotification.Size = new Size(287, 32);
            lastnameNotification.TabIndex = 2;
            // 
            // firstNamePanel
            // 
            firstNamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            firstNamePanel.BackColor = Color.LightCyan;
            firstNamePanel.Controls.Add(firstNameLabel);
            firstNamePanel.Controls.Add(firstName);
            firstNamePanel.Controls.Add(firstnameNotification);
            mainBody.SetFlowBreak(firstNamePanel, true);
            firstNamePanel.Location = new Point(73, 96);
            firstNamePanel.Name = "firstNamePanel";
            firstNamePanel.Size = new Size(332, 87);
            firstNamePanel.TabIndex = 2;
            firstNamePanel.Visible = false;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            firstNameLabel.ForeColor = SystemColors.ActiveCaptionText;
            firstNameLabel.Location = new Point(3, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(85, 22);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            firstNameLabel.Click += firstNameLabel_Click;
            // 
            // firstName
            // 
            firstName.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            firstName.Location = new Point(94, 3);
            firstName.Name = "firstName";
            firstName.PlaceholderText = "Your First name";
            firstName.Size = new Size(181, 34);
            firstName.TabIndex = 1;
            firstName.TextAlign = HorizontalAlignment.Center;
            firstName.KeyDown += firstName_TextChanged;
            // 
            // firstnameNotification
            // 
            firstnameNotification.Location = new Point(3, 43);
            firstnameNotification.Name = "firstnameNotification";
            firstnameNotification.Size = new Size(287, 32);
            firstnameNotification.TabIndex = 2;
            // 
            // emailPanel
            // 
            emailPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            emailPanel.BackColor = Color.LightCyan;
            emailPanel.Controls.Add(emailLabel);
            emailPanel.Controls.Add(email);
            emailPanel.Controls.Add(emailNotification);
            mainBody.SetFlowBreak(emailPanel, true);
            emailPanel.Location = new Point(73, 189);
            emailPanel.Name = "emailPanel";
            emailPanel.Size = new Size(672, 87);
            emailPanel.TabIndex = 3;
            emailPanel.Visible = false;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Dock = DockStyle.Left;
            emailLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.ActiveCaptionText;
            emailLabel.Location = new Point(3, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(53, 40);
            emailLabel.TabIndex = 0;
            emailLabel.Text = "Email:";
            emailLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // email
            // 
            email.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            email.Location = new Point(62, 3);
            email.Name = "email";
            email.PlaceholderText = "Your email";
            email.Size = new Size(527, 34);
            email.TabIndex = 1;
            email.TextAlign = HorizontalAlignment.Center;
            email.KeyDown += email_TextChanged;
            // 
            // emailNotification
            // 
            emailNotification.Location = new Point(3, 43);
            emailNotification.Name = "emailNotification";
            emailNotification.Size = new Size(607, 32);
            emailNotification.TabIndex = 2;
            // 
            // phonePanel
            // 
            phonePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            phonePanel.BackColor = Color.LightCyan;
            phonePanel.Controls.Add(label1);
            phonePanel.Controls.Add(phone);
            phonePanel.Controls.Add(phoneNotification);
            mainBody.SetFlowBreak(phonePanel, true);
            phonePanel.ForeColor = SystemColors.ControlText;
            phonePanel.Location = new Point(73, 282);
            phonePanel.Name = "phonePanel";
            phonePanel.Size = new Size(672, 87);
            phonePanel.TabIndex = 4;
            phonePanel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 40);
            label1.TabIndex = 0;
            label1.Text = "Phone Number:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseWaitCursor = true;
            // 
            // phone
            // 
            phone.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            phone.Location = new Point(128, 3);
            phone.Name = "phone";
            phone.PlaceholderText = "Your phone number";
            phone.Size = new Size(457, 34);
            phone.TabIndex = 1;
            phone.TextAlign = HorizontalAlignment.Center;
            phone.KeyDown += phone_TextChanged;
            // 
            // phoneNotification
            // 
            phoneNotification.Location = new Point(3, 43);
            phoneNotification.Name = "phoneNotification";
            phoneNotification.Size = new Size(607, 32);
            phoneNotification.TabIndex = 2;
            // 
            // locationPanel
            // 
            locationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            locationPanel.BackColor = Color.LightCyan;
            locationPanel.Controls.Add(locationLabel);
            locationPanel.Controls.Add(location);
            locationPanel.Controls.Add(locationNotification);
            mainBody.SetFlowBreak(locationPanel, true);
            locationPanel.Location = new Point(73, 375);
            locationPanel.Name = "locationPanel";
            locationPanel.Size = new Size(672, 87);
            locationPanel.TabIndex = 5;
            locationPanel.Visible = false;
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Dock = DockStyle.Left;
            locationLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            locationLabel.ForeColor = SystemColors.ActiveCaptionText;
            locationLabel.Location = new Point(3, 0);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(76, 40);
            locationLabel.TabIndex = 0;
            locationLabel.Text = "Location:";
            locationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // location
            // 
            location.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            location.Location = new Point(85, 3);
            location.Name = "location";
            location.PlaceholderText = "Your street addrest";
            location.Size = new Size(496, 34);
            location.TabIndex = 1;
            location.TextAlign = HorizontalAlignment.Center;
            location.KeyDown += location_TextChanged;
            // 
            // locationNotification
            // 
            locationNotification.Location = new Point(3, 43);
            locationNotification.Name = "locationNotification";
            locationNotification.Size = new Size(607, 32);
            locationNotification.TabIndex = 2;
            // 
            // nationPanel
            // 
            nationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nationPanel.BackColor = Color.LightCyan;
            nationPanel.Controls.Add(nationLabel);
            nationPanel.Controls.Add(nation);
            nationPanel.Controls.Add(nationNotification);
            nationPanel.Location = new Point(519, 468);
            nationPanel.Name = "nationPanel";
            nationPanel.Size = new Size(226, 87);
            nationPanel.TabIndex = 6;
            nationPanel.Visible = false;
            // 
            // nationLabel
            // 
            nationLabel.AutoSize = true;
            nationLabel.Dock = DockStyle.Left;
            nationLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            nationLabel.ForeColor = SystemColors.ActiveCaptionText;
            nationLabel.Location = new Point(3, 0);
            nationLabel.Name = "nationLabel";
            nationLabel.Size = new Size(61, 34);
            nationLabel.TabIndex = 0;
            nationLabel.Text = "Nation:";
            nationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nation
            // 
            nation.FormattingEnabled = true;
            nation.Items.AddRange(new object[] { "Afghanistan", "land Islands", "Albania", "Algeria", "American Samoa", "AndorrA", "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Congo, The Democratic Republic of the", "Cook Islands", "Costa Rica", "Cote D\\\"Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Island and Mcdonald Islands", "Holy See (Vatican City State)", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran, Islamic Republic Of", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, Democratic People\\\"S Republic of", "Korea, Republic of", "Kuwait", "Kyrgyzstan", "Lao People\\\"S Democratic Republic", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao", "Macedonia, The Former Yugoslav Republic of", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia, Federated States of", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestinian Territory, Occupied", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "RWANDA", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint Pierre and Miquelon", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan, Province of China", "Tajikistan", "Tanzania, United Republic of", "Thailand", "Timor-Leste", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "United States Minor Outlying Islands", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Viet Nam", "Virgin Islands, British", "Virgin Islands, U.S.", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe" });
            nation.Location = new Point(70, 3);
            nation.Name = "nation";
            nation.Size = new Size(151, 28);
            nation.TabIndex = 3;
            nation.KeyDown += nation_SelectedIndexChanged;
            // 
            // nationNotification
            // 
            nationNotification.Dock = DockStyle.Bottom;
            nationNotification.Location = new Point(3, 37);
            nationNotification.Name = "nationNotification";
            nationNotification.Size = new Size(607, 32);
            nationNotification.TabIndex = 2;
            // 
            // birthDatePanel
            // 
            birthDatePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            birthDatePanel.BackColor = Color.LightCyan;
            birthDatePanel.Controls.Add(birthdateLabel);
            birthDatePanel.Controls.Add(birthDate);
            birthDatePanel.Controls.Add(birthdateNotification);
            birthDatePanel.Location = new Point(282, 468);
            birthDatePanel.Name = "birthDatePanel";
            birthDatePanel.Size = new Size(231, 87);
            birthDatePanel.TabIndex = 7;
            birthDatePanel.Visible = false;
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Dock = DockStyle.Left;
            birthdateLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            birthdateLabel.ForeColor = SystemColors.ActiveCaptionText;
            birthdateLabel.Location = new Point(3, 0);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new Size(86, 33);
            birthdateLabel.TabIndex = 0;
            birthdateLabel.Text = "Birth Date:";
            birthdateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // birthDate
            // 
            birthDate.Format = DateTimePickerFormat.Short;
            birthDate.Location = new Point(95, 3);
            birthDate.MaxDate = new DateTime(2012, 12, 31, 0, 0, 0, 0);
            birthDate.MinDate = new DateTime(1799, 12, 31, 0, 0, 0, 0);
            birthDate.Name = "birthDate";
            birthDate.Size = new Size(130, 27);
            birthDate.TabIndex = 3;
            birthDate.Value = new DateTime(2012, 12, 18, 0, 0, 0, 0);
            birthDate.KeyDown += birthDate_ValueChanged;
            // 
            // birthdateNotification
            // 
            birthdateNotification.Dock = DockStyle.Bottom;
            birthdateNotification.Location = new Point(3, 36);
            birthdateNotification.Name = "birthdateNotification";
            birthdateNotification.Size = new Size(607, 38);
            birthdateNotification.TabIndex = 2;
            // 
            // imageUrlPanel
            // 
            imageUrlPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            imageUrlPanel.BackColor = Color.LightCyan;
            imageUrlPanel.Controls.Add(imgUrlLabel);
            imageUrlPanel.Controls.Add(imgUrl);
            imageUrlPanel.Controls.Add(flowLayoutPanel4);
            mainBody.SetFlowBreak(imageUrlPanel, true);
            imageUrlPanel.Location = new Point(73, 561);
            imageUrlPanel.Name = "imageUrlPanel";
            imageUrlPanel.Size = new Size(672, 87);
            imageUrlPanel.TabIndex = 8;
            imageUrlPanel.Visible = false;
            // 
            // imgUrlLabel
            // 
            imgUrlLabel.AutoSize = true;
            imgUrlLabel.Dock = DockStyle.Left;
            imgUrlLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            imgUrlLabel.ForeColor = SystemColors.ActiveCaptionText;
            imgUrlLabel.Location = new Point(3, 0);
            imgUrlLabel.Name = "imgUrlLabel";
            imgUrlLabel.Size = new Size(142, 40);
            imgUrlLabel.TabIndex = 0;
            imgUrlLabel.Text = "Profile Image URL:";
            imgUrlLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgUrl
            // 
            imgUrl.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            imgUrl.Location = new Point(151, 3);
            imgUrl.Name = "imgUrl";
            imgUrl.PlaceholderText = "Paste your profile image URL here";
            imgUrl.Size = new Size(426, 34);
            imgUrl.TabIndex = 1;
            imgUrl.TextAlign = HorizontalAlignment.Center;
            imgUrl.KeyDown += imgUrl_TextChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(3, 43);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(607, 32);
            flowLayoutPanel4.TabIndex = 2;
            // 
            // genderPanel
            // 
            genderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            genderPanel.BackColor = Color.LightCyan;
            genderPanel.Controls.Add(genderLabel);
            genderPanel.Controls.Add(gender);
            genderPanel.Controls.Add(genderNotification);
            mainBody.SetFlowBreak(genderPanel, true);
            genderPanel.Location = new Point(541, 654);
            genderPanel.Name = "genderPanel";
            genderPanel.Size = new Size(204, 87);
            genderPanel.TabIndex = 9;
            genderPanel.Visible = false;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Dock = DockStyle.Left;
            genderLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            genderLabel.ForeColor = SystemColors.ActiveCaptionText;
            genderLabel.Location = new Point(3, 0);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(66, 34);
            genderLabel.TabIndex = 0;
            genderLabel.Text = "Gender:";
            genderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gender
            // 
            gender.FormattingEnabled = true;
            gender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            gender.Location = new Point(75, 3);
            gender.Name = "gender";
            gender.Size = new Size(118, 28);
            gender.TabIndex = 3;
            gender.KeyDown += gender_SelectedIndexChanged;
            // 
            // genderNotification
            // 
            genderNotification.Dock = DockStyle.Bottom;
            genderNotification.Location = new Point(3, 37);
            genderNotification.Name = "genderNotification";
            genderNotification.Size = new Size(607, 32);
            genderNotification.TabIndex = 2;
            // 
            // passwordPanel
            // 
            passwordPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            passwordPanel.BackColor = Color.LightCyan;
            passwordPanel.Controls.Add(passwordLabel);
            passwordPanel.Controls.Add(password);
            passwordPanel.Controls.Add(passwordNotification);
            mainBody.SetFlowBreak(passwordPanel, true);
            passwordPanel.Location = new Point(77, 747);
            passwordPanel.Name = "passwordPanel";
            passwordPanel.Size = new Size(668, 87);
            passwordPanel.TabIndex = 10;
            passwordPanel.Visible = false;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Dock = DockStyle.Left;
            passwordLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            passwordLabel.ForeColor = SystemColors.ActiveCaptionText;
            passwordLabel.Location = new Point(3, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(122, 45);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Set a password:";
            passwordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // password
            // 
            password.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            password.Location = new Point(131, 3);
            password.Name = "password";
            password.PlaceholderText = "Create a password";
            password.Size = new Size(519, 39);
            password.TabIndex = 1;
            password.TextAlign = HorizontalAlignment.Center;
            password.UseSystemPasswordChar = true;
            password.KeyDown += password_TextChanged;
            // 
            // passwordNotification
            // 
            passwordNotification.Location = new Point(3, 48);
            passwordNotification.Name = "passwordNotification";
            passwordNotification.Size = new Size(607, 32);
            passwordNotification.TabIndex = 2;
            // 
            // confirmPanel
            // 
            confirmPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            confirmPanel.BackColor = Color.LightCyan;
            confirmPanel.Controls.Add(confirmLabel);
            confirmPanel.Controls.Add(confirm);
            confirmPanel.Controls.Add(confirmNotification);
            confirmPanel.Location = new Point(77, 840);
            confirmPanel.Name = "confirmPanel";
            confirmPanel.Size = new Size(668, 87);
            confirmPanel.TabIndex = 11;
            confirmPanel.Visible = false;
            // 
            // confirmLabel
            // 
            confirmLabel.AutoSize = true;
            confirmLabel.Dock = DockStyle.Left;
            confirmLabel.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            confirmLabel.ForeColor = SystemColors.ActiveCaptionText;
            confirmLabel.Location = new Point(3, 0);
            confirmLabel.Name = "confirmLabel";
            confirmLabel.Size = new Size(184, 45);
            confirmLabel.TabIndex = 0;
            confirmLabel.Text = "Confirm your password: ";
            confirmLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirm
            // 
            confirm.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            confirm.Location = new Point(193, 3);
            confirm.Name = "confirm";
            confirm.PlaceholderText = "Confirm your password";
            confirm.Size = new Size(457, 39);
            confirm.TabIndex = 1;
            confirm.TextAlign = HorizontalAlignment.Center;
            confirm.UseSystemPasswordChar = true;
            confirm.TextChanged += confirm_TextChanged;
            confirm.KeyDown += confirm_TextChanged;
            // 
            // confirmNotification
            // 
            confirmNotification.Location = new Point(3, 48);
            confirmNotification.Name = "confirmNotification";
            confirmNotification.Size = new Size(607, 32);
            confirmNotification.TabIndex = 2;
            // 
            // donePanel
            // 
            donePanel.Controls.Add(login);
            donePanel.Controls.Add(done);
            donePanel.Controls.Add(doneIco);
            donePanel.Location = new Point(76, 933);
            donePanel.Name = "donePanel";
            donePanel.Size = new Size(669, 179);
            donePanel.TabIndex = 12;
            donePanel.Visible = false;
            // 
            // login
            // 
            login.BackColor = Color.Transparent;
            login.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            login.ForeColor = SystemColors.ButtonHighlight;
            login.Image = (Image)resources.GetObject("login.Image");
            login.Location = new Point(446, 144);
            login.Name = "login";
            login.Size = new Size(226, 35);
            login.TabIndex = 2;
            login.Text = "Go login!";
            login.Click += login_Click;
            // 
            // done
            // 
            done.Font = new Font("Exo ExtraBold", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            done.ForeColor = Color.LimeGreen;
            done.Location = new Point(172, 19);
            done.Name = "done";
            done.Size = new Size(280, 125);
            done.TabIndex = 1;
            done.Text = "Registed succesfully!";
            // 
            // doneIco
            // 
            doneIco.Image = (Image)resources.GetObject("doneIco.Image");
            doneIco.Location = new Point(19, 19);
            doneIco.Name = "doneIco";
            doneIco.Size = new Size(162, 139);
            doneIco.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(step);
            panel1.Controls.Add(first);
            panel1.Controls.Add(finish);
            panel1.Location = new Point(63, 331);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.Yes;
            panel1.Size = new Size(775, 27);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Cursor = Cursors.Hand;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(372, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 3;
            label2.Click += label2_Click;
            // 
            // step
            // 
            step.Cursor = Cursors.Hand;
            step.Image = (Image)resources.GetObject("step.Image");
            step.Location = new Point(123, 2);
            step.Name = "step";
            step.Size = new Size(281, 25);
            step.TabIndex = 0;
            step.Text = "Next";
            step.TextAlign = ContentAlignment.MiddleCenter;
            step.Click += step_Click;
            // 
            // first
            // 
            first.Cursor = Cursors.Hand;
            first.Image = (Image)resources.GetObject("first.Image");
            first.Location = new Point(198, 0);
            first.Name = "first";
            first.Size = new Size(62, 25);
            first.TabIndex = 2;
            first.Click += label1_Click;
            // 
            // finish
            // 
            finish.Cursor = Cursors.Hand;
            finish.Image = (Image)resources.GetObject("finish.Image");
            finish.Location = new Point(529, 2);
            finish.Name = "finish";
            finish.Size = new Size(62, 25);
            finish.TabIndex = 1;
            finish.Click += finish_Click;
            // 
            // previous
            // 
            previous.Image = (Image)resources.GetObject("previous.Image");
            previous.Location = new Point(3, 0);
            previous.Name = "previous";
            previous.Size = new Size(27, 25);
            previous.TabIndex = 6;
            previous.Click += previous_Click;
            // 
            // topBar
            // 
            topBar.Dock = DockStyle.Fill;
            topBar.Location = new Point(36, 3);
            topBar.Name = "topBar";
            topBar.Size = new Size(901, 21);
            topBar.TabIndex = 7;
            topBar.Paint += panel2_Paint;
            topBar.MouseDown += topBar_MouseDown;
            topBar.MouseMove += regisForm_MouseMove;
            topBar.MouseUp += registForm_MouseUp;
            // 
            // RegistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1022, 491);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistForm";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            mainBody.ResumeLayout(false);
            usernamePanel.ResumeLayout(false);
            usernamePanel.PerformLayout();
            lastnamePanel.ResumeLayout(false);
            lastnamePanel.PerformLayout();
            firstNamePanel.ResumeLayout(false);
            firstNamePanel.PerformLayout();
            emailPanel.ResumeLayout(false);
            emailPanel.PerformLayout();
            phonePanel.ResumeLayout(false);
            phonePanel.PerformLayout();
            locationPanel.ResumeLayout(false);
            locationPanel.PerformLayout();
            nationPanel.ResumeLayout(false);
            nationPanel.PerformLayout();
            birthDatePanel.ResumeLayout(false);
            birthDatePanel.PerformLayout();
            imageUrlPanel.ResumeLayout(false);
            imageUrlPanel.PerformLayout();
            genderPanel.ResumeLayout(false);
            genderPanel.PerformLayout();
            passwordPanel.ResumeLayout(false);
            passwordPanel.PerformLayout();
            confirmPanel.ResumeLayout(false);
            confirmPanel.PerformLayout();
            donePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label Close;
        private Label minimize;
        private Label maximize;
        private TableLayoutPanel tableLayoutPanel2;
        private Label welcome;
        private TableLayoutPanel tableLayoutPanel3;
        private Label signIn;
        private FlowLayoutPanel mainBody;
        private Label usernameLabel;
        private TextBox username;
        private FlowLayoutPanel usernamePanel;
        private FlowLayoutPanel usernameNotification;
        private Panel panel1;
        private Label step;
        private Label finish;
        private Label first;
        private Label label2;
        private FlowLayoutPanel lastnamePanel;
        private Label lastNameLabel;
        private TextBox lastName;
        private FlowLayoutPanel lastnameNotification;
        private FlowLayoutPanel firstNamePanel;
        private Label firstNameLabel;
        private TextBox firstName;
        private FlowLayoutPanel firstnameNotification;
        private FlowLayoutPanel emailPanel;
        private Label emailLabel;
        private TextBox email;
        private FlowLayoutPanel emailNotification;
        private FlowLayoutPanel phonePanel;
        private Label label1;
        private TextBox phone;
        private FlowLayoutPanel phoneNotification;
        private FlowLayoutPanel locationPanel;
        private Label locationLabel;
        private TextBox location;
        private FlowLayoutPanel locationNotification;
        private FlowLayoutPanel nationPanel;
        private Label nationLabel;
        private ComboBox nation;
        private FlowLayoutPanel nationNotification;
        private FlowLayoutPanel birthDatePanel;
        private Label birthdateLabel;
        private FlowLayoutPanel birthdateNotification;
        private DateTimePicker birthDate;
        private FlowLayoutPanel imageUrlPanel;
        private Label imgUrlLabel;
        private TextBox imgUrl;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel genderPanel;
        private Label genderLabel;
        private ComboBox gender;
        private FlowLayoutPanel genderNotification;
        private FlowLayoutPanel passwordPanel;
        private Label passwordLabel;
        private TextBox password;
        private FlowLayoutPanel passwordNotification;
        private FlowLayoutPanel confirmPanel;
        private Label confirmLabel;
        private TextBox confirm;
        private FlowLayoutPanel confirmNotification;
        private Label previous;
        private Panel topBar;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label doneIco;
        private Panel donePanel;
        private Label done;
        private Label login;
    }
}