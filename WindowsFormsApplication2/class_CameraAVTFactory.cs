/*=============================================================================
  Copyright (C) 2012 Allied Vision Technologies.  All Rights Reserved.

  Redistribution of this file, in original or modified form, without
  prior written consent of Allied Vision Technologies is prohibited.

-------------------------------------------------------------------------------

  File:        CameraFactory.cs

  Description: The CameraFactory example will create a suitable object for
               each known interface. The user can create his own factory and 
               camera classes for customisation.

-------------------------------------------------------------------------------

  THIS SOFTWARE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR IMPLIED
  WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF TITLE,
  NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR A PARTICULAR  PURPOSE ARE
  DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT,
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
  LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED
  AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
  TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
  OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

=============================================================================*/
using System;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;
//using JW_OT002Demo;
using AVT.VmbAPINET;

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WindowsFormsApplication2
{
    public class class_CameraAVT
    {

        #region AVT Camera Control
        private Vimba sysAVT;
        /// <summary>
        /// 相机个数
        /// </summary>
        public int iCameraCount = 0;
        /// <summary>
        /// 实际相机有没有找到，和注册表里面的相机序列号对应
        /// </summary>
        public static bool[] bCameraListFind = new bool[] { };
        /// <summary>
        /// 注册表里面的相机序列号
        /// //
        /// "285937813", "285944105"
        public static string[] strCameraSn = new string[] { "285937816", "285944968" };
        /// 注册表里面的相机对应的参数
        /// </summary>
        public string[] strCameraParam = new string[] { };
        public static Camera[] myCameras = new Camera[] { };

        //private AVT.VmbAPINET.Examples.FirewireCamera[] firewallCameras = new AVT.VmbAPINET.Examples.FirewireCamera[] { };.
        //private AVT.VmbAPINET.Examples.GigECamera[] gigECameras = new AVT.VmbAPINET.Examples.GigECamera[] { };
        //private AVT.VmbAPINET.Examples.USBCamera[] usbCameras = new AVT.VmbAPINET.Examples.USBCamera[] { };
        private RingBitmap m_RingBitmap = null;
        private const int m_RingBitmapSize = 2;
        private static bool m_ImageInUse = true;
        //
        private static Socket RemoveETrigger = null;
        #endregion
        private bool bneedHalconObject = false;
        public class_CameraAVT(bool bneedHObject)
        {
            bneedHalconObject = bneedHObject;
        }
        public void InitializeAVTCameras()
        {
            try
            {
                sysAVT = new Vimba();

                CameraCollection cameras;

                VmbInterfaceType interfaceType = VmbInterfaceType.VmbInterfaceUnknown; // The interface type of the cam

                sysAVT.Startup();
                sysAVT.CreateCamera += new Vimba.CreateCameraHandler(AVT.VmbAPINET.Examples.UserCameraFactory.MyCameraFactory);  // register the CreateCamera function

                cameras = sysAVT.Cameras;

                iCameraCount = cameras.Count;

                bCameraListFind = new bool[strCameraSn.Length];
                for (int cam_Num = 0; cam_Num < strCameraSn.Length; cam_Num++) bCameraListFind[cam_Num] = false;

                myCameras = new Camera[strCameraSn.Length];

                for (int ihh = 0; ihh < strCameraSn.Length; ihh++)
                {
                    for (int iCamNumber = 0; iCamNumber < iCameraCount; iCamNumber++)
                    {
                        if (strCameraSn[ihh] == cameras[iCamNumber].SerialNumber)
                        {
                            bCameraListFind[ihh] = true;
                            myCameras[ihh] = cameras[iCamNumber];
                            break;
                        }
                        else
                        {
                            bCameraListFind[ihh] = false;
                        }
                    }
                }

                if (myCameras.Length > 0)
                {
                    for (int icamNumber = 0; icamNumber < myCameras.Length; icamNumber++)
                    {
                        if (!bCameraListFind[icamNumber]) continue;
                        if (icamNumber == 0)
                        {
                            Camera fwCam = myCameras[icamNumber];
                            // Camera fwCam = myCameras[0];
                            fwCam.Open(VmbAccessModeType.VmbAccessModeFull);
                            bCameraListFind[icamNumber] = true;
                            FeatureCollection features = fwCam.Features;
                            AdjustPixelFormat(fwCam);
                            m_RingBitmap = new RingBitmap(m_RingBitmapSize);
                            m_ImageInUse = true;

                            //相机图像长宽\设置
                            features["Width"].IntValue = 2452;
                            features["Height"].IntValue = 2056;
                            features["TriggerMode"].StringValue = "Off";
                            features["ExposureAuto"].StringValue = "Off";
                            features["PixelFormat"].StringValue = "Mono8";
                            features["Gain"].FloatValue = 13.64;
                            //曝光时间设置
                            features["ExposureTime"].FloatValue = 6000.0;
                            features["TriggerActivation"].StringValue = "RisingEdge";
                            features["TriggerMode"].StringValue = "Off";
                        }

                        if (icamNumber == 1)
                        {
                            Camera fwCam = myCameras[icamNumber];
                            // Camera fwCam = myCameras[0];
                            fwCam.Open(VmbAccessModeType.VmbAccessModeFull);
                            bCameraListFind[icamNumber] = true;
                            FeatureCollection features = fwCam.Features;
                            AdjustPixelFormat(fwCam);
                            m_RingBitmap = new RingBitmap(m_RingBitmapSize);
                            m_ImageInUse = true;

                            //相机图像长宽\设置
                            features["Width"].IntValue = 2452;
                            features["Height"].IntValue = 2056;
                            features["TriggerMode"].StringValue = "Off";
                            features["ExposureAuto"].StringValue = "Off";
                            features["PixelFormat"].StringValue = "Mono8";
                            features["Gain"].FloatValue = 13.25;
                            //曝光时间设置
                            features["ExposureTime"].FloatValue = 5000.00;
                            features["TriggerActivation"].StringValue = "RisingEdge";
                            features["TriggerMode"].StringValue = "Off";
                        }



                        if (icamNumber == 0)
                        {
                            myCameras[icamNumber].OnFrameReceived += new AVT.VmbAPINET.Camera.OnFrameReceivedHandler(Cam1_OnFrameReceived);
                        }
                        if (icamNumber == 1)
                        {
                            myCameras[icamNumber].OnFrameReceived += new AVT.VmbAPINET.Camera.OnFrameReceivedHandler(Cam2_OnFrameReceived);
                        }

                        //myCameras[0].OnFrameReceived += new AVT.VmbAPINET.Camera.OnFrameReceivedHandler(Cam1_OnFrameReceived);

                        //myCameras[1].OnFrameReceived += new AVT.VmbAPINET.Camera.OnFrameReceivedHandler(Cam1_OnFrameReceived);
                    }
                }







                else
                {

                }




            }
            catch (Exception exc)
            {
                MessageBox.Show("InitializeAVTCameras()跳出");
            }

        }
        public void SetExposureTime(int i)
        {
            for (int icamNumber = 0; icamNumber < myCameras.Length - 1; icamNumber++)
            {
                Camera fwCam = myCameras[icamNumber];
                FeatureCollection features = fwCam.Features;
                features["ExposureTime"].FloatValue = 5000.0;///////////////////////
            }
        }
        /// <summary>
        /// =10全部开始 =1 开启第一个 =2 开启第2个
        /// </summary>
        /// <param name="icamIndex"></param>
        public void startCameras(int icamIndex)
        {
            try
            {
                myCameras[0].StartContinuousImageAcquisition(3);
             //   FormMain.Isccd1Detect = true;

            }
            catch (Exception exc)
            {
               // FormMain.Isccd1Detect = false;
                // MessageBox.Show(1.ToString() + "相机开启出错");

            }
            try
            {
                myCameras[1].StartContinuousImageAcquisition(3);
               // FormMain.Isccd2Detect = true;

            }
            catch (Exception exc)
            {
                MessageBox.Show(2.ToString() + "相机开启出错");
              //  FormMain.Isccd2Detect = false;
            }

        }
        public void stopCameras(int icamIndex)
        {
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                        myCameras[cam_Num].StopContinuousImageAcquisition();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show((icamIndex + 1).ToString() + "相机停止出错");
            }
        }
        public void closeCameras()
        {
            sysAVT.Shutdown();
        }
        public void setcameraTriggerOn(int icamIndex)
        {
            bneedHalconObject = true;
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                    {
                        myCameras[cam_Num].Features["TriggerMode"].StringValue = "On";
                        //myCameras[cam_Num].Features["TriggerDelay"].StringValue = "0";
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show((icamIndex + 1).ToString() + "相机触发模式on出错");
            }
        }
        public void setcameraTriggerOff(int icamIndex)
        {
            bneedHalconObject = false;
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                        myCameras[cam_Num].Features["TriggerMode"].StringValue = "Off";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show((icamIndex + 1).ToString() + "相机触发模式off出错");
            }
        }
        public void setcameraParam(int icamIndex)
        {
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                    {
                        //0-曝光# 2-触发延时
                        string[] strParam = strCameraParam[cam_Num].Split('#');

                        myCameras[cam_Num].Features["ExposureTime"].FloatValue = int.Parse(strParam[0]);
                        //myCameras[cam_Num].Features["AcquisitionFrameRate"].FloatValue = int.Parse(strParam[2]);
                        myCameras[cam_Num].Features["TriggerDelay"].FloatValue = float.Parse(strParam[3]);

                    }
                }
            }
            catch (Exception exc)
            {
                //dhDll.frmMsg.Log("设置AVT相机曝光等参数出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }
        public void setcameraOutputOn(int icamIndex, int iport)
        {
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                    {
                        ulong[] addressArray = new ulong[] { 0xf1000320 };

                        if (iport == 2) addressArray = new ulong[] { 0xf1000324 };
                        else if (iport == 3) addressArray = new ulong[] { 0xf1000328 };

                        ulong[] dataArray = new ulong[] { 0xC0010000 };
                        uint completedReads = 0;
                        long lkk = Convert.ToInt64("11000000000000010000000000000001", 2);
                        dataArray = new ulong[] { (ulong)lkk };

                        myCameras[cam_Num].WriteRegisters(addressArray, dataArray, ref completedReads);
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show((icamIndex + 1).ToString() + "相机OutPutON出错");
            }
        }
        public void setcameraOutputOff(int icamIndex, int iport)
        {
            try
            {
                for (int cam_Num = 0; cam_Num < myCameras.Length; cam_Num++)
                {
                    if ((icamIndex == 10 || icamIndex == cam_Num) && bCameraListFind[cam_Num])
                    {
                        ulong[] addressArray = new ulong[] { 0xf1000320 };

                        if (iport == 2) addressArray = new ulong[] { 0xf1000324 };
                        else if (iport == 3) addressArray = new ulong[] { 0xf1000328 };

                        ulong[] dataArray = new ulong[] { 0xC0010000 };
                        uint completedReads = 0;
                        long lkk = Convert.ToInt64("11000000000000010000000000000000", 2);
                        dataArray = new ulong[] { (ulong)lkk };

                        myCameras[cam_Num].WriteRegisters(addressArray, dataArray, ref completedReads);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show((icamIndex + 1).ToString() + "相机OutPutOFF出错");
            }
        }

        public static HalconDotNet.HObject ho_image1 = null;
        public static Bitmap bmp_image1 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera01 = delegate { Dosome(bmp_image1, ho_image1); };

        public static HalconDotNet.HObject ho_image2 = null;
        public static Bitmap bmp_image2 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera02 = delegate { Dosome(bmp_image2, ho_image2); };

        static void Dosome(Bitmap bmpImage, HalconDotNet.HObject hoIntsnsity)
        {
            //System.Windows.Forms.MessageBox.Show("in class jai say :hello!");
            return;
        }

        static System.Threading.Thread threadProcess1, threadProcess2;
        public static string receivetest(Socket server)
        {

            //   byte[] msg = Encoding.UTF8.GetBytes("a");
            byte[] bytes = new byte[1];
            string result;
            try
            {

                int i = server.Receive(bytes);
                result = Encoding.UTF8.GetString(bytes);


            }
            catch
            {
                result = "error";

            }
            return result;

        }
        void Cam1_OnFrameReceived(AVT.VmbAPINET.Frame frame)
        {


            //字符串屏蔽误触发
            //IPAddress broadcast = IPAddress.Parse("192.168.13.10");
            //RemoveETrigger = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //RemoveETrigger.Connect(new IPEndPoint(broadcast, 5050)); //配置服务器IP与端口 ,,机器人端作为服务器，一直开启       
            //string R;
            //R = receivetest(RemoveETrigger);
            //RemoveETrigger.Close();

          //  ++FormMain.ccd1FrameNum;
            try
            {
                frame.Fill(ref bmp_image1);
                //说明相机1已经拍照                    
                if (bneedHalconObject)
                {
                    unsafe
                    {
                        fixed (byte* pSrc = frame.Buffer)
                        {
                            HalconDotNet.HOperatorSet.GenImage1(out ho_image1, "byte", bmp_image1.Width, bmp_image1.Height, (int)pSrc);
                        }
                    }
                }
                if (bmp_image1 != null)
                {
                    bool benableNew = false;
                    if (threadProcess1 == null) benableNew = true;
                    else if (!threadProcess1.IsAlive) benableNew = true;
                    if (benableNew)
                    {
                        //if (R == "a")
                        //{
                        threadProcess1 = new System.Threading.Thread(processCamera01);
                        threadProcess1.Start();
                      //  FormMain.RemoveEgrab = 1;
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cam1_OnFrameReceived()跳出");
            }
            finally
            {
                try
                {
                    myCameras[0].QueueFrame(frame);
                }
                catch (AVT.VmbAPINET.VimbaException ex)
                { }

            }





        }
        void Cam2_OnFrameReceived(AVT.VmbAPINET.Frame frame)
        {
            //若相机拍照完毕
           // ++FormMain.ccd2FrameNum;
            //字符串屏蔽误触发

            //IPAddress broadcast = IPAddress.Parse("192.168.13.10");
            //RemoveETrigger = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //RemoveETrigger.Connect(new IPEndPoint(broadcast, 5050)); //配置服务器IP与端口 ,,机器人端作为服务器，一直开启       
            //string R;
            //R = receivetest(RemoveETrigger);
            //RemoveETrigger.Close();
            try
            {
                frame.Fill(ref bmp_image2);
                if (bneedHalconObject)
                {
                    unsafe
                    {
                        fixed (byte* pSrc = frame.Buffer)
                        {
                            HalconDotNet.HOperatorSet.GenImage1(out ho_image2, "byte", bmp_image2.Width, bmp_image2.Height, (int)pSrc);
                        }
                    }
                }
                if (bmp_image2 != null)
                {
                    bool benableNew = false;
                    if (threadProcess2 == null) benableNew = true;
                    else if (!threadProcess2.IsAlive) benableNew = true;
                    if (benableNew)
                    {
                        threadProcess2 = new System.Threading.Thread(processCamera02);
                        threadProcess2.Start();

                        //if (FormMain.RemoveEgrab == 1)
                        //{
                        //    //if (R == "b")
                        //    //{
                        //    threadProcess2.Start();
                        //    FormMain.RemoveEgrab = 2;  //相机检测状态 
                        //    //}
                        //}
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cam2_OnFrameReceived()跳出");
            }
            finally
            {
                try
                {
                    myCameras[1].QueueFrame(frame);
                }
                catch (AVT.VmbAPINET.VimbaException ex)
                { }
            }
            //}
        }


        private void AdjustPixelFormat(Camera camera)
        {
            if (null == camera)
            {
                throw new ArgumentNullException("camera");
            }

            string[] supportedPixelFormats = new string[] { "BGR8Packed", "Mono8" };
            //Check for compatible pixel format
            Feature pixelFormatFeature = camera.Features["PixelFormat"];

            //Determine current pixel format
            string currentPixelFormat = pixelFormatFeature.EnumValue;

            //Check if current pixel format is supported
            bool currentPixelFormatSupported = false;
            foreach (string supportedPixelFormat in supportedPixelFormats)
            {
                if (string.Compare(currentPixelFormat, supportedPixelFormat, StringComparison.Ordinal) == 0)
                {
                    currentPixelFormatSupported = true;
                    break;
                }
            }

            //Only adjust pixel format if we not already have a compatible one.
            if (false == currentPixelFormatSupported)
            {
                //Determine available pixel formats
                string[] availablePixelFormats = pixelFormatFeature.EnumValues;

                //Check if there is a supported pixel format
                bool pixelFormatSet = false;
                foreach (string supportedPixelFormat in supportedPixelFormats)
                {
                    foreach (string availablePixelFormat in availablePixelFormats)
                    {
                        if ((string.Compare(supportedPixelFormat, availablePixelFormat, StringComparison.Ordinal) == 0)
                            && (pixelFormatFeature.IsEnumValueAvailable(supportedPixelFormat) == true))
                        {
                            //Set the found pixel format
                            pixelFormatFeature.EnumValue = supportedPixelFormat;
                            pixelFormatSet = true;
                            break;
                        }
                    }

                    if (true == pixelFormatSet)
                    {
                        break;
                    }
                }

                if (false == pixelFormatSet)
                {
                    throw new Exception("None of the pixel formats that are supported by this example (Mono8 and BRG8Packed) can be set in the camera.");
                }
            }
        }

    }





    class RingBitmap
    {
        private int m_Size = 0;
        private Bitmap[] m_Bitmaps = null;              //Bitmaps to display images
        private int m_BitmapSelector = 0;               //selects Bitmap

        public RingBitmap(int size)
        {
            m_Size = size;
            m_Bitmaps = new Bitmap[m_Size];
        }

        //Bitmap rotation selector
        private void SwitchBitamp()
        {
            m_BitmapSelector++;

            if (m_Size == m_BitmapSelector)
                m_BitmapSelector = 0;
        }

        //return current bitmap as image
        public Image Image
        {
            get
            {
                return m_Bitmaps[m_BitmapSelector];
            }
        }

        //copy buffer in 8bppIndexed bitmap
        public void CopyToNextBitmap_8bppIndexed(int width, int height, byte[] buffer)
        {
            //switch to Bitmap object which is currently not in use by GUI
            SwitchBitamp();

            //check if this Bitmap object was already created -> else reuse it
            if (null == m_Bitmaps[m_BitmapSelector])
                m_Bitmaps[m_BitmapSelector] = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            //Set greyscale palette
            ColorPalette palette = m_Bitmaps[m_BitmapSelector].Palette;
            for (int i = 0; i < palette.Entries.Length; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            m_Bitmaps[m_BitmapSelector].Palette = palette;

            //Copy image data
            BitmapData bitmapData = m_Bitmaps[m_BitmapSelector].LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        width,
                                                                                        height),
                                                                         ImageLockMode.WriteOnly,
                                                                         PixelFormat.Format8bppIndexed);
            try
            {
                //Copy image data line by line
                for (int y = 0; y < height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(buffer,
                                                                y * width,
                                                                new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                width);
                }
            }
            finally
            {
                m_Bitmaps[m_BitmapSelector].UnlockBits(bitmapData);
            }
        }

        //copy buffer in 24bppRgb bitmap
        public void CopyToNextBitmap_24bppRgb(int width, int height, byte[] buffer)
        {
            //switch to Bitmap object which is currently not in use by GUI
            SwitchBitamp();

            //check if this Bitmap object was already created -> else reuse it
            if (null == m_Bitmaps[m_BitmapSelector])
                m_Bitmaps[m_BitmapSelector] = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            //Copy image data
            BitmapData bitmapData = m_Bitmaps[m_BitmapSelector].LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        width,
                                                                                        height),
                                                                        ImageLockMode.WriteOnly,
                                                                        PixelFormat.Format24bppRgb);
            try
            {
                //Copy image data line by line
                for (int y = 0; y < height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(buffer,
                                                                y * width * 3,
                                                                new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                width * 3);
                }
            }
            finally
            {
                m_Bitmaps[m_BitmapSelector].UnlockBits(bitmapData);
            }
        }

        //接受网口数据
        public static string receivetest(Socket server)
        {


            byte[] bytes = new byte[1];
            string result;
            try
            {

                int i = server.Receive(bytes);
                result = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                result = "e";
            }
            return result;

        }

    }



}

namespace AVT
{
    namespace VmbAPINET
    {
        namespace Examples
        {


            public class FirewireCamera : Camera
            {
                public FirewireCamera(string cameraID,
                                        string cameraName,
                                        string cameraModel,
                                        string cameraSerialNumber,
                                        string interfaceID,
                                        VmbInterfaceType interfaceType,
                                        string interfaceName,
                                        string interfaceSerialNumber,
                                        VmbAccessModeType interfacePermittedAccess)
                    : base(cameraID,
                            cameraName,
                            cameraModel,
                            cameraSerialNumber,
                            interfaceID,
                            interfaceType,
                            interfaceName,
                            interfaceSerialNumber,
                            interfacePermittedAccess)
                {
                }

                public void addonFirewire(string info)  // custom camera function
                {
                    info = "1394 interface connection detected";
                }
            };

            public class GigECamera : Camera
            {
                public GigECamera(string cameraID,
                                    string cameraName,
                                    string cameraModel,
                                    string cameraSerialNumber,
                                    string interfaceID,
                                    VmbInterfaceType interfaceType,
                                    string interfaceName,
                                    string interfaceSerialNumber,
                                    VmbAccessModeType interfacePermittedAccess)
                    : base(cameraID,
                            cameraName,
                            cameraModel,
                            cameraSerialNumber,
                            interfaceID,
                            interfaceType,
                            interfaceName,
                            interfaceSerialNumber,
                            interfacePermittedAccess)
                {
                }

                public void addonGigE(string info)  // custom camera function
                {
                    info = "ethernet interface connection detected";
                }
            };

            public class USBCamera : Camera
            {
                public USBCamera(string cameraID,
                                    string cameraName,
                                    string cameraModel,
                                    string cameraSerialNumber,
                                    string interfaceID,
                                    VmbInterfaceType interfaceType,
                                    string interfaceName,
                                    string interfaceSerialNumber,
                                    VmbAccessModeType interfacePermittedAccess)
                    : base(cameraID,
                            cameraName,
                            cameraModel,
                            cameraSerialNumber,
                            interfaceID,
                            interfaceType,
                            interfaceName,
                            interfaceSerialNumber,
                            interfacePermittedAccess)
                {
                }

                public void addonUSB(string info)  // custom camera function
                {
                    info = "usb interface connection detected";
                }
            }

            // class to give possiblility to create standart camera
            class DefaultCamera : Camera
            {
                public DefaultCamera(string cameraID,
                                     string cameraName,
                                     string cameraModel,
                                     string cameraSerialNumber,
                                     string interfaceID,
                                     VmbInterfaceType interfaceType,
                                     string interfaceName,
                                     string interfaceSerialNumber,
                                     VmbAccessModeType interfacePermittedAccess)
                    : base(cameraID,
                            cameraName,
                            cameraModel,
                            cameraSerialNumber,
                            interfaceID,
                            interfaceType,
                            interfaceName,
                            interfaceSerialNumber,
                            interfacePermittedAccess)
                {
                }
            }

            public class UserCameraFactory
            {
                static public Camera MyCameraFactory(string cameraID,
                                                        string cameraName,
                                                        string cameraModel,
                                                        string cameraSerialNumber,
                                                        string interfaceID,
                                                        VmbInterfaceType interfaceType,
                                                        string interfaceName,
                                                        string interfaceSerialNumber,
                                                        VmbAccessModeType interfacePermittedAccess)
                {
                    // create camera class, depending on camera interface type
                    if (VmbInterfaceType.VmbInterfaceFirewire == interfaceType)
                    {
                        return new FirewireCamera(cameraID,
                                                  cameraName,
                                                  cameraModel,
                                                  cameraSerialNumber,
                                                  interfaceID,
                                                  interfaceType,
                                                  interfaceName,
                                                  interfaceSerialNumber,
                                                  interfacePermittedAccess);
                    }
                    else if (VmbInterfaceType.VmbInterfaceEthernet == interfaceType)
                    {
                        return new GigECamera(cameraID,
                                              cameraName,
                                              cameraModel,
                                              cameraSerialNumber,
                                              interfaceID,
                                              interfaceType,
                                              interfaceName,
                                              interfaceSerialNumber,
                                              interfacePermittedAccess);
                    }
                    else if (VmbInterfaceType.VmbInterfaceUsb == interfaceType)
                    {
                        return new USBCamera(cameraID,
                                             cameraName,
                                             cameraModel,
                                             cameraSerialNumber,
                                             interfaceID,
                                             interfaceType,
                                             interfaceName,
                                             interfaceSerialNumber,
                                             interfacePermittedAccess);
                    }
                    else // unknown camera interface
                    {
                        // use default camera class
                        return new DefaultCamera(cameraID,
                                                 cameraName,
                                                 cameraModel,
                                                 cameraSerialNumber,
                                                 interfaceID,
                                                 interfaceType,
                                                 interfaceName,
                                                 interfaceSerialNumber,
                                                 interfacePermittedAccess);
                    }
                }
            }

        }
    }
} // Namespace AVT::Vimba::Exanples