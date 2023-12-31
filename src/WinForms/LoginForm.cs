using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;

namespace WinForms
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.Lime;
            try
            {
                cmd = new SqlCommand("select * from users where username=@username and password=@password", con);
                cmd.Parameters.AddWithValue("@username", usernameTextbox.Text);
                cmd.Parameters.AddWithValue("@password", passwordTextbox.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Label lb = new Label();
                    lb.Text = "Loging!";
                    lb.Size = new Size(240, 30);
                    lb.ForeColor = Color.Green;
                    lb.Padding = new Padding(12, 0, 0, 0);
                    loginNotification.Controls.Add(lb);                    
                    
                    Form mainForm = new LoadingForm(usernameTextbox.Text);
                    this.Visible = false;
                    //new LoadingForm(() => /*Show loading form while mainform in progress*/ mainForm.ShowDialog()).ShowDialog();
                    _ = mainForm.ShowDialog();


                }
                else
                {
                    Label lb = new Label();
                    lb.Text = "Login informations incorrect!";
                    lb.Size = new Size(240, 30);
                    lb.ForeColor = Color.Red;
                    lb.Padding = new Padding(12, 0, 0, 0);
                    loginNotification.Controls.Add(lb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // close the reader
                if (dr != null)
                {
                    dr.Close();
                }

                //Close the connection
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void label4_Hover(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.DodgerBlue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            loginBtn.BackColor = Color.LightBlue;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Hover(object sender, EventArgs e)
        {
            register.ForeColor = Color.Lime;
        }

        private void register_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegistForm regist = new RegistForm();
            regist.ShowDialog();
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            register.ForeColor = Color.White;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Hover(object sender, EventArgs e)
        {
            forgotPass.ForeColor = Color.LightCoral;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            forgotPass.ForeColor = Color.White;
        }

        private void usernameTextbox_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                passwordTextbox.Focus();
        }

        private void loginNotification_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passwordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                label4_Click(sender, e);
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Onclick(object sender, EventArgs e)
        {
            usernameTextbox.Enabled = true;
            passwordTextbox.Enabled = true;
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            dragging = false;
        }

        private void seePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (seePassword.Checked)
            {
                passwordTextbox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordTextbox.UseSystemPasswordChar = true;
            }
        }
    }
}