using static WinForms.EffectBlur;
using System.Runtime.InteropServices;

namespace WinForms
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            grad0 = new GradientPanel();
            progressLabel = new Label();
            loadingLabel = new Label();
            progressBar = new ProgressBar();
            tableLayoutPanel1.SuspendLayout();
            grad0.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 700F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(grad0, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1026, 569);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // grad0
            // 
            grad0.BackgroundImage = (Image)resources.GetObject("grad0.BackgroundImage");
            grad0.BackgroundImageLayout = ImageLayout.Stretch;
            grad0.Controls.Add(progressLabel);
            grad0.Controls.Add(loadingLabel);
            grad0.Controls.Add(progressBar);
            grad0.Dock = DockStyle.Fill;
            grad0.GradientAngle = 30F;
            grad0.GradientPrimaryColor = Color.FromArgb(192, 255, 255);
            grad0.GradientSecondaryColor = Color.Transparent;
            grad0.Location = new Point(163, 59);
            grad0.Margin = new Padding(0);
            grad0.Name = "grad0";
            grad0.Size = new Size(700, 450);
            grad0.TabIndex = 0;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(270, 276);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(36, 20);
            progressLabel.TabIndex = 2;
            progressLabel.Text = "N/A";
            // 
            // loadingLabel
            // 
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font("Exo ExtraBold", 22.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            loadingLabel.ForeColor = Color.DodgerBlue;
            loadingLabel.Location = new Point(270, 205);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(186, 52);
            loadingLabel.TabIndex = 1;
            loadingLabel.Text = "Loading...";
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.ForeColor = Color.Lime;
            progressBar.Location = new Point(0, 445);
            progressBar.Margin = new Padding(0);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(700, 5);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 0;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 569);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdFeedForm";
            WindowState = FormWindowState.Maximized;
            Load += LoadingForm_LoadAsync2;
            tableLayoutPanel1.ResumeLayout(false);
            grad0.ResumeLayout(false);
            grad0.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GradientPanel grad0;
        private ProgressBar progressBar;
        private Label loadingLabel;
        private Label progressLabel;
    }
}