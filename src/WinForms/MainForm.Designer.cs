using static WinForms.EffectBlur;
using System.Runtime.InteropServices;

namespace WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            userLabel = new Label();
            homeLabel = new Label();
            searchLabel = new Label();
            heartLabel = new Label();
            librariesLabel = new Label();
            recentLabel = new Label();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            recommendFlowPanel = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            mainPanel = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            recommendFlowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 550F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 0);
            tableLayoutPanel1.Controls.Add(recommendFlowPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(mainPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Size = new Size(819, 846);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(userLabel);
            flowLayoutPanel1.Controls.Add(homeLabel);
            flowLayoutPanel1.Controls.Add(searchLabel);
            flowLayoutPanel1.Controls.Add(heartLabel);
            flowLayoutPanel1.Controls.Add(librariesLabel);
            flowLayoutPanel1.Controls.Add(recentLabel);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(722, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(94, 740);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.MouseWheel += FlowLayoutPanel1_MouseWheel;
            // 
            // userLabel
            // 
            userLabel.BackColor = Color.Transparent;
            userLabel.Image = (Image)resources.GetObject("userLabel.Image");
            userLabel.Location = new Point(0, 30);
            userLabel.Margin = new Padding(0, 30, 0, 50);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(90, 90);
            userLabel.TabIndex = 0;
            userLabel.Click += label1_Click;
            // 
            // homeLabel
            // 
            homeLabel.Image = (Image)resources.GetObject("homeLabel.Image");
            homeLabel.Location = new Point(13, 180);
            homeLabel.Margin = new Padding(13, 10, 0, 0);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(71, 71);
            homeLabel.TabIndex = 3;
            // 
            // searchLabel
            // 
            searchLabel.Image = (Image)resources.GetObject("searchLabel.Image");
            searchLabel.Location = new Point(13, 270);
            searchLabel.Margin = new Padding(13, 19, 0, 0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(71, 71);
            searchLabel.TabIndex = 1;
            // 
            // heartLabel
            // 
            heartLabel.BackColor = Color.Transparent;
            heartLabel.Image = (Image)resources.GetObject("heartLabel.Image");
            heartLabel.Location = new Point(13, 341);
            heartLabel.Margin = new Padding(13, 0, 0, 0);
            heartLabel.Name = "heartLabel";
            heartLabel.Size = new Size(71, 71);
            heartLabel.TabIndex = 2;
            // 
            // librariesLabel
            // 
            librariesLabel.BackColor = Color.Transparent;
            librariesLabel.Image = (Image)resources.GetObject("librariesLabel.Image");
            librariesLabel.Location = new Point(13, 412);
            librariesLabel.Margin = new Padding(13, 0, 0, 0);
            librariesLabel.Name = "librariesLabel";
            librariesLabel.Size = new Size(71, 71);
            librariesLabel.TabIndex = 4;
            // 
            // recentLabel
            // 
            recentLabel.BackColor = Color.Transparent;
            recentLabel.Image = (Image)resources.GetObject("recentLabel.Image");
            recentLabel.Location = new Point(13, 483);
            recentLabel.Margin = new Padding(13, 0, 0, 0);
            recentLabel.Name = "recentLabel";
            recentLabel.Size = new Size(71, 71);
            recentLabel.TabIndex = 5;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.Location = new Point(13, 554);
            label6.Margin = new Padding(13, 0, 0, 0);
            label6.Name = "label6";
            label6.Size = new Size(71, 71);
            label6.TabIndex = 11;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(13, 625);
            label1.Margin = new Padding(13, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 71);
            label1.TabIndex = 12;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(13, 696);
            label2.Margin = new Padding(13, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 71);
            label2.TabIndex = 13;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(13, 767);
            label3.Margin = new Padding(13, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 71);
            label3.TabIndex = 14;
            // 
            // recommendFlowPanel
            // 
            recommendFlowPanel.AutoScroll = true;
            recommendFlowPanel.BackColor = Color.Black;
            recommendFlowPanel.Controls.Add(flowLayoutPanel2);
            recommendFlowPanel.Dock = DockStyle.Fill;
            recommendFlowPanel.Location = new Point(172, 3);
            recommendFlowPanel.Name = "recommendFlowPanel";
            recommendFlowPanel.Size = new Size(544, 740);
            recommendFlowPanel.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.IndianRed;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(531, 212);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Black;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(3, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(163, 740);
            mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(819, 846);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            recommendFlowPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void FlowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            SetStyle(ControlStyles.UserMouse | ControlStyles.Selectable, true);
        }


        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label userLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label searchLabel;
        private Label heartLabel;
        private Label homeLabel;
        private Label librariesLabel;
        private Label recentLabel;
        private Label label6;
        private FlowLayoutPanel recommendFlowPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel mainPanel;
    }
}