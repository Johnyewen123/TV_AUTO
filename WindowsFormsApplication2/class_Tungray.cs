using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Drawing;

using Microsoft.Win32;


namespace WindowsFormsApplication2
{
    public class clsFuction
    {

        public static Pen nPenOrangeRed2 = new Pen(Color.OrangeRed, 2);
        public static Pen nPenBlue1 = new Pen(Color.Blue, 1);//蓝色画笔
        public static Pen nPenLime2 = new Pen(Color.Lime, 2);
        public static Pen nPenBlue2 = new Pen(Color.Blue, 2);

        public static Brush nBrushOK = Brushes.Blue;
        public static Brush nBrushNG = Brushes.OrangeRed;

        /// <summary>
        /// ok ng 比如：OK ，NG-[05][区域找圆][无坐标];
        /// </summary>
        public static Font font2DrawOkNg = new Font("Times New Roman", 24, FontStyle.Bold);//宋体  Times New Roman  楷体_GB2312
        /// <summary>
        /// info in proceed
        /// </summary>
        public static Font font2DrawInfo = new Font("Times New Roman", 24, FontStyle.Bold);//宋体  Times New Roman  楷体_GB2312

        public static Point pFontOkNgPos = new Point(1, 1);

        static long lIsDrawingListObj = 0;


        public static void drawListObj(List<object> listObj2Draw, Graphics g, Rectangle recPicboxBounds, float fscaleXy)
        {
            if (Interlocked.Read(ref lIsDrawingListObj) == 1) return;
            Interlocked.Exchange(ref lIsDrawingListObj, 1);
            try
            {
                string strship = (string)listObj2Draw[0];
                //总的OK&NG
                if (strship.Contains("OK"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Lime, new PointF(120 / fscaleXy, 1060 / fscaleXy));
                }
                else if (strship.Contains("NG"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Red, new PointF(120 / fscaleXy, 1060 / fscaleXy));
                }

                strship = (string)listObj2Draw[1];
                if (strship.Contains("OK"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Lime, new PointF(1100 / fscaleXy, 1060 / fscaleXy));
                }
                else if (strship.Contains("NG"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Red, new PointF(1100 / fscaleXy, 1060 / fscaleXy));
                }

                strship = (string)listObj2Draw[2];
                if (strship.Contains("OK"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Lime, new PointF(2020 / fscaleXy, 1060 / fscaleXy));
                }
                else if (strship.Contains("NG"))
                {
                    g.DrawString(strship, font2DrawOkNg, Brushes.Red, new PointF(2020 / fscaleXy, 1060 / fscaleXy));
                }

                for (int igg = 3; igg < listObj2Draw.Count - 2; igg += 3)
                {
                    strship = (string)listObj2Draw[igg];

                    string strOKNG = (string)listObj2Draw[igg + 2];

                    if (strship == "矩形")
                    {
                        RectangleF[] recship = (RectangleF[])listObj2Draw[igg + 1];

                        if (strOKNG.Contains("OK"))
                        {
                            for (int ihh = 0; ihh < recship.Length; ihh++)
                            {
                                g.DrawRectangle(Pens.Lime, recship[ihh].X / fscaleXy, recship[ihh].Y / fscaleXy, recship[ihh].Width / fscaleXy, recship[ihh].Height / fscaleXy);
                            }
                        }
                        else if (strOKNG.Contains("NG"))
                        {
                            for (int ihh = 0; ihh < recship.Length; ihh++)
                            {
                                g.DrawRectangle(Pens.Red, recship[ihh].X / fscaleXy, recship[ihh].Y / fscaleXy, recship[ihh].Width / fscaleXy, recship[ihh].Height / fscaleXy);
                            }
                        }
                    }
                    if (strship == "线")
                    {
                        RectangleF recship = (RectangleF)listObj2Draw[igg + 1];

                        if (strOKNG.Contains("OK"))
                        {
                            g.DrawLine(Pens.Lime, recship.X / fscaleXy, recship.Y / fscaleXy, recship.Width / fscaleXy, recship.Height / fscaleXy);
                        }
                        else if (strOKNG.Contains("NG"))
                        {
                            g.DrawLine(Pens.Red, recship.X / fscaleXy, recship.Y / fscaleXy, recship.Width / fscaleXy, recship.Height / fscaleXy);
                        }
                    }



                }
            }
            catch (Exception exc)
            {

            }
            finally
            {
                Interlocked.Exchange(ref lIsDrawingListObj, 0);
            }

        }

        /// <summary>
        /// 延时 毫秒
        /// </summary>
        /// <param name="ielpTime"></param>
        public static void Delay(int ielpTime)
        {
            long ltick = DateTime.Now.Ticks;

            while (DateTime.Now.Ticks - ltick < ielpTime * 10000)
                System.Windows.Forms.Application.DoEvents();
        }

    }

    #region 绘图使用的结构体

    /// <summary>
    /// 绘图-圆结构
    /// </summary>
    public struct DrawCirle
    {
        private int drawModel;
        private PointF center;
        private int radio;
        /// <summary>
        /// 绘图对象类型 1-圆（点）；2-十字坐标点；3-矩形；4-椭圆；5-线；6-多边形
        /// </summary>
        public int DrawModel
        {
            get { return drawModel; }
            set { drawModel = value; }
        }
        /// <summary>
        /// 中心坐标点
        /// </summary>
        public PointF Center
        {
            get { return center; }
            set { center = value; }
        }
        /// <summary>
        /// 半径
        /// </summary>
        public int Radio
        {
            get { return radio; }
            set { radio = value; }
        }

    }

    #endregion

}
