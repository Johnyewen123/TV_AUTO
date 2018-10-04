namespace WindowsFormsApplication2
{
    partial class FormSocket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSocket));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Connect_SocketServer = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.Send_Socketserver = new System.Windows.Forms.Button();
            this.btn_toClientSocket = new System.Windows.Forms.Button();
            this.txb_toClientSocket = new System.Windows.Forms.TextBox();
            this.checkBox_IsSocketOpen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txB_IP = new System.Windows.Forms.TextBox();
            this.txB_SocketPort = new System.Windows.Forms.TextBox();
            this.btn_SaveSocketPara = new System.Windows.Forms.Button();
            this.btn_ApplySocketPara = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(379, 316);
            this.listBox1.TabIndex = 0;
            // 
            // Connect_SocketServer
            // 
            this.Connect_SocketServer.Location = new System.Drawing.Point(807, 30);
            this.Connect_SocketServer.Name = "Connect_SocketServer";
            this.Connect_SocketServer.Size = new System.Drawing.Size(75, 23);
            this.Connect_SocketServer.TabIndex = 1;
            this.Connect_SocketServer.Text = "Connect";
            this.Connect_SocketServer.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(439, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(326, 304);
            this.listBox2.TabIndex = 2;
            // 
            // Send_Socketserver
            // 
            this.Send_Socketserver.Location = new System.Drawing.Point(807, 73);
            this.Send_Socketserver.Name = "Send_Socketserver";
            this.Send_Socketserver.Size = new System.Drawing.Size(75, 23);
            this.Send_Socketserver.TabIndex = 3;
            this.Send_Socketserver.Text = "Send";
            this.Send_Socketserver.UseVisualStyleBackColor = true;
            // 
            // btn_toClientSocket
            // 
            this.btn_toClientSocket.Location = new System.Drawing.Point(297, 435);
            this.btn_toClientSocket.Name = "btn_toClientSocket";
            this.btn_toClientSocket.Size = new System.Drawing.Size(98, 23);
            this.btn_toClientSocket.TabIndex = 4;
            this.btn_toClientSocket.Text = "发送给客户端";
            this.btn_toClientSocket.UseVisualStyleBackColor = true;
            this.btn_toClientSocket.Click += new System.EventHandler(this.btn_toClientSocket_Click);
            // 
            // txb_toClientSocket
            // 
            this.txb_toClientSocket.Location = new System.Drawing.Point(12, 437);
            this.txb_toClientSocket.Name = "txb_toClientSocket";
            this.txb_toClientSocket.Size = new System.Drawing.Size(267, 21);
            this.txb_toClientSocket.TabIndex = 5;
            // 
            // checkBox_IsSocketOpen
            // 
            this.checkBox_IsSocketOpen.AutoSize = true;
            this.checkBox_IsSocketOpen.Location = new System.Drawing.Point(319, 385);
            this.checkBox_IsSocketOpen.Name = "checkBox_IsSocketOpen";
            this.checkBox_IsSocketOpen.Size = new System.Drawing.Size(72, 16);
            this.checkBox_IsSocketOpen.TabIndex = 7;
            this.checkBox_IsSocketOpen.Text = "网口开关";
            this.checkBox_IsSocketOpen.UseVisualStyleBackColor = true;
            this.checkBox_IsSocketOpen.Click += new System.EventHandler(this.checkBox_IsSocketOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "端口:";
            // 
            // txB_IP
            // 
            this.txB_IP.Location = new System.Drawing.Point(69, 340);
            this.txB_IP.Name = "txB_IP";
            this.txB_IP.Size = new System.Drawing.Size(156, 21);
            this.txB_IP.TabIndex = 8;
            // 
            // txB_SocketPort
            // 
            this.txB_SocketPort.Location = new System.Drawing.Point(307, 340);
            this.txB_SocketPort.Name = "txB_SocketPort";
            this.txB_SocketPort.Size = new System.Drawing.Size(84, 21);
            this.txB_SocketPort.TabIndex = 11;
            // 
            // btn_SaveSocketPara
            // 
            this.btn_SaveSocketPara.Location = new System.Drawing.Point(24, 378);
            this.btn_SaveSocketPara.Name = "btn_SaveSocketPara";
            this.btn_SaveSocketPara.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveSocketPara.TabIndex = 12;
            this.btn_SaveSocketPara.Text = "参数保存";
            this.btn_SaveSocketPara.UseVisualStyleBackColor = true;
            this.btn_SaveSocketPara.Click += new System.EventHandler(this.btn_SaveSocketPara_Click);
            // 
            // btn_ApplySocketPara
            // 
            this.btn_ApplySocketPara.Location = new System.Drawing.Point(105, 378);
            this.btn_ApplySocketPara.Name = "btn_ApplySocketPara";
            this.btn_ApplySocketPara.Size = new System.Drawing.Size(75, 23);
            this.btn_ApplySocketPara.TabIndex = 13;
            this.btn_ApplySocketPara.Text = "参数应用";
            this.btn_ApplySocketPara.UseVisualStyleBackColor = true;
            // 
            // FormSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(896, 468);
            this.Controls.Add(this.btn_ApplySocketPara);
            this.Controls.Add(this.btn_SaveSocketPara);
            this.Controls.Add(this.txB_SocketPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txB_IP);
            this.Controls.Add(this.checkBox_IsSocketOpen);
            this.Controls.Add(this.txb_toClientSocket);
            this.Controls.Add(this.btn_toClientSocket);
            this.Controls.Add(this.Send_Socketserver);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.Connect_SocketServer);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSocket";
            this.Text = "网口";
            this.Load += new System.EventHandler(this.FormSocket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Connect_SocketServer;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button Send_Socketserver;
        private System.Windows.Forms.Button btn_toClientSocket;
        private System.Windows.Forms.TextBox txb_toClientSocket;
        private System.Windows.Forms.CheckBox checkBox_IsSocketOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txB_IP;
        private System.Windows.Forms.TextBox txB_SocketPort;
        private System.Windows.Forms.Button btn_SaveSocketPara;
        private System.Windows.Forms.Button btn_ApplySocketPara;
    }
}