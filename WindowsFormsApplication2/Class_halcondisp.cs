
///
///封装图像格式转换相关函数
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
namespace WindowsFormsApplication2
{
    class Class_halcondisp
    {

        /// <summary>
        /// 
        /// disp_message函数
        /// </summary>
        /// <param name="hv_WindowHandle"></param>
        /// <param name="hv_String"></param>
        /// <param name="hv_CoordSystem"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Color"></param>
        /// <param name="hv_Box"></param>m
        public static void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
          HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = null, hv_HeightWin = null, hv_MaxAscent = null;
            HTuple hv_MaxDescent = null, hv_MaxWidth = null, hv_MaxHeight = null;
            HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRow = new HTuple();
            HTuple hv_FactorColumn = new HTuple(), hv_UseShadow = null;
            HTuple hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 


            //Prepare window
            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 1;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                hv_ShadowColor = "#f28d26";
            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1, hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }
        ///图像格式转换的相关函数

        #region  
        //**************************************************************************************************

        [DllImport("kernel32", EntryPoint = "RtlMoveMemory", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void CopyMemory(int Destination, int Source, int length);

        public static Bitmap dhHimage2Bitmap(HImage himg)
        {
            try
            {
                HTuple type, width, height;
                int pointer = himg.GetImagePointer1(out type, out width, out height);

                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                ColorPalette pal = bmp.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    pal.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                bmp.Palette = pal;
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                int PixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
                int stride = bitmapData.Stride;
                int ptr = bitmapData.Scan0.ToInt32();
                for (int i = 0; i < height; i++)
                {
                    CopyMemory(ptr, pointer, width * PixelSize);
                    pointer += width;
                    ptr += bitmapData.Stride;
                }

                bmp.UnlockBits(bitmapData);
                return bmp;
            }
            catch (Exception exc)
            {

                return null;
            }
        }
        public static Bitmap dhHObject2Bitmap(HObject ho)
        {
            try
            {
                HTuple type, width, height, pointer;
                //HOperatorSet.AccessChannel(ho, out ho, 1);
                HOperatorSet.GetImagePointer1(ho, out pointer, out type, out width, out height);
                //himg.GetImagePointer1(out type, out width, out height);

                Bitmap bmp = new Bitmap(width.I, height.I, PixelFormat.Format8bppIndexed);
                ColorPalette pal = bmp.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    pal.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                bmp.Palette = pal;
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                int PixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
                int stride = bitmapData.Stride;
                int ptr = bitmapData.Scan0.ToInt32();
                for (int i = 0; i < height; i++)
                {
                    CopyMemory(ptr, pointer, width * PixelSize);
                    pointer += width;
                    ptr += bitmapData.Stride;
                }

                bmp.UnlockBits(bitmapData);
                return bmp;
            }
            catch (Exception exc)
            {

                return null;
            }
        }
        public static HImage dhBitmap2Himage(Bitmap bmp)
        {
            try
            {

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                IntPtr pointer = bmpData.Scan0;

                byte[] dataBlue = new byte[bmp.Width * bmp.Height];
                unsafe
                {
                    fixed (byte* ptrdata = dataBlue)
                    {
                        for (int i = 0; i < bmp.Height; i++)
                        {
                            CopyMemory((int)(ptrdata + bmp.Width * i), (int)(pointer + bmpData.Stride * i), bmp.Width);
                        }
                        HObject ho;
                        HOperatorSet.GenImage1(out ho, "byte", bmp.Width, bmp.Height, (int)ptrdata);
                        HImage himg = new HImage("byte", bmp.Width, bmp.Height, (IntPtr)ptrdata);
                        bmp.UnlockBits(bmpData);
                        return himg;
                    }
                }
            }
            catch (Exception exc)
            {

                return null;
            }

        }
        public static HObject dhBitmap2HObject(Bitmap bmp)
        {
            try
            {

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                IntPtr pointer = bmpData.Scan0;

                byte[] dataBlue = new byte[bmp.Width * bmp.Height];
                unsafe
                {
                    fixed (byte* ptrdata = dataBlue)
                    {
                        for (int i = 0; i < bmp.Height; i++)
                        {
                            CopyMemory((int)(ptrdata + bmp.Width * i), (int)(pointer + bmpData.Stride * i), bmp.Width);
                        }
                        HObject ho;
                        HOperatorSet.GenImage1(out ho, "byte", bmp.Width, bmp.Height, (int)ptrdata);
                        HImage himg = new HImage("byte", bmp.Width, bmp.Height, (IntPtr)ptrdata);

                        //HOperatorSet.DispImage(ho, hWindowControl1.HalconWindow);

                        bmp.UnlockBits(bmpData);
                        return ho;
                    }
                }
            }
            catch (Exception exc)
            {

                return null;
            }

        }
        public static unsafe Bitmap dhHobject2RgbBitmap(HObject ho_img)
        {
            try
            {
                HTuple type, width, height, pointerRed, pointerGreen, pointerBlue;
                HOperatorSet.GetImagePointer3(ho_img, out pointerRed, out pointerGreen, out pointerBlue, out type, out width, out height);

                int iwidth = width.I; int iheight = height.I;
                Bitmap bmp = new Bitmap(iwidth, iheight, PixelFormat.Format24bppRgb);

                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, iwidth, iheight), ImageLockMode.WriteOnly, bmp.PixelFormat);
                int stride = bitmapData.Stride;
                byte* ptr = (byte*)bitmapData.Scan0;

                byte* ptrB = (byte*)((int)pointerBlue);
                byte* ptrG = (byte*)((int)pointerGreen);
                byte* ptrR = (byte*)((int)pointerRed);

                for (int row = 0; row < iheight; row++)
                {
                    for (int column = 0; column < iwidth; column++)
                    {
                        ptr[0] = ptrB[0]; ptr[1] = ptrG[0]; ptr[2] = ptrR[0];
                        ptr += 3; ptrB++; ptrG++; ptrR++;
                    }
                    ptr += bitmapData.Stride - 3 * iwidth;
                }

                bmp.UnlockBits(bitmapData);

                return bmp;
            }
            catch (Exception exc)
            {

                return null;
            }

        }


        #endregion



    }
}
