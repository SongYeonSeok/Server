
namespace Server
{
    partial class frmAlertSettings
    {
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMinTemp = new System.Windows.Forms.TextBox();
            this.tbMaxTemp = new System.Windows.Forms.TextBox();
            this.tbMinMoist = new System.Windows.Forms.TextBox();
            this.tbMaxMoist = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(38, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 33);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(168, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "최소 유지 온도(℃)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "최대 유지 온도(℃)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "최소 유지 습도(%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "최대 유지 습도(%)";
            // 
            // tbMinTemp
            // 
            this.tbMinTemp.Location = new System.Drawing.Point(158, 115);
            this.tbMinTemp.Name = "tbMinTemp";
            this.tbMinTemp.Size = new System.Drawing.Size(96, 21);
            this.tbMinTemp.TabIndex = 3;
            // 
            // tbMaxTemp
            // 
            this.tbMaxTemp.Location = new System.Drawing.Point(158, 148);
            this.tbMaxTemp.Name = "tbMaxTemp";
            this.tbMaxTemp.Size = new System.Drawing.Size(96, 21);
            this.tbMaxTemp.TabIndex = 3;
            // 
            // tbMinMoist
            // 
            this.tbMinMoist.Location = new System.Drawing.Point(158, 180);
            this.tbMinMoist.Name = "tbMinMoist";
            this.tbMinMoist.Size = new System.Drawing.Size(96, 21);
            this.tbMinMoist.TabIndex = 3;
            // 
            // tbMaxMoist
            // 
            this.tbMaxMoist.Location = new System.Drawing.Point(158, 210);
            this.tbMaxMoist.Name = "tbMaxMoist";
            this.tbMaxMoist.Size = new System.Drawing.Size(96, 21);
            this.tbMaxMoist.TabIndex = 3;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "기본값",
            "크레스티드 게코",
            "목도리도마뱀",
            "기타"});
            this.cbType.Location = new System.Drawing.Point(45, 72);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(208, 20);
            this.cbType.TabIndex = 4;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // frmAlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 317);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbMaxMoist);
            this.Controls.Add(this.tbMinMoist);
            this.Controls.Add(this.tbMaxTemp);
            this.Controls.Add(this.tbMinTemp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlertSettings";
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "온습도 설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbMinTemp;
        public System.Windows.Forms.TextBox tbMaxTemp;
        public System.Windows.Forms.TextBox tbMinMoist;
        public System.Windows.Forms.TextBox tbMaxMoist;
        private System.Windows.Forms.ComboBox cbType;
    }
}