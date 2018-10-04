using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;//DllImport
using System.Diagnostics;
using System.Xml.Serialization;



using DevExpress.XtraCharts;//dev_express控件


namespace WindowsFormsApplication2
{
    public partial class FormMain : Form
    {


        #region 网口变量
        private S7Client Client;
        private byte[] Buffer = new byte[65536];
        private string IP;
        private int Rack;
        private int Slot;
        private int ConnectResult;
        #endregion

        public JRSCameraYMJ CamYMJ;
        public JRSCameraYMJ2 CamYMJ2;
        //相机线程中的bmp图像
        public static Bitmap bmpProcessThread01, bmpProcessThread02;
        //相机线程中的hobject图像
        public static HalconDotNet.HObject ho_processThread01, ho_processThread02;

        public static HWindow WindowL;
        public static HWindow WindowR;
        /// 结束加载标志，加载结束后，loading界面消失
        public static long LoaddingEnd = 0;
        //主程序加载完成
        public static int LoadMainformEnd = 0;
        //左相机离线测试图像
        public static HObject LImgload;
        //右相机离线测试图像
        public static HObject RImgload;
        public static IniFileData _iniData;//声明ini数据对象

        /// <summary>
        /// 显示ROI
        /// </summary>

        private List<HDrawingObject> drawing_objects = new List<HDrawingObject>();

        private Stack<HObject> graphic_stack = new Stack<HObject>();
        private HDrawingObject selected_drawing_object = new HDrawingObject(250, 250, 100);
        private HImage background_image = null;
        private object stack_lock = new object();
        /// <summary>
        /// 左右窗口是否可放缩
        /// </summary>
        public static bool IsLwinSizeable = true;
        public static HWindowControl HwincontrolROI;
        public static long Threadtogether = 0;      //处理线程线程同步
        #region   网口
        //public static   Socket socketServer;///网口客户端
        // 创建一个和客户端通信的套接字
        Socket socketwatch = null;
        Socket SocketSoftwareCCDToDetectCCD = null;

        //定义一个集合，存储客户端信息
       // Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };


        ParameterizedThreadStart pts;

        private delegate void InvokeListBox(string strCon);    // 刷新ListBox的委托。
        private InvokeListBox invokeListBox;
        private Work wk;    //工作线程对象

        public int Displist = 0;
        #endregion

        //相机的状态检测
        public static bool Camera1TriggerOpen;
        public static bool Camera2TriggerOpen;
        //刷新界面
        public delegate void AddListItem(String myString);//声明一个绑定字符串的委托类型
        public AddListItem mmyDelegate;//委托实例化
        public static int SaveImage = 2;//0 save all image,1 save  NG image,2 donot save image

        /// <summary>
        /// 软触发信号 0表示无触发，1表示有触发
        /// </summary>
      //  public static int trigger1 = 0;//相机1
       // public static int trigger2 = 0;//相机2

        public static long trigger1Start = 0;

        public static long trigger1End = 0;

        public static long trigger2Start= 0;

        public static long trigger2End = 0;

        public AddListItem myDelegate;//委托实例化


        /// <summary>
        /// 结束加载标志，加载结束后，loading界面消失
        /// </summary>
        public static long lClosingLoading = 0;
        public FormMain()
        {
            InitializeComponent();
            _iniData = new IniFileData(Class_Global.SocketParaPath);
            //_mouse_HwindowLeft = new Mourse();
            //_mouse_HwindowRight = new Mourse();
            //HwincontrolROI = new HWindowControl();
            //user_actions = new Drawobj(this);
            //   this.AttachDrawObj(selected_drawing_object);

            myDelegate = new AddListItem(AddListItemMethod);//注册委托事件 

        }
        int  SOCKETTrigger1 = 0;

        int SOCKETTrigger2 = 0;

        public void AddListItemMethod(String myString)
        {

            lbl_ccd1imagenum.Text = ccd1num1.ToString();
            lbl_ccd2imagenum.Text = ccd1num2.ToString();
            label_socket1.Text = SOCKETTrigger1.ToString();
            label_socket2.Text = SOCKETTrigger2.ToString();
        }

        void initializeCameras()
        {


            CamYMJ = new JRSCameraYMJ();
            JRSCameraYMJ.processCamera01 = delegate { doCamerajob01(JRSCameraYMJ.bmp_image1, JRSCameraYMJ.ho_image1); };

            CamYMJ2 = new JRSCameraYMJ2();
            JRSCameraYMJ2.processCamera01 = delegate { doCamerajob02(JRSCameraYMJ2.bmp_image1, JRSCameraYMJ2.ho_image1); };

        }

        /// <summary>
        /// 网口初始化
        /// </summary>
        void initializeSocket()
        {

            ////******与机械手通讯的线程***********//////////////////////////////////////

            wk = Work.GetInstance();    //单例模式初始化工作线程对象
            wk.invokeOthers = new Work.InvokeListBox(ReciveData);    // 绑定，接收工作线程过来的数据
            invokeListBox = new InvokeListBox(RefrushListBox);       // 绑定，刷新界面ListBox控件

            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）
            IPAddress address = IPAddress.Parse(Class_Global.SocketIp);
            IPEndPoint point = new IPEndPoint(address, Convert.ToInt32(Class_Global.SocketPort));
            socketwatch.Bind(point);
            //将套接字的监听队列长度限制为20  
            socketwatch.Listen(20);

            Thread threadwatch = new Thread(watchconnecting);
            threadwatch.IsBackground = true;
            threadwatch.Start();


            //////******与检测平台通讯的线程***********//////////////////////////////////////
            SocketSoftwareCCDToDetectCCD = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address1 = IPAddress.Parse("127.0.0.1");
            IPEndPoint point1 = new IPEndPoint(address1, 8098);
            SocketSoftwareCCDToDetectCCD.Bind(point1);

            SocketSoftwareCCDToDetectCCD.Listen(20);
            Thread threadwatch1 = new Thread(watchconnectingLocal);
            threadwatch1.IsBackground = true;
            threadwatch1.Start();
        }
        //CCD1 拍照线程与网口线程交互信号
        public static bool CalulateStatePick;
        public static bool CalulateStatePickSend;
        public static bool checkstate;
        public static bool software1tosoftware2;

        //CCD2 拍照线程与网口线程交互信号
        public static bool putstate;
        public static bool putstateSend;
        void recv(object socketclientpara)
        {


            Socket socketServer = socketclientpara as Socket;
            while (true)
            {

                byte[] arrServerRecMsg = new byte[100];//创建一个内存缓冲区，其大小为1024*1024字节即1M， 将接收到的信息存入到内存缓冲区，并返回其字节数组的长度        

                ///收到机械手发送的坐标，节拍为先发送坐标，然后再拍照
                try
                {
                    ///放料ok信号处理
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, socketServer.Receive(arrServerRecMsg));//将机器接受到的字节数组转换为人可以读懂的字符串 

                    string[] SpiltStr = strSRecMsg.Split(new Char[] { ' ', ',','\r','\n'});//逗号或者空格分隔符

                   // string[] SpiltStr = strSRecMsg.Split(new Char[] { ' ', ',', '\r', '\n' });//逗号或者空格分隔符

                    /// 999  \r 表示机械手复位ok
                    /// 
                  ///  if (SpiltStr[0] == "999")
                    string[] str123 = new string[10];

                    int j=0;
                    for (int i = 0; i < SpiltStr.Length ;i++)
                    {
                        if(SpiltStr[i]!="")
                        {                         
                            if(j<10)
                            {
                                str123[j] = SpiltStr[i];
                                j++;
                            }                                                  
                        }
                    }

                    if (str123[0] == "T1")
                    {
                        wk.invokeOthers("接受到上相机触发信号" + GetCurrentTime() + "\r\n" + str123[0]);             
                    }
                    if (str123[0] == "T2")
                    {
                        wk.invokeOthers("接受到下相机触发信号" + GetCurrentTime() + "\r\n" + str123[0]);
                        SOCKETTrigger2 = 1;
                        lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { SOCKETTrigger2.ToString() });
                      // trigger2 = 1;
                    }
                     if (str123[0] == "999")
                     {
                         wk.invokeOthers("机械手的复位OK" + GetCurrentTime() + "\r\n" + str123[0]);                  
                      }
                   ///888 n接受到机械手拍照位置坐标
        
                    if (str123[0]=="888")
                    {
                        Class_Global.RobotCCD1X = Convert.ToDouble(str123[1]);
                        Class_Global.RobotCCD1Y = Convert.ToDouble(str123[2]);
                      //  Class_Global.RobotCCD1Angle = Convert.ToDouble(SpiltStr[3]);
                        Class_Global.RobotCCD1Angle = 0;
                        wk.invokeOthers("接受到相机1拍照位坐标" + GetCurrentTime() + "\r\n" + str123[1] + " " + str123[2]);
                     //   timer_trigger1.Enabled = true;
                        SOCKETTrigger1 = 1;
                        lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { SOCKETTrigger1.ToString() });
                      //  System.Threading.Interlocked.Exchange(ref trigger1Start, 1);
                               
                    }
                    if (str123[0] == "222")
                    {

                        System.Threading.Interlocked.Exchange(ref trigger2Start, 1);

                        Thread.Sleep(200);

                        wk.invokeOthers("接受到下相机触发信号" + GetCurrentTime() + "\r\n" + str123[0]);


                        SOCKETTrigger2 = 1;
                        lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { SOCKETTrigger2.ToString() });

                    }

                   
                    ///777机械手等待模组测试结果
                    if (str123[0] == "777")
                    {
                        wk.invokeOthers("机械手等待模组测试结果" + GetCurrentTime() + "\r\n" + str123[0]);


                        ///直接发送模组的结果
                        ///

                        byte[] arrSendMsg = new byte[1024 * 1024];
                        string sendmsg = null;                    
                        //sendmsg = "2000";

                        sendmsg = Result;
                        arrSendMsg = Encoding.UTF8.GetBytes(sendmsg + "\r\n");
                        connection2Robot.Send(arrSendMsg);
                        wk.invokeOthers(GetCurrentTime() + "发送检测结果到机械手" + sendmsg + "\r\n");//是否接受到检测平台的检测结果


                    }


                    if (str123[0] == "100")   ////100表示放料ok
                    {
                        //发送角度给plc 电机回零
                        FormMain.m_FinsConnecor.WriteFloat(322, 0);
                        FormMain.m_FinsConnecor.WriteInt32(320, 101);
                        
                        wk.invokeOthers("接受到机械手放料完毕" + GetCurrentTime() + "\r\n" + str123[0]);//显示接受数据

                        string StrSoftware1toSoftware2 = "checkstart" + "，" + "O";
                        connection2LensTest.Send(Encoding.UTF8.GetBytes(StrSoftware1toSoftware2));//发送测试开始信号给模组
                        wk.invokeOthers("发送模组开始测试" + GetCurrentTime() + "\r\n" + str123[0]);//显示接受数据


                    

                    }
                   

                    //供料完毕和下料盘满信号处理
                    //001表示的四个料盘已经取完
                    //002表示A类产品放满
                    //003表示B类产品放满
                    //004表示C类产品放满
                    if (str123[0] == "001") 
                    {
                      //  MessageBox.Show("上料盘中料测试完毕，请更换上料盘");
                        FormTips tips = new FormTips();
                        tips.label_Tip.Text = "上料盘中料测试完毕，请更换上料盘";
                        tips.ShowDialog();
                    }
                    if (str123[0] == "002") 
                    {
                      //  MessageBox.Show("下料盘A类放满，请更换下料盘");

                        FormTips tips = new FormTips();
                        tips.label_Tip.Text = "下料盘A类放满，请更换下料盘";
                        tips.ShowDialog();
                    }
                    if (str123[0] == "003")
                    {
                      //  MessageBox.Show("下料盘B类放满，请更换下料盘");

                        FormTips tips = new FormTips();
                        tips.label_Tip.Text = "下料盘B类放满，请更换下料盘";
                        tips.ShowDialog();
                    }
                    if (str123[0] == "004")
                    {
                     //   MessageBox.Show("下料盘C类放满，请更换下料盘");

                        FormTips tips = new FormTips();
                        tips.label_Tip.Text = "下料盘C类放满，请更换下料盘";
                        tips.ShowDialog();
                    }




                }
                catch (Exception ex)
                {
                    //clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());
                    wk.invokeOthers("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    socketServer.Close();//关闭之前accept出来的和客户端进行通信的套接字 
                    break;
                }
            }
        }
        //////网口通讯
        /// <summary>
        ///PC与机械手的通讯网口连接
        /// </summary>
        /// 
        Socket ConnectUknow = null;
        Socket connection2Robot = null;   //机械手的地址为192.168.1.123
        Socket connect2PLC = null;       //plc地址为192.168.1.121
        /// <summary>
        /// PC与Lens通讯
        /// </summary>
        Socket connection2LensTest = null;//

        /// <summary>
        /// 监听网口客户端线程
        /// </summary>
        void watchconnecting()
        {

            //持续不断监听客户端发来的请求     
            while (true)
            {
                try
                {
                    ConnectUknow = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    //提示套接字监听异常     
                    Console.WriteLine(ex.Message);
                    break;
                }

                IPAddress clientIP = (ConnectUknow.RemoteEndPoint as IPEndPoint).Address;      //获取客户端的IP和端口号  
                int clientPort = (ConnectUknow.RemoteEndPoint as IPEndPoint).Port;
                ////判断若连接对象为机械手的IP，则初始为机械手网口通讯对象
                if(clientIP.ToString()=="192.168.0.124")
                {
                    connection2Robot = ConnectUknow;


                    string sendmsg = "connect with Client successfully！\r\n" + "ClientIP:" + clientIP + "，ClientPort" + clientPort.ToString();   //让客户显示"连接成功的"的信息  
                    byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                    //  connection2Robot.Send(arrSendMsg);

                    string remoteEndPoint = connection2Robot.RemoteEndPoint.ToString();              //客户端网络结点号  
                    wk.invokeOthers("successfully connect with" + remoteEndPoint + "\t\n");

                   // clientConnectionItems.Add(remoteEndPoint, connection2Robot); //添加客户端信息 
                    IPEndPoint netpoint = connection2Robot.RemoteEndPoint as IPEndPoint;
                    ParameterizedThreadStart pts = new ParameterizedThreadStart(recv); //创建一个通信线程
                    Thread thread = new Thread(pts);
                    thread.IsBackground = true;//设置为后台线程，随着主线程退出而退出                    
                    thread.Start(connection2Robot);


                }
   

          
            }
        }
        public DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
        /// <summary>
        /// 接收工作线程过来的数据，更新界面
        /// </summary>
        /// <param name="i"></param>
        public void ReciveData(string inputstr)
        {

            //如果首字符为P1则为抓取信号 更新到第一个listbox
            //如果第一个字符为pic，则更新到第一个listbox,若为put则更新到第二个
            //string[] JudgeStr = new string[inputstr.Length];
            //string[] JudgeStr123 = inputstr.Split(new Char[] { ' ', ',', '.', ':', '\t', '\n', '\r' });
            ////JudgeStr = inputstr.Split();

            //string Judgestr = null;
            //for (int i = 0; i < inputstr.Length; i++)
            //{
            //    Judgestr = Judgestr + " " + JudgeStr123[i];
            //}
            //string Judgestr = JudgeStr123[12];
            string strConten = inputstr;
            if (this.listBox_pick1.InvokeRequired)
            {
                this.listBox_pick1.Invoke(invokeListBox, new object[] { strConten });
            }


        }
        /// <summary>
        /// 监听本地客户端连接
        /// </summary>
        void watchconnectingLocal()
        {


            //持续不断监听客户端发来的请求     
            while (true)
            {
                try
                {
                    connection2LensTest = SocketSoftwareCCDToDetectCCD.Accept();
                }
                catch (Exception ex)
                {
                    //提示套接字监听异常     
                    Console.WriteLine(ex.Message);
                    break;
                }
                IPAddress clientIP = (connection2LensTest.RemoteEndPoint as IPEndPoint).Address;      //获取客户端的IP和端口号  
                int clientPort = (connection2LensTest.RemoteEndPoint as IPEndPoint).Port;
                string sendmsg = "successfully connect with ！\r\n" + "Client IP:" + clientIP + "Cliengt Port" + clientPort.ToString();   //让客户显示"连接成功的"的信息  
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
              //  connection2LensTest.Send(arrSendMsg);

                string remoteEndPoint = connection2LensTest.RemoteEndPoint.ToString();              //客户端网络结点号  
                wk.invokeOthers("Successfully connect with" + remoteEndPoint + "！\t\n");


                //clientConnectionItems.Add(remoteEndPoint, connection2LensTest); //添加客户端信息

                IPEndPoint netpoint = connection2LensTest.RemoteEndPoint as IPEndPoint;

                ParameterizedThreadStart pts = new ParameterizedThreadStart(recvLocal); //创建一个通信线程

                Thread thread = new Thread(pts);

                thread.IsBackground = true;//设置为后台线程，随着主线程退出而退出   

                thread.Start(connection2LensTest);
            }
        }
        void recvLocal(object socketclientpara)
        {


            Socket socketServer = socketclientpara as Socket;
            while (true)
            {
                
                byte[] arrServerRecMsg = new byte[100];//创建一个内存缓冲区，其大小为1024*1024字节  即1M ,将接收到的信息存入到内存缓冲区，并返回其字节数组的长度    
                try
                {

                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, socketServer.Receive(arrServerRecMsg));
                    string[] StrRecv = strSRecMsg.Split(new Char[] { ' ', '，', ',', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                   // var arr = item.userAnswer.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (StrRecv[0] == "checkend")
                    {
                        wk.invokeOthers(GetCurrentTime() + "接受到检测软件2的检测结果" + strSRecMsg + "\r\n");//是否接受到检测平台的检测结果
                        string sendmsg1 = StrRecv[1];

                        ////10  20 30 分别表示测试结果 A\B\NG三种    

                        byte[] arrSendMsg=new byte [1024*1024];
                        string sendmsg = null;
                        if(sendmsg1=="A")
                        {
                           sendmsg="1000";                   
                        }
                        if (sendmsg1 == "B")
                        {
                            sendmsg = "2000";
                        }
                        if (sendmsg1 == "C")
                        {
                          sendmsg = "3000";
                        }
                        arrSendMsg = Encoding.UTF8.GetBytes(sendmsg+"\r\n");
                        connection2Robot.Send(arrSendMsg);
                        wk.invokeOthers(GetCurrentTime() + "发送检测结果到机械手" + sendmsg + "\r\n");//是否接受到检测平台的检测结果                 
                    }
           
                }
                catch (Exception ex)
                {
                //   clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());
                    wk.invokeOthers("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    socketServer.Close();
                    break;
                }
            }
        }
        /// <summary>
        /// 具体刷新界面函数
        /// </summary>
        /// <param name="_str"></param>
        public void RefrushListBox(string _str)
        {
            try
            {
                this.listBox_pick1.Items.Add(_str);
            }
            catch { }
        }
        void sendSocket()
        {
            //发送坐标给机械手
            //socketServer.Send(Encoding.UTF8.GetBytes("y  x  angle "));

        }
        public class Work
        {
            private volatile static Work instanceWork;    // 单例

            public delegate void InvokeListBox(string input);
            public InvokeListBox invokeOthers;
            /// <summary>
            /// 构造函数
            /// </summary>
            public Work()
            {

            }

            /// <summary>
            /// 对外接口，获取单例
            /// </summary>
            /// <returns></returns>
            public static Work GetInstance()
            {
                if (null == instanceWork)
                {
                    instanceWork = new Work();
                }

                return instanceWork;
            }

            /// <summary>
            /// 业务函数，在工作过程中将状态传给主界面
            /// </summary>
            public void DoSomething()
            {
                for (int i = 0; i < 20; i++)
                {
                    // Thread.Sleep(1000);
                    invokeOthers(i.ToString());
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //开启加载界面显示
            System.Threading.Thread.Sleep(300);
            Interlocked.Exchange(ref lClosingLoading, 1);


            #region 控件置于最前方




            #endregion



            // inActiveMainWin();
            //显示登录界面
            ShowLogin();
                 
            WindowL = hWindowControlL.HalconWindow;
            WindowR = hWindowControlR.HalconWindow;

            try
            {
                initializeCameras();
                lblConnectedCam1.Text = "1";
                lblConnectedCam1.BackColor = Color.Green;
                lblConnectedCam2.Text = "2";
                lblConnectedCam2.BackColor = Color.Green;

            }
            catch (Exception ERROR)
            {
                MessageBox.Show(ERROR.ToString());
                lblConnectedCam1.Text = "1";
                lblConnectedCam1.BackColor = Color.Red;
                lblConnectedCam2.Text = "2";
                lblConnectedCam2.BackColor = Color.Red;
            }

            Class_IniOperation _iniOperation = new Class_IniOperation(Class_Global.SocketParaPath);
            if (File.Exists(Class_Global.SocketParaPath))
            {
                #region  参数载入
                Class_Global.SocketIp = _iniOperation.ReadValue("Socket", "IP");
                Class_Global.SocketPort = _iniOperation.ReadValue("Socket", "Port");


                FormMeausureSet.Readini();//读入九点标定参数
                FormCameraSetting.ReadCameraSettingini();//读入相机参数
                #endregion
                try
                {
                    initializeSocket();
                }
                catch { }
            }
            BuilderDevChart();//显示饼状图



            #region  PLC连接
            try
            {
                string str = "9600";
                string ip = "192.168.0.152";
                int port = int.Parse(str);
               // int port = int.Parse(str.Split(':')[1]);
                if (m_FinsConnecor.Open(ip, port, byte.Parse(ip.Split('.')[3]), 4))
                    MessageBox.Show("连接成功--");
                //Trace.WriteLine("已连接！");

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                MessageBox.Show("连接失败！");
            }

            #endregion


            #region  plc地址参数

            XmlSerializer serializer = new XmlSerializer(m_para.GetType());
            FileStream stream = new FileStream("Department.xml", FileMode.Open);
            m_para = (Class_Para)serializer.Deserialize(stream);
            stream.Close();
            #endregion

        }
        int ccd1num1 = 0;
        int ccd1num2 = 0;
        //图像事件
        public void doCamerajob01(Bitmap bmpDaheng, HalconDotNet.HObject hoDaheng)
        {


            ccd1num1++;
            lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { ccd1num1.ToString() });



            SOCKETTrigger1 = 0;
            lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { SOCKETTrigger1.ToString() });
      


            bmpProcessThread01 = (Bitmap)bmpDaheng.Clone();
            HalconDotNet.HTuple hoPointer, hoType, hoWidth, hoHeight;
            HalconDotNet.HOperatorSet.GetImagePointer1(hoDaheng, out hoPointer, out hoType, out hoWidth, out hoHeight);
            HalconDotNet.HOperatorSet.GenImage1(out ho_processThread01, hoType, hoWidth, hoHeight, hoPointer);
            ThreadStart processCamera = delegate { ProcessThread01(bmpProcessThread01, hoDaheng); };
            Thread threadProcess = new System.Threading.Thread(processCamera);
            threadProcess.Start();

        }
        public void ProcessThread01(Bitmap bmp, HalconDotNet.HObject hoImage)
        {
           ////每次初始化窗口大小参数

            WindowL.SetPart(0, 0, 1944, 2592);                                    
            WindowL.DispObj(ho_processThread01);
            string result = null;
            System.Threading.Interlocked.Exchange(ref  trigger1End, 1);
            Thread.Sleep(200);
            long lk1=Interlocked.Read(ref trigger1Start);
            if(lk1==0)
            {
                Interlocked.Exchange(ref trigger2End, 0);
            }
            bool ResultTemp = Class_Halconalgorithm.Location_Pickup(ho_processThread01, WindowL);
            if (ResultTemp == true)
            {
                result = "OK";//result ok
            }
            else if (ResultTemp == false)
            {
                result = "NG";
            }
            //save all image
            string ABC = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            if (Class_Global.Saveimg == true)
            {
                if (!File.Exists(Class_Global.path))
                {
                    System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(Class_Global.path);
                }

                HOperatorSet.WriteImage(hoImage, "bmp", 0, Class_Global.path + "\\" + ABC + "-" + result + ".bmp");
            }
            if ((Class_Global.SaveOKimg == true) && (result == "OK"))
            {
                if (!File.Exists(Class_Global.path))
                {
                    System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(Class_Global.path);
                }
                HOperatorSet.WriteImage(hoImage, "bmp", 0, Class_Global.path + "\\" + ABC + "-" + result + ".bmp");
            }

            if ((Class_Global.SaveNGimg == true) && (result == "NG"))
            {
                if (!File.Exists(Class_Global.path))
                {
                    System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(Class_Global.path);
                }
                HOperatorSet.WriteImage(hoImage, "bmp", 0, Class_Global.path + "\\" + ABC + "-" + result + ".bmp");
            }
           
            double TempX = Class_Global.pickX[0];
            double TempY = Class_Global.pickY[0];
            
            //判断坐标不为空
            if ((TempX == 0) && (TempY == 0))
            {
                try 
                {
                    ///666表示拍照错误 

                    //string CCD1Send = "666" + "," + "666" + "\r\n";
                    //connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send));

                    //发送完后清空数据
                    Class_Global.pickX[0] = 0;
                    Class_Global.pickY[0] = 0;
                    Class_Global.pickAngle[0] = 0;

                }
                catch
                {


                }
          
            }
            else
            {
                //try
                //{
                   // Sx = Convert.ToDouble(Class_Global.TransCCD1Para[0]);
                    //Sy = Convert.ToDouble(Class_Global.TransCCD1Para[1]);
                    //Tx = Convert.ToDouble(Class_Global.TransCCD1Para[2]) + Class_Global.RobotCCD1X - Class_Global.RobotCCD1ZeroX;
                    //Ty = Convert.ToDouble(Class_Global.TransCCD1Para[3]) + Class_Global.RobotCCD1Y - Class_Global.RobotCCD1ZeroY;
                    //Phi = Convert.ToDouble(Class_Global.TransCCD1Para[4]) + Class_Global.RobotCCD1Angle - Class_Global.RobotCCD1ZeroAngle;
                    //Theta = Convert.ToDouble(Class_Global.TransCCD1Para[5]);

                    //Class_Halconalgorithm.GenhvMat2D(Sx, Sy, Phi, Theta, Tx, Ty, out hv_Mat2d);

                    //Class_Halconalgorithm.TranfromCCDtoRobort(Class_Global.pickX, Class_Global.pickY, hv_Mat2d, out Class_Global.pickXfact, out Class_Global.pickYfact);

                    ////角度旋转计算
                    //Class_Global.pickAnglefact = Class_Global.pickAngle;
                    //HOperatorSet.SetTposition(WindowL, 300, 0);
                    //WindowL.SetColor("red");
                    //HOperatorSet.WriteString(WindowL, "ROBOT_X " + Class_Global.pickXfact + " ROBOT_Y " + Class_Global.pickYfact);
            
                    try
                    {

                        double x = Class_Global.pickXfact[0];
                        double y = Class_Global.pickYfact[0];
                        ///基准角度为152.44
                        double angleTemp = Class_Global.pickAnglefact[0] - 152;
                        double angle = 0;

                        //角度计算如果角度绝对值大于180，则给另外一个方向的角度
                        if (Math.Abs(angleTemp) > 180)
                        {
                            if (angleTemp >= 0)
                            {
                                angle = angleTemp - 360;
                            }
                            else
                            {
                                angle = angleTemp + 360;
                            }
                        }
                        else
                        {
                            angle = angleTemp;
                        }

                        angle = 0;
                        ////相机1回坐标给机械手
                        string CCD1Send = Class_Halconalgorithm.Trans2DongzhiRobortStr(x) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(angle) + "\r\n";
                        connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send));
                        wk.invokeOthers("CCD1软件发送上料产品坐标" + GetCurrentTime() + CCD1Send);

                        ///发送角度给plc
                        angle = 0;
                        FormMain.m_FinsConnecor.WriteFloat(322, (float)angle);
                        FormMain.m_FinsConnecor.WriteInt32(320, 100);
               

                        

                        //System.Threading.Thread.Sleep(100);
                        /////回馈收到数据信号
                        //byte[] arrServerRecMsg = new byte[1024 * 1024];//创建一个内存缓冲区，其大小为1024*1024字节即1M， 将接收到的信息存入到内存缓冲区，并返回其字节数组的长度        
                        //string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, connection2Robot.Receive(arrServerRecMsg));

                        //  小数点三位，mm,分割逗号，结尾回车换行

                        //发送完后清空数据
                        Class_Global.pickX[0] = 0;
                        Class_Global.pickY[0] = 0;
                        Class_Global.pickAngle[0] = 0;

                        Class_Global.pickXfact[0] = 0;
                        Class_Global.pickYfact[0] = 0;
                        Class_Global.pickAnglefact[0] = 0;
                 
                    }
                    catch
                    {


                        //string CCD1Send = "666" + "," + "666" + "\r\n";
                        //connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send));
                       // 发送完后清空数据
                        Class_Global.pickX[0] = 0;
                        Class_Global.pickY[0] = 0;
                        Class_Global.pickAngle[0] = 0;



                    }
                //}
                //catch { }

        


            }

        }
        public void doCamerajob02(Bitmap bmpDaheng, HalconDotNet.HObject hoDaheng)
        {

            ccd1num2++;
            lbl_ccd2imagenum.Invoke(myDelegate, new Object[] { ccd1num2.ToString() });



            SOCKETTrigger2 = 0;
            lbl_ccd1imagenum.Invoke(myDelegate, new Object[] { SOCKETTrigger2.ToString() });

            bmpProcessThread02 = (Bitmap)bmpDaheng.Clone();
            HalconDotNet.HTuple hoPointer, hoType, hoWidth, hoHeight;
            HalconDotNet.HOperatorSet.GetImagePointer1(hoDaheng, out hoPointer, out hoType, out hoWidth, out hoHeight);
            HalconDotNet.HOperatorSet.GenImage1(out ho_processThread02, hoType, hoWidth, hoHeight, hoPointer);
            ThreadStart processCamera = delegate { ProcessThread02(bmpProcessThread02, hoDaheng); };
            Thread threadProcess = new System.Threading.Thread(processCamera);
            threadProcess.Start();
        }
        string numccd2;
        public void ProcessThread02(Bitmap bmpDaheng, HalconDotNet.HObject hoDaheng)
        {

            WindowR.SetPart(0, 0, 1944, 2592);


            WindowR.DispObj(ho_processThread02);
            Class_Halconalgorithm.SecondLocation(ho_processThread02, WindowR);

            System.Threading.Interlocked.Exchange(ref  trigger2End, 1);
            double TempX = Class_Global.putXfact[0];
            double TempY = Class_Global.putYfact[0];
            if ((TempX == 0) && (TempY == 0))
            {

                try 
                {

                  //  string CCD1Send = "NG";

                    //string CCD1Send =  "666" + "," + "666" + "\r\n";


                    //connection2LensTest.Send(Encoding.UTF8.GetBytes(CCD1Send));

                    //发送完后清空数据

                    Class_Global.putX[0] = 0;
                    Class_Global.putY[0] = 0;

                    Class_Global.putXfact[0] = 0;
                    Class_Global.putYfact[0] = 0;

                    wk.invokeOthers("CCD2坐标计算失败");
                    putstate = false;
                }
                catch
                {




                }
             

            }
            else
            {
                try
                {
                    ///下相机坐标


                    double x1 = Class_Global.putXfact[0] - Class_Global.PutOK_RobotX;
                    double y1 = Class_Global.putYfact[0] - Class_Global.PutOK_RobotY;

                    //double x1 = 0;
                    //double y1 = 0;

                    double angle1 = 0;



                    //x1 = 1.0;
                    //y1 = 2.0;


                    //double angle1 = 3;//取料无角度


                    string CCD1Send1 = Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(angle1) + "\r\n";

                    connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send1));
                   // x1 = 4.0;
                   // y1 = 5.0;


                   // angle1 = 3;//取料无角度

                   //// string CCD1Send = "Put" + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(angle1) + "," + "Camera" + 2;

                   // string CCD1Send = Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + ",CR" + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "\r\n";


                   // connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send));




                   // FormMain.putstateSend = true;

                    //发送完后清空数据
                    Class_Global.putX[0] = 0;
                    Class_Global.putY[0] = 0;

                    Class_Global.putXfact[0] = 0;
                    Class_Global.putYfact[0] = 0;

                    wk.invokeOthers("CCD1软件发送下料位置坐标" + GetCurrentTime() + CCD1Send1);

                    //wk.invokeOthers("CCD1软件发送下料位置坐标" + GetCurrentTime() + CCD1Send);
             

                    putstate = false;
                }
                catch
                {
                //    string CCD1Send = "NG";

                    //string CCD1Send = "666" + "," + "666" + "\r\n";

                    //connection2LensTest.Send(Encoding.UTF8.GetBytes(CCD1Send));


                    //发送完后清空数据

                    Class_Global.putX[0] = 0;
                    Class_Global.putY[0] = 0;


                    Class_Global.putXfact[0] = 0;
                    Class_Global.putYfact[0] = 0;

                    wk.invokeOthers("CCD2坐标计算失败");
                    putstate = false;

                }
                Class_Global.putX[0] = 0;
                Class_Global.putY[0] = 0;
                Class_Global.putXfact[0] = 0;
                Class_Global.putYfact[0] = 0;


            }

        }
        private void tsbRun_Click(object sender, EventArgs e)
        {
             bool CCD1Conect=false;
             bool CCD2Conect=false;
            try 
            {
                CCD1Conect = CamYMJ.Open(Class_Global.Camera1[0]);
                CamYMJ.CameraPara(CamYMJ.m_ImageControl);  ///加载相机参数
                CamYMJ.m_ImageControl.LiveStart();
                CCD2Conect = CamYMJ2.Open(Class_Global.Camera2[0]);
                CamYMJ2.CameraPara(CamYMJ2.m_ImageControl);  ///加载相机参数
                CamYMJ2.m_ImageControl.LiveStart();
            }
            catch { }
           
      

            if (CCD1Conect == true)
            {
                lblDetectCam1.Text = "1";
                lblDetectCam1.BackColor = Color.Green;
                Camera1TriggerOpen = true;
            }
            else
            {
                lblDetectCam1.Text = "1";
                lblDetectCam1.BackColor = Color.Red;

            }


            if (CCD2Conect == true)
            {
                lblDetectCam2.Text = "1";
                lblDetectCam2.BackColor = Color.Green;
                Camera2TriggerOpen = true;
            }
            else
            {
                lblDetectCam2.Text = "1";
                lblDetectCam2.BackColor = Color.Red;

            }

            tsbRun.Enabled = false;
            tsbExit.Enabled = true;

        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("       确定退出TV画像上料软件？", " 提示        ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                try
                {
                    CamYMJ.Close();

                }
                catch { }

            }

        }
        private void ShowLogin()
        {

         //   Formlogin frm = new Formlogin();//新建实例窗口对象
         //   frm.ShowDialog();




        }
        //更新窗口控件状态
        private void ActiveMainWin()
        {
            tsbCameraConfig.Enabled = true;
            tsbcontactus.Enabled = true;
            tsbhelpDoc.Enabled = true;
            tsbOnline.Enabled = true;
            tsbparaSet.Enabled = true;
            tsbproductselect.Enabled = true;
          //  tsbRun.Enabled = true;
            tsbsystemSet.Enabled = true;
            tsbExit.Enabled = true;
            toolStripButton8.Enabled = true;
            tsB_socket.Enabled = true;
            tSB_softTrigger.Enabled = true;

            tsB_Stop.Enabled = true;
            tsB_CalibrateCoordinate.Enabled = true;
            tsb_NormalWin.Enabled = true;
            //tsB_Login.Enabled = false;


         //   tsB_Stop.Enabled = true;
            tsB_CalibrateCoordinate.Enabled = true;
            tsb_NormalWin.Enabled = true;

            lblDetectCam1.Enabled = true;
            lblDetectCam2.Enabled = true;
            cMStrip_SocketMessage.Enabled = true;


            tsbExit.Enabled = true;
            comB_SaveImage.Enabled = true;


            //timer_trigger1.Enabled = true;
            //timer_trigger2.Enabled = true;



        }
        private void inActiveMainWin()
        {
            tsbCameraConfig.Enabled = false;
            tsbcontactus.Enabled = false;
            tsbhelpDoc.Enabled = false;
            tsbOnline.Enabled = false;
            tsbparaSet.Enabled = false;
            tsbproductselect.Enabled = false;
            tsbRun.Enabled = false;
            tsbsystemSet.Enabled = false;
            tsbExit.Enabled = false;
            toolStripButton8.Enabled = false;
            tsB_socket.Enabled = false;
            tSB_softTrigger.Enabled = false;
            //tsB_Login.Enabled = true;

            tsB_Stop.Enabled = false;
            tsB_CalibrateCoordinate.Enabled = false;
            tsb_NormalWin.Enabled = false;

            tsbExit.Enabled = true;

            lblDetectCam1.Enabled = false;
            lblDetectCam2.Enabled = false;
            cMStrip_SocketMessage.Enabled = false;


            comB_SaveImage.Enabled = false;





        }
        private void tsbcontactus_Click(object sender, EventArgs e)
        {
            FormContactus frm = new FormContactus();
            frm.Show();
        }
        private void tsbCameraConfig_Click(object sender, EventArgs e)
        {
            FormCameraSetting frm = new FormCameraSetting();
            frm.Show();
        }
        private void tsbhelpDoc_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(Class_Global.AppNameDir + "使用说明.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统未找到指定说明书文件", "提示");

            }
        }
        private void tsbsystemSet_Click(object sender, EventArgs e)
        {
            FormSystemSetting frmSyssetting = new FormSystemSetting();
            frmSyssetting.Owner = this;
            frmSyssetting.Show();

        }  
       private void timer1_Tick(object sender, EventArgs e)
        {
            //    lbl_disptime.Text = DateTime.Now.ToString();
            lbl_timedisp.Text = DateTime.Now.ToString();

        }

        private void tsbparaSet_Click(object sender, EventArgs e)
        {

            FormMeausureSet Measuresetfrm = new FormMeausureSet();
            Measuresetfrm.Show();

        }
     
       

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CamYMJ.Close();
                CamYMJ2.Close();
            }

            catch { }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CamYMJ.Close();

            }
            catch { }
        }

        private void tSB_softTrigger_Click(object sender, EventArgs e)
        {

            CamYMJ.SoftTrigger();
            CamYMJ2.SoftTrigger();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendSocket();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            sendSocket();

            Class_Global.pickXfact[0] = 1.0;
            Class_Global.pickYfact[0] = 2.0;
            Class_Global.pickAnglefact[0] = 3.0;

            /// CalulateState = true;
        }

        private void tsB_Login_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormSocket frmSocket = new FormSocket();
            frmSocket.Show();
        }

        private void tsB_CalibrateCoordinate_Click(object sender, EventArgs e)
        {
            FormCali_brate frmcalibrate = new FormCali_brate();
            frmcalibrate.Show();
        }

        private void lblConnectedCam1_DoubleClick(object sender, EventArgs e)
        {




        }

        private void lblConnectedCam2_Click(object sender, EventArgs e)
        {

            


        }

        private void lblDetectCam1_DoubleClick(object sender, EventArgs e)
        {
            if (CamYMJ.TrigEnableSwitch.Switch == true)
            {
                try
                {
                    CamYMJ.TrigEnableSwitch.Switch = false;
                    MessageBox.Show("相机1实时模式打开");

                }
                catch
                {
                    MessageBox.Show("相机1实时模式打开失败");

                }
            }
            else if (CamYMJ.TrigEnableSwitch.Switch == false)
            {
                try
                {
                    CamYMJ.TrigEnableSwitch.Switch = true;
                    MessageBox.Show("相机1trigger模式打开");
                }
                catch
                {
                    MessageBox.Show("相机1触发模式打开失败");

                }

            }

        }

        private void lblDetectCam2_DoubleClick(object sender, EventArgs e)
        {
            if (CamYMJ2.m_ImageControl.DeviceTrigger == true)
            {
                try
                {
                    if (CamYMJ2.m_ImageControl.LiveVideoRunning)
                        CamYMJ2.m_ImageControl.LiveStop();

                    CamYMJ2.m_ImageControl.LiveStart();
                    CamYMJ2.m_ImageControl.DeviceTrigger = false;
                    Camera1TriggerOpen = false;
                    MessageBox.Show("相机2实时模式打开");

                }
                catch
                {
                    MessageBox.Show("相机2实时模式打开失败");

                }
            }
            if (CamYMJ2.m_ImageControl.DeviceTrigger == false)
            {
                try
                {
                    if (CamYMJ2.m_ImageControl.LiveVideoRunning)
                        CamYMJ2.m_ImageControl.LiveStop();

                    CamYMJ2.m_ImageControl.LiveStart();
                    CamYMJ2.m_ImageControl.DeviceTrigger = true;
                    Camera1TriggerOpen = true;
                    MessageBox.Show("相机2触发模式打开");
                }
                catch
                {
                    MessageBox.Show("相机2触发模式打开失败");

                }
            }
        }

        private void lblDetectCam1_Click(object sender, EventArgs e)
        {

        }

        private void tsb_NormalWin_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;


            listBox_pick1.Items.Clear();
        }

        private void tsB_Stop_Click_1(object sender, EventArgs e)
        {
           // CamYMJ.Close();
          //  CamYMJ2.Close();
            tsbRun.Enabled = true;
            tsB_Stop.Enabled = false;

            bool CCD1Close = CamYMJ.Close(); ;
            bool CCD2Close = CamYMJ2.Close();

            if (CCD1Close == true)
            {
                lblDetectCam1.Text = "CCD1断开";
                lblDetectCam1.BackColor = Color.Red;
                Camera1TriggerOpen = true;
            }


            if (CCD2Close == true)
            {

                lblDetectCam2.Text = "CCD2断开";
                lblDetectCam2.BackColor = Color.Red;
                Camera2TriggerOpen = true;
            }
        

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
          //  Formlogin frm = new Formlogin();//新建实例窗口对象
           // frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Bitmap image1;
            image1 = (Bitmap)Bitmap.FromFile("C://1.bmp");

            HObject image_ho;
            image_ho = Bitmap2HObject(image1);


        }


        [DllImport("kernel32", EntryPoint = "RtlMoveMemory", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern void CopyMemory(int Destination, int Source, int length);
        public HalconDotNet.HObject Bitmap2HObject(Bitmap bmp)
        {
            //if (bmp.PixelFormat != PixelFormat.Format8bppIndexed) bmp = DH.clsDHImgProcessing.ToGrayBitmap(bmp);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            IntPtr pointer = bmpData.Scan0;

            byte[] dataBlue = new byte[bmp.Width * bmp.Height];
            unsafe
            {
                fixed (byte* ptrdata = dataBlue)
                {
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        CopyMemory((int)(ptrdata + bmp.Width * i), (int)(pointer.ToInt32() + bmpData.Stride * i), bmp.Width);
                    }
                    HalconDotNet.HObject hobject;
                    HalconDotNet.HOperatorSet.GenImage1(out hobject, "byte", bmp.Width, bmp.Height, (int)ptrdata);
                    HalconDotNet.HImage himg = new HalconDotNet.HImage("byte", bmp.Width, bmp.Height, (IntPtr)ptrdata);

                    bmp.UnlockBits(bmpData);
                    return hobject;
                }
            }

        }
        private void comB_SaveImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comB_SaveImage.SelectedItem == "SaveAllImage")
            {

                Class_Global.Saveimg = true;

            }
            if (comB_SaveImage.SelectedItem == "SaveNGImage")
            {
                Class_Global.SaveNGimg = true;

            }
            if (comB_SaveImage.SelectedItem == "SaveOKImage")
            {

                Class_Global.SaveOKimg = true;

            }
            if (comB_SaveImage.SelectedItem == "NotSaveImage")
            {

                Class_Global.NotSaveImage = true;


            }
        }
        private void button1_Click_3(object sender, EventArgs e)
        {


            string sendmsg = "Secondery Location x y z";
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
            connection2Robot.Send(arrSendMsg);


            listBox_pick1.Items.Add("Send Secondery Location position" + GetCurrentTime() + arrSendMsg);

            
        }
        private void button2_Click(object sender, EventArgs e)
        {



            string sendmsg = "Product x y z";
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
            connection2LensTest.Send(arrSendMsg);


            listBox_pick1.Items.Add("Send SProduct position" + GetCurrentTime() + arrSendMsg);



        }
        private void Clear_message_ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("      Socket message？", " Tips        ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                listBox_pick1.Items.Clear();

            }

        }
        private void sendMessageToRobortToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   string sendmsg = "Secondery Location x y c";
            double[] point1 = new double[3] { 123.3456, 13.5689, 45.7890 };

            string Send=null;
   
            Send = Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0]) +","+ Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0])
                + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0])+"\r\n";
    
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(Send);
           // connection2Robot.Send(arrSendMsg);

            connection2Robot.Send(arrSendMsg);
            listBox_pick1.Items.Add("Send Pick  position" + GetCurrentTime() + Send);
        }
        private void sendMessageToLensToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string sendmsg = "checkstart" + "，" + "O";
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
            connection2LensTest.Send(arrSendMsg);


            listBox_pick1.Items.Add("Send Start Signal to LensTest" + GetCurrentTime() + arrSendMsg);
        }
        private void send坐标2ToRobortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] point1 = new double[3] { 123.3456, 13.5689, 0 };

            string Send = null;

            Send = Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0]) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0])
                + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(point1[0]) + "\r\n";

            byte[] arrSendMsg = Encoding.UTF8.GetBytes(Send);
            // connection2Robot.Send(arrSendMsg);
            connection2Robot.Send(arrSendMsg);
            listBox_pick1.Items.Add("Send Secondery Location position" + GetCurrentTime() + Send);

        }
       private void send测试结果ToRobortToolStripMenuItem_Click(object sender, EventArgs e)
        {

         byte[] arrSendMsg = Encoding.UTF8.GetBytes("10" + "\r\n");
         connection2Robot.Send(arrSendMsg);
        }
        #region  测试结果统计显示


        public  static  int[] LevelResult=new int[3]{1,1,1};

        public static string[] ResultName = new string[3] { "Level _A", "Level _B", "Level _C" };


        private DataTable CreateChartData()
        {

            DataTable table = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, ColumnName
            // and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Value";
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            table.Columns.Add(column);

            // Create new DataRow objects and add to DataTable. 

            string[] Result = { "Level _A", "Level _B", "Level _C" };
            for (int i = 0; i < 3; i++)
            {
                row = table.NewRow();
                row["Value"] = LevelResult[i];
              //  row["Name"] = "Name " + i;
                row["Name"] = ResultName[i];
                table.Rows.Add(row);
            }
          
            return table;
        }
        //初始化控件中饼状图
        Series _pieSeries;

        /// <summary>
        /// 根据数据创建一个饼状图
        /// </summary>
        /// <returns></returns>
        /// 
        private void BuilderDevChart()
        {
            _pieSeries = new Series("测试", ViewType.Pie);
            _pieSeries.ValueDataMembers[0] = "Value";
            _pieSeries.ArgumentDataMember = "Name";
            _pieSeries.DataSource = CreateChartData();


            chartControl1.Series.Add(_pieSeries);
            SetPiePercentage(_pieSeries);
            // _pieSeries.SeriesPointsSorting();
            _pieSeries.LegendPointOptions.PointView = PointView.ArgumentAndValues;
        }
        public void SetPiePercentage(Series series)
        {
            if (series.View is PieSeriesView)
            {
                //设置为值
                ((PiePointOptions)series.PointOptions).PercentOptions.ValueAsPercent = false;
                ((PiePointOptions)series.PointOptions).ValueNumericOptions.Format = NumericFormat.Number;
                ((PiePointOptions)series.PointOptions).ValueNumericOptions.Precision = 0;
                //设置为百分比
                //((PiePointOptions)series.PointOptions).PercentOptions.ValueAsPercent = true;
                //((PiePointOptions)series.PointOptions).ValueNumericOptions.Format = NumericFormat.Percent;
                //((PiePointOptions)series.PointOptions).ValueNumericOptions.Precision = 0;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (timer_statistics.Enabled ==true)
            {
             timer_statistics.Enabled = false;
            }
            else 
            {
                timer_statistics.Enabled = true;
            
            }


        }
   
        private void timer_statistics_Tick(object sender, EventArgs e)
        {
            LevelResult[0] = LevelResult[0] + 10;
            LevelResult[1] = LevelResult[1] + 5;
            LevelResult[2] = LevelResult[2] + 6;

            CreateChartData();

            _pieSeries.DataSource = CreateChartData();

            //   chartControl1.Series.Add(_pieSeries);
            SetPiePercentage(_pieSeries);

            // _pieSeries.SeriesPointsSorting();
            _pieSeries.LegendPointOptions.PointView = PointView.ArgumentAndValues;




        }
        #endregion
        private void splitContainer9_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ListBox_Socketpick_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void button4_Click(object sender, EventArgs e)
        {
            FormTips formtip = new FormTips();

            formtip.label_Tip.Text = "下料盘C类放满，请更换下料盘";
            formtip.ShowDialog();

                    //  MessageBox.Show("上料盘中料测试完毕，请更换上料盘");                    
                    //}                
                    //if (strSRecMsg == "002") 
                    //{
                    //    MessageBox.Show("下料盘A类放满，请更换下料盘");                 
                    //}
                    //if (strSRecMsg == "003")
                    //{
                    //    MessageBox.Show("下料盘B类放满，请更换下料盘");
                    //}
                    //if (strSRecMsg == "004")
                    //{
                    //    MessageBox.Show("下料盘C类放满，请更换下料盘");
            try
            {
               


            }
            catch { }
        }

        /// <summary>
        /// PLC  fins变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public static  JRSFinsProtocal_UDP m_FinsConnecor = new JRSFinsProtocal_UDP();
        public bool m_setstate = true;
        private void timer_authority_Tick(object sender, EventArgs e)
        {

            lbl_timedisp.Text = DateTime.Now.ToString();
            ActiveMainWin();
           //     tsbRun.Enabled = true;
               // tsB_Stop.Enabled = true;
            
            
            //if(Formlogin.authority==1)
            //{
            //    inActiveMainWin();
            //    tsbRun.Enabled = true;
            //    tsB_Stop.Enabled = true;
            //}
            //if (Formlogin.authority == 2)
            //{
            //    ActiveMainWin();
            //}
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {

            Class_Global.RobotCCD1X = Convert.ToDouble(textBox_ccdX.Text);
            Class_Global.RobotCCD1Y = Convert.ToDouble(textBox_ccdY.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           double  x1 = 1.0;
           double   y1 = 2.0;
  

            double angle1 = 3;//取料无角度


            string CCD1Send1 = Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(angle1) + "\r\n";

            connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send1));
            x1 = 4.0;
            y1 = 5.0;


            angle1 = 3;//取料无角度

            // string CCD1Send = "Put" + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(angle1) + "," + "Camera" + 2;

            string CCD1Send = Class_Halconalgorithm.Trans2DongzhiRobortStr(x1) + "," + Class_Halconalgorithm.Trans2DongzhiRobortStr(y1) + "\r\n";


            connection2Robot.Send(Encoding.UTF8.GetBytes(CCD1Send));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CamYMJ.SoftTrigger();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CamYMJ2.SoftTrigger();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            long lk = System.Threading.Interlocked.Read(ref trigger1Start);

            if (trigger1Start == 1)
            {
             //   lock (CamYMJ)
             //{

             //    bool res = CamYMJ.SoftTrigger();

             //}                            
            //   timer_trigger1.Enabled = false;

               Thread.Sleep(100);

               long lk1 = System.Threading.Interlocked.Read(ref trigger1End);

               if (lk1 == 1)
               {
                   System.Threading.Interlocked.Exchange(ref trigger1Start, 0);
                 //  System.Threading.Interlocked.Exchange(ref trigger1End, 0);

               }


                  //   trigger1 = 0;
            }
 
         //   CamYMJ.SoftTrigger();

        }

     

        private void timer_trigger2_Tick(object sender, EventArgs e)
        {
            long lk = System.Threading.Interlocked.Read(ref trigger2Start);

            if (trigger2Start == 1)
            {
                CamYMJ2.SoftTrigger();

                long lk1 = System.Threading.Interlocked.Read(ref trigger2End);

                if (lk1 == 1)
                {
                    System.Threading.Interlocked.Exchange(ref trigger2Start, 0);
                   // System.Threading.Interlocked.Exchange(ref trigger2End, 0);
                }

             //   trigger2 = 0;
            }     
           // CamYMJ2.SoftTrigger();

            
        }

        //读取plc状态
        int[] State = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void timer_test_Tick(object sender, EventArgs e)
        {
                      
            if (label_socket1.Text == "1")
            {         
                CamYMJ.SoftTrigger();
            }
            if(label_socket2.Text=="1")
            {

                CamYMJ2.SoftTrigger();
            }
            try 
            {
                for (int i = 0; i < 16; i++)
                {
                    m_FinsConnecor.ReadBit(301, D301byte[i], ref State[i]);
                }
                if (State[0] == 1)
                {
                    btn_RobotAlarm.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_RobotAlarm.BackColor = Color.Red;
                }


                if (State[1] == 1)
                {
                    btn_RobotVcuumAlarm.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_RobotVcuumAlarm.BackColor = Color.Red;
                }


                if (State[2] == 1)
                {
                    btn_CrcleAxiAlarm.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_CrcleAxiAlarm.BackColor = Color.Red;
                }


                if (State[3] == 1)
                {
                    btn_SaveDoorAlarm.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_SaveDoorAlarm.BackColor = Color.Red;
                }

                if (State[4] == 1)
                {
                    btn_SocketRobortAlarm.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_SocketRobortAlarm.BackColor = Color.Red;
                }


                if (State[5] == 1)
                {
                    btn_vacuum1_Now.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_vacuum1_Now.BackColor = Color.Red;
                }


                if (State[6] == 1)
                {
                    btn_vacuum2_Now.BackColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    btn_vacuum2_Now.BackColor = Color.Red;
                }

            }
            catch
            {



            }
     
        }

        private void tpB_PLCSetup_Click(object sender, EventArgs e)
        {
            FormPLC frmPLC = new FormPLC();
            frmPLC.Show();
        }



        public static string Result = "1000";
        /// <summary>
        /// q强制结果信号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                Result = "1000";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Result = "2000";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Result = "3000";
            }


        }

        private void textBox_ccdY_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ccdX_TextChanged(object sender, EventArgs e)
        {

        }
        
      

        #region  PLC地址
        public  static    Class_Para m_para = new Class_Para(); ///plc地址参数
        /// <summary>
        ///1.D300.0 使能 值：0或1 切换开关
        ///2.D300.1 回原点     值：0或1  自动复位
        ///3.D300.2  正转     值：0或1  自动复位
        ///4.D300.3  反转     值：0或1  自动复位
        ///5.D300.4  定位触发  值：0或1  自复位
        ///6.D300.7  安全门屏蔽         切换开关
        ///7.D300.8   机械手复位         自动复位
        ///8.D300.9  机械手使能          切换开关
        ///9. D300.10 真空1开启 值：0或1  切换开关
        ///10. D300.11 真空2开启 值：0或1 切换开关
        ///11. D300.12 高度差气缸 值：0或1 切换开关     
        /// </summary>
        byte[] D300byte = { 0, 1, 2, 3, 4, 7, 8, 9, 10, 11, 12 };
        /// <summary> 
        ///D301.0  机械手报警
        ///D301.1  机械手吸附真空异常
        ///D301.2 旋转轴报警
        ///D301.3 安全门报警
        ///D301.4 PLC与机械手通信未连接
        ///D301.5  真空信号1
        ///D301.6  真空信号2
        /// </summary>
        byte[] D301byte = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        /// <summary>
        ///1.D310  显示位置  双字Dint   ///plc写给pc 
        ///2.D312 设置速度   双字 Dint   ///PC写给plc  32位
        ///3.D314  点动速度   双字 Dint  //////PC写给plc  32位
        /// </summary>
        short[] Add = { 310, 312, 314 };




        //电机旋转
        private void button9_Click(object sender, EventArgs e)
        {

            float abc = float.Parse(textBox1.Text);


            FormMain.m_FinsConnecor.WriteFloat(322, abc);
            FormMain.m_FinsConnecor.WriteInt32(320, 100);
        }
        //发送角度给plc 电机回零
        private void button10_Click(object sender, EventArgs e)
        {

            float angle = 0;
            FormMain.m_FinsConnecor.WriteFloat(322, (float)angle);
            FormMain.m_FinsConnecor.WriteInt32(320, 100);
        }

        //1.电机使能
        private void btn_EnableMotion_Click(object sender, EventArgs e)
        {

            string[] add = m_para.EnableAxiAdd.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


            if (btn_EnableMotion.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_EnableMotion.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_EnableMotion.BackColor = Color.Red;
            }
        }
       

        //2回零
        private void btn_Zero_MouseDown(object sender, MouseEventArgs e)
        {
            string[] add = m_para.Zero.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);

        //    FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
            btn_Zero.BackColor = Color.Green;
        }
        private void btn_Zero_MouseUp(object sender, MouseEventArgs e)
        {
            string[] add = m_para.Zero.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


           // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
            btn_Zero.BackColor = Color.Silver;
        }
        //3.正转
        private void btn_forward_MouseDown(object sender, MouseEventArgs e)
        {
            string[] add = m_para.Forward.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


         //   FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
            btn_forward.BackColor = Color.Green;
        }

        private void btn_forward_MouseUp(object sender, MouseEventArgs e)
        {
            string[] add = m_para.Forward.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


           // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
            btn_forward.BackColor = Color.Silver;
        }



        #endregion

        private void btn_TrayOver_Click(object sender, EventArgs e)
        {
            FormTips formtip = new FormTips();

            formtip.label_Tip.Text = "下料盘C类放满，请更换下料盘";
            formtip.ShowDialog();
        }

        private void btn_testpirchart_Click(object sender, EventArgs e)
        {
            if (timer_statistics.Enabled == true)
            {
                timer_statistics.Enabled = false;
            }
            else
            {
                timer_statistics.Enabled = true;

            }
        }
        //4.反转
        private void btn_backward_MouseDown(object sender, MouseEventArgs e)
        {

            string[] add = m_para.backward.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);

          //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
            btn_backward.BackColor = Color.Green;
        }
        private void btn_backward_MouseUp(object sender, MouseEventArgs e)
        {
            string[] add = m_para.backward.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


           // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
            btn_backward.BackColor = Color.Silver;
        }

        ///5.定位触发
        private void btn_Trigger_MouseDown(object sender, MouseEventArgs e)
        {


            string[] add = m_para.Trigger.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);



            FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
            btn_Trigger.BackColor = Color.Green;
        }

        private void btn_Trigger_MouseUp(object sender, MouseEventArgs e)
        {

            string[] add = m_para.Trigger.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);

            FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
            btn_Trigger.BackColor = Color.Silver;
        }

        ///6.安全门
        private void btn_SafeDoor_Click(object sender, EventArgs e)
        {



            string[] add = m_para.SafeDoor.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);



            if (btn_SafeDoor.BackColor == Color.Red)
            {
               /// FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_SafeDoor.BackColor = Color.Green;
            }
            else
            {
               // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_SafeDoor.BackColor = Color.Red;
            }
        }

        ///7.机械手复位
        private void btn_Reset_MouseDown(object sender, MouseEventArgs e)
        {

            string[] add = m_para.Reset.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


          //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
            btn_Reset.BackColor = Color.Green;
        }

        private void btn_Reset_MouseUp(object sender, MouseEventArgs e)
        {

            string[] add = m_para.Reset.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


          //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
            btn_Reset.BackColor = Color.Silver;
        }
        ///8.机械手使能
        private void btn_EnableRobot_Click(object sender, EventArgs e)
        {

            string[] add = m_para.Enable.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);


            if (btn_EnableRobot.BackColor == Color.Red)
            {
             //   FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_EnableRobot.BackColor = Color.Green;
            }
            else
            {
              //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_EnableRobot.BackColor = Color.Red;
            }
        }

        ///9.真空开关1
        private void btn_vacuum1_Click(object sender, EventArgs e)
        {
            string[] add = m_para.vacuum1.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);



            if (btn_vacuum1.BackColor == Color.Red)
            {
               // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_vacuum1.BackColor = Color.Green;
            }
            else
            {
               // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_vacuum1.BackColor = Color.Red;
            }
        }

        ///10.真空开关2
        private void btn_vacuum2_Click(object sender, EventArgs e)
        {


            string[] add = m_para.vacuum2.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);

            if (btn_vacuum2.BackColor == Color.Red)
            {
              //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_vacuum2.BackColor = Color.Green;
            }
            else
            {
              //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_vacuum2.BackColor = Color.Red;
            }
        }
        ///11.高度差气缸
        private void btn_Differentialcylinder_Click(object sender, EventArgs e)
        {


            string[] add = m_para.Differentialcylinder.Split('.');
            int m_portAdd = int.Parse(add[0]);
            byte m_bit = byte.Parse(add[1]);

            if (btn_Differentialcylinder.BackColor == Color.Red)
            {
              //  FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 1);
                btn_Differentialcylinder.BackColor = Color.Green;
            }
            else
            {
               // FormMain.m_FinsConnecor.WriteBit(m_portAdd, m_bit, 0);
                btn_Differentialcylinder.BackColor = Color.Red;
            }
        }
        //获取当前位置
        private void btn_GetPositionNow_Click(object sender, EventArgs e)
        {
            int position = 0;
            FormMain.m_FinsConnecor.ReadInt16(Add[0], ref position);
            label_PositionNow.Text = position.ToString();
        }
        //设置手动速度
        private void btn_SetSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                short speed = 0;
                speed = Convert.ToInt16(txB_Speed.Text);
                FormMain.m_FinsConnecor.WriteInt16(Add[1], speed);
            }
            catch
            {

            }
        }
        //到目标位置
        private void btn_GoAimPosition_Click(object sender, EventArgs e)
        {
            try
            {
                short AimPosition = 0;
                AimPosition = Convert.ToInt16(txB_AimPosition.Text);
                FormMain.m_FinsConnecor.WriteInt16(Add[1], AimPosition);
            }
            catch
            {

            }

        }

        private void btn_PLCAddPara_Click(object sender, EventArgs e)
        {
            FormPLCAdd frm = new FormPLCAdd();
            frm.ShowDialog();
        }

   

       
       
        


    }
}
