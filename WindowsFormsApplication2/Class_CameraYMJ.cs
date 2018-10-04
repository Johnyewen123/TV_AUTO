//using JRS_Vision_Dev;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIS.Imaging;
using HalconDotNet;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WindowsFormsApplication2
{
    public class JRSCameraYMJ
        //: JRSCamera
    {
       public TIS.Imaging.ICImagingControl m_ImageControl;
         private TIS.Imaging.VCDHelpers.VCDSimpleProperty VCDProp;
        ManualResetEvent doneEvent = new ManualResetEvent(true);
        public TIS.Imaging.VCDSwitchProperty TrigEnableSwitch;//触发使能开关
        private TIS.Imaging.VCDSwitchProperty ExposureSwith;//开关属性
        private TIS.Imaging.VCDAbsoluteValueProperty ExposureAbsoluteValue;//绝对曝光值属性
        private TIS.Imaging.VCDAbsoluteValueProperty GainAbsoluteValue;//绝对增益值属性
        private TIS.Imaging.VCDSwitchProperty GainSwith;//开关属性
        private TIS.Imaging.VCDButtonProperty Softtrigger;//触发属性
        int m_nWidth = 2592; //图像宽度
        int m_nHeight = 1944;//图像高度
        byte[] m_byMonoBuffer = null;
        private AutoResetEvent ReturnImgEvent = new AutoResetEvent(false);
       // private Bitmap img;


        public JRSCameraYMJ()
        {
           
        }
        ~JRSCameraYMJ()
        {

        }

        public bool bIsConnected = false;
       public void CameraPara(TIS.Imaging.ICImagingControl icImagingControl1)
        {
            //文件打开相机
            try
            {
                icImagingControl1.LoadDeviceStateFromFile("device1.xml", true);
            }
            catch (Exception)
            {
               // icImagingControl1.ShowDeviceSettingsDialog();
                if (!icImagingControl1.DeviceValid)
                {
                    MessageBox.Show("没有找到设备");                 
                }
                else
                {
                    icImagingControl1.SaveDeviceStateToFile("device1.xml");
                }
            }
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="strSN">相机ID号</param>
        /// <returns>成功返回true，失败返回false</returns>
        /// 
        public  bool  Open(string strSN)
        {
            try
            {
                string tempSN = string.Empty;
                m_ImageControl = new ICImagingControl();
                foreach (Device dev in m_ImageControl.Devices)
                {
                    if (dev.GetSerialNumber(out tempSN))
                    {
                        if (strSN == tempSN)//判断是否等于指定相机序号
                        {
                            m_ImageControl.Device = dev.Name;
                            break;
                        }
                    }
                }
                if (!m_ImageControl.DeviceValid)
                {
                    throw new Exception("没有找到相机，是否SN号有误！");
                }
                if (m_ImageControl.LiveVideoRunning)
                    m_ImageControl.LiveStop();
                m_ImageControl.MemoryCurrentGrabberColorformat = TIS.Imaging.ICImagingControlColorformats.ICY8;
                float[] Frame = m_ImageControl.DeviceFrameRates;
                m_ImageControl.DeviceFrameRate = Frame[0];
                VCDProp = TIS.Imaging.VCDHelpers.VCDSimpleModule.GetSimplePropertyContainer(m_ImageControl.VCDPropertyItems);

                //m_ImageControl.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
                //m_ImageControl.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
                //m_ImageControl.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;

                m_ImageControl.LiveCaptureContinuous = true;
                m_ImageControl.LiveDisplayDefault = false;
                m_ImageControl.ImageAvailable += ImageCallBack;
                m_byMonoBuffer = new byte[m_nWidth * m_nHeight];
                m_ImageControl.LiveStart();
                TrigEnableSwitch = (TIS.Imaging.VCDSwitchProperty)m_ImageControl.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_Value + ":" + TIS.Imaging.VCDIDs.VCDInterface_Switch);
           
                TrigEnableSwitch.Switch = true;


                m_ImageControl.LiveStop();

                //TrigEnableSwitch.Switch = false;
              //  m_ImageControl.DeviceTrigger = false;  Imagecamera cannot set trigger while openning
                bIsConnected = true;
                //IsConnected = true;
                return true;

           
            }
            catch (Exception ex)
            {
                Trace.WriteLine("YMJ Init fail " + ex.Message);
                return false;
            }
        }

        public  bool Close()
        {
            try
            {
                if (m_ImageControl.LiveVideoRunning)
                    m_ImageControl.LiveStop();
              //  IsConnected = false;
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("YMJ Close fail " + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Snap Image Data From Camera
        /// </summary>
        /// <param name="image">Bitmap Image Data</param>
        /// <returns>Indicate Operation Result</returns>
        public  bool SnapImage(out Bitmap image)
        {
            try
            {
                if (!ReturnImgEvent.WaitOne(2000))
                {
                    throw new Exception("Wait YMJ Snap Time Out");
                }
                else
                {
                   // image = img;
                    image = bmp_image1;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("YMJ SnapImage fail " + ex.Message);
                image = null;
                doneEvent.Set();
                return false;
            }
        }

        /// <summary>
        /// 0曝光、1为增益、2帧率，
        /// </summary>
        public enum CamParam
        {
            Exposure = 0,
            Gain = 1,
            FrameRate = 2,
        }
        public  bool SetCamParam(CamParam eParam, string strParamValue)
        {
            try
            {
                switch (eParam)
                {
                    case CamParam.Exposure:
                        //VCDProp.RangeValue[VCDIDs.VCDID_Exposure] = Convert.ToInt32(strParamValue);
                        ExposureSwith = (TIS.Imaging.VCDSwitchProperty)m_ImageControl.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                        ExposureSwith.Switch = false;//关闭自动曝光
                        //绝对曝光对象初始化
                        ExposureAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)m_ImageControl.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                        double time = 1 / Convert.ToDouble(strParamValue);
                        if (time <= ExposureAbsoluteValue.RangeMin)
                        {
                            ExposureAbsoluteValue.Value = ExposureAbsoluteValue.RangeMin;
                        }
                        else if (time >= ExposureAbsoluteValue.RangeMax)
                        {
                            ExposureAbsoluteValue.Value = ExposureAbsoluteValue.RangeMax;
                        }
                        else
                        {
                            ExposureAbsoluteValue.Value = time;
                        }

                        break;
                    case CamParam.FrameRate:
                        //m_ImageControl.DeviceFrameRate = float.Parse(strParamValue);
                        break;
                    case CamParam.Gain:
                        //VCDProp.RangeValue[VCDIDs.VCDID_Gain] = Convert.ToInt32(strParamValue);
                        GainSwith = (TIS.Imaging.VCDSwitchProperty)m_ImageControl.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                        GainSwith.Switch = false;//关闭自动增益
                        //绝对增益对象初始化
                        GainAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)m_ImageControl.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Gain + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                        double GValue = Convert.ToDouble(strParamValue) / 1000;
                        if (GValue <= GainAbsoluteValue.RangeMin)
                        {
                            GainAbsoluteValue.Value = GainAbsoluteValue.RangeMin;
                        }
                        else if (GValue >= GainAbsoluteValue.RangeMax)
                        {
                            GainAbsoluteValue.Value = GainAbsoluteValue.RangeMax;
                        }
                        else
                        {
                            GainAbsoluteValue.Value = GValue;
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
            //    m_strLastErr = ex.Message;
                return false;
            }

        }

        public  bool GetCamParam(CamParam eParam, ref string strParamValue)
        {
            try
            {
                //if (IsConnected)
                //{
                    switch (eParam)
                    {
                        case CamParam.Exposure:
                            strParamValue = VCDProp.RangeValue[VCDIDs.VCDID_Exposure].ToString();
                            break;
                        case CamParam.FrameRate:
                            strParamValue = m_ImageControl.DeviceFrameRate.ToString();
                            break;
                        case CamParam.Gain:
                            strParamValue = VCDProp.RangeValue[VCDIDs.VCDID_Gain].ToString();
                            break;
                        default:
                            break;
                    //}
                    return true;
                }

                    return true;
                //else
                //{
                //    throw new Exception("Please connect the Cmaera first");
                //}
            }
            catch (Exception ex)
            {
                //m_strLastErr = ex.Message;
                return false;
            }
        }
        public bool SoftTrigger()
        {

            try 
            {

                Softtrigger = (TIS.Imaging.VCDButtonProperty)m_ImageControl.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" + TIS.Imaging.VCDIDs.VCDElement_SoftwareTrigger + ":" + TIS.Imaging.VCDIDs.VCDInterface_Button);
                Softtrigger.Push();//软触发


                return true;
            }
            catch
            {

                return false;

            }
        
        }


        #region  回调函数
        public static HalconDotNet.HObject ho_image1 = null;
        public static Bitmap bmp_image1 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera01 = delegate { dhDosome(bmp_image1, ho_image1); };
        static System.Threading.Thread threadProcess1;

        static void dhDosome(Bitmap bmpImage, HalconDotNet.HObject hoIntsnsity)
        {
            //System.Windows.Forms.MessageBox.Show("in class jai say :hello!");
            return;
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



        //取流回调函数
        private void ImageCallBack(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            try
            {
                //Trace.WriteLine(string.Format("触发回调 = {0}", DateTime.Now.ToString("HH:mm:ss:fff")));
                TIS.Imaging.ImageBuffer CurrentBuffer = null;
                CurrentBuffer = m_ImageControl.ImageBuffers[e.bufferIndex];
                bmp_image1  = CurrentBuffer.Bitmap;

                ho_image1 = Bitmap2HObject(bmp_image1);
                // bmp_image1 
                // ReturnImgEvent.Set();
                //Trace.WriteLine(string.Format("获取图像 = {0}",DateTime.Now.ToString("HH:mm:ss:fff")));

                if (bmp_image1 != null)
                {
                    bool benableNew = false;
                    if (threadProcess1 == null) benableNew = true;
                    else if (!threadProcess1.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess1 = new System.Threading.Thread(processCamera01);
                        threadProcess1.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message + "回调失败！！！");
            }
        }

     #endregion



    }
}

