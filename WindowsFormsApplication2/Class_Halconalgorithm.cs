using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace WindowsFormsApplication2
{
    class Class_Halconalgorithm
    {

        public static bool Location_Pickup(HObject Aimage, HWindow AWindow)
        {

            ////固定阈值需要开放出来***************
            #region  上料定位算法
          

            HObject ho_Image = null, ho_Region = null, ho_ConnectedRegions = null;
            HObject ho_SelectedRegions2 = null, ho_Contours = null, ho_ContoursSplit = null;
            HObject ho_SelectedXLD = null, ho_UnionContours = null, ho_ContCircle = null;

            HObject ho_CircleRES = null;

            HObject ho_Circle = null, ho_Region1 = null, ho_ConnectedRegions3 = null;
            HObject ho_SelectedRegions1 = null, ho_RegionIntersection1 = null;
            HObject ho_ConnectedRegions2 = null, ho_SelectedRegions3 = null;
            HObject ho_RegionFillUp1 = null, ho_Cross = null, ho_LineDirection = null;
            HObject ho_LineZeroAngle = null;
            HTuple UsedThreshold = null;
            

            // Local control variables 

            HTuple hv_WindowHandle = null, hv_ImageFiles = null;
            HTuple hv_Index = null, hv_Row = new HTuple(), hv_Column = new HTuple();
            HTuple hv_Radius = new HTuple(), hv_StartPhi = new HTuple();
            HTuple hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();
            HTuple hv_i = new HTuple(), hv_ProCenterR = new HTuple();
            HTuple hv_ProCenterC = new HTuple(), hv_InnerRadius = new HTuple();
            HTuple hv_Area = new HTuple(), hv_RowDirectionPt = new HTuple();
            HTuple hv_ColumnDirectionPt = new HTuple(), hv_Angle = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions2);
            HOperatorSet.GenEmptyObj(out ho_Contours);
            HOperatorSet.GenEmptyObj(out ho_ContoursSplit);
            HOperatorSet.GenEmptyObj(out ho_SelectedXLD);
            HOperatorSet.GenEmptyObj(out ho_UnionContours);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions3);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection1);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions2);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions3);
            HOperatorSet.GenEmptyObj(out ho_RegionFillUp1);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_LineDirection);
            HOperatorSet.GenEmptyObj(out ho_LineZeroAngle);
            HOperatorSet.GenEmptyObj(out ho_CircleRES);
            HObject ho_center_region;
            HOperatorSet.GenEmptyObj(out ho_center_region);
            HObject ho_center_heng;
            HOperatorSet.GenEmptyObj(out ho_center_heng);
            HObject ho_center_shu;
            HOperatorSet.GenEmptyObj(out ho_center_shu);
            HObject ho_line_intersection;
            HOperatorSet.GenEmptyObj(out ho_line_intersection);



            int result = 0;

            try
            {


                ho_Image.Dispose();
                ho_Image = Aimage;

                HTuple ho_center_area = new HTuple();
                HTuple ho_center_Row = new HTuple();
                HTuple ho_center_Column = new HTuple();

                ///calculate image center
                ho_center_region.Dispose();
                HOperatorSet.Threshold(ho_Image, out ho_center_region, 0, 255);
              
                HOperatorSet.AreaCenter(ho_center_region, out ho_center_area, out ho_center_Row, out ho_center_Column);
                ho_center_heng.Dispose();
                HOperatorSet.GenRegionLine(out ho_center_heng, 0, ho_center_Column, 2 * ho_center_Row, ho_center_Column);
                ho_center_shu.Dispose();
                HOperatorSet.GenRegionLine(out ho_center_shu, ho_center_Row, 0, ho_center_Row, 2 * ho_center_Column);
                ho_LineDirection.Dispose();
                HOperatorSet.Intersection(ho_center_heng, ho_center_shu, out ho_line_intersection);

                AWindow.DispObj(ho_center_heng);
                AWindow.DispObj(ho_center_shu);
                AWindow.DispObj(ho_line_intersection);

               ///检测产品位置
                HTuple hv_threshold = new HTuple();
                hv_threshold[0] = Class_Global.ThresholdPick;
  
                ho_Region.Dispose();
               // HOperatorSet.Threshold(ho_Image, out ho_Region, hv_threshold, 255);

                HOperatorSet.BinaryThreshold(ho_Image, out ho_Region, "max_separability", "light", out UsedThreshold);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
                //*找圆心区域

                ho_SelectedRegions2.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions2, ((new HTuple("area")).TupleConcat(
                    "rect2_len1")).TupleConcat("rect2_len2"), "and", ((new HTuple(100000)).TupleConcat(
                    550)).TupleConcat(550), ((new HTuple(300000)).TupleConcat(750)).TupleConcat(
                    750));




                HTuple hv_smallestcircleRow = null;

                HTuple hv_smallestcircleCol = null;

                HTuple  hv_smallestcircleRa=null;

                HOperatorSet.SmallestCircle(ho_SelectedRegions2, out hv_smallestcircleRow, out hv_smallestcircleCol, out hv_smallestcircleRa);



                hv_ProCenterR = hv_smallestcircleRow;
                hv_ProCenterC = hv_smallestcircleCol;
                hv_InnerRadius = hv_smallestcircleRa;


                //ho_Contours.Dispose();
                //HOperatorSet.GenContourRegionXld(ho_SelectedRegions2, out ho_Contours, "border");
                //ho_ContoursSplit.Dispose();
                //HOperatorSet.SegmentContoursXld(ho_Contours, out ho_ContoursSplit, "lines_circles",
                //    35, 20, 5);

                //ho_SelectedXLD.Dispose();
                //HOperatorSet.SelectShapeXld(ho_ContoursSplit, out ho_SelectedXLD, "outer_radius",
                //    "and", 100, 700);
                //ho_UnionContours.Dispose();
                //HOperatorSet.UnionAdjacentContoursXld(ho_SelectedXLD, out ho_UnionContours,
                //    10, 1, "attr_keep");


   
                //HOperatorSet.FitCircleContourXld(ho_UnionContours, "geometric", -1, 0, 0, 3,
                //    2, out hv_Row, out hv_Column, out hv_Radius, out hv_StartPhi, out hv_EndPhi,
                //    out hv_PointOrder);
                //ho_ContCircle.Dispose();
                //HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_Row, hv_Column, hv_Radius,
                //    0, 6.28318, "positive", 1);


                ////**剔除误拟合圆
                //for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Radius.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                //{
                //    if ((int)(new HTuple((new HTuple(560)).TupleLess(hv_Radius.TupleSelect(hv_i)))) != 0)
                //    {
                //        if ((int)(new HTuple(((hv_Radius.TupleSelect(hv_i))).TupleLess(620))) != 0)
                //        {
                //            hv_ProCenterR = hv_Row.TupleSelect(hv_i);
                //            hv_ProCenterC = hv_Column.TupleSelect(hv_i);
                //            hv_InnerRadius = hv_Radius.TupleSelect(hv_i);
                //        }
                //    }
                //}

                ho_CircleRES.Dispose();
                HOperatorSet.GenCircle(out ho_CircleRES, hv_ProCenterR, hv_ProCenterC, hv_InnerRadius );



                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, hv_ProCenterR, hv_ProCenterC, hv_InnerRadius + 10);

                //**找产品aaaa方向
               ho_Region1.Dispose();
                HOperatorSet.Threshold(ho_Image, out ho_Region1, 128, 255);

                ho_ConnectedRegions3.Dispose();
                HOperatorSet.Connection(ho_Region1, out ho_ConnectedRegions3);

                ho_SelectedRegions1.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions3, out ho_SelectedRegions1, ((new HTuple("area")).TupleConcat(
                    "rect2_len1")).TupleConcat("rect2_len2"), "and", ((new HTuple(3500)).TupleConcat(
                    50)).TupleConcat(15), ((new HTuple(7000)).TupleConcat(70)).TupleConcat(
                    35));

                //*用圆筛选
                ho_RegionIntersection1.Dispose();
                HOperatorSet.Intersection(ho_SelectedRegions1, ho_Circle, out ho_RegionIntersection1);


                ho_ConnectedRegions2.Dispose();
                HOperatorSet.Connection(ho_RegionIntersection1, out ho_ConnectedRegions2);

                ho_SelectedRegions3.Dispose();
                HOperatorSet.SelectShapeStd(ho_ConnectedRegions2, out ho_SelectedRegions3,
                    "max_area", 70);

                ho_RegionFillUp1.Dispose();
                HOperatorSet.FillUp(ho_SelectedRegions3, out ho_RegionFillUp1);


                HOperatorSet.AreaCenter(ho_RegionFillUp1, out hv_Area, out hv_RowDirectionPt,
                    out hv_ColumnDirectionPt);
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_RowDirectionPt, hv_ColumnDirectionPt,
                    6, 0.785398);
                //***计算产品与水平方向夹角
                //***角度为逆时针旋转角度为负值
                ho_LineDirection.Dispose();
                HOperatorSet.GenRegionLine(out ho_LineDirection, hv_RowDirectionPt, hv_ColumnDirectionPt,
                    hv_ProCenterR, hv_ProCenterC);
                ho_LineZeroAngle.Dispose();
                HOperatorSet.GenRegionLine(out ho_LineZeroAngle, hv_ProCenterR, hv_ProCenterC - 650,
                    hv_ProCenterR, hv_ProCenterC);
                HOperatorSet.AngleLl(hv_RowDirectionPt, hv_ColumnDirectionPt, hv_ProCenterR,
                    hv_ProCenterC - 720, hv_ProCenterR, hv_ProCenterC, hv_ProCenterR, hv_ProCenterC,
                    out hv_Angle);

                ///***********输出结果**************/////////////////////\
                //Class_Global.
                Class_Global.pickX = hv_ProCenterR;
                Class_Global.pickY = hv_ProCenterC;
                Class_Global.pickAngle = (hv_Angle / 3.1415926) * 180;



                #region  坐标系转换

                //相机1与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
                ///生成新的标定矩阵
                HTuple Sx = new HTuple(); HTuple Sy = new HTuple(); HTuple Tx = new HTuple(); HTuple Ty = new HTuple(); HTuple Phi = new HTuple(); HTuple Theta = new HTuple();
                HTuple hv_Mat2d = new HTuple();



                Sx = Convert.ToDouble(Class_Global.TransCCD1Para[0]);
                Sy = Convert.ToDouble(Class_Global.TransCCD1Para[1]);
                Tx = Convert.ToDouble(Class_Global.TransCCD1Para[2]) + Class_Global.RobotCCD1X - Class_Global.RobotCCD1ZeroX;
                Ty = Convert.ToDouble(Class_Global.TransCCD1Para[3]) + Class_Global.RobotCCD1Y - Class_Global.RobotCCD1ZeroY;
                Phi = Convert.ToDouble(Class_Global.TransCCD1Para[4]) + Class_Global.RobotCCD1Angle - Class_Global.RobotCCD1ZeroAngle;
                Theta = Convert.ToDouble(Class_Global.TransCCD1Para[5]);

                Class_Halconalgorithm.GenhvMat2D(Sx, Sy, Phi, Theta, Tx, Ty, out hv_Mat2d);
                Class_Halconalgorithm.TranfromCCDtoRobort(Class_Global.pickX, Class_Global.pickY, hv_Mat2d, out Class_Global.pickXfact, out Class_Global.pickYfact);

                //角度旋转计算
                Class_Global.pickAnglefact = Class_Global.pickAngle;
              


                # endregion 

                ///
                #endregion
                #region 显示图形结果
                AWindow.SetColor("red");
                AWindow.DispObj(ho_Image);
                AWindow.SetDraw("margin");
                AWindow.SetColor("blue");
                AWindow.DispObj(ho_CircleRES);
                AWindow.SetColor("green");
                AWindow.DispObj(ho_RegionFillUp1);
                AWindow.DispObj(ho_LineDirection);
                AWindow.DispObj(ho_LineZeroAngle);

                //AWindow.DispObj(ho_center_heng);
                //AWindow.DispObj(ho_center_shu);
                //AWindow.DispObj(ho_line_intersection);


                disp_message(AWindow, (((((((new HTuple("圆心坐标:")).TupleConcat("Row:" + hv_ProCenterR))).TupleConcat(
          "Col:" + hv_ProCenterC))).TupleConcat("Radius:" + hv_InnerRadius))).TupleConcat(
          "产品角度：" + (hv_Angle / 3.1415926) * 180), "window", -1, -1, ((new HTuple("black")).TupleConcat(
          "blue")).TupleConcat("blue"), "true");
                HOperatorSet.SetTposition(AWindow, 300, 0);
                AWindow.SetColor("blue");
                ///标定位置相机坐标
                ///
                HOperatorSet.WriteString(AWindow, "标定位置相机坐标; ROBOT_X " + Class_Global.RobotCCD1ZeroX + " ROBOT_Y " + Class_Global.RobotCCD1ZeroY);
        

                HOperatorSet.SetTposition(AWindow, 400, 0);
                AWindow.SetColor("red");
                HOperatorSet.WriteString(AWindow, "产品坐标：ROBOT_X " + Class_Global.pickXfact + " ROBOT_Y " + Class_Global.pickYfact);


                HOperatorSet.SetTposition(AWindow, 500, 0);
                AWindow.SetColor("blue");
                HOperatorSet.WriteString(AWindow, "标准角度：ROBOT_X " + Class_Global.PickOK_RobotAngle + " 旋转角度" + (Class_Global.pickAngle-Class_Global.PickOK_RobotAngle));



                #endregion\
              #region 显示数据结果


      

                AWindow.SetColor("pink");
                AWindow.DispObj(ho_LineDirection);
                AWindow.DispObj(ho_LineZeroAngle);

                AWindow.DispObj(ho_Cross);

                result = 1;
                #endregion 
                #region 内存释放
                ho_Image.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_Contours.Dispose();
                ho_ContoursSplit.Dispose();
                ho_SelectedXLD.Dispose();
                ho_UnionContours.Dispose();
                ho_ContCircle.Dispose();
                ho_Circle.Dispose();
                ho_Region1.Dispose();
                ho_ConnectedRegions3.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_RegionIntersection1.Dispose();
                ho_ConnectedRegions2.Dispose();
                ho_SelectedRegions3.Dispose();
                ho_RegionFillUp1.Dispose();
                ho_Cross.Dispose();
                ho_LineDirection.Dispose();
                ho_LineZeroAngle.Dispose();


                ho_center_region.Dispose();
                ho_center_heng.Dispose();
                ho_center_shu.Dispose();
                ho_line_intersection.Dispose();

                ho_CircleRES.Dispose();

                #endregion
            }
            catch (Exception e)
            {
             #region  内存释放  
                ho_Image.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_Contours.Dispose();
                ho_ContoursSplit.Dispose();
                ho_SelectedXLD.Dispose();
                ho_UnionContours.Dispose();
                ho_ContCircle.Dispose();
                ho_Circle.Dispose();
                ho_Region1.Dispose();
                ho_ConnectedRegions3.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_RegionIntersection1.Dispose();
                ho_ConnectedRegions2.Dispose();
                ho_SelectedRegions3.Dispose();
                ho_RegionFillUp1.Dispose();
                ho_Cross.Dispose();
                ho_LineDirection.Dispose();
                ho_LineZeroAngle.Dispose();




                ho_center_region.Dispose();
                ho_center_heng.Dispose();
                ho_center_shu.Dispose();
                ho_line_intersection.Dispose();





                ///***********输出结果**************/////////////////////\
                //Class_Global.
                Class_Global.pickX[0] = 0;
                Class_Global.pickY[0] = 0;
                Class_Global.pickAngle[0] = 0;



                result = 0;
                #endregion
            }
            if (result == 1)
            {
                return true;
            }
            else { return false; }

        }
        public static void LocationPutDown(HObject Bimage, HWindow BWindow)
        {

            // Local iconic variables 

            HObject ho_Image, ho_Region, ho_ConnectedRegions;
            HObject ho_SelectedRegions, ho_Circle;
            // Local control variables 
            HTuple hv_Row = null, hv_Column = null, hv_Radius = null;

            HTuple  UsedThreshold=null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_Circle);

            try
            {
                ho_Image.Dispose();
               
                ho_Image = Bimage;
                ho_Region.Dispose();
               // HOperatorSet.Threshold(ho_Image, out ho_Region, 158, 255);

                HOperatorSet.BinaryThreshold(ho_Image, out ho_Region, "max_separability", "light", out UsedThreshold);

                
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, ((new HTuple("area")).TupleConcat(
                    "rect2_len1")).TupleConcat("rect2_len2"), "and", ((new HTuple(0.9e+06)).TupleConcat(
                    500)).TupleConcat(500), ((new HTuple(14.9e+06)).TupleConcat(900)).TupleConcat(
                    900));
                HOperatorSet.SmallestCircle(ho_SelectedRegions, out hv_Row, out hv_Column,
                    out hv_Radius);
                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);

                BWindow.SetDraw("margin");
                BWindow.SetColor("red");
                BWindow.DispObj(ho_Circle);

                ///***********输出结果**************/////////////////////
                Class_Global.putX = hv_Column;
                Class_Global.putY = hv_Row;


            }
            catch (Exception e)
            {

                ho_Image.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_Circle.Dispose();
            }



            ///结果输出
            ///




            #region  内存释放
            //ho_Image.Dispose();
            //ho_Region.Dispose();
            //ho_ConnectedRegions.Dispose();
            //ho_SelectedRegions.Dispose();
            //ho_Circle.Dispose();

            # endregion



        }
        public static void SecondLocation(HObject Cimage, HWindow CWindow)
        {


            #region 二次定位算法
            HTuple hv_Width = null, hv_Height = null, hv_WindowHandle = null;
            HTuple hv_ROW_T = null, hv_Colun_t = null, hv_ImageFiles = null;
            HTuple hv_Index = null, hv_Area = new HTuple(), hv_Rotot_x = null, hv_Robot_y = null;
            HTuple hv_HomMat2D = null, hv_Rotot_x1 = null, hv_Robot_y1 = null;
            HTuple hv_disf_x = null, hv_diff_y = null;

            HObject ho_Image, ho_Region2, ho_ConnectedRegions;
            HObject ho_SelectedRegions1, ho_SelectedRegions2, ho_Circle;
            HObject ho_fillup;

            HObject ho_cross;

            HObject ho_union1;

            hv_ROW_T = new HTuple();
            hv_Colun_t = new HTuple();

            // Local control variables 
            HTuple hv_UsedThreshold = null, hv_Row = null;
            HTuple hv_Column = null, hv_Radius = null;

             HTuple hv_RowCenter = null, hv_ColumnCenter = null,hv_area=null;

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Region2);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions2);
            HOperatorSet.GenEmptyObj(out ho_Circle);


            HOperatorSet.GenEmptyObj(out ho_union1);

            HOperatorSet.GenEmptyObj(out ho_fillup);

            HOperatorSet.GenEmptyObj(out ho_cross);


            try
            {

                ho_Image.Dispose();
                ho_Image = Cimage;
                ho_Region2.Dispose();

                HOperatorSet.Threshold(ho_Image, out ho_Region2, 0,250);

                //HOperatorSet.BinaryThreshold(ho_Image, out ho_Region2, "max_separability", "dark", out hv_UsedThreshold);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region2, out ho_ConnectedRegions);
                ho_SelectedRegions1.Dispose();

                //HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions1, "area","and", 150, 200000);

                //HOperatorSet.SelectShape(ho_SelectedRegions1, out ho_SelectedRegions1, "rect2_len1", "and", 40, 99999);
               // HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions1, "max_area", 70);
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions1, "rect2_len1", "and", 640, 690);




                ho_union1.Dispose();
                HOperatorSet.Union1(ho_SelectedRegions1, out ho_union1);


                ho_fillup.Dispose();
                HOperatorSet.FillUp(ho_SelectedRegions1, out ho_fillup);

                HOperatorSet.AreaCenter(ho_fillup, out hv_area, out hv_RowCenter, out  hv_ColumnCenter);

                ho_cross.Dispose();

                CWindow.SetColor("green");
                HOperatorSet.GenCrossContourXld(out ho_cross, hv_RowCenter, hv_ColumnCenter,16,0);


                //HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions1, "rect2_len1",
                //    "and", 645, 695);
                //ho_SelectedRegions2.Dispose();
                //HOperatorSet.SelectShape(ho_SelectedRegions1, out ho_SelectedRegions2, "rect2_len1",
                //    "and", 645, 695);
                HOperatorSet.SmallestCircle(ho_union1, out hv_Row, out hv_Column, out hv_Radius);
                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, hv_Radius);
                //Class_Global.putX = hv_Row;
                //Class_Global.putY = hv_Column;

                Class_Global.putX = hv_RowCenter;
                Class_Global.putY = hv_ColumnCenter;

            #endregion

                #region 标定转换
                //相机1与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
                ///生成新的标定矩阵
                HTuple Sx = new HTuple(); HTuple Sy = new HTuple(); HTuple Tx = new HTuple(); HTuple Ty = new HTuple(); HTuple Phi = new HTuple(); HTuple Theta = new HTuple();
                HTuple hv_Mat2d = new HTuple();

                Sx = Convert.ToDouble(Class_Global.TransCCD2Para[0]);
                Sy = Convert.ToDouble(Class_Global.TransCCD2Para[1]);
                Tx = Convert.ToDouble(Class_Global.TransCCD2Para[2]);
                Ty = Convert.ToDouble(Class_Global.TransCCD2Para[3]);
                Phi = Convert.ToDouble(Class_Global.TransCCD2Para[4]);
                Theta = Convert.ToDouble(Class_Global.TransCCD2Para[5]);
                Class_Halconalgorithm.GenhvMat2D(Sx, Sy, Phi, Theta, Tx, Ty, out hv_Mat2d);
                Class_Halconalgorithm.TranfromCCDtoRobort(Class_Global.putX, Class_Global.putY, hv_Mat2d, out Class_Global.putXfact, out Class_Global.putYfact);
                #endregion

                #region 图形显示
                CWindow.SetDraw("margin");
                CWindow.SetColor("red");

                CWindow.DispObj(ho_fillup);

                CWindow.SetColor("green");
               // CWindow.DispObj(ho_Circle);
                CWindow.DispObj(ho_cross);
              
                #endregion

                #region 数据显示
                disp_message(CWindow, (((("ROW:" + hv_Row)).TupleConcat("column:" + hv_Column))).TupleConcat(
         "Radius:" + hv_Radius), "window", -1, -1, ((new HTuple("black")).TupleConcat(
         "blue")).TupleConcat("red"), "true"); CWindow.SetColor("blue");
                //HOperatorSet.SetTposition(CWindow, 100, 0);
                //HOperatorSet.WriteString(CWindow, "ROW :" + hv_Row + " COL :" + hv_Column);


                HOperatorSet.SetTposition(CWindow, 220, 0);
                CWindow.SetColor("red");
                ///   HOperatorSet.WriteString(CWindow,)
                HOperatorSet.WriteString(CWindow, "标准位置： ROBOT_X: " + Class_Global.PutOK_RobotX + " ROBOT_Y :" + Class_Global.PutOK_RobotY);


                HOperatorSet.SetTposition(CWindow, 320, 0);
                ///   HOperatorSet.WriteString(CWindow,)
                          CWindow.SetColor("blue");
                HOperatorSet.WriteString(CWindow, "ROBOT_X: " + Class_Global.putXfact + " ROBOT_Y :" + Class_Global.putYfact);



                HOperatorSet.SetTposition(CWindow, 420, 0);
                ///   HOperatorSet.WriteString(CWindow,)
               CWindow.SetColor("red");

                HOperatorSet.WriteString(CWindow, "偏移量： ROBOT_X: " + (Class_Global.putXfact - Class_Global.PutOK_RobotX) + " ROBOT_Y :" + (Class_Global.putYfact-Class_Global.PutOK_RobotY));





                ////
                #endregion
                ho_Image.Dispose();
                ho_Region2.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_Circle.Dispose();

                ho_fillup.Dispose();
                ho_cross.Dispose();


            }
            catch
            {
                ho_Image.Dispose();
                ho_Region2.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions1.Dispose();
                ho_SelectedRegions2.Dispose();
                ho_Circle.Dispose();

                ho_fillup.Dispose();
                ho_cross.Dispose();

                Class_Global.putXfact[0] = 0;
                Class_Global.putYfact[0] = 0;

                Class_Global.putX[0] = 0;
                Class_Global.putY[0] = 0;

            }

        }

        /// <summary>
        /// 拟合圆形
        /// </summary>
        /// <param name="ho_Image"></param
        /// <param name="ho_Regions"></param>
        /// <param name="hv_Elements"></param>
        /// <param name="hv_DetectHeight"></param>
        /// <param name="hv_DetectWidth"></param>
        /// <param name="hv_Sigma"></param>
        /// <param name="hv_Threshold"></param>
        /// <param name="hv_Transition"></param>
        /// <param name="hv_Select"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Column2"></param>
        /// <param name="hv_ResultRow"></param>
        /// <param name="hv_ResultColumn"></param>
        public static void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements, HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold, HTuple hv_Transition, HTuple hv_Select, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
        {

            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Rectangle = null, ho_Arrow1 = null;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_ATan = null;
            HTuple hv_Deg1 = null, hv_Deg = null, hv_i = null, hv_RowC = new HTuple();
            HTuple hv_ColC = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple();
            HTuple hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple();
            HTuple hv_MsrHandle_Measure = new HTuple(), hv_RowEdge = new HTuple();
            HTuple hv_ColEdge = new HTuple(), hv_Amplitude = new HTuple();
            HTuple hv_tRow = new HTuple(), hv_tCol = new HTuple();
            HTuple hv_t = new HTuple(), hv_Number = new HTuple(), hv_j = new HTuple();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

            ho_Regions.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Regions);
            hv_ResultRow = new HTuple();
            hv_ResultColumn = new HTuple();
            HOperatorSet.TupleAtan2((-hv_Row2) + hv_Row1, hv_Column2 - hv_Column1, out hv_ATan);
            HOperatorSet.TupleDeg(hv_ATan, out hv_Deg1);

            hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

            HOperatorSet.TupleDeg(hv_ATan, out hv_Deg);


            HTuple end_val13 = hv_Elements;
            HTuple step_val13 = 1;
            for (hv_i = 1; hv_i.Continue(end_val13, step_val13); hv_i = hv_i.TupleAdd(step_val13))
            {
                hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * hv_i) / (hv_Elements + 1));
                hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * hv_i) / (hv_Elements + 1));
                if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                    new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                    hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                {
                    continue;
                }
                if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                {
                    HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                    ho_Rectangle.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                        hv_Deg.TupleRad(), hv_DetectHeight / 2, hv_Distance / 2);
                }
                else
                {
                    ho_Rectangle.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                        hv_Deg.TupleRad(), hv_DetectHeight / 2, hv_DetectWidth / 2);
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle, out ExpTmpOutVar_0);
                    ho_Regions.Dispose();
                    ho_Regions = ExpTmpOutVar_0;
                }
                if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                {
                    hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                    hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                    hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                    hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                    ho_Arrow1.Dispose();
                    gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                        25, 25);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                }
                HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_Deg.TupleRad(), hv_DetectHeight / 2,
                    hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);

                if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                {
                    hv_Transition_COPY_INP_TMP = "negative";
                }
                else
                {
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                    {

                        hv_Transition_COPY_INP_TMP = "positive";
                    }
                    else
                    {
                        hv_Transition_COPY_INP_TMP = "all";
                    }
                }

                if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                {
                    hv_Select_COPY_INP_TMP = "first";
                }
                else
                {
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                    {

                        hv_Select_COPY_INP_TMP = "last";
                    }
                    else
                    {
                        hv_Select_COPY_INP_TMP = "all";
                    }
                }

                HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                    hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                    out hv_Amplitude, out hv_Distance);
                HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
                hv_tRow = 0;
                hv_tCol = 0;
                hv_t = 0;
                HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                {
                    continue;
                }
                HTuple end_val69 = hv_Number - 1;
                HTuple step_val69 = 1;
                for (hv_j = 0; hv_j.Continue(end_val69, step_val69); hv_j = hv_j.TupleAdd(step_val69))
                {
                    if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
                        hv_t))) != 0)
                    {

                        hv_tRow = hv_RowEdge.TupleSelect(hv_j);
                        hv_tCol = hv_ColEdge.TupleSelect(hv_j);
                        hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
                    }
                }
                if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                {

                    hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                    hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                }
            }
            HOperatorSet.TupleLength(hv_ResultRow, out hv_Number);


            ho_Rectangle.Dispose();
            ho_Arrow1.Dispose();

            return;
        }
        /// <summary>
        /// 拟合直线
        /// </summary>
        /// <param name="ho_Line"></param>
        /// <param name="hv_Rows"></param>
        /// <param name="hv_Cols"></param>
        /// <param name="hv_ActiveNum"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Col1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Col2"></param>
        public static void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols, HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Col1, out HTuple hv_Row2, out HTuple hv_Col2)
        {



            // Local iconic variables 

            HObject ho_Contour = null;

            // Local control variables 

            HTuple hv_Length = null, hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_Length1 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            hv_Row1 = 0;
            hv_Col1 = 0;
            hv_Row2 = 0;
            hv_Col2 = 0;
            ho_Line.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.TupleLength(hv_Cols, out hv_Length);

            if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(new HTuple(hv_ActiveNum.TupleGreater(
                1)))) != 0)
            {

                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                HOperatorSet.FitLineContourXld(ho_Contour, "tukey", hv_ActiveNum, 0, 5, 2,
                    out hv_Row1, out hv_Col1, out hv_Row2, out hv_Col2, out hv_Nr, out hv_Nc,
                    out hv_Dist);
                HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
                if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                {
                    ho_Contour.Dispose();

                    return;
                }
                ho_Line.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
                    hv_Col1.TupleConcat(hv_Col2));

            }

            ho_Contour.Dispose();

            return;
        }
        /// <summary>
        /// 生成箭头轮廓
        /// </summary>
        /// <param name="ho_Arrow"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Column2"></param>
        /// <param name="hv_HeadLength"></param>
        /// <param name="hv_HeadWidth"></param>
        public static void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_TempArrow = null;

            // Local control variables 

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);

            ho_Arrow.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            //
            //Calculate the arrow length
            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            //
            //Calculate end points of the arrow head.
            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            //
            //Finally create output XLD contour for each input point pair
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                {
                    //Create_ single points for arrows with identical start and end point
                    ho_TempArrow.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(hv_Index),
                        hv_Column1.TupleSelect(hv_Index));
                }
                else
                {
                    //Create arrow contour
                    ho_TempArrow.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                    ho_Arrow.Dispose();
                    ho_Arrow = ExpTmpOutVar_0;
                }
            }
            ho_TempArrow.Dispose();

            return;
        }

        #region  九点标定以及转换
        /// <summary>
        /// 计算机械手坐标和相机坐标系转换系数
        /// </summary>
        /// <param name="ImgX"></param>
        /// <param name="ImgY"></param>
        /// <param name="RobotX"></param>
        /// <param name="RobotY"></param>
        /// <param name="Mat2D"></param>
        public static void CalculateMat2D(HTuple ImgX, HTuple ImgY, HTuple RobotX, HTuple RobotY, out HTuple Sx, out HTuple Sy, out HTuple Phi, out HTuple Theta, out HTuple Tx, out HTuple Ty)
        {

            ///计算仿射变换矩阵
            HTuple hv_Mat2d = new HTuple();
            HOperatorSet.VectorToHomMat2d(ImgX, ImgY, RobotX, RobotY, out hv_Mat2d);
            ///计算出平移、旋转、放缩、坐标系倾斜系数
            HOperatorSet.HomMat2dToAffinePar(hv_Mat2d, out Sx, out Sy, out Phi, out Theta, out Tx, out Ty);


        }

        /// <summary>
        /// 将标定系数转换为标定矩阵
        /// </summary>
        /// <param name="Sx"></param>
        /// <param name="Sy"></param>
        /// <param name="Phi"></param>
        /// <param name="Theta"></param>
        /// <param name="Tx"></param>
        /// <param name="Ty"></param>
        /// <param name="Mat2d"></param>
        /// <returns></returns>
        public static void GenhvMat2D(HTuple Sx, HTuple Sy, HTuple Phi, HTuple Theta, HTuple Tx, HTuple Ty, out HTuple Mat2d)
        {

            HTuple HomMat2DIdentity = null;
            HTuple HomMat2DScale = null;
            HTuple HomMat2DSlant = null;
            HTuple HomMat2DRotate = null;
            // HTuple HomMat2D123 = null;//最终结果

            HOperatorSet.HomMat2dIdentity(out HomMat2DIdentity);
            HOperatorSet.HomMat2dScale(HomMat2DIdentity, Sx, Sy, 0, 0, out HomMat2DScale);
            HOperatorSet.HomMat2dSlant(HomMat2DScale, Theta, "y", 0, 0, out  HomMat2DSlant);
            HOperatorSet.HomMat2dRotate(HomMat2DSlant, Phi, 0, 0, out HomMat2DRotate);
            HOperatorSet.HomMat2dTranslate(HomMat2DRotate, Tx, Ty, out  Mat2d);


        }

        public static double[] TransHtupleToArray(HTuple hv_Htuple)
        {

            double[] _temp = new double[hv_Htuple.TupleLength()];
            for (int i = 0; i < hv_Htuple.TupleLength() - 1; i++)
            {
                _temp[i] = hv_Htuple[i];
            }
            return _temp;
        }

        public static void TranfromCCDtoRobort(HTuple Product_X, HTuple Product_Y, HTuple ccdToRobortMat2D, out  HTuple Product_XtoRobort, out HTuple Product_YtoRobort)
        {

            //结合得到的机械手的坐标偏移计算放射变换的矩阵
            HOperatorSet.AffineTransPoint2d(ccdToRobortMat2D, Product_X, Product_Y, out  Product_XtoRobort, out  Product_YtoRobort);
        }

        #endregion

        public static void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {

            // Local iconic variables 
            // Local control variables 

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
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Column: The column coordinate of the desired text position
            //   If set to -1, a default value of 12 is used.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically
            //   for each new textline.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow (same as if no second value is given)
            //       otherwise -> use given string as color string for the shadow color
            //
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

        public static string TransToxinshidaRobortStr(double InputNumber)
        {
            string Temp = null;

            string a1 = null;

            a1 = InputNumber.ToString();

            char[] cc = a1.ToCharArray();

            char[] cc1 = new char[8];

            for (int i = 0; i <= 7; i++)
            {
                cc1[i] = cc[i];
            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in cc1)
            {
                sb.Append(c);
            }
            Temp = sb.ToString();

            return Temp;
        }


        public static string Trans2DongzhiRobortStr(double InputNumber)
        {

            string Temp = String.Format("{0:N3}", InputNumber);
            return Temp;

        }









    }
}
