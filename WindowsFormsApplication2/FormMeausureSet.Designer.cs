namespace WindowsFormsApplication2
{
    partial class FormMeausureSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeausureSet));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_ThresholdSecondLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Ty2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ScaleY2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Phi2 = new System.Windows.Forms.TextBox();
            this.txt_Tx2 = new System.Windows.Forms.TextBox();
            this.txt_Theta2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ScaleX2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txB_ThresholdPut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ThresholdPick = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Tx1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ScaleY1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Ty1 = new System.Windows.Forms.TextBox();
            this.txt_Theta1 = new System.Windows.Forms.TextBox();
            this.txB_Phi1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_ScaleX1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton_Location2 = new System.Windows.Forms.RadioButton();
            this.btn_SaveImage = new System.Windows.Forms.Button();
            this.btn_ApplyPara = new System.Windows.Forms.Button();
            this.btn_SavePara = new System.Windows.Forms.Button();
            this.btn_TestImage = new System.Windows.Forms.Button();
            this.BSideradioButton = new System.Windows.Forms.RadioButton();
            this.ASideradioButton = new System.Windows.Forms.RadioButton();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.hWindowControl_test = new HalconDotNet.HWindowControl();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1370, 722);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1362, 696);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "离线测试";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(29, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 509);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "算法参数";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_ThresholdSecondLocation);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_Ty2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_ScaleY2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_Phi2);
            this.groupBox3.Controls.Add(this.txt_Tx2);
            this.groupBox3.Controls.Add(this.txt_Theta2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_ScaleX2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(18, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 208);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // txt_ThresholdSecondLocation
            // 
            this.txt_ThresholdSecondLocation.Location = new System.Drawing.Point(112, 160);
            this.txt_ThresholdSecondLocation.Name = "txt_ThresholdSecondLocation";
            this.txt_ThresholdSecondLocation.Size = new System.Drawing.Size(100, 31);
            this.txt_ThresholdSecondLocation.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Threshod:";
            // 
            // txt_Ty2
            // 
            this.txt_Ty2.Location = new System.Drawing.Point(314, 122);
            this.txt_Ty2.Name = "txt_Ty2";
            this.txt_Ty2.Size = new System.Drawing.Size(100, 31);
            this.txt_Ty2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(218, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "TranY:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Teal;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(218, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "TranX:";
            // 
            // txt_ScaleY2
            // 
            this.txt_ScaleY2.Location = new System.Drawing.Point(112, 81);
            this.txt_ScaleY2.Name = "txt_ScaleY2";
            this.txt_ScaleY2.Size = new System.Drawing.Size(100, 31);
            this.txt_ScaleY2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Teal;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(11, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "ScaleY:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Teal;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(218, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Theta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "CCD2初始九点标定参数";
            // 
            // txt_Phi2
            // 
            this.txt_Phi2.Location = new System.Drawing.Point(112, 122);
            this.txt_Phi2.Name = "txt_Phi2";
            this.txt_Phi2.Size = new System.Drawing.Size(100, 31);
            this.txt_Phi2.TabIndex = 7;
            // 
            // txt_Tx2
            // 
            this.txt_Tx2.Location = new System.Drawing.Point(314, 79);
            this.txt_Tx2.Name = "txt_Tx2";
            this.txt_Tx2.Size = new System.Drawing.Size(100, 31);
            this.txt_Tx2.TabIndex = 6;
            // 
            // txt_Theta2
            // 
            this.txt_Theta2.Location = new System.Drawing.Point(314, 39);
            this.txt_Theta2.Name = "txt_Theta2";
            this.txt_Theta2.Size = new System.Drawing.Size(100, 31);
            this.txt_Theta2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Teal;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(11, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Phi:";
            // 
            // txt_ScaleX2
            // 
            this.txt_ScaleX2.Location = new System.Drawing.Point(112, 41);
            this.txt_ScaleX2.Name = "txt_ScaleX2";
            this.txt_ScaleX2.Size = new System.Drawing.Size(100, 31);
            this.txt_ScaleX2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Teal;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(11, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "ScaleX:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txB_ThresholdPut);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txt_ThresholdPick);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txt_Tx1);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txt_ScaleY1);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txt_Ty1);
            this.groupBox4.Controls.Add(this.txt_Theta1);
            this.groupBox4.Controls.Add(this.txB_Phi1);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txt_ScaleX1);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(18, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(546, 215);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // txB_ThresholdPut
            // 
            this.txB_ThresholdPut.Location = new System.Drawing.Point(434, 173);
            this.txB_ThresholdPut.Name = "txB_ThresholdPut";
            this.txB_ThresholdPut.Size = new System.Drawing.Size(100, 31);
            this.txB_ThresholdPut.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(289, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Threshodput:";
            // 
            // txt_ThresholdPick
            // 
            this.txt_ThresholdPick.Location = new System.Drawing.Point(171, 173);
            this.txt_ThresholdPick.Name = "txt_ThresholdPick";
            this.txt_ThresholdPick.Size = new System.Drawing.Size(100, 31);
            this.txt_ThresholdPick.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Teal;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(11, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "Threshodpick:";
            // 
            // txt_Tx1
            // 
            this.txt_Tx1.Location = new System.Drawing.Point(294, 83);
            this.txt_Tx1.Name = "txt_Tx1";
            this.txt_Tx1.Size = new System.Drawing.Size(100, 31);
            this.txt_Tx1.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Teal;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(218, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 19);
            this.label12.TabIndex = 13;
            this.label12.Text = "TranY:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Teal;
            this.label13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(218, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "TranX:";
            // 
            // txt_ScaleY1
            // 
            this.txt_ScaleY1.Location = new System.Drawing.Point(111, 78);
            this.txt_ScaleY1.Name = "txt_ScaleY1";
            this.txt_ScaleY1.Size = new System.Drawing.Size(100, 31);
            this.txt_ScaleY1.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Teal;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(11, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 19);
            this.label14.TabIndex = 10;
            this.label14.Text = "ScaleY:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Teal;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(218, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 19);
            this.label15.TabIndex = 9;
            this.label15.Text = "Theta:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(11, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(209, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "CCD1初始九点标定参数";
            // 
            // txt_Ty1
            // 
            this.txt_Ty1.Location = new System.Drawing.Point(293, 122);
            this.txt_Ty1.Name = "txt_Ty1";
            this.txt_Ty1.Size = new System.Drawing.Size(100, 31);
            this.txt_Ty1.TabIndex = 7;
            // 
            // txt_Theta1
            // 
            this.txt_Theta1.Location = new System.Drawing.Point(295, 43);
            this.txt_Theta1.Name = "txt_Theta1";
            this.txt_Theta1.Size = new System.Drawing.Size(100, 31);
            this.txt_Theta1.TabIndex = 6;
            // 
            // txB_Phi1
            // 
            this.txB_Phi1.Location = new System.Drawing.Point(111, 122);
            this.txB_Phi1.Name = "txB_Phi1";
            this.txB_Phi1.Size = new System.Drawing.Size(100, 31);
            this.txB_Phi1.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Teal;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(11, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 19);
            this.label17.TabIndex = 2;
            this.label17.Text = "Phi:";
            // 
            // txt_ScaleX1
            // 
            this.txt_ScaleX1.Location = new System.Drawing.Point(111, 41);
            this.txt_ScaleX1.Name = "txt_ScaleX1";
            this.txt_ScaleX1.Size = new System.Drawing.Size(100, 31);
            this.txt_ScaleX1.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Teal;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(11, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 19);
            this.label18.TabIndex = 0;
            this.label18.Text = "ScaleX:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radioButton_Location2);
            this.groupBox8.Controls.Add(this.btn_SaveImage);
            this.groupBox8.Controls.Add(this.btn_ApplyPara);
            this.groupBox8.Controls.Add(this.btn_SavePara);
            this.groupBox8.Controls.Add(this.btn_TestImage);
            this.groupBox8.Controls.Add(this.BSideradioButton);
            this.groupBox8.Controls.Add(this.ASideradioButton);
            this.groupBox8.Controls.Add(this.btn_LoadImage);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(608, 162);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            // 
            // radioButton_Location2
            // 
            this.radioButton_Location2.AutoSize = true;
            this.radioButton_Location2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Location2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioButton_Location2.Location = new System.Drawing.Point(194, 25);
            this.radioButton_Location2.Name = "radioButton_Location2";
            this.radioButton_Location2.Size = new System.Drawing.Size(107, 23);
            this.radioButton_Location2.TabIndex = 7;
            this.radioButton_Location2.TabStop = true;
            this.radioButton_Location2.Text = "二次定位";
            this.radioButton_Location2.UseVisualStyleBackColor = true;
            this.radioButton_Location2.Click += new System.EventHandler(this.radioButton_Location2_Click);
            // 
            // btn_SaveImage
            // 
            this.btn_SaveImage.Location = new System.Drawing.Point(464, 25);
            this.btn_SaveImage.Name = "btn_SaveImage";
            this.btn_SaveImage.Size = new System.Drawing.Size(123, 43);
            this.btn_SaveImage.TabIndex = 6;
            this.btn_SaveImage.Text = "保存图像";
            this.btn_SaveImage.UseVisualStyleBackColor = true;
            this.btn_SaveImage.Click += new System.EventHandler(this.btn_SaveImage_Click);
            // 
            // btn_ApplyPara
            // 
            this.btn_ApplyPara.Location = new System.Drawing.Point(318, 96);
            this.btn_ApplyPara.Name = "btn_ApplyPara";
            this.btn_ApplyPara.Size = new System.Drawing.Size(123, 43);
            this.btn_ApplyPara.TabIndex = 5;
            this.btn_ApplyPara.Text = "应用参数";
            this.btn_ApplyPara.UseVisualStyleBackColor = true;
            this.btn_ApplyPara.Click += new System.EventHandler(this.btn_ApplyPara_Click);
            // 
            // btn_SavePara
            // 
            this.btn_SavePara.Location = new System.Drawing.Point(464, 96);
            this.btn_SavePara.Name = "btn_SavePara";
            this.btn_SavePara.Size = new System.Drawing.Size(123, 43);
            this.btn_SavePara.TabIndex = 4;
            this.btn_SavePara.Text = "保存参数";
            this.btn_SavePara.UseVisualStyleBackColor = true;
            this.btn_SavePara.Click += new System.EventHandler(this.btn_SavePara_Click);
            // 
            // btn_TestImage
            // 
            this.btn_TestImage.Location = new System.Drawing.Point(175, 96);
            this.btn_TestImage.Name = "btn_TestImage";
            this.btn_TestImage.Size = new System.Drawing.Size(123, 43);
            this.btn_TestImage.TabIndex = 3;
            this.btn_TestImage.Text = "测试图像";
            this.btn_TestImage.UseVisualStyleBackColor = true;
            this.btn_TestImage.Click += new System.EventHandler(this.btn_TestImage_Click);
            // 
            // BSideradioButton
            // 
            this.BSideradioButton.AutoSize = true;
            this.BSideradioButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BSideradioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BSideradioButton.Location = new System.Drawing.Point(108, 25);
            this.BSideradioButton.Name = "BSideradioButton";
            this.BSideradioButton.Size = new System.Drawing.Size(67, 23);
            this.BSideradioButton.TabIndex = 2;
            this.BSideradioButton.TabStop = true;
            this.BSideradioButton.Text = "下料";
            this.BSideradioButton.UseVisualStyleBackColor = true;
            this.BSideradioButton.Click += new System.EventHandler(this.BSideradioButton_Click);
            // 
            // ASideradioButton
            // 
            this.ASideradioButton.AutoSize = true;
            this.ASideradioButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ASideradioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ASideradioButton.Location = new System.Drawing.Point(23, 25);
            this.ASideradioButton.Name = "ASideradioButton";
            this.ASideradioButton.Size = new System.Drawing.Size(67, 23);
            this.ASideradioButton.TabIndex = 1;
            this.ASideradioButton.TabStop = true;
            this.ASideradioButton.Text = "上料";
            this.ASideradioButton.UseVisualStyleBackColor = true;
            this.ASideradioButton.Click += new System.EventHandler(this.ASideradioButton_Click);
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Location = new System.Drawing.Point(23, 96);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(123, 43);
            this.btn_LoadImage.TabIndex = 0;
            this.btn_LoadImage.Text = "加载图像";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.btn_LoadImage_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.hWindowControl_test);
            this.groupBox9.Location = new System.Drawing.Point(643, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(704, 671);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            // 
            // hWindowControl_test
            // 
            this.hWindowControl_test.BackColor = System.Drawing.Color.Black;
            this.hWindowControl_test.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl_test.ImagePart = new System.Drawing.Rectangle(0, 0, 2592, 1944);
            this.hWindowControl_test.Location = new System.Drawing.Point(6, 12);
            this.hWindowControl_test.Name = "hWindowControl_test";
            this.hWindowControl_test.Size = new System.Drawing.Size(692, 653);
            this.hWindowControl_test.TabIndex = 1;
            this.hWindowControl_test.WindowSize = new System.Drawing.Size(692, 653);
            this.hWindowControl_test.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl_test_HMouseMove);
            this.hWindowControl_test.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl_test_HMouseDown);
            this.hWindowControl_test.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl_test_HMouseUp);
            this.hWindowControl_test.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.hWindowControl_test_HMouseWheel);
            // 
            // FormMeausureSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1497, 762);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMeausureSet";
            this.Text = "算法参数";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private HalconDotNet.HWindowControl hWindowControl_test;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_ApplyPara;
        private System.Windows.Forms.Button btn_SavePara;
        private System.Windows.Forms.Button btn_TestImage;
        private System.Windows.Forms.RadioButton BSideradioButton;
        private System.Windows.Forms.RadioButton ASideradioButton;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_SaveImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_ThresholdSecondLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Ty2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ScaleY2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Phi2;
        private System.Windows.Forms.TextBox txt_Tx2;
        private System.Windows.Forms.TextBox txt_Theta2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_ScaleX2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_ThresholdPick;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Tx1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_ScaleY1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Ty1;
        private System.Windows.Forms.TextBox txt_Theta1;
        private System.Windows.Forms.TextBox txB_Phi1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_ScaleX1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txB_ThresholdPut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_Location2;

    }
}