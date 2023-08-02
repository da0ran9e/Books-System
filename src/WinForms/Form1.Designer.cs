namespace WinForms
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Bahnschrift Condensed", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(492, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(27, 18);
            label1.TabIndex = 0;
            label1.Text = "❌";
            label1.TextAlign = ContentAlignment.TopRight;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Candara", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(188, 65);
            label2.MaximumSize = new Size(300, 80);
            label2.MinimumSize = new Size(150, 40);
            label2.Name = "label2";
            label2.Size = new Size(167, 45);
            label2.TabIndex = 1;
            label2.Text = "Login";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(231, 223);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(151, 27);
            maskedTextBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(231, 266);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 223);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 4;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 269);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Info;
            label5.Location = new Point(181, 335);
            label5.Name = "label5";
            label5.Size = new Size(174, 25);
            label5.TabIndex = 6;
            label5.Text = "Login";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(143, 366);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 7;
            label6.Text = "Register?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(311, 366);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 8;
            label7.Text = "Forgot password?";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(464, 0);
            label8.Name = "label8";
            label8.Size = new Size(31, 20);
            label8.TabIndex = 9;
            label8.Text = "➖";
            label8.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(521, 613);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(maskedTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MaskedTextBox maskedTextBox1;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}