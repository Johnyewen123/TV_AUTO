
///////////////////////////
///该类实现对于鼠标操作的响应
////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using PylonC.NET;
using System.Threading;
using System.Drawing.Imaging;
using HalconDotNet;

namespace WindowsFormsApplication2
{

    public class Mourse
    {
        public HWindow _hWindowShow;
        public HObject _imageShow1, _imageShow2; //窗口显示的图片
        private int _row_MouseDown, _column_MouseDown;   //鼠标按下时记录坐标
        private int _row_MouseMove, _column_MouseMove; //鼠标移动时记录坐标
        private double _zoom;  //滚轮参数
        private double _zoomTrans;
        private double _zoomOrg;
        public bool _flag_act=false ;  //对应的窗口是否已激活
        public Mourse()
        {
            _hWindowShow = new HWindow();
           // _imageShow1 = new HObject();
            HOperatorSet.GenEmptyObj(out _imageShow1);
            HOperatorSet.GenEmptyObj(out _imageShow1);
          //  _imageShow2 =new HObject();
            _zoom = 1;
            _zoomOrg = 1;
            _zoomTrans = 1;
        }

        public double _Zoom
        {
            set { _zoom = value; }
        }

        public double _ZoomTrans
        {
            set { _zoomTrans = value; }
        }

        public double _ZoomOrg
        {
            set { _zoomOrg = value; }
        }
        public void hWindow_rawImage_HMouseWheel(object sender, HMouseEventArgs ev)
        {
            int row, col, button;
            double rowShif, colShif;
            int row1, column1, row2, column2;
            int height, width;
            int r1, c1, r2, c2;
            if (_flag_act == true)
            {
                if (ev.Delta > 0)
                {
                    try
                    {
                        _hWindowShow.GetMposition(out row, out col, out button);
                        Console.WriteLine(ev.Delta);
                        if (_zoom >= 32.0)
                        {
                            _zoom = 32.0;
                        }
                        else
                        {
                            _zoom *= 2;
                        }

                        _zoomTrans = _zoom / _zoomOrg;
                        _zoomOrg = _zoom;
                        rowShif = 0;
                        colShif = 0;

                        _hWindowShow.GetPart(out row1, out column1, out row2, out column2);
                        height = row2 - row1;
                        width = column2 - column1;
                        r1 = Convert.ToInt32((row1 + ((1 - (1.0 / _zoomTrans)) * (row - row1)) - (rowShif / _zoomTrans)));
                        c1 = Convert.ToInt32((column1 + ((1 - (1.0 / _zoomTrans)) * (col - column1)) - (colShif / _zoomTrans)));
                        r2 = r1 + Convert.ToInt32(height / _zoomTrans);
                        c2 = c1 + Convert.ToInt32(width / _zoomTrans);
                        _hWindowShow.SetPart(r1, c1, r2, c2);
                        _hWindowShow.ClearWindow();
                        _hWindowShow.DispObj(_imageShow1);
                        _hWindowShow.DispObj(_imageShow2);
                    }
                    catch (Exception)
                    {

                        //throw;
                    }


                }
                else if (ev.Delta < 0)
                {
                    //Convert.ToInt32(ev.X);
                    //Convert.ToInt32(ev.Y);
                    try
                    {
                        _hWindowShow.GetMposition(out row, out col, out button);
                        Console.WriteLine(ev.Delta);
                        if (_zoom <= 1 / 16.0)
                        {
                            _zoom = 1 / 16.0;
                        }
                        else
                        {
                            _zoom /= 2.0;
                        }

                        _zoomTrans = _zoom / _zoomOrg;
                        _zoomOrg = _zoom;
                        rowShif = 0;
                        colShif = 0;

                        _hWindowShow.GetPart(out row1, out column1, out row2, out column2);
                        height = row2 - row1;
                        width = column2 - column1;
                        r1 = Convert.ToInt32((row1 + ((1 - (1.0 / _zoomTrans)) * (row - row1)) - (rowShif / _zoomTrans)));
                        c1 = Convert.ToInt32((column1 + ((1 - (1.0 / _zoomTrans)) * (col - column1)) - (colShif / _zoomTrans)));
                        r2 = r1 + Convert.ToInt32(height / _zoomTrans);
                        c2 = c1 + Convert.ToInt32(width / _zoomTrans);
                        _hWindowShow.SetPart(r1, c1, r2, c2);
                        _hWindowShow.ClearWindow();
                        _hWindowShow.DispObj(_imageShow1);
                        _hWindowShow.DispObj(_imageShow2);
                    }
                    catch (Exception)
                    {

                        //throw;
                    }

                }
                Console.WriteLine(ev.X);
                Console.WriteLine(ev.Y);
                Console.WriteLine(_zoom);
            }
             
            
        }
        public void hWindow_HMouseDown(object sender, HMouseEventArgs ev)
        {
            Console.WriteLine(ev.Button);
            int button;
            if (ev.Button == MouseButtons.Left && _flag_act ==true)
            {
                //_canMove = true;
                try
                {
                    _hWindowShow.GetMposition(out _row_MouseDown, out _column_MouseDown, out button);

                }
                catch (Exception)
                {
                    
                    //throw;
                }
            }
        }
        public void hWindow_HMouseUp(object sender, HMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _flag_act ==true)
            {
                //_canMove = false;
                MoveImage();

            }
        }
        public void hWindow_HMouseMove(object sender, HMouseEventArgs e)
        {
        //    int _row_MouseMove, _column_MouseMove;
            int button;
            if (_flag_act == true)
            {
                try
                {
                    _hWindowShow.GetMposition(out _row_MouseMove, out _column_MouseMove, out button);
                    if (button == 1)
                    {
                        MoveImage();
                    }

                }

                catch (HalconException hEx)
                {

                  //  LogHelper.WriteLogError(sender.GetType(), hEx.ToString());
                } 
            }
            
            
        }
        public void MoveImage()
        {
            int row1, col1, row2, col2;
            int  button;
            int rowMoved, colMoved;
            int rowB, colB, rowE, colE;
            try
            {
                _hWindowShow.GetMposition(out _row_MouseMove, out _column_MouseMove, out button);

                rowB = _row_MouseDown;
                colB = _column_MouseDown;
                rowE = _row_MouseMove;
                colE = _column_MouseMove;

                rowMoved = rowB - rowE;
                colMoved = colB - colE;

                _hWindowShow.GetPart(out row1, out col1, out row2, out col2);
                _hWindowShow.SetPart(row1 + rowMoved, col1 + colMoved, row2 + rowMoved, col2 + colMoved);
                //if (!_canMove)
                _hWindowShow.ClearWindow();
                _hWindowShow.DispObj(_imageShow1);
                _hWindowShow.DispObj(_imageShow2);
            }
            catch (Exception)
            {
                
                //throw;
            }

        }
    }
}


