
namespace Server
{
    partial class frmServer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbClientList = new System.Windows.Forms.ToolStripStatusLabel();
            this.DBList = new System.Windows.Forms.ToolStripDropDownButton();
            this.MoistTable = new System.Windows.Forms.ToolStripMenuItem();
            this.TempTable = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.tabServer = new MetroFramework.Controls.MetroTabPage();
            this.btnServerStart = new MetroFramework.Controls.MetroButton();
            this.tbServerLog = new System.Windows.Forms.RichTextBox();
            this.tbAndroidServerPort = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPiServerPort = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTnM = new MetroFramework.Controls.MetroTabPage();
            this.lbTempTarget = new System.Windows.Forms.Label();
            this.lbMoistTarget = new System.Windows.Forms.Label();
            this.lbTempNow = new System.Windows.Forms.Label();
            this.lbStatusTarget = new System.Windows.Forms.Label();
            this.lbStatusNow = new System.Windows.Forms.Label();
            this.lbMoistNow = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabSettings = new MetroFramework.Controls.MetroTabPage();
            this.btnPiServerOff = new MetroFramework.Controls.MetroTile();
            this.btnDebug = new MetroFramework.Controls.MetroTile();
            this.btnAndroid = new MetroFramework.Controls.MetroTile();
            this.btnAndServerOff = new MetroFramework.Controls.MetroTile();
            this.btnAppServerStart = new MetroFramework.Controls.MetroTile();
            this.btnPiServerStart = new MetroFramework.Controls.MetroTile();
            this.tbServer = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabTnM.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel1,
            this.sbClientList,
            this.DBList});
            this.statusStrip1.Location = new System.Drawing.Point(20, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(918, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbLabel1
            // 
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(58, 17);
            this.sbLabel1.Text = "RemoteIP";
            // 
            // sbClientList
            // 
            this.sbClientList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbClientList.Image = ((System.Drawing.Image)(resources.GetObject("sbClientList.Image")));
            this.sbClientList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbClientList.Name = "sbClientList";
            this.sbClientList.Size = new System.Drawing.Size(67, 17);
            this.sbClientList.Text = "클라이언트";
            // 
            // DBList
            // 
            this.DBList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoistTable,
            this.TempTable});
            this.DBList.Image = ((System.Drawing.Image)(resources.GetObject("DBList.Image")));
            this.DBList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DBList.Name = "DBList";
            this.DBList.Size = new System.Drawing.Size(80, 20);
            this.DBList.Text = "DB 목록";
            // 
            // MoistTable
            // 
            this.MoistTable.Name = "MoistTable";
            this.MoistTable.Size = new System.Drawing.Size(98, 22);
            this.MoistTable.Text = "습도";
            this.MoistTable.Click += new System.EventHandler(this.MoistTable_Click);
            // 
            // TempTable
            // 
            this.TempTable.Name = "TempTable";
            this.TempTable.Size = new System.Drawing.Size(98, 22);
            this.TempTable.Text = "온도";
            this.TempTable.Click += new System.EventHandler(this.TempTable_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMenu);
            this.splitContainer1.Size = new System.Drawing.Size(918, 448);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.tabServer);
            this.tabMenu.Controls.Add(this.tabTnM);
            this.tabMenu.Controls.Add(this.tabSettings);
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(918, 172);
            this.tabMenu.Style = MetroFramework.MetroColorStyle.Green;
            this.tabMenu.TabIndex = 0;
            this.tabMenu.UseSelectable = true;
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.btnServerStart);
            this.tabServer.Controls.Add(this.tbServerLog);
            this.tabServer.Controls.Add(this.tbAndroidServerPort);
            this.tabServer.Controls.Add(this.label2);
            this.tabServer.Controls.Add(this.tbPiServerPort);
            this.tabServer.Controls.Add(this.label1);
            this.tabServer.HorizontalScrollbarBarColor = true;
            this.tabServer.HorizontalScrollbarHighlightOnWheel = false;
            this.tabServer.HorizontalScrollbarSize = 10;
            this.tabServer.Location = new System.Drawing.Point(4, 38);
            this.tabServer.Name = "tabServer";
            this.tabServer.Size = new System.Drawing.Size(910, 130);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = "서버";
            this.tabServer.VerticalScrollbarBarColor = true;
            this.tabServer.VerticalScrollbarHighlightOnWheel = false;
            this.tabServer.VerticalScrollbarSize = 10;
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(14, 92);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(151, 31);
            this.btnServerStart.TabIndex = 4;
            this.btnServerStart.Text = "서버 시작";
            this.btnServerStart.UseSelectable = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // tbServerLog
            // 
            this.tbServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerLog.BackColor = System.Drawing.Color.White;
            this.tbServerLog.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServerLog.Location = new System.Drawing.Point(179, 3);
            this.tbServerLog.Name = "tbServerLog";
            this.tbServerLog.ReadOnly = true;
            this.tbServerLog.Size = new System.Drawing.Size(731, 137);
            this.tbServerLog.TabIndex = 2;
            this.tbServerLog.Text = "";
            // 
            // tbAndroidServerPort
            // 
            this.tbAndroidServerPort.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAndroidServerPort.Location = new System.Drawing.Point(85, 52);
            this.tbAndroidServerPort.Multiline = false;
            this.tbAndroidServerPort.Name = "tbAndroidServerPort";
            this.tbAndroidServerPort.ReadOnly = true;
            this.tbAndroidServerPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbAndroidServerPort.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbAndroidServerPort.Size = new System.Drawing.Size(81, 25);
            this.tbAndroidServerPort.TabIndex = 2;
            this.tbAndroidServerPort.Text = "9000";
            this.tbAndroidServerPort.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "App Port";
            // 
            // tbPiServerPort
            // 
            this.tbPiServerPort.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPiServerPort.Location = new System.Drawing.Point(85, 21);
            this.tbPiServerPort.Multiline = false;
            this.tbPiServerPort.Name = "tbPiServerPort";
            this.tbPiServerPort.ReadOnly = true;
            this.tbPiServerPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbPiServerPort.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbPiServerPort.Size = new System.Drawing.Size(81, 25);
            this.tbPiServerPort.TabIndex = 2;
            this.tbPiServerPort.Text = "9090";
            this.tbPiServerPort.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pi Port";
            // 
            // tabTnM
            // 
            this.tabTnM.Controls.Add(this.lbTempTarget);
            this.tabTnM.Controls.Add(this.lbMoistTarget);
            this.tabTnM.Controls.Add(this.lbTempNow);
            this.tabTnM.Controls.Add(this.lbStatusTarget);
            this.tabTnM.Controls.Add(this.lbStatusNow);
            this.tabTnM.Controls.Add(this.lbMoistNow);
            this.tabTnM.Controls.Add(this.label7);
            this.tabTnM.Controls.Add(this.label6);
            this.tabTnM.HorizontalScrollbarBarColor = true;
            this.tabTnM.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTnM.HorizontalScrollbarSize = 10;
            this.tabTnM.Location = new System.Drawing.Point(4, 38);
            this.tabTnM.Name = "tabTnM";
            this.tabTnM.Size = new System.Drawing.Size(910, 130);
            this.tabTnM.TabIndex = 1;
            this.tabTnM.Text = "온습도";
            this.tabTnM.VerticalScrollbarBarColor = true;
            this.tabTnM.VerticalScrollbarHighlightOnWheel = false;
            this.tabTnM.VerticalScrollbarSize = 10;
            // 
            // lbTempTarget
            // 
            this.lbTempTarget.AutoSize = true;
            this.lbTempTarget.BackColor = System.Drawing.Color.White;
            this.lbTempTarget.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbTempTarget.Location = new System.Drawing.Point(297, 63);
            this.lbTempTarget.Name = "lbTempTarget";
            this.lbTempTarget.Size = new System.Drawing.Size(84, 28);
            this.lbTempTarget.TabIndex = 3;
            this.lbTempTarget.Text = "--------";
            this.lbTempTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMoistTarget
            // 
            this.lbMoistTarget.AutoSize = true;
            this.lbMoistTarget.BackColor = System.Drawing.Color.White;
            this.lbMoistTarget.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoistTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbMoistTarget.Location = new System.Drawing.Point(735, 63);
            this.lbMoistTarget.Name = "lbMoistTarget";
            this.lbMoistTarget.Size = new System.Drawing.Size(66, 28);
            this.lbMoistTarget.TabIndex = 3;
            this.lbMoistTarget.Text = "------";
            this.lbMoistTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTempNow
            // 
            this.lbTempNow.AutoSize = true;
            this.lbTempNow.BackColor = System.Drawing.Color.White;
            this.lbTempNow.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbTempNow.Location = new System.Drawing.Point(93, 63);
            this.lbTempNow.Name = "lbTempNow";
            this.lbTempNow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbTempNow.Size = new System.Drawing.Size(84, 28);
            this.lbTempNow.TabIndex = 3;
            this.lbTempNow.Text = "--------";
            this.lbTempNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatusTarget
            // 
            this.lbStatusTarget.AutoSize = true;
            this.lbStatusTarget.BackColor = System.Drawing.Color.White;
            this.lbStatusTarget.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStatusTarget.Location = new System.Drawing.Point(298, 36);
            this.lbStatusTarget.Name = "lbStatusTarget";
            this.lbStatusTarget.Size = new System.Drawing.Size(73, 19);
            this.lbStatusTarget.TabIndex = 3;
            this.lbStatusTarget.Text = "설정 온도";
            this.lbStatusTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatusNow
            // 
            this.lbStatusNow.AutoSize = true;
            this.lbStatusNow.BackColor = System.Drawing.Color.White;
            this.lbStatusNow.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStatusNow.Location = new System.Drawing.Point(95, 36);
            this.lbStatusNow.Name = "lbStatusNow";
            this.lbStatusNow.Size = new System.Drawing.Size(73, 19);
            this.lbStatusNow.TabIndex = 3;
            this.lbStatusNow.Text = "현재 온도";
            this.lbStatusNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMoistNow
            // 
            this.lbMoistNow.AutoSize = true;
            this.lbMoistNow.BackColor = System.Drawing.Color.White;
            this.lbMoistNow.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoistNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbMoistNow.Location = new System.Drawing.Point(532, 61);
            this.lbMoistNow.Name = "lbMoistNow";
            this.lbMoistNow.Size = new System.Drawing.Size(66, 28);
            this.lbMoistNow.TabIndex = 3;
            this.lbMoistNow.Text = "------";
            this.lbMoistNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(528, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "현재 습도";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(731, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "설정 습도";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnPiServerOff);
            this.tabSettings.Controls.Add(this.btnDebug);
            this.tabSettings.Controls.Add(this.btnAndroid);
            this.tabSettings.Controls.Add(this.btnAndServerOff);
            this.tabSettings.Controls.Add(this.btnAppServerStart);
            this.tabSettings.Controls.Add(this.btnPiServerStart);
            this.tabSettings.HorizontalScrollbarBarColor = true;
            this.tabSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.tabSettings.HorizontalScrollbarSize = 10;
            this.tabSettings.Location = new System.Drawing.Point(4, 38);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(910, 130);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "설정";
            this.tabSettings.VerticalScrollbarBarColor = true;
            this.tabSettings.VerticalScrollbarHighlightOnWheel = false;
            this.tabSettings.VerticalScrollbarSize = 10;
            // 
            // btnPiServerOff
            // 
            this.btnPiServerOff.ActiveControl = null;
            this.btnPiServerOff.Location = new System.Drawing.Point(166, 12);
            this.btnPiServerOff.Name = "btnPiServerOff";
            this.btnPiServerOff.Size = new System.Drawing.Size(157, 112);
            this.btnPiServerOff.Style = MetroFramework.MetroColorStyle.Green;
            this.btnPiServerOff.TabIndex = 5;
            this.btnPiServerOff.Text = "파이 서버 연결 끊기";
            this.btnPiServerOff.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPiServerOff.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnPiServerOff.UseSelectable = true;
            this.btnPiServerOff.UseTileImage = true;
            this.btnPiServerOff.Click += new System.EventHandler(this.btnPiServerOff_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.ActiveControl = null;
            this.btnDebug.Location = new System.Drawing.Point(799, 12);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(110, 112);
            this.btnDebug.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDebug.TabIndex = 5;
            this.btnDebug.Text = "디버깅";
            this.btnDebug.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDebug.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnDebug.UseSelectable = true;
            this.btnDebug.UseTileImage = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnAndroid
            // 
            this.btnAndroid.ActiveControl = null;
            this.btnAndroid.Location = new System.Drawing.Point(656, 12);
            this.btnAndroid.Name = "btnAndroid";
            this.btnAndroid.Size = new System.Drawing.Size(135, 112);
            this.btnAndroid.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAndroid.TabIndex = 5;
            this.btnAndroid.Text = "앱 서버 연결 확인";
            this.btnAndroid.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAndroid.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnAndroid.UseSelectable = true;
            this.btnAndroid.UseTileImage = true;
            this.btnAndroid.Click += new System.EventHandler(this.btnAndroid_Click);
            // 
            // btnAndServerOff
            // 
            this.btnAndServerOff.ActiveControl = null;
            this.btnAndServerOff.Location = new System.Drawing.Point(492, 12);
            this.btnAndServerOff.Name = "btnAndServerOff";
            this.btnAndServerOff.Size = new System.Drawing.Size(157, 112);
            this.btnAndServerOff.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAndServerOff.TabIndex = 5;
            this.btnAndServerOff.Text = "앱 서버 연결 끊기";
            this.btnAndServerOff.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAndServerOff.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnAndServerOff.UseSelectable = true;
            this.btnAndServerOff.UseTileImage = true;
            this.btnAndServerOff.Click += new System.EventHandler(this.btnAndServerOff_Click);
            // 
            // btnAppServerStart
            // 
            this.btnAppServerStart.ActiveControl = null;
            this.btnAppServerStart.Location = new System.Drawing.Point(329, 12);
            this.btnAppServerStart.Name = "btnAppServerStart";
            this.btnAppServerStart.Size = new System.Drawing.Size(157, 112);
            this.btnAppServerStart.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAppServerStart.TabIndex = 5;
            this.btnAppServerStart.Text = "앱 서버 연결";
            this.btnAppServerStart.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAppServerStart.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnAppServerStart.UseSelectable = true;
            this.btnAppServerStart.UseTileImage = true;
            this.btnAppServerStart.Click += new System.EventHandler(this.btnAppServerStart_Click);
            // 
            // btnPiServerStart
            // 
            this.btnPiServerStart.AccessibleDescription = "";
            this.btnPiServerStart.ActiveControl = null;
            this.btnPiServerStart.Location = new System.Drawing.Point(3, 12);
            this.btnPiServerStart.Name = "btnPiServerStart";
            this.btnPiServerStart.Size = new System.Drawing.Size(157, 112);
            this.btnPiServerStart.Style = MetroFramework.MetroColorStyle.Green;
            this.btnPiServerStart.TabIndex = 5;
            this.btnPiServerStart.Text = "파이 서버 연결";
            this.btnPiServerStart.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPiServerStart.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnPiServerStart.UseSelectable = true;
            this.btnPiServerStart.UseTileImage = true;
            this.btnPiServerStart.Click += new System.EventHandler(this.btnPiServerStart_Click);
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.BackColor = System.Drawing.Color.White;
            this.tbServer.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServer.Location = new System.Drawing.Point(20, 237);
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.Size = new System.Drawing.Size(918, 270);
            this.tbServer.TabIndex = 2;
            this.tbServer.Text = "";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 550);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "frmServer";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "스마트 사육장 서버";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.tabTnM.ResumeLayout(false);
            this.tabTnM.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ToolStripDropDownButton DBList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox tbServer;
        private System.Windows.Forms.ToolStripMenuItem MoistTable;
        private System.Windows.Forms.ToolStripMenuItem TempTable;
        private System.Windows.Forms.RichTextBox tbServerLog;
        private System.Windows.Forms.Label lbStatusNow;
        private System.Windows.Forms.Label lbStatusTarget;
        private System.Windows.Forms.Label lbTempNow;
        private System.Windows.Forms.Label lbMoistNow;
        private System.Windows.Forms.Label lbTempTarget;
        private System.Windows.Forms.Label lbMoistTarget;
        private MetroFramework.Controls.MetroTabControl tabMenu;
        private MetroFramework.Controls.MetroTabPage tabServer;
        private MetroFramework.Controls.MetroTabPage tabTnM;
        private MetroFramework.Controls.MetroTabPage tabSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox tbPiServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel sbClientList;
        private System.Windows.Forms.RichTextBox tbAndroidServerPort;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton btnServerStart;
        private MetroFramework.Controls.MetroTile btnPiServerStart;
        private MetroFramework.Controls.MetroTile btnPiServerOff;
        private MetroFramework.Controls.MetroTile btnAppServerStart;
        private MetroFramework.Controls.MetroTile btnDebug;
        private MetroFramework.Controls.MetroTile btnAndroid;
        private MetroFramework.Controls.MetroTile btnAndServerOff;
    }
}

