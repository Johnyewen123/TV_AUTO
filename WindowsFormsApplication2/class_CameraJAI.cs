using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jai_FactoryDotNET;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    class class_CameraJAI
    {
        private CFactory myFactory;
        private CCamera[] myCameras = new CCamera[] { };

        private CNode myWidthNode;
        private CNode myHeightNode;
        private CNode myGainNode;

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

        public bool bneedHalconObject = false;

        ColorPalette palImage;

        public class_CameraJAI(bool bneedHObject)
        {
            bneedHalconObject = bneedHObject;

            Bitmap bmzod = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
            palImage = bmzod.Palette;
            for (int i = 0; i <= 255; i++)
            {
                palImage.Entries[i] = Color.FromArgb(255, i, i, i);
            }

        }


        public void initilizeJaiCamera()
        {
            #region 初始化JAI相机
            try
            {
                Jai_FactoryWrapper.EFactoryError error = Jai_FactoryWrapper.EFactoryError.Success;
                myFactory = new CFactory();
                error = myFactory.Open("");

                myFactory.UpdateCameraList(Jai_FactoryDotNET.CFactory.EDriverType.FilterDriver);

                iCameraCount = myFactory.CameraList.Count;

                bCameraListFind = new bool[strCameraSn.Length];
                for (int igg = 0; igg < strCameraSn.Length; igg++) bCameraListFind[igg] = false;

                myCameras = new CCamera[strCameraSn.Length];

                for (int ihh = 0; ihh < strCameraSn.Length; ihh++)
                {
                    for (int iCamNumber = 0; iCamNumber < iCameraCount; iCamNumber++)
                    {
                        if (strCameraSn[ihh] == myFactory.CameraList[iCamNumber].SerialNumber)
                        {
                            myCameras[ihh] = myFactory.CameraList[iCamNumber];
                            break;
                        }
                    }
                }


                for (int icamNumber = 0; icamNumber < myCameras.Length; icamNumber++)
                {
                    if (myCameras[icamNumber] != null)
                    {
                        myCameras[icamNumber].Open();
                        bCameraListFind[icamNumber] = true;

                        //myCameras[iCamNumber].GetGain(ref myRGain, ref myGGain, ref myBGain);
                        myCameras[icamNumber].StretchLiveVideo = true;
                        //myCameras[iCamNumber].ZoomDirect(25);

                        myWidthNode = myCameras[icamNumber].GetNode("Width");
                        if (myWidthNode != null) myWidthNode.Value = myWidthNode.Max;

                        myHeightNode = myCameras[icamNumber].GetNode("Height");
                        if (myHeightNode != null) myHeightNode.Value = myHeightNode.Max;

                        if (myCameras[icamNumber].GetNode("TriggerSelector") != null)
                        {
                            myCameras[icamNumber].GetNode("TriggerMode").Value = "On";
                            myCameras[icamNumber].GetNode("TriggerSource").Value = "Line5 - Optical In 1";
                            //myCameras[iCamNumber].GetNode("ShutterMode").Value = 2;

                            //myCameras[iCamNumber].GetNode("ExposureTimeAbs").Value = (object)lExposureTimeUs;
                        }
                        else
                        {

                            myCameras[icamNumber].GetNode("ExposureMode").Value = "EdgePreSelect";
                            // Set Line Selector to "Camera Trigger 0"
                            myCameras[icamNumber].GetNode("LineSelector").Value = "CameraTrigger0";
                            myCameras[icamNumber].GetNode("LineSource").Value = 4;
                            // .. and finally set the Line Polarity (LineInverter) to "Active High"
                            myCameras[icamNumber].GetNode("LineInverter").Value = "ActiveHigh";
                            myCameras[icamNumber].GetNode("ShutterMode").Value = "Programmable Exposure (us)";
                            //myCameras[icamNumber].GetNode("ExposureTimeAbs").Value = (object)lExposureTimeUs;
                        }

                        if (icamNumber == 0)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera1_HandleImage);
                        }
                        if (icamNumber == 1)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera2_HandleImage);
                        }
                        if (icamNumber == 2)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera3_HandleImage);
                        }
                        if (icamNumber == 3)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera4_HandleImage);
                        }
                        if (icamNumber == 4)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera5_HandleImage);
                        }
                        if (icamNumber == 5)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera6_HandleImage);
                        }
                        if (icamNumber == 6)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera7_HandleImage);
                        }
                        if (icamNumber == 7)
                        {
                            myCameras[icamNumber].NewImageDelegate += new Jai_FactoryWrapper.ImageCallBack(myCamera8_HandleImage);
                        }


                        dhDll.clsTimeDelay.Delay(50);

                    }
                    else
                    {

                    }
                }


            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("相机JAI初始化出错:" + exc.Message, 1, 2, 1);
            }
            #endregion
        }

        /// <summary>
        /// =888全部开始 =1 开启第一个 =0 开启第0个
        /// </summary>
        /// <param name="icamIndex"></param>
        public void startCameras(int icamIndex)
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                    myCameras[igg].StartImageAcquisition(false, 2);
            }
        }

        public void stopCameras(int icamIndex)
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                    myCameras[igg].StopImageAcquisition();
            }
        }

        public void closeCameras()
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if (myCameras[igg].IsAcquisitionRunning) myCameras[igg].StopImageAcquisition();
                myCameras[igg].Close();
            }
            if (myFactory != null) myFactory.Close();
        }


        public void setcameraTriggerOn(int icamIndex)
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                {
                    myCameras[igg].GetNode("TriggerSelector").Value = "Frame Start";
                    myCameras[igg].GetNode("TriggerMode").Value = "On";
                    myCameras[igg].GetNode("TriggerSource").Value = "Line 5 - Optical In 1";
                }
            }
        }

        public void setcameraTriggerOff(int icamIndex)
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                {
                    myCameras[igg].GetNode("TriggerSelector").Value = "Frame Start";
                    myCameras[igg].GetNode("TriggerMode").Value = "Off";
                    myCameras[igg].GetNode("TriggerSource").Value = "Low";
                }
            }
        }

        public void setcameraParam(int icamIndex)
        {
            for (int igg = 0; igg < myCameras.Length; igg++)
            {
                if ((icamIndex == 888 || icamIndex == igg) && bCameraListFind[igg])
                {
                    //0-曝光# 1-增益 2-帧率 3-触发延时
                    string[] strParam = strCameraParam[igg].Split('#');

                    myCameras[igg].GetNode("ExposureTime").Value = (object)(long.Parse(strParam[0]));

                }
            }
        }




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

        void myCamera1_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam1)
        {
            try
            {
                if (ImageInfoCam1.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image1 = new Bitmap((int)ImageInfoCam1.SizeX, (int)ImageInfoCam1.SizeY, (int)ImageInfoCam1.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam1.ImageBuffer);

                    bmp_image1.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image1, "byte", bmp_image1.Width, bmp_image1.Height, ImageInfoCam1.ImageBuffer);

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
            catch (Exception exc)
            {
            }
        }

        void myCamera2_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam2)
        {
            try
            {
                if (ImageInfoCam2.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image2 = new Bitmap((int)ImageInfoCam2.SizeX, (int)ImageInfoCam2.SizeY, (int)ImageInfoCam2.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam2.ImageBuffer);

                    bmp_image2.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image2, "byte", bmp_image2.Width, bmp_image2.Height, ImageInfoCam2.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera3_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam3)
        {
            try
            {
                if (ImageInfoCam3.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image3 = new Bitmap((int)ImageInfoCam3.SizeX, (int)ImageInfoCam3.SizeY, (int)ImageInfoCam3.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam3.ImageBuffer);

                    bmp_image3.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image3, "byte", bmp_image3.Width, bmp_image3.Height, ImageInfoCam3.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera4_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam4)
        {
            try
            {
                if (ImageInfoCam4.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image4 = new Bitmap((int)ImageInfoCam4.SizeX, (int)ImageInfoCam4.SizeY, (int)ImageInfoCam4.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam4.ImageBuffer);

                    bmp_image4.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image4, "byte", bmp_image4.Width, bmp_image4.Height, ImageInfoCam4.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera5_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam5)
        {
            try
            {
                if (ImageInfoCam5.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image5 = new Bitmap((int)ImageInfoCam5.SizeX, (int)ImageInfoCam5.SizeY, (int)ImageInfoCam5.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam5.ImageBuffer);

                    bmp_image5.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image5, "byte", bmp_image5.Width, bmp_image5.Height, ImageInfoCam5.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera6_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam6)
        {
            try
            {
                if (ImageInfoCam6.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image6 = new Bitmap((int)ImageInfoCam6.SizeX, (int)ImageInfoCam6.SizeY, (int)ImageInfoCam6.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam6.ImageBuffer);

                    bmp_image6.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image6, "byte", bmp_image6.Width, bmp_image6.Height, ImageInfoCam6.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera7_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfoCam7)
        {
            try
            {
                if (ImageInfoCam7.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image7 = new Bitmap((int)ImageInfoCam7.SizeX, (int)ImageInfoCam7.SizeY, (int)ImageInfoCam7.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfoCam7.ImageBuffer);

                    bmp_image7.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image7, "byte", bmp_image7.Width, bmp_image7.Height, ImageInfoCam7.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }

        void myCamera8_HandleImage(ref Jai_FactoryWrapper.ImageInfo ImageInfo)
        {
            try
            {
                if (ImageInfo.PixelFormat == Jai_FactoryWrapper.EPixelFormatType.GVSP_PIX_MONO8)
                {
                    bmp_image8 = new Bitmap((int)ImageInfo.SizeX, (int)ImageInfo.SizeY, (int)ImageInfo.SizeX,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed, ImageInfo.ImageBuffer);

                    bmp_image8.Palette = palImage;

                    if (bneedHalconObject)
                        HalconDotNet.HOperatorSet.GenImage1(out ho_image8, "byte", bmp_image8.Width, bmp_image8.Height, ImageInfo.ImageBuffer);


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
            }
            catch (Exception exc)
            {
            }
        }






    }



}
