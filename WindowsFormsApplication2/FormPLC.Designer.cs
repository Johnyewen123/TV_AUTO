namespace WindowsFormsApplication2
{
    partial class FormPLC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPLC));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_angleZero = new System.Windows.Forms.Button();
            this.txb_angle = new System.Windows.Forms.TextBox();
            this.btn_angle = new System.Windows.Forms.Button();
            this.btn_PLCAddPara = new System.Windows.Forms.Button();
            this.btn_SafeDoor = new System.Windows.Forms.Button();
            this.btn_Differentialcylinder = new System.Windows.Forms.Button();
            this.btn_EnableRobot = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_vacuum1 = new System.Windows.Forms.Button();
            this.btn_vacuum2 = new System.Windows.Forms.Button();
            this.btn_Trigger = new System.Windows.Forms.Button();
            this.btn_backward = new System.Windows.Forms.Button();
            this.btn_forward = new System.Windows.Forms.Button();
            this.btn_Zero = new System.Windows.Forms.Button();
            this.btn_EnableMotion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_PLC_heartbeat = new System.Windows.Forms.Button();
            this.btn_vacuum2_Now = new System.Windows.Forms.Button();
            this.btn_vacuum1_Now = new System.Windows.Forms.Button();
            this.btn_SocketRobortAlarm = new System.Windows.Forms.Button();
            this.btn_SaveDoorAlarm = new System.Windows.Forms.Button();
            this.btn_CrcleAxiAlarm = new System.Windows.Forms.Button();
            this.btn_RobotVcuumAlarm = new System.Windows.Forms.Button();
            this.btn_RobotAlarm = new System.Windows.Forms.Button();
            this.btn_SetSpeed = new System.Windows.Forms.Button();
            this.txB_Speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txB_AimPosition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_PositionNow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_GoAimPosition = new System.Windows.Forms.Button();
            this.btn_GetPositionNow = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_angleZero);
            this.groupBox1.Controls.Add(this.txb_angle);
            this.groupBox1.Controls.Add(this.btn_angle);
            this.groupBox1.Controls.Add(this.btn_PLCAddPara);
            this.groupBox1.Controls.Add(this.btn_SafeDoor);
            this.groupBox1.Controls.Add(this.btn_Differentialcylinder);
            this.groupBox1.Controls.Add(this.btn_EnableRobot);
            this.groupBox1.Controls.Add(this.btn_Reset);
            this.groupBox1.Controls.Add(this.btn_vacuum1);
            this.groupBox1.Controls.Add(this.btn_vacuum2);
            this.groupBox1.Controls.Add(this.btn_Trigger);
            this.groupBox1.Controls.Add(this.btn_backward);
            this.groupBox1.Controls.Add(this.btn_forward);
            this.groupBox1.Controls.Add(this.btn_Zero);
            this.groupBox1.Controls.Add(this.btn_EnableMotion);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 588);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电动吸嘴旋转";
            // 
            // btn_angleZero
            // 
            this.btn_angleZero.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_angleZero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_angleZero.Location = new System.Drawing.Point(151, 500);
            this.btn_angleZero.Name = "btn_angleZero";
            this.btn_angleZero.Size = new System.Drawing.Size(139, 41);
            this.btn_angleZero.TabIndex = 17;
            this.btn_angleZero.Text = "回零";
            this.btn_angleZero.UseVisualStyleBackColor = false;
            this.btn_angleZero.Click += new System.EventHandler(this.btn_angleZero_Click);
            // 
            // txb_angle
            // 
            this.txb_angle.Location = new System.Drawing.Point(18, 460);
            this.txb_angle.Name = "txb_angle";
            this.txb_angle.Size = new System.Drawing.Size(100, 30);
            this.txb_angle.TabIndex = 16;
            // 
            // btn_angle
            // 
            this.btn_angle.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_angle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_angle.Location = new System.Drawing.Point(151, 453);
            this.btn_angle.Name = "btn_angle";
            this.btn_angle.Size = new System.Drawing.Size(139, 41);
            this.btn_angle.TabIndex = 15;
            this.btn_angle.Text = "旋转";
            this.btn_angle.UseVisualStyleBackColor = false;
            this.btn_angle.Click += new System.EventHandler(this.btn_angle_Click);
            // 
            // btn_PLCAddPara
            // 
            this.btn_PLCAddPara.BackColor = System.Drawing.Color.Green;
            this.btn_PLCAddPara.Location = new System.Drawing.Point(151, 363);
            this.btn_PLCAddPara.Name = "btn_PLCAddPara";
            this.btn_PLCAddPara.Size = new System.Drawing.Size(146, 56);
            this.btn_PLCAddPara.TabIndex = 11;
            this.btn_PLCAddPara.Text = "PLC地址配置";
            this.btn_PLCAddPara.UseVisualStyleBackColor = false;
            this.btn_PLCAddPara.Click += new System.EventHandler(this.btn_PLCAddPara_Click);
            // 
            // btn_SafeDoor
            // 
            this.btn_SafeDoor.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_SafeDoor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SafeDoor.Location = new System.Drawing.Point(6, 352);
            this.btn_SafeDoor.Name = "btn_SafeDoor";
            this.btn_SafeDoor.Size = new System.Drawing.Size(139, 41);
            this.btn_SafeDoor.TabIndex = 10;
            this.btn_SafeDoor.Text = "安全门屏蔽";
            this.btn_SafeDoor.UseVisualStyleBackColor = false;
            this.btn_SafeDoor.Click += new System.EventHandler(this.btn_SafeDoor_Click);
            // 
            // btn_Differentialcylinder
            // 
            this.btn_Differentialcylinder.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_Differentialcylinder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Differentialcylinder.Location = new System.Drawing.Point(151, 282);
            this.btn_Differentialcylinder.Name = "btn_Differentialcylinder";
            this.btn_Differentialcylinder.Size = new System.Drawing.Size(139, 41);
            this.btn_Differentialcylinder.TabIndex = 9;
            this.btn_Differentialcylinder.Text = "高度差气缸";
            this.btn_Differentialcylinder.UseVisualStyleBackColor = false;
            this.btn_Differentialcylinder.Click += new System.EventHandler(this.btn_Differentialcylinder_Click);
            // 
            // btn_EnableRobot
            // 
            this.btn_EnableRobot.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_EnableRobot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_EnableRobot.Location = new System.Drawing.Point(151, 29);
            this.btn_EnableRobot.Name = "btn_EnableRobot";
            this.btn_EnableRobot.Size = new System.Drawing.Size(139, 41);
            this.btn_EnableRobot.TabIndex = 8;
            this.btn_EnableRobot.Text = "机械手使能";
            this.btn_EnableRobot.UseVisualStyleBackColor = false;
            this.btn_EnableRobot.Click += new System.EventHandler(this.btn_EnableRobot_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Reset.Location = new System.Drawing.Point(151, 85);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(139, 41);
            this.btn_Reset.TabIndex = 7;
            this.btn_Reset.Text = "机械手复位";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            this.btn_Reset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Reset_MouseDown);
            this.btn_Reset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Reset_MouseUp);
            // 
            // btn_vacuum1
            // 
            this.btn_vacuum1.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_vacuum1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_vacuum1.Location = new System.Drawing.Point(151, 147);
            this.btn_vacuum1.Name = "btn_vacuum1";
            this.btn_vacuum1.Size = new System.Drawing.Size(139, 41);
            this.btn_vacuum1.TabIndex = 6;
            this.btn_vacuum1.Text = "真空1";
            this.btn_vacuum1.UseVisualStyleBackColor = false;
            this.btn_vacuum1.Click += new System.EventHandler(this.btn_vacuum1_Click);
            // 
            // btn_vacuum2
            // 
            this.btn_vacuum2.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_vacuum2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_vacuum2.Location = new System.Drawing.Point(151, 216);
            this.btn_vacuum2.Name = "btn_vacuum2";
            this.btn_vacuum2.Size = new System.Drawing.Size(139, 41);
            this.btn_vacuum2.TabIndex = 5;
            this.btn_vacuum2.Text = "真空2";
            this.btn_vacuum2.UseVisualStyleBackColor = false;
            this.btn_vacuum2.Click += new System.EventHandler(this.btn_vacuum2_Click);
            // 
            // btn_Trigger
            // 
            this.btn_Trigger.BackColor = System.Drawing.Color.Silver;
            this.btn_Trigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Trigger.Location = new System.Drawing.Point(6, 282);
            this.btn_Trigger.Name = "btn_Trigger";
            this.btn_Trigger.Size = new System.Drawing.Size(139, 41);
            this.btn_Trigger.TabIndex = 4;
            this.btn_Trigger.Text = "定位触发";
            this.btn_Trigger.UseVisualStyleBackColor = false;
            this.btn_Trigger.Click += new System.EventHandler(this.btn_Trigger_Click);
            this.btn_Trigger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Trigger_MouseDown);
            this.btn_Trigger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Trigger_MouseUp);
            // 
            // btn_backward
            // 
            this.btn_backward.BackColor = System.Drawing.Color.Silver;
            this.btn_backward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_backward.Location = new System.Drawing.Point(6, 216);
            this.btn_backward.Name = "btn_backward";
            this.btn_backward.Size = new System.Drawing.Size(139, 41);
            this.btn_backward.TabIndex = 3;
            this.btn_backward.Text = "反转";
            this.btn_backward.UseVisualStyleBackColor = false;
            this.btn_backward.Click += new System.EventHandler(this.btn_backward_Click);
            this.btn_backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_backward_MouseDown);
            this.btn_backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_backward_MouseUp);
            // 
            // btn_forward
            // 
            this.btn_forward.BackColor = System.Drawing.Color.Silver;
            this.btn_forward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_forward.Location = new System.Drawing.Point(6, 147);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(139, 41);
            this.btn_forward.TabIndex = 2;
            this.btn_forward.Text = "正转";
            this.btn_forward.UseVisualStyleBackColor = false;
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            this.btn_forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_forward_MouseDown);
            this.btn_forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_forward_MouseUp);
            // 
            // btn_Zero
            // 
            this.btn_Zero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Zero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Zero.Location = new System.Drawing.Point(6, 85);
            this.btn_Zero.Name = "btn_Zero";
            this.btn_Zero.Size = new System.Drawing.Size(139, 41);
            this.btn_Zero.TabIndex = 1;
            this.btn_Zero.Text = "回零";
            this.btn_Zero.UseVisualStyleBackColor = false;
            this.btn_Zero.Click += new System.EventHandler(this.btn_Zero_Click);
            this.btn_Zero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Zero_MouseDown);
            this.btn_Zero.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Zero_MouseUp);
            // 
            // btn_EnableMotion
            // 
            this.btn_EnableMotion.BackColor = System.Drawing.Color.Silver;
            this.btn_EnableMotion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_EnableMotion.Location = new System.Drawing.Point(6, 29);
            this.btn_EnableMotion.Name = "btn_EnableMotion";
            this.btn_EnableMotion.Size = new System.Drawing.Size(139, 41);
            this.btn_EnableMotion.TabIndex = 0;
            this.btn_EnableMotion.Text = "电机使能";
            this.btn_EnableMotion.UseVisualStyleBackColor = false;
            this.btn_EnableMotion.Click += new System.EventHandler(this.btn_EnableMotion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btn_SetSpeed);
            this.groupBox2.Controls.Add(this.txB_Speed);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txB_AimPosition);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label_PositionNow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_GoAimPosition);
            this.groupBox2.Controls.Add(this.btn_GetPositionNow);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(353, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 588);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动调试";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_PLC_heartbeat);
            this.groupBox3.Controls.Add(this.btn_vacuum2_Now);
            this.groupBox3.Controls.Add(this.btn_vacuum1_Now);
            this.groupBox3.Controls.Add(this.btn_SocketRobortAlarm);
            this.groupBox3.Controls.Add(this.btn_SaveDoorAlarm);
            this.groupBox3.Controls.Add(this.btn_CrcleAxiAlarm);
            this.groupBox3.Controls.Add(this.btn_RobotVcuumAlarm);
            this.groupBox3.Controls.Add(this.btn_RobotAlarm);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(6, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 394);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "报警以及状态显示";
            // 
            // btn_PLC_heartbeat
            // 
            this.btn_PLC_heartbeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_PLC_heartbeat.Location = new System.Drawing.Point(43, 352);
            this.btn_PLC_heartbeat.Name = "btn_PLC_heartbeat";
            this.btn_PLC_heartbeat.Size = new System.Drawing.Size(308, 36);
            this.btn_PLC_heartbeat.TabIndex = 7;
            this.btn_PLC_heartbeat.Text = "PLC心跳报警";
            this.btn_PLC_heartbeat.UseVisualStyleBackColor = false;
            // 
            // btn_vacuum2_Now
            // 
            this.btn_vacuum2_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_vacuum2_Now.Location = new System.Drawing.Point(43, 304);
            this.btn_vacuum2_Now.Name = "btn_vacuum2_Now";
            this.btn_vacuum2_Now.Size = new System.Drawing.Size(308, 36);
            this.btn_vacuum2_Now.TabIndex = 6;
            this.btn_vacuum2_Now.Text = "真空信号2";
            this.btn_vacuum2_Now.UseVisualStyleBackColor = false;
            // 
            // btn_vacuum1_Now
            // 
            this.btn_vacuum1_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_vacuum1_Now.Location = new System.Drawing.Point(43, 254);
            this.btn_vacuum1_Now.Name = "btn_vacuum1_Now";
            this.btn_vacuum1_Now.Size = new System.Drawing.Size(308, 36);
            this.btn_vacuum1_Now.TabIndex = 5;
            this.btn_vacuum1_Now.Text = "真空信号1";
            this.btn_vacuum1_Now.UseVisualStyleBackColor = false;
            // 
            // btn_SocketRobortAlarm
            // 
            this.btn_SocketRobortAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_SocketRobortAlarm.Location = new System.Drawing.Point(43, 209);
            this.btn_SocketRobortAlarm.Name = "btn_SocketRobortAlarm";
            this.btn_SocketRobortAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_SocketRobortAlarm.TabIndex = 4;
            this.btn_SocketRobortAlarm.Text = "与机械手网口连接报警";
            this.btn_SocketRobortAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_SaveDoorAlarm
            // 
            this.btn_SaveDoorAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_SaveDoorAlarm.Location = new System.Drawing.Point(43, 165);
            this.btn_SaveDoorAlarm.Name = "btn_SaveDoorAlarm";
            this.btn_SaveDoorAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_SaveDoorAlarm.TabIndex = 3;
            this.btn_SaveDoorAlarm.Text = "安全门报警";
            this.btn_SaveDoorAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_CrcleAxiAlarm
            // 
            this.btn_CrcleAxiAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_CrcleAxiAlarm.Location = new System.Drawing.Point(43, 118);
            this.btn_CrcleAxiAlarm.Name = "btn_CrcleAxiAlarm";
            this.btn_CrcleAxiAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_CrcleAxiAlarm.TabIndex = 2;
            this.btn_CrcleAxiAlarm.Text = "旋转轴报警";
            this.btn_CrcleAxiAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_RobotVcuumAlarm
            // 
            this.btn_RobotVcuumAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_RobotVcuumAlarm.Location = new System.Drawing.Point(43, 72);
            this.btn_RobotVcuumAlarm.Name = "btn_RobotVcuumAlarm";
            this.btn_RobotVcuumAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_RobotVcuumAlarm.TabIndex = 1;
            this.btn_RobotVcuumAlarm.Text = "机械手吸附真空异常";
            this.btn_RobotVcuumAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_RobotAlarm
            // 
            this.btn_RobotAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_RobotAlarm.Location = new System.Drawing.Point(43, 30);
            this.btn_RobotAlarm.Name = "btn_RobotAlarm";
            this.btn_RobotAlarm.Size = new System.Drawing.Size(308, 36);
            this.btn_RobotAlarm.TabIndex = 0;
            this.btn_RobotAlarm.Text = "机械手报警";
            this.btn_RobotAlarm.UseVisualStyleBackColor = false;
            // 
            // btn_SetSpeed
            // 
            this.btn_SetSpeed.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_SetSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_SetSpeed.Location = new System.Drawing.Point(241, 82);
            this.btn_SetSpeed.Name = "btn_SetSpeed";
            this.btn_SetSpeed.Size = new System.Drawing.Size(139, 41);
            this.btn_SetSpeed.TabIndex = 15;
            this.btn_SetSpeed.Text = "设置当前速度";
            this.btn_SetSpeed.UseVisualStyleBackColor = false;
            this.btn_SetSpeed.Click += new System.EventHandler(this.btn_SetSpeed_Click);
            // 
            // txB_Speed
            // 
            this.txB_Speed.Location = new System.Drawing.Point(131, 88);
            this.txB_Speed.Name = "txB_Speed";
            this.txB_Speed.Size = new System.Drawing.Size(100, 30);
            this.txB_Speed.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "手动速度：";
            // 
            // txB_AimPosition
            // 
            this.txB_AimPosition.Location = new System.Drawing.Point(131, 142);
            this.txB_AimPosition.Name = "txB_AimPosition";
            this.txB_AimPosition.Size = new System.Drawing.Size(100, 30);
            this.txB_AimPosition.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "目标位置：";
            // 
            // label_PositionNow
            // 
            this.label_PositionNow.AutoSize = true;
            this.label_PositionNow.Location = new System.Drawing.Point(129, 39);
            this.label_PositionNow.Name = "label_PositionNow";
            this.label_PositionNow.Size = new System.Drawing.Size(89, 20);
            this.label_PositionNow.TabIndex = 10;
            this.label_PositionNow.Text = "————";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "当前位置：";
            // 
            // btn_GoAimPosition
            // 
            this.btn_GoAimPosition.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_GoAimPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GoAimPosition.Location = new System.Drawing.Point(239, 137);
            this.btn_GoAimPosition.Name = "btn_GoAimPosition";
            this.btn_GoAimPosition.Size = new System.Drawing.Size(139, 41);
            this.btn_GoAimPosition.TabIndex = 8;
            this.btn_GoAimPosition.Text = "到目标位置";
            this.btn_GoAimPosition.UseVisualStyleBackColor = false;
            this.btn_GoAimPosition.Click += new System.EventHandler(this.btn_GoAimPosition_Click);
            // 
            // btn_GetPositionNow
            // 
            this.btn_GetPositionNow.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_GetPositionNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_GetPositionNow.Location = new System.Drawing.Point(241, 28);
            this.btn_GetPositionNow.Name = "btn_GetPositionNow";
            this.btn_GetPositionNow.Size = new System.Drawing.Size(139, 41);
            this.btn_GetPositionNow.TabIndex = 0;
            this.btn_GetPositionNow.Text = "获取当前位置";
            this.btn_GetPositionNow.UseVisualStyleBackColor = false;
            this.btn_GetPositionNow.Click += new System.EventHandler(this.btn_GetPositionNow_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(785, 612);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPLC";
            this.Text = "PLC控制";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SafeDoor;
        private System.Windows.Forms.Button btn_Differentialcylinder;
        private System.Windows.Forms.Button btn_EnableRobot;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_vacuum1;
        private System.Windows.Forms.Button btn_vacuum2;
        private System.Windows.Forms.Button btn_Trigger;
        private System.Windows.Forms.Button btn_backward;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.Button btn_Zero;
        private System.Windows.Forms.Button btn_EnableMotion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_PLC_heartbeat;
        private System.Windows.Forms.Button btn_vacuum2_Now;
        private System.Windows.Forms.Button btn_vacuum1_Now;
        private System.Windows.Forms.Button btn_SocketRobortAlarm;
        private System.Windows.Forms.Button btn_SaveDoorAlarm;
        private System.Windows.Forms.Button btn_CrcleAxiAlarm;
        private System.Windows.Forms.Button btn_RobotVcuumAlarm;
        private System.Windows.Forms.Button btn_RobotAlarm;
        private System.Windows.Forms.Button btn_SetSpeed;
        private System.Windows.Forms.TextBox txB_Speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txB_AimPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_PositionNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_GoAimPosition;
        private System.Windows.Forms.Button btn_GetPositionNow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_PLCAddPara;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_angleZero;
        private System.Windows.Forms.TextBox txb_angle;
        private System.Windows.Forms.Button btn_angle;

    }
}