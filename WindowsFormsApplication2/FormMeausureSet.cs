using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class FormMeausureSet : Form
    {
        public static HObject ImageTest;
        public static int ChoseTestSide = 1;///1 表示A面 2表示B面

        public Mourse _mouse_Hwindow;
        
        public FormMeausureSet()
        {
            InitializeComponent();
            ShowPara();
            _mouse_Hwindow = new Mourse();//初始化鼠标放缩函数对象
        }

        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            HOperatorSet.GenEmptyObj(out ImageTest);
         
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
          //  openFileDialog1.InitialDirectory = "c:\\";///初始盘的位置
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";//文件格式
            openFileDialog1.FilterIndex = 2;//获取或设置文件对话框中当前选定筛选器的索引
            openFileDialog1.RestoreDirectory = true;
        
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string curString = openFileDialog1.FileName;///获取路径文件名称
                    if (curString != null)
                    {

                        if (System.IO.File.Exists(curString))///File类对于文件操作很方便
                        {

                            HOperatorSet.ReadImage(out ImageTest, curString);

                            //  _mouse_HwindowLeft变量初始化
                            _mouse_Hwindow._imageShow1 = ImageTest;
                            HTuple TempWidth, TempHeight;
                            HOperatorSet.GetImageSize(_mouse_Hwindow._imageShow1, out TempWidth, out TempHeight);

                            hWindowControl_test.HalconWindow.SetPart(0, 0, TempHeight.I, TempWidth.I);

                            // WindowL.DispObj(LImgload);
                            hWindowControl_test.HalconWindow.DispObj(ImageTest);
                           // WindowL.DispObj(Limg);
                          //  ImageTest.Dispose();

                            _mouse_Hwindow._Zoom = 1;
                            _mouse_Hwindow._ZoomTrans = 1;
                            _mouse_Hwindow._ZoomOrg = 1;
                            _mouse_Hwindow._hWindowShow = hWindowControl_test.HalconWindow;
                            _mouse_Hwindow._flag_act = true;
           

                        }

                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("加载图片出错:" + exc.Message);
                    return;
                }

            }

        }

        private void btn_TestImage_Click(object sender, EventArgs e)
        {

            string[] ResultA = new string[4];
            HObject ImageTest_temp;
            HOperatorSet.GenEmptyObj(out ImageTest_temp);
            ImageTest_temp = ImageTest.Clone();

            if (ChoseTestSide == 1)
            {
                Class_Halconalgorithm.Location_Pickup(ImageTest_temp, hWindowControl_test.HalconWindow);
                  
            }   
            string[] ResultB = new string[4];
            if (ChoseTestSide == 2)
            {
                Class_Halconalgorithm.LocationPutDown(ImageTest_temp, hWindowControl_test.HalconWindow);
            }

            if (ChoseTestSide == 3)
            {               
                Class_Halconalgorithm.SecondLocation(ImageTest_temp, hWindowControl_test.HalconWindow);
            }




         
        }

        private void ASideradioButton_Click(object sender, EventArgs e)
        {
            if(ChoseTestSide!=1)
            {
                ChoseTestSide = 1;
            }                    
        }

        private void BSideradioButton_Click(object sender, EventArgs e)
        {
            if (ChoseTestSide != 2)
            {
                ChoseTestSide =2 ;
            }
        }

        private void radioButton_Location2_Click(object sender, EventArgs e)
        {
            if (ChoseTestSide != 3)
            {
                ChoseTestSide = 3;
            }

        }




        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "save as";
                saveDlg.OverwritePrompt = true;
                saveDlg.Filter = "BMP文件（*.bmp)|*.bmp|" + "Tiff文件(*.tif)|*.tif";
                saveDlg.ShowHelp = true;

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    //获取用户选择的文件名
                    string fileName = saveDlg.FileName;
                    fileName = fileName.Substring(0, fileName.Length - 4);
                    HOperatorSet.WriteImage(ImageTest, "bmp", 0, fileName + ".bmp");
                }
            }
            catch (Exception exc)
            {

            }



        }

        private void btn_ApplyPara_Click(object sender, EventArgs e)
        {





        }

        private void hWindowControl_test_HMouseDown(object sender, HMouseEventArgs e)
        {
            _mouse_Hwindow.hWindow_HMouseDown(sender, e);
        }

        private void hWindowControl_test_HMouseMove(object sender, HMouseEventArgs e)
        {

            _mouse_Hwindow.hWindow_HMouseMove(sender,e);
        }

        private void hWindowControl_test_HMouseUp(object sender, HMouseEventArgs e)
        {
            _mouse_Hwindow.hWindow_HMouseUp(sender, e);

        }

        private void hWindowControl_test_HMouseWheel(object sender, HMouseEventArgs e)
        {

            _mouse_Hwindow.hWindow_rawImage_HMouseWheel(sender, e);

        }

        [ DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [ DllImport("kernel32")]

        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void btn_SavePara_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要修改参数吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
     

                Class_Global.TransCCD1Para[0] = Convert.ToDouble(txt_ScaleX1.Text);
                Class_Global.TransCCD1Para[1] = Convert.ToDouble(txt_ScaleY1.Text);
                Class_Global.TransCCD1Para[2] = Convert.ToDouble(txt_Tx1.Text);
                Class_Global.TransCCD1Para[3] = Convert.ToDouble(txt_Ty1.Text);
                Class_Global.TransCCD1Para[4] = Convert.ToDouble(txB_Phi1.Text);
                Class_Global.TransCCD1Para[5] = Convert.ToDouble(txt_Theta1.Text);


                Class_Global.TransCCD2Para[0] = Convert.ToDouble(txt_ScaleX2.Text);
                Class_Global.TransCCD2Para[1] = Convert.ToDouble(txt_ScaleY2.Text);
                Class_Global.TransCCD2Para[2] = Convert.ToDouble(txt_Tx2.Text);
                Class_Global.TransCCD2Para[3] = Convert.ToDouble(txt_Ty2.Text);
                Class_Global.TransCCD2Para[4] = Convert.ToDouble(txt_Phi2.Text);
                Class_Global.TransCCD2Para[5] = Convert.ToDouble(txt_Theta2.Text);

                Class_Global.ThresholdPick = Convert.ToDouble(txB_ThresholdPut.Text);
                Class_Global.ThresholdPut = Convert.ToDouble(txB_ThresholdPut.Text);
                Class_Global.ThresholdSecondLocation = Convert.ToDouble(txt_ThresholdSecondLocation.Text);
            
            }

            Saveini();

        }
        public void  Saveini()
        {
           
         
            //保存相机1九点标定参数
            WritePrivateProfileString("Camera1", "ScaleX1", txt_ScaleX1.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "ScaleY1", txt_ScaleY1.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "Phi1", txB_Phi1.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "Thera1", txt_Theta1.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "TransX1", txt_Tx1.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "TransY1", txt_Ty1.Text,    Class_Global.LocationParaPath);

            //保存相机2九点标定参数
            WritePrivateProfileString("Camera2", "ScaleX2", txt_ScaleX2.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "ScaleY2", txt_ScaleY2.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "Phi2", txt_Phi2.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "Thera2", txt_Theta2.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "TransX2", txt_Tx2.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "TransY2", txt_Ty2.Text,    Class_Global.LocationParaPath);


            WritePrivateProfileString("Camera1", "ThresholdPick", txt_ThresholdPick.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera1", "ThresholdPut", txB_ThresholdPut.Text,    Class_Global.LocationParaPath);
            WritePrivateProfileString("Camera2", "ThresholdSecondLocation", txt_ThresholdSecondLocation.Text,    Class_Global.LocationParaPath);

        }
        public void ShowPara()
        {

            txt_ScaleX1.Text = Class_Global.TransCCD1Para[0].ToString();
            txt_ScaleY1.Text = Class_Global.TransCCD1Para[1].ToString();
            txt_Tx1.Text = Class_Global.TransCCD1Para[2].ToString();
            txt_Ty1.Text = Class_Global.TransCCD1Para[3].ToString();
            txB_Phi1.Text = Class_Global.TransCCD1Para[4].ToString();
            txt_Theta1.Text = Class_Global.TransCCD1Para[5].ToString();


            txt_ScaleX2.Text = Class_Global.TransCCD2Para[0].ToString();
            txt_ScaleY2.Text = Class_Global.TransCCD2Para[1].ToString();
            txt_Tx2.Text = Class_Global.TransCCD2Para[2].ToString();
            txt_Ty2.Text = Class_Global.TransCCD2Para[3].ToString();
            txt_Phi2.Text = Class_Global.TransCCD2Para[4].ToString();
            txt_Theta2.Text = Class_Global.TransCCD2Para[5].ToString();

            txt_ThresholdPick.Text = Class_Global.ThresholdPick.ToString();
            txB_ThresholdPut.Text = Class_Global.ThresholdPut.ToString();
            txt_ThresholdSecondLocation.Text = Class_Global.ThresholdSecondLocation.ToString();




        }

        public static  void Readini()
        {

            StringBuilder stringBud = new StringBuilder(15);
            string str = "0";

            GetPrivateProfileString("Camera1", "ScaleX1", str, stringBud, 15,    Class_Global.LocationParaPath);
            Class_Global.TransCCD1Para[0] = Convert.ToDouble(stringBud.ToString());

            GetPrivateProfileString("Camera1", "ScaleY1", str, stringBud, 15,    Class_Global.LocationParaPath);
            Class_Global.TransCCD1Para[1]  = Convert.ToDouble(stringBud.ToString());

            GetPrivateProfileString("Camera1", "TransX1", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD1Para[2] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera1", "TransY1", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD1Para[3] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera1", "Phi1", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD1Para[4] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera1", "Thera1", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD1Para[5] = Convert.ToDouble(stringBud.ToString());



             GetPrivateProfileString("Camera2", "ScaleX2", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[0] = Convert.ToDouble(stringBud.ToString());

             //Class_Global.TransCCD2Para[1] = GetPrivateProfileString("相机2", "ScaleY2", str, stringBud, 15,    Class_Global.LocationParaPath);
             //Class_Global.TransCCD2Para[1] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera2", "ScaleY2", str, stringBud, 15, Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[1] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera2", "TransX2", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[2] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera2", "TransY2", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[3] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera2", "Phi2", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[4] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera2", "Thera2", str, stringBud, 15, Class_Global.LocationParaPath);
             Class_Global.TransCCD2Para[5] = Convert.ToDouble(stringBud.ToString());

             //Class_Global.TransCCD2Para[5] = GetPrivateProfileString("相机2", "Thera2", str, stringBud, 15,    Class_Global.LocationParaPath);
             //Class_Global.TransCCD2Para[5] = Convert.ToDouble(stringBud.ToString());

             GetPrivateProfileString("Camera1", "ThresholdPick", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.ThresholdPick = Convert.ToDouble(stringBud.ToString());
             GetPrivateProfileString("Camera1", "ThresholdPut", str, stringBud, 15,    Class_Global.LocationParaPath);
             Class_Global.ThresholdPut = Convert.ToDouble(stringBud.ToString());
             GetPrivateProfileString("Camera1", "ThresholdSecondLocation", str, stringBud, 15,    Class_Global.LocationParaPath);
              Class_Global.ThresholdSecondLocation = Convert.ToDouble(stringBud.ToString());
            


        }

     
       







    }
}
