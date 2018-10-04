namespace WindowsFormsApplication2
{
    partial class FormSystemSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystemSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnConfigSave = new System.Windows.Forms.Button();
            this.buttonSelectNGPath = new System.Windows.Forms.Button();
            this.txtNGPath = new System.Windows.Forms.TextBox();
            this.checkSaveNGImage = new System.Windows.Forms.CheckBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chkSaveImage = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnapplycommmunication = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.text_Port = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.text_IP = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.comboParity2 = new System.Windows.Forms.ComboBox();
            this.comboStopBits2 = new System.Windows.Forms.ComboBox();
            this.comboDataBits2 = new System.Windows.Forms.ComboBox();
            this.comboBaudrate2 = new System.Windows.Forms.ComboBox();
            this.comboPortName2 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDefaultOnlineEnabled = new System.Windows.Forms.CheckBox();
            this.comboCommunicationMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsavecommmunication = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(45, 150);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 606);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.groupBox9);
            this.tabConfig.Location = new System.Drawing.Point(97, 4);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(600, 598);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "系统设定";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnConfigSave);
            this.groupBox9.Controls.Add(this.buttonSelectNGPath);
            this.groupBox9.Controls.Add(this.txtNGPath);
            this.groupBox9.Controls.Add(this.checkSaveNGImage);
            this.groupBox9.Controls.Add(this.btnSelectPath);
            this.groupBox9.Controls.Add(this.txtPath);
            this.groupBox9.Controls.Add(this.chkSaveImage);
            this.groupBox9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox9.Location = new System.Drawing.Point(6, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(502, 238);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "图像设置";
            // 
            // btnConfigSave
            // 
            this.btnConfigSave.Location = new System.Drawing.Point(13, 182);
            this.btnConfigSave.Name = "btnConfigSave";
            this.btnConfigSave.Size = new System.Drawing.Size(126, 61);
            this.btnConfigSave.TabIndex = 1;
            this.btnConfigSave.Text = "保存";
            this.btnConfigSave.UseVisualStyleBackColor = true;
            this.btnConfigSave.Click += new System.EventHandler(this.btnConfigSave_Click);
            // 
            // buttonSelectNGPath
            // 
            this.buttonSelectNGPath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSelectNGPath.Location = new System.Drawing.Point(12, 91);
            this.buttonSelectNGPath.Name = "buttonSelectNGPath";
            this.buttonSelectNGPath.Size = new System.Drawing.Size(101, 26);
            this.buttonSelectNGPath.TabIndex = 5;
            this.buttonSelectNGPath.Text = "选择NG路径";
            this.buttonSelectNGPath.UseVisualStyleBackColor = true;
            this.buttonSelectNGPath.Click += new System.EventHandler(this.buttonSelectNGPath_Click);
            // 
            // txtNGPath
            // 
            this.txtNGPath.Location = new System.Drawing.Point(122, 90);
            this.txtNGPath.Name = "txtNGPath";
            this.txtNGPath.ReadOnly = true;
            this.txtNGPath.Size = new System.Drawing.Size(403, 29);
            this.txtNGPath.TabIndex = 4;
            // 
            // checkSaveNGImage
            // 
            this.checkSaveNGImage.AutoSize = true;
            this.checkSaveNGImage.Location = new System.Drawing.Point(266, 25);
            this.checkSaveNGImage.Name = "checkSaveNGImage";
            this.checkSaveNGImage.Size = new System.Drawing.Size(124, 23);
            this.checkSaveNGImage.TabIndex = 3;
            this.checkSaveNGImage.Text = "保存NG图片";
            this.checkSaveNGImage.UseVisualStyleBackColor = true;
            this.checkSaveNGImage.Click += new System.EventHandler(this.checkSaveNGImage_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectPath.Location = new System.Drawing.Point(13, 54);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(101, 26);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "选择OK路径";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(122, 52);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(403, 29);
            this.txtPath.TabIndex = 1;
            // 
            // chkSaveImage
            // 
            this.chkSaveImage.AutoSize = true;
            this.chkSaveImage.Location = new System.Drawing.Point(13, 25);
            this.chkSaveImage.Name = "chkSaveImage";
            this.chkSaveImage.Size = new System.Drawing.Size(104, 23);
            this.chkSaveImage.TabIndex = 0;
            this.chkSaveImage.Text = "保存图片";
            this.chkSaveImage.UseVisualStyleBackColor = true;
            this.chkSaveImage.CheckedChanged += new System.EventHandler(this.chkSaveImage_CheckedChanged);
            this.chkSaveImage.Click += new System.EventHandler(this.chkSaveImage_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnapplycommmunication);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox13);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnsavecommmunication);
            this.tabPage1.Location = new System.Drawing.Point(97, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 598);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "通讯设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnapplycommmunication
            // 
            this.btnapplycommmunication.Location = new System.Drawing.Point(57, 442);
            this.btnapplycommmunication.Name = "btnapplycommmunication";
            this.btnapplycommmunication.Size = new System.Drawing.Size(96, 41);
            this.btnapplycommmunication.TabIndex = 13;
            this.btnapplycommmunication.Text = "应用";
            this.btnapplycommmunication.UseVisualStyleBackColor = true;
            this.btnapplycommmunication.Click += new System.EventHandler(this.btnapplycommmunication_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.text_Port);
            this.groupBox2.Controls.Add(this.label_IP);
            this.groupBox2.Controls.Add(this.text_IP);
            this.groupBox2.Location = new System.Drawing.Point(13, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网络设定";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(131, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 35;
            this.label14.Text = "Port";
            // 
            // text_Port
            // 
            this.text_Port.Location = new System.Drawing.Point(131, 48);
            this.text_Port.Name = "text_Port";
            this.text_Port.Size = new System.Drawing.Size(44, 26);
            this.text_Port.TabIndex = 32;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(21, 31);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(56, 16);
            this.label_IP.TabIndex = 33;
            this.label_IP.Text = "IP地址";
            // 
            // text_IP
            // 
            this.text_IP.Location = new System.Drawing.Point(21, 48);
            this.text_IP.Name = "text_IP";
            this.text_IP.Size = new System.Drawing.Size(100, 26);
            this.text_IP.TabIndex = 31;
            this.text_IP.Text = "192.168.0.72";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.comboParity2);
            this.groupBox13.Controls.Add(this.comboStopBits2);
            this.groupBox13.Controls.Add(this.comboDataBits2);
            this.groupBox13.Controls.Add(this.comboBaudrate2);
            this.groupBox13.Controls.Add(this.comboPortName2);
            this.groupBox13.Controls.Add(this.label26);
            this.groupBox13.Controls.Add(this.label27);
            this.groupBox13.Controls.Add(this.label28);
            this.groupBox13.Controls.Add(this.label29);
            this.groupBox13.Controls.Add(this.label30);
            this.groupBox13.Location = new System.Drawing.Point(281, 138);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(233, 147);
            this.groupBox13.TabIndex = 11;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "串口设定2";
            // 
            // comboParity2
            // 
            this.comboParity2.FormattingEnabled = true;
            this.comboParity2.Location = new System.Drawing.Point(90, 118);
            this.comboParity2.Name = "comboParity2";
            this.comboParity2.Size = new System.Drawing.Size(121, 24);
            this.comboParity2.TabIndex = 1;
            // 
            // comboStopBits2
            // 
            this.comboStopBits2.FormattingEnabled = true;
            this.comboStopBits2.Location = new System.Drawing.Point(90, 94);
            this.comboStopBits2.Name = "comboStopBits2";
            this.comboStopBits2.Size = new System.Drawing.Size(121, 24);
            this.comboStopBits2.TabIndex = 1;
            // 
            // comboDataBits2
            // 
            this.comboDataBits2.FormattingEnabled = true;
            this.comboDataBits2.Location = new System.Drawing.Point(90, 70);
            this.comboDataBits2.Name = "comboDataBits2";
            this.comboDataBits2.Size = new System.Drawing.Size(121, 24);
            this.comboDataBits2.TabIndex = 1;
            // 
            // comboBaudrate2
            // 
            this.comboBaudrate2.FormattingEnabled = true;
            this.comboBaudrate2.Location = new System.Drawing.Point(90, 46);
            this.comboBaudrate2.Name = "comboBaudrate2";
            this.comboBaudrate2.Size = new System.Drawing.Size(121, 24);
            this.comboBaudrate2.TabIndex = 1;
            // 
            // comboPortName2
            // 
            this.comboPortName2.FormattingEnabled = true;
            this.comboPortName2.Location = new System.Drawing.Point(90, 22);
            this.comboPortName2.Name = "comboPortName2";
            this.comboPortName2.Size = new System.Drawing.Size(121, 24);
            this.comboPortName2.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 124);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 16);
            this.label26.TabIndex = 0;
            this.label26.Text = "奇偶校验";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 100);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 16);
            this.label27.TabIndex = 0;
            this.label27.Text = "停止位";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(9, 76);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "数据位";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 52);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 16);
            this.label29.TabIndex = 0;
            this.label29.Text = "波特率";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 28);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 0;
            this.label30.Text = "串口名";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboParity);
            this.groupBox4.Controls.Add(this.comboStopBits);
            this.groupBox4.Controls.Add(this.comboDataBits);
            this.groupBox4.Controls.Add(this.comboBaudrate);
            this.groupBox4.Controls.Add(this.comboPortName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(21, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 147);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "串口设定 1";
            // 
            // comboParity
            // 
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Location = new System.Drawing.Point(102, 110);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(121, 24);
            this.comboParity.TabIndex = 1;
            // 
            // comboStopBits
            // 
            this.comboStopBits.FormattingEnabled = true;
            this.comboStopBits.Location = new System.Drawing.Point(102, 86);
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.Size = new System.Drawing.Size(121, 24);
            this.comboStopBits.TabIndex = 1;
            // 
            // comboDataBits
            // 
            this.comboDataBits.FormattingEnabled = true;
            this.comboDataBits.Location = new System.Drawing.Point(102, 62);
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.Size = new System.Drawing.Size(121, 24);
            this.comboDataBits.TabIndex = 1;
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Location = new System.Drawing.Point(102, 38);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(121, 24);
            this.comboBaudrate.TabIndex = 1;
            // 
            // comboPortName
            // 
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(102, 14);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(121, 24);
            this.comboPortName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "奇偶校验";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "停止位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "数据位";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "波特率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "串口名";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDefaultOnlineEnabled);
            this.groupBox3.Controls.Add(this.comboCommunicationMode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(19, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 104);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // chkDefaultOnlineEnabled
            // 
            this.chkDefaultOnlineEnabled.AutoSize = true;
            this.chkDefaultOnlineEnabled.Location = new System.Drawing.Point(327, 47);
            this.chkDefaultOnlineEnabled.Name = "chkDefaultOnlineEnabled";
            this.chkDefaultOnlineEnabled.Size = new System.Drawing.Size(104, 23);
            this.chkDefaultOnlineEnabled.TabIndex = 2;
            this.chkDefaultOnlineEnabled.Text = "默认联机";
            this.chkDefaultOnlineEnabled.UseVisualStyleBackColor = true;
            this.chkDefaultOnlineEnabled.Click += new System.EventHandler(this.chkDefaultOnlineEnabled_Click);
            // 
            // comboCommunicationMode
            // 
            this.comboCommunicationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCommunicationMode.FormattingEnabled = true;
            this.comboCommunicationMode.Items.AddRange(new object[] {
            "串口",
            "网口"});
            this.comboCommunicationMode.Location = new System.Drawing.Point(102, 48);
            this.comboCommunicationMode.Name = "comboCommunicationMode";
            this.comboCommunicationMode.Size = new System.Drawing.Size(121, 27);
            this.comboCommunicationMode.TabIndex = 1;
            this.comboCommunicationMode.SelectedValueChanged += new System.EventHandler(this.comboCommunicationMode_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "通讯方式";
            // 
            // btnsavecommmunication
            // 
            this.btnsavecommmunication.Location = new System.Drawing.Point(281, 442);
            this.btnsavecommmunication.Name = "btnsavecommmunication";
            this.btnsavecommmunication.Size = new System.Drawing.Size(96, 41);
            this.btnsavecommmunication.TabIndex = 7;
            this.btnsavecommmunication.Text = "保存";
            this.btnsavecommmunication.UseVisualStyleBackColor = true;
            this.btnsavecommmunication.Click += new System.EventHandler(this.btnsavecommmunication_Click);
            // 
            // FormSystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 612);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSystemSetting";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.FormSystemSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.Button btnConfigSave;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button buttonSelectNGPath;
        private System.Windows.Forms.TextBox txtNGPath;
        private System.Windows.Forms.CheckBox checkSaveNGImage;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.CheckBox chkSaveImage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox text_Port;
        internal System.Windows.Forms.Label label_IP;
        internal System.Windows.Forms.TextBox text_IP;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.ComboBox comboParity2;
        private System.Windows.Forms.ComboBox comboStopBits2;
        private System.Windows.Forms.ComboBox comboDataBits2;
        private System.Windows.Forms.ComboBox comboBaudrate2;
        private System.Windows.Forms.ComboBox comboPortName2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.ComboBox comboStopBits;
        private System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.ComboBox comboPortName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkDefaultOnlineEnabled;
        private System.Windows.Forms.ComboBox comboCommunicationMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsavecommmunication;
        private System.Windows.Forms.Button btnapplycommmunication;

    }
}