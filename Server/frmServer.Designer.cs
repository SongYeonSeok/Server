
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbClientList = new System.Windows.Forms.ToolStripDropDownButton();
            this.DBList = new System.Windows.Forms.ToolStripDropDownButton();
            this.MoistTable = new System.Windows.Forms.ToolStripMenuItem();
            this.TempTable = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbServer = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbGreenStatus = new System.Windows.Forms.TextBox();
            this.cbGreenOff = new System.Windows.Forms.CheckBox();
            this.cbGreenOn = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbYellowOff = new System.Windows.Forms.CheckBox();
            this.cbYellowOn = new System.Windows.Forms.CheckBox();
            this.tbYellowStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbRedOff = new System.Windows.Forms.CheckBox();
            this.cbRedOn = new System.Windows.Forms.CheckBox();
            this.tbRedStatus = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuSendServerText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(93, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel1,
            this.sbClientList,
            this.DBList});
            this.statusStrip1.Location = new System.Drawing.Point(20, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
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
            this.sbClientList.Size = new System.Drawing.Size(81, 20);
            this.sbClientList.Text = "sbClientList";
            this.sbClientList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbClientList_DropDownItemClicked);
            // 
            // DBList
            // 
            this.DBList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoistTable,
            this.TempTable});
            this.DBList.Image = ((System.Drawing.Image)(resources.GetObject("DBList.Image")));
            this.DBList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DBList.Name = "DBList";
            this.DBList.Size = new System.Drawing.Size(70, 20);
            this.DBList.Text = "DBList";
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
            this.splitContainer1.Location = new System.Drawing.Point(20, 84);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbServer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(867, 424);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServer.Location = new System.Drawing.Point(0, 0);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(632, 421);
            this.tbServer.TabIndex = 2;
            this.tbServer.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbGreenStatus);
            this.groupBox2.Controls.Add(this.cbGreenOff);
            this.groupBox2.Controls.Add(this.cbGreenOn);
            this.groupBox2.Location = new System.Drawing.Point(8, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 68);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Green LED";
            // 
            // tbGreenStatus
            // 
            this.tbGreenStatus.Location = new System.Drawing.Point(10, 27);
            this.tbGreenStatus.Name = "tbGreenStatus";
            this.tbGreenStatus.ReadOnly = true;
            this.tbGreenStatus.Size = new System.Drawing.Size(73, 21);
            this.tbGreenStatus.TabIndex = 4;
            this.tbGreenStatus.Text = "waiting...";
            // 
            // cbGreenOff
            // 
            this.cbGreenOff.AutoSize = true;
            this.cbGreenOff.Location = new System.Drawing.Point(95, 42);
            this.cbGreenOff.Name = "cbGreenOff";
            this.cbGreenOff.Size = new System.Drawing.Size(77, 16);
            this.cbGreenOff.TabIndex = 9;
            this.cbGreenOff.Text = "Lights Off";
            this.cbGreenOff.UseVisualStyleBackColor = true;
            this.cbGreenOff.CheckedChanged += new System.EventHandler(this.cbGreenOff_CheckedChanged);
            // 
            // cbGreenOn
            // 
            this.cbGreenOn.AutoSize = true;
            this.cbGreenOn.Location = new System.Drawing.Point(95, 18);
            this.cbGreenOn.Name = "cbGreenOn";
            this.cbGreenOn.Size = new System.Drawing.Size(78, 16);
            this.cbGreenOn.TabIndex = 9;
            this.cbGreenOn.Text = "Lights On";
            this.cbGreenOn.UseVisualStyleBackColor = true;
            this.cbGreenOn.CheckedChanged += new System.EventHandler(this.cbGreenOn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbYellowOff);
            this.groupBox3.Controls.Add(this.cbYellowOn);
            this.groupBox3.Controls.Add(this.tbYellowStatus);
            this.groupBox3.Location = new System.Drawing.Point(7, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 72);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Yellow LED";
            // 
            // cbYellowOff
            // 
            this.cbYellowOff.AutoSize = true;
            this.cbYellowOff.Location = new System.Drawing.Point(97, 42);
            this.cbYellowOff.Name = "cbYellowOff";
            this.cbYellowOff.Size = new System.Drawing.Size(77, 16);
            this.cbYellowOff.TabIndex = 9;
            this.cbYellowOff.Text = "Lights Off";
            this.cbYellowOff.UseVisualStyleBackColor = true;
            this.cbYellowOff.CheckedChanged += new System.EventHandler(this.cbYellowOff_CheckedChanged);
            // 
            // cbYellowOn
            // 
            this.cbYellowOn.AutoSize = true;
            this.cbYellowOn.Location = new System.Drawing.Point(98, 20);
            this.cbYellowOn.Name = "cbYellowOn";
            this.cbYellowOn.Size = new System.Drawing.Size(78, 16);
            this.cbYellowOn.TabIndex = 9;
            this.cbYellowOn.Text = "Lights On";
            this.cbYellowOn.UseVisualStyleBackColor = true;
            this.cbYellowOn.CheckedChanged += new System.EventHandler(this.cbYellowOn_CheckedChanged);
            // 
            // tbYellowStatus
            // 
            this.tbYellowStatus.Location = new System.Drawing.Point(12, 29);
            this.tbYellowStatus.Name = "tbYellowStatus";
            this.tbYellowStatus.ReadOnly = true;
            this.tbYellowStatus.Size = new System.Drawing.Size(73, 21);
            this.tbYellowStatus.TabIndex = 4;
            this.tbYellowStatus.Text = "waiting...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRedOff);
            this.groupBox1.Controls.Add(this.cbRedOn);
            this.groupBox1.Controls.Add(this.tbRedStatus);
            this.groupBox1.Location = new System.Drawing.Point(6, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 67);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red LED";
            // 
            // cbRedOff
            // 
            this.cbRedOff.AutoSize = true;
            this.cbRedOff.Location = new System.Drawing.Point(98, 42);
            this.cbRedOff.Name = "cbRedOff";
            this.cbRedOff.Size = new System.Drawing.Size(77, 16);
            this.cbRedOff.TabIndex = 9;
            this.cbRedOff.Text = "Lights Off";
            this.cbRedOff.UseVisualStyleBackColor = true;
            this.cbRedOff.CheckedChanged += new System.EventHandler(this.cbRedOff_CheckedChanged);
            // 
            // cbRedOn
            // 
            this.cbRedOn.AutoSize = true;
            this.cbRedOn.Location = new System.Drawing.Point(98, 20);
            this.cbRedOn.Name = "cbRedOn";
            this.cbRedOn.Size = new System.Drawing.Size(78, 16);
            this.cbRedOn.TabIndex = 9;
            this.cbRedOn.Text = "Lights On";
            this.cbRedOn.UseVisualStyleBackColor = true;
            this.cbRedOn.CheckedChanged += new System.EventHandler(this.cbRedOn_CheckedChanged);
            // 
            // tbRedStatus
            // 
            this.tbRedStatus.Location = new System.Drawing.Point(12, 28);
            this.tbRedStatus.Name = "tbRedStatus";
            this.tbRedStatus.ReadOnly = true;
            this.tbRedStatus.Size = new System.Drawing.Size(74, 21);
            this.tbRedStatus.TabIndex = 4;
            this.tbRedStatus.Text = "waiting...";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnServerStart);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbServerPort);
            this.groupBox4.Location = new System.Drawing.Point(27, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 87);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "서버";
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(15, 47);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(143, 23);
            this.btnServerStart.TabIndex = 2;
            this.btnServerStart.Text = "Server Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Port";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(86, 20);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(72, 21);
            this.tbServerPort.TabIndex = 0;
            this.tbServerPort.Text = "9000";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuSendServerText});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 26);
            // 
            // pmnuSendServerText
            // 
            this.pmnuSendServerText.Name = "pmnuSendServerText";
            this.pmnuSendServerText.Size = new System.Drawing.Size(127, 22);
            this.pmnuSendServerText.Text = "Send Text";
            this.pmnuSendServerText.Click += new System.EventHandler(this.pmnuSendServerText_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 550);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServer";
            this.Text = "LED Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ToolStripDropDownButton DBList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox tbServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbGreenStatus;
        private System.Windows.Forms.CheckBox cbGreenOff;
        private System.Windows.Forms.CheckBox cbGreenOn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbYellowOff;
        private System.Windows.Forms.CheckBox cbYellowOn;
        private System.Windows.Forms.TextBox tbYellowStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbRedOff;
        private System.Windows.Forms.CheckBox cbRedOn;
        private System.Windows.Forms.TextBox tbRedStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.ToolStripMenuItem MoistTable;
        private System.Windows.Forms.ToolStripMenuItem TempTable;
        private System.Windows.Forms.ToolStripDropDownButton sbClientList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pmnuSendServerText;
    }
}

