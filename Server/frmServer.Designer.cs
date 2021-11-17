
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuSendServerText = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuRunCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.tbServerLog = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbServer);
            this.splitContainer1.Size = new System.Drawing.Size(867, 424);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServer.Location = new System.Drawing.Point(0, 2);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(867, 322);
            this.tbServer.TabIndex = 2;
            this.tbServer.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnServerStart);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbServerPort);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 90);
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
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuRunCmd});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(126, 26);
            // 
            // pmnuRunCmd
            // 
            this.pmnuRunCmd.Name = "pmnuRunCmd";
            this.pmnuRunCmd.Size = new System.Drawing.Size(125, 22);
            this.pmnuRunCmd.Text = "Run Cmd";
            // 
            // tbServerLog
            // 
            this.tbServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerLog.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbServerLog.Location = new System.Drawing.Point(-1, 0);
            this.tbServerLog.Name = "tbServerLog";
            this.tbServerLog.ReadOnly = true;
            this.tbServerLog.Size = new System.Drawing.Size(687, 96);
            this.tbServerLog.TabIndex = 2;
            this.tbServerLog.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbServerLog);
            this.splitContainer2.Size = new System.Drawing.Size(867, 96);
            this.splitContainer2.SplitterDistance = 177;
            this.splitContainer2.TabIndex = 0;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 550);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServer";
            this.Text = "도오오오오오마뱀";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.ToolStripMenuItem MoistTable;
        private System.Windows.Forms.ToolStripMenuItem TempTable;
        private System.Windows.Forms.ToolStripDropDownButton sbClientList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pmnuSendServerText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem pmnuRunCmd;
        private System.Windows.Forms.RichTextBox tbServerLog;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

