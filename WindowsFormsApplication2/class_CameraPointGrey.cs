/*=============================================================================
  Copyright (C) 2012 Allied Vision Technologies.  All Rights Reserved.

  Redistribution of this file, in original or modified form, without
  prior written consent of Allied Vision Technologies is prohibited.

-------------------------------------------------------------------------------

  File:        CameraPointGrey.cs

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
using System.Collections.Generic;
using System.Runtime.InteropServices;//DllImport
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using FlyCapture2Managed;

namespace WindowsFormsApplication2
{
    class class_CameraPointGrey
    {
        /*****默认最多可同时使用8台相机*****/

        #region PointGrey Cameras Control

        [DllImport("kernel32", EntryPoint = "RtlMoveMemory", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern void CopyMemory(int Destination, int Source, int length);

        /// <summary>
        /// 相机个数
        /// </summary>
        public uint iCameraCount = 0;

        /// <summary>
        /// 实际相机有没有找到，和注册表里面的相机序列号对应
        /// </summary>
        public bool[] bCameraListFind = new bool[] { };

        /// <summary>
        /// 注册表里面的相机序列号，实例化类之后=Parameter.strCameraSn
        /// </summary>
        public string[] strCameraSn = new string[] { "14421202", "14420950" };
        public uint[] SnCamera = { 14421202, 14420950 };

        /// <summary>
        /// 注册表里面的相机对应的参数 用于初始化相机
        /// </summary>
        public string[] strCameraParam = new string[] { };

        /// <summary>
        /// 相机总线控制类
        /// </summary>
        public ManagedBusManager busMgr;

        public ManagedCamera[] myCameras;

        public ManagedCamera myCamera;
        //  public ManagedCamera[] myCameras = new ManagedCamera[] { };

        public ManagedCamera camera1;//1394相机类
        public ManagedCamera camera2;

        static ColorPalette palImage;
        #endregion

        public class_CameraPointGrey()
        {
            //初始化调色板
            Bitmap bmzod = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            palImage = bmzod.Palette;
            for (int i = 0; i <= 255; i++)
            {
                palImage.Entries[i] = Color.FromArgb(255, i, i, i);
            }
        }



        /// <summary>
        /// 初始化相机
        /// </summary>
        public void initilizePGCamera()
        {
            try
            {
                busMgr = new ManagedBusManager();
                //获取可查找到的相机数量
                iCameraCount = busMgr.GetNumOfCameras();

                bCameraListFind = new bool[strCameraSn.Length];
                for (int igg = 0; igg < strCameraSn.Length; igg++) bCameraListFind[igg] = false;

                myCameras = new ManagedCamera[strCameraSn.Length];

                //按照相机序列号一一匹配相机
                for (int i = 0; i < strCameraSn.Length; i++)
                {
                    //  uint m_serialNumber = Convert.ToUInt32( strCameraSn[ihh]);
                    myCameras[i] = new ManagedCamera();

                    myCamera = new ManagedCamera();
                    uint m_serialNumber = SnCamera[i];
                    ManagedPGRGuid guid = busMgr.GetCameraFromSerialNumber(m_serialNumber);
                    if (guid != null)
                    {
                        myCameras[i].Connect(guid);
                        //myCamera.Connect(guid);
                        bCameraListFind[i] = true;
                    }

                }
                //初始化每个相机的参数
                if (myCameras.Length > 0)
                {
                    //待补充

                }
                else
                {
                    //     dhDll.frmMsg.Log("没有搜索到PointGrey相机!请查看连接!", 1, 2, 0);
                }

                //for (uint i = 0; i < iCameraCount; i++)
                //{
                //    ManagedPGRGuid guid = busMgr.GetCameraFromIndex(i);
                //    ManagedPGRGuid guid1 = busMgr.GetCameraFromSerialNumber(123456);
                //    if (i == 0)
                //    {
                //        camera1.Connect(guid);
                //    }
                //    if (i == 1)
                //    {
                //        camera2.Connect(guid);
                //    }

                //}
                //

            }
            catch (Exception exc)
            {
                // dhDll.frmMsg.Log("初始化PointGrey相机出错!请查看驱动和连接:" + exc.Message, 1, 2, 0);
            }


        }
        /// <summary>
        /// 打开标示为icamIndex相机 =888 全部打开
        /// </summary>
        public void startPGCameras(int icamIndex)
        {
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                    {
                        switch (igg)
                        {
                            case 0:
                                myCameras[igg].StartCapture(myCamera1_HandleImage);
                                break;
                            case 1:
                                myCameras[igg].StartCapture(myCamera2_HandleImage);
                                break;
                            case 2:
                                myCameras[igg].StartCapture(myCamera3_HandleImage);
                                break;
                            case 3:
                                myCameras[igg].StartCapture(myCamera4_HandleImage);
                                break;
                            case 4:
                                myCameras[igg].StartCapture(myCamera5_HandleImage);
                                break;
                            case 5:
                                myCameras[igg].StartCapture(myCamera6_HandleImage);
                                break;
                            case 6:
                                myCameras[igg].StartCapture(myCamera7_HandleImage);
                                break;
                            case 7:
                                myCameras[igg].StartCapture(myCamera8_HandleImage);
                                break;

                        }


                    }
                }
            }
            catch (Exception exc)
            {
                //dhDll.frmMsg.Log("开启PointGrey相机采图出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }

        }
        /// <summary>
        /// 停止指定相机采集 =888 停止全部
        /// </summary>
        /// <param name="icamIndex"></param>
        public void stopPGCameras(int icamIndex)
        {
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                        myCameras[igg].StopCapture();
                }
            }
            catch (Exception exc)
            {
                //dhDll.frmMsg.Log("停止PointGrey相机采图出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }
        /// <summary>
        /// 关闭所有函数
        /// </summary>
        public void closePGCameras()
        {
            //关闭所有相机
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if (bCameraListFind[igg])
                {
                    myCameras[igg].Disconnect();
                    myCameras[igg].Dispose();
                }
            }
            if (null != busMgr)
            {
                busMgr.Dispose();
            }
        }

        /********************* 相机设置***********************/
        #region 相机设置函数
        public void setCameraTriggerOn(int iCamIndex)
        {

        }

        public void setCameraTriggerOff(int iCamIndex)
        {

        }

        #endregion
        /********************* 相机回调***********************/
        static System.Threading.Thread threadProcess1, threadProcess2, threadProcess3, threadProcess4, threadProcess5, threadProcess6, threadProcess7, threadProcess8;

        static void futureDosome(Bitmap bmpImage, HalconDotNet.HObject hoIntsnsity)
        {
            //System.Windows.Forms.MessageBox.Show("in class PointGreyCamera say :hello!");
            return;
        }

        #region 相机1回调设置
        public static HalconDotNet.HObject ho_image1 = null;
        public static Bitmap bmp_image1 = null;
        /// <summary>
        /// 相机1主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG1 = delegate { futureDosome(bmp_image1, ho_image1); };
        /// <summary>
        /// 相机1回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera1_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_image1 = BitmapCopy(img.bitmap);
                    //bmp_image = img.bitmap;
                    bmp_image1.Palette = palImage;
                    ho_image1 = Bitmap2HObject(bmp_image1);
                    if (bmp_image1 != null)
                    {
                        threadProcess1 = new System.Threading.Thread(processPG1);
                        threadProcess1.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机2回调设置
        public static HalconDotNet.HObject ho_img_cam2 = null;
        public static Bitmap bmp_img_cam2 = null;
        /// <summary>
        /// 相机2主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG2 = delegate { futureDosome(bmp_img_cam2, ho_img_cam2); };
        /// <summary>
        /// 相机2回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera2_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam2 = BitmapCopy(img.bitmap);
                    bmp_img_cam2.Palette = palImage;
                    ho_img_cam2 = Bitmap2HObject(bmp_img_cam2);
                    if (bmp_img_cam2 != null)
                    {
                        threadProcess2 = new System.Threading.Thread(processPG2);
                        threadProcess2.Start();

                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机3回调设置
        public static HalconDotNet.HObject ho_img_cam3 = null;
        public static Bitmap bmp_img_cam3 = null;
        /// <summary>
        /// 相机3主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG3 = delegate { futureDosome(bmp_img_cam3, ho_img_cam3); };
        /// <summary>
        /// 相机3回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera3_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam3 = BitmapCopy(img.bitmap);
                    bmp_img_cam3.Palette = palImage;
                    ho_img_cam3 = Bitmap2HObject(bmp_img_cam3);
                    if (bmp_img_cam3 != null)
                    {
                        threadProcess3 = new System.Threading.Thread(processPG3);
                        threadProcess3.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机4回调设置
        public static HalconDotNet.HObject ho_img_cam4 = null;
        public static Bitmap bmp_img_cam4 = null;
        /// <summary>
        /// 相机4主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG4 = delegate { futureDosome(bmp_img_cam4, ho_img_cam4); };
        /// <summary>
        /// 相机4回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera4_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam4 = BitmapCopy(img.bitmap);
                    bmp_img_cam4.Palette = palImage;
                    ho_img_cam4 = Bitmap2HObject(bmp_img_cam4);
                    if (bmp_img_cam4 != null)
                    {
                        threadProcess4 = new System.Threading.Thread(processPG4);
                        threadProcess4.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机5回调设置
        public static HalconDotNet.HObject ho_img_cam5 = null;
        public static Bitmap bmp_img_cam5 = null;
        /// <summary>
        /// 相机5主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG5 = delegate { futureDosome(bmp_img_cam5, ho_img_cam5); };
        /// <summary>
        /// 相机5回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera5_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam5 = BitmapCopy(img.bitmap);
                    bmp_img_cam5.Palette = palImage;
                    ho_img_cam5 = Bitmap2HObject(bmp_img_cam5);
                    if (bmp_img_cam5 != null)
                    {
                        threadProcess5 = new System.Threading.Thread(processPG5);
                        threadProcess5.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机6回调设置
        public static HalconDotNet.HObject ho_img_cam6 = null;
        public static Bitmap bmp_img_cam6 = null;
        /// <summary>
        /// 相机6主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG6 = delegate { futureDosome(bmp_img_cam6, ho_img_cam6); };
        /// <summary>
        /// 相机6回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera6_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam6 = BitmapCopy(img.bitmap);
                    bmp_img_cam6.Palette = palImage;
                    ho_img_cam6 = Bitmap2HObject(bmp_img_cam6);
                    if (bmp_img_cam6 != null)
                    {
                        threadProcess6 = new System.Threading.Thread(processPG6);
                        threadProcess6.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机7回调设置
        public static HalconDotNet.HObject ho_img_cam7 = null;
        public static Bitmap bmp_img_cam7 = null;
        /// <summary>
        /// 相机7主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG7 = delegate { futureDosome(bmp_img_cam7, ho_img_cam7); };
        /// <summary>
        /// 相机7回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera7_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam7 = BitmapCopy(img.bitmap);
                    bmp_img_cam7.Palette = palImage;
                    ho_img_cam7 = Bitmap2HObject(bmp_img_cam7);
                    if (bmp_img_cam7 != null)
                    {
                        threadProcess7 = new System.Threading.Thread(processPG7);
                        threadProcess7.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 相机8回调设置
        public static HalconDotNet.HObject ho_img_cam8 = null;
        public static Bitmap bmp_img_cam8 = null;
        /// <summary>
        /// 相机8主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processPG8 = delegate { futureDosome(bmp_img_cam8, ho_img_cam8); };
        /// <summary>
        /// 相机8回调函数
        /// </summary>
        /// <param name="img"></param>
        void myCamera8_HandleImage(ManagedImage img)
        {
            try
            {
                if (img.pixelFormat == FlyCapture2Managed.PixelFormat.PixelFormatMono8)
                {
                    bmp_img_cam8 = BitmapCopy(img.bitmap);
                    bmp_img_cam8.Palette = palImage;
                    ho_img_cam8 = Bitmap2HObject(bmp_img_cam8);
                    if (bmp_img_cam8 != null)
                    {
                        threadProcess8 = new System.Threading.Thread(processPG8);
                        threadProcess8.Start();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region 公用处理函数
        //Bitmap转HObject（灰度）
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
        //Bitmap copy 彩色图像
        public Bitmap RGBitmapCopy(Bitmap bmp)
        {
            int iwidth = bmp.Width;
            int iheight = bmp.Height;
            Bitmap dst = new Bitmap(iwidth, iheight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);//
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, iwidth, iheight), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, iwidth, iheight), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = srcData.Stride;
            int src_ptr = srcData.Scan0.ToInt32();
            int dst_ptr = dstData.Scan0.ToInt32();
            for (int i = 0; i < iheight; i++)
            {
                CopyMemory(dst_ptr, src_ptr, stride);
                dst_ptr += stride;
                src_ptr += stride;
            }
            bmp.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
        //Bitmap copy 灰度图像
        public Bitmap BitmapCopy(Bitmap bmp)
        {
            int iwidth = bmp.Width;
            int iheight = bmp.Height;
            Bitmap dst = new Bitmap(iwidth, iheight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);//
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, iwidth, iheight), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, iwidth, iheight), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            int stride = srcData.Stride;
            int src_ptr = srcData.Scan0.ToInt32();
            int dst_ptr = dstData.Scan0.ToInt32();
            for (int i = 0; i < iheight; i++)
            {
                CopyMemory(dst_ptr, src_ptr, stride);
                dst_ptr += stride;
                src_ptr += stride;
            }
            bmp.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }

        #endregion

    }
}
