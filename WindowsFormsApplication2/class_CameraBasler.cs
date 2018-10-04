/*=============================================================================
  Copyright (C) 2012 Future.  All Rights Reserved.

  Redistribution of this file, in original or modified form, without
  prior written consent of Allied Vision Technologies is prohibited.

-------------------------------------------------------------------------------

  File:        CameraBasler.cs

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

 -----------------------------------------------------------------------------
 *   by Leo.Wang   2015.07.21
=============================================================================*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;//DllImport
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Basler.Pylon;


namespace WindowsFormsApplication2
{
    public class class_CameraBasler
    {
        [DllImport("kernel32", EntryPoint = "RtlMoveMemory", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern void CopyMemory(int Destination, int Source, int length);

        #region Basler Camera Control
        /// <summary>
        /// 相机个数
        /// </summary>
        public int iCameraCount = 0;

        /// <summary>
        /// 实际相机有没有找到，和注册表里面的相机序列号对应
        /// </summary>
        public bool[] bCameraListFind = new bool[] { };

        /// <summary>
        /// 注册表里面的相机序列号，实例化类之后=Parameter.strCameraSn
        /// </summary>
        public string[] strCameraSn = new string[] { };

        /// <summary>
        /// 注册表里面的相机对应的参数
        /// </summary>
        public string[] strCameraParam = new string[] { };

        /// <summary>
        /// /* 所有相机 */
        /// </summary>
        Camera[] myCameras = new Camera[] { };


        private RingBitmap m_RingBitmap = null;
        private const int m_RingBitmapSize = 2;
        private static bool m_ImageInUse = true;

        ColorPalette palImage;

        #endregion

        public void InitializeBaslerCameras()
        {

            try
            {
                bCameraListFind = new bool[strCameraSn.Length];
                for (int igg = 0; igg < strCameraSn.Length; igg++) bCameraListFind[igg] = false;
                myCameras = new Camera[strCameraSn.Length];

                Bitmap bmzod = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                palImage = bmzod.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    palImage.Entries[i] = Color.FromArgb(255, i, i, i);
                }

                List<ICameraInfo> allcamerainfo = CameraFinder.Enumerate();//查找所有可连接相机

                iCameraCount = allcamerainfo.Count;

                #region 把查找到的相机按照序列号进行匹配
                for (uint ihh = 0; ihh < strCameraSn.Length; ihh++)
                {

                    for (int iCamNumber = 0; iCamNumber < iCameraCount; iCamNumber++)
                    {
                        //获取相机的序列号
                        ICameraInfo icamerainfo = allcamerainfo.ElementAt(iCamNumber);
                        string value = icamerainfo[CameraInfoKey.SerialNumber];
                        //判定是不是指定的相机
                        if (strCameraSn[ihh] == value)
                        {
                            bCameraListFind[ihh] = true;
                            myCameras[ihh] = new Camera(value);
                            break;
                        }
                    }
                }
                #endregion

                #region 对找到的相机进行初始化设置
                if (myCameras.Length > 0)
                {
                    for (int icamNumber = 0; icamNumber < myCameras.Length; icamNumber++)
                    {
                        if (!bCameraListFind[icamNumber]) continue;

                        /*打开相机*/
                        myCameras[icamNumber].Open();
                        bCameraListFind[icamNumber] = true;

                        /* 设置为黑白格式*/
                        myCameras[icamNumber].Parameters[PLCamera.PixelFormat].TrySetValue(PLCamera.PixelFormat.Mono8);

                        /* 设置为硬触发模式*/
                        myCameras[icamNumber].Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart);
                        myCameras[icamNumber].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                        myCameras[icamNumber].Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Line1);

                        /* 设置曝光时间*/
                        myCameras[icamNumber].Parameters[PLCamera.ExposureTimeAbs].TrySetValue(35000);

                        /* 设置采集模式为连续采集*/
                        myCameras[icamNumber].Parameters[PLCamera.AcquisitionMode].TrySetValue(PLCamera.AcquisitionMode.Continuous);

                        /* 设置网口数据包*/
                        myCameras[icamNumber].Parameters[PLCamera.GevSCPSPacketSize].TrySetValue(1500);


                        m_RingBitmap = new RingBitmap(m_RingBitmapSize);
                        m_ImageInUse = true;

                        /* 设置回调函数*/

                        if (icamNumber == 0)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam1_OnFrameReceived;
                        }
                        if (icamNumber == 1)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam2_OnFrameReceived;
                        }
                        if (icamNumber == 2)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam3_OnFrameReceived;
                        }
                        if (icamNumber == 3)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam4_OnFrameReceived;
                        }
                        if (icamNumber == 4)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam5_OnFrameReceived;
                        }
                        if (icamNumber == 5)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam6_OnFrameReceived;
                        }
                        if (icamNumber == 6)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam7_OnFrameReceived;
                        }
                        if (icamNumber == 7)
                        {
                            myCameras[icamNumber].StreamGrabber.ImageGrabbed += Cam8_OnFrameReceived;
                        }

                        dhDll.clsTimeDelay.Delay(50);

                    }

                    //strCameraSerials = lSerial.ToArray();

                }
                else
                {
                    dhDll.frmMsg.Log("没有搜索到Basler相机!请查看连接!", 1, 2, 0);
                }
                #endregion

            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// =888全部开始 =1 开启第一个 =0 开启第0个
        /// </summary>
        /// <param name="icamIndex"></param>
        public void startCameras(int icamIndex)
        {
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                        //   myCameras[igg].StartContinuousImageAcquisition(3);
                        myCameras[igg].StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                }
            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("开启Basler相机采图出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }

        public void stopCameras(int icamIndex)
        {
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                        // myCameras[igg].StopContinuousImageAcquisition();
                        myCameras[igg].StreamGrabber.Stop();
                }
            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("停止Basler相机采图出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }

        public void closeCameras()
        {

            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if (bCameraListFind[igg])
                        myCameras[igg].Close();
                }
            }
            catch (Exception exc)
            {

            }

        }

        //设置相机为硬触发模式
        public void setCameraTriggerOn(int icamIndex)
        {
            //bneedHalconObject = true;
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                    {
                        myCameras[igg].Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart);
                        myCameras[igg].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                        myCameras[igg].Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Line1);
                    }
                }
            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("设置Basler相机触发模式On出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }

        public void setCameraTriggerOff(int icamIndex)
        {
            //bneedHalconObject = false;
            try
            {
                for (int igg = 0; igg < myCameras.Length; igg++)
                {
                    if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                    {
                        myCameras[igg].Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart);
                        myCameras[igg].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.Off);
                        myCameras[igg].Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                    }
                }
            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("设置Basler相机触发模式Off出错<" + icamIndex.ToString() + ">:" + exc.Message, 1, 2, 1);
            }
        }


        #region 回调函数处理

        public static HalconDotNet.HObject ho_image1 = null;
        public static Bitmap bmp_image1 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera01 = delegate { dhDosome(bmp_image1, ho_image1); };

        public static HalconDotNet.HObject ho_image2 = null;
        public static Bitmap bmp_image2 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera02 = delegate { dhDosome(bmp_image2, ho_image2); };

        public static HalconDotNet.HObject ho_image3 = null;
        public static Bitmap bmp_image3 = null;
        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera03 = delegate { dhDosome(bmp_image3, ho_image3); };


        public static HalconDotNet.HObject ho_image4 = null;
        public static Bitmap bmp_image4 = null;

        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera04 = delegate { dhDosome(bmp_image4, ho_image4); };


        public static HalconDotNet.HObject ho_image5 = null;
        public static Bitmap bmp_image5 = null;

        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera05 = delegate { dhDosome(bmp_image5, ho_image5); };


        public static HalconDotNet.HObject ho_image6 = null;
        public static Bitmap bmp_image6 = null;

        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera06 = delegate { dhDosome(bmp_image6, ho_image6); };


        public static HalconDotNet.HObject ho_image7 = null;
        public static Bitmap bmp_image7 = null;

        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera07 = delegate { dhDosome(bmp_image7, ho_image7); };



        public static HalconDotNet.HObject ho_image8 = null;
        public static Bitmap bmp_image8 = null;

        /// <summary>
        /// 主处理委托
        /// </summary>
        public static System.Threading.ThreadStart processCamera08 = delegate { dhDosome(bmp_image8, ho_image8); };


        static void dhDosome(Bitmap bmpImage, HalconDotNet.HObject hoIntsnsity)
        {
            //System.Windows.Forms.MessageBox.Show("in class jai say :hello!");
            return;
        }

        static System.Threading.Thread threadProcess1, threadProcess2, threadProcess3, threadProcess4, threadProcess5, threadProcess6, threadProcess7, threadProcess8;



        void Cam1_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;
                // Image grabbed successfully?
                if (grabResult.GrabSucceeded)
                {
                    // Access the image data.

                    byte[] buffer = grabResult.PixelData as byte[];


                    unsafe
                    {
                        fixed (byte* pSrc = buffer)
                        {
                            HalconDotNet.HOperatorSet.GenImage1(out ho_image1, "byte", grabResult.Width, grabResult.Height, (int)pSrc);

                            //HalconDotNet.HOperatorSet.WriteImage(ho_image1, "tiff", 0, "C:\\100.tif");

                            bmp_image1 = new Bitmap(grabResult.Width, grabResult.Height,
                             System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                            bmp_image1.Palette = palImage;

                            BitmapData bmpData = bmp_image1.LockBits(new Rectangle(0, 0, bmp_image1.Width, bmp_image1.Height), ImageLockMode.ReadWrite, bmp_image1.PixelFormat);

                            byte* ptrScan0 = (byte*)bmpData.Scan0;

                            for (int irow = 0; irow < bmp_image1.Height; irow++)
                            {
                                cls_Win32.CopyMemory((int)(ptrScan0 + irow * bmpData.Stride), (int)(pSrc + irow * bmpData.Stride), bmp_image1.Width);

                                //for (int icol = 0; icol < bmp_image1.Width; icol++)
                                //{
                                // *(ptrScan0 + irow * bmpData.Stride + icol) = *(pSrc + irow * bmpData.Stride + icol);
                                //}
                            }

                            bmp_image1.UnlockBits(bmpData);


                            //bmp_image1.Save("C:\\112.bmp");

                        }


                    }

                    //ImagePersistence.Save(ImageFileFormat.Bmp, "test.bmp", grabResult);

                    //转换为Hobject

                    //发送数据到处理函数
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

            }
            catch (Exception exception)
            {

            }

        }

        void Cam2_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {

                if (bmp_image2 != null)
                {
                    bool benableNew = false;
                    if (threadProcess2 == null) benableNew = true;
                    else if (!threadProcess2.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess2 = new System.Threading.Thread(processCamera02);
                        threadProcess2.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam3_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image3 != null)
                {
                    bool benableNew = false;
                    if (threadProcess3 == null) benableNew = true;
                    else if (!threadProcess3.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess3 = new System.Threading.Thread(processCamera03);
                        threadProcess3.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam4_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image4 != null)
                {
                    bool benableNew = false;
                    if (threadProcess4 == null) benableNew = true;
                    else if (!threadProcess4.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess4 = new System.Threading.Thread(processCamera04);
                        threadProcess4.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam5_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image5 != null)
                {
                    bool benableNew = false;
                    if (threadProcess5 == null) benableNew = true;
                    else if (!threadProcess5.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess5 = new System.Threading.Thread(processCamera05);
                        threadProcess5.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam6_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image6 != null)
                {
                    bool benableNew = false;
                    if (threadProcess6 == null) benableNew = true;
                    else if (!threadProcess6.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess6 = new System.Threading.Thread(processCamera06);
                        threadProcess6.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam7_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image7 != null)
                {
                    bool benableNew = false;
                    if (threadProcess7 == null) benableNew = true;
                    else if (!threadProcess7.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess7 = new System.Threading.Thread(processCamera07);
                        threadProcess7.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        void Cam8_OnFrameReceived(Object sender, ImageGrabbedEventArgs e)
        {
            try
            {


                if (bmp_image8 != null)
                {
                    bool benableNew = false;
                    if (threadProcess8 == null) benableNew = true;
                    else if (!threadProcess8.IsAlive) benableNew = true;

                    if (benableNew)
                    {
                        threadProcess8 = new System.Threading.Thread(processCamera08);
                        threadProcess8.Start();
                    }
                }

            }
            catch (Exception exception)
            {

            }

        }

        #endregion

        #region 公用处理函数

        //public static Bitmap CreateBitmap(byte[] originalImageData, int originalWidth, int originalHeight)

        //{

        //    //指定8位格式，即256色

        //    Bitmap resultBitmap = new Bitmap(originalWidth, originalHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

        //    //将该位图存入内存中

        //    MemoryStream curImageStream = new MemoryStream();

        //    resultBitmap.Save(curImageStream, System.Drawing.Imaging.ImageFormat.Bmp);

        //    curImageStream.Flush();

        //    //由于位图数据需要DWORD对齐（4byte倍数），计算需要补位的个数

        //    int curPadNum = ((originalWidth * 8 + 31) / 32 * 4) - originalWidth;

        //    //最终生成的位图数据大小

        //    int bitmapDataSize = ((originalWidth * 8 + 31) / 32 * 4) * originalHeight;

        //    //数据部分相对文件开始偏移，具体可以参考位图文件格式

        //    dataOffset = ReadData(curImageStream, 10, 4);

        //    //改变调色板，因为默认的调色板是32位彩色的，需要修改为256色的调色板

        //    int paletteStart = 54;

        //    int paletteEnd = dataOffset;

        //    int color = 0;

        //    for (int i = paletteStart; i < paletteEnd; i += 4)

        //    {

        //        byte[] tempColor = new byte[4];

        //        tempColor[0] = (byte)color;

        //        tempColor[1] = (byte)color;

        //        tempColor[2] = (byte)color;

        //        tempColor[3] = (byte)0;

        //        color++;

        //        curImageStream.Position = i;

        //        curImageStream.Write(tempColor, 0, 4);

        //    }

        //    //最终生成的位图数据，以及大小，高度没有变，宽度需要调整

        //    byte[] destImageData = new byte[bitmapDataSize];

        //    int destWidth = originalWidth + curPadNum;

        //    //生成最终的位图数据，注意的是，位图数据 从左到右，从下到上，所以需要颠倒

        //    for (int originalRowIndex = originalHeight - 1; originalRowIndex >= 0; originalRowIndex--)

        //    {

        //        int destRowIndex = originalHeight - originalRowIndex - 1;

        //        for (int dataIndex = 0; dataIndex < originalWidth; dataIndex++)

        //    {

        //    //同时还要注意，新的位图数据的宽度已经变化destWidth，否则会产生错位

        //    destImageData[destRowIndex * destWidth + dataIndex] = originalImageData[originalRowIndex * originalWidth + dataIndex];

        //    }

        //    }
        //    //将流的Position移到数据段　　 

        //    curImageStream.Position = dataOffset;

        //    //将新位图数据写入内存中

        //    curImageStream.Write(destImageData, 0, bitmapDataSize);

        //    curImageStream.Flush();

        //    //将内存中的位图写入Bitmap对象

        //    resultBitmap = new Bitmap(curImageStream);

        //    return resultBitmap;

        //}


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
