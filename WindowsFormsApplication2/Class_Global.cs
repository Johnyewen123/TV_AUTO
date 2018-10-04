
////////
///封装程序所需全局变量
//////





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace WindowsFormsApplication2
{
    class Class_Global
    {


        public static readonly string AppNameDir = System.AppDomain.CurrentDomain.BaseDirectory;//获取程序所在程序目录

        public static int ComunicationMethod = 1;//通讯方式，串口为1 ，网口为2，默认为串口
        public static bool SaveNGimg = false;//保存OK图像
        public static bool SaveOKimg = false;//保存NG图像
        public static bool Saveimg = false;//保存图像
        public static bool NotSaveImage = true;// not save image


        public static string excellDatapath = AppNameDir + "excell.xls";//excell文件路径
         public static string path = AppDomain.CurrentDomain.BaseDirectory + @"Data" + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
        System.IO.DirectoryInfo info = System.IO.Directory.CreateDirectory(path);

         
        public static string SocketIp;
        public static string SocketPort;


  
     
        /// <summary>
        ///    相机1与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
        /// </summary>
        public static double[] TransCCD1Para = new double[6];
        /// <summary>
        ///    相机2与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
        /// </summary>
        public static double[] TransCCD2Para = new double[6];

        #region  图像的相关参数

        public static double[] Imageprocess = new double[3];
        /// <summary>
        /// 放置阈值
        /// </summary>
        public static double ThresholdPut;
        /// <summary>
        /// 抓取阈值
        /// </summary>
        public static double ThresholdPick;
        /// <summary>
        /// 二次定位阈值
        /// </summary>
        public static double ThresholdSecondLocation;

        #endregion
        /// <summary>
        /// 机械手实际拍照位CCD1位置以及角度
        /// </summary>
        /// 
        public static double RobotCCD1X=0;
        public static double RobotCCD1Y=0;
        public static double RobotCCD1Angle=0;


        /// <summary>
        /// 机械手初始拍照位CCD1位置以及角度
        /// </summary>
//        ///   ZERO_X:=510.193
          //    ZERO_Y:=67.745
        public static double RobotCCD1ZeroX = 510.193;
        public static double RobotCCD1ZeroY = 67.745;
        public static double RobotCCD1ZeroAngle=0;


        /// <summary>
        /// 检测平台的检测结果 A\B\C\D分别表示四个等级
        /// </summary>
        public static string CheckResult;

       ///机械手所在动作
       ///
        public static int Robotstate = 0; //1表示取料位置，2表示二次定位单位位置 3.表示放料位置

        #region 坐标计算相关

        //相机1图像产品在图像中的位置和角度   
        public static HTuple pickX = new HTuple();
        public static HTuple pickY = new HTuple();
        public static HTuple pickAngle = new HTuple();

        //相机1初始拍照位置点以及方向
        public static HTuple pickXfact = new HTuple();
        public static HTuple pickYfact = new HTuple();
        public static HTuple pickAnglefact = new HTuple();
        //相机1中产品的标准角度
        public static double PickOK_RobotAngle = 0;


        //相机2图像产品在图像中的位置   
        public static HTuple putX = new HTuple();
        public static HTuple putY = new HTuple();
       
        // 相机2
        public static HTuple putXfact = new HTuple();
        public static HTuple putYfact = new HTuple();

        ///相机2中产品的标准位置
        ///x=410.226 y=-357.138


        public static double PutOK_RobotX = 410.226-0.502161;
        public static double PutOK_RobotY = -357.138-0.774;




        #endregion

        #region  参数加载

       // public static string Inipath = AppNameDir + "\\Socket.ini";//配置文件存储路径



       # endregion
        #region
        /// <summary>
        /// 相机1序列号、曝光、增益
        /// </summary>
        public static string[] Camera1 = new string[3];

           /// <summary>
        /// 相机2序列号、曝光、增益
        /// </summary>
        public static string[] Camera2 = new string[3];//相机序列号、曝光、增益
      #endregion

        #region  parapath
         public static string pathPara=AppDomain.CurrentDomain.BaseDirectory + @"Para";

        System.IO.DirectoryInfo info1 = System.IO.Directory.CreateDirectory(pathPara);

        public static string LocationParaPath = pathPara + "\\" + "LocationPara.ini";
        public static string CameraParaPath = pathPara + "\\" + "CameraPara.ini";
        public static string SocketParaPath = pathPara + "\\" + "SocketPara.ini";

        public static string loginPath = pathPara + "\\" + "PassWord.ini";

        #endregion

       
    }
}
