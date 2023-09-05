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

        private User reader;
        private List<Book> books = new List<Book>();
        private List<UserRating> ratings = new List<UserRating>();

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            //SingleTextView singleTextView1 = new TSkin.ST.SingleTextView();
            containerMainTableLayout = new TableLayoutPanel();
            verticalMenuBar = new FlowLayoutPanel();
            userLabel = new Label();
            verticalTableMenu = new TableLayoutPanel();
            bottomBlank = new GradientPanel();
            topBlank = new GradientPanel();
            user = new Winforms.RJButton();
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
            publisherLabel = new Label();
            contentYear = new Label();
            contentImg = new Label();
            contentTitle = new Label();
            authorLabel = new Label();
            aboutAuthor = new Label();
            authorDesLabel = new Label();
            categoryLabel = new Label();
            category0 = new GradientPanel();
            categoryTable0 = new TableLayoutPanel();
            categoryImg0 = new Label();
            categoryFlowPanel0 = new FlowLayoutPanel();
            categoryTitle0 = new Label();
            categoryAuthor0 = new Label();
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
            helloFlow1 = new FlowLayoutPanel();
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
            recommentElement0 = new GradientPanel();
            recommentTable0 = new TableLayoutPanel();
            recommentImg0 = new Label();
            recommentFlowPanel0 = new FlowLayoutPanel();
            recommentTitle0 = new Label();
            recommentAuthor0 = new Label();
            recommentElement1 = new GradientPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            recommentImg1 = new Label();
            recommentFlowPanel1 = new FlowLayoutPanel();
            recommentTitle1 = new Label();
            recommentAuthor1 = new Label();
            recommentElement2 = new GradientPanel();
            recommentTable2 = new TableLayoutPanel();
            recommentImg2 = new Label();
            recommentFlowLabel2 = new FlowLayoutPanel();
            recommentTitle2 = new Label();
            recommentAuthor2 = new Label();
            recommentElement3 = new GradientPanel();
            recommentTable3 = new TableLayoutPanel();
            recommentImg3 = new Label();
            recommentFlowLabel3 = new FlowLayoutPanel();
            recommentTitle3 = new Label();
            recommentAuthor3 = new Label();
            recentPanel = new FlowLayoutPanel();
            searchFlowPanel = new FlowLayoutPanel();
            searchPanel = new FlowLayoutPanel();
            searchLayoutTable = new TableLayoutPanel();
            searchBoxContainer = new GradientPanel();
            searchBox = new TSkin.ST.STTextBox();
            searchImg = new Label();
            bestMatchPanel = new FlowLayoutPanel();
            bestMatchLabel = new Label();
            topSearchPanel = new GradientPanel();
            topSeachTable = new TableLayoutPanel();
            topSearchImg = new Label();
            topSearchFlowPanel = new FlowLayoutPanel();
            topSearchTitle = new Label();
            topSearchAuthor = new Label();
            otherResult0 = new GradientPanel();
            otherTable0 = new TableLayoutPanel();
            otherTitle0 = new Label();
            otherImg0 = new Label();
            otherResult1 = new GradientPanel();
            otherTable1 = new TableLayoutPanel();
            otherTitle1 = new Label();
            otherImg1 = new Label();
            otherResult2 = new GradientPanel();
            otherTable2 = new TableLayoutPanel();
            otherTitle2 = new Label();
            otherImg2 = new Label();
            otherResult3 = new GradientPanel();
            otherTable3 = new TableLayoutPanel();
            otherTitle3 = new Label();
            otherImg3 = new Label();
            otherResult4 = new GradientPanel();
            otherTable4 = new TableLayoutPanel();
            otherTitle4 = new Label();
            otherImg4 = new Label();
            otherResult5 = new GradientPanel();
            otherTable5 = new TableLayoutPanel();
            otherTitle5 = new Label();
            otherImg5 = new Label();
            otherResult6 = new GradientPanel();
            otherTable6 = new TableLayoutPanel();
            otherTitle6 = new Label();
            otherImg6 = new Label();
            otherResult7 = new GradientPanel();
            otherTable7 = new TableLayoutPanel();
            otherTitle7 = new Label();
            otherImg7 = new Label();
            otherResult8 = new GradientPanel();
            otherTable8 = new TableLayoutPanel();
            otherTitle8 = new Label();
            otherImg8 = new Label();
            otherResult9 = new GradientPanel();
            otherTable9 = new TableLayoutPanel();
            otherTitle9 = new Label();
            otherImg9 = new Label();
            flowLayoutPanel61 = new FlowLayoutPanel();
            favoritePanel = new FlowLayoutPanel();
            favFlowPanel = new FlowLayoutPanel();
            favoriteLabel = new Label();
            favTableHead = new TableLayoutPanel();
            favBookLabel = new Label();
            favRankLabel = new Label();
            scoreLabel = new Label();
            favPublisherLabel = new Label();
            categoriesPanel = new FlowLayoutPanel();
            mainCategoryPanel = new FlowLayoutPanel();
            categoryMainLabel = new Label();
            authormainFlowPanel = new FlowLayoutPanel();
            authorMainLabel = new Label();
            otherCategoriesPanel = new FlowLayoutPanel();
            otherCategoryLabel = new Label();
            historyPanel = new FlowLayoutPanel();
            historyFlowPanel = new FlowLayoutPanel();
            historyLabel = new Label();
            bestBookPanel = new FlowLayoutPanel();
            bestBookFlowPanel = new FlowLayoutPanel();
            bestBookLabel = new Label();
            bestBookElement0 = new GradientPanel();
            bestBookTable0 = new TableLayoutPanel();
            bestBookImg0 = new Label();
            bestBookLabel0 = new FlowLayoutPanel();
            bestBookTitle0 = new Label();
            bestBookAuthor0 = new Label();
            bestBookElement1 = new GradientPanel();
            bestBookTable1 = new TableLayoutPanel();
            bestBookImg1 = new Label();
            bestBookLabel1 = new FlowLayoutPanel();
            bestBookTitle1 = new Label();
            bestBookAuthor1 = new Label();
            bestBookElement2 = new GradientPanel();
            bestBookTable2 = new TableLayoutPanel();
            bestBookImg2 = new Label();
            bestBookLabel2 = new FlowLayoutPanel();
            bestBookTitle2 = new Label();
            bestBookAuthor2 = new Label();
            bestBookElement3 = new GradientPanel();
            bestBookTable3 = new TableLayoutPanel();
            bestBookImg3 = new Label();
            bestBookLabel3 = new FlowLayoutPanel();
            bestBookTitle3 = new Label();
            bestBookAuthor3 = new Label();
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
            forward = new Label();
            bookmark = new Label();
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
            close = new ToolStripButton();
            maximize = new ToolStripButton();
            minimize = new ToolStripButton();
            containerMainTableLayout.SuspendLayout();
            verticalMenuBar.SuspendLayout();
            verticalTableMenu.SuspendLayout();
            topBlank.SuspendLayout();
            homeGradientPanel.SuspendLayout();
            searchGradientPanel.SuspendLayout();
            heartGradientPanel.SuspendLayout();
            libraryGradientPanel.SuspendLayout();
            recentGradientPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            contentContainer.SuspendLayout();
            category0.SuspendLayout();
            categoryTable0.SuspendLayout();
            categoryFlowPanel0.SuspendLayout();
            mainFlowPanel.SuspendLayout();
            homeFlowPanel.SuspendLayout();
            helloPanel.SuspendLayout();
            helloElement0.SuspendLayout();
            helloElementTable0.SuspendLayout();
            helloFlow0.SuspendLayout();
            helloElement1.SuspendLayout();
            helloElementTable1.SuspendLayout();
            helloFlow1.SuspendLayout();
            helloElement2.SuspendLayout();
            helloElementTable2.SuspendLayout();
            helloFlow2.SuspendLayout();
            helloElement3.SuspendLayout();
            helloElementTable3.SuspendLayout();
            helloFlow3.SuspendLayout();
            recommentPanel.SuspendLayout();
            recommentElement0.SuspendLayout();
            recommentTable0.SuspendLayout();
            recommentFlowPanel0.SuspendLayout();
            recommentElement1.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            recommentFlowPanel1.SuspendLayout();
            recommentElement2.SuspendLayout();
            recommentTable2.SuspendLayout();
            recommentFlowLabel2.SuspendLayout();
            recommentElement3.SuspendLayout();
            recommentTable3.SuspendLayout();
            recommentFlowLabel3.SuspendLayout();
            searchFlowPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            searchLayoutTable.SuspendLayout();
            searchBoxContainer.SuspendLayout();
            bestMatchPanel.SuspendLayout();
            topSearchPanel.SuspendLayout();
            topSeachTable.SuspendLayout();
            topSearchFlowPanel.SuspendLayout();
            otherResult0.SuspendLayout();
            otherTable0.SuspendLayout();
            otherResult1.SuspendLayout();
            otherTable1.SuspendLayout();
            otherResult2.SuspendLayout();
            otherTable2.SuspendLayout();
            otherResult3.SuspendLayout();
            otherTable3.SuspendLayout();
            otherResult4.SuspendLayout();
            otherTable4.SuspendLayout();
            otherResult5.SuspendLayout();
            otherTable5.SuspendLayout();
            otherResult6.SuspendLayout();
            otherTable6.SuspendLayout();
            otherResult7.SuspendLayout();
            otherTable7.SuspendLayout();
            otherResult8.SuspendLayout();
            otherTable8.SuspendLayout();
            otherResult9.SuspendLayout();
            otherTable9.SuspendLayout();
            favoritePanel.SuspendLayout();
            favFlowPanel.SuspendLayout();
            favTableHead.SuspendLayout();
            categoriesPanel.SuspendLayout();
            mainCategoryPanel.SuspendLayout();
            authormainFlowPanel.SuspendLayout();
            otherCategoriesPanel.SuspendLayout();
            historyPanel.SuspendLayout();
            historyFlowPanel.SuspendLayout();
            bestBookPanel.SuspendLayout();
            bestBookFlowPanel.SuspendLayout();
            bestBookElement0.SuspendLayout();
            bestBookTable0.SuspendLayout();
            bestBookLabel0.SuspendLayout();
            bestBookElement1.SuspendLayout();
            bestBookTable1.SuspendLayout();
            bestBookLabel1.SuspendLayout();
            bestBookElement2.SuspendLayout();
            bestBookTable2.SuspendLayout();
            bestBookLabel2.SuspendLayout();
            bestBookElement3.SuspendLayout();
            bestBookTable3.SuspendLayout();
            bestBookLabel3.SuspendLayout();
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
            // containerMainTableLayout
            // 
            containerMainTableLayout.BackColor = Color.Transparent;
            containerMainTableLayout.ColumnCount = 3;
            containerMainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            containerMainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            containerMainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            containerMainTableLayout.Controls.Add(verticalMenuBar, 2, 0);
            containerMainTableLayout.Controls.Add(contentPanel, 0, 0);
            containerMainTableLayout.Controls.Add(mainFlowPanel, 1, 0);
            containerMainTableLayout.Controls.Add(currentPanel, 2, 1);
            containerMainTableLayout.Controls.Add(currentProperties, 1, 1);
            containerMainTableLayout.Controls.Add(optionPanel, 0, 1);
            containerMainTableLayout.Dock = DockStyle.Fill;
            containerMainTableLayout.Location = new Point(0, 0);
            containerMainTableLayout.Margin = new Padding(0, 500, 0, 0);
            containerMainTableLayout.Name = "containerMainTableLayout";
            containerMainTableLayout.RowCount = 2;
            containerMainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            containerMainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            containerMainTableLayout.Size = new Size(1280, 826);
            containerMainTableLayout.TabIndex = 0;
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
            verticalMenuBar.Size = new Size(100, 726);
            verticalMenuBar.TabIndex = 1;
            verticalMenuBar.WrapContents = false;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            // 
            // userLabel
            // 
            userLabel.BackColor = Color.DimGray;
            userLabel.Image = (Image)resources.GetObject("userLabel.Image");
            userLabel.Location = new Point(0, 0);
            userLabel.Margin = new Padding(0);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(100, 27);
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
            verticalTableMenu.Dock = DockStyle.Fill;
            verticalTableMenu.Location = new Point(0, 47);
            verticalTableMenu.Margin = new Padding(0, 20, 0, 0);
            verticalTableMenu.Name = "verticalTableMenu";
            verticalTableMenu.RowCount = 7;
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            verticalTableMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            verticalTableMenu.Size = new Size(100, 635);
            verticalTableMenu.TabIndex = 1;
            // 
            // bottomBlank
            // 
            bottomBlank.Dock = DockStyle.Fill;
            bottomBlank.GradientAngle = 90F;
            bottomBlank.GradientPrimaryColor = Color.White;
            bottomBlank.GradientSecondaryColor = Color.Black;
            bottomBlank.Location = new Point(0, 505);
            bottomBlank.Margin = new Padding(0);
            bottomBlank.Name = "bottomBlank";
            bottomBlank.Size = new Size(100, 200);
            bottomBlank.TabIndex = 6;
            // 
            // topBlank
            // 
            topBlank.Controls.Add(user);
            topBlank.Dock = DockStyle.Fill;
            topBlank.GradientAngle = 90F;
            topBlank.GradientPrimaryColor = Color.Black;
            topBlank.GradientSecondaryColor = Color.AliceBlue;
            topBlank.Location = new Point(0, 0);
            topBlank.Margin = new Padding(0);
            topBlank.Name = "topBlank";
            topBlank.Size = new Size(100, 150);
            topBlank.TabIndex = 7;
            // 
            // user
            // 
            user.BackColor = Color.DimGray;
            user.BackgroundColor = Color.DimGray;
            user.BackgroundImage = (Image)resources.GetObject("user.BackgroundImage");
            user.BackgroundImageLayout = ImageLayout.Center;
            user.BorderColor = Color.PaleVioletRed;
            user.BorderRadius = 50;
            user.BorderSize = 0;
            user.Dock = DockStyle.Top;
            user.FlatAppearance.BorderSize = 0;
            user.FlatStyle = FlatStyle.Flat;
            user.ForeColor = Color.White;
            user.Location = new Point(0, 0);
            user.Name = "user";
            user.Size = new Size(100, 100);
            user.TabIndex = 0;
            user.TextColor = Color.White;
            user.UseVisualStyleBackColor = false;
            user.Click += user_Click;
            // 
            // homeGradientPanel
            // 
            homeGradientPanel.Controls.Add(homeLabel);
            homeGradientPanel.Dock = DockStyle.Fill;
            homeGradientPanel.GradientAngle = 90F;
            homeGradientPanel.GradientPrimaryColor = Color.White;
            homeGradientPanel.GradientSecondaryColor = Color.Empty;
            homeGradientPanel.Location = new Point(0, 150);
            homeGradientPanel.Margin = new Padding(0);
            homeGradientPanel.Name = "homeGradientPanel";
            homeGradientPanel.Size = new Size(100, 71);
            homeGradientPanel.TabIndex = 8;
            // 
            // homeLabel
            // 
            homeLabel.Dock = DockStyle.Fill;
            homeLabel.Image = (Image)resources.GetObject("homeLabel.Image");
            homeLabel.Location = new Point(0, 0);
            homeLabel.Margin = new Padding(0);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(100, 71);
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
            searchGradientPanel.Location = new Point(0, 221);
            searchGradientPanel.Margin = new Padding(0);
            searchGradientPanel.Name = "searchGradientPanel";
            searchGradientPanel.Size = new Size(100, 71);
            searchGradientPanel.TabIndex = 9;
            // 
            // searchLabel
            // 
            searchLabel.Dock = DockStyle.Fill;
            searchLabel.Image = (Image)resources.GetObject("searchLabel.Image");
            searchLabel.Location = new Point(0, 0);
            searchLabel.Margin = new Padding(0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(100, 71);
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
            heartGradientPanel.Location = new Point(0, 292);
            heartGradientPanel.Margin = new Padding(0);
            heartGradientPanel.Name = "heartGradientPanel";
            heartGradientPanel.Size = new Size(100, 71);
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
            heartLabel.Size = new Size(100, 71);
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
            libraryGradientPanel.Location = new Point(0, 363);
            libraryGradientPanel.Margin = new Padding(0);
            libraryGradientPanel.Name = "libraryGradientPanel";
            libraryGradientPanel.Size = new Size(100, 71);
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
            librariesLabel.Size = new Size(100, 71);
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
            recentGradientPanel.Location = new Point(0, 434);
            recentGradientPanel.Margin = new Padding(0);
            recentGradientPanel.Name = "recentGradientPanel";
            recentGradientPanel.Size = new Size(100, 71);
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
            recentLabel.Size = new Size(100, 71);
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
            contentPanel.Size = new Size(394, 720);
            contentPanel.TabIndex = 3;
            // 
            // contentContainer
            // 
            contentContainer.AutoScroll = true;
            contentContainer.Controls.Add(publisherLabel);
            contentContainer.Controls.Add(contentYear);
            contentContainer.Controls.Add(contentImg);
            contentContainer.Controls.Add(contentTitle);
            contentContainer.Controls.Add(authorLabel);
            contentContainer.Controls.Add(aboutAuthor);
            contentContainer.Controls.Add(authorDesLabel);
            contentContainer.Controls.Add(categoryLabel);
            contentContainer.Controls.Add(category0);
            contentContainer.Location = new Point(0, 0);
            contentContainer.Margin = new Padding(0);
            contentContainer.Name = "contentContainer";
            contentContainer.Size = new Size(429, 749);
            contentContainer.TabIndex = 0;
            contentContainer.Paint += contentContainer_Paint;
            // 
            // publisherLabel
            // 
            publisherLabel.AutoSize = true;
            publisherLabel.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(publisherLabel, true);
            publisherLabel.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            publisherLabel.ForeColor = SystemColors.ControlDark;
            publisherLabel.Location = new Point(0, 30);
            publisherLabel.Margin = new Padding(0, 30, 0, 0);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.Size = new Size(102, 28);
            publisherLabel.TabIndex = 0;
            publisherLabel.Text = "Publisher";
            // 
            // contentYear
            // 
            contentYear.AutoSize = true;
            contentYear.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(contentYear, true);
            contentYear.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            contentYear.ForeColor = SystemColors.ControlDark;
            contentYear.Location = new Point(3, 58);
            contentYear.Name = "contentYear";
            contentYear.Size = new Size(51, 28);
            contentYear.TabIndex = 8;
            contentYear.Text = "NaN";
            // 
            // contentImg
            // 
            contentImg.BackColor = Color.Transparent;
            contentImg.Image = (Image)resources.GetObject("contentImg.Image");
            contentImg.Location = new Point(30, 116);
            contentImg.Margin = new Padding(30);
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
            contentTitle.Location = new Point(3, 540);
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
            authorLabel.Location = new Point(3, 580);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(79, 28);
            authorLabel.TabIndex = 3;
            authorLabel.Text = "Author";
            // 
            // aboutAuthor
            // 
            aboutAuthor.AutoEllipsis = true;
            aboutAuthor.AutoSize = true;
            aboutAuthor.BackColor = Color.Transparent;
            contentContainer.SetFlowBreak(aboutAuthor, true);
            aboutAuthor.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            aboutAuthor.ForeColor = SystemColors.ControlLight;
            aboutAuthor.Location = new Point(3, 620);
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
            authorDesLabel.Location = new Point(3, 660);
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
            categoryLabel.Location = new Point(3, 700);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(285, 40);
            categoryLabel.TabIndex = 6;
            categoryLabel.Text = "Publisher's category";
            // 
            // category0
            // 
            category0.Controls.Add(categoryTable0);
            category0.GradientAngle = 60F;
            category0.GradientPrimaryColor = Color.Transparent;
            category0.GradientSecondaryColor = Color.White;
            category0.Location = new Point(0, 740);
            category0.Margin = new Padding(0, 0, 0, 50);
            category0.Name = "category0";
            category0.Size = new Size(349, 88);
            category0.TabIndex = 12;
            // 
            // categoryTable0
            // 
            categoryTable0.AutoSize = true;
            categoryTable0.ColumnCount = 2;
            categoryTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            categoryTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            categoryTable0.Controls.Add(categoryImg0, 0, 0);
            categoryTable0.Controls.Add(categoryFlowPanel0, 1, 0);
            categoryTable0.Dock = DockStyle.Fill;
            categoryTable0.Location = new Point(0, 0);
            categoryTable0.Name = "categoryTable0";
            categoryTable0.RowCount = 1;
            categoryTable0.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            categoryTable0.Size = new Size(349, 88);
            categoryTable0.TabIndex = 0;
            // 
            // categoryImg0
            // 
            categoryImg0.BackColor = Color.Transparent;
            categoryImg0.Image = (Image)resources.GetObject("categoryImg0.Image");
            categoryImg0.Location = new Point(3, 0);
            categoryImg0.Name = "categoryImg0";
            categoryImg0.Size = new Size(82, 88);
            categoryImg0.TabIndex = 0;
            // 
            // categoryFlowPanel0
            // 
            categoryFlowPanel0.Controls.Add(categoryTitle0);
            categoryFlowPanel0.Controls.Add(categoryAuthor0);
            categoryFlowPanel0.Dock = DockStyle.Fill;
            categoryFlowPanel0.Location = new Point(91, 3);
            categoryFlowPanel0.Name = "categoryFlowPanel0";
            categoryFlowPanel0.Size = new Size(255, 82);
            categoryFlowPanel0.TabIndex = 1;
            // 
            // categoryTitle0
            // 
            categoryTitle0.AutoSize = true;
            categoryTitle0.BackColor = Color.Transparent;
            categoryFlowPanel0.SetFlowBreak(categoryTitle0, true);
            categoryTitle0.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            categoryTitle0.ForeColor = SystemColors.ControlLight;
            categoryTitle0.Location = new Point(3, 0);
            categoryTitle0.Name = "categoryTitle0";
            categoryTitle0.Size = new Size(50, 28);
            categoryTitle0.TabIndex = 1;
            categoryTitle0.Text = "title";
            // 
            // categoryAuthor0
            // 
            categoryAuthor0.AutoSize = true;
            categoryAuthor0.BackColor = Color.Transparent;
            categoryFlowPanel0.SetFlowBreak(categoryAuthor0, true);
            categoryAuthor0.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            categoryAuthor0.ForeColor = SystemColors.ControlLight;
            categoryAuthor0.Location = new Point(3, 28);
            categoryAuthor0.Name = "categoryAuthor0";
            categoryAuthor0.Size = new Size(50, 19);
            categoryAuthor0.TabIndex = 5;
            categoryAuthor0.Text = "author";
            // 
            // mainFlowPanel
            // 
            mainFlowPanel.Controls.Add(homeFlowPanel);
            mainFlowPanel.Controls.Add(searchFlowPanel);
            mainFlowPanel.Controls.Add(favoritePanel);
            mainFlowPanel.Controls.Add(categoriesPanel);
            mainFlowPanel.Controls.Add(historyPanel);
            mainFlowPanel.Controls.Add(bestBookPanel);
            mainFlowPanel.Dock = DockStyle.Fill;
            mainFlowPanel.Location = new Point(400, 0);
            mainFlowPanel.Margin = new Padding(0);
            mainFlowPanel.Name = "mainFlowPanel";
            mainFlowPanel.Size = new Size(780, 726);
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
            homeFlowPanel.Location = new Point(0, 0);
            homeFlowPanel.Margin = new Padding(0);
            homeFlowPanel.Name = "homeFlowPanel";
            homeFlowPanel.Size = new Size(822, 765);
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
            helloPanel.Size = new Size(741, 258);
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
            helloElement0.Location = new Point(0, 82);
            helloElement0.Margin = new Padding(0);
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
            helloElementImg0.Click += helloElement0_Click;
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
            helloFlow0.Click += helloElement0_Click;
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
            helloElementTitle0.Click += helloElement0_Click;
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
            helloAuthor0.Click += helloElement0_Click;
            // 
            // helloElement1
            // 
            helloElement1.Controls.Add(helloElementTable1);
            helloElement1.GradientAngle = 60F;
            helloElement1.GradientPrimaryColor = Color.Transparent;
            helloElement1.GradientSecondaryColor = Color.White;
            helloElement1.Location = new Point(349, 82);
            helloElement1.Margin = new Padding(0);
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
            helloElementTable1.Controls.Add(helloFlow1, 1, 0);
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
            helloElementImg1.Click += helloElement1_Click;
            // 
            // helloFlow1
            // 
            helloFlow1.Controls.Add(helloElementTitle1);
            helloFlow1.Controls.Add(helloAuthor1);
            helloFlow1.Dock = DockStyle.Fill;
            helloFlow1.Location = new Point(91, 3);
            helloFlow1.Name = "helloFlow1";
            helloFlow1.Size = new Size(255, 82);
            helloFlow1.TabIndex = 1;
            helloFlow1.Click += helloElement1_Click;
            // 
            // helloElementTitle1
            // 
            helloElementTitle1.AutoSize = true;
            helloElementTitle1.BackColor = Color.Transparent;
            helloFlow1.SetFlowBreak(helloElementTitle1, true);
            helloElementTitle1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            helloElementTitle1.ForeColor = SystemColors.ControlLight;
            helloElementTitle1.Location = new Point(3, 0);
            helloElementTitle1.Name = "helloElementTitle1";
            helloElementTitle1.Size = new Size(50, 28);
            helloElementTitle1.TabIndex = 1;
            helloElementTitle1.Text = "title";
            helloElementTitle1.Click += helloElement1_Click;
            // 
            // helloAuthor1
            // 
            helloAuthor1.AutoSize = true;
            helloAuthor1.BackColor = Color.Transparent;
            helloFlow1.SetFlowBreak(helloAuthor1, true);
            helloAuthor1.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            helloAuthor1.ForeColor = SystemColors.ControlLight;
            helloAuthor1.Location = new Point(3, 28);
            helloAuthor1.Name = "helloAuthor1";
            helloAuthor1.Size = new Size(50, 19);
            helloAuthor1.TabIndex = 3;
            helloAuthor1.Text = "author";
            helloAuthor1.Click += helloElement1_Click;
            // 
            // helloElement2
            // 
            helloElement2.Controls.Add(helloElementTable2);
            helloElement2.GradientAngle = 60F;
            helloElement2.GradientPrimaryColor = Color.Transparent;
            helloElement2.GradientSecondaryColor = Color.White;
            helloElement2.Location = new Point(0, 170);
            helloElement2.Margin = new Padding(0);
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
            helloElementImg2.Click += helloElement2_Click;
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
            helloFlow2.Click += helloElement2_Click;
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
            helloElementTitle2.Click += helloElement2_Click;
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
            helloAuthor2.Click += helloElement2_Click;
            // 
            // helloElement3
            // 
            helloElement3.Controls.Add(helloElementTable3);
            helloElement3.GradientAngle = 60F;
            helloElement3.GradientPrimaryColor = Color.Transparent;
            helloElement3.GradientSecondaryColor = Color.White;
            helloElement3.Location = new Point(349, 170);
            helloElement3.Margin = new Padding(0);
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
            helloElementImg3.Click += helloElement3_Click;
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
            helloFlow3.Click += helloElement3_Click;
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
            helloElementTitle3.Click += helloElement3_Click;
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
            helloAuthor3.Click += helloElement3_Click;
            // 
            // recommentPanel
            // 
            recommentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recommentPanel.AutoSize = true;
            recommentPanel.Controls.Add(recommentLabel);
            recommentPanel.Controls.Add(recommentElement0);
            recommentPanel.Controls.Add(recommentElement1);
            recommentPanel.Controls.Add(recommentElement2);
            recommentPanel.Controls.Add(recommentElement3);
            homeFlowPanel.SetFlowBreak(recommentPanel, true);
            recommentPanel.Location = new Point(0, 285);
            recommentPanel.Margin = new Padding(0);
            recommentPanel.Name = "recommentPanel";
            recommentPanel.Size = new Size(741, 258);
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
            // recommentElement0
            // 
            recommentElement0.Controls.Add(recommentTable0);
            recommentElement0.GradientAngle = 60F;
            recommentElement0.GradientPrimaryColor = Color.Transparent;
            recommentElement0.GradientSecondaryColor = Color.White;
            recommentElement0.Location = new Point(0, 82);
            recommentElement0.Margin = new Padding(0);
            recommentElement0.Name = "recommentElement0";
            recommentElement0.Size = new Size(349, 88);
            recommentElement0.TabIndex = 8;
            // 
            // recommentTable0
            // 
            recommentTable0.AutoSize = true;
            recommentTable0.ColumnCount = 2;
            recommentTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            recommentTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            recommentTable0.Controls.Add(recommentImg0, 0, 0);
            recommentTable0.Controls.Add(recommentFlowPanel0, 1, 0);
            recommentTable0.Dock = DockStyle.Fill;
            recommentTable0.Location = new Point(0, 0);
            recommentTable0.Name = "recommentTable0";
            recommentTable0.RowCount = 1;
            recommentTable0.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            recommentTable0.Size = new Size(349, 88);
            recommentTable0.TabIndex = 0;
            // 
            // recommentImg0
            // 
            recommentImg0.BackColor = Color.Transparent;
            recommentImg0.Image = (Image)resources.GetObject("recommentImg0.Image");
            recommentImg0.Location = new Point(3, 0);
            recommentImg0.Name = "recommentImg0";
            recommentImg0.Size = new Size(82, 88);
            recommentImg0.TabIndex = 0;
            recommentImg0.Click += recommentElement0_Click;
            // 
            // recommentFlowPanel0
            // 
            recommentFlowPanel0.Controls.Add(recommentTitle0);
            recommentFlowPanel0.Controls.Add(recommentAuthor0);
            recommentFlowPanel0.Dock = DockStyle.Fill;
            recommentFlowPanel0.Location = new Point(91, 3);
            recommentFlowPanel0.Name = "recommentFlowPanel0";
            recommentFlowPanel0.Size = new Size(255, 82);
            recommentFlowPanel0.TabIndex = 1;
            recommentFlowPanel0.Click += recommentElement0_Click;
            // 
            // recommentTitle0
            // 
            recommentTitle0.AutoSize = true;
            recommentTitle0.BackColor = Color.Transparent;
            recommentFlowPanel0.SetFlowBreak(recommentTitle0, true);
            recommentTitle0.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            recommentTitle0.ForeColor = SystemColors.ControlLight;
            recommentTitle0.Location = new Point(3, 0);
            recommentTitle0.Name = "recommentTitle0";
            recommentTitle0.Size = new Size(50, 28);
            recommentTitle0.TabIndex = 1;
            recommentTitle0.Text = "title";
            recommentTitle0.Click += recommentElement0_Click;
            // 
            // recommentAuthor0
            // 
            recommentAuthor0.AutoSize = true;
            recommentAuthor0.BackColor = Color.Transparent;
            recommentFlowPanel0.SetFlowBreak(recommentAuthor0, true);
            recommentAuthor0.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            recommentAuthor0.ForeColor = SystemColors.ControlLight;
            recommentAuthor0.Location = new Point(3, 28);
            recommentAuthor0.Name = "recommentAuthor0";
            recommentAuthor0.Size = new Size(50, 19);
            recommentAuthor0.TabIndex = 5;
            recommentAuthor0.Text = "author";
            recommentAuthor0.Click += recommentElement0_Click;
            // 
            // recommentElement1
            // 
            recommentElement1.Controls.Add(tableLayoutPanel8);
            recommentElement1.GradientAngle = 60F;
            recommentElement1.GradientPrimaryColor = Color.Transparent;
            recommentElement1.GradientSecondaryColor = Color.White;
            recommentElement1.Location = new Point(349, 82);
            recommentElement1.Margin = new Padding(0);
            recommentElement1.Name = "recommentElement1";
            recommentElement1.Size = new Size(349, 88);
            recommentElement1.TabIndex = 9;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.AutoSize = true;
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(recommentImg1, 0, 0);
            tableLayoutPanel8.Controls.Add(recommentFlowPanel1, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel8.Size = new Size(349, 88);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // recommentImg1
            // 
            recommentImg1.BackColor = Color.Transparent;
            recommentImg1.Image = (Image)resources.GetObject("recommentImg1.Image");
            recommentImg1.Location = new Point(3, 0);
            recommentImg1.Name = "recommentImg1";
            recommentImg1.Size = new Size(82, 88);
            recommentImg1.TabIndex = 0;
            recommentImg1.Click += recommentElement1_Click;
            // 
            // recommentFlowPanel1
            // 
            recommentFlowPanel1.Controls.Add(recommentTitle1);
            recommentFlowPanel1.Controls.Add(recommentAuthor1);
            recommentFlowPanel1.Dock = DockStyle.Fill;
            recommentFlowPanel1.Location = new Point(91, 3);
            recommentFlowPanel1.Name = "recommentFlowPanel1";
            recommentFlowPanel1.Size = new Size(255, 82);
            recommentFlowPanel1.TabIndex = 1;
            recommentFlowPanel1.Click += recommentElement1_Click;
            // 
            // recommentTitle1
            // 
            recommentTitle1.AutoSize = true;
            recommentTitle1.BackColor = Color.Transparent;
            recommentFlowPanel1.SetFlowBreak(recommentTitle1, true);
            recommentTitle1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            recommentTitle1.ForeColor = SystemColors.ControlLight;
            recommentTitle1.Location = new Point(3, 0);
            recommentTitle1.Name = "recommentTitle1";
            recommentTitle1.Size = new Size(50, 28);
            recommentTitle1.TabIndex = 1;
            recommentTitle1.Text = "title";
            recommentTitle1.Click += recommentElement1_Click;
            // 
            // recommentAuthor1
            // 
            recommentAuthor1.AutoSize = true;
            recommentAuthor1.BackColor = Color.Transparent;
            recommentFlowPanel1.SetFlowBreak(recommentAuthor1, true);
            recommentAuthor1.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            recommentAuthor1.ForeColor = SystemColors.ControlLight;
            recommentAuthor1.Location = new Point(3, 28);
            recommentAuthor1.Name = "recommentAuthor1";
            recommentAuthor1.Size = new Size(50, 19);
            recommentAuthor1.TabIndex = 5;
            recommentAuthor1.Text = "author";
            recommentAuthor1.Click += recommentElement1_Click;
            // 
            // recommentElement2
            // 
            recommentElement2.Controls.Add(recommentTable2);
            recommentElement2.GradientAngle = 60F;
            recommentElement2.GradientPrimaryColor = Color.Transparent;
            recommentElement2.GradientSecondaryColor = Color.White;
            recommentElement2.Location = new Point(0, 170);
            recommentElement2.Margin = new Padding(0);
            recommentElement2.Name = "recommentElement2";
            recommentElement2.Size = new Size(349, 88);
            recommentElement2.TabIndex = 10;
            // 
            // recommentTable2
            // 
            recommentTable2.AutoSize = true;
            recommentTable2.ColumnCount = 2;
            recommentTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            recommentTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            recommentTable2.Controls.Add(recommentImg2, 0, 0);
            recommentTable2.Controls.Add(recommentFlowLabel2, 1, 0);
            recommentTable2.Dock = DockStyle.Fill;
            recommentTable2.Location = new Point(0, 0);
            recommentTable2.Name = "recommentTable2";
            recommentTable2.RowCount = 1;
            recommentTable2.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            recommentTable2.Size = new Size(349, 88);
            recommentTable2.TabIndex = 0;
            // 
            // recommentImg2
            // 
            recommentImg2.BackColor = Color.Transparent;
            recommentImg2.Image = (Image)resources.GetObject("recommentImg2.Image");
            recommentImg2.Location = new Point(3, 0);
            recommentImg2.Name = "recommentImg2";
            recommentImg2.Size = new Size(82, 88);
            recommentImg2.TabIndex = 0;
            recommentImg2.Click += recommentElement2_Click;
            // 
            // recommentFlowLabel2
            // 
            recommentFlowLabel2.Controls.Add(recommentTitle2);
            recommentFlowLabel2.Controls.Add(recommentAuthor2);
            recommentFlowLabel2.Dock = DockStyle.Fill;
            recommentFlowLabel2.Location = new Point(91, 3);
            recommentFlowLabel2.Name = "recommentFlowLabel2";
            recommentFlowLabel2.Size = new Size(255, 82);
            recommentFlowLabel2.TabIndex = 1;
            recommentFlowLabel2.Click += recommentElement2_Click;
            // 
            // recommentTitle2
            // 
            recommentTitle2.AutoSize = true;
            recommentTitle2.BackColor = Color.Transparent;
            recommentFlowLabel2.SetFlowBreak(recommentTitle2, true);
            recommentTitle2.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            recommentTitle2.ForeColor = SystemColors.ControlLight;
            recommentTitle2.Location = new Point(3, 0);
            recommentTitle2.Name = "recommentTitle2";
            recommentTitle2.Size = new Size(50, 28);
            recommentTitle2.TabIndex = 1;
            recommentTitle2.Text = "title";
            // 
            // recommentAuthor2
            // 
            recommentAuthor2.AutoSize = true;
            recommentAuthor2.BackColor = Color.Transparent;
            recommentFlowLabel2.SetFlowBreak(recommentAuthor2, true);
            recommentAuthor2.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            recommentAuthor2.ForeColor = SystemColors.ControlLight;
            recommentAuthor2.Location = new Point(3, 28);
            recommentAuthor2.Name = "recommentAuthor2";
            recommentAuthor2.Size = new Size(50, 19);
            recommentAuthor2.TabIndex = 5;
            recommentAuthor2.Text = "author";
            recommentAuthor2.Click += recommentElement2_Click;
            // 
            // recommentElement3
            // 
            recommentElement3.Controls.Add(recommentTable3);
            recommentElement3.GradientAngle = 60F;
            recommentElement3.GradientPrimaryColor = Color.Transparent;
            recommentElement3.GradientSecondaryColor = Color.White;
            recommentElement3.Location = new Point(349, 170);
            recommentElement3.Margin = new Padding(0);
            recommentElement3.Name = "recommentElement3";
            recommentElement3.Size = new Size(349, 88);
            recommentElement3.TabIndex = 11;
            // 
            // recommentTable3
            // 
            recommentTable3.AutoSize = true;
            recommentTable3.ColumnCount = 2;
            recommentTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            recommentTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            recommentTable3.Controls.Add(recommentImg3, 0, 0);
            recommentTable3.Controls.Add(recommentFlowLabel3, 1, 0);
            recommentTable3.Dock = DockStyle.Fill;
            recommentTable3.Location = new Point(0, 0);
            recommentTable3.Name = "recommentTable3";
            recommentTable3.RowCount = 1;
            recommentTable3.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            recommentTable3.Size = new Size(349, 88);
            recommentTable3.TabIndex = 0;
            // 
            // recommentImg3
            // 
            recommentImg3.BackColor = Color.Transparent;
            recommentImg3.Image = (Image)resources.GetObject("recommentImg3.Image");
            recommentImg3.Location = new Point(3, 0);
            recommentImg3.Name = "recommentImg3";
            recommentImg3.Size = new Size(82, 88);
            recommentImg3.TabIndex = 0;
            recommentImg3.Click += recommentElement3_Click;
            // 
            // recommentFlowLabel3
            // 
            recommentFlowLabel3.Controls.Add(recommentTitle3);
            recommentFlowLabel3.Controls.Add(recommentAuthor3);
            recommentFlowLabel3.Dock = DockStyle.Fill;
            recommentFlowLabel3.Location = new Point(91, 3);
            recommentFlowLabel3.Name = "recommentFlowLabel3";
            recommentFlowLabel3.Size = new Size(255, 82);
            recommentFlowLabel3.TabIndex = 1;
            recommentFlowLabel3.Click += recommentElement3_Click;
            // 
            // recommentTitle3
            // 
            recommentTitle3.AutoSize = true;
            recommentTitle3.BackColor = Color.Transparent;
            recommentFlowLabel3.SetFlowBreak(recommentTitle3, true);
            recommentTitle3.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            recommentTitle3.ForeColor = SystemColors.ControlLight;
            recommentTitle3.Location = new Point(3, 0);
            recommentTitle3.Name = "recommentTitle3";
            recommentTitle3.Size = new Size(50, 28);
            recommentTitle3.TabIndex = 1;
            recommentTitle3.Text = "title";
            recommentTitle3.Click += recommentElement3_Click;
            // 
            // recommentAuthor3
            // 
            recommentAuthor3.AutoSize = true;
            recommentAuthor3.BackColor = Color.Transparent;
            recommentFlowLabel3.SetFlowBreak(recommentAuthor3, true);
            recommentAuthor3.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            recommentAuthor3.ForeColor = SystemColors.ControlLight;
            recommentAuthor3.Location = new Point(3, 28);
            recommentAuthor3.Name = "recommentAuthor3";
            recommentAuthor3.Size = new Size(50, 19);
            recommentAuthor3.TabIndex = 5;
            recommentAuthor3.Text = "author";
            recommentAuthor3.Click += recommentElement3_Click;
            // 
            // recentPanel
            // 
            recentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            recentPanel.AutoSize = true;
            homeFlowPanel.SetFlowBreak(recentPanel, true);
            recentPanel.Location = new Point(3, 546);
            recentPanel.Margin = new Padding(3, 3, 3, 30);
            recentPanel.Name = "recentPanel";
            recentPanel.Size = new Size(0, 0);
            recentPanel.TabIndex = 2;
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
            searchFlowPanel.Size = new Size(803, 765);
            searchFlowPanel.TabIndex = 1;
            searchFlowPanel.Visible = false;
            // 
            // searchPanel
            // 
            searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPanel.AutoSize = true;
            searchPanel.Controls.Add(searchLayoutTable);
            searchFlowPanel.SetFlowBreak(searchPanel, true);
            searchPanel.Location = new Point(50, 30);
            searchPanel.Margin = new Padding(50, 30, 3, 30);
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
            //searchBox.SetTextView = singleTextView1;
            searchBox.Size = new Size(560, 55);
            searchBox.TabIndex = 5;
            searchBox.Text = "What do you want to read?";
            searchBox.GotFocus += SearchBox_GotFocus;
            searchBox.KeyDown += searchBox_KeyDown;
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
            bestMatchPanel.Controls.Add(topSearchPanel);
            bestMatchPanel.Controls.Add(otherResult0);
            bestMatchPanel.Controls.Add(otherResult1);
            bestMatchPanel.Controls.Add(otherResult2);
            bestMatchPanel.Controls.Add(otherResult3);
            bestMatchPanel.Controls.Add(otherResult4);
            bestMatchPanel.Controls.Add(otherResult5);
            bestMatchPanel.Controls.Add(otherResult6);
            bestMatchPanel.Controls.Add(otherResult7);
            bestMatchPanel.Controls.Add(otherResult8);
            bestMatchPanel.Controls.Add(otherResult9);
            searchFlowPanel.SetFlowBreak(bestMatchPanel, true);
            bestMatchPanel.Location = new Point(3, 124);
            bestMatchPanel.Margin = new Padding(3, 3, 3, 30);
            bestMatchPanel.Name = "bestMatchPanel";
            bestMatchPanel.Size = new Size(741, 872);
            bestMatchPanel.TabIndex = 1;
            bestMatchPanel.Visible = false;
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
            // topSearchPanel
            // 
            topSearchPanel.Controls.Add(topSeachTable);
            bestMatchPanel.SetFlowBreak(topSearchPanel, true);
            topSearchPanel.GradientAngle = 60F;
            topSearchPanel.GradientPrimaryColor = Color.Transparent;
            topSearchPanel.GradientSecondaryColor = Color.White;
            topSearchPanel.Location = new Point(3, 85);
            topSearchPanel.Name = "topSearchPanel";
            topSearchPanel.Size = new Size(385, 124);
            topSearchPanel.TabIndex = 12;
            topSearchPanel.Visible = false;
            // 
            // topSeachTable
            // 
            topSeachTable.AutoSize = true;
            topSeachTable.ColumnCount = 2;
            topSeachTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            topSeachTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topSeachTable.Controls.Add(topSearchImg, 0, 0);
            topSeachTable.Controls.Add(topSearchFlowPanel, 1, 0);
            topSeachTable.Dock = DockStyle.Fill;
            topSeachTable.Location = new Point(0, 0);
            topSeachTable.Name = "topSeachTable";
            topSeachTable.RowCount = 1;
            topSeachTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
            topSeachTable.Size = new Size(385, 124);
            topSeachTable.TabIndex = 0;
            // 
            // topSearchImg
            // 
            topSearchImg.BackColor = Color.Transparent;
            topSearchImg.Dock = DockStyle.Fill;
            topSearchImg.Image = (Image)resources.GetObject("topSearchImg.Image");
            topSearchImg.Location = new Point(3, 0);
            topSearchImg.Name = "topSearchImg";
            topSearchImg.Size = new Size(118, 124);
            topSearchImg.TabIndex = 0;
            topSearchImg.Click += topSearchFlowPanel_Click;
            // 
            // topSearchFlowPanel
            // 
            topSearchFlowPanel.Controls.Add(topSearchTitle);
            topSearchFlowPanel.Controls.Add(topSearchAuthor);
            topSearchFlowPanel.Dock = DockStyle.Fill;
            topSearchFlowPanel.Location = new Point(127, 3);
            topSearchFlowPanel.Name = "topSearchFlowPanel";
            topSearchFlowPanel.Size = new Size(255, 118);
            topSearchFlowPanel.TabIndex = 1;
            topSearchFlowPanel.Click += topSearchFlowPanel_Click;
            // 
            // topSearchTitle
            // 
            topSearchTitle.AutoSize = true;
            topSearchTitle.BackColor = Color.Transparent;
            topSearchFlowPanel.SetFlowBreak(topSearchTitle, true);
            topSearchTitle.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            topSearchTitle.ForeColor = SystemColors.ControlLight;
            topSearchTitle.Location = new Point(3, 0);
            topSearchTitle.Name = "topSearchTitle";
            topSearchTitle.Size = new Size(50, 28);
            topSearchTitle.TabIndex = 1;
            topSearchTitle.Text = "title";
            topSearchTitle.Click += topSearchFlowPanel_Click;
            // 
            // topSearchAuthor
            // 
            topSearchAuthor.AutoSize = true;
            topSearchAuthor.BackColor = Color.Transparent;
            topSearchFlowPanel.SetFlowBreak(topSearchAuthor, true);
            topSearchAuthor.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            topSearchAuthor.ForeColor = SystemColors.ControlLight;
            topSearchAuthor.Location = new Point(3, 28);
            topSearchAuthor.Name = "topSearchAuthor";
            topSearchAuthor.Size = new Size(50, 19);
            topSearchAuthor.TabIndex = 5;
            topSearchAuthor.Text = "author";
            topSearchAuthor.Click += topSearchFlowPanel_Click;
            // 
            // otherResult0
            // 
            otherResult0.Controls.Add(otherTable0);
            bestMatchPanel.SetFlowBreak(otherResult0, true);
            otherResult0.GradientAngle = 0F;
            otherResult0.GradientPrimaryColor = Color.Transparent;
            otherResult0.GradientSecondaryColor = Color.Transparent;
            otherResult0.Location = new Point(3, 215);
            otherResult0.Name = "otherResult0";
            otherResult0.Size = new Size(595, 60);
            otherResult0.TabIndex = 13;
            otherResult0.Visible = false;
            // 
            // otherTable0
            // 
            otherTable0.AutoSize = true;
            otherTable0.ColumnCount = 2;
            otherTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable0.Controls.Add(otherTitle0, 1, 0);
            otherTable0.Controls.Add(otherImg0, 0, 0);
            otherTable0.Dock = DockStyle.Fill;
            otherTable0.Location = new Point(0, 0);
            otherTable0.Name = "otherTable0";
            otherTable0.RowCount = 1;
            otherTable0.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable0.Size = new Size(595, 60);
            otherTable0.TabIndex = 0;
            // 
            // otherTitle0
            // 
            otherTitle0.AutoSize = true;
            otherTitle0.BackColor = Color.Transparent;
            otherTitle0.Dock = DockStyle.Fill;
            otherTitle0.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle0.ForeColor = SystemColors.ControlLight;
            otherTitle0.Location = new Point(63, 0);
            otherTitle0.Name = "otherTitle0";
            otherTitle0.Size = new Size(529, 88);
            otherTitle0.TabIndex = 2;
            otherTitle0.Text = "title";
            toolTip1.SetToolTip(otherTitle0, "author");
            otherTitle0.Click += otherTitle0_Click;
            // 
            // otherImg0
            // 
            otherImg0.BackColor = Color.Transparent;
            otherImg0.Image = (Image)resources.GetObject("otherImg0.Image");
            otherImg0.Location = new Point(3, 0);
            otherImg0.Name = "otherImg0";
            otherImg0.Size = new Size(54, 50);
            otherImg0.TabIndex = 0;
            otherImg0.Click += otherTitle0_Click;
            // 
            // otherResult1
            // 
            otherResult1.Controls.Add(otherTable1);
            bestMatchPanel.SetFlowBreak(otherResult1, true);
            otherResult1.GradientAngle = 0F;
            otherResult1.GradientPrimaryColor = Color.Transparent;
            otherResult1.GradientSecondaryColor = Color.Transparent;
            otherResult1.Location = new Point(3, 281);
            otherResult1.Name = "otherResult1";
            otherResult1.Size = new Size(595, 60);
            otherResult1.TabIndex = 14;
            otherResult1.Visible = false;
            // 
            // otherTable1
            // 
            otherTable1.AutoSize = true;
            otherTable1.ColumnCount = 2;
            otherTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable1.Controls.Add(otherTitle1, 1, 0);
            otherTable1.Controls.Add(otherImg1, 0, 0);
            otherTable1.Dock = DockStyle.Fill;
            otherTable1.Location = new Point(0, 0);
            otherTable1.Name = "otherTable1";
            otherTable1.RowCount = 1;
            otherTable1.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable1.Size = new Size(595, 60);
            otherTable1.TabIndex = 0;
            // 
            // otherTitle1
            // 
            otherTitle1.AutoSize = true;
            otherTitle1.BackColor = Color.Transparent;
            otherTitle1.Dock = DockStyle.Fill;
            otherTitle1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle1.ForeColor = SystemColors.ControlLight;
            otherTitle1.Location = new Point(63, 0);
            otherTitle1.Name = "otherTitle1";
            otherTitle1.Size = new Size(529, 88);
            otherTitle1.TabIndex = 2;
            otherTitle1.Text = "title";
            toolTip1.SetToolTip(otherTitle1, "author");
            otherTitle1.Click += otherTitle1_Click;
            // 
            // otherImg1
            // 
            otherImg1.BackColor = Color.Transparent;
            otherImg1.Image = (Image)resources.GetObject("otherImg1.Image");
            otherImg1.Location = new Point(3, 0);
            otherImg1.Name = "otherImg1";
            otherImg1.Size = new Size(54, 50);
            otherImg1.TabIndex = 0;
            otherImg1.Click += otherTitle1_Click;
            // 
            // otherResult2
            // 
            otherResult2.Controls.Add(otherTable2);
            bestMatchPanel.SetFlowBreak(otherResult2, true);
            otherResult2.GradientAngle = 0F;
            otherResult2.GradientPrimaryColor = Color.Transparent;
            otherResult2.GradientSecondaryColor = Color.Transparent;
            otherResult2.Location = new Point(3, 347);
            otherResult2.Name = "otherResult2";
            otherResult2.Size = new Size(595, 60);
            otherResult2.TabIndex = 15;
            otherResult2.Visible = false;
            // 
            // otherTable2
            // 
            otherTable2.AutoSize = true;
            otherTable2.ColumnCount = 2;
            otherTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable2.Controls.Add(otherTitle2, 1, 0);
            otherTable2.Controls.Add(otherImg2, 0, 0);
            otherTable2.Dock = DockStyle.Fill;
            otherTable2.Location = new Point(0, 0);
            otherTable2.Name = "otherTable2";
            otherTable2.RowCount = 1;
            otherTable2.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable2.Size = new Size(595, 60);
            otherTable2.TabIndex = 0;
            // 
            // otherTitle2
            // 
            otherTitle2.AutoSize = true;
            otherTitle2.BackColor = Color.Transparent;
            otherTitle2.Dock = DockStyle.Fill;
            otherTitle2.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle2.ForeColor = SystemColors.ControlLight;
            otherTitle2.Location = new Point(63, 0);
            otherTitle2.Name = "otherTitle2";
            otherTitle2.Size = new Size(529, 88);
            otherTitle2.TabIndex = 2;
            otherTitle2.Text = "title";
            toolTip1.SetToolTip(otherTitle2, "author");
            otherTitle2.Click += otherTitle2_Click;
            // 
            // otherImg2
            // 
            otherImg2.BackColor = Color.Transparent;
            otherImg2.Location = new Point(3, 0);
            otherImg2.Name = "otherImg2";
            otherImg2.Size = new Size(54, 50);
            otherImg2.TabIndex = 0;
            otherImg2.Click += otherTitle2_Click;
            // 
            // otherResult3
            // 
            otherResult3.Controls.Add(otherTable3);
            bestMatchPanel.SetFlowBreak(otherResult3, true);
            otherResult3.GradientAngle = 0F;
            otherResult3.GradientPrimaryColor = Color.Transparent;
            otherResult3.GradientSecondaryColor = Color.Transparent;
            otherResult3.Location = new Point(3, 413);
            otherResult3.Name = "otherResult3";
            otherResult3.Size = new Size(595, 60);
            otherResult3.TabIndex = 16;
            otherResult3.Visible = false;
            // 
            // otherTable3
            // 
            otherTable3.AutoSize = true;
            otherTable3.ColumnCount = 2;
            otherTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable3.Controls.Add(otherTitle3, 1, 0);
            otherTable3.Controls.Add(otherImg3, 0, 0);
            otherTable3.Dock = DockStyle.Fill;
            otherTable3.Location = new Point(0, 0);
            otherTable3.Name = "otherTable3";
            otherTable3.RowCount = 1;
            otherTable3.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable3.Size = new Size(595, 60);
            otherTable3.TabIndex = 0;
            // 
            // otherTitle3
            // 
            otherTitle3.AutoSize = true;
            otherTitle3.BackColor = Color.Transparent;
            otherTitle3.Dock = DockStyle.Fill;
            otherTitle3.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle3.ForeColor = SystemColors.ControlLight;
            otherTitle3.Location = new Point(63, 0);
            otherTitle3.Name = "otherTitle3";
            otherTitle3.Size = new Size(529, 88);
            otherTitle3.TabIndex = 2;
            otherTitle3.Text = "title";
            toolTip1.SetToolTip(otherTitle3, "author");
            otherTitle3.Click += otherTitle3_Click;
            // 
            // otherImg3
            // 
            otherImg3.BackColor = Color.Transparent;
            otherImg3.Location = new Point(3, 0);
            otherImg3.Name = "otherImg3";
            otherImg3.Size = new Size(54, 50);
            otherImg3.TabIndex = 0;
            otherImg3.Click += otherTitle3_Click;
            // 
            // otherResult4
            // 
            otherResult4.Controls.Add(otherTable4);
            bestMatchPanel.SetFlowBreak(otherResult4, true);
            otherResult4.GradientAngle = 0F;
            otherResult4.GradientPrimaryColor = Color.Transparent;
            otherResult4.GradientSecondaryColor = Color.Transparent;
            otherResult4.Location = new Point(3, 479);
            otherResult4.Name = "otherResult4";
            otherResult4.Size = new Size(595, 60);
            otherResult4.TabIndex = 17;
            otherResult4.Visible = false;
            // 
            // otherTable4
            // 
            otherTable4.AutoSize = true;
            otherTable4.ColumnCount = 2;
            otherTable4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable4.Controls.Add(otherTitle4, 1, 0);
            otherTable4.Controls.Add(otherImg4, 0, 0);
            otherTable4.Dock = DockStyle.Fill;
            otherTable4.Location = new Point(0, 0);
            otherTable4.Name = "otherTable4";
            otherTable4.RowCount = 1;
            otherTable4.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable4.Size = new Size(595, 60);
            otherTable4.TabIndex = 0;
            // 
            // otherTitle4
            // 
            otherTitle4.AutoSize = true;
            otherTitle4.BackColor = Color.Transparent;
            otherTitle4.Dock = DockStyle.Fill;
            otherTitle4.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle4.ForeColor = SystemColors.ControlLight;
            otherTitle4.Location = new Point(63, 0);
            otherTitle4.Name = "otherTitle4";
            otherTitle4.Size = new Size(529, 88);
            otherTitle4.TabIndex = 2;
            otherTitle4.Text = "title";
            toolTip1.SetToolTip(otherTitle4, "author");
            otherTitle4.Click += otherTitle4_Click;
            // 
            // otherImg4
            // 
            otherImg4.BackColor = Color.Transparent;
            otherImg4.Location = new Point(3, 0);
            otherImg4.Name = "otherImg4";
            otherImg4.Size = new Size(54, 50);
            otherImg4.TabIndex = 0;
            otherImg4.Click += otherTitle4_Click;
            // 
            // otherResult5
            // 
            otherResult5.Controls.Add(otherTable5);
            bestMatchPanel.SetFlowBreak(otherResult5, true);
            otherResult5.GradientAngle = 0F;
            otherResult5.GradientPrimaryColor = Color.Transparent;
            otherResult5.GradientSecondaryColor = Color.Transparent;
            otherResult5.Location = new Point(3, 545);
            otherResult5.Name = "otherResult5";
            otherResult5.Size = new Size(595, 60);
            otherResult5.TabIndex = 18;
            otherResult5.Visible = false;
            // 
            // otherTable5
            // 
            otherTable5.AutoSize = true;
            otherTable5.ColumnCount = 2;
            otherTable5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable5.Controls.Add(otherTitle5, 1, 0);
            otherTable5.Controls.Add(otherImg5, 0, 0);
            otherTable5.Dock = DockStyle.Fill;
            otherTable5.Location = new Point(0, 0);
            otherTable5.Name = "otherTable5";
            otherTable5.RowCount = 1;
            otherTable5.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable5.Size = new Size(595, 60);
            otherTable5.TabIndex = 0;
            // 
            // otherTitle5
            // 
            otherTitle5.AutoSize = true;
            otherTitle5.BackColor = Color.Transparent;
            otherTitle5.Dock = DockStyle.Fill;
            otherTitle5.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle5.ForeColor = SystemColors.ControlLight;
            otherTitle5.Location = new Point(63, 0);
            otherTitle5.Name = "otherTitle5";
            otherTitle5.Size = new Size(529, 88);
            otherTitle5.TabIndex = 2;
            otherTitle5.Text = "title";
            toolTip1.SetToolTip(otherTitle5, "author");
            otherTitle5.Click += otherTitle5_Click;
            // 
            // otherImg5
            // 
            otherImg5.BackColor = Color.Transparent;
            otherImg5.Location = new Point(3, 0);
            otherImg5.Name = "otherImg5";
            otherImg5.Size = new Size(54, 50);
            otherImg5.TabIndex = 0;
            otherImg5.Click += otherTitle5_Click;
            // 
            // otherResult6
            // 
            otherResult6.Controls.Add(otherTable6);
            bestMatchPanel.SetFlowBreak(otherResult6, true);
            otherResult6.GradientAngle = 0F;
            otherResult6.GradientPrimaryColor = Color.Transparent;
            otherResult6.GradientSecondaryColor = Color.Transparent;
            otherResult6.Location = new Point(3, 611);
            otherResult6.Name = "otherResult6";
            otherResult6.Size = new Size(595, 60);
            otherResult6.TabIndex = 19;
            otherResult6.Visible = false;
            // 
            // otherTable6
            // 
            otherTable6.AutoSize = true;
            otherTable6.ColumnCount = 2;
            otherTable6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable6.Controls.Add(otherTitle6, 1, 0);
            otherTable6.Controls.Add(otherImg6, 0, 0);
            otherTable6.Dock = DockStyle.Fill;
            otherTable6.Location = new Point(0, 0);
            otherTable6.Name = "otherTable6";
            otherTable6.RowCount = 1;
            otherTable6.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable6.Size = new Size(595, 60);
            otherTable6.TabIndex = 0;
            // 
            // otherTitle6
            // 
            otherTitle6.AutoSize = true;
            otherTitle6.BackColor = Color.Transparent;
            otherTitle6.Dock = DockStyle.Fill;
            otherTitle6.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle6.ForeColor = SystemColors.ControlLight;
            otherTitle6.Location = new Point(63, 0);
            otherTitle6.Name = "otherTitle6";
            otherTitle6.Size = new Size(529, 88);
            otherTitle6.TabIndex = 2;
            otherTitle6.Text = "title";
            toolTip1.SetToolTip(otherTitle6, "author");
            otherTitle6.Click += otherTitle6_Click;
            // 
            // otherImg6
            // 
            otherImg6.BackColor = Color.Transparent;
            otherImg6.Location = new Point(3, 0);
            otherImg6.Name = "otherImg6";
            otherImg6.Size = new Size(54, 50);
            otherImg6.TabIndex = 0;
            otherImg6.Click += otherTitle6_Click;
            // 
            // otherResult7
            // 
            otherResult7.Controls.Add(otherTable7);
            bestMatchPanel.SetFlowBreak(otherResult7, true);
            otherResult7.GradientAngle = 0F;
            otherResult7.GradientPrimaryColor = Color.Transparent;
            otherResult7.GradientSecondaryColor = Color.Transparent;
            otherResult7.Location = new Point(3, 677);
            otherResult7.Name = "otherResult7";
            otherResult7.Size = new Size(595, 60);
            otherResult7.TabIndex = 20;
            otherResult7.Visible = false;
            // 
            // otherTable7
            // 
            otherTable7.AutoSize = true;
            otherTable7.ColumnCount = 2;
            otherTable7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable7.Controls.Add(otherTitle7, 1, 0);
            otherTable7.Controls.Add(otherImg7, 0, 0);
            otherTable7.Dock = DockStyle.Fill;
            otherTable7.Location = new Point(0, 0);
            otherTable7.Name = "otherTable7";
            otherTable7.RowCount = 1;
            otherTable7.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable7.Size = new Size(595, 60);
            otherTable7.TabIndex = 0;
            // 
            // otherTitle7
            // 
            otherTitle7.AutoSize = true;
            otherTitle7.BackColor = Color.Transparent;
            otherTitle7.Dock = DockStyle.Fill;
            otherTitle7.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle7.ForeColor = SystemColors.ControlLight;
            otherTitle7.Location = new Point(63, 0);
            otherTitle7.Name = "otherTitle7";
            otherTitle7.Size = new Size(529, 88);
            otherTitle7.TabIndex = 2;
            otherTitle7.Text = "title";
            toolTip1.SetToolTip(otherTitle7, "author");
            otherTitle7.Click += otherTitle7_Click;
            // 
            // otherImg7
            // 
            otherImg7.BackColor = Color.Transparent;
            otherImg7.Location = new Point(3, 0);
            otherImg7.Name = "otherImg7";
            otherImg7.Size = new Size(54, 50);
            otherImg7.TabIndex = 0;
            otherImg7.Click += otherTitle7_Click;
            // 
            // otherResult8
            // 
            otherResult8.Controls.Add(otherTable8);
            bestMatchPanel.SetFlowBreak(otherResult8, true);
            otherResult8.GradientAngle = 0F;
            otherResult8.GradientPrimaryColor = Color.Transparent;
            otherResult8.GradientSecondaryColor = Color.Transparent;
            otherResult8.Location = new Point(3, 743);
            otherResult8.Name = "otherResult8";
            otherResult8.Size = new Size(595, 60);
            otherResult8.TabIndex = 21;
            otherResult8.Visible = false;
            // 
            // otherTable8
            // 
            otherTable8.AutoSize = true;
            otherTable8.ColumnCount = 2;
            otherTable8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable8.Controls.Add(otherTitle8, 1, 0);
            otherTable8.Controls.Add(otherImg8, 0, 0);
            otherTable8.Dock = DockStyle.Fill;
            otherTable8.Location = new Point(0, 0);
            otherTable8.Name = "otherTable8";
            otherTable8.RowCount = 1;
            otherTable8.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable8.Size = new Size(595, 60);
            otherTable8.TabIndex = 0;
            // 
            // otherTitle8
            // 
            otherTitle8.AutoSize = true;
            otherTitle8.BackColor = Color.Transparent;
            otherTitle8.Dock = DockStyle.Fill;
            otherTitle8.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle8.ForeColor = SystemColors.ControlLight;
            otherTitle8.Location = new Point(63, 0);
            otherTitle8.Name = "otherTitle8";
            otherTitle8.Size = new Size(529, 88);
            otherTitle8.TabIndex = 2;
            otherTitle8.Text = "title";
            toolTip1.SetToolTip(otherTitle8, "author");
            otherTitle8.Click += otherTitle8_Click;
            // 
            // otherImg8
            // 
            otherImg8.BackColor = Color.Transparent;
            otherImg8.Location = new Point(3, 0);
            otherImg8.Name = "otherImg8";
            otherImg8.Size = new Size(54, 50);
            otherImg8.TabIndex = 0;
            otherImg8.Click += otherTitle8_Click;
            // 
            // otherResult9
            // 
            otherResult9.Controls.Add(otherTable9);
            bestMatchPanel.SetFlowBreak(otherResult9, true);
            otherResult9.GradientAngle = 0F;
            otherResult9.GradientPrimaryColor = Color.Transparent;
            otherResult9.GradientSecondaryColor = Color.Transparent;
            otherResult9.Location = new Point(3, 809);
            otherResult9.Name = "otherResult9";
            otherResult9.Size = new Size(595, 60);
            otherResult9.TabIndex = 22;
            otherResult9.Visible = false;
            // 
            // otherTable9
            // 
            otherTable9.AutoSize = true;
            otherTable9.ColumnCount = 2;
            otherTable9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            otherTable9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            otherTable9.Controls.Add(otherTitle9, 1, 0);
            otherTable9.Controls.Add(otherImg9, 0, 0);
            otherTable9.Dock = DockStyle.Fill;
            otherTable9.Location = new Point(0, 0);
            otherTable9.Name = "otherTable9";
            otherTable9.RowCount = 1;
            otherTable9.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            otherTable9.Size = new Size(595, 60);
            otherTable9.TabIndex = 0;
            // 
            // otherTitle9
            // 
            otherTitle9.AutoSize = true;
            otherTitle9.BackColor = Color.Transparent;
            otherTitle9.Dock = DockStyle.Fill;
            otherTitle9.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            otherTitle9.ForeColor = SystemColors.ControlLight;
            otherTitle9.Location = new Point(63, 0);
            otherTitle9.Name = "otherTitle9";
            otherTitle9.Size = new Size(529, 88);
            otherTitle9.TabIndex = 2;
            otherTitle9.Text = "title";
            toolTip1.SetToolTip(otherTitle9, "author");
            otherTitle9.Click += otherTitle9_Click;
            // 
            // otherImg9
            // 
            otherImg9.BackColor = Color.Transparent;
            otherImg9.Location = new Point(3, 0);
            otherImg9.Name = "otherImg9";
            otherImg9.Size = new Size(54, 50);
            otherImg9.TabIndex = 0;
            otherImg9.Click += otherTitle9_Click;
            // 
            // flowLayoutPanel61
            // 
            flowLayoutPanel61.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel61.AutoSize = true;
            searchFlowPanel.SetFlowBreak(flowLayoutPanel61, true);
            flowLayoutPanel61.Location = new Point(3, 1029);
            flowLayoutPanel61.Margin = new Padding(3, 3, 3, 30);
            flowLayoutPanel61.Name = "flowLayoutPanel61";
            flowLayoutPanel61.Size = new Size(0, 0);
            flowLayoutPanel61.TabIndex = 3;
            // 
            // favoritePanel
            // 
            favoritePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            favoritePanel.AutoScroll = true;
            favoritePanel.Controls.Add(favFlowPanel);
            favoritePanel.Location = new Point(0, 1557);
            favoritePanel.Margin = new Padding(0);
            favoritePanel.Name = "favoritePanel";
            favoritePanel.Size = new Size(803, 765);
            favoritePanel.TabIndex = 2;
            favoritePanel.Visible = false;
            // 
            // favFlowPanel
            // 
            favFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            favFlowPanel.AutoSize = true;
            favFlowPanel.Controls.Add(favoriteLabel);
            favFlowPanel.Controls.Add(favTableHead);
            favoritePanel.SetFlowBreak(favFlowPanel, true);
            favFlowPanel.Location = new Point(0, 27);
            favFlowPanel.Margin = new Padding(0, 27, 0, 150);
            favFlowPanel.Name = "favFlowPanel";
            favFlowPanel.Size = new Size(741, 132);
            favFlowPanel.TabIndex = 0;
            // 
            // favoriteLabel
            // 
            favFlowPanel.SetFlowBreak(favoriteLabel, true);
            favoriteLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            favoriteLabel.ForeColor = SystemColors.ControlLightLight;
            favoriteLabel.Location = new Point(3, 0);
            favoriteLabel.Name = "favoriteLabel";
            favoriteLabel.Size = new Size(735, 82);
            favoriteLabel.TabIndex = 0;
            favoriteLabel.Text = "Favorite";
            // 
            // favTableHead
            // 
            favTableHead.ColumnCount = 4;
            favTableHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            favTableHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            favTableHead.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            favTableHead.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            favTableHead.Controls.Add(favBookLabel, 1, 0);
            favTableHead.Controls.Add(favRankLabel, 0, 0);
            favTableHead.Controls.Add(scoreLabel, 3, 0);
            favTableHead.Controls.Add(favPublisherLabel, 2, 0);
            favTableHead.Location = new Point(0, 82);
            favTableHead.Margin = new Padding(0);
            favTableHead.Name = "favTableHead";
            favTableHead.RowCount = 1;
            favTableHead.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            favTableHead.Size = new Size(732, 50);
            favTableHead.TabIndex = 8;
            // 
            // favBookLabel
            // 
            favBookLabel.AutoSize = true;
            favBookLabel.Dock = DockStyle.Fill;
            favBookLabel.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            favBookLabel.ForeColor = SystemColors.ButtonHighlight;
            favBookLabel.Location = new Point(53, 0);
            favBookLabel.Name = "favBookLabel";
            favBookLabel.Size = new Size(373, 50);
            favBookLabel.TabIndex = 4;
            favBookLabel.Text = "Book Title";
            // 
            // favRankLabel
            // 
            favRankLabel.AutoSize = true;
            favRankLabel.Dock = DockStyle.Fill;
            favRankLabel.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            favRankLabel.ForeColor = SystemColors.ButtonHighlight;
            favRankLabel.Location = new Point(0, 0);
            favRankLabel.Margin = new Padding(0);
            favRankLabel.Name = "favRankLabel";
            favRankLabel.Size = new Size(50, 50);
            favRankLabel.TabIndex = 3;
            favRankLabel.Text = "#";
            favRankLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            scoreLabel.BackColor = Color.Transparent;
            scoreLabel.Image = (Image)resources.GetObject("scoreLabel.Image");
            scoreLabel.Location = new Point(681, 0);
            scoreLabel.Margin = new Padding(0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(51, 50);
            scoreLabel.TabIndex = 1;
            // 
            // favPublisherLabel
            // 
            favPublisherLabel.AutoSize = true;
            favPublisherLabel.Dock = DockStyle.Fill;
            favPublisherLabel.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            favPublisherLabel.ForeColor = SystemColors.ButtonHighlight;
            favPublisherLabel.Location = new Point(432, 0);
            favPublisherLabel.Name = "favPublisherLabel";
            favPublisherLabel.Size = new Size(246, 50);
            favPublisherLabel.TabIndex = 2;
            favPublisherLabel.Text = "Category";
            // 
            // categoriesPanel
            // 
            categoriesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            categoriesPanel.AutoScroll = true;
            categoriesPanel.Controls.Add(mainCategoryPanel);
            categoriesPanel.Controls.Add(authormainFlowPanel);
            categoriesPanel.Controls.Add(otherCategoriesPanel);
            categoriesPanel.Location = new Point(0, 2322);
            categoriesPanel.Margin = new Padding(0);
            categoriesPanel.Name = "categoriesPanel";
            categoriesPanel.Size = new Size(767, 765);
            categoriesPanel.TabIndex = 3;
            categoriesPanel.Visible = false;
            // 
            // mainCategoryPanel
            // 
            mainCategoryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainCategoryPanel.AutoSize = true;
            mainCategoryPanel.Controls.Add(categoryMainLabel);
            categoriesPanel.SetFlowBreak(mainCategoryPanel, true);
            mainCategoryPanel.Location = new Point(0, 27);
            mainCategoryPanel.Margin = new Padding(0, 27, 0, 0);
            mainCategoryPanel.Name = "mainCategoryPanel";
            mainCategoryPanel.Size = new Size(741, 82);
            mainCategoryPanel.TabIndex = 0;
            // 
            // categoryMainLabel
            // 
            mainCategoryPanel.SetFlowBreak(categoryMainLabel, true);
            categoryMainLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            categoryMainLabel.ForeColor = SystemColors.ControlLightLight;
            categoryMainLabel.Location = new Point(3, 0);
            categoryMainLabel.Name = "categoryMainLabel";
            categoryMainLabel.Size = new Size(735, 82);
            categoryMainLabel.TabIndex = 0;
            categoryMainLabel.Text = "Category";
            // 
            // authormainFlowPanel
            // 
            authormainFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            authormainFlowPanel.AutoSize = true;
            authormainFlowPanel.Controls.Add(authorMainLabel);
            categoriesPanel.SetFlowBreak(authormainFlowPanel, true);
            authormainFlowPanel.Location = new Point(0, 136);
            authormainFlowPanel.Margin = new Padding(0, 27, 0, 0);
            authormainFlowPanel.Name = "authormainFlowPanel";
            authormainFlowPanel.Size = new Size(741, 82);
            authormainFlowPanel.TabIndex = 3;
            // 
            // authorMainLabel
            // 
            authormainFlowPanel.SetFlowBreak(authorMainLabel, true);
            authorMainLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            authorMainLabel.ForeColor = SystemColors.ControlLightLight;
            authorMainLabel.Location = new Point(3, 0);
            authorMainLabel.Name = "authorMainLabel";
            authorMainLabel.Size = new Size(735, 82);
            authorMainLabel.TabIndex = 0;
            authorMainLabel.Text = "Author";
            // 
            // otherCategoriesPanel
            // 
            otherCategoriesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            otherCategoriesPanel.AutoSize = true;
            otherCategoriesPanel.Controls.Add(otherCategoryLabel);
            categoriesPanel.SetFlowBreak(otherCategoriesPanel, true);
            otherCategoriesPanel.Location = new Point(0, 245);
            otherCategoriesPanel.Margin = new Padding(0, 27, 0, 150);
            otherCategoriesPanel.Name = "otherCategoriesPanel";
            otherCategoriesPanel.Size = new Size(741, 82);
            otherCategoriesPanel.TabIndex = 4;
            // 
            // otherCategoryLabel
            // 
            otherCategoriesPanel.SetFlowBreak(otherCategoryLabel, true);
            otherCategoryLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            otherCategoryLabel.ForeColor = SystemColors.ControlLightLight;
            otherCategoryLabel.Location = new Point(3, 0);
            otherCategoryLabel.Name = "otherCategoryLabel";
            otherCategoryLabel.Size = new Size(735, 82);
            otherCategoryLabel.TabIndex = 0;
            otherCategoryLabel.Text = "Other categories";
            // 
            // historyPanel
            // 
            historyPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            historyPanel.AutoScroll = true;
            historyPanel.Controls.Add(historyFlowPanel);
            historyPanel.Location = new Point(0, 3087);
            historyPanel.Margin = new Padding(0);
            historyPanel.Name = "historyPanel";
            historyPanel.Size = new Size(767, 765);
            historyPanel.TabIndex = 4;
            historyPanel.Visible = false;
            // 
            // historyFlowPanel
            // 
            historyFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            historyFlowPanel.AutoSize = true;
            historyFlowPanel.Controls.Add(historyLabel);
            historyPanel.SetFlowBreak(historyFlowPanel, true);
            historyFlowPanel.Location = new Point(0, 27);
            historyFlowPanel.Margin = new Padding(0, 27, 0, 50);
            historyFlowPanel.Name = "historyFlowPanel";
            historyFlowPanel.Size = new Size(741, 82);
            historyFlowPanel.TabIndex = 0;
            // 
            // historyLabel
            // 
            historyFlowPanel.SetFlowBreak(historyLabel, true);
            historyLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            historyLabel.ForeColor = SystemColors.ControlLightLight;
            historyLabel.Location = new Point(3, 0);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new Size(735, 82);
            historyLabel.TabIndex = 0;
            historyLabel.Text = "Read history";
            // 
            // bestBookPanel
            // 
            bestBookPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bestBookPanel.AutoScroll = true;
            bestBookPanel.Controls.Add(bestBookFlowPanel);
            bestBookPanel.Location = new Point(0, 3852);
            bestBookPanel.Margin = new Padding(0);
            bestBookPanel.Name = "bestBookPanel";
            bestBookPanel.Size = new Size(767, 765);
            bestBookPanel.TabIndex = 17;
            // 
            // bestBookFlowPanel
            // 
            bestBookFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bestBookFlowPanel.AutoSize = true;
            bestBookFlowPanel.Controls.Add(bestBookLabel);
            bestBookFlowPanel.Controls.Add(bestBookElement0);
            bestBookFlowPanel.Controls.Add(bestBookElement1);
            bestBookFlowPanel.Controls.Add(bestBookElement2);
            bestBookFlowPanel.Controls.Add(bestBookElement3);
            bestBookPanel.SetFlowBreak(bestBookFlowPanel, true);
            bestBookFlowPanel.Location = new Point(0, 0);
            bestBookFlowPanel.Margin = new Padding(0);
            bestBookFlowPanel.Name = "bestBookFlowPanel";
            bestBookFlowPanel.Size = new Size(735, 258);
            bestBookFlowPanel.TabIndex = 0;
            bestBookFlowPanel.Visible = false;
            // 
            // bestBookLabel
            // 
            bestBookFlowPanel.SetFlowBreak(bestBookLabel, true);
            bestBookLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookLabel.ForeColor = SystemColors.ControlLightLight;
            bestBookLabel.Location = new Point(0, 0);
            bestBookLabel.Margin = new Padding(0);
            bestBookLabel.Name = "bestBookLabel";
            bestBookLabel.Size = new Size(735, 82);
            bestBookLabel.TabIndex = 0;
            bestBookLabel.Text = "Best Book!";
            // 
            // bestBookElement0
            // 
            bestBookElement0.BackColor = Color.Transparent;
            bestBookElement0.Controls.Add(bestBookTable0);
            bestBookElement0.GradientAngle = 60F;
            bestBookElement0.GradientPrimaryColor = Color.Transparent;
            bestBookElement0.GradientSecondaryColor = Color.White;
            bestBookElement0.Location = new Point(0, 82);
            bestBookElement0.Margin = new Padding(0);
            bestBookElement0.Name = "bestBookElement0";
            bestBookElement0.Size = new Size(349, 88);
            bestBookElement0.TabIndex = 4;
            // 
            // bestBookTable0
            // 
            bestBookTable0.AutoSize = true;
            bestBookTable0.ColumnCount = 2;
            bestBookTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            bestBookTable0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bestBookTable0.Controls.Add(bestBookImg0, 0, 0);
            bestBookTable0.Controls.Add(bestBookLabel0, 1, 0);
            bestBookTable0.Dock = DockStyle.Fill;
            bestBookTable0.Location = new Point(0, 0);
            bestBookTable0.Name = "bestBookTable0";
            bestBookTable0.RowCount = 1;
            bestBookTable0.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            bestBookTable0.Size = new Size(349, 88);
            bestBookTable0.TabIndex = 0;
            // 
            // bestBookImg0
            // 
            bestBookImg0.BackColor = Color.Transparent;
            bestBookImg0.Image = (Image)resources.GetObject("bestBookImg0.Image");
            bestBookImg0.Location = new Point(3, 0);
            bestBookImg0.Name = "bestBookImg0";
            bestBookImg0.Size = new Size(82, 88);
            bestBookImg0.TabIndex = 0;
            bestBookImg0.Click += bestBookLabel0_Click;
            // 
            // bestBookLabel0
            // 
            bestBookLabel0.AutoSize = true;
            bestBookLabel0.Controls.Add(bestBookTitle0);
            bestBookLabel0.Controls.Add(bestBookAuthor0);
            bestBookLabel0.Dock = DockStyle.Fill;
            bestBookLabel0.Location = new Point(91, 3);
            bestBookLabel0.Name = "bestBookLabel0";
            bestBookLabel0.Size = new Size(255, 82);
            bestBookLabel0.TabIndex = 1;
            bestBookLabel0.Click += bestBookLabel0_Click;
            // 
            // bestBookTitle0
            // 
            bestBookTitle0.AutoSize = true;
            bestBookTitle0.BackColor = Color.Transparent;
            bestBookLabel0.SetFlowBreak(bestBookTitle0, true);
            bestBookTitle0.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookTitle0.ForeColor = SystemColors.ControlLight;
            bestBookTitle0.Location = new Point(3, 0);
            bestBookTitle0.Name = "bestBookTitle0";
            bestBookTitle0.Size = new Size(50, 28);
            bestBookTitle0.TabIndex = 1;
            bestBookTitle0.Text = "title";
            bestBookTitle0.Click += bestBookLabel0_Click;
            // 
            // bestBookAuthor0
            // 
            bestBookAuthor0.AutoSize = true;
            bestBookAuthor0.BackColor = Color.Transparent;
            bestBookLabel0.SetFlowBreak(bestBookAuthor0, true);
            bestBookAuthor0.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookAuthor0.ForeColor = SystemColors.ControlLight;
            bestBookAuthor0.Location = new Point(3, 28);
            bestBookAuthor0.Name = "bestBookAuthor0";
            bestBookAuthor0.Size = new Size(50, 19);
            bestBookAuthor0.TabIndex = 2;
            bestBookAuthor0.Text = "author";
            bestBookAuthor0.Click += bestBookLabel0_Click;
            // 
            // bestBookElement1
            // 
            bestBookElement1.Controls.Add(bestBookTable1);
            bestBookElement1.GradientAngle = 60F;
            bestBookElement1.GradientPrimaryColor = Color.Transparent;
            bestBookElement1.GradientSecondaryColor = Color.White;
            bestBookElement1.Location = new Point(349, 82);
            bestBookElement1.Margin = new Padding(0);
            bestBookElement1.Name = "bestBookElement1";
            bestBookElement1.Size = new Size(349, 88);
            bestBookElement1.TabIndex = 5;
            // 
            // bestBookTable1
            // 
            bestBookTable1.AutoSize = true;
            bestBookTable1.ColumnCount = 2;
            bestBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            bestBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bestBookTable1.Controls.Add(bestBookImg1, 0, 0);
            bestBookTable1.Controls.Add(bestBookLabel1, 1, 0);
            bestBookTable1.Dock = DockStyle.Fill;
            bestBookTable1.Location = new Point(0, 0);
            bestBookTable1.Name = "bestBookTable1";
            bestBookTable1.RowCount = 1;
            bestBookTable1.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            bestBookTable1.Size = new Size(349, 88);
            bestBookTable1.TabIndex = 0;
            // 
            // bestBookImg1
            // 
            bestBookImg1.BackColor = Color.Transparent;
            bestBookImg1.Image = (Image)resources.GetObject("bestBookImg1.Image");
            bestBookImg1.Location = new Point(3, 0);
            bestBookImg1.Name = "bestBookImg1";
            bestBookImg1.Size = new Size(82, 88);
            bestBookImg1.TabIndex = 0;
            bestBookImg1.Click += bestBookLabel1_Click;
            // 
            // bestBookLabel1
            // 
            bestBookLabel1.Controls.Add(bestBookTitle1);
            bestBookLabel1.Controls.Add(bestBookAuthor1);
            bestBookLabel1.Dock = DockStyle.Fill;
            bestBookLabel1.Location = new Point(91, 3);
            bestBookLabel1.Name = "bestBookLabel1";
            bestBookLabel1.Size = new Size(255, 82);
            bestBookLabel1.TabIndex = 1;
            bestBookLabel1.Click += bestBookLabel1_Click;
            // 
            // bestBookTitle1
            // 
            bestBookTitle1.AutoSize = true;
            bestBookTitle1.BackColor = Color.Transparent;
            bestBookLabel1.SetFlowBreak(bestBookTitle1, true);
            bestBookTitle1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookTitle1.ForeColor = SystemColors.ControlLight;
            bestBookTitle1.Location = new Point(3, 0);
            bestBookTitle1.Name = "bestBookTitle1";
            bestBookTitle1.Size = new Size(50, 28);
            bestBookTitle1.TabIndex = 1;
            bestBookTitle1.Text = "title";
            bestBookTitle1.Click += bestBookLabel1_Click;
            // 
            // bestBookAuthor1
            // 
            bestBookAuthor1.AutoSize = true;
            bestBookAuthor1.BackColor = Color.Transparent;
            bestBookLabel1.SetFlowBreak(bestBookAuthor1, true);
            bestBookAuthor1.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookAuthor1.ForeColor = SystemColors.ControlLight;
            bestBookAuthor1.Location = new Point(3, 28);
            bestBookAuthor1.Name = "bestBookAuthor1";
            bestBookAuthor1.Size = new Size(50, 19);
            bestBookAuthor1.TabIndex = 3;
            bestBookAuthor1.Text = "author";
            bestBookAuthor1.Click += bestBookLabel1_Click;
            // 
            // bestBookElement2
            // 
            bestBookElement2.Controls.Add(bestBookTable2);
            bestBookElement2.GradientAngle = 60F;
            bestBookElement2.GradientPrimaryColor = Color.Transparent;
            bestBookElement2.GradientSecondaryColor = Color.White;
            bestBookElement2.Location = new Point(0, 170);
            bestBookElement2.Margin = new Padding(0);
            bestBookElement2.Name = "bestBookElement2";
            bestBookElement2.Size = new Size(349, 88);
            bestBookElement2.TabIndex = 6;
            // 
            // bestBookTable2
            // 
            bestBookTable2.AutoSize = true;
            bestBookTable2.ColumnCount = 2;
            bestBookTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            bestBookTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bestBookTable2.Controls.Add(bestBookImg2, 0, 0);
            bestBookTable2.Controls.Add(bestBookLabel2, 1, 0);
            bestBookTable2.Dock = DockStyle.Fill;
            bestBookTable2.Location = new Point(0, 0);
            bestBookTable2.Name = "bestBookTable2";
            bestBookTable2.RowCount = 1;
            bestBookTable2.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            bestBookTable2.Size = new Size(349, 88);
            bestBookTable2.TabIndex = 0;
            // 
            // bestBookImg2
            // 
            bestBookImg2.BackColor = Color.Transparent;
            bestBookImg2.Image = (Image)resources.GetObject("bestBookImg2.Image");
            bestBookImg2.Location = new Point(3, 0);
            bestBookImg2.Name = "bestBookImg2";
            bestBookImg2.Size = new Size(82, 88);
            bestBookImg2.TabIndex = 0;
            bestBookImg2.Click += bestBookLabel2_Click;
            // 
            // bestBookLabel2
            // 
            bestBookLabel2.Controls.Add(bestBookTitle2);
            bestBookLabel2.Controls.Add(bestBookAuthor2);
            bestBookLabel2.Dock = DockStyle.Fill;
            bestBookLabel2.Location = new Point(91, 3);
            bestBookLabel2.Name = "bestBookLabel2";
            bestBookLabel2.Size = new Size(255, 82);
            bestBookLabel2.TabIndex = 1;
            bestBookLabel2.Click += bestBookLabel2_Click;
            // 
            // bestBookTitle2
            // 
            bestBookTitle2.AutoSize = true;
            bestBookTitle2.BackColor = Color.Transparent;
            bestBookLabel2.SetFlowBreak(bestBookTitle2, true);
            bestBookTitle2.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookTitle2.ForeColor = SystemColors.ControlLight;
            bestBookTitle2.Location = new Point(3, 0);
            bestBookTitle2.Name = "bestBookTitle2";
            bestBookTitle2.Size = new Size(50, 28);
            bestBookTitle2.TabIndex = 1;
            bestBookTitle2.Text = "title";
            bestBookTitle2.Click += bestBookLabel2_Click;
            // 
            // bestBookAuthor2
            // 
            bestBookAuthor2.AutoSize = true;
            bestBookAuthor2.BackColor = Color.Transparent;
            bestBookLabel2.SetFlowBreak(bestBookAuthor2, true);
            bestBookAuthor2.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookAuthor2.ForeColor = SystemColors.ControlLight;
            bestBookAuthor2.Location = new Point(3, 28);
            bestBookAuthor2.Name = "bestBookAuthor2";
            bestBookAuthor2.Size = new Size(50, 19);
            bestBookAuthor2.TabIndex = 4;
            bestBookAuthor2.Text = "author";
            bestBookAuthor2.Click += bestBookLabel2_Click;
            // 
            // bestBookElement3
            // 
            bestBookElement3.Controls.Add(bestBookTable3);
            bestBookElement3.GradientAngle = 60F;
            bestBookElement3.GradientPrimaryColor = Color.Transparent;
            bestBookElement3.GradientSecondaryColor = Color.White;
            bestBookElement3.Location = new Point(349, 170);
            bestBookElement3.Margin = new Padding(0);
            bestBookElement3.Name = "bestBookElement3";
            bestBookElement3.Size = new Size(349, 88);
            bestBookElement3.TabIndex = 7;
            // 
            // bestBookTable3
            // 
            bestBookTable3.AutoSize = true;
            bestBookTable3.ColumnCount = 2;
            bestBookTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            bestBookTable3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bestBookTable3.Controls.Add(bestBookImg3, 0, 0);
            bestBookTable3.Controls.Add(bestBookLabel3, 1, 0);
            bestBookTable3.Dock = DockStyle.Fill;
            bestBookTable3.Location = new Point(0, 0);
            bestBookTable3.Name = "bestBookTable3";
            bestBookTable3.RowCount = 1;
            bestBookTable3.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            bestBookTable3.Size = new Size(349, 88);
            bestBookTable3.TabIndex = 0;
            // 
            // bestBookImg3
            // 
            bestBookImg3.BackColor = Color.Transparent;
            bestBookImg3.Image = (Image)resources.GetObject("bestBookImg3.Image");
            bestBookImg3.Location = new Point(3, 0);
            bestBookImg3.Name = "bestBookImg3";
            bestBookImg3.Size = new Size(82, 88);
            bestBookImg3.TabIndex = 0;
            bestBookImg3.Click += bestBookLabel3_Click;
            // 
            // bestBookLabel3
            // 
            bestBookLabel3.Controls.Add(bestBookTitle3);
            bestBookLabel3.Controls.Add(bestBookAuthor3);
            bestBookLabel3.Dock = DockStyle.Fill;
            bestBookLabel3.Location = new Point(91, 3);
            bestBookLabel3.Name = "bestBookLabel3";
            bestBookLabel3.Size = new Size(255, 82);
            bestBookLabel3.TabIndex = 1;
            bestBookLabel3.Click += bestBookLabel3_Click;
            // 
            // bestBookTitle3
            // 
            bestBookTitle3.AutoSize = true;
            bestBookTitle3.BackColor = Color.Transparent;
            bestBookLabel3.SetFlowBreak(bestBookTitle3, true);
            bestBookTitle3.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookTitle3.ForeColor = SystemColors.ControlLight;
            bestBookTitle3.Location = new Point(3, 0);
            bestBookTitle3.Name = "bestBookTitle3";
            bestBookTitle3.Size = new Size(50, 28);
            bestBookTitle3.TabIndex = 1;
            bestBookTitle3.Text = "title";
            bestBookTitle3.Click += bestBookLabel3_Click;
            // 
            // bestBookAuthor3
            // 
            bestBookAuthor3.AutoSize = true;
            bestBookAuthor3.BackColor = Color.Transparent;
            bestBookLabel3.SetFlowBreak(bestBookAuthor3, true);
            bestBookAuthor3.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            bestBookAuthor3.ForeColor = SystemColors.ControlLight;
            bestBookAuthor3.Location = new Point(3, 28);
            bestBookAuthor3.Name = "bestBookAuthor3";
            bestBookAuthor3.Size = new Size(50, 19);
            bestBookAuthor3.TabIndex = 5;
            bestBookAuthor3.Text = "author";
            bestBookAuthor3.Click += bestBookLabel3_Click;
            // 
            // currentPanel
            // 
            currentPanel.BackColor = Color.Gainsboro;
            currentPanel.Controls.Add(currentLabel);
            currentPanel.Dock = DockStyle.Fill;
            currentPanel.Location = new Point(1180, 726);
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
            currentProperties.Location = new Point(400, 726);
            currentProperties.Margin = new Padding(0);
            currentProperties.Name = "currentProperties";
            currentProperties.Size = new Size(780, 100);
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
            currentPropertiesTable.Size = new Size(780, 100);
            currentPropertiesTable.TabIndex = 0;
            // 
            // currentBookPanel
            // 
            currentBookPanel.Controls.Add(currentBookTitle);
            currentBookPanel.Controls.Add(currentBookAuthor);
            currentBookPanel.Controls.Add(currentBookRate);
            currentBookPanel.Dock = DockStyle.Fill;
            currentBookPanel.FlowDirection = FlowDirection.RightToLeft;
            currentBookPanel.Location = new Point(440, 0);
            currentBookPanel.Margin = new Padding(0);
            currentBookPanel.Name = "currentBookPanel";
            currentBookPanel.Size = new Size(340, 100);
            currentBookPanel.TabIndex = 0;
            // 
            // currentBookTitle
            // 
            currentBookTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            currentBookTitle.AutoSize = true;
            currentBookPanel.SetFlowBreak(currentBookTitle, true);
            currentBookTitle.Font = new Font("Exo ExtraBold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point);
            currentBookTitle.ForeColor = SystemColors.Menu;
            currentBookTitle.Location = new Point(242, 10);
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
            currentBookAuthor.Location = new Point(246, 34);
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
            currentBookRate.Location = new Point(237, 59);
            currentBookRate.Name = "currentBookRate";
            currentBookRate.Size = new Size(100, 25);
            currentBookRate.TabIndex = 2;
            currentBookRate.Text = "3.0";
            // 
            // currentPagePanel
            // 
            currentPagePanel.Controls.Add(totalPage);
            currentPagePanel.Controls.Add(currentPage);
            currentPagePanel.Dock = DockStyle.Fill;
            currentPagePanel.Location = new Point(340, 0);
            currentPagePanel.Margin = new Padding(0);
            currentPagePanel.Name = "currentPagePanel";
            currentPagePanel.Size = new Size(100, 100);
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
            currentPublisherPanel.Size = new Size(340, 100);
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
            optionPanel.Location = new Point(0, 726);
            optionPanel.Margin = new Padding(0);
            optionPanel.Name = "optionPanel";
            optionPanel.Size = new Size(400, 100);
            optionPanel.TabIndex = 7;
            // 
            // optionsFlowPanel
            // 
            optionsFlowPanel.Controls.Add(heartOption);
            optionsFlowPanel.Controls.Add(textToSpeech);
            optionsFlowPanel.Controls.Add(brightness);
            optionsFlowPanel.Controls.Add(forward);
            optionsFlowPanel.Controls.Add(bookmark);
            optionsFlowPanel.Dock = DockStyle.Fill;
            optionsFlowPanel.FlowDirection = FlowDirection.RightToLeft;
            optionsFlowPanel.Location = new Point(0, 0);
            optionsFlowPanel.Name = "optionsFlowPanel";
            optionsFlowPanel.Size = new Size(400, 100);
            optionsFlowPanel.TabIndex = 0;
            // 
            // heartOption
            // 
            heartOption.Image = (Image)resources.GetObject("heartOption.Image");
            heartOption.Location = new Point(323, 30);
            heartOption.Margin = new Padding(10, 30, 30, 30);
            heartOption.Name = "heartOption";
            heartOption.Size = new Size(47, 41);
            heartOption.TabIndex = 0;
            // 
            // textToSpeech
            // 
            textToSpeech.Enabled = false;
            textToSpeech.Image = (Image)resources.GetObject("textToSpeech.Image");
            textToSpeech.Location = new Point(266, 30);
            textToSpeech.Margin = new Padding(10, 30, 0, 30);
            textToSpeech.Name = "textToSpeech";
            textToSpeech.Size = new Size(47, 41);
            textToSpeech.TabIndex = 1;
            // 
            // brightness
            // 
            brightness.Enabled = false;
            brightness.Image = (Image)resources.GetObject("brightness.Image");
            brightness.Location = new Point(209, 30);
            brightness.Margin = new Padding(15, 30, 0, 30);
            brightness.Name = "brightness";
            brightness.Size = new Size(47, 41);
            brightness.TabIndex = 2;
            // 
            // forward
            // 
            forward.Enabled = false;
            forward.Image = (Image)resources.GetObject("forward.Image");
            forward.Location = new Point(147, 30);
            forward.Margin = new Padding(15, 30, 0, 30);
            forward.Name = "forward";
            forward.Size = new Size(47, 41);
            forward.TabIndex = 3;
            // 
            // bookmark
            // 
            bookmark.Enabled = false;
            bookmark.Image = (Image)resources.GetObject("bookmark.Image");
            bookmark.Location = new Point(85, 30);
            bookmark.Margin = new Padding(15, 30, 0, 30);
            bookmark.Name = "bookmark";
            bookmark.Size = new Size(47, 41);
            bookmark.TabIndex = 4;
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
            label3.Text = "otherTitle1";
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
            label9.Text = "otherTitle1";
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, close, maximize, minimize });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1280, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.MouseDown += toolStrip1_MouseDown;
            toolStrip1.MouseMove += mainForm_MouseMove;
            toolStrip1.MouseUp += mainForm_MouseUp;
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
            // close
            // 
            close.Alignment = ToolStripItemAlignment.Right;
            close.BackColor = Color.Transparent;
            close.DisplayStyle = ToolStripItemDisplayStyle.Image;
            close.Image = (Image)resources.GetObject("close.Image");
            close.ImageTransparentColor = Color.Crimson;
            close.Name = "close";
            close.Size = new Size(29, 24);
            close.Text = "toolStripButton1";
            close.TextAlign = ContentAlignment.MiddleRight;
            close.Click += toolStripButton1_Click;
            // 
            // maximize
            // 
            maximize.Alignment = ToolStripItemAlignment.Right;
            maximize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            maximize.Image = (Image)resources.GetObject("maximize.Image");
            maximize.ImageTransparentColor = Color.Magenta;
            maximize.Name = "maximize";
            maximize.Size = new Size(29, 24);
            maximize.Text = "toolStripButton2";
            maximize.Click += toolStripButton2_Click;
            // 
            // minimize
            // 
            minimize.Alignment = ToolStripItemAlignment.Right;
            minimize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            minimize.Image = (Image)resources.GetObject("minimize.Image");
            minimize.ImageTransparentColor = Color.Magenta;
            minimize.Name = "minimize";
            minimize.Size = new Size(29, 24);
            minimize.Text = "toolStripButton3";
            minimize.Click += toolStripButton3_Click;
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
            Controls.Add(containerMainTableLayout);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Padding = new Padding(0, 0, 0, 20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            toolTip1.SetToolTip(this, "user");
            Load += MainForm_Load;
            ResizeBegin += MainForm_ResizeBegin;
            Resize += MainForm_Resize;
            containerMainTableLayout.ResumeLayout(false);
            verticalMenuBar.ResumeLayout(false);
            verticalTableMenu.ResumeLayout(false);
            topBlank.ResumeLayout(false);
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
            categoryTable0.ResumeLayout(false);
            categoryFlowPanel0.ResumeLayout(false);
            categoryFlowPanel0.PerformLayout();
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
            helloFlow1.ResumeLayout(false);
            helloFlow1.PerformLayout();
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
            recommentElement0.ResumeLayout(false);
            recommentElement0.PerformLayout();
            recommentTable0.ResumeLayout(false);
            recommentFlowPanel0.ResumeLayout(false);
            recommentFlowPanel0.PerformLayout();
            recommentElement1.ResumeLayout(false);
            recommentElement1.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            recommentFlowPanel1.ResumeLayout(false);
            recommentFlowPanel1.PerformLayout();
            recommentElement2.ResumeLayout(false);
            recommentElement2.PerformLayout();
            recommentTable2.ResumeLayout(false);
            recommentFlowLabel2.ResumeLayout(false);
            recommentFlowLabel2.PerformLayout();
            recommentElement3.ResumeLayout(false);
            recommentElement3.PerformLayout();
            recommentTable3.ResumeLayout(false);
            recommentFlowLabel3.ResumeLayout(false);
            recommentFlowLabel3.PerformLayout();
            searchFlowPanel.ResumeLayout(false);
            searchFlowPanel.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchLayoutTable.ResumeLayout(false);
            searchBoxContainer.ResumeLayout(false);
            bestMatchPanel.ResumeLayout(false);
            topSearchPanel.ResumeLayout(false);
            topSearchPanel.PerformLayout();
            topSeachTable.ResumeLayout(false);
            topSearchFlowPanel.ResumeLayout(false);
            topSearchFlowPanel.PerformLayout();
            otherResult0.ResumeLayout(false);
            otherResult0.PerformLayout();
            otherTable0.ResumeLayout(false);
            otherTable0.PerformLayout();
            otherResult1.ResumeLayout(false);
            otherResult1.PerformLayout();
            otherTable1.ResumeLayout(false);
            otherTable1.PerformLayout();
            otherResult2.ResumeLayout(false);
            otherResult2.PerformLayout();
            otherTable2.ResumeLayout(false);
            otherTable2.PerformLayout();
            otherResult3.ResumeLayout(false);
            otherResult3.PerformLayout();
            otherTable3.ResumeLayout(false);
            otherTable3.PerformLayout();
            otherResult4.ResumeLayout(false);
            otherResult4.PerformLayout();
            otherTable4.ResumeLayout(false);
            otherTable4.PerformLayout();
            otherResult5.ResumeLayout(false);
            otherResult5.PerformLayout();
            otherTable5.ResumeLayout(false);
            otherTable5.PerformLayout();
            otherResult6.ResumeLayout(false);
            otherResult6.PerformLayout();
            otherTable6.ResumeLayout(false);
            otherTable6.PerformLayout();
            otherResult7.ResumeLayout(false);
            otherResult7.PerformLayout();
            otherTable7.ResumeLayout(false);
            otherTable7.PerformLayout();
            otherResult8.ResumeLayout(false);
            otherResult8.PerformLayout();
            otherTable8.ResumeLayout(false);
            otherTable8.PerformLayout();
            otherResult9.ResumeLayout(false);
            otherResult9.PerformLayout();
            otherTable9.ResumeLayout(false);
            otherTable9.PerformLayout();
            favoritePanel.ResumeLayout(false);
            favoritePanel.PerformLayout();
            favFlowPanel.ResumeLayout(false);
            favTableHead.ResumeLayout(false);
            favTableHead.PerformLayout();
            categoriesPanel.ResumeLayout(false);
            categoriesPanel.PerformLayout();
            mainCategoryPanel.ResumeLayout(false);
            authormainFlowPanel.ResumeLayout(false);
            otherCategoriesPanel.ResumeLayout(false);
            historyPanel.ResumeLayout(false);
            historyPanel.PerformLayout();
            historyFlowPanel.ResumeLayout(false);
            bestBookPanel.ResumeLayout(false);
            bestBookPanel.PerformLayout();
            bestBookFlowPanel.ResumeLayout(false);
            bestBookElement0.ResumeLayout(false);
            bestBookElement0.PerformLayout();
            bestBookTable0.ResumeLayout(false);
            bestBookTable0.PerformLayout();
            bestBookLabel0.ResumeLayout(false);
            bestBookLabel0.PerformLayout();
            bestBookElement1.ResumeLayout(false);
            bestBookElement1.PerformLayout();
            bestBookTable1.ResumeLayout(false);
            bestBookLabel1.ResumeLayout(false);
            bestBookLabel1.PerformLayout();
            bestBookElement2.ResumeLayout(false);
            bestBookElement2.PerformLayout();
            bestBookTable2.ResumeLayout(false);
            bestBookLabel2.ResumeLayout(false);
            bestBookLabel2.PerformLayout();
            bestBookElement3.ResumeLayout(false);
            bestBookElement3.PerformLayout();
            bestBookTable3.ResumeLayout(false);
            bestBookLabel3.ResumeLayout(false);
            bestBookLabel3.PerformLayout();
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

        private void HelloElementTitle2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FlowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            SetStyle(ControlStyles.UserMouse | ControlStyles.Selectable, true);
        }


        #endregion


        private TableLayoutPanel containerMainTableLayout;
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
        private FlowLayoutPanel searchFlowPanel;
        private FlowLayoutPanel searchPanel;
        private TableLayoutPanel searchLayoutTable;
        private Label searchImg;
        private FlowLayoutPanel bestMatchPanel;
        private Label bestMatchLabel;
        private FlowLayoutPanel flowLayoutPanel61;
        private ContextMenuStrip contextMenuStrip1;
        private FlowLayoutPanel contentContainer;
        private Label contentImg;
        private Label contentTitle;
        private Label authorLabel;
        private Label publisherLabel;
        private Label aboutAuthor;
        private Label authorDesLabel;
        private Label categoryLabel;
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
        private ToolStripButton close;
        private ToolStripButton maximize;
        private ToolStripButton minimize;
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
        private FlowLayoutPanel helloFlow1;
        private Label helloAuthor1;
        private FlowLayoutPanel helloFlow2;
        private Label helloAuthor2;
        private FlowLayoutPanel helloFlow3;
        private Label helloAuthor3;
        private GradientPanel recommentElement0;
        private TableLayoutPanel recommentTable0;
        private Label recommentImg0;
        private FlowLayoutPanel recommentFlowPanel0;
        private Label recommentTitle0;
        private Label recommentAuthor0;
        private GradientPanel recommentElement1;
        private TableLayoutPanel tableLayoutPanel8;
        private Label recommentImg1;
        private FlowLayoutPanel recommentFlowPanel1;
        private Label recommentTitle1;
        private Label recommentAuthor1;
        private GradientPanel recommentElement2;
        private TableLayoutPanel recommentTable2;
        private Label recommentImg2;
        private FlowLayoutPanel recommentFlowLabel2;
        private Label recommentTitle2;
        private Label recommentAuthor2;
        private GradientPanel recommentElement3;
        private TableLayoutPanel recommentTable3;
        private Label recommentImg3;
        private FlowLayoutPanel recommentFlowLabel3;
        private Label recommentTitle3;
        private Label recommentAuthor3;
        private Label contentYear;
        private GradientPanel topSearchPanel;
        private TableLayoutPanel topSeachTable;
        private Label topSearchImg;
        private FlowLayoutPanel topSearchFlowPanel;
        private Label topSearchTitle;
        private Label topSearchAuthor;
        private FlowLayoutPanel favoritePanel;
        private FlowLayoutPanel favFlowPanel;
        private Label favoriteLabel;
        private FlowLayoutPanel categoriesPanel;
        private FlowLayoutPanel mainCategoryPanel;
        private Label categoryMainLabel;
        private FlowLayoutPanel historyPanel;
        private FlowLayoutPanel historyFlowPanel;
        private Label historyLabel;
        private Label forward;
        private Label bookmark;
        private Winforms.RJButton user;
        private Label userLabel;
        private FlowLayoutPanel bestBookPanel;
        private FlowLayoutPanel bestBookFlowPanel;
        private Label bestBookLabel;
        private GradientPanel bestBookElement0;
        private TableLayoutPanel bestBookTable0;
        private Label bestBookImg0;
        private FlowLayoutPanel bestBookLabel0;
        private Label bestBookTitle0;
        private Label bestBookAuthor0;
        private GradientPanel bestBookElement1;
        private TableLayoutPanel bestBookTable1;
        private Label bestBookImg1;
        private FlowLayoutPanel bestBookLabel1;
        private Label bestBookTitle1;
        private Label bestBookAuthor1;
        private GradientPanel bestBookElement2;
        private TableLayoutPanel bestBookTable2;
        private Label bestBookImg2;
        private FlowLayoutPanel bestBookLabel2;
        private Label bestBookTitle2;
        private Label bestBookAuthor2;
        private GradientPanel bestBookElement3;
        private TableLayoutPanel bestBookTable3;
        private Label bestBookImg3;
        private FlowLayoutPanel bestBookLabel3;
        private Label bestBookTitle3;
        private Label bestBookAuthor3;
        private GradientPanel otherResult0;
        private TableLayoutPanel otherTable0;
        private Label otherImg0;
        private Label otherTitle0;
        private GradientPanel otherResult1;
        private TableLayoutPanel otherTable1;
        private Label otherTitle1;
        private Label otherImg1;
        private GradientPanel otherResult2;
        private TableLayoutPanel otherTable2;
        private Label otherTitle2;
        private Label otherImg2;
        private GradientPanel otherResult3;
        private TableLayoutPanel otherTable3;
        private Label otherTitle3;
        private Label otherImg3;
        private GradientPanel otherResult4;
        private TableLayoutPanel otherTable4;
        private Label otherTitle4;
        private Label otherImg4;
        private GradientPanel otherResult5;
        private TableLayoutPanel otherTable5;
        private Label otherTitle5;
        private Label otherImg5;
        private GradientPanel otherResult6;
        private TableLayoutPanel otherTable6;
        private Label otherTitle6;
        private Label otherImg6;
        private GradientPanel otherResult7;
        private TableLayoutPanel otherTable7;
        private Label otherTitle7;
        private Label otherImg7;
        private GradientPanel otherResult8;
        private TableLayoutPanel otherTable8;
        private Label otherTitle8;
        private Label otherImg8;
        private GradientPanel otherResult9;
        private TableLayoutPanel otherTable9;
        private Label otherTitle9;
        private Label otherImg9;
        private GradientPanel category0;
        private TableLayoutPanel categoryTable0;
        private Label categoryImg0;
        private FlowLayoutPanel categoryFlowPanel0;
        private Label categoryTitle0;
        private Label categoryAuthor0;
        private TableLayoutPanel favTableHead;
        private Label favBookLabel;
        private Label favRankLabel;
        private Label scoreLabel;
        private Label favPublisherLabel;
        private FlowLayoutPanel authormainFlowPanel;
        private Label authorMainLabel;
        private FlowLayoutPanel otherCategoriesPanel;
        private Label otherCategoryLabel;
    }
}