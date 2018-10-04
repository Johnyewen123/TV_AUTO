namespace WindowsFormsApplication2
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SimpleDiagram simpleDiagram7 = new DevExpress.XtraCharts.SimpleDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel7 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView13 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView14 = new DevExpress.XtraCharts.PieSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbl_ccd1imagenum = new System.Windows.Forms.Label();
            this.hWindowControlL = new HalconDotNet.HWindowControl();
            this.lblDetectCam1 = new System.Windows.Forms.Label();
            this.lblConnectedCam1 = new System.Windows.Forms.Label();
            this.lblConnectedCam2 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.lblDetectCam2 = new System.Windows.Forms.Label();
            this.listBox_pick1 = new System.Windows.Forms.ListBox();
            this.cMStrip_SocketMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Clear_message_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToRobortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToLensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.send测试结果ToRobortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.send坐标2ToRobortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_ccdX = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_ccdY = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_ccd2imagenum = new System.Windows.Forms.Label();
            this.hWindowControlR = new HalconDotNet.HWindowControl();
            this.comB_SaveImage = new System.Windows.Forms.ComboBox();
            this.label_socket1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_socket2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.labelCaption = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbproductselect = new System.Windows.Forms.ToolStripButton();
            this.tsbCameraConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbparaSet = new System.Windows.Forms.ToolStripButton();
            this.tsbsystemSet = new System.Windows.Forms.ToolStripButton();
            this.tsbhelpDoc = new System.Windows.Forms.ToolStripButton();
            this.tsbcontactus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.tsbOnline = new System.Windows.Forms.ToolStripButton();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsB_Stop = new System.Windows.Forms.ToolStripButton();
            this.tSB_softTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsB_socket = new System.Windows.Forms.ToolStripButton();
            this.tsB_CalibrateCoordinate = new System.Windows.Forms.ToolStripButton();
            this.tsb_NormalWin = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tpB_PLCSetup = new System.Windows.Forms.ToolStripButton();
            this.timer_statistics = new System.Windows.Forms.Timer(this.components);
            this.timer_authority = new System.Windows.Forms.Timer(this.components);
            this.timer_test = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Lab_PC2RobortSocket = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lab_PLCheartbeat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_timedisp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_testpirchart = new System.Windows.Forms.Button();
            this.btn_TrayOver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_RobotAlarm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_PLC_heartbeat = new System.Windows.Forms.Button();
            this.btn_RobotVcuumAlarm = new System.Windows.Forms.Button();
            this.btn_vacuum1_Now = new System.Windows.Forms.Button();
            this.btn_vacuum2_Now = new System.Windows.Forms.Button();
            this.btn_SaveDoorAlarm = new System.Windows.Forms.Button();
            this.btn_SocketRobortAlarm = new System.Windows.Forms.Button();
            this.btn_CrcleAxiAlarm = new System.Windows.Forms.Button();
            this.btn_Differentialcylinder = new System.Windows.Forms.Button();
            this.btn_GoAimPosition = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_SetSpeed = new System.Windows.Forms.Button();
            this.btn_PLCAddPara = new System.Windows.Forms.Button();
            this.txB_AimPosition = new System.Windows.Forms.TextBox();
            this.btn_GetPositionNow = new System.Windows.Forms.Button();
            this.txB_Speed = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_vacuum2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_EnableMotion = new System.Windows.Forms.Button();
            this.btn_SafeDoor = new System.Windows.Forms.Button();
            this.btn_vacuum1 = new System.Windows.Forms.Button();
            this.label_PositionNow = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_EnableRobot = new System.Windows.Forms.Button();
            this.btn_Zero = new System.Windows.Forms.Button();
            this.btn_forward = new System.Windows.Forms.Button();
            this.btn_backward = new System.Windows.Forms.Button();
            this.btn_Trigger = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cMStrip_SocketMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView14)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ccd1imagenum
            // 
            this.lbl_ccd1imagenum.AutoSize = true;
            this.lbl_ccd1imagenum.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_ccd1imagenum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ccd1imagenum.Location = new System.Drawing.Point(561, 3);
            this.lbl_ccd1imagenum.Name = "lbl_ccd1imagenum";
            this.lbl_ccd1imagenum.Size = new System.Drawing.Size(40, 16);
            this.lbl_ccd1imagenum.TabIndex = 1;
            this.lbl_ccd1imagenum.Text = "——";
            // 
            // hWindowControlL
            // 
            this.hWindowControlL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hWindowControlL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hWindowControlL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControlL.ImagePart = new System.Drawing.Rectangle(0, 0, 2592, 1944);
            this.hWindowControlL.Location = new System.Drawing.Point(3, 3);
            this.hWindowControlL.Name = "hWindowControlL";
            this.hWindowControlL.Size = new System.Drawing.Size(598, 481);
            this.hWindowControlL.TabIndex = 0;
            this.hWindowControlL.WindowSize = new System.Drawing.Size(598, 481);
            // 
            // lblDetectCam1
            // 
            this.lblDetectCam1.BackColor = System.Drawing.Color.Brown;
            this.lblDetectCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetectCam1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectCam1.ForeColor = System.Drawing.Color.Black;
            this.lblDetectCam1.Location = new System.Drawing.Point(153, 11);
            this.lblDetectCam1.Name = "lblDetectCam1";
            this.lblDetectCam1.Size = new System.Drawing.Size(28, 26);
            this.lblDetectCam1.TabIndex = 340;
            this.lblDetectCam1.Text = "1";
            this.lblDetectCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDetectCam1.Click += new System.EventHandler(this.lblDetectCam1_Click);
            this.lblDetectCam1.DoubleClick += new System.EventHandler(this.lblDetectCam1_DoubleClick);
            // 
            // lblConnectedCam1
            // 
            this.lblConnectedCam1.BackColor = System.Drawing.Color.Green;
            this.lblConnectedCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnectedCam1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConnectedCam1.ForeColor = System.Drawing.Color.Black;
            this.lblConnectedCam1.Location = new System.Drawing.Point(388, 44);
            this.lblConnectedCam1.Name = "lblConnectedCam1";
            this.lblConnectedCam1.Size = new System.Drawing.Size(29, 23);
            this.lblConnectedCam1.TabIndex = 337;
            this.lblConnectedCam1.Text = "1";
            this.lblConnectedCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnectedCam1.DoubleClick += new System.EventHandler(this.lblConnectedCam1_DoubleClick);
            // 
            // lblConnectedCam2
            // 
            this.lblConnectedCam2.BackColor = System.Drawing.Color.Green;
            this.lblConnectedCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnectedCam2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConnectedCam2.ForeColor = System.Drawing.Color.Black;
            this.lblConnectedCam2.Location = new System.Drawing.Point(357, 44);
            this.lblConnectedCam2.Name = "lblConnectedCam2";
            this.lblConnectedCam2.Size = new System.Drawing.Size(28, 23);
            this.lblConnectedCam2.TabIndex = 338;
            this.lblConnectedCam2.Text = "2";
            this.lblConnectedCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnectedCam2.Click += new System.EventHandler(this.lblConnectedCam2_Click);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label75.ForeColor = System.Drawing.Color.DarkOrange;
            this.label75.Location = new System.Drawing.Point(266, 44);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(99, 19);
            this.label75.TabIndex = 336;
            this.label75.Text = "相机连接:";
            // 
            // lblDetectCam2
            // 
            this.lblDetectCam2.BackColor = System.Drawing.Color.Brown;
            this.lblDetectCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetectCam2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetectCam2.ForeColor = System.Drawing.Color.Black;
            this.lblDetectCam2.Location = new System.Drawing.Point(127, 11);
            this.lblDetectCam2.Name = "lblDetectCam2";
            this.lblDetectCam2.Size = new System.Drawing.Size(27, 26);
            this.lblDetectCam2.TabIndex = 299;
            this.lblDetectCam2.Text = "2";
            this.lblDetectCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDetectCam2.DoubleClick += new System.EventHandler(this.lblDetectCam2_DoubleClick);
            // 
            // listBox_pick1
            // 
            this.listBox_pick1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox_pick1.ContextMenuStrip = this.cMStrip_SocketMessage;
            this.listBox_pick1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_pick1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_pick1.FormattingEnabled = true;
            this.listBox_pick1.ItemHeight = 16;
            this.listBox_pick1.Location = new System.Drawing.Point(3, 3);
            this.listBox_pick1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox_pick1.Name = "listBox_pick1";
            this.listBox_pick1.Size = new System.Drawing.Size(1270, 520);
            this.listBox_pick1.TabIndex = 7;
            // 
            // cMStrip_SocketMessage
            // 
            this.cMStrip_SocketMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clear_message_ToolStripMenuItem,
            this.sendMessageToRobortToolStripMenuItem,
            this.sendMessageToLensToolStripMenuItem,
            this.send测试结果ToRobortToolStripMenuItem,
            this.send坐标2ToRobortToolStripMenuItem});
            this.cMStrip_SocketMessage.Name = "cMStrip_SocketMessage";
            this.cMStrip_SocketMessage.Size = new System.Drawing.Size(228, 114);
            this.cMStrip_SocketMessage.Text = "清空网路通讯信息";
            // 
            // Clear_message_ToolStripMenuItem
            // 
            this.Clear_message_ToolStripMenuItem.Name = "Clear_message_ToolStripMenuItem";
            this.Clear_message_ToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.Clear_message_ToolStripMenuItem.Text = "Clear  Messsage";
            this.Clear_message_ToolStripMenuItem.Click += new System.EventHandler(this.Clear_message_ToolStripMenuItem_Click);
            // 
            // sendMessageToRobortToolStripMenuItem
            // 
            this.sendMessageToRobortToolStripMenuItem.Name = "sendMessageToRobortToolStripMenuItem";
            this.sendMessageToRobortToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.sendMessageToRobortToolStripMenuItem.Text = "Send 坐标1 to Robort ";
            this.sendMessageToRobortToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToRobortToolStripMenuItem_Click);
            // 
            // sendMessageToLensToolStripMenuItem
            // 
            this.sendMessageToLensToolStripMenuItem.Name = "sendMessageToLensToolStripMenuItem";
            this.sendMessageToLensToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.sendMessageToLensToolStripMenuItem.Text = "Send 开始测试信号 to Lens";
            this.sendMessageToLensToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToLensToolStripMenuItem_Click);
            // 
            // send测试结果ToRobortToolStripMenuItem
            // 
            this.send测试结果ToRobortToolStripMenuItem.Name = "send测试结果ToRobortToolStripMenuItem";
            this.send测试结果ToRobortToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.send测试结果ToRobortToolStripMenuItem.Text = "Send 测试结果 to Robort";
            this.send测试结果ToRobortToolStripMenuItem.Click += new System.EventHandler(this.send测试结果ToRobortToolStripMenuItem_Click);
            // 
            // send坐标2ToRobortToolStripMenuItem
            // 
            this.send坐标2ToRobortToolStripMenuItem.Name = "send坐标2ToRobortToolStripMenuItem";
            this.send坐标2ToRobortToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.send坐标2ToRobortToolStripMenuItem.Text = "Send  坐标2 to Robort";
            this.send坐标2ToRobortToolStripMenuItem.Click += new System.EventHandler(this.send坐标2ToRobortToolStripMenuItem_Click);
            // 
            // textBox_ccdX
            // 
            this.textBox_ccdX.Location = new System.Drawing.Point(377, 76);
            this.textBox_ccdX.Name = "textBox_ccdX";
            this.textBox_ccdX.Size = new System.Drawing.Size(98, 29);
            this.textBox_ccdX.TabIndex = 8;
            this.textBox_ccdX.TextChanged += new System.EventHandler(this.textBox_ccdX_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "测试网口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox_ccdY
            // 
            this.textBox_ccdY.Location = new System.Drawing.Point(258, 76);
            this.textBox_ccdY.Name = "textBox_ccdY";
            this.textBox_ccdY.Size = new System.Drawing.Size(100, 29);
            this.textBox_ccdY.TabIndex = 9;
            this.textBox_ccdY.TextChanged += new System.EventHandler(this.textBox_ccdY_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "手动给拍照位置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(426, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "测试数据统计";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 24);
            this.button4.TabIndex = 5;
            this.button4.Text = "测试满料";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_ccd2imagenum
            // 
            this.lbl_ccd2imagenum.AutoSize = true;
            this.lbl_ccd2imagenum.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_ccd2imagenum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ccd2imagenum.Location = new System.Drawing.Point(561, 3);
            this.lbl_ccd2imagenum.Name = "lbl_ccd2imagenum";
            this.lbl_ccd2imagenum.Size = new System.Drawing.Size(40, 16);
            this.lbl_ccd2imagenum.TabIndex = 6;
            this.lbl_ccd2imagenum.Text = "——";
            // 
            // hWindowControlR
            // 
            this.hWindowControlR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hWindowControlR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hWindowControlR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControlR.ImagePart = new System.Drawing.Rectangle(0, 0, 2592, 1944);
            this.hWindowControlR.Location = new System.Drawing.Point(3, 3);
            this.hWindowControlR.Name = "hWindowControlR";
            this.hWindowControlR.Size = new System.Drawing.Size(598, 481);
            this.hWindowControlR.TabIndex = 1;
            this.hWindowControlR.WindowSize = new System.Drawing.Size(598, 481);
            // 
            // comB_SaveImage
            // 
            this.comB_SaveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comB_SaveImage.FormattingEnabled = true;
            this.comB_SaveImage.Items.AddRange(new object[] {
            "SaveAllImage",
            "SaveNGImage",
            "SaveOKImage",
            "NotSaveImage"});
            this.comB_SaveImage.Location = new System.Drawing.Point(137, 46);
            this.comB_SaveImage.Name = "comB_SaveImage";
            this.comB_SaveImage.Size = new System.Drawing.Size(104, 20);
            this.comB_SaveImage.TabIndex = 335;
            this.comB_SaveImage.SelectedIndexChanged += new System.EventHandler(this.comB_SaveImage_SelectedIndexChanged);
            // 
            // label_socket1
            // 
            this.label_socket1.AutoSize = true;
            this.label_socket1.Location = new System.Drawing.Point(619, 18);
            this.label_socket1.Name = "label_socket1";
            this.label_socket1.Size = new System.Drawing.Size(41, 12);
            this.label_socket1.TabIndex = 15;
            this.label_socket1.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(206, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "相机2软触发信号：";
            // 
            // label_socket2
            // 
            this.label_socket2.AutoSize = true;
            this.label_socket2.Location = new System.Drawing.Point(371, 13);
            this.label_socket2.Name = "label_socket2";
            this.label_socket2.Size = new System.Drawing.Size(41, 12);
            this.label_socket2.TabIndex = 18;
            this.label_socket2.Text = "label5";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(171, 186);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(109, 24);
            this.button7.TabIndex = 13;
            this.button7.Text = "定时触发1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(426, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 24);
            this.button5.TabIndex = 11;
            this.button5.Text = "相机1触发";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chartControl1
            // 
            this.chartControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            simpleDiagram7.EqualPieSize = false;
            this.chartControl1.Diagram = simpleDiagram7;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            pieSeriesLabel7.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.Label = pieSeriesLabel7;
            series7.Name = "Series 1";
            pieSeriesView13.RuntimeExploding = false;
            pieSeriesView13.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
            series7.View = pieSeriesView13;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7};
            pieSeriesView14.RuntimeExploding = false;
            pieSeriesView14.SweepDirection = DevExpress.XtraCharts.PieSweepDirection.Counterclockwise;
            this.chartControl1.SeriesTemplate.View = pieSeriesView14;
            this.chartControl1.Size = new System.Drawing.Size(654, 520);
            this.chartControl1.TabIndex = 3;
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCaption.Font = new System.Drawing.Font("楷体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCaption.Location = new System.Drawing.Point(0, 0);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCaption.Size = new System.Drawing.Size(356, 48);
            this.labelCaption.TabIndex = 1;
            this.labelCaption.Text = "TV刻画自动上料";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(519, 275);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(139, 41);
            this.button10.TabIndex = 7;
            this.button10.Text = "电机回零";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(243, 282);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 8;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(361, 275);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 41);
            this.button9.TabIndex = 7;
            this.button9.Text = "电机旋转";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbproductselect,
            this.tsbCameraConfig,
            this.tsbparaSet,
            this.tsbsystemSet,
            this.tsbhelpDoc,
            this.tsbcontactus,
            this.toolStripButton8,
            this.tsbOnline,
            this.tsbRun,
            this.tsB_Stop,
            this.tSB_softTrigger,
            this.tsB_socket,
            this.tsB_CalibrateCoordinate,
            this.tsb_NormalWin,
            this.toolStripButton1,
            this.tsbExit,
            this.tpB_PLCSetup});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(936, 49);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // tsbproductselect
            // 
            this.tsbproductselect.AutoSize = false;
            this.tsbproductselect.Image = ((System.Drawing.Image)(resources.GetObject("tsbproductselect.Image")));
            this.tsbproductselect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbproductselect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbproductselect.Name = "tsbproductselect";
            this.tsbproductselect.Size = new System.Drawing.Size(60, 61);
            this.tsbproductselect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbCameraConfig
            // 
            this.tsbCameraConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbCameraConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsbCameraConfig.Image")));
            this.tsbCameraConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCameraConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCameraConfig.Name = "tsbCameraConfig";
            this.tsbCameraConfig.Size = new System.Drawing.Size(52, 46);
            this.tsbCameraConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCameraConfig.Click += new System.EventHandler(this.tsbCameraConfig_Click);
            // 
            // tsbparaSet
            // 
            this.tsbparaSet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbparaSet.Image = ((System.Drawing.Image)(resources.GetObject("tsbparaSet.Image")));
            this.tsbparaSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbparaSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbparaSet.Name = "tsbparaSet";
            this.tsbparaSet.Size = new System.Drawing.Size(52, 46);
            this.tsbparaSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbparaSet.Click += new System.EventHandler(this.tsbparaSet_Click);
            // 
            // tsbsystemSet
            // 
            this.tsbsystemSet.AutoSize = false;
            this.tsbsystemSet.Image = ((System.Drawing.Image)(resources.GetObject("tsbsystemSet.Image")));
            this.tsbsystemSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbsystemSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbsystemSet.Name = "tsbsystemSet";
            this.tsbsystemSet.Size = new System.Drawing.Size(60, 61);
            this.tsbsystemSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbsystemSet.Click += new System.EventHandler(this.tsbsystemSet_Click);
            // 
            // tsbhelpDoc
            // 
            this.tsbhelpDoc.AutoSize = false;
            this.tsbhelpDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsbhelpDoc.Image")));
            this.tsbhelpDoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbhelpDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbhelpDoc.Name = "tsbhelpDoc";
            this.tsbhelpDoc.Size = new System.Drawing.Size(60, 61);
            this.tsbhelpDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbhelpDoc.ToolTipText = "帮助文档";
            this.tsbhelpDoc.Click += new System.EventHandler(this.tsbhelpDoc_Click);
            // 
            // tsbcontactus
            // 
            this.tsbcontactus.Image = ((System.Drawing.Image)(resources.GetObject("tsbcontactus.Image")));
            this.tsbcontactus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbcontactus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbcontactus.Name = "tsbcontactus";
            this.tsbcontactus.Size = new System.Drawing.Size(52, 46);
            this.tsbcontactus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbcontactus.Click += new System.EventHandler(this.tsbcontactus_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(52, 46);
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbOnline
            // 
            this.tsbOnline.CheckOnClick = true;
            this.tsbOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tsbOnline.Image = ((System.Drawing.Image)(resources.GetObject("tsbOnline.Image")));
            this.tsbOnline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOnline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOnline.Name = "tsbOnline";
            this.tsbOnline.Size = new System.Drawing.Size(52, 46);
            this.tsbOnline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOnline.ToolTipText = "是否进行联机";
            // 
            // tsbRun
            // 
            this.tsbRun.Image = ((System.Drawing.Image)(resources.GetObject("tsbRun.Image")));
            this.tsbRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(52, 46);
            this.tsbRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRun.ToolTipText = "开始检测";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsB_Stop
            // 
            this.tsB_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsB_Stop.Image = ((System.Drawing.Image)(resources.GetObject("tsB_Stop.Image")));
            this.tsB_Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsB_Stop.ImageTransparentColor = System.Drawing.Color.Lime;
            this.tsB_Stop.Name = "tsB_Stop";
            this.tsB_Stop.Size = new System.Drawing.Size(52, 46);
            this.tsB_Stop.Text = "toolStripButton2";
            this.tsB_Stop.ToolTipText = "停止检测";
            this.tsB_Stop.Click += new System.EventHandler(this.tsB_Stop_Click_1);
            // 
            // tSB_softTrigger
            // 
            this.tSB_softTrigger.Image = ((System.Drawing.Image)(resources.GetObject("tSB_softTrigger.Image")));
            this.tSB_softTrigger.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSB_softTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_softTrigger.Name = "tSB_softTrigger";
            this.tSB_softTrigger.Size = new System.Drawing.Size(52, 46);
            this.tSB_softTrigger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tSB_softTrigger.ToolTipText = "软触发";
            this.tSB_softTrigger.Click += new System.EventHandler(this.tSB_softTrigger_Click);
            // 
            // tsB_socket
            // 
            this.tsB_socket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsB_socket.Image = ((System.Drawing.Image)(resources.GetObject("tsB_socket.Image")));
            this.tsB_socket.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsB_socket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsB_socket.Name = "tsB_socket";
            this.tsB_socket.Size = new System.Drawing.Size(52, 46);
            this.tsB_socket.Text = "toolStripButton1";
            this.tsB_socket.ToolTipText = "网口通讯";
            this.tsB_socket.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsB_CalibrateCoordinate
            // 
            this.tsB_CalibrateCoordinate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsB_CalibrateCoordinate.Image = ((System.Drawing.Image)(resources.GetObject("tsB_CalibrateCoordinate.Image")));
            this.tsB_CalibrateCoordinate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsB_CalibrateCoordinate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsB_CalibrateCoordinate.Name = "tsB_CalibrateCoordinate";
            this.tsB_CalibrateCoordinate.Size = new System.Drawing.Size(52, 46);
            this.tsB_CalibrateCoordinate.Text = "toolStripButton2";
            this.tsB_CalibrateCoordinate.ToolTipText = "坐标系标定";
            this.tsB_CalibrateCoordinate.Click += new System.EventHandler(this.tsB_CalibrateCoordinate_Click);
            // 
            // tsb_NormalWin
            // 
            this.tsb_NormalWin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_NormalWin.Image = ((System.Drawing.Image)(resources.GetObject("tsb_NormalWin.Image")));
            this.tsb_NormalWin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_NormalWin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_NormalWin.Name = "tsb_NormalWin";
            this.tsb_NormalWin.Size = new System.Drawing.Size(52, 46);
            this.tsb_NormalWin.Text = "toolStripButton2";
            this.tsb_NormalWin.ToolTipText = "窗口显示大小调整";
            this.tsb_NormalWin.Click += new System.EventHandler(this.tsb_NormalWin_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 46);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(52, 46);
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.ToolTipText = "退出软件";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tpB_PLCSetup
            // 
            this.tpB_PLCSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpB_PLCSetup.Image = ((System.Drawing.Image)(resources.GetObject("tpB_PLCSetup.Image")));
            this.tpB_PLCSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tpB_PLCSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpB_PLCSetup.Name = "tpB_PLCSetup";
            this.tpB_PLCSetup.Size = new System.Drawing.Size(52, 46);
            this.tpB_PLCSetup.Text = "toolStripButton2";
            this.tpB_PLCSetup.ToolTipText = "PLC设置";
            this.tpB_PLCSetup.Click += new System.EventHandler(this.tpB_PLCSetup_Click);
            // 
            // timer_statistics
            // 
            this.timer_statistics.Interval = 2;
            this.timer_statistics.Tick += new System.EventHandler(this.timer_statistics_Tick);
            // 
            // timer_authority
            // 
            this.timer_authority.Enabled = true;
            this.timer_authority.Tick += new System.EventHandler(this.timer_authority_Tick);
            // 
            // timer_test
            // 
            this.timer_test.Interval = 10;
            this.timer_test.Tick += new System.EventHandler(this.timer_test_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 701);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 341;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel1);
            this.splitContainer4.Size = new System.Drawing.Size(1284, 49);
            this.splitContainer4.SplitterDistance = 936;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.labelCaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 49);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Lab_PC2RobortSocket);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.lab_PLCheartbeat);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.lblConnectedCam2);
            this.splitContainer2.Panel1.Controls.Add(this.lblConnectedCam1);
            this.splitContainer2.Panel1.Controls.Add(this.label75);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_timedisp);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.comB_SaveImage);
            this.splitContainer2.Panel1.Controls.Add(this.label72);
            this.splitContainer2.Panel1.Controls.Add(this.lblDetectCam2);
            this.splitContainer2.Panel1.Controls.Add(this.lblDetectCam1);
            this.splitContainer2.Panel1.Controls.Add(this.label_socket2);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label_socket1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 648);
            this.splitContainer2.SplitterDistance = 72;
            this.splitContainer2.TabIndex = 0;
            // 
            // Lab_PC2RobortSocket
            // 
            this.Lab_PC2RobortSocket.BackColor = System.Drawing.Color.Green;
            this.Lab_PC2RobortSocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lab_PC2RobortSocket.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_PC2RobortSocket.ForeColor = System.Drawing.Color.Black;
            this.Lab_PC2RobortSocket.Location = new System.Drawing.Point(778, 46);
            this.Lab_PC2RobortSocket.Name = "Lab_PC2RobortSocket";
            this.Lab_PC2RobortSocket.Size = new System.Drawing.Size(29, 23);
            this.Lab_PC2RobortSocket.TabIndex = 349;
            this.Lab_PC2RobortSocket.Text = "1";
            this.Lab_PC2RobortSocket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(582, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 19);
            this.label7.TabIndex = 348;
            this.label7.Text = "机械手与PC网口连接：";
            // 
            // lab_PLCheartbeat
            // 
            this.lab_PLCheartbeat.BackColor = System.Drawing.Color.Green;
            this.lab_PLCheartbeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_PLCheartbeat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PLCheartbeat.ForeColor = System.Drawing.Color.Black;
            this.lab_PLCheartbeat.Location = new System.Drawing.Point(536, 44);
            this.lab_PLCheartbeat.Name = "lab_PLCheartbeat";
            this.lab_PLCheartbeat.Size = new System.Drawing.Size(29, 23);
            this.lab_PLCheartbeat.TabIndex = 347;
            this.lab_PLCheartbeat.Text = "1";
            this.lab_PLCheartbeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(460, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 346;
            this.label1.Text = "PLC心跳：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(22, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 345;
            this.label6.Text = "图像保存：";
            // 
            // lbl_timedisp
            // 
            this.lbl_timedisp.AutoSize = true;
            this.lbl_timedisp.Location = new System.Drawing.Point(766, 20);
            this.lbl_timedisp.Name = "lbl_timedisp";
            this.lbl_timedisp.Size = new System.Drawing.Size(53, 12);
            this.lbl_timedisp.TabIndex = 343;
            this.lbl_timedisp.Text = "现在时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(691, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 344;
            this.label5.Text = "时间：";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label72.ForeColor = System.Drawing.Color.DarkOrange;
            this.label72.Location = new System.Drawing.Point(22, 13);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(99, 19);
            this.label72.TabIndex = 339;
            this.label72.Text = "相机检测:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(439, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "相机1软触发信号：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_pick1);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1276, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "运行日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1276, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chartControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer3.Size = new System.Drawing.Size(1270, 520);
            this.splitContainer3.SplitterDistance = 654;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(612, 520);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lbl_ccd2imagenum);
            this.tabPage5.Controls.Add(this.hWindowControlR);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(604, 487);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "相机1";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lbl_ccd1imagenum);
            this.tabPage6.Controls.Add(this.hWindowControlL);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(604, 487);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "相机2";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Controls.Add(this.btn_testpirchart);
            this.tabPage3.Controls.Add(this.btn_TrayOver);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.textBox_ccdX);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.textBox_ccdY);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1276, 539);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "调试";
            // 
            // btn_testpirchart
            // 
            this.btn_testpirchart.Location = new System.Drawing.Point(718, 12);
            this.btn_testpirchart.Name = "btn_testpirchart";
            this.btn_testpirchart.Size = new System.Drawing.Size(139, 41);
            this.btn_testpirchart.TabIndex = 351;
            this.btn_testpirchart.Text = "饼装图测试";
            this.btn_testpirchart.UseVisualStyleBackColor = true;
            this.btn_testpirchart.Click += new System.EventHandler(this.btn_testpirchart_Click);
            // 
            // btn_TrayOver
            // 
            this.btn_TrayOver.Location = new System.Drawing.Point(518, 12);
            this.btn_TrayOver.Name = "btn_TrayOver";
            this.btn_TrayOver.Size = new System.Drawing.Size(139, 41);
            this.btn_TrayOver.TabIndex = 349;
            this.btn_TrayOver.Text = "满料信号测试";
            this.btn_TrayOver.UseVisualStyleBackColor = true;
            this.btn_TrayOver.Click += new System.EventHandler(this.btn_TrayOver_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btn_Differentialcylinder);
            this.panel2.Controls.Add(this.btn_GoAimPosition);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btn_SetSpeed);
            this.panel2.Controls.Add(this.btn_PLCAddPara);
            this.panel2.Controls.Add(this.txB_AimPosition);
            this.panel2.Controls.Add(this.btn_GetPositionNow);
            this.panel2.Controls.Add(this.txB_Speed);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.btn_vacuum2);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btn_EnableMotion);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btn_SafeDoor);
            this.panel2.Controls.Add(this.btn_vacuum1);
            this.panel2.Controls.Add(this.label_PositionNow);
            this.panel2.Controls.Add(this.btn_Reset);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.btn_EnableRobot);
            this.panel2.Controls.Add(this.btn_Zero);
            this.panel2.Controls.Add(this.btn_forward);
            this.panel2.Controls.Add(this.btn_backward);
            this.panel2.Controls.Add(this.btn_Trigger);
            this.panel2.Location = new System.Drawing.Point(8, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 394);
            this.panel2.TabIndex = 348;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_RobotAlarm);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btn_PLC_heartbeat);
            this.groupBox3.Controls.Add(this.btn_RobotVcuumAlarm);
            this.groupBox3.Controls.Add(this.btn_vacuum1_Now);
            this.groupBox3.Controls.Add(this.btn_vacuum2_Now);
            this.groupBox3.Controls.Add(this.btn_SaveDoorAlarm);
            this.groupBox3.Controls.Add(this.btn_SocketRobortAlarm);
            this.groupBox3.Controls.Add(this.btn_CrcleAxiAlarm);
            this.groupBox3.Location = new System.Drawing.Point(876, -3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 391);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // btn_RobotAlarm
            // 
            this.btn_RobotAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_RobotAlarm.Location = new System.Drawing.Point(35, 88);
            this.btn_RobotAlarm.Name = "btn_RobotAlarm";
            this.btn_RobotAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_RobotAlarm.TabIndex = 0;
            this.btn_RobotAlarm.Text = "机械手报警";
            this.btn_RobotAlarm.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "报警信号灯";
            // 
            // btn_PLC_heartbeat
            // 
            this.btn_PLC_heartbeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_PLC_heartbeat.Location = new System.Drawing.Point(35, 339);
            this.btn_PLC_heartbeat.Name = "btn_PLC_heartbeat";
            this.btn_PLC_heartbeat.Size = new System.Drawing.Size(308, 36);
            this.btn_PLC_heartbeat.TabIndex = 7;
            this.btn_PLC_heartbeat.Text = "PLC心跳报警";
            this.btn_PLC_heartbeat.UseVisualStyleBackColor = false;
            // 
            // btn_RobotVcuumAlarm
            // 
            this.btn_RobotVcuumAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_RobotVcuumAlarm.Location = new System.Drawing.Point(35, 129);
            this.btn_RobotVcuumAlarm.Name = "btn_RobotVcuumAlarm";
            this.btn_RobotVcuumAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_RobotVcuumAlarm.TabIndex = 1;
            this.btn_RobotVcuumAlarm.Text = "机械手吸附真空异常";
            this.btn_RobotVcuumAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_vacuum1_Now
            // 
            this.btn_vacuum1_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_vacuum1_Now.Location = new System.Drawing.Point(35, 46);
            this.btn_vacuum1_Now.Name = "btn_vacuum1_Now";
            this.btn_vacuum1_Now.Size = new System.Drawing.Size(308, 36);
            this.btn_vacuum1_Now.TabIndex = 5;
            this.btn_vacuum1_Now.Text = "真空信号1";
            this.btn_vacuum1_Now.UseVisualStyleBackColor = false;
            // 
            // btn_vacuum2_Now
            // 
            this.btn_vacuum2_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_vacuum2_Now.Location = new System.Drawing.Point(35, 213);
            this.btn_vacuum2_Now.Name = "btn_vacuum2_Now";
            this.btn_vacuum2_Now.Size = new System.Drawing.Size(308, 36);
            this.btn_vacuum2_Now.TabIndex = 6;
            this.btn_vacuum2_Now.Text = "真空信号2";
            this.btn_vacuum2_Now.UseVisualStyleBackColor = false;
            // 
            // btn_SaveDoorAlarm
            // 
            this.btn_SaveDoorAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_SaveDoorAlarm.Location = new System.Drawing.Point(35, 297);
            this.btn_SaveDoorAlarm.Name = "btn_SaveDoorAlarm";
            this.btn_SaveDoorAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_SaveDoorAlarm.TabIndex = 3;
            this.btn_SaveDoorAlarm.Text = "安全门报警";
            this.btn_SaveDoorAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_SocketRobortAlarm
            // 
            this.btn_SocketRobortAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_SocketRobortAlarm.Location = new System.Drawing.Point(35, 171);
            this.btn_SocketRobortAlarm.Name = "btn_SocketRobortAlarm";
            this.btn_SocketRobortAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_SocketRobortAlarm.TabIndex = 4;
            this.btn_SocketRobortAlarm.Text = "与机械手网口连接报警";
            this.btn_SocketRobortAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_CrcleAxiAlarm
            // 
            this.btn_CrcleAxiAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_CrcleAxiAlarm.Location = new System.Drawing.Point(35, 255);
            this.btn_CrcleAxiAlarm.Name = "btn_CrcleAxiAlarm";
            this.btn_CrcleAxiAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_CrcleAxiAlarm.TabIndex = 2;
            this.btn_CrcleAxiAlarm.Text = "旋转轴报警";
            this.btn_CrcleAxiAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_Differentialcylinder
            // 
            this.btn_Differentialcylinder.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_Differentialcylinder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Differentialcylinder.Location = new System.Drawing.Point(328, 85);
            this.btn_Differentialcylinder.Name = "btn_Differentialcylinder";
            this.btn_Differentialcylinder.Size = new System.Drawing.Size(139, 41);
            this.btn_Differentialcylinder.TabIndex = 9;
            this.btn_Differentialcylinder.Text = "高度差气缸";
            this.btn_Differentialcylinder.UseVisualStyleBackColor = false;
            this.btn_Differentialcylinder.Click += new System.EventHandler(this.btn_Differentialcylinder_Click);
            // 
            // btn_GoAimPosition
            // 
            this.btn_GoAimPosition.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_GoAimPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GoAimPosition.Location = new System.Drawing.Point(731, 105);
            this.btn_GoAimPosition.Name = "btn_GoAimPosition";
            this.btn_GoAimPosition.Size = new System.Drawing.Size(139, 41);
            this.btn_GoAimPosition.TabIndex = 8;
            this.btn_GoAimPosition.Text = "到目标位置";
            this.btn_GoAimPosition.UseVisualStyleBackColor = false;
            this.btn_GoAimPosition.Click += new System.EventHandler(this.btn_GoAimPosition_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 15.75F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(29, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 21);
            this.label8.TabIndex = 345;
            this.label8.Text = "手动电机旋转度数：";
            // 
            // btn_SetSpeed
            // 
            this.btn_SetSpeed.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_SetSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SetSpeed.Location = new System.Drawing.Point(731, 56);
            this.btn_SetSpeed.Name = "btn_SetSpeed";
            this.btn_SetSpeed.Size = new System.Drawing.Size(139, 41);
            this.btn_SetSpeed.TabIndex = 15;
            this.btn_SetSpeed.Text = "设置当前速度";
            this.btn_SetSpeed.UseVisualStyleBackColor = false;
            this.btn_SetSpeed.Click += new System.EventHandler(this.btn_SetSpeed_Click);
            // 
            // btn_PLCAddPara
            // 
            this.btn_PLCAddPara.BackColor = System.Drawing.Color.Green;
            this.btn_PLCAddPara.Location = new System.Drawing.Point(724, 268);
            this.btn_PLCAddPara.Name = "btn_PLCAddPara";
            this.btn_PLCAddPara.Size = new System.Drawing.Size(146, 56);
            this.btn_PLCAddPara.TabIndex = 11;
            this.btn_PLCAddPara.Text = "PLC地址配置";
            this.btn_PLCAddPara.UseVisualStyleBackColor = false;
            this.btn_PLCAddPara.Click += new System.EventHandler(this.btn_PLCAddPara_Click);
            // 
            // txB_AimPosition
            // 
            this.txB_AimPosition.Location = new System.Drawing.Point(609, 94);
            this.txB_AimPosition.Name = "txB_AimPosition";
            this.txB_AimPosition.Size = new System.Drawing.Size(100, 29);
            this.txB_AimPosition.TabIndex = 12;
            // 
            // btn_GetPositionNow
            // 
            this.btn_GetPositionNow.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_GetPositionNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GetPositionNow.Location = new System.Drawing.Point(731, 10);
            this.btn_GetPositionNow.Name = "btn_GetPositionNow";
            this.btn_GetPositionNow.Size = new System.Drawing.Size(139, 40);
            this.btn_GetPositionNow.TabIndex = 0;
            this.btn_GetPositionNow.Text = "获取当前位置";
            this.btn_GetPositionNow.UseVisualStyleBackColor = false;
            this.btn_GetPositionNow.Click += new System.EventHandler(this.btn_GetPositionNow_Click);
            // 
            // txB_Speed
            // 
            this.txB_Speed.Location = new System.Drawing.Point(609, 58);
            this.txB_Speed.Name = "txB_Speed";
            this.txB_Speed.Size = new System.Drawing.Size(100, 29);
            this.txB_Speed.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(494, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 19);
            this.label12.TabIndex = 11;
            this.label12.Text = "目标位置：";
            // 
            // btn_vacuum2
            // 
            this.btn_vacuum2.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_vacuum2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_vacuum2.Location = new System.Drawing.Point(328, 22);
            this.btn_vacuum2.Name = "btn_vacuum2";
            this.btn_vacuum2.Size = new System.Drawing.Size(139, 41);
            this.btn_vacuum2.TabIndex = 5;
            this.btn_vacuum2.Text = "真空2";
            this.btn_vacuum2.UseVisualStyleBackColor = false;
            this.btn_vacuum2.Click += new System.EventHandler(this.btn_vacuum2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(494, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 19);
            this.label13.TabIndex = 13;
            this.label13.Text = "手动速度：";
            // 
            // btn_EnableMotion
            // 
            this.btn_EnableMotion.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_EnableMotion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_EnableMotion.Location = new System.Drawing.Point(328, 142);
            this.btn_EnableMotion.Name = "btn_EnableMotion";
            this.btn_EnableMotion.Size = new System.Drawing.Size(139, 41);
            this.btn_EnableMotion.TabIndex = 0;
            this.btn_EnableMotion.Text = "电机使能";
            this.btn_EnableMotion.UseVisualStyleBackColor = false;
            this.btn_EnableMotion.Click += new System.EventHandler(this.btn_EnableMotion_Click);
            // 
            // btn_SafeDoor
            // 
            this.btn_SafeDoor.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_SafeDoor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SafeDoor.Location = new System.Drawing.Point(183, 22);
            this.btn_SafeDoor.Name = "btn_SafeDoor";
            this.btn_SafeDoor.Size = new System.Drawing.Size(139, 41);
            this.btn_SafeDoor.TabIndex = 10;
            this.btn_SafeDoor.Text = "安全门屏蔽";
            this.btn_SafeDoor.UseVisualStyleBackColor = false;
            this.btn_SafeDoor.Click += new System.EventHandler(this.btn_SafeDoor_Click);
            // 
            // btn_vacuum1
            // 
            this.btn_vacuum1.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_vacuum1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_vacuum1.Location = new System.Drawing.Point(183, 204);
            this.btn_vacuum1.Name = "btn_vacuum1";
            this.btn_vacuum1.Size = new System.Drawing.Size(139, 41);
            this.btn_vacuum1.TabIndex = 6;
            this.btn_vacuum1.Text = "真空1";
            this.btn_vacuum1.UseVisualStyleBackColor = false;
            this.btn_vacuum1.Click += new System.EventHandler(this.btn_vacuum1_Click);
            // 
            // label_PositionNow
            // 
            this.label_PositionNow.AutoSize = true;
            this.label_PositionNow.Location = new System.Drawing.Point(625, 31);
            this.label_PositionNow.Name = "label_PositionNow";
            this.label_PositionNow.Size = new System.Drawing.Size(89, 19);
            this.label_PositionNow.TabIndex = 10;
            this.label_PositionNow.Text = "————";
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.Silver;
            this.btn_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Reset.Location = new System.Drawing.Point(183, 142);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(139, 41);
            this.btn_Reset.TabIndex = 7;
            this.btn_Reset.Text = "机械手复位";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Reset_MouseDown);
            this.btn_Reset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Reset_MouseUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(494, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 19);
            this.label14.TabIndex = 9;
            this.label14.Text = "当前位置：";
            // 
            // btn_EnableRobot
            // 
            this.btn_EnableRobot.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_EnableRobot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_EnableRobot.Location = new System.Drawing.Point(183, 85);
            this.btn_EnableRobot.Name = "btn_EnableRobot";
            this.btn_EnableRobot.Size = new System.Drawing.Size(139, 41);
            this.btn_EnableRobot.TabIndex = 8;
            this.btn_EnableRobot.Text = "机械手使能";
            this.btn_EnableRobot.UseVisualStyleBackColor = false;
            this.btn_EnableRobot.Click += new System.EventHandler(this.btn_EnableRobot_Click);
            // 
            // btn_Zero
            // 
            this.btn_Zero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Zero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Zero.Location = new System.Drawing.Point(18, 22);
            this.btn_Zero.Name = "btn_Zero";
            this.btn_Zero.Size = new System.Drawing.Size(139, 41);
            this.btn_Zero.TabIndex = 1;
            this.btn_Zero.Text = "回零";
            this.btn_Zero.UseVisualStyleBackColor = false;
            this.btn_Zero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Zero_MouseDown);
            this.btn_Zero.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Zero_MouseUp);
            // 
            // btn_forward
            // 
            this.btn_forward.BackColor = System.Drawing.Color.Silver;
            this.btn_forward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_forward.Location = new System.Drawing.Point(19, 86);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(139, 41);
            this.btn_forward.TabIndex = 2;
            this.btn_forward.Text = "正转";
            this.btn_forward.UseVisualStyleBackColor = false;
            this.btn_forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_forward_MouseDown);
            this.btn_forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_forward_MouseUp);
            // 
            // btn_backward
            // 
            this.btn_backward.BackColor = System.Drawing.Color.Silver;
            this.btn_backward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_backward.Location = new System.Drawing.Point(19, 142);
            this.btn_backward.Name = "btn_backward";
            this.btn_backward.Size = new System.Drawing.Size(139, 41);
            this.btn_backward.TabIndex = 3;
            this.btn_backward.Text = "反转";
            this.btn_backward.UseVisualStyleBackColor = false;
            this.btn_backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_backward_MouseDown);
            this.btn_backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_backward_MouseUp);
            // 
            // btn_Trigger
            // 
            this.btn_Trigger.BackColor = System.Drawing.Color.Silver;
            this.btn_Trigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Trigger.Location = new System.Drawing.Point(18, 208);
            this.btn_Trigger.Name = "btn_Trigger";
            this.btn_Trigger.Size = new System.Drawing.Size(139, 41);
            this.btn_Trigger.TabIndex = 4;
            this.btn_Trigger.Text = "定位触发";
            this.btn_Trigger.UseVisualStyleBackColor = false;
            this.btn_Trigger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Trigger_MouseDown);
            this.btn_Trigger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Trigger_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("楷体", 15.75F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(22, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 21);
            this.label10.TabIndex = 347;
            this.label10.Text = "手动给取料坐标X--Y：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("楷体", 15.75F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(23, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 21);
            this.label9.TabIndex = 346;
            this.label9.Text = "强制检测结果：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(191, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 27);
            this.comboBox1.TabIndex = 342;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cMStrip_SocketMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //   private System.Windows.Forms.ListBox ListBox_Socketpick;
        private System.Windows.Forms.Label lblDetectCam1;
        private System.Windows.Forms.Label lblConnectedCam1;
        private System.Windows.Forms.Label lblConnectedCam2;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label lblDetectCam2;
        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbproductselect;
        private System.Windows.Forms.ToolStripButton tsbCameraConfig;
        private System.Windows.Forms.ToolStripButton tsbparaSet;
        private System.Windows.Forms.ToolStripButton tsbsystemSet;
        private System.Windows.Forms.ToolStripButton tsbhelpDoc;
        private System.Windows.Forms.ToolStripButton tsbcontactus;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton tsbOnline;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripButton tsB_socket;
        public System.Windows.Forms.ToolStripButton tSB_softTrigger;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsB_CalibrateCoordinate;
      //  private System.Windows.Forms.Label lbl_ccd1imagenum;
       // private System.Windows.Forms.Label lbl_ccd2imagenum;
        private System.Windows.Forms.ToolStripButton tsB_Stop;
        private System.Windows.Forms.ToolStripButton tsb_NormalWin;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ComboBox comB_SaveImage;
        private System.Windows.Forms.ContextMenuStrip cMStrip_SocketMessage;
        private System.Windows.Forms.ToolStripMenuItem Clear_message_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToRobortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToLensToolStripMenuItem;
        private HalconDotNet.HWindowControl hWindowControlR;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer_statistics;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.ListBox listBox_pick1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem send测试结果ToRobortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem send坐标2ToRobortToolStripMenuItem;
        private System.Windows.Forms.Label lbl_ccd1imagenum;
        private System.Windows.Forms.Label lbl_ccd2imagenum;
        private System.Windows.Forms.Timer timer_authority;
        private System.Windows.Forms.TextBox textBox_ccdY;
        private System.Windows.Forms.TextBox textBox_ccdX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Timer timer_test;
        private System.Windows.Forms.Label label_socket1;
        private System.Windows.Forms.Label label_socket2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton tpB_PLCSetup;
        private HalconDotNet.HWindowControl hWindowControlL;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbl_timedisp;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label Lab_PC2RobortSocket;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lab_PLCheartbeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_RobotAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_PLC_heartbeat;
        private System.Windows.Forms.Button btn_RobotVcuumAlarm;
        private System.Windows.Forms.Button btn_vacuum1_Now;
        private System.Windows.Forms.Button btn_vacuum2_Now;
        private System.Windows.Forms.Button btn_SaveDoorAlarm;
        private System.Windows.Forms.Button btn_SocketRobortAlarm;
        private System.Windows.Forms.Button btn_CrcleAxiAlarm;
        private System.Windows.Forms.Button btn_Differentialcylinder;
        private System.Windows.Forms.Button btn_GoAimPosition;
        private System.Windows.Forms.Button btn_SetSpeed;
        private System.Windows.Forms.Button btn_PLCAddPara;
        private System.Windows.Forms.TextBox txB_AimPosition;
        private System.Windows.Forms.Button btn_GetPositionNow;
        private System.Windows.Forms.TextBox txB_Speed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_vacuum2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_EnableMotion;
        private System.Windows.Forms.Button btn_SafeDoor;
        private System.Windows.Forms.Button btn_vacuum1;
        private System.Windows.Forms.Label label_PositionNow;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_EnableRobot;
        private System.Windows.Forms.Button btn_Zero;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.Button btn_backward;
        private System.Windows.Forms.Button btn_Trigger;
        private System.Windows.Forms.Button btn_TrayOver;
        private System.Windows.Forms.Button btn_testpirchart;

    }
}

