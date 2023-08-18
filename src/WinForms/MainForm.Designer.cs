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

        private string username;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
           // SingleTextView singleTextView1 = new TSkin.ST.SingleTextView();
            searchTabeLayout = new TableLayoutPanel();
            verticalMenuBar = new FlowLayoutPanel();
            userLabel = new Label();
            verticalTableMenu = new TableLayoutPanel();
            bottomBlank = new GradientPanel();
            topBlank = new GradientPanel();
            homeGradientPanel = new GradientPanel();
            homeLabel = new Label();
            searchGradientPanel = new GradientPanel();
            searchLabel = new Label();
            heartGradientPanel = new GradientPanel();
            heartLabel = new Label();
            libraryGradientPanel = new GradientPanel();
            librariesLabel = new Label();
            recentGradientPanel = new GradientPanel();
            recentLabel = new Label();
            contentPanel = new FlowLayoutPanel();
            contentContainer = new FlowLayoutPanel();
            contentImg = new Label();
            contentTitle = new Label();
            authorLabel = new Label();
            publisherLabel = new Label();
            aboutAuthor = new Label();
            authorDesLabel = new Label();
            categoryLabel = new Label();
            category0 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label39 = new Label();
            label76 = new Label();
            flowLayoutPanel40 = new FlowLayoutPanel();
            tableLayoutPanel39 = new TableLayoutPanel();
            label77 = new Label();
            label78 = new Label();
            mainFlowPanel = new FlowLayoutPanel();
            homeFlowPanel = new FlowLayoutPanel();
            helloPanel = new FlowLayoutPanel();
            helloLabel = new Label();
            helloElement0 = new GradientPanel();
            helloElementTable0 = new TableLayoutPanel();
            helloElementImg0 = new Label();
            helloFlow0 = new FlowLayoutPanel();
            helloElementTitle0 = new Label();
            helloAuthor0 = new Label();
            helloElement1 = new GradientPanel();
            helloElementTable1 = new TableLayoutPanel();
            helloElementImg1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            helloElementTitle1 = new Label();
            helloAuthor1 = new Label();
            helloElement2 = new GradientPanel();
            helloElementTable2 = new TableLayoutPanel();
            helloElementImg2 = new Label();
            helloFlow2 = new FlowLayoutPanel();
            helloElementTitle2 = new Label();
            helloAuthor2 = new Label();
            helloElement3 = new GradientPanel();
            helloElementTable3 = new TableLayoutPanel();
            helloElementImg3 = new Label();
            helloFlow3 = new FlowLayoutPanel();
            helloElementTitle3 = new Label();
            helloAuthor3 = new Label();
            recommentPanel = new FlowLayoutPanel();
            recommentLabel = new Label();
            flowLayoutPanel22 = new FlowLayoutPanel();
            tableLayoutPanel20 = new TableLayoutPanel();
            label40 = new Label();
            label41 = new Label();
            flowLayoutPanel23 = new FlowLayoutPanel();
            tableLayoutPanel21 = new TableLayoutPanel();
            label42 = new Label();
            label43 = new Label();
            flowLayoutPanel24 = new FlowLayoutPanel();
            tableLayoutPanel22 = new TableLayoutPanel();
            label44 = new Label();
            label45 = new Label();
            flowLayoutPanel25 = new FlowLayoutPanel();
            tableLayoutPanel23 = new TableLayoutPanel();
            label46 = new Label();
            label47 = new Label();
            flowLayoutPanel26 = new FlowLayoutPanel();
            tableLayoutPanel24 = new TableLayoutPanel();
            label48 = new Label();
            label49 = new Label();
            flowLayoutPanel27 = new FlowLayoutPanel();
            tableLayoutPanel25 = new TableLayoutPanel();
            label50 = new Label();
            label51 = new Label();
            recentPanel = new FlowLayoutPanel();
            recentReadPanel = new Label();
            flowLayoutPanel28 = new FlowLayoutPanel();
            tableLayoutPanel26 = new TableLayoutPanel();
            label52 = new Label();
            label53 = new Label();
            flowLayoutPanel29 = new FlowLayoutPanel();
            tableLayoutPanel27 = new TableLayoutPanel();
            label54 = new Label();
            label55 = new Label();
            flowLayoutPanel30 = new FlowLayoutPanel();
            tableLayoutPanel28 = new TableLayoutPanel();
            label56 = new Label();
            label57 = new Label();
            flowLayoutPanel31 = new FlowLayoutPanel();
            tableLayoutPanel29 = new TableLayoutPanel();
            label58 = new Label();
            label59 = new Label();
            flowLayoutPanel32 = new FlowLayoutPanel();
            tableLayoutPanel30 = new TableLayoutPanel();
            label60 = new Label();
            label61 = new Label();
            flowLayoutPanel33 = new FlowLayoutPanel();
            tableLayoutPanel31 = new TableLayoutPanel();
            label62 = new Label();
            label63 = new Label();
            bestBookPanel = new FlowLayoutPanel();
            bestBookLabel = new Label();
            flowLayoutPanel34 = new FlowLayoutPanel();
            tableLayoutPanel32 = new TableLayoutPanel();
            label64 = new Label();
            label65 = new Label();
            flowLayoutPanel35 = new FlowLayoutPanel();
            tableLayoutPanel33 = new TableLayoutPanel();
            label66 = new Label();
            label67 = new Label();
            flowLayoutPanel36 = new FlowLayoutPanel();
            tableLayoutPanel34 = new TableLayoutPanel();
            label68 = new Label();
            label69 = new Label();
            flowLayoutPanel37 = new FlowLayoutPanel();
            tableLayoutPanel35 = new TableLayoutPanel();
            label70 = new Label();
            label71 = new Label();
            flowLayoutPanel38 = new FlowLayoutPanel();
            tableLayoutPanel36 = new TableLayoutPanel();
            label72 = new Label();
            label73 = new Label();
            flowLayoutPanel39 = new FlowLayoutPanel();
            tableLayoutPanel37 = new TableLayoutPanel();
            label74 = new Label();
            label75 = new Label();
            searchFlowPanel = new FlowLayoutPanel();
            searchPanel = new FlowLayoutPanel();
            searchLayoutTable = new TableLayoutPanel();
            searchBoxContainer = new GradientPanel();
            searchBox = new TSkin.ST.STTextBox();
            searchImg = new Label();
            bestMatchPanel = new FlowLayoutPanel();
            bestMatchLabel = new Label();
            bestMatchResult = new FlowLayoutPanel();
            bestMatchTableLayout = new TableLayoutPanel();
            label89 = new Label();
            label90 = new Label();
            flowLayoutPanel49 = new FlowLayoutPanel();
            tableLayoutPanel45 = new TableLayoutPanel();
            label91 = new Label();
            label92 = new Label();
            flowLayoutPanel61 = new FlowLayoutPanel();
            label114 = new Label();
            flowLayoutPanel62 = new FlowLayoutPanel();
            tableLayoutPanel56 = new TableLayoutPanel();
            label115 = new Label();
            label116 = new Label();
            flowLayoutPanel63 = new FlowLayoutPanel();
            tableLayoutPanel57 = new TableLayoutPanel();
            label117 = new Label();
            label118 = new Label();
            flowLayoutPanel64 = new FlowLayoutPanel();
            tableLayoutPanel58 = new TableLayoutPanel();
            label119 = new Label();
            label120 = new Label();
            flowLayoutPanel65 = new FlowLayoutPanel();
            tableLayoutPanel59 = new TableLayoutPanel();
            label121 = new Label();
            label122 = new Label();
            flowLayoutPanel66 = new FlowLayoutPanel();
            tableLayoutPanel60 = new TableLayoutPanel();
            label123 = new Label();
            label124 = new Label();
            flowLayoutPanel67 = new FlowLayoutPanel();
            tableLayoutPanel61 = new TableLayoutPanel();
            label125 = new Label();
            label126 = new Label();
            currentPanel = new Panel();
            currentLabel = new Label();
            currentProperties = new GradientPanel();
            currentPropertiesTable = new TableLayoutPanel();
            currentBookPanel = new FlowLayoutPanel();
            currentBookTitle = new Label();
            currentBookAuthor = new Label();
            currentBookRate = new Label();
            currentPagePanel = new Panel();
            totalPage = new Label();
            currentPage = new Label();
            currentPublisherPanel = new FlowLayoutPanel();
            currentPublisher = new Label();
            yearOfPublication = new Label();
            optionPanel = new GradientPanel();
            optionsFlowPanel = new FlowLayoutPanel();
            heartOption = new Label();
            textToSpeech = new Label();
            brightness = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label9 = new Label();
            label10 = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label11 = new Label();
            label12 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label5 = new Label();
            flowLayoutPanel8 = new FlowLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label6 = new Label();
            label15 = new Label();
            flowLayoutPanel9 = new FlowLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            label16 = new Label();
            label17 = new Label();
            flowLayoutPanel10 = new FlowLayoutPanel();
            tableLayoutPanel10 = new TableLayoutPanel();
            label18 = new Label();
            label19 = new Label();
            flowLayoutPanel11 = new FlowLayoutPanel();
            tableLayoutPanel11 = new TableLayoutPanel();
            label20 = new Label();
            label21 = new Label();
            flowLayoutPanel12 = new FlowLayoutPanel();
            tableLayoutPanel12 = new TableLayoutPanel();
            label22 = new Label();
            label23 = new Label();
            flowLayoutPanel13 = new FlowLayoutPanel();
            tableLayoutPanel13 = new TableLayoutPanel();
            label24 = new Label();
            label25 = new Label();
            flowLayoutPanel14 = new FlowLayoutPanel();
            label26 = new Label();
            flowLayoutPanel15 = new FlowLayoutPanel();
            tableLayoutPanel14 = new TableLayoutPanel();
            label27 = new Label();
            label28 = new Label();
            flowLayoutPanel16 = new FlowLayoutPanel();
            tableLayoutPanel15 = new TableLayoutPanel();
            label29 = new Label();
            label30 = new Label();
            flowLayoutPanel17 = new FlowLayoutPanel();
            tableLayoutPanel16 = new TableLayoutPanel();
            label31 = new Label();
            label32 = new Label();
            flowLayoutPanel18 = new FlowLayoutPanel();
            tableLayoutPanel17 = new TableLayoutPanel();
            label33 = new Label();
            label34 = new Label();
            flowLayoutPanel19 = new FlowLayoutPanel();
            tableLayoutPanel18 = new TableLayoutPanel();
            label35 = new Label();
            label36 = new Label();
            flowLayoutPanel20 = new FlowLayoutPanel();
            tableLayoutPanel19 = new TableLayoutPanel();
            label37 = new Label();
            label38 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            gradientPanel2 = new GradientPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label7 = new Label();
            label8 = new Label();
            gradientPanel4 = new GradientPanel();
            tableLayoutPanel40 = new TableLayoutPanel();
            label79 = new Label();
            label80 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            viewToolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            searchTabeLayout.SuspendLayout();
            verticalMenuBar.SuspendLayout();
            verticalTableMenu.SuspendLayout();
            homeGradientPanel.SuspendLayout();
            searchGradientPanel.SuspendLayout();
            heartGradientPanel.SuspendLayout();
            libraryGradientPanel.SuspendLayout();
            recentGradientPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            contentContainer.SuspendLayout();
            category0.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel40.SuspendLayout();
            tableLayoutPanel39.SuspendLayout();
            mainFlowPanel.SuspendLayout();
            homeFlowPanel.SuspendLayout();
            helloPanel.SuspendLayout();
            helloElement0.SuspendLayout();
            helloElementTable0.SuspendLayout();
            helloFlow0.SuspendLayout();
            helloElement1.SuspendLayout();
            helloElementTable1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            helloElement2.SuspendLayout();
            helloElementTable2.SuspendLayout();
            helloFlow2.SuspendLayout();
            helloElement3.SuspendLayout();
            helloElementTable3.SuspendLayout();
            helloFlow3.SuspendLayout();
            recommentPanel.SuspendLayout();
            flowLayoutPanel22.SuspendLayout();
            tableLayoutPanel20.SuspendLayout();
            flowLayoutPanel23.SuspendLayout();
            tableLayoutPanel21.SuspendLayout();
            flowLayoutPanel24.SuspendLayout();
            tableLayoutPanel22.SuspendLayout();
            flowLayoutPanel25.SuspendLayout();
            tableLayoutPanel23.SuspendLayout();
            flowLayoutPanel26.SuspendLayout();
            tableLayoutPanel24.SuspendLayout();
            flowLayoutPanel27.SuspendLayout();
            tableLayoutPanel25.SuspendLayout();
            recentPanel.SuspendLayout();
            flowLayoutPanel28.SuspendLayout();
            tableLayoutPanel26.SuspendLayout();
            flowLayoutPanel29.SuspendLayout();
            tableLayoutPanel27.SuspendLayout();
            flowLayoutPanel30.SuspendLayout();
            tableLayoutPanel28.SuspendLayout();
            flowLayoutPanel31.SuspendLayout();
            tableLayoutPanel29.SuspendLayout();
            flowLayoutPanel32.SuspendLayout();
            tableLayoutPanel30.SuspendLayout();
            flowLayoutPanel33.SuspendLayout();
            tableLayoutPanel31.SuspendLayout();
            bestBookPanel.SuspendLayout();
            flowLayoutPanel34.SuspendLayout();
            tableLayoutPanel32.SuspendLayout();
            flowLayoutPanel35.SuspendLayout();
            tableLayoutPanel33.SuspendLayout();
            flowLayoutPanel36.SuspendLayout();
            tableLayoutPanel34.SuspendLayout();
            flowLayoutPanel37.SuspendLayout();
            tableLayoutPanel35.SuspendLayout();
            flowLayoutPanel38.SuspendLayout();
            tableLayoutPanel36.SuspendLayout();
            flowLayoutPanel39.SuspendLayout();
            tableLayoutPanel37.SuspendLayout();
            searchFlowPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            searchLayoutTable.SuspendLayout();
            searchBoxContainer.SuspendLayout();
            bestMatchPanel.SuspendLayout();
            bestMatchResult.SuspendLayout();
            bestMatchTableLayout.SuspendLayout();
            flowLayoutPanel49.SuspendLayout();
            tableLayoutPanel45.SuspendLayout();
            flowLayoutPanel61.SuspendLayout();
            flowLayoutPanel62.SuspendLayout();
            tableLayoutPanel56.SuspendLayout();
            flowLayoutPanel63.SuspendLayout();
            tableLayoutPanel57.SuspendLayout();
            flowLayoutPanel64.SuspendLayout();
            tableLayoutPanel58.SuspendLayout();
            flowLayoutPanel65.SuspendLayout();
            tableLayoutPanel59.SuspendLayout();
            flowLayoutPanel66.SuspendLayout();
            tableLayoutPanel60.SuspendLayout();
            flowLayoutPanel67.SuspendLayout();
            tableLayoutPanel61.SuspendLayout();
            currentPanel.SuspendLayout();
            currentProperties.SuspendLayout();
            currentPropertiesTable.SuspendLayout();
            currentBookPanel.SuspendLayout();
            currentPagePanel.SuspendLayout();
            currentPublisherPanel.SuspendLayout();
            optionPanel.SuspendLayout();
            optionsFlowPanel.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            flowLayoutPanel12.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            flowLayoutPanel14.SuspendLayout();
            flowLayoutPanel15.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            flowLayoutPanel16.SuspendLayout();
            tableLayoutPanel15.SuspendLayout();
            flowLayoutPanel17.SuspendLayout();
            tableLayoutPanel16.SuspendLayout();
            flowLayoutPanel18.SuspendLayout();
            tableLayoutPanel17.SuspendLayout();
            flowLayoutPanel19.SuspendLayout();
            tableLayoutPanel18.SuspendLayout();
            tableLayoutPanel19.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel40.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // searchTabeLayout
            // 
            searchTabeLayout.BackColor = Color.Transparent;
            searchTabeLayout.ColumnCount = 3;
            searchTabeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchTabeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 750F));
            searchTabeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            searchTabeLayout.Controls.Add(verticalMenuBar, 2, 0);
            searchTabeLayout.Controls.Add(contentPanel, 0, 0);
            searchTabeLayout.Controls.Add(mainFlowPanel, 1, 0);
            searchTabeLayout.Controls.Add(currentPanel, 2, 1);
            searchTabeLayout.Controls.Add(currentProperties, 1, 1);
            searchTabeLayout.Controls.Add(optionPanel, 0, 1);
            searchTabeLayout.Dock = DockStyle.Fill;
            searchTabeLayout.Location = new Point(0, 0);
            searchTabeLayout.Margin = new Padding(0, 500, 0, 0);
            searchTabeLayout.Name = "searchTabeLayout";
            searchTabeLayout.RowCount = 2;
            searchTabeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            searchTabeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            searchTabeLayout.Size = new Size(1280, 846);
            searchTabeLayout.TabIndex = 0;
            // 
            // verticalMenuBar
            // 
            verticalMenuBar.Controls.Add(userLabel);
            verticalMenuBar.Controls.Add(verticalTableMenu);
            verticalMenuBar.Dock = DockStyle.Fill;
            verticalMenuBar.FlowDirection = FlowDirection.TopDown;
            verticalMenuBar.Location = new Point(1180, 0);
            verticalMenuBar.Margin = new Padding(0);
            verticalMenuBar.Name = "verticalMenuBar";
            verticalMenuBar.Size = new Size(100, 746);
            verticalMenuBar.TabIndex = 1;
            verticalMenuBar.WrapContents = false;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            // 
            // userLabel
            // 
            userLabel.BackColor = Color.DimGray;
            userLabel.Image = (Image)resources.GetObject("userLabel.Image");
            userLabel.Location = new Point(0, 30);
            userLabel.Margin = new Padding(0, 30, 0, 0);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(90, 90);
            userLabel.TabIndex = 0;
            toolTip1.SetToolTip(userLabel, "user");
            // 
            // verticalTableMenu
            // 
            verticalTableMenu.ColumnCount = 1;
            verticalTableMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            verticalTableMenu.Controls.Add(bottomBlank, 0, 6);
            verticalTableMenu.Controls.Add(topBlank, 0, 0);
            verticalTableMenu.Controls.Add(homeGradientPanel, 0, 1);
            verticalTableMenu.Controls.Add(searchGradientPanel, 0, 2);
            verticalTableMenu.Controls.Add(heartGradientPanel, 0, 3);
            verticalTableMenu.Controls.Add(libraryGradientPanel, 0, 4);
            verticalTableMenu.Controls.Add(recentGradientPanel, 0, 5);
            verticalTableMenu.Dock = DockStyle.Bottom;
            verticalTableMenu.Location = new Point(0, 120);
            verticalTableMenu.Margin = new Padding(0);
            verticalTableMenu.Name = "verticalTableMenu";
            verticalTableMenu.RowCount = 7;
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            verticalTableMenu.Size = new Size(90, 635);
            verticalTableMenu.TabIndex = 1;
            // 
            // bottomBlank
            // 
            bottomBlank.Dock = DockStyle.Fill;
            bottomBlank.GradientAngle = 90F;
            bottomBlank.GradientPrimaryColor = Color.White;
            bottomBlank.GradientSecondaryColor = Color.Black;
            bottomBlank.Location = new Point(0, 405);
            bottomBlank.Margin = new Padding(0);
            bottomBlank.Name = "bottomBlank";
            bottomBlank.Size = new Size(90, 230);
            bottomBlank.TabIndex = 6;
            // 
            // topBlank
            // 
            topBlank.Dock = DockStyle.Fill;
            topBlank.GradientAngle = 90F;
            topBlank.GradientPrimaryColor = Color.Black;
            topBlank.GradientSecondaryColor = Color.AliceBlue;
            topBlank.Location = new Point(0, 0);
            topBlank.Margin = new Padding(0);
            topBlank.Name = "topBlank";
            topBlank.Size = new Size(90, 50);
            topBlank.TabIndex = 7;
            // 
            // homeGradientPanel
            // 
            homeGradientPanel.Controls.Add(homeLabel);
            homeGradientPanel.Dock = DockStyle.Fill;
            homeGradientPanel.GradientAngle = 90F;
            homeGradientPanel.GradientPrimaryColor = Color.White;
            homeGradientPanel.GradientSecondaryColor = Color.Empty;
            homeGradientPanel.Location = new Point(0, 50);
            homeGradientPanel.Margin = new Padding(0);
            homeGradientPanel.Name = "homeGradientPanel";
            homeGradientPanel.Size = new Size(90, 71);
            homeGradientPanel.TabIndex = 8;
            // 
            // homeLabel
            // 
            homeLabel.Dock = DockStyle.Fill;
            homeLabel.Image = (Image)resources.GetObject("homeLabel.Image");
            homeLabel.Location = new Point(0, 0);
            homeLabel.Margin = new Padding(0);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(90, 71);
            homeLabel.TabIndex = 3;
            toolTip1.SetToolTip(homeLabel, "Home");
            homeLabel.Click += homeLabel_Click;
            // 
            // searchGradientPanel
            // 
            searchGradientPanel.Controls.Add(searchLabel);
            searchGradientPanel.Dock = DockStyle.Fill;
            searchGradientPanel.GradientAngle = 90F;
            searchGradientPanel.GradientPrimaryColor = Color.White;
            searchGradientPanel.GradientSecondaryColor = Color.Empty;
            searchGradientPanel.Location = new Point(0, 121);
            searchGradientPanel.Margin = new Padding(0);
            searchGradientPanel.Name = "searchGradientPanel";
            searchGradientPanel.Size = new Size(90, 71);
            searchGradientPanel.TabIndex = 9;
            // 
            // searchLabel
            // 
            searchLabel.Dock = DockStyle.Fill;
            searchLabel.Image = (Image)resources.GetObject("searchLabel.Image");
            searchLabel.Location = new Point(0, 0);
            searchLabel.Margin = new Padding(0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(90, 71);
            searchLabel.TabIndex = 1;
            searchLabel.Click += searchLabel_Click;
            // 
            // heartGradientPanel
            // 
            heartGradientPanel.Controls.Add(heartLabel);
            heartGradientPanel.Dock = DockStyle.Fill;
            heartGradientPanel.GradientAngle = 90F;
            heartGradientPanel.GradientPrimaryColor = Color.White;
            heartGradientPanel.GradientSecondaryColor = Color.Empty;
            heartGradientPanel.Location = new Point(0, 192);
            heartGradientPanel.Margin = new Padding(0);
            heartGradientPanel.Name = "heartGradientPanel";
            heartGradientPanel.Size = new Size(90, 71);
            heartGradientPanel.TabIndex = 10;
            // 
            // heartLabel
            // 
            heartLabel.BackColor = Color.Transparent;
            heartLabel.Dock = DockStyle.Fill;
            heartLabel.Image = (Image)resources.GetObject("heartLabel.Image");
            heartLabel.Location = new Point(0, 0);
            heartLabel.Margin = new Padding(0);
            heartLabel.Name = "heartLabel";
            heartLabel.Size = new Size(90, 71);
            heartLabel.TabIndex = 2;
            heartLabel.Click += heartLabel_Click;
            // 
            // libraryGradientPanel
            // 
            libraryGradientPanel.Controls.Add(librariesLabel);
            libraryGradientPanel.Dock = DockStyle.Fill;
            libraryGradientPanel.GradientAngle = 90F;
            libraryGradientPanel.GradientPrimaryColor = Color.White;
            libraryGradientPanel.GradientSecondaryColor = Color.Empty;
            libraryGradientPanel.Location = new Point(0, 263);
            libraryGradientPanel.Margin = new Padding(0);
            libraryGradientPanel.Name = "libraryGradientPanel";
            libraryGradientPanel.Size = new Size(90, 71);
            libraryGradientPanel.TabIndex = 11;
            // 
            // librariesLabel
            // 
            librariesLabel.BackColor = Color.Transparent;
            librariesLabel.Dock = DockStyle.Fill;
            librariesLabel.Image = (Image)resources.GetObject("librariesLabel.Image");
            librariesLabel.Location = new Point(0, 0);
            librariesLabel.Margin = new Padding(0);
            librariesLabel.Name = "librariesLabel";
            librariesLabel.Size = new Size(90, 71);
            librariesLabel.TabIndex = 4;
            librariesLabel.Click += librariesLabel_Click;
            // 
            // recentGradientPanel
            // 
            recentGradientPanel.Controls.Add(recentLabel);
            recentGradientPanel.Dock = DockStyle.Fill;
            recentGradientPanel.GradientAngle = 90F;
            recentGradientPanel.GradientPrimaryColor = Color.White;
            recentGradientPanel.GradientSecondaryColor = Color.Empty;
            recentGradientPanel.Location = new Point(0, 334);
            recentGradientPanel.Margin = new Padding(0);
            recentGradientPanel.Name = "recentGradientPanel";
            recentGradientPanel.Size = new Size(90, 71);
            recentGradientPanel.TabIndex = 12;
            // 
            // recentLabel
            // 
            recentLabel.BackColor = Color.Transparent;
            recentLabel.Dock = DockStyle.Fill;
            recentLabel.Image = (Image)resources.GetObject("recentLabel.Image");
            recentLabel.Location = new Point(0, 0);
            recentLabel.Margin = new Padding(0);
            recentLabel.Name = "recentLabel";
            recentLabel.Size = new Size(90, 71);
            recentLabel.TabIndex = 5;
            recentLabel.Click += recentLabel_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.Black;
            contentPanel.Controls.Add(contentContainer);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(3, 3);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(424, 740);
            contentPanel.TabIndex = 3;
            // 
            // contentContainer
            // 
            contentContainer.AutoScroll = true;
            contentContainer.Controls.Add(contentImg);
            contentContainer.Controls.Add(contentTitle);
            contentContainer.Controls.Add(authorLabel);
            contentContainer.Controls.Add(publisherLabel);
            contentContainer.Controls.Add(aboutAuthor);
            contentContainer.Controls.Add(authorDesLabel);
            contentContainer.Controls.Add(categoryLabel);
            contentContainer.Controls.Add(category0);
            contentContainer.Location = new Point(0, 0);
            contentContainer.Margin = new Padding(0);
            contentContainer.Name = "contentContainer";
            contentContainer.Size = new Size(450, 762);
            contentContainer.TabIndex = 0;
            contentContainer.Paint += contentContainer_Paint;
            // 
            // contentImg
            // 
            contentImg.BackColor = Color.Transparent;
            contentImg.Image = (Image)resources.GetObject("contentImg.Image");
            contentImg.Location = new Point(30, 50);
            contentImg.Margin = new Padding(30, 50, 30, 30);
            contentImg.Name = "contentImg";
            contentImg.Size = new Size(352, 394);
            contentImg.TabIndex = 1;
            // 
            // contentTitle
            // 
            contentTitle.AutoEllipsis = true;
            contentTitle.AutoSize = true;
            contentTitle.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(contentTitle, true);
            contentTitle.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            contentTitle.ForeColor = SystemColors.ControlLight;
            contentTitle.Location = new Point(3, 474);
            contentTitle.Name = "contentTitle";
            contentTitle.Size = new Size(77, 40);
            contentTitle.TabIndex = 2;
            contentTitle.Text = "Title";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(authorLabel, true);
            authorLabel.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            authorLabel.ForeColor = SystemColors.ControlDark;
            authorLabel.Location = new Point(3, 514);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(79, 28);
            authorLabel.TabIndex = 3;
            authorLabel.Text = "Author";
            // 
            // publisherLabel
            // 
            publisherLabel.AutoSize = true;
            publisherLabel.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(publisherLabel, true);
            publisherLabel.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            publisherLabel.ForeColor = SystemColors.ControlDark;
            publisherLabel.Location = new Point(3, 542);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.Size = new Size(102, 28);
            publisherLabel.TabIndex = 0;
            publisherLabel.Text = "Publisher";
            // 
            // aboutAuthor
            // 
            aboutAuthor.AutoEllipsis = true;
            aboutAuthor.AutoSize = true;
            aboutAuthor.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(aboutAuthor, true);
            aboutAuthor.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            aboutAuthor.ForeColor = SystemColors.ControlLight;
            aboutAuthor.Location = new Point(3, 582);
            aboutAuthor.Name = "aboutAuthor";
            aboutAuthor.Size = new Size(191, 40);
            aboutAuthor.TabIndex = 4;
            aboutAuthor.Text = "About author";
            // 
            // authorDesLabel
            // 
            authorDesLabel.AutoSize = true;
            authorDesLabel.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(authorDesLabel, true);
            authorDesLabel.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            authorDesLabel.ForeColor = SystemColors.ControlDark;
            authorDesLabel.Location = new Point(3, 622);
            authorDesLabel.Name = "authorDesLabel";
            authorDesLabel.Size = new Size(120, 28);
            authorDesLabel.TabIndex = 5;
            authorDesLabel.Text = "Description";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoEllipsis = true;
            categoryLabel.AutoSize = true;
            categoryLabel.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(categoryLabel, true);
            categoryLabel.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            categoryLabel.ForeColor = SystemColors.ControlLight;
            categoryLabel.Location = new Point(3, 662);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(285, 40);
            categoryLabel.TabIndex = 6;
            categoryLabel.Text = "Publisher's category";
            // 
            // category0
            // 
            category0.Controls.Add(tableLayoutPanel1);
            category0.Controls.Add(flowLayoutPanel40);
            category0.Location = new Point(3, 705);
            category0.Margin = new Padding(3, 3, 3, 15);
            category0.Name = "category0";
            category0.Size = new Size(352, 88);
            category0.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label39, 1, 0);
            tableLayoutPanel1.Controls.Add(label76, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.Size = new Size(346, 88);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label39
            // 
            label39.BackColor = Color.Gray;
            label39.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label39.ForeColor = SystemColors.ControlLight;
            label39.Location = new Point(91, 0);
            label39.Name = "label39";
            label39.Size = new Size(252, 88);
            label39.TabIndex = 1;
            label39.Text = "title";
            // 
            // label76
            // 
            label76.BackColor = Color.DimGray;
            label76.Image = (Image)resources.GetObject("label76.Image");
            label76.Location = new Point(3, 0);
            label76.Name = "label76";
            label76.Size = new Size(82, 88);
            label76.TabIndex = 0;
            // 
            // flowLayoutPanel40
            // 
            flowLayoutPanel40.Controls.Add(tableLayoutPanel39);
            flowLayoutPanel40.Location = new Point(3, 97);
            flowLayoutPanel40.Name = "flowLayoutPanel40";
            flowLayoutPanel40.Size = new Size(370, 88);
            flowLayoutPanel40.TabIndex = 2;
            // 
            // tableLayoutPanel39
            // 
            tableLayoutPanel39.AutoSize = true;
            tableLayoutPanel39.ColumnCount = 2;
            tableLayoutPanel39.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel39.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel39.Controls.Add(label77, 1, 0);
            tableLayoutPanel39.Controls.Add(label78, 0, 0);
            tableLayoutPanel39.Location = new Point(3, 3);
            tableLayoutPanel39.Name = "tableLayoutPanel39";
            tableLayoutPanel39.RowCount = 1;
            tableLayoutPanel39.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel39.Size = new Size(362, 88);
            tableLayoutPanel39.TabIndex = 0;
            // 
            // label77
            // 
            label77.BackColor = Color.Gray;
            label77.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label77.ForeColor = SystemColors.ControlLight;
            label77.Location = new Point(91, 0);
            label77.Name = "label77";
            label77.Size = new Size(268, 88);
            label77.TabIndex = 1;
            label77.Text = "label77";
            // 
            // label78
            // 
            label78.BackColor = Color.DimGray;
            label78.Image = (Image)resources.GetObject("label78.Image");
            label78.Location = new Point(3, 0);
            label78.Name = "label78";
            label78.Size = new Size(82, 88);
            label78.TabIndex = 0;
            // 
            // mainFlowPanel
            // 
            mainFlowPanel.AutoScroll = true;
            mainFlowPanel.Controls.Add(homeFlowPanel);
            mainFlowPanel.Controls.Add(searchFlowPanel);
            mainFlowPanel.Dock = DockStyle.Fill;
            mainFlowPanel.Location = new Point(430, 0);
            mainFlowPanel.Margin = new Padding(0);
            mainFlowPanel.Name = "mainFlowPanel";
            mainFlowPanel.Size = new Size(750, 746);
            mainFlowPanel.TabIndex = 4;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            // 
            // homeFlowPanel
            // 
            homeFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            homeFlowPanel.AutoScroll = true;
            homeFlowPanel.Controls.Add(helloPanel);
            homeFlowPanel.Controls.Add(recommentPanel);
            homeFlowPanel.Controls.Add(recentPanel);
            homeFlowPanel.Controls.Add(bestBookPanel);
            homeFlowPanel.Location = new Point(0, 0);
            homeFlowPanel.Margin = new Padding(0);
            homeFlowPanel.Name = "homeFlowPanel";
            homeFlowPanel.Size = new Size(767, 765);
            homeFlowPanel.TabIndex = 0;
            // 
            // helloPanel
            // 
            helloPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            helloPanel.AutoSize = true;
            helloPanel.Controls.Add(helloLabel);
            helloPanel.Controls.Add(helloElement0);
            helloPanel.Controls.Add(helloElement1);
            helloPanel.Controls.Add(helloElement2);
            helloPanel.Controls.Add(helloElement3);
            homeFlowPanel.SetFlowBreak(helloPanel, true);
            helloPanel.Location = new Point(0, 27);
            helloPanel.Margin = new Padding(0, 27, 0, 0);
            helloPanel.Name = "helloPanel";
            helloPanel.Size = new Size(741, 270);
            helloPanel.TabIndex = 0;
            helloPanel.Paint += helloPanel_Paint;
            // 
            // helloLabel
            // 
            helloPanel.SetFlowBreak(helloLabel, true);
            helloLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            helloLabel.ForeColor = SystemColors.ControlLightLight;
            helloLabel.Location = new Point(3, 0);
            helloLabel.Name = "helloLabel";
            helloLabel.Size = new Size(735, 82);
            helloLabel.TabIndex = 0;
            helloLabel.Text = "Hello!";
            // 
            // helloElement0
            // 
            helloElement0.BackColor = Color.Transparent;
            helloElement0.Controls.Add(helloElementTable0);
            helloElement0.GradientAngle = 60F;
            helloElement0.GradientPrimaryColor = Color.Transparent;
            helloElement0.GradientSecondaryColor = Color.White;
            helloElement0.Location = new Point(3, 85);
            helloElement0.Name = "helloElement0";
            helloElement0.Size = new Size(349, 88);
            helloElement0.TabIndex = 4;
            // 
            // helloElementTable0
            // 
            helloElementTable0.AutoSize = true;
            helloElementTable0.ColumnCount = 2;
            helloElementTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            helloElementTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            helloElementTable0.Controls.Add(helloElementImg0, 0, 0);
            helloElementTable0.Controls.Add(helloFlow0, 1, 0);
            helloElementTable0.Dock = DockStyle.Fill;
            helloElementTable0.Location = new Point(0, 0);
            helloElementTable0.Name = "helloElementTable0";
            helloElementTable0.RowCount = 1;
            helloElementTable0.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            helloElementTable0.Size = new Size(349, 88);
            helloElementTable0.TabIndex = 0;
            // 
            // helloElementImg0
            // 
            helloElementImg0.BackColor = Color.Transparent;
            helloElementImg0.Image = (Image)resources.GetObject("helloElementImg0.Image");
            helloElementImg0.Location = new Point(3, 0);
            helloElementImg0.Name = "helloElementImg0";
            helloElementImg0.Size = new Size(82, 88);
            helloElementImg0.TabIndex = 0;
            // 
            // helloFlow0
            // 
            helloFlow0.AutoSize = true;
            helloFlow0.Controls.Add(helloElementTitle0);
            helloFlow0.Controls.Add(helloAuthor0);
            helloFlow0.Dock = DockStyle.Fill;
            helloFlow0.Location = new Point(91, 3);
            helloFlow0.Name = "helloFlow0";
            helloFlow0.Size = new Size(255, 82);
            helloFlow0.TabIndex = 1;
            // 
            // helloElementTitle0
            // 
            helloElementTitle0.AutoSize = true;
            helloElementTitle0.BackColor = Color.Transparent;
            helloFlow0.SetFlowBreak(helloElementTitle0, true);
            helloElementTitle0.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            helloElementTitle0.ForeColor = SystemColors.ControlLight;
            helloElementTitle0.Location = new Point(3, 0);
            helloElementTitle0.Name = "helloElementTitle0";
            helloElementTitle0.Size = new Size(50, 28);
            helloElementTitle0.TabIndex = 1;
            helloElementTitle0.Text = "title";
            // 
            // helloAuthor0
            // 
            helloAuthor0.AutoSize = true;
            helloAuthor0.BackColor = Color.Transparent;
            helloFlow0.SetFlowBreak(helloAuthor0, true);
            helloAuthor0.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            helloAuthor0.ForeColor = SystemColors.ControlLight;
            helloAuthor0.Location = new Point(3, 28);
            helloAuthor0.Name = "helloAuthor0";
            helloAuthor0.Size = new Size(50, 19);
            helloAuthor0.TabIndex = 2;
            helloAuthor0.Text = "author";
            // 
            // helloElement1
            // 
            helloElement1.Controls.Add(helloElementTable1);
            helloElement1.GradientAngle = 60F;
            helloElement1.GradientPrimaryColor = Color.Transparent;
            helloElement1.GradientSecondaryColor = Color.White;
            helloElement1.Location = new Point(358, 85);
            helloElement1.Name = "helloElement1";
            helloElement1.Size = new Size(349, 88);
            helloElement1.TabIndex = 5;
            // 
            // helloElementTable1
            // 
            helloElementTable1.AutoSize = true;
            helloElementTable1.ColumnCount = 2;
            helloElementTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            helloElementTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            helloElementTable1.Controls.Add(helloElementImg1, 0, 0);
            helloElementTable1.Controls.Add(flowLayoutPanel1, 1, 0);
            helloElementTable1.Dock = DockStyle.Fill;
            helloElementTable1.Location = new Point(0, 0);
            helloElementTable1.Name = "helloElementTable1";
            helloElementTable1.RowCount = 1;
            helloElementTable1.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            helloElementTable1.Size = new Size(349, 88);
            helloElementTable1.TabIndex = 0;
            // 
            // helloElementImg1
            // 
            helloElementImg1.BackColor = Color.Transparent;
            helloElementImg1.Image = (Image)resources.GetObject("helloElementImg1.Image");
            helloElementImg1.Location = new Point(3, 0);
            helloElementImg1.Name = "helloElementImg1";
            helloElementImg1.Size = new Size(82, 88);
            helloElementImg1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(helloElementTitle1);
            flowLayoutPanel1.Controls.Add(helloAuthor1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(91, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(255, 82);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // helloElementTitle1
            // 
            helloElementTitle1.AutoSize = true;
            helloElementTitle1.BackColor = Color.Transparent;
            flowLayoutPanel1.SetFlowBreak(helloElementTitle1, true);
            helloElementTitle1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            helloElementTitle1.ForeColor = SystemColors.ControlLight;
            helloElementTitle1.Location = new Point(3, 0);
            helloElementTitle1.Name = "helloElementTitle1";
            helloElementTitle1.Size = new Size(50, 28);
            helloElementTitle1.TabIndex = 1;
            helloElementTitle1.Text = "title";
            // 
            // helloAuthor1
            // 
            helloAuthor1.AutoSize = true;
            helloAuthor1.BackColor = Color.Transparent;
            flowLayoutPanel1.SetFlowBreak(helloAuthor1, true);
            helloAuthor1.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            helloAuthor1.ForeColor = SystemColors.ControlLight;
            helloAuthor1.Location = new Point(3, 28);
            helloAuthor1.Name = "helloAuthor1";
            helloAuthor1.Size = new Size(50, 19);
            helloAuthor1.TabIndex = 3;
            helloAuthor1.Text = "author";
            // 
            // helloElement2
            // 
            helloElement2.Controls.Add(helloElementTable2);
            helloElement2.GradientAngle = 60F;
            helloElement2.GradientPrimaryColor = Color.Transparent;
            helloElement2.GradientSecondaryColor = Color.White;
            helloElement2.Location = new Point(3, 179);
            helloElement2.Name = "helloElement2";
            helloElement2.Size = new Size(349, 88);
            helloElement2.TabIndex = 6;
            // 
            // helloElementTable2
            // 
            helloElementTable2.AutoSize = true;
            helloElementTable2.ColumnCount = 2;
            helloElementTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            helloElementTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            helloElementTable2.Controls.Add(helloElementImg2, 0, 0);
            helloElementTable2.Controls.Add(helloFlow2, 1, 0);
            helloElementTable2.Dock = DockStyle.Fill;
            helloElementTable2.Location = new Point(0, 0);
            helloElementTable2.Name = "helloElementTable2";
            helloElementTable2.RowCount = 1;
            helloElementTable2.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            helloElementTable2.Size = new Size(349, 88);
            helloElementTable2.TabIndex = 0;
            // 
            // helloElementImg2
            // 
            helloElementImg2.BackColor = Color.Transparent;
            helloElementImg2.Image = (Image)resources.GetObject("helloElementImg2.Image");
            helloElementImg2.Location = new Point(3, 0);
            helloElementImg2.Name = "helloElementImg2";
            helloElementImg2.Size = new Size(82, 88);
            helloElementImg2.TabIndex = 0;
            // 
            // helloFlow2
            // 
            helloFlow2.Controls.Add(helloElementTitle2);
            helloFlow2.Controls.Add(helloAuthor2);
            helloFlow2.Dock = DockStyle.Fill;
            helloFlow2.Location = new Point(91, 3);
            helloFlow2.Name = "helloFlow2";
            helloFlow2.Size = new Size(255, 82);
            helloFlow2.TabIndex = 1;
            // 
            // helloElementTitle2
            // 
            helloElementTitle2.AutoSize = true;
            helloElementTitle2.BackColor = Color.Transparent;
            helloFlow2.SetFlowBreak(helloElementTitle2, true);
            helloElementTitle2.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            helloElementTitle2.ForeColor = SystemColors.ControlLight;
            helloElementTitle2.Location = new Point(3, 0);
            helloElementTitle2.Name = "helloElementTitle2";
            helloElementTitle2.Size = new Size(50, 28);
            helloElementTitle2.TabIndex = 1;
            helloElementTitle2.Text = "title";
            // 
            // helloAuthor2
            // 
            helloAuthor2.AutoSize = true;
            helloAuthor2.BackColor = Color.Transparent;
            helloFlow2.SetFlowBreak(helloAuthor2, true);
            helloAuthor2.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            helloAuthor2.ForeColor = SystemColors.ControlLight;
            helloAuthor2.Location = new Point(3, 28);
            helloAuthor2.Name = "helloAuthor2";
            helloAuthor2.Size = new Size(50, 19);
            helloAuthor2.TabIndex = 4;
            helloAuthor2.Text = "author";
            // 
            // helloElement3
            // 
            helloElement3.Controls.Add(helloElementTable3);
            helloElement3.GradientAngle = 60F;
            helloElement3.GradientPrimaryColor = Color.Transparent;
            helloElement3.GradientSecondaryColor = Color.White;
            helloElement3.Location = new Point(358, 179);
            helloElement3.Name = "helloElement3";
            helloElement3.Size = new Size(349, 88);
            helloElement3.TabIndex = 7;
            // 
            // helloElementTable3
            // 
            helloElementTable3.AutoSize = true;
            helloElementTable3.ColumnCount = 2;
            helloElementTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            helloElementTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            helloElementTable3.Controls.Add(helloElementImg3, 0, 0);
            helloElementTable3.Controls.Add(helloFlow3, 1, 0);
            helloElementTable3.Dock = DockStyle.Fill;
            helloElementTable3.Location = new Point(0, 0);
            helloElementTable3.Name = "helloElementTable3";
            helloElementTable3.RowCount = 1;
            helloElementTable3.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            helloElementTable3.Size = new Size(349, 88);
            helloElementTable3.TabIndex = 0;
            // 
            // helloElementImg3
            // 
            helloElementImg3.BackColor = Color.Transparent;
            helloElementImg3.Image = (Image)resources.GetObject("helloElementImg3.Image");
            helloElementImg3.Location = new Point(3, 0);
            helloElementImg3.Name = "helloElementImg3";
            helloElementImg3.Size = new Size(82, 88);
            helloElementImg3.TabIndex = 0;
            // 
            // helloFlow3
            // 
            helloFlow3.Controls.Add(helloElementTitle3);
            helloFlow3.Controls.Add(helloAuthor3);
            helloFlow3.Dock = DockStyle.Fill;
            helloFlow3.Location = new Point(91, 3);
            helloFlow3.Name = "helloFlow3";
            helloFlow3.Size = new Size(255, 82);
            helloFlow3.TabIndex = 1;
            // 
            // helloElementTitle3
            // 
            helloElementTitle3.AutoSize = true;
            helloElementTitle3.BackColor = Color.Transparent;
            helloFlow3.SetFlowBreak(helloElementTitle3, true);
            helloElementTitle3.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            helloElementTitle3.ForeColor = SystemColors.ControlLight;
            helloElementTitle3.Location = new Point(3, 0);
            helloElementTitle3.Name = "helloElementTitle3";
            helloElementTitle3.Size = new Size(50, 28);
            helloElementTitle3.TabIndex = 1;
            helloElementTitle3.Text = "title";
            // 
            // helloAuthor3
            // 
            helloAuthor3.AutoSize = true;
            helloAuthor3.BackColor = Color.Transparent;
            helloFlow3.SetFlowBreak(helloAuthor3, true);
            helloAuthor3.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            helloAuthor3.ForeColor = SystemColors.ControlLight;
            helloAuthor3.Location = new Point(3, 28);
            helloAuthor3.Name = "helloAuthor3";
            helloAuthor3.Size = new Size(50, 19);
            helloAuthor3.TabIndex = 5;
            helloAuthor3.Text = "author";
            // 
            // recommentPanel
            // 
            recommentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recommentPanel.AutoSize = true;
            recommentPanel.Controls.Add(recommentLabel);
            recommentPanel.Controls.Add(flowLayoutPanel22);
            recommentPanel.Controls.Add(flowLayoutPanel24);
            recommentPanel.Controls.Add(flowLayoutPanel26);
            homeFlowPanel.SetFlowBreak(recommentPanel, true);
            recommentPanel.Location = new Point(3, 300);
            recommentPanel.Margin = new Padding(3, 3, 3, 30);
            recommentPanel.Name = "recommentPanel";
            recommentPanel.Size = new Size(741, 270);
            recommentPanel.TabIndex = 1;
            // 
            // recommentLabel
            // 
            recommentPanel.SetFlowBreak(recommentLabel, true);
            recommentLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            recommentLabel.ForeColor = SystemColors.ControlLightLight;
            recommentLabel.Location = new Point(3, 0);
            recommentLabel.Name = "recommentLabel";
            recommentLabel.Size = new Size(735, 82);
            recommentLabel.TabIndex = 0;
            recommentLabel.Text = "Made for you";
            // 
            // flowLayoutPanel22
            // 
            flowLayoutPanel22.Controls.Add(tableLayoutPanel20);
            flowLayoutPanel22.Controls.Add(flowLayoutPanel23);
            flowLayoutPanel22.Location = new Point(3, 85);
            flowLayoutPanel22.Name = "flowLayoutPanel22";
            flowLayoutPanel22.Size = new Size(352, 88);
            flowLayoutPanel22.TabIndex = 1;
            // 
            // tableLayoutPanel20
            // 
            tableLayoutPanel20.AutoSize = true;
            tableLayoutPanel20.ColumnCount = 2;
            tableLayoutPanel20.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel20.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel20.Controls.Add(label40, 1, 0);
            tableLayoutPanel20.Controls.Add(label41, 0, 0);
            tableLayoutPanel20.Location = new Point(3, 3);
            tableLayoutPanel20.Name = "tableLayoutPanel20";
            tableLayoutPanel20.RowCount = 1;
            tableLayoutPanel20.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel20.Size = new Size(346, 88);
            tableLayoutPanel20.TabIndex = 0;
            // 
            // label40
            // 
            label40.BackColor = Color.Gray;
            label40.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label40.ForeColor = SystemColors.ControlLight;
            label40.Location = new Point(91, 0);
            label40.Name = "label40";
            label40.Size = new Size(252, 88);
            label40.TabIndex = 1;
            label40.Text = "title";
            // 
            // label41
            // 
            label41.BackColor = Color.DimGray;
            label41.Image = (Image)resources.GetObject("label41.Image");
            label41.Location = new Point(3, 0);
            label41.Name = "label41";
            label41.Size = new Size(82, 88);
            label41.TabIndex = 0;
            // 
            // flowLayoutPanel23
            // 
            flowLayoutPanel23.Controls.Add(tableLayoutPanel21);
            flowLayoutPanel23.Location = new Point(3, 97);
            flowLayoutPanel23.Name = "flowLayoutPanel23";
            flowLayoutPanel23.Size = new Size(370, 88);
            flowLayoutPanel23.TabIndex = 2;
            // 
            // tableLayoutPanel21
            // 
            tableLayoutPanel21.AutoSize = true;
            tableLayoutPanel21.ColumnCount = 2;
            tableLayoutPanel21.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel21.Controls.Add(label42, 1, 0);
            tableLayoutPanel21.Controls.Add(label43, 0, 0);
            tableLayoutPanel21.Location = new Point(3, 3);
            tableLayoutPanel21.Name = "tableLayoutPanel21";
            tableLayoutPanel21.RowCount = 1;
            tableLayoutPanel21.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel21.Size = new Size(362, 88);
            tableLayoutPanel21.TabIndex = 0;
            // 
            // label42
            // 
            label42.BackColor = Color.Gray;
            label42.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label42.ForeColor = SystemColors.ControlLight;
            label42.Location = new Point(91, 0);
            label42.Name = "label42";
            label42.Size = new Size(268, 88);
            label42.TabIndex = 1;
            label42.Text = "label42";
            // 
            // label43
            // 
            label43.BackColor = Color.DimGray;
            label43.Image = (Image)resources.GetObject("label43.Image");
            label43.Location = new Point(3, 0);
            label43.Name = "label43";
            label43.Size = new Size(82, 88);
            label43.TabIndex = 0;
            // 
            // flowLayoutPanel24
            // 
            flowLayoutPanel24.Controls.Add(tableLayoutPanel22);
            flowLayoutPanel24.Controls.Add(flowLayoutPanel25);
            flowLayoutPanel24.Location = new Point(361, 85);
            flowLayoutPanel24.Name = "flowLayoutPanel24";
            flowLayoutPanel24.Size = new Size(352, 88);
            flowLayoutPanel24.TabIndex = 2;
            // 
            // tableLayoutPanel22
            // 
            tableLayoutPanel22.AutoSize = true;
            tableLayoutPanel22.ColumnCount = 2;
            tableLayoutPanel22.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel22.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel22.Controls.Add(label44, 1, 0);
            tableLayoutPanel22.Controls.Add(label45, 0, 0);
            tableLayoutPanel22.Location = new Point(3, 3);
            tableLayoutPanel22.Name = "tableLayoutPanel22";
            tableLayoutPanel22.RowCount = 1;
            tableLayoutPanel22.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel22.Size = new Size(346, 88);
            tableLayoutPanel22.TabIndex = 0;
            // 
            // label44
            // 
            label44.BackColor = Color.Gray;
            label44.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label44.ForeColor = SystemColors.ControlLight;
            label44.Location = new Point(91, 0);
            label44.Name = "label44";
            label44.Size = new Size(252, 88);
            label44.TabIndex = 1;
            label44.Text = "title";
            // 
            // label45
            // 
            label45.BackColor = Color.DimGray;
            label45.Image = (Image)resources.GetObject("label45.Image");
            label45.Location = new Point(3, 0);
            label45.Name = "label45";
            label45.Size = new Size(82, 88);
            label45.TabIndex = 0;
            // 
            // flowLayoutPanel25
            // 
            flowLayoutPanel25.Controls.Add(tableLayoutPanel23);
            flowLayoutPanel25.Location = new Point(3, 97);
            flowLayoutPanel25.Name = "flowLayoutPanel25";
            flowLayoutPanel25.Size = new Size(370, 88);
            flowLayoutPanel25.TabIndex = 2;
            // 
            // tableLayoutPanel23
            // 
            tableLayoutPanel23.AutoSize = true;
            tableLayoutPanel23.ColumnCount = 2;
            tableLayoutPanel23.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel23.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel23.Controls.Add(label46, 1, 0);
            tableLayoutPanel23.Controls.Add(label47, 0, 0);
            tableLayoutPanel23.Location = new Point(3, 3);
            tableLayoutPanel23.Name = "tableLayoutPanel23";
            tableLayoutPanel23.RowCount = 1;
            tableLayoutPanel23.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel23.Size = new Size(362, 88);
            tableLayoutPanel23.TabIndex = 0;
            // 
            // label46
            // 
            label46.BackColor = Color.Gray;
            label46.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label46.ForeColor = SystemColors.ControlLight;
            label46.Location = new Point(91, 0);
            label46.Name = "label46";
            label46.Size = new Size(268, 88);
            label46.TabIndex = 1;
            label46.Text = "label46";
            // 
            // label47
            // 
            label47.BackColor = Color.DimGray;
            label47.Image = (Image)resources.GetObject("label47.Image");
            label47.Location = new Point(3, 0);
            label47.Name = "label47";
            label47.Size = new Size(82, 88);
            label47.TabIndex = 0;
            // 
            // flowLayoutPanel26
            // 
            flowLayoutPanel26.Controls.Add(tableLayoutPanel24);
            flowLayoutPanel26.Controls.Add(flowLayoutPanel27);
            flowLayoutPanel26.Location = new Point(3, 179);
            flowLayoutPanel26.Name = "flowLayoutPanel26";
            flowLayoutPanel26.Size = new Size(352, 88);
            flowLayoutPanel26.TabIndex = 3;
            // 
            // tableLayoutPanel24
            // 
            tableLayoutPanel24.AutoSize = true;
            tableLayoutPanel24.ColumnCount = 2;
            tableLayoutPanel24.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel24.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel24.Controls.Add(label48, 1, 0);
            tableLayoutPanel24.Controls.Add(label49, 0, 0);
            tableLayoutPanel24.Location = new Point(3, 3);
            tableLayoutPanel24.Name = "tableLayoutPanel24";
            tableLayoutPanel24.RowCount = 1;
            tableLayoutPanel24.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel24.Size = new Size(346, 88);
            tableLayoutPanel24.TabIndex = 0;
            // 
            // label48
            // 
            label48.BackColor = Color.Gray;
            label48.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label48.ForeColor = SystemColors.ControlLight;
            label48.Location = new Point(91, 0);
            label48.Name = "label48";
            label48.Size = new Size(252, 88);
            label48.TabIndex = 1;
            label48.Text = "title";
            // 
            // label49
            // 
            label49.BackColor = Color.DimGray;
            label49.Image = (Image)resources.GetObject("label49.Image");
            label49.Location = new Point(3, 0);
            label49.Name = "label49";
            label49.Size = new Size(82, 88);
            label49.TabIndex = 0;
            // 
            // flowLayoutPanel27
            // 
            flowLayoutPanel27.Controls.Add(tableLayoutPanel25);
            flowLayoutPanel27.Location = new Point(3, 97);
            flowLayoutPanel27.Name = "flowLayoutPanel27";
            flowLayoutPanel27.Size = new Size(370, 88);
            flowLayoutPanel27.TabIndex = 2;
            // 
            // tableLayoutPanel25
            // 
            tableLayoutPanel25.AutoSize = true;
            tableLayoutPanel25.ColumnCount = 2;
            tableLayoutPanel25.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel25.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel25.Controls.Add(label50, 1, 0);
            tableLayoutPanel25.Controls.Add(label51, 0, 0);
            tableLayoutPanel25.Location = new Point(3, 3);
            tableLayoutPanel25.Name = "tableLayoutPanel25";
            tableLayoutPanel25.RowCount = 1;
            tableLayoutPanel25.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel25.Size = new Size(362, 88);
            tableLayoutPanel25.TabIndex = 0;
            // 
            // label50
            // 
            label50.BackColor = Color.Gray;
            label50.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label50.ForeColor = SystemColors.ControlLight;
            label50.Location = new Point(91, 0);
            label50.Name = "label50";
            label50.Size = new Size(268, 88);
            label50.TabIndex = 1;
            label50.Text = "label50";
            // 
            // label51
            // 
            label51.BackColor = Color.DimGray;
            label51.Image = (Image)resources.GetObject("label51.Image");
            label51.Location = new Point(3, 0);
            label51.Name = "label51";
            label51.Size = new Size(82, 88);
            label51.TabIndex = 0;
            // 
            // recentPanel
            // 
            recentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recentPanel.AutoSize = true;
            recentPanel.Controls.Add(recentReadPanel);
            recentPanel.Controls.Add(flowLayoutPanel28);
            recentPanel.Controls.Add(flowLayoutPanel30);
            recentPanel.Controls.Add(flowLayoutPanel32);
            homeFlowPanel.SetFlowBreak(recentPanel, true);
            recentPanel.Location = new Point(3, 603);
            recentPanel.Margin = new Padding(3, 3, 3, 30);
            recentPanel.Name = "recentPanel";
            recentPanel.Size = new Size(741, 270);
            recentPanel.TabIndex = 2;
            // 
            // recentReadPanel
            // 
            recentPanel.SetFlowBreak(recentReadPanel, true);
            recentReadPanel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            recentReadPanel.ForeColor = SystemColors.ControlLightLight;
            recentReadPanel.Location = new Point(3, 0);
            recentReadPanel.Name = "recentReadPanel";
            recentReadPanel.Size = new Size(735, 82);
            recentReadPanel.TabIndex = 0;
            recentReadPanel.Text = "Recent read";
            // 
            // flowLayoutPanel28
            // 
            flowLayoutPanel28.Controls.Add(tableLayoutPanel26);
            flowLayoutPanel28.Controls.Add(flowLayoutPanel29);
            flowLayoutPanel28.Location = new Point(3, 85);
            flowLayoutPanel28.Name = "flowLayoutPanel28";
            flowLayoutPanel28.Size = new Size(352, 88);
            flowLayoutPanel28.TabIndex = 1;
            // 
            // tableLayoutPanel26
            // 
            tableLayoutPanel26.AutoSize = true;
            tableLayoutPanel26.ColumnCount = 2;
            tableLayoutPanel26.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel26.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel26.Controls.Add(label52, 1, 0);
            tableLayoutPanel26.Controls.Add(label53, 0, 0);
            tableLayoutPanel26.Location = new Point(3, 3);
            tableLayoutPanel26.Name = "tableLayoutPanel26";
            tableLayoutPanel26.RowCount = 1;
            tableLayoutPanel26.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel26.Size = new Size(346, 88);
            tableLayoutPanel26.TabIndex = 0;
            // 
            // label52
            // 
            label52.BackColor = Color.Gray;
            label52.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label52.ForeColor = SystemColors.ControlLight;
            label52.Location = new Point(91, 0);
            label52.Name = "label52";
            label52.Size = new Size(252, 88);
            label52.TabIndex = 1;
            label52.Text = "title";
            // 
            // label53
            // 
            label53.BackColor = Color.DimGray;
            label53.Image = (Image)resources.GetObject("label53.Image");
            label53.Location = new Point(3, 0);
            label53.Name = "label53";
            label53.Size = new Size(82, 88);
            label53.TabIndex = 0;
            // 
            // flowLayoutPanel29
            // 
            flowLayoutPanel29.Controls.Add(tableLayoutPanel27);
            flowLayoutPanel29.Location = new Point(3, 97);
            flowLayoutPanel29.Name = "flowLayoutPanel29";
            flowLayoutPanel29.Size = new Size(370, 88);
            flowLayoutPanel29.TabIndex = 2;
            // 
            // tableLayoutPanel27
            // 
            tableLayoutPanel27.AutoSize = true;
            tableLayoutPanel27.ColumnCount = 2;
            tableLayoutPanel27.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel27.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel27.Controls.Add(label54, 1, 0);
            tableLayoutPanel27.Controls.Add(label55, 0, 0);
            tableLayoutPanel27.Location = new Point(3, 3);
            tableLayoutPanel27.Name = "tableLayoutPanel27";
            tableLayoutPanel27.RowCount = 1;
            tableLayoutPanel27.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel27.Size = new Size(362, 88);
            tableLayoutPanel27.TabIndex = 0;
            // 
            // label54
            // 
            label54.BackColor = Color.Gray;
            label54.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label54.ForeColor = SystemColors.ControlLight;
            label54.Location = new Point(91, 0);
            label54.Name = "label54";
            label54.Size = new Size(268, 88);
            label54.TabIndex = 1;
            label54.Text = "label54";
            // 
            // label55
            // 
            label55.BackColor = Color.DimGray;
            label55.Image = (Image)resources.GetObject("label55.Image");
            label55.Location = new Point(3, 0);
            label55.Name = "label55";
            label55.Size = new Size(82, 88);
            label55.TabIndex = 0;
            // 
            // flowLayoutPanel30
            // 
            flowLayoutPanel30.Controls.Add(tableLayoutPanel28);
            flowLayoutPanel30.Controls.Add(flowLayoutPanel31);
            flowLayoutPanel30.Location = new Point(361, 85);
            flowLayoutPanel30.Name = "flowLayoutPanel30";
            flowLayoutPanel30.Size = new Size(352, 88);
            flowLayoutPanel30.TabIndex = 2;
            // 
            // tableLayoutPanel28
            // 
            tableLayoutPanel28.AutoSize = true;
            tableLayoutPanel28.ColumnCount = 2;
            tableLayoutPanel28.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel28.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel28.Controls.Add(label56, 1, 0);
            tableLayoutPanel28.Controls.Add(label57, 0, 0);
            tableLayoutPanel28.Location = new Point(3, 3);
            tableLayoutPanel28.Name = "tableLayoutPanel28";
            tableLayoutPanel28.RowCount = 1;
            tableLayoutPanel28.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel28.Size = new Size(346, 88);
            tableLayoutPanel28.TabIndex = 0;
            // 
            // label56
            // 
            label56.BackColor = Color.Gray;
            label56.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label56.ForeColor = SystemColors.ControlLight;
            label56.Location = new Point(91, 0);
            label56.Name = "label56";
            label56.Size = new Size(252, 88);
            label56.TabIndex = 1;
            label56.Text = "title";
            // 
            // label57
            // 
            label57.BackColor = Color.DimGray;
            label57.Image = (Image)resources.GetObject("label57.Image");
            label57.Location = new Point(3, 0);
            label57.Name = "label57";
            label57.Size = new Size(82, 88);
            label57.TabIndex = 0;
            // 
            // flowLayoutPanel31
            // 
            flowLayoutPanel31.Controls.Add(tableLayoutPanel29);
            flowLayoutPanel31.Location = new Point(3, 97);
            flowLayoutPanel31.Name = "flowLayoutPanel31";
            flowLayoutPanel31.Size = new Size(370, 88);
            flowLayoutPanel31.TabIndex = 2;
            // 
            // tableLayoutPanel29
            // 
            tableLayoutPanel29.AutoSize = true;
            tableLayoutPanel29.ColumnCount = 2;
            tableLayoutPanel29.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel29.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel29.Controls.Add(label58, 1, 0);
            tableLayoutPanel29.Controls.Add(label59, 0, 0);
            tableLayoutPanel29.Location = new Point(3, 3);
            tableLayoutPanel29.Name = "tableLayoutPanel29";
            tableLayoutPanel29.RowCount = 1;
            tableLayoutPanel29.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel29.Size = new Size(362, 88);
            tableLayoutPanel29.TabIndex = 0;
            // 
            // label58
            // 
            label58.BackColor = Color.Gray;
            label58.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label58.ForeColor = SystemColors.ControlLight;
            label58.Location = new Point(91, 0);
            label58.Name = "label58";
            label58.Size = new Size(268, 88);
            label58.TabIndex = 1;
            label58.Text = "label58";
            // 
            // label59
            // 
            label59.BackColor = Color.DimGray;
            label59.Image = (Image)resources.GetObject("label59.Image");
            label59.Location = new Point(3, 0);
            label59.Name = "label59";
            label59.Size = new Size(82, 88);
            label59.TabIndex = 0;
            // 
            // flowLayoutPanel32
            // 
            flowLayoutPanel32.Controls.Add(tableLayoutPanel30);
            flowLayoutPanel32.Controls.Add(flowLayoutPanel33);
            flowLayoutPanel32.Location = new Point(3, 179);
            flowLayoutPanel32.Name = "flowLayoutPanel32";
            flowLayoutPanel32.Size = new Size(352, 88);
            flowLayoutPanel32.TabIndex = 3;
            // 
            // tableLayoutPanel30
            // 
            tableLayoutPanel30.AutoSize = true;
            tableLayoutPanel30.ColumnCount = 2;
            tableLayoutPanel30.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel30.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel30.Controls.Add(label60, 1, 0);
            tableLayoutPanel30.Controls.Add(label61, 0, 0);
            tableLayoutPanel30.Location = new Point(3, 3);
            tableLayoutPanel30.Name = "tableLayoutPanel30";
            tableLayoutPanel30.RowCount = 1;
            tableLayoutPanel30.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel30.Size = new Size(346, 88);
            tableLayoutPanel30.TabIndex = 0;
            // 
            // label60
            // 
            label60.BackColor = Color.Gray;
            label60.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label60.ForeColor = SystemColors.ControlLight;
            label60.Location = new Point(91, 0);
            label60.Name = "label60";
            label60.Size = new Size(252, 88);
            label60.TabIndex = 1;
            label60.Text = "title";
            // 
            // label61
            // 
            label61.BackColor = Color.DimGray;
            label61.Image = (Image)resources.GetObject("label61.Image");
            label61.Location = new Point(3, 0);
            label61.Name = "label61";
            label61.Size = new Size(82, 88);
            label61.TabIndex = 0;
            // 
            // flowLayoutPanel33
            // 
            flowLayoutPanel33.Controls.Add(tableLayoutPanel31);
            flowLayoutPanel33.Location = new Point(3, 97);
            flowLayoutPanel33.Name = "flowLayoutPanel33";
            flowLayoutPanel33.Size = new Size(370, 88);
            flowLayoutPanel33.TabIndex = 2;
            // 
            // tableLayoutPanel31
            // 
            tableLayoutPanel31.AutoSize = true;
            tableLayoutPanel31.ColumnCount = 2;
            tableLayoutPanel31.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel31.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel31.Controls.Add(label62, 1, 0);
            tableLayoutPanel31.Controls.Add(label63, 0, 0);
            tableLayoutPanel31.Location = new Point(3, 3);
            tableLayoutPanel31.Name = "tableLayoutPanel31";
            tableLayoutPanel31.RowCount = 1;
            tableLayoutPanel31.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel31.Size = new Size(362, 88);
            tableLayoutPanel31.TabIndex = 0;
            // 
            // label62
            // 
            label62.BackColor = Color.Gray;
            label62.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label62.ForeColor = SystemColors.ControlLight;
            label62.Location = new Point(91, 0);
            label62.Name = "label62";
            label62.Size = new Size(268, 88);
            label62.TabIndex = 1;
            label62.Text = "label62";
            // 
            // label63
            // 
            label63.BackColor = Color.DimGray;
            label63.Image = (Image)resources.GetObject("label63.Image");
            label63.Location = new Point(3, 0);
            label63.Name = "label63";
            label63.Size = new Size(82, 88);
            label63.TabIndex = 0;
            // 
            // bestBookPanel
            // 
            bestBookPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bestBookPanel.AutoSize = true;
            bestBookPanel.Controls.Add(bestBookLabel);
            bestBookPanel.Controls.Add(flowLayoutPanel34);
            bestBookPanel.Controls.Add(flowLayoutPanel36);
            bestBookPanel.Controls.Add(flowLayoutPanel38);
            homeFlowPanel.SetFlowBreak(bestBookPanel, true);
            bestBookPanel.Location = new Point(3, 906);
            bestBookPanel.Margin = new Padding(3, 3, 3, 30);
            bestBookPanel.Name = "bestBookPanel";
            bestBookPanel.Size = new Size(741, 270);
            bestBookPanel.TabIndex = 3;
            // 
            // bestBookLabel
            // 
            bestBookPanel.SetFlowBreak(bestBookLabel, true);
            bestBookLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookLabel.ForeColor = SystemColors.ControlLightLight;
            bestBookLabel.Location = new Point(3, 0);
            bestBookLabel.Name = "bestBookLabel";
            bestBookLabel.Size = new Size(735, 82);
            bestBookLabel.TabIndex = 0;
            bestBookLabel.Text = "Best book";
            // 
            // flowLayoutPanel34
            // 
            flowLayoutPanel34.Controls.Add(tableLayoutPanel32);
            flowLayoutPanel34.Controls.Add(flowLayoutPanel35);
            flowLayoutPanel34.Location = new Point(3, 85);
            flowLayoutPanel34.Name = "flowLayoutPanel34";
            flowLayoutPanel34.Size = new Size(352, 88);
            flowLayoutPanel34.TabIndex = 1;
            // 
            // tableLayoutPanel32
            // 
            tableLayoutPanel32.AutoSize = true;
            tableLayoutPanel32.ColumnCount = 2;
            tableLayoutPanel32.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel32.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel32.Controls.Add(label64, 1, 0);
            tableLayoutPanel32.Controls.Add(label65, 0, 0);
            tableLayoutPanel32.Location = new Point(3, 3);
            tableLayoutPanel32.Name = "tableLayoutPanel32";
            tableLayoutPanel32.RowCount = 1;
            tableLayoutPanel32.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel32.Size = new Size(346, 88);
            tableLayoutPanel32.TabIndex = 0;
            // 
            // label64
            // 
            label64.BackColor = Color.Gray;
            label64.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label64.ForeColor = SystemColors.ControlLight;
            label64.Location = new Point(91, 0);
            label64.Name = "label64";
            label64.Size = new Size(252, 88);
            label64.TabIndex = 1;
            label64.Text = "title";
            // 
            // label65
            // 
            label65.BackColor = Color.DimGray;
            label65.Image = (Image)resources.GetObject("label65.Image");
            label65.Location = new Point(3, 0);
            label65.Name = "label65";
            label65.Size = new Size(82, 88);
            label65.TabIndex = 0;
            // 
            // flowLayoutPanel35
            // 
            flowLayoutPanel35.Controls.Add(tableLayoutPanel33);
            flowLayoutPanel35.Location = new Point(3, 97);
            flowLayoutPanel35.Name = "flowLayoutPanel35";
            flowLayoutPanel35.Size = new Size(370, 88);
            flowLayoutPanel35.TabIndex = 2;
            // 
            // tableLayoutPanel33
            // 
            tableLayoutPanel33.AutoSize = true;
            tableLayoutPanel33.ColumnCount = 2;
            tableLayoutPanel33.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel33.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel33.Controls.Add(label66, 1, 0);
            tableLayoutPanel33.Controls.Add(label67, 0, 0);
            tableLayoutPanel33.Location = new Point(3, 3);
            tableLayoutPanel33.Name = "tableLayoutPanel33";
            tableLayoutPanel33.RowCount = 1;
            tableLayoutPanel33.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel33.Size = new Size(362, 88);
            tableLayoutPanel33.TabIndex = 0;
            // 
            // label66
            // 
            label66.BackColor = Color.Gray;
            label66.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label66.ForeColor = SystemColors.ControlLight;
            label66.Location = new Point(91, 0);
            label66.Name = "label66";
            label66.Size = new Size(268, 88);
            label66.TabIndex = 1;
            label66.Text = "label66";
            // 
            // label67
            // 
            label67.BackColor = Color.DimGray;
            label67.Image = (Image)resources.GetObject("label67.Image");
            label67.Location = new Point(3, 0);
            label67.Name = "label67";
            label67.Size = new Size(82, 88);
            label67.TabIndex = 0;
            // 
            // flowLayoutPanel36
            // 
            flowLayoutPanel36.Controls.Add(tableLayoutPanel34);
            flowLayoutPanel36.Controls.Add(flowLayoutPanel37);
            flowLayoutPanel36.Location = new Point(361, 85);
            flowLayoutPanel36.Name = "flowLayoutPanel36";
            flowLayoutPanel36.Size = new Size(352, 88);
            flowLayoutPanel36.TabIndex = 2;
            // 
            // tableLayoutPanel34
            // 
            tableLayoutPanel34.AutoSize = true;
            tableLayoutPanel34.ColumnCount = 2;
            tableLayoutPanel34.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel34.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel34.Controls.Add(label68, 1, 0);
            tableLayoutPanel34.Controls.Add(label69, 0, 0);
            tableLayoutPanel34.Location = new Point(3, 3);
            tableLayoutPanel34.Name = "tableLayoutPanel34";
            tableLayoutPanel34.RowCount = 1;
            tableLayoutPanel34.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel34.Size = new Size(346, 88);
            tableLayoutPanel34.TabIndex = 0;
            // 
            // label68
            // 
            label68.BackColor = Color.Gray;
            label68.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label68.ForeColor = SystemColors.ControlLight;
            label68.Location = new Point(91, 0);
            label68.Name = "label68";
            label68.Size = new Size(252, 88);
            label68.TabIndex = 1;
            label68.Text = "title";
            // 
            // label69
            // 
            label69.BackColor = Color.DimGray;
            label69.Image = (Image)resources.GetObject("label69.Image");
            label69.Location = new Point(3, 0);
            label69.Name = "label69";
            label69.Size = new Size(82, 88);
            label69.TabIndex = 0;
            // 
            // flowLayoutPanel37
            // 
            flowLayoutPanel37.Controls.Add(tableLayoutPanel35);
            flowLayoutPanel37.Location = new Point(3, 97);
            flowLayoutPanel37.Name = "flowLayoutPanel37";
            flowLayoutPanel37.Size = new Size(370, 88);
            flowLayoutPanel37.TabIndex = 2;
            // 
            // tableLayoutPanel35
            // 
            tableLayoutPanel35.AutoSize = true;
            tableLayoutPanel35.ColumnCount = 2;
            tableLayoutPanel35.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel35.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel35.Controls.Add(label70, 1, 0);
            tableLayoutPanel35.Controls.Add(label71, 0, 0);
            tableLayoutPanel35.Location = new Point(3, 3);
            tableLayoutPanel35.Name = "tableLayoutPanel35";
            tableLayoutPanel35.RowCount = 1;
            tableLayoutPanel35.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel35.Size = new Size(362, 88);
            tableLayoutPanel35.TabIndex = 0;
            // 
            // label70
            // 
            label70.BackColor = Color.Gray;
            label70.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label70.ForeColor = SystemColors.ControlLight;
            label70.Location = new Point(91, 0);
            label70.Name = "label70";
            label70.Size = new Size(268, 88);
            label70.TabIndex = 1;
            label70.Text = "label70";
            // 
            // label71
            // 
            label71.BackColor = Color.DimGray;
            label71.Image = (Image)resources.GetObject("label71.Image");
            label71.Location = new Point(3, 0);
            label71.Name = "label71";
            label71.Size = new Size(82, 88);
            label71.TabIndex = 0;
            // 
            // flowLayoutPanel38
            // 
            flowLayoutPanel38.Controls.Add(tableLayoutPanel36);
            flowLayoutPanel38.Controls.Add(flowLayoutPanel39);
            flowLayoutPanel38.Location = new Point(3, 179);
            flowLayoutPanel38.Name = "flowLayoutPanel38";
            flowLayoutPanel38.Size = new Size(352, 88);
            flowLayoutPanel38.TabIndex = 3;
            // 
            // tableLayoutPanel36
            // 
            tableLayoutPanel36.AutoSize = true;
            tableLayoutPanel36.ColumnCount = 2;
            tableLayoutPanel36.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel36.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel36.Controls.Add(label72, 1, 0);
            tableLayoutPanel36.Controls.Add(label73, 0, 0);
            tableLayoutPanel36.Location = new Point(3, 3);
            tableLayoutPanel36.Name = "tableLayoutPanel36";
            tableLayoutPanel36.RowCount = 1;
            tableLayoutPanel36.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel36.Size = new Size(346, 88);
            tableLayoutPanel36.TabIndex = 0;
            // 
            // label72
            // 
            label72.BackColor = Color.Gray;
            label72.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label72.ForeColor = SystemColors.ControlLight;
            label72.Location = new Point(91, 0);
            label72.Name = "label72";
            label72.Size = new Size(252, 88);
            label72.TabIndex = 1;
            label72.Text = "title";
            // 
            // label73
            // 
            label73.BackColor = Color.DimGray;
            label73.Image = (Image)resources.GetObject("label73.Image");
            label73.Location = new Point(3, 0);
            label73.Name = "label73";
            label73.Size = new Size(82, 88);
            label73.TabIndex = 0;
            // 
            // flowLayoutPanel39
            // 
            flowLayoutPanel39.Controls.Add(tableLayoutPanel37);
            flowLayoutPanel39.Location = new Point(3, 97);
            flowLayoutPanel39.Name = "flowLayoutPanel39";
            flowLayoutPanel39.Size = new Size(370, 88);
            flowLayoutPanel39.TabIndex = 2;
            // 
            // tableLayoutPanel37
            // 
            tableLayoutPanel37.AutoSize = true;
            tableLayoutPanel37.ColumnCount = 2;
            tableLayoutPanel37.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel37.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel37.Controls.Add(label74, 1, 0);
            tableLayoutPanel37.Controls.Add(label75, 0, 0);
            tableLayoutPanel37.Location = new Point(3, 3);
            tableLayoutPanel37.Name = "tableLayoutPanel37";
            tableLayoutPanel37.RowCount = 1;
            tableLayoutPanel37.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel37.Size = new Size(362, 88);
            tableLayoutPanel37.TabIndex = 0;
            // 
            // label74
            // 
            label74.BackColor = Color.Gray;
            label74.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label74.ForeColor = SystemColors.ControlLight;
            label74.Location = new Point(91, 0);
            label74.Name = "label74";
            label74.Size = new Size(268, 88);
            label74.TabIndex = 1;
            label74.Text = "label74";
            // 
            // label75
            // 
            label75.BackColor = Color.DimGray;
            label75.Image = (Image)resources.GetObject("label75.Image");
            label75.Location = new Point(3, 0);
            label75.Name = "label75";
            label75.Size = new Size(82, 88);
            label75.TabIndex = 0;
            // 
            // searchFlowPanel
            // 
            searchFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchFlowPanel.AutoScroll = true;
            searchFlowPanel.Controls.Add(searchPanel);
            searchFlowPanel.Controls.Add(bestMatchPanel);
            searchFlowPanel.Controls.Add(flowLayoutPanel61);
            searchFlowPanel.Location = new Point(0, 792);
            searchFlowPanel.Margin = new Padding(0, 27, 0, 0);
            searchFlowPanel.Name = "searchFlowPanel";
            searchFlowPanel.Size = new Size(767, 765);
            searchFlowPanel.TabIndex = 1;
            searchFlowPanel.Visible = false;
            // 
            // searchPanel
            // 
            searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPanel.AutoSize = true;
            searchPanel.Controls.Add(searchLayoutTable);
            searchFlowPanel.SetFlowBreak(searchPanel, true);
            searchPanel.Location = new Point(3, 30);
            searchPanel.Margin = new Padding(3, 30, 3, 30);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(621, 61);
            searchPanel.TabIndex = 0;
            // 
            // searchLayoutTable
            // 
            searchLayoutTable.ColumnCount = 2;
            searchLayoutTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            searchLayoutTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayoutTable.Controls.Add(searchBoxContainer, 1, 0);
            searchLayoutTable.Controls.Add(searchImg, 0, 0);
            searchLayoutTable.Location = new Point(3, 3);
            searchLayoutTable.Name = "searchLayoutTable";
            searchLayoutTable.RowCount = 1;
            searchLayoutTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            searchLayoutTable.Size = new Size(615, 55);
            searchLayoutTable.TabIndex = 5;
            // 
            // searchBoxContainer
            // 
            searchBoxContainer.Controls.Add(searchBox);
            searchBoxContainer.Dock = DockStyle.Fill;
            searchBoxContainer.GradientAngle = 70F;
            searchBoxContainer.GradientPrimaryColor = Color.FromArgb(245, 127, 243);
            searchBoxContainer.GradientSecondaryColor = Color.Transparent;
            searchBoxContainer.Location = new Point(55, 0);
            searchBoxContainer.Margin = new Padding(0);
            searchBoxContainer.Name = "searchBoxContainer";
            searchBoxContainer.Size = new Size(560, 55);
            searchBoxContainer.TabIndex = 2;
            // 
            // searchBox
            // 
            searchBox.Dock = DockStyle.Fill;
            searchBox.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            searchBox.ForeColor = SystemColors.ControlLight;
            searchBox.Location = new Point(0, 0);
            searchBox.Margin = new Padding(0);
            searchBox.Name = "searchBox";
           // searchBox.SetTextView = singleTextView1;
            searchBox.Size = new Size(560, 55);
            searchBox.TabIndex = 5;
            searchBox.Text = "What do you want to read?";
            searchBox.GotFocus += SearchBox_GotFocus;
            searchBox.LostFocus += SearchBox_LostFocus;
            searchBox.MouseLeave += SearchBox_MouseLeave;
            searchBox.MouseHover += SearchBox_Hover;
            // 
            // searchImg
            // 
            searchImg.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            searchImg.ForeColor = SystemColors.ControlLightLight;
            searchImg.Image = (Image)resources.GetObject("searchImg.Image");
            searchImg.Location = new Point(3, 0);
            searchImg.Name = "searchImg";
            searchImg.Size = new Size(49, 55);
            searchImg.TabIndex = 0;
            // 
            // bestMatchPanel
            // 
            bestMatchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bestMatchPanel.AutoSize = true;
            bestMatchPanel.Controls.Add(bestMatchLabel);
            bestMatchPanel.Controls.Add(bestMatchResult);
            searchFlowPanel.SetFlowBreak(bestMatchPanel, true);
            bestMatchPanel.Location = new Point(3, 124);
            bestMatchPanel.Margin = new Padding(3, 3, 3, 30);
            bestMatchPanel.Name = "bestMatchPanel";
            bestMatchPanel.Size = new Size(741, 176);
            bestMatchPanel.TabIndex = 1;

            // 
            // bestMatchLabel
            // 
            bestMatchPanel.SetFlowBreak(bestMatchLabel, true);
            bestMatchLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            bestMatchLabel.ForeColor = SystemColors.ControlLightLight;
            bestMatchLabel.Location = new Point(3, 0);
            bestMatchLabel.Name = "bestMatchLabel";
            bestMatchLabel.Size = new Size(735, 82);
            bestMatchLabel.TabIndex = 0;
            bestMatchLabel.Text = "Best match";
            // 
            // bestMatchResult
            // 
            bestMatchResult.Controls.Add(bestMatchTableLayout);
            bestMatchResult.Controls.Add(flowLayoutPanel49);
            bestMatchResult.Location = new Point(3, 85);
            bestMatchResult.Name = "bestMatchResult";
            bestMatchResult.Size = new Size(352, 88);
            bestMatchResult.TabIndex = 1;
            // 
            // bestMatchTableLayout
            // 
            bestMatchTableLayout.AutoSize = true;
            bestMatchTableLayout.ColumnCount = 2;
            bestMatchTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            bestMatchTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bestMatchTableLayout.Controls.Add(label89, 1, 0);
            bestMatchTableLayout.Controls.Add(label90, 0, 0);
            bestMatchTableLayout.Location = new Point(3, 3);
            bestMatchTableLayout.Name = "bestMatchTableLayout";
            bestMatchTableLayout.RowCount = 1;
            bestMatchTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            bestMatchTableLayout.Size = new Size(346, 101);
            bestMatchTableLayout.TabIndex = 0;
            // 
            // label89
            // 
            label89.BackColor = Color.Gray;
            label89.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label89.ForeColor = SystemColors.ControlLight;
            label89.Location = new Point(91, 0);
            label89.Name = "label89";
            label89.Size = new Size(252, 88);
            label89.TabIndex = 1;
            label89.Text = "title";
            // 
            // label90
            // 
            label90.BackColor = Color.DimGray;
            label90.Image = (Image)resources.GetObject("label90.Image");
            label90.Location = new Point(3, 0);
            label90.Name = "label90";
            label90.Size = new Size(82, 101);
            label90.TabIndex = 0;
            // 
            // flowLayoutPanel49
            // 
            flowLayoutPanel49.Controls.Add(tableLayoutPanel45);
            flowLayoutPanel49.Location = new Point(3, 110);
            flowLayoutPanel49.Name = "flowLayoutPanel49";
            flowLayoutPanel49.Size = new Size(370, 88);
            flowLayoutPanel49.TabIndex = 2;
            // 
            // tableLayoutPanel45
            // 
            tableLayoutPanel45.AutoSize = true;
            tableLayoutPanel45.ColumnCount = 2;
            tableLayoutPanel45.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel45.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel45.Controls.Add(label91, 1, 0);
            tableLayoutPanel45.Controls.Add(label92, 0, 0);
            tableLayoutPanel45.Location = new Point(3, 3);
            tableLayoutPanel45.Name = "tableLayoutPanel45";
            tableLayoutPanel45.RowCount = 1;
            tableLayoutPanel45.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel45.Size = new Size(362, 88);
            tableLayoutPanel45.TabIndex = 0;
            // 
            // label91
            // 
            label91.BackColor = Color.Gray;
            label91.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label91.ForeColor = SystemColors.ControlLight;
            label91.Location = new Point(91, 0);
            label91.Name = "label91";
            label91.Size = new Size(268, 88);
            label91.TabIndex = 1;
            label91.Text = "label91";
            // 
            // label92
            // 
            label92.BackColor = Color.DimGray;
            label92.Image = (Image)resources.GetObject("label92.Image");
            label92.Location = new Point(3, 0);
            label92.Name = "label92";
            label92.Size = new Size(82, 88);
            label92.TabIndex = 0;
            // 
            // flowLayoutPanel61
            // 
            flowLayoutPanel61.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel61.AutoSize = true;
            flowLayoutPanel61.Controls.Add(label114);
            flowLayoutPanel61.Controls.Add(flowLayoutPanel62);
            flowLayoutPanel61.Controls.Add(flowLayoutPanel64);
            flowLayoutPanel61.Controls.Add(flowLayoutPanel66);
            searchFlowPanel.SetFlowBreak(flowLayoutPanel61, true);
            flowLayoutPanel61.Location = new Point(3, 333);
            flowLayoutPanel61.Margin = new Padding(3, 3, 3, 30);
            flowLayoutPanel61.Name = "flowLayoutPanel61";
            flowLayoutPanel61.Size = new Size(741, 270);
            flowLayoutPanel61.TabIndex = 3;
            // 
            // label114
            // 
            flowLayoutPanel61.SetFlowBreak(label114, true);
            label114.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label114.ForeColor = SystemColors.ControlLightLight;
            label114.Location = new Point(3, 0);
            label114.Name = "label114";
            label114.Size = new Size(735, 82);
            label114.TabIndex = 0;
            label114.Text = "Best book";
            // 
            // flowLayoutPanel62
            // 
            flowLayoutPanel62.Controls.Add(tableLayoutPanel56);
            flowLayoutPanel62.Controls.Add(flowLayoutPanel63);
            flowLayoutPanel62.Location = new Point(3, 85);
            flowLayoutPanel62.Name = "flowLayoutPanel62";
            flowLayoutPanel62.Size = new Size(352, 88);
            flowLayoutPanel62.TabIndex = 1;
            // 
            // tableLayoutPanel56
            // 
            tableLayoutPanel56.AutoSize = true;
            tableLayoutPanel56.ColumnCount = 2;
            tableLayoutPanel56.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel56.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel56.Controls.Add(label115, 1, 0);
            tableLayoutPanel56.Controls.Add(label116, 0, 0);
            tableLayoutPanel56.Location = new Point(3, 3);
            tableLayoutPanel56.Name = "tableLayoutPanel56";
            tableLayoutPanel56.RowCount = 1;
            tableLayoutPanel56.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel56.Size = new Size(346, 88);
            tableLayoutPanel56.TabIndex = 0;
            // 
            // label115
            // 
            label115.BackColor = Color.Gray;
            label115.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label115.ForeColor = SystemColors.ControlLight;
            label115.Location = new Point(91, 0);
            label115.Name = "label115";
            label115.Size = new Size(252, 88);
            label115.TabIndex = 1;
            label115.Text = "title";
            // 
            // label116
            // 
            label116.BackColor = Color.DimGray;
            label116.Image = (Image)resources.GetObject("label116.Image");
            label116.Location = new Point(3, 0);
            label116.Name = "label116";
            label116.Size = new Size(82, 88);
            label116.TabIndex = 0;
            // 
            // flowLayoutPanel63
            // 
            flowLayoutPanel63.Controls.Add(tableLayoutPanel57);
            flowLayoutPanel63.Location = new Point(3, 97);
            flowLayoutPanel63.Name = "flowLayoutPanel63";
            flowLayoutPanel63.Size = new Size(370, 88);
            flowLayoutPanel63.TabIndex = 2;
            // 
            // tableLayoutPanel57
            // 
            tableLayoutPanel57.AutoSize = true;
            tableLayoutPanel57.ColumnCount = 2;
            tableLayoutPanel57.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel57.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel57.Controls.Add(label117, 1, 0);
            tableLayoutPanel57.Controls.Add(label118, 0, 0);
            tableLayoutPanel57.Location = new Point(3, 3);
            tableLayoutPanel57.Name = "tableLayoutPanel57";
            tableLayoutPanel57.RowCount = 1;
            tableLayoutPanel57.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel57.Size = new Size(362, 88);
            tableLayoutPanel57.TabIndex = 0;
            // 
            // label117
            // 
            label117.BackColor = Color.Gray;
            label117.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label117.ForeColor = SystemColors.ControlLight;
            label117.Location = new Point(91, 0);
            label117.Name = "label117";
            label117.Size = new Size(268, 88);
            label117.TabIndex = 1;
            label117.Text = "label117";
            // 
            // label118
            // 
            label118.BackColor = Color.DimGray;
            label118.Image = (Image)resources.GetObject("label118.Image");
            label118.Location = new Point(3, 0);
            label118.Name = "label118";
            label118.Size = new Size(82, 88);
            label118.TabIndex = 0;
            // 
            // flowLayoutPanel64
            // 
            flowLayoutPanel64.Controls.Add(tableLayoutPanel58);
            flowLayoutPanel64.Controls.Add(flowLayoutPanel65);
            flowLayoutPanel64.Location = new Point(361, 85);
            flowLayoutPanel64.Name = "flowLayoutPanel64";
            flowLayoutPanel64.Size = new Size(352, 88);
            flowLayoutPanel64.TabIndex = 2;
            // 
            // tableLayoutPanel58
            // 
            tableLayoutPanel58.AutoSize = true;
            tableLayoutPanel58.ColumnCount = 2;
            tableLayoutPanel58.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel58.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel58.Controls.Add(label119, 1, 0);
            tableLayoutPanel58.Controls.Add(label120, 0, 0);
            tableLayoutPanel58.Location = new Point(3, 3);
            tableLayoutPanel58.Name = "tableLayoutPanel58";
            tableLayoutPanel58.RowCount = 1;
            tableLayoutPanel58.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel58.Size = new Size(346, 88);
            tableLayoutPanel58.TabIndex = 0;
            // 
            // label119
            // 
            label119.BackColor = Color.Gray;
            label119.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label119.ForeColor = SystemColors.ControlLight;
            label119.Location = new Point(91, 0);
            label119.Name = "label119";
            label119.Size = new Size(252, 88);
            label119.TabIndex = 1;
            label119.Text = "title";
            // 
            // label120
            // 
            label120.BackColor = Color.DimGray;
            label120.Image = (Image)resources.GetObject("label120.Image");
            label120.Location = new Point(3, 0);
            label120.Name = "label120";
            label120.Size = new Size(82, 88);
            label120.TabIndex = 0;
            // 
            // flowLayoutPanel65
            // 
            flowLayoutPanel65.Controls.Add(tableLayoutPanel59);
            flowLayoutPanel65.Location = new Point(3, 97);
            flowLayoutPanel65.Name = "flowLayoutPanel65";
            flowLayoutPanel65.Size = new Size(370, 88);
            flowLayoutPanel65.TabIndex = 2;
            // 
            // tableLayoutPanel59
            // 
            tableLayoutPanel59.AutoSize = true;
            tableLayoutPanel59.ColumnCount = 2;
            tableLayoutPanel59.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel59.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel59.Controls.Add(label121, 1, 0);
            tableLayoutPanel59.Controls.Add(label122, 0, 0);
            tableLayoutPanel59.Location = new Point(3, 3);
            tableLayoutPanel59.Name = "tableLayoutPanel59";
            tableLayoutPanel59.RowCount = 1;
            tableLayoutPanel59.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel59.Size = new Size(362, 88);
            tableLayoutPanel59.TabIndex = 0;
            // 
            // label121
            // 
            label121.BackColor = Color.Gray;
            label121.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label121.ForeColor = SystemColors.ControlLight;
            label121.Location = new Point(91, 0);
            label121.Name = "label121";
            label121.Size = new Size(268, 88);
            label121.TabIndex = 1;
            label121.Text = "label121";
            // 
            // label122
            // 
            label122.BackColor = Color.DimGray;
            label122.Image = (Image)resources.GetObject("label122.Image");
            label122.Location = new Point(3, 0);
            label122.Name = "label122";
            label122.Size = new Size(82, 88);
            label122.TabIndex = 0;
            // 
            // flowLayoutPanel66
            // 
            flowLayoutPanel66.Controls.Add(tableLayoutPanel60);
            flowLayoutPanel66.Controls.Add(flowLayoutPanel67);
            flowLayoutPanel66.Location = new Point(3, 179);
            flowLayoutPanel66.Name = "flowLayoutPanel66";
            flowLayoutPanel66.Size = new Size(352, 88);
            flowLayoutPanel66.TabIndex = 3;
            // 
            // tableLayoutPanel60
            // 
            tableLayoutPanel60.AutoSize = true;
            tableLayoutPanel60.ColumnCount = 2;
            tableLayoutPanel60.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel60.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel60.Controls.Add(label123, 1, 0);
            tableLayoutPanel60.Controls.Add(label124, 0, 0);
            tableLayoutPanel60.Location = new Point(3, 3);
            tableLayoutPanel60.Name = "tableLayoutPanel60";
            tableLayoutPanel60.RowCount = 1;
            tableLayoutPanel60.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel60.Size = new Size(346, 88);
            tableLayoutPanel60.TabIndex = 0;
            // 
            // label123
            // 
            label123.BackColor = Color.Gray;
            label123.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label123.ForeColor = SystemColors.ControlLight;
            label123.Location = new Point(91, 0);
            label123.Name = "label123";
            label123.Size = new Size(252, 88);
            label123.TabIndex = 1;
            label123.Text = "title";
            // 
            // label124
            // 
            label124.BackColor = Color.DimGray;
            label124.Image = (Image)resources.GetObject("label124.Image");
            label124.Location = new Point(3, 0);
            label124.Name = "label124";
            label124.Size = new Size(82, 88);
            label124.TabIndex = 0;
            // 
            // flowLayoutPanel67
            // 
            flowLayoutPanel67.Controls.Add(tableLayoutPanel61);
            flowLayoutPanel67.Location = new Point(3, 97);
            flowLayoutPanel67.Name = "flowLayoutPanel67";
            flowLayoutPanel67.Size = new Size(370, 88);
            flowLayoutPanel67.TabIndex = 2;
            // 
            // tableLayoutPanel61
            // 
            tableLayoutPanel61.AutoSize = true;
            tableLayoutPanel61.ColumnCount = 2;
            tableLayoutPanel61.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel61.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel61.Controls.Add(label125, 1, 0);
            tableLayoutPanel61.Controls.Add(label126, 0, 0);
            tableLayoutPanel61.Location = new Point(3, 3);
            tableLayoutPanel61.Name = "tableLayoutPanel61";
            tableLayoutPanel61.RowCount = 1;
            tableLayoutPanel61.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel61.Size = new Size(362, 88);
            tableLayoutPanel61.TabIndex = 0;
            // 
            // label125
            // 
            label125.BackColor = Color.Gray;
            label125.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label125.ForeColor = SystemColors.ControlLight;
            label125.Location = new Point(91, 0);
            label125.Name = "label125";
            label125.Size = new Size(268, 88);
            label125.TabIndex = 1;
            label125.Text = "label125";
            // 
            // label126
            // 
            label126.BackColor = Color.DimGray;
            label126.Image = (Image)resources.GetObject("label126.Image");
            label126.Location = new Point(3, 0);
            label126.Name = "label126";
            label126.Size = new Size(82, 88);
            label126.TabIndex = 0;
            // 
            // currentPanel
            // 
            currentPanel.BackColor = Color.Gainsboro;
            currentPanel.Controls.Add(currentLabel);
            currentPanel.Dock = DockStyle.Fill;
            currentPanel.Location = new Point(1180, 746);
            currentPanel.Margin = new Padding(0);
            currentPanel.Name = "currentPanel";
            currentPanel.Size = new Size(100, 100);
            currentPanel.TabIndex = 5;
            // 
            // currentLabel
            // 
            currentLabel.BackColor = Color.Transparent;
            currentLabel.Dock = DockStyle.Fill;
            currentLabel.Image = (Image)resources.GetObject("currentLabel.Image");
            currentLabel.Location = new Point(0, 0);
            currentLabel.Name = "currentLabel";
            currentLabel.Size = new Size(100, 100);
            currentLabel.TabIndex = 0;
            // 
            // currentProperties
            // 
            currentProperties.Controls.Add(currentPropertiesTable);
            currentProperties.Dock = DockStyle.Fill;
            currentProperties.GradientAngle = 180F;
            currentProperties.GradientPrimaryColor = Color.FromArgb(0, 64, 0);
            currentProperties.GradientSecondaryColor = Color.Empty;
            currentProperties.Location = new Point(430, 746);
            currentProperties.Margin = new Padding(0);
            currentProperties.Name = "currentProperties";
            currentProperties.Size = new Size(750, 100);
            currentProperties.TabIndex = 6;
            // 
            // currentPropertiesTable
            // 
            currentPropertiesTable.ColumnCount = 3;
            currentPropertiesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            currentPropertiesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            currentPropertiesTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            currentPropertiesTable.Controls.Add(currentBookPanel, 2, 0);
            currentPropertiesTable.Controls.Add(currentPagePanel, 1, 0);
            currentPropertiesTable.Controls.Add(currentPublisherPanel, 0, 0);
            currentPropertiesTable.Dock = DockStyle.Fill;
            currentPropertiesTable.Location = new Point(0, 0);
            currentPropertiesTable.Margin = new Padding(0);
            currentPropertiesTable.Name = "currentPropertiesTable";
            currentPropertiesTable.RowCount = 1;
            currentPropertiesTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            currentPropertiesTable.Size = new Size(750, 100);
            currentPropertiesTable.TabIndex = 0;
            // 
            // currentBookPanel
            // 
            currentBookPanel.Controls.Add(currentBookTitle);
            currentBookPanel.Controls.Add(currentBookAuthor);
            currentBookPanel.Controls.Add(currentBookRate);
            currentBookPanel.Dock = DockStyle.Fill;
            currentBookPanel.FlowDirection = FlowDirection.RightToLeft;
            currentBookPanel.Location = new Point(425, 0);
            currentBookPanel.Margin = new Padding(0);
            currentBookPanel.Name = "currentBookPanel";
            currentBookPanel.Size = new Size(325, 100);
            currentBookPanel.TabIndex = 0;
            // 
            // currentBookTitle
            // 
            currentBookTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            currentBookTitle.AutoSize = true;
            currentBookPanel.SetFlowBreak(currentBookTitle, true);
            currentBookTitle.Font = new Font("Exo ExtraBold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            currentBookTitle.ForeColor = SystemColors.Menu;
            currentBookTitle.Location = new Point(227, 10);
            currentBookTitle.Margin = new Padding(3, 10, 10, 0);
            currentBookTitle.Name = "currentBookTitle";
            currentBookTitle.Size = new Size(88, 24);
            currentBookTitle.TabIndex = 0;
            currentBookTitle.Text = "Book title";
            // 
            // currentBookAuthor
            // 
            currentBookAuthor.AutoSize = true;
            currentBookPanel.SetFlowBreak(currentBookAuthor, true);
            currentBookAuthor.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            currentBookAuthor.ForeColor = SystemColors.Menu;
            currentBookAuthor.Location = new Point(231, 34);
            currentBookAuthor.Margin = new Padding(3, 0, 10, 0);
            currentBookAuthor.Name = "currentBookAuthor";
            currentBookAuthor.Size = new Size(84, 19);
            currentBookAuthor.TabIndex = 1;
            currentBookAuthor.Text = "Book Author";
            // 
            // currentBookRate
            // 
            currentBookRate.Font = new Font("Exo ExtraBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            currentBookRate.ForeColor = SystemColors.Menu;
            currentBookRate.Image = (Image)resources.GetObject("currentBookRate.Image");
            currentBookRate.Location = new Point(222, 59);
            currentBookRate.Name = "currentBookRate";
            currentBookRate.Size = new Size(100, 25);
            currentBookRate.TabIndex = 2;
            currentBookRate.Text = "3.0";
            // 
            // currentPagePanel
            // 
            currentPagePanel.Controls.Add(totalPage);
            currentPagePanel.Controls.Add(currentPage);
            currentPagePanel.Location = new Point(325, 0);
            currentPagePanel.Margin = new Padding(0);
            currentPagePanel.Name = "currentPagePanel";
            currentPagePanel.Size = new Size(94, 94);
            currentPagePanel.TabIndex = 1;
            // 
            // totalPage
            // 
            totalPage.AutoSize = true;
            totalPage.ForeColor = SystemColors.Menu;
            totalPage.Location = new Point(42, 53);
            totalPage.Name = "totalPage";
            totalPage.Size = new Size(45, 20);
            totalPage.TabIndex = 1;
            totalPage.Text = "/NaN";
            // 
            // currentPage
            // 
            currentPage.AutoSize = true;
            currentPage.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            currentPage.ForeColor = SystemColors.Menu;
            currentPage.Location = new Point(6, 20);
            currentPage.Name = "currentPage";
            currentPage.Size = new Size(45, 23);
            currentPage.TabIndex = 0;
            currentPage.Text = "NaN";
            // 
            // currentPublisherPanel
            // 
            currentPublisherPanel.Controls.Add(currentPublisher);
            currentPublisherPanel.Controls.Add(yearOfPublication);
            currentPublisherPanel.Dock = DockStyle.Fill;
            currentPublisherPanel.Location = new Point(0, 0);
            currentPublisherPanel.Margin = new Padding(0);
            currentPublisherPanel.Name = "currentPublisherPanel";
            currentPublisherPanel.Size = new Size(325, 100);
            currentPublisherPanel.TabIndex = 2;
            // 
            // currentPublisher
            // 
            currentPublisher.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            currentPublisher.AutoSize = true;
            currentPublisherPanel.SetFlowBreak(currentPublisher, true);
            currentPublisher.Font = new Font("Exo ExtraBold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            currentPublisher.ForeColor = SystemColors.Menu;
            currentPublisher.Location = new Point(3, 15);
            currentPublisher.Margin = new Padding(3, 15, 10, 0);
            currentPublisher.Name = "currentPublisher";
            currentPublisher.Size = new Size(86, 24);
            currentPublisher.TabIndex = 1;
            currentPublisher.Text = "Publisher";
            // 
            // yearOfPublication
            // 
            yearOfPublication.AutoSize = true;
            currentPublisherPanel.SetFlowBreak(yearOfPublication, true);
            yearOfPublication.Font = new Font("Exo ExtraBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            yearOfPublication.ForeColor = SystemColors.Menu;
            yearOfPublication.Location = new Point(3, 39);
            yearOfPublication.Margin = new Padding(3, 0, 10, 0);
            yearOfPublication.Name = "yearOfPublication";
            yearOfPublication.Size = new Size(47, 21);
            yearOfPublication.TabIndex = 2;
            yearOfPublication.Text = "2022";
            // 
            // optionPanel
            // 
            optionPanel.Controls.Add(optionsFlowPanel);
            optionPanel.Dock = DockStyle.Fill;
            optionPanel.GradientAngle = 90F;
            optionPanel.GradientPrimaryColor = Color.Black;
            optionPanel.GradientSecondaryColor = Color.Empty;
            optionPanel.Location = new Point(0, 746);
            optionPanel.Margin = new Padding(0);
            optionPanel.Name = "optionPanel";
            optionPanel.Size = new Size(430, 100);
            optionPanel.TabIndex = 7;
            // 
            // optionsFlowPanel
            // 
            optionsFlowPanel.Controls.Add(heartOption);
            optionsFlowPanel.Controls.Add(textToSpeech);
            optionsFlowPanel.Controls.Add(brightness);
            optionsFlowPanel.Dock = DockStyle.Fill;
            optionsFlowPanel.FlowDirection = FlowDirection.RightToLeft;
            optionsFlowPanel.Location = new Point(0, 0);
            optionsFlowPanel.Name = "optionsFlowPanel";
            optionsFlowPanel.Size = new Size(430, 100);
            optionsFlowPanel.TabIndex = 0;
            // 
            // heartOption
            // 
            heartOption.Image = (Image)resources.GetObject("heartOption.Image");
            heartOption.Location = new Point(353, 30);
            heartOption.Margin = new Padding(10, 30, 30, 30);
            heartOption.Name = "heartOption";
            heartOption.Size = new Size(47, 41);
            heartOption.TabIndex = 0;
            // 
            // textToSpeech
            // 
            textToSpeech.Enabled = false;
            textToSpeech.Image = (Image)resources.GetObject("textToSpeech.Image");
            textToSpeech.Location = new Point(296, 30);
            textToSpeech.Margin = new Padding(10, 30, 0, 30);
            textToSpeech.Name = "textToSpeech";
            textToSpeech.Size = new Size(47, 41);
            textToSpeech.TabIndex = 1;
            // 
            // brightness
            // 
            brightness.Enabled = false;
            brightness.Image = (Image)resources.GetObject("brightness.Image");
            brightness.Location = new Point(239, 30);
            brightness.Margin = new Padding(15, 30, 0, 30);
            brightness.Name = "brightness";
            brightness.Size = new Size(47, 41);
            brightness.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(200, 100);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label3, 1, 0);
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = Color.Gray;
            label3.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(91, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 88);
            label3.TabIndex = 1;
            label3.Text = "label1";
            // 
            // label4
            // 
            label4.BackColor = Color.DimGray;
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 88);
            label4.TabIndex = 0;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(tableLayoutPanel6);
            flowLayoutPanel5.Location = new Point(0, 0);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(200, 100);
            flowLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.AutoSize = true;
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(label9, 1, 0);
            tableLayoutPanel6.Controls.Add(label10, 0, 0);
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel6.Size = new Size(194, 88);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label9
            // 
            label9.BackColor = Color.Gray;
            label9.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLight;
            label9.Location = new Point(91, 0);
            label9.Name = "label9";
            label9.Size = new Size(100, 88);
            label9.TabIndex = 1;
            label9.Text = "label1";
            // 
            // label10
            // 
            label10.BackColor = Color.DimGray;
            label10.Image = (Image)resources.GetObject("label10.Image");
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(82, 88);
            label10.TabIndex = 0;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Location = new Point(0, 0);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(200, 100);
            flowLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.AutoSize = true;
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label11, 1, 0);
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.Size = new Size(200, 100);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label11
            // 
            label11.BackColor = Color.Gray;
            label11.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ControlLight;
            label11.Location = new Point(91, 0);
            label11.Name = "label11";
            label11.Size = new Size(106, 88);
            label11.TabIndex = 1;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.BackColor = Color.DimGray;
            label12.Image = (Image)resources.GetObject("label12.Image");
            label12.Location = new Point(3, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 88);
            label12.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(label5);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel10);
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(200, 100);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // label5
            // 
            flowLayoutPanel3.SetFlowBreak(label5, true);
            label5.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(735, 82);
            label5.TabIndex = 0;
            label5.Text = "Hello!";
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(tableLayoutPanel4);
            flowLayoutPanel8.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel8.Location = new Point(3, 85);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(352, 88);
            flowLayoutPanel8.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label6, 1, 0);
            tableLayoutPanel4.Controls.Add(label15, 0, 0);
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel4.Size = new Size(346, 88);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label6
            // 
            label6.BackColor = Color.Gray;
            label6.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(91, 0);
            label6.Name = "label6";
            label6.Size = new Size(252, 88);
            label6.TabIndex = 1;
            label6.Text = "title";
            // 
            // label15
            // 
            label15.BackColor = Color.DimGray;
            label15.Image = (Image)resources.GetObject("label15.Image");
            label15.Location = new Point(3, 0);
            label15.Name = "label15";
            label15.Size = new Size(82, 88);
            label15.TabIndex = 0;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(tableLayoutPanel9);
            flowLayoutPanel9.Location = new Point(3, 97);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(370, 88);
            flowLayoutPanel9.TabIndex = 2;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.AutoSize = true;
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(label16, 1, 0);
            tableLayoutPanel9.Controls.Add(label17, 0, 0);
            tableLayoutPanel9.Location = new Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel9.Size = new Size(362, 88);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // label16
            // 
            label16.BackColor = Color.Gray;
            label16.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = SystemColors.ControlLight;
            label16.Location = new Point(91, 0);
            label16.Name = "label16";
            label16.Size = new Size(268, 88);
            label16.TabIndex = 1;
            label16.Text = "label16";
            // 
            // label17
            // 
            label17.BackColor = Color.DimGray;
            label17.Image = (Image)resources.GetObject("label17.Image");
            label17.Location = new Point(3, 0);
            label17.Name = "label17";
            label17.Size = new Size(82, 88);
            label17.TabIndex = 0;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Controls.Add(tableLayoutPanel10);
            flowLayoutPanel10.Controls.Add(flowLayoutPanel11);
            flowLayoutPanel10.Location = new Point(3, 179);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(352, 88);
            flowLayoutPanel10.TabIndex = 2;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.AutoSize = true;
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel10.Controls.Add(label18, 1, 0);
            tableLayoutPanel10.Controls.Add(label19, 0, 0);
            tableLayoutPanel10.Location = new Point(3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel10.Size = new Size(346, 88);
            tableLayoutPanel10.TabIndex = 0;
            // 
            // label18
            // 
            label18.BackColor = Color.Gray;
            label18.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = SystemColors.ControlLight;
            label18.Location = new Point(91, 0);
            label18.Name = "label18";
            label18.Size = new Size(252, 88);
            label18.TabIndex = 1;
            label18.Text = "title";
            // 
            // label19
            // 
            label19.BackColor = Color.DimGray;
            label19.Image = (Image)resources.GetObject("label19.Image");
            label19.Location = new Point(3, 0);
            label19.Name = "label19";
            label19.Size = new Size(82, 88);
            label19.TabIndex = 0;
            // 
            // flowLayoutPanel11
            // 
            flowLayoutPanel11.Controls.Add(tableLayoutPanel11);
            flowLayoutPanel11.Location = new Point(3, 97);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            flowLayoutPanel11.Size = new Size(370, 88);
            flowLayoutPanel11.TabIndex = 2;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.AutoSize = true;
            tableLayoutPanel11.ColumnCount = 2;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.Controls.Add(label20, 1, 0);
            tableLayoutPanel11.Controls.Add(label21, 0, 0);
            tableLayoutPanel11.Location = new Point(3, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel11.Size = new Size(362, 88);
            tableLayoutPanel11.TabIndex = 0;
            // 
            // label20
            // 
            label20.BackColor = Color.Gray;
            label20.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label20.ForeColor = SystemColors.ControlLight;
            label20.Location = new Point(91, 0);
            label20.Name = "label20";
            label20.Size = new Size(268, 88);
            label20.TabIndex = 1;
            label20.Text = "label20";
            // 
            // label21
            // 
            label21.BackColor = Color.DimGray;
            label21.Image = (Image)resources.GetObject("label21.Image");
            label21.Location = new Point(3, 0);
            label21.Name = "label21";
            label21.Size = new Size(82, 88);
            label21.TabIndex = 0;
            // 
            // flowLayoutPanel12
            // 
            flowLayoutPanel12.Controls.Add(tableLayoutPanel12);
            flowLayoutPanel12.Location = new Point(0, 0);
            flowLayoutPanel12.Name = "flowLayoutPanel12";
            flowLayoutPanel12.Size = new Size(200, 100);
            flowLayoutPanel12.TabIndex = 0;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.AutoSize = true;
            tableLayoutPanel12.ColumnCount = 2;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Controls.Add(label22, 1, 0);
            tableLayoutPanel12.Controls.Add(label23, 0, 0);
            tableLayoutPanel12.Location = new Point(3, 3);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel12.Size = new Size(194, 88);
            tableLayoutPanel12.TabIndex = 0;
            // 
            // label22
            // 
            label22.BackColor = Color.Gray;
            label22.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label22.ForeColor = SystemColors.ControlLight;
            label22.Location = new Point(91, 0);
            label22.Name = "label22";
            label22.Size = new Size(100, 88);
            label22.TabIndex = 1;
            label22.Text = "title";
            // 
            // label23
            // 
            label23.BackColor = Color.DimGray;
            label23.Image = (Image)resources.GetObject("label23.Image");
            label23.Location = new Point(3, 0);
            label23.Name = "label23";
            label23.Size = new Size(82, 88);
            label23.TabIndex = 0;
            // 
            // flowLayoutPanel13
            // 
            flowLayoutPanel13.Location = new Point(0, 0);
            flowLayoutPanel13.Name = "flowLayoutPanel13";
            flowLayoutPanel13.Size = new Size(200, 100);
            flowLayoutPanel13.TabIndex = 0;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.AutoSize = true;
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Controls.Add(label24, 1, 0);
            tableLayoutPanel13.Location = new Point(0, 0);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.Size = new Size(200, 100);
            tableLayoutPanel13.TabIndex = 0;
            // 
            // label24
            // 
            label24.BackColor = Color.Gray;
            label24.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = SystemColors.ControlLight;
            label24.Location = new Point(91, 0);
            label24.Name = "label24";
            label24.Size = new Size(106, 88);
            label24.TabIndex = 1;
            label24.Text = "label24";
            // 
            // label25
            // 
            label25.BackColor = Color.DimGray;
            label25.Image = (Image)resources.GetObject("label25.Image");
            label25.Location = new Point(3, 0);
            label25.Name = "label25";
            label25.Size = new Size(82, 88);
            label25.TabIndex = 0;
            // 
            // flowLayoutPanel14
            // 
            flowLayoutPanel14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel14.AutoSize = true;
            flowLayoutPanel14.Controls.Add(label26);
            flowLayoutPanel14.Controls.Add(flowLayoutPanel15);
            flowLayoutPanel14.Controls.Add(flowLayoutPanel17);
            flowLayoutPanel14.Location = new Point(0, 0);
            flowLayoutPanel14.Name = "flowLayoutPanel14";
            flowLayoutPanel14.Size = new Size(200, 100);
            flowLayoutPanel14.TabIndex = 0;
            // 
            // label26
            // 
            flowLayoutPanel14.SetFlowBreak(label26, true);
            label26.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label26.ForeColor = SystemColors.ControlLightLight;
            label26.Location = new Point(3, 0);
            label26.Name = "label26";
            label26.Size = new Size(735, 82);
            label26.TabIndex = 0;
            label26.Text = "Hello!";
            // 
            // flowLayoutPanel15
            // 
            flowLayoutPanel15.Controls.Add(tableLayoutPanel14);
            flowLayoutPanel15.Controls.Add(flowLayoutPanel16);
            flowLayoutPanel15.Location = new Point(3, 85);
            flowLayoutPanel15.Name = "flowLayoutPanel15";
            flowLayoutPanel15.Size = new Size(352, 88);
            flowLayoutPanel15.TabIndex = 1;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.AutoSize = true;
            tableLayoutPanel14.ColumnCount = 2;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel14.Controls.Add(label27, 1, 0);
            tableLayoutPanel14.Controls.Add(label28, 0, 0);
            tableLayoutPanel14.Location = new Point(3, 3);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel14.Size = new Size(346, 88);
            tableLayoutPanel14.TabIndex = 0;
            // 
            // label27
            // 
            label27.BackColor = Color.Gray;
            label27.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label27.ForeColor = SystemColors.ControlLight;
            label27.Location = new Point(91, 0);
            label27.Name = "label27";
            label27.Size = new Size(252, 88);
            label27.TabIndex = 1;
            label27.Text = "title";
            // 
            // label28
            // 
            label28.BackColor = Color.DimGray;
            label28.Image = (Image)resources.GetObject("label28.Image");
            label28.Location = new Point(3, 0);
            label28.Name = "label28";
            label28.Size = new Size(82, 88);
            label28.TabIndex = 0;
            // 
            // flowLayoutPanel16
            // 
            flowLayoutPanel16.Controls.Add(tableLayoutPanel15);
            flowLayoutPanel16.Location = new Point(3, 97);
            flowLayoutPanel16.Name = "flowLayoutPanel16";
            flowLayoutPanel16.Size = new Size(370, 88);
            flowLayoutPanel16.TabIndex = 2;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.AutoSize = true;
            tableLayoutPanel15.ColumnCount = 2;
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel15.Controls.Add(label29, 1, 0);
            tableLayoutPanel15.Controls.Add(label30, 0, 0);
            tableLayoutPanel15.Location = new Point(3, 3);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel15.Size = new Size(362, 88);
            tableLayoutPanel15.TabIndex = 0;
            // 
            // label29
            // 
            label29.BackColor = Color.Gray;
            label29.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label29.ForeColor = SystemColors.ControlLight;
            label29.Location = new Point(91, 0);
            label29.Name = "label29";
            label29.Size = new Size(268, 88);
            label29.TabIndex = 1;
            label29.Text = "label29";
            // 
            // label30
            // 
            label30.BackColor = Color.DimGray;
            label30.Image = (Image)resources.GetObject("label30.Image");
            label30.Location = new Point(3, 0);
            label30.Name = "label30";
            label30.Size = new Size(82, 88);
            label30.TabIndex = 0;
            // 
            // flowLayoutPanel17
            // 
            flowLayoutPanel17.Controls.Add(tableLayoutPanel16);
            flowLayoutPanel17.Controls.Add(flowLayoutPanel18);
            flowLayoutPanel17.Location = new Point(3, 179);
            flowLayoutPanel17.Name = "flowLayoutPanel17";
            flowLayoutPanel17.Size = new Size(352, 88);
            flowLayoutPanel17.TabIndex = 2;
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.AutoSize = true;
            tableLayoutPanel16.ColumnCount = 2;
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel16.Controls.Add(label31, 1, 0);
            tableLayoutPanel16.Controls.Add(label32, 0, 0);
            tableLayoutPanel16.Location = new Point(3, 3);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 1;
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel16.Size = new Size(346, 88);
            tableLayoutPanel16.TabIndex = 0;
            // 
            // label31
            // 
            label31.BackColor = Color.Gray;
            label31.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label31.ForeColor = SystemColors.ControlLight;
            label31.Location = new Point(91, 0);
            label31.Name = "label31";
            label31.Size = new Size(252, 88);
            label31.TabIndex = 1;
            label31.Text = "title";
            // 
            // label32
            // 
            label32.BackColor = Color.DimGray;
            label32.Image = (Image)resources.GetObject("label32.Image");
            label32.Location = new Point(3, 0);
            label32.Name = "label32";
            label32.Size = new Size(82, 88);
            label32.TabIndex = 0;
            // 
            // flowLayoutPanel18
            // 
            flowLayoutPanel18.Controls.Add(tableLayoutPanel17);
            flowLayoutPanel18.Location = new Point(3, 97);
            flowLayoutPanel18.Name = "flowLayoutPanel18";
            flowLayoutPanel18.Size = new Size(370, 88);
            flowLayoutPanel18.TabIndex = 2;
            // 
            // tableLayoutPanel17
            // 
            tableLayoutPanel17.AutoSize = true;
            tableLayoutPanel17.ColumnCount = 2;
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel17.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel17.Controls.Add(label33, 1, 0);
            tableLayoutPanel17.Controls.Add(label34, 0, 0);
            tableLayoutPanel17.Location = new Point(3, 3);
            tableLayoutPanel17.Name = "tableLayoutPanel17";
            tableLayoutPanel17.RowCount = 1;
            tableLayoutPanel17.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel17.Size = new Size(362, 88);
            tableLayoutPanel17.TabIndex = 0;
            // 
            // label33
            // 
            label33.BackColor = Color.Gray;
            label33.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label33.ForeColor = SystemColors.ControlLight;
            label33.Location = new Point(91, 0);
            label33.Name = "label33";
            label33.Size = new Size(268, 88);
            label33.TabIndex = 1;
            label33.Text = "label33";
            // 
            // label34
            // 
            label34.BackColor = Color.DimGray;
            label34.Image = (Image)resources.GetObject("label34.Image");
            label34.Location = new Point(3, 0);
            label34.Name = "label34";
            label34.Size = new Size(82, 88);
            label34.TabIndex = 0;
            // 
            // flowLayoutPanel19
            // 
            flowLayoutPanel19.Controls.Add(tableLayoutPanel18);
            flowLayoutPanel19.Location = new Point(0, 0);
            flowLayoutPanel19.Name = "flowLayoutPanel19";
            flowLayoutPanel19.Size = new Size(200, 100);
            flowLayoutPanel19.TabIndex = 0;
            // 
            // tableLayoutPanel18
            // 
            tableLayoutPanel18.AutoSize = true;
            tableLayoutPanel18.ColumnCount = 2;
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel18.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel18.Controls.Add(label35, 1, 0);
            tableLayoutPanel18.Controls.Add(label36, 0, 0);
            tableLayoutPanel18.Location = new Point(3, 3);
            tableLayoutPanel18.Name = "tableLayoutPanel18";
            tableLayoutPanel18.RowCount = 1;
            tableLayoutPanel18.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel18.Size = new Size(194, 88);
            tableLayoutPanel18.TabIndex = 0;
            // 
            // label35
            // 
            label35.BackColor = Color.Gray;
            label35.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label35.ForeColor = SystemColors.ControlLight;
            label35.Location = new Point(91, 0);
            label35.Name = "label35";
            label35.Size = new Size(100, 88);
            label35.TabIndex = 1;
            label35.Text = "title";
            // 
            // label36
            // 
            label36.BackColor = Color.DimGray;
            label36.Image = (Image)resources.GetObject("label36.Image");
            label36.Location = new Point(3, 0);
            label36.Name = "label36";
            label36.Size = new Size(82, 88);
            label36.TabIndex = 0;
            // 
            // flowLayoutPanel20
            // 
            flowLayoutPanel20.Location = new Point(0, 0);
            flowLayoutPanel20.Name = "flowLayoutPanel20";
            flowLayoutPanel20.Size = new Size(200, 100);
            flowLayoutPanel20.TabIndex = 0;
            // 
            // tableLayoutPanel19
            // 
            tableLayoutPanel19.AutoSize = true;
            tableLayoutPanel19.ColumnCount = 2;
            tableLayoutPanel19.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel19.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel19.Controls.Add(label37, 1, 0);
            tableLayoutPanel19.Location = new Point(0, 0);
            tableLayoutPanel19.Name = "tableLayoutPanel19";
            tableLayoutPanel19.RowCount = 1;
            tableLayoutPanel19.Size = new Size(200, 100);
            tableLayoutPanel19.TabIndex = 0;
            // 
            // label37
            // 
            label37.BackColor = Color.Gray;
            label37.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label37.ForeColor = SystemColors.ControlLight;
            label37.Location = new Point(91, 0);
            label37.Name = "label37";
            label37.Size = new Size(106, 88);
            label37.TabIndex = 1;
            label37.Text = "label37";
            // 
            // label38
            // 
            label38.BackColor = Color.DimGray;
            label38.Image = (Image)resources.GetObject("label38.Image");
            label38.Location = new Point(3, 0);
            label38.Name = "label38";
            label38.Size = new Size(82, 88);
            label38.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(111, 100);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(110, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(110, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(110, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(110, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // gradientPanel2
            // 
            gradientPanel2.GradientAngle = 0F;
            gradientPanel2.GradientPrimaryColor = Color.Empty;
            gradientPanel2.GradientSecondaryColor = Color.Empty;
            gradientPanel2.Location = new Point(0, 0);
            gradientPanel2.Name = "gradientPanel2";
            gradientPanel2.Size = new Size(200, 100);
            gradientPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.AutoSize = true;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(label7, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(200, 100);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlLight;
            label7.Location = new Point(91, 0);
            label7.Name = "label7";
            label7.Size = new Size(106, 88);
            label7.TabIndex = 1;
            label7.Text = "title";
            // 
            // label8
            // 
            label8.BackColor = Color.DimGray;
            label8.Image = (Image)resources.GetObject("label8.Image");
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(82, 88);
            label8.TabIndex = 0;
            // 
            // gradientPanel4
            // 
            gradientPanel4.GradientAngle = 0F;
            gradientPanel4.GradientPrimaryColor = Color.Empty;
            gradientPanel4.GradientSecondaryColor = Color.Empty;
            gradientPanel4.Location = new Point(0, 0);
            gradientPanel4.Name = "gradientPanel4";
            gradientPanel4.Size = new Size(200, 100);
            gradientPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel40
            // 
            tableLayoutPanel40.AutoSize = true;
            tableLayoutPanel40.ColumnCount = 2;
            tableLayoutPanel40.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel40.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel40.Controls.Add(label79, 1, 0);
            tableLayoutPanel40.Dock = DockStyle.Fill;
            tableLayoutPanel40.Location = new Point(0, 0);
            tableLayoutPanel40.Name = "tableLayoutPanel40";
            tableLayoutPanel40.RowCount = 1;
            tableLayoutPanel40.Size = new Size(200, 100);
            tableLayoutPanel40.TabIndex = 0;
            // 
            // label79
            // 
            label79.BackColor = Color.Transparent;
            label79.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label79.ForeColor = SystemColors.ControlLight;
            label79.Location = new Point(91, 0);
            label79.Name = "label79";
            label79.Size = new Size(106, 88);
            label79.TabIndex = 1;
            label79.Text = "title";
            // 
            // label80
            // 
            label80.BackColor = Color.DimGray;
            label80.Image = (Image)resources.GetObject("label80.Image");
            label80.Location = new Point(3, 0);
            label80.Name = "label80";
            label80.Size = new Size(82, 88);
            label80.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.Font = new Font("Exo ExtraBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1280, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, viewToolStripMenuItem1, helpToolStripMenuItem1 });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Navy;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(34, 24);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(129, 26);
            fileToolStripMenuItem1.Text = "File";
            // 
            // viewToolStripMenuItem1
            // 
            viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            viewToolStripMenuItem1.Size = new Size(129, 26);
            viewToolStripMenuItem1.Text = "View";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(129, 26);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.BackColor = Color.Transparent;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Crimson;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.TextAlign = ContentAlignment.MiddleRight;
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Alignment = ToolStripItemAlignment.Right;
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Alignment = ToolStripItemAlignment.Right;
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 846);
            Controls.Add(toolStrip1);
            Controls.Add(searchTabeLayout);
            DoubleBuffered = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            toolTip1.SetToolTip(this, "user");
            Load += MainForm_Load;
            searchTabeLayout.ResumeLayout(false);
            verticalMenuBar.ResumeLayout(false);
            verticalTableMenu.ResumeLayout(false);
            homeGradientPanel.ResumeLayout(false);
            searchGradientPanel.ResumeLayout(false);
            heartGradientPanel.ResumeLayout(false);
            libraryGradientPanel.ResumeLayout(false);
            recentGradientPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentContainer.ResumeLayout(false);
            contentContainer.PerformLayout();
            category0.ResumeLayout(false);
            category0.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel40.ResumeLayout(false);
            flowLayoutPanel40.PerformLayout();
            tableLayoutPanel39.ResumeLayout(false);
            mainFlowPanel.ResumeLayout(false);
            homeFlowPanel.ResumeLayout(false);
            homeFlowPanel.PerformLayout();
            helloPanel.ResumeLayout(false);
            helloElement0.ResumeLayout(false);
            helloElement0.PerformLayout();
            helloElementTable0.ResumeLayout(false);
            helloElementTable0.PerformLayout();
            helloFlow0.ResumeLayout(false);
            helloFlow0.PerformLayout();
            helloElement1.ResumeLayout(false);
            helloElement1.PerformLayout();
            helloElementTable1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            helloElement2.ResumeLayout(false);
            helloElement2.PerformLayout();
            helloElementTable2.ResumeLayout(false);
            helloFlow2.ResumeLayout(false);
            helloFlow2.PerformLayout();
            helloElement3.ResumeLayout(false);
            helloElement3.PerformLayout();
            helloElementTable3.ResumeLayout(false);
            helloFlow3.ResumeLayout(false);
            helloFlow3.PerformLayout();
            recommentPanel.ResumeLayout(false);
            flowLayoutPanel22.ResumeLayout(false);
            flowLayoutPanel22.PerformLayout();
            tableLayoutPanel20.ResumeLayout(false);
            flowLayoutPanel23.ResumeLayout(false);
            flowLayoutPanel23.PerformLayout();
            tableLayoutPanel21.ResumeLayout(false);
            flowLayoutPanel24.ResumeLayout(false);
            flowLayoutPanel24.PerformLayout();
            tableLayoutPanel22.ResumeLayout(false);
            flowLayoutPanel25.ResumeLayout(false);
            flowLayoutPanel25.PerformLayout();
            tableLayoutPanel23.ResumeLayout(false);
            flowLayoutPanel26.ResumeLayout(false);
            flowLayoutPanel26.PerformLayout();
            tableLayoutPanel24.ResumeLayout(false);
            flowLayoutPanel27.ResumeLayout(false);
            flowLayoutPanel27.PerformLayout();
            tableLayoutPanel25.ResumeLayout(false);
            recentPanel.ResumeLayout(false);
            flowLayoutPanel28.ResumeLayout(false);
            flowLayoutPanel28.PerformLayout();
            tableLayoutPanel26.ResumeLayout(false);
            flowLayoutPanel29.ResumeLayout(false);
            flowLayoutPanel29.PerformLayout();
            tableLayoutPanel27.ResumeLayout(false);
            flowLayoutPanel30.ResumeLayout(false);
            flowLayoutPanel30.PerformLayout();
            tableLayoutPanel28.ResumeLayout(false);
            flowLayoutPanel31.ResumeLayout(false);
            flowLayoutPanel31.PerformLayout();
            tableLayoutPanel29.ResumeLayout(false);
            flowLayoutPanel32.ResumeLayout(false);
            flowLayoutPanel32.PerformLayout();
            tableLayoutPanel30.ResumeLayout(false);
            flowLayoutPanel33.ResumeLayout(false);
            flowLayoutPanel33.PerformLayout();
            tableLayoutPanel31.ResumeLayout(false);
            bestBookPanel.ResumeLayout(false);
            flowLayoutPanel34.ResumeLayout(false);
            flowLayoutPanel34.PerformLayout();
            tableLayoutPanel32.ResumeLayout(false);
            flowLayoutPanel35.ResumeLayout(false);
            flowLayoutPanel35.PerformLayout();
            tableLayoutPanel33.ResumeLayout(false);
            flowLayoutPanel36.ResumeLayout(false);
            flowLayoutPanel36.PerformLayout();
            tableLayoutPanel34.ResumeLayout(false);
            flowLayoutPanel37.ResumeLayout(false);
            flowLayoutPanel37.PerformLayout();
            tableLayoutPanel35.ResumeLayout(false);
            flowLayoutPanel38.ResumeLayout(false);
            flowLayoutPanel38.PerformLayout();
            tableLayoutPanel36.ResumeLayout(false);
            flowLayoutPanel39.ResumeLayout(false);
            flowLayoutPanel39.PerformLayout();
            tableLayoutPanel37.ResumeLayout(false);
            searchFlowPanel.ResumeLayout(false);
            searchFlowPanel.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchLayoutTable.ResumeLayout(false);
            searchBoxContainer.ResumeLayout(false);
            bestMatchPanel.ResumeLayout(false);
            bestMatchResult.ResumeLayout(false);
            bestMatchResult.PerformLayout();
            bestMatchTableLayout.ResumeLayout(false);
            flowLayoutPanel49.ResumeLayout(false);
            flowLayoutPanel49.PerformLayout();
            tableLayoutPanel45.ResumeLayout(false);
            flowLayoutPanel61.ResumeLayout(false);
            flowLayoutPanel62.ResumeLayout(false);
            flowLayoutPanel62.PerformLayout();
            tableLayoutPanel56.ResumeLayout(false);
            flowLayoutPanel63.ResumeLayout(false);
            flowLayoutPanel63.PerformLayout();
            tableLayoutPanel57.ResumeLayout(false);
            flowLayoutPanel64.ResumeLayout(false);
            flowLayoutPanel64.PerformLayout();
            tableLayoutPanel58.ResumeLayout(false);
            flowLayoutPanel65.ResumeLayout(false);
            flowLayoutPanel65.PerformLayout();
            tableLayoutPanel59.ResumeLayout(false);
            flowLayoutPanel66.ResumeLayout(false);
            flowLayoutPanel66.PerformLayout();
            tableLayoutPanel60.ResumeLayout(false);
            flowLayoutPanel67.ResumeLayout(false);
            flowLayoutPanel67.PerformLayout();
            tableLayoutPanel61.ResumeLayout(false);
            currentPanel.ResumeLayout(false);
            currentProperties.ResumeLayout(false);
            currentPropertiesTable.ResumeLayout(false);
            currentBookPanel.ResumeLayout(false);
            currentBookPanel.PerformLayout();
            currentPagePanel.ResumeLayout(false);
            currentPagePanel.PerformLayout();
            currentPublisherPanel.ResumeLayout(false);
            currentPublisherPanel.PerformLayout();
            optionPanel.ResumeLayout(false);
            optionsFlowPanel.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel10.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel12.ResumeLayout(false);
            flowLayoutPanel12.PerformLayout();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            flowLayoutPanel14.ResumeLayout(false);
            flowLayoutPanel15.ResumeLayout(false);
            flowLayoutPanel15.PerformLayout();
            tableLayoutPanel14.ResumeLayout(false);
            flowLayoutPanel16.ResumeLayout(false);
            flowLayoutPanel16.PerformLayout();
            tableLayoutPanel15.ResumeLayout(false);
            flowLayoutPanel17.ResumeLayout(false);
            flowLayoutPanel17.PerformLayout();
            tableLayoutPanel16.ResumeLayout(false);
            flowLayoutPanel18.ResumeLayout(false);
            flowLayoutPanel18.PerformLayout();
            tableLayoutPanel17.ResumeLayout(false);
            flowLayoutPanel19.ResumeLayout(false);
            flowLayoutPanel19.PerformLayout();
            tableLayoutPanel18.ResumeLayout(false);
            tableLayoutPanel19.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel40.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void FlowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            SetStyle(ControlStyles.UserMouse | ControlStyles.Selectable, true);
        }


        #endregion


        private TableLayoutPanel searchTabeLayout;
        private Label userLabel;
        private FlowLayoutPanel verticalMenuBar;
        private Label searchLabel;
        private Label heartLabel;
        private Label homeLabel;
        private Label librariesLabel;
        private Label recentLabel;
        private FlowLayoutPanel contentPanel;
        private FlowLayoutPanel mainFlowPanel;
        private FlowLayoutPanel homeFlowPanel;
        private FlowLayoutPanel helloPanel;
        private Label helloLabel;
        private Label helloElementImg0;
        private Label helloElementTitle0;
        private TableLayoutPanel helloElementTable0;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label9;
        private Label label10;
        private FlowLayoutPanel flowLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label11;
        private Label label12;
        private FlowLayoutPanel recommentPanel;
        private Label recommentLabel;
        private FlowLayoutPanel flowLayoutPanel22;
        private TableLayoutPanel tableLayoutPanel20;
        private Label label40;
        private Label label41;
        private FlowLayoutPanel flowLayoutPanel23;
        private TableLayoutPanel tableLayoutPanel21;
        private Label label42;
        private Label label43;
        private FlowLayoutPanel flowLayoutPanel24;
        private TableLayoutPanel tableLayoutPanel22;
        private Label label44;
        private Label label45;
        private FlowLayoutPanel flowLayoutPanel25;
        private TableLayoutPanel tableLayoutPanel23;
        private Label label46;
        private Label label47;
        private FlowLayoutPanel flowLayoutPanel26;
        private TableLayoutPanel tableLayoutPanel24;
        private Label label48;
        private Label label49;
        private FlowLayoutPanel flowLayoutPanel27;
        private TableLayoutPanel tableLayoutPanel25;
        private Label label50;
        private Label label51;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label6;
        private Label label15;
        private FlowLayoutPanel flowLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label16;
        private Label label17;
        private FlowLayoutPanel flowLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel10;
        private Label label18;
        private Label label19;
        private FlowLayoutPanel flowLayoutPanel11;
        private TableLayoutPanel tableLayoutPanel11;
        private Label label20;
        private Label label21;
        private FlowLayoutPanel flowLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel12;
        private Label label22;
        private Label label23;
        private FlowLayoutPanel flowLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel13;
        private Label label24;
        private Label label25;
        private FlowLayoutPanel flowLayoutPanel14;
        private Label label26;
        private FlowLayoutPanel flowLayoutPanel15;
        private TableLayoutPanel tableLayoutPanel14;
        private Label label27;
        private Label label28;
        private FlowLayoutPanel flowLayoutPanel16;
        private TableLayoutPanel tableLayoutPanel15;
        private Label label29;
        private Label label30;
        private FlowLayoutPanel flowLayoutPanel17;
        private TableLayoutPanel tableLayoutPanel16;
        private Label label31;
        private Label label32;
        private FlowLayoutPanel flowLayoutPanel18;
        private TableLayoutPanel tableLayoutPanel17;
        private Label label33;
        private Label label34;
        private FlowLayoutPanel flowLayoutPanel19;
        private TableLayoutPanel tableLayoutPanel18;
        private Label label35;
        private Label label36;
        private FlowLayoutPanel flowLayoutPanel20;
        private TableLayoutPanel tableLayoutPanel19;
        private Label label37;
        private Label label38;
        private FlowLayoutPanel recentPanel;
        private Label recentReadPanel;
        private FlowLayoutPanel flowLayoutPanel28;
        private TableLayoutPanel tableLayoutPanel26;
        private Label label52;
        private Label label53;
        private FlowLayoutPanel flowLayoutPanel29;
        private TableLayoutPanel tableLayoutPanel27;
        private Label label54;
        private Label label55;
        private FlowLayoutPanel flowLayoutPanel30;
        private TableLayoutPanel tableLayoutPanel28;
        private Label label56;
        private Label label57;
        private FlowLayoutPanel flowLayoutPanel31;
        private TableLayoutPanel tableLayoutPanel29;
        private Label label58;
        private Label label59;
        private FlowLayoutPanel flowLayoutPanel32;
        private TableLayoutPanel tableLayoutPanel30;
        private Label label60;
        private Label label61;
        private FlowLayoutPanel flowLayoutPanel33;
        private TableLayoutPanel tableLayoutPanel31;
        private Label label62;
        private Label label63;
        private FlowLayoutPanel bestBookPanel;
        private Label bestBookLabel;
        private FlowLayoutPanel flowLayoutPanel34;
        private TableLayoutPanel tableLayoutPanel32;
        private Label label64;
        private Label label65;
        private FlowLayoutPanel flowLayoutPanel35;
        private TableLayoutPanel tableLayoutPanel33;
        private Label label66;
        private Label label67;
        private FlowLayoutPanel flowLayoutPanel36;
        private TableLayoutPanel tableLayoutPanel34;
        private Label label68;
        private Label label69;
        private FlowLayoutPanel flowLayoutPanel37;
        private TableLayoutPanel tableLayoutPanel35;
        private Label label70;
        private Label label71;
        private FlowLayoutPanel flowLayoutPanel38;
        private TableLayoutPanel tableLayoutPanel36;
        private Label label72;
        private Label label73;
        private FlowLayoutPanel flowLayoutPanel39;
        private TableLayoutPanel tableLayoutPanel37;
        private Label label74;
        private Label label75;
        private FlowLayoutPanel searchFlowPanel;
        private FlowLayoutPanel searchPanel;
        private TableLayoutPanel searchLayoutTable;
        private Label searchImg;
        private FlowLayoutPanel bestMatchPanel;
        private Label bestMatchLabel;
        private FlowLayoutPanel bestMatchResult;
        private TableLayoutPanel bestMatchTableLayout;
        private Label label89;
        private Label label90;
        private FlowLayoutPanel flowLayoutPanel49;
        private TableLayoutPanel tableLayoutPanel45;
        private Label label91;
        private Label label92;
        private FlowLayoutPanel flowLayoutPanel61;
        private Label label114;
        private FlowLayoutPanel flowLayoutPanel62;
        private TableLayoutPanel tableLayoutPanel56;
        private Label label115;
        private Label label116;
        private FlowLayoutPanel flowLayoutPanel63;
        private TableLayoutPanel tableLayoutPanel57;
        private Label label117;
        private Label label118;
        private FlowLayoutPanel flowLayoutPanel64;
        private TableLayoutPanel tableLayoutPanel58;
        private Label label119;
        private Label label120;
        private FlowLayoutPanel flowLayoutPanel65;
        private TableLayoutPanel tableLayoutPanel59;
        private Label label121;
        private Label label122;
        private FlowLayoutPanel flowLayoutPanel66;
        private TableLayoutPanel tableLayoutPanel60;
        private Label label123;
        private Label label124;
        private FlowLayoutPanel flowLayoutPanel67;
        private TableLayoutPanel tableLayoutPanel61;
        private Label label125;
        private Label label126;
        private ContextMenuStrip contextMenuStrip1;
        private FlowLayoutPanel contentContainer;
        private Label contentImg;
        private Label contentTitle;
        private Label authorLabel;
        private Label publisherLabel;
        private Label aboutAuthor;
        private Label authorDesLabel;
        private Label categoryLabel;
        private FlowLayoutPanel category0;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label39;
        private Label label76;
        private FlowLayoutPanel flowLayoutPanel40;
        private TableLayoutPanel tableLayoutPanel39;
        private Label label77;
        private Label label78;
        private ToolTip toolTip1;
        private GradientPanel helloElement1;
        private GradientPanel helloElement0;
        private TableLayoutPanel helloElementTable1;
        private Label helloElementTitle1;
        private Label helloElementImg1;
        private GradientPanel helloElement2;
        private TableLayoutPanel helloElementTable2;
        private Label helloElementTitle2;
        private Label helloElementImg2;
        private GradientPanel helloElement3;
        private TableLayoutPanel helloElementTable3;
        private Label helloElementTitle3;
        private Label helloElementImg3;
        private GradientPanel gradientPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label7;
        private Label label8;
        private GradientPanel gradientPanel4;
        private TableLayoutPanel tableLayoutPanel40;
        private Label label79;
        private Label label80;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem viewToolStripMenuItem1;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private TableLayoutPanel verticalTableMenu;
        private GradientPanel bottomBlank;
        private GradientPanel topBlank;
        private GradientPanel homeGradientPanel;
        private GradientPanel searchGradientPanel;
        private GradientPanel heartGradientPanel;
        private GradientPanel libraryGradientPanel;
        private GradientPanel recentGradientPanel;
        private TransparentTextbox transparentTextbox1;
        private TSkin.ST.STTextBox searchBox;
        private GradientPanel searchBoxContainer;
        private Panel currentPanel;
        private Label currentLabel;
        private GradientPanel currentProperties;
        private TableLayoutPanel currentPropertiesTable;
        private FlowLayoutPanel currentBookPanel;
        private Label currentBookTitle;
        private Label currentBookAuthor;
        private Label currentBookRate;
        private Panel currentPagePanel;
        private Label currentPage;
        private Label totalPage;
        private FlowLayoutPanel currentPublisherPanel;
        private Label currentPublisher;
        private Label yearOfPublication;
        private GradientPanel optionPanel;
        private FlowLayoutPanel optionsFlowPanel;
        private Label heartOption;
        private Label textToSpeech;
        private Label brightness;
        private FlowLayoutPanel helloFlow0;
        private Label helloAuthor0;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label helloAuthor1;
        private FlowLayoutPanel helloFlow2;
        private Label helloAuthor2;
        private FlowLayoutPanel helloFlow3;
        private Label helloAuthor3;
    }
}