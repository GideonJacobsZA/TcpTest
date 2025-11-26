namespace TcpTest
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAutoReplyWithCRCHeader = new System.Windows.Forms.CheckBox();
            this.cbBroadCastClientData = new System.Windows.Forms.CheckBox();
            this.cbAutoReplyWithCRC = new System.Windows.Forms.CheckBox();
            this.cbAutoReply = new System.Windows.Forms.CheckBox();
            this.btnSendToClient = new System.Windows.Forms.Button();
            this.tbDataToSend = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cbSendToServer = new System.Windows.Forms.CheckBox();
            this.pTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.pTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 368);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1714, 601);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(108, 96);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(314, 272);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(156, 20);
            this.tbAddress.TabIndex = 2;
            this.tbAddress.Text = "102.130.247.242";
            this.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(124, 70);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(70, 20);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "60522";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAutoReplyWithCRCHeader);
            this.groupBox1.Controls.Add(this.cbBroadCastClientData);
            this.groupBox1.Controls.Add(this.cbAutoReplyWithCRC);
            this.groupBox1.Controls.Add(this.cbAutoReply);
            this.groupBox1.Location = new System.Drawing.Point(258, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // cbAutoReplyWithCRCHeader
            // 
            this.cbAutoReplyWithCRCHeader.Checked = true;
            this.cbAutoReplyWithCRCHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoReplyWithCRCHeader.Location = new System.Drawing.Point(42, 72);
            this.cbAutoReplyWithCRCHeader.Name = "cbAutoReplyWithCRCHeader";
            this.cbAutoReplyWithCRCHeader.Size = new System.Drawing.Size(183, 17);
            this.cbAutoReplyWithCRCHeader.TabIndex = 10;
            this.cbAutoReplyWithCRCHeader.Text = "Auto Reply With CRC Header";
            this.cbAutoReplyWithCRCHeader.UseVisualStyleBackColor = true;
            this.cbAutoReplyWithCRCHeader.CheckedChanged += new System.EventHandler(this.cbAutoReplyWithCRCHeader_CheckedChanged);
            // 
            // cbBroadCastClientData
            // 
            this.cbBroadCastClientData.Checked = true;
            this.cbBroadCastClientData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBroadCastClientData.Location = new System.Drawing.Point(42, 96);
            this.cbBroadCastClientData.Name = "cbBroadCastClientData";
            this.cbBroadCastClientData.Size = new System.Drawing.Size(183, 26);
            this.cbBroadCastClientData.TabIndex = 9;
            this.cbBroadCastClientData.Text = "Broad Cast Client Data";
            this.cbBroadCastClientData.UseVisualStyleBackColor = true;
            this.cbBroadCastClientData.CheckedChanged += new System.EventHandler(this.cbBroadCastClientData_CheckedChanged);
            // 
            // cbAutoReplyWithCRC
            // 
            this.cbAutoReplyWithCRC.Checked = true;
            this.cbAutoReplyWithCRC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoReplyWithCRC.Location = new System.Drawing.Point(42, 49);
            this.cbAutoReplyWithCRC.Name = "cbAutoReplyWithCRC";
            this.cbAutoReplyWithCRC.Size = new System.Drawing.Size(183, 17);
            this.cbAutoReplyWithCRC.TabIndex = 1;
            this.cbAutoReplyWithCRC.Text = "Auto Reply With CRC";
            this.cbAutoReplyWithCRC.UseVisualStyleBackColor = true;
            this.cbAutoReplyWithCRC.CheckedChanged += new System.EventHandler(this.cbAutoReplyWithCRC_CheckedChanged);
            // 
            // cbAutoReply
            // 
            this.cbAutoReply.Checked = true;
            this.cbAutoReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoReply.Location = new System.Drawing.Point(42, 19);
            this.cbAutoReply.Name = "cbAutoReply";
            this.cbAutoReply.Size = new System.Drawing.Size(183, 24);
            this.cbAutoReply.TabIndex = 0;
            this.cbAutoReply.Text = "Auto Reply";
            this.cbAutoReply.UseVisualStyleBackColor = true;
            this.cbAutoReply.CheckedChanged += new System.EventHandler(this.cbAutoReply_CheckedChanged);
            // 
            // btnSendToClient
            // 
            this.btnSendToClient.Location = new System.Drawing.Point(314, 231);
            this.btnSendToClient.Name = "btnSendToClient";
            this.btnSendToClient.Size = new System.Drawing.Size(156, 35);
            this.btnSendToClient.TabIndex = 5;
            this.btnSendToClient.Text = "Send Data";
            this.btnSendToClient.UseVisualStyleBackColor = true;
            this.btnSendToClient.Click += new System.EventHandler(this.btnSendToClient_Click);
            // 
            // tbDataToSend
            // 
            this.tbDataToSend.Location = new System.Drawing.Point(98, 12);
            this.tbDataToSend.Multiline = true;
            this.tbDataToSend.Name = "tbDataToSend";
            this.tbDataToSend.Size = new System.Drawing.Size(578, 192);
            this.tbDataToSend.TabIndex = 6;
            this.tbDataToSend.Text = resources.GetString("tbDataToSend.Text");
            this.tbDataToSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDataToSend.TextChanged += new System.EventHandler(this.tbDataToSend_TextChanged);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(108, 137);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(101, 35);
            this.btnStopServer.TabIndex = 7;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(359, 298);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(70, 20);
            this.tbClientPort.TabIndex = 8;
            this.tbClientPort.Text = "60525";
            this.tbClientPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 368);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 601);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // cbSendToServer
            // 
            this.cbSendToServer.AutoSize = true;
            this.cbSendToServer.Location = new System.Drawing.Point(326, 324);
            this.cbSendToServer.Name = "cbSendToServer";
            this.cbSendToServer.Size = new System.Drawing.Size(135, 17);
            this.cbSendToServer.TabIndex = 10;
            this.cbSendToServer.Text = "Send To Server Clients";
            this.cbSendToServer.UseVisualStyleBackColor = true;
            this.cbSendToServer.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.panel1);
            this.pTop.Controls.Add(this.groupBox1);
            this.pTop.Controls.Add(this.tbPort);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1717, 368);
            this.pTop.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSendToServer);
            this.panel1.Controls.Add(this.tbDataToSend);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.tbClientPort);
            this.panel1.Controls.Add(this.btnSendToClient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(970, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 368);
            this.panel1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 969);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbAutoReplyWithCRC;
        private System.Windows.Forms.CheckBox cbAutoReply;
        private System.Windows.Forms.Button btnSendToClient;
        private System.Windows.Forms.TextBox tbDataToSend;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.CheckBox cbAutoReplyWithCRCHeader;
        private System.Windows.Forms.CheckBox cbBroadCastClientData;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox cbSendToServer;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Panel panel1;
    }
}

