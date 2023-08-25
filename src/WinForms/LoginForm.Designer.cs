namespace WinForms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            Close = new Label();
            minimize = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3 = new Panel();
            forgotPass = new Label();
            register = new Label();
            loginBtn = new Label();
            loginNotification = new Panel();
            panel2 = new Panel();
            seePassword = new CheckBox();
            passwordTextbox = new TextBox();
            usernameTextbox = new TextBox();
            panel1 = new Panel();
            loginLabel = new Label();
            welcome = new Label();
            drag = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Controls.Add(Close, 5, 0);
            tableLayoutPanel1.Controls.Add(minimize, 4, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 2);
            tableLayoutPanel1.Controls.Add(welcome, 2, 1);
            tableLayoutPanel1.Controls.Add(drag, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(520, 693);
            tableLayoutPanel1.TabIndex = 11;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // Close
            // 
            Close.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Close.Cursor = Cursors.Hand;
            Close.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Close.ForeColor = SystemColors.ControlLightLight;
            Close.Image = (Image)resources.GetObject("Close.Image");
            Close.Location = new Point(495, 0);
            Close.Margin = new Padding(0);
            Close.Name = "Close";
            Close.Size = new Size(25, 20);
            Close.TabIndex = 0;
            Close.TextAlign = ContentAlignment.TopRight;
            Close.Click += label1_Click_1;
            // 
            // minimize
            // 
            minimize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            minimize.Cursor = Cursors.Hand;
            minimize.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point);
            minimize.ForeColor = SystemColors.ButtonHighlight;
            minimize.Image = (Image)resources.GetObject("minimize.Image");
            minimize.Location = new Point(473, 0);
            minimize.Name = "minimize";
            minimize.Size = new Size(19, 20);
            minimize.TabIndex = 1;
            minimize.TextAlign = ContentAlignment.BottomLeft;
            minimize.Click += label2_Click_1;
            // 
            // otherCategoriesPanel
            // 
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(loginNotification);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel1.Location = new Point(137, 153);
            flowLayoutPanel1.Name = "otherCategoriesPanel";
            flowLayoutPanel1.Size = new Size(246, 418);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(forgotPass);
            panel3.Controls.Add(register);
            panel3.Controls.Add(loginBtn);
            panel3.Location = new Point(3, 339);
            panel3.Name = "panel3";
            panel3.Size = new Size(241, 76);
            panel3.TabIndex = 2;
            // 
            // forgotPass
            // 
            forgotPass.AutoSize = true;
            forgotPass.ForeColor = SystemColors.ControlLightLight;
            forgotPass.Location = new Point(124, 42);
            forgotPass.Name = "forgotPass";
            forgotPass.Size = new Size(130, 20);
            forgotPass.TabIndex = 2;
            forgotPass.Text = "Forgot password?";
            forgotPass.Click += label7_Click;
            forgotPass.MouseLeave += label7_MouseLeave;
            forgotPass.MouseHover += label7_Hover;
            // 
            // register
            // 
            register.AutoSize = true;
            register.ForeColor = SystemColors.ControlLightLight;
            register.Location = new Point(-3, 42);
            register.Name = "register";
            register.Size = new Size(77, 20);
            register.TabIndex = 1;
            register.Text = "Registers?";
            register.Click += register_Click;
            register.MouseLeave += label6_MouseLeave;
            register.MouseHover += label6_Hover;
            // 
            // loginBtn
            // 
            loginBtn.AccessibleRole = AccessibleRole.IpAddress;
            loginBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            loginBtn.BackColor = Color.LightBlue;
            loginBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginBtn.ForeColor = Color.MidnightBlue;
            loginBtn.Location = new Point(19, 0);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(205, 26);
            loginBtn.TabIndex = 0;
            loginBtn.Text = "Login ";
            loginBtn.TextAlign = ContentAlignment.MiddleCenter;
            loginBtn.Click += label4_Click;
            loginBtn.MouseLeave += label4_MouseLeave;
            loginBtn.MouseHover += label4_Hover;
            // 
            // loginNotification
            // 
            loginNotification.Location = new Point(3, 303);
            loginNotification.Name = "loginNotification";
            loginNotification.Size = new Size(241, 30);
            loginNotification.TabIndex = 3;
            loginNotification.Paint += loginNotification_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(seePassword);
            panel2.Controls.Add(passwordTextbox);
            panel2.Controls.Add(usernameTextbox);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(3, 226);
            panel2.Name = "panel2";
            panel2.Size = new Size(241, 71);
            panel2.TabIndex = 1;
            panel2.Click += panel2_Onclick;
            // 
            // seePassword
            // 
            seePassword.AutoSize = true;
            seePassword.Location = new Point(212, 42);
            seePassword.Name = "seePassword";
            seePassword.Size = new Size(18, 17);
            seePassword.TabIndex = 2;
            seePassword.UseVisualStyleBackColor = true;
            seePassword.CheckedChanged += seePassword_CheckedChanged;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Enabled = false;
            passwordTextbox.Location = new Point(19, 36);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PlaceholderText = "Password";
            passwordTextbox.Size = new Size(187, 27);
            passwordTextbox.TabIndex = 1;
            passwordTextbox.UseSystemPasswordChar = true;
            passwordTextbox.KeyDown += passwordTextbox_KeyDown;
            // 
            // usernameTextbox
            // 
            usernameTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            usernameTextbox.Enabled = false;
            usernameTextbox.Location = new Point(19, 3);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.PlaceholderText = "Username";
            usernameTextbox.Size = new Size(205, 27);
            usernameTextbox.TabIndex = 0;
            usernameTextbox.TextChanged += usernameTextbox_TextChanged;
            usernameTextbox.KeyDown += usernameTextbox_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(loginLabel);
            panel1.Location = new Point(3, 149);
            panel1.Name = "panel1";
            panel1.Size = new Size(241, 71);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // loginLabel
            // 
            loginLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Cooper Black", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.ForeColor = Color.LightCyan;
            loginLabel.Location = new Point(79, 21);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(94, 32);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Login";
            loginLabel.Click += label3_Click;
            // 
            // welcome
            // 
            welcome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            welcome.AutoSize = true;
            welcome.Font = new Font("Arial Rounded MT Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            welcome.ForeColor = Color.Navy;
            welcome.Location = new Point(137, 20);
            welcome.Name = "welcome";
            welcome.Size = new Size(246, 130);
            welcome.TabIndex = 4;
            welcome.Text = "Welcome!";
            welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // drag
            // 
            drag.Cursor = Cursors.Hand;
            drag.Image = (Image)resources.GetObject("drag.Image");
            drag.Location = new Point(3, 0);
            drag.Name = "drag";
            drag.Size = new Size(23, 20);
            drag.TabIndex = 6;
            drag.MouseDown += label1_MouseDown;
            drag.MouseMove += LoginForm_MouseMove;
            drag.MouseUp += LoginForm_MouseUp;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(520, 693);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label Close;
        private Label minimize;
        private Label welcome;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label loginLabel;
        private Panel panel2;
        private TextBox passwordTextbox;
        private TextBox usernameTextbox;
        private Panel panel3;
        private Label loginBtn;
        private Panel loginNotification;
        private Label forgotPass;
        private Label register;
        private Label drag;
        private CheckBox seePassword;
    }
}