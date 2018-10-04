using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class FormCameraSetting : Form
    {

        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]

        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        public FormCameraSetting()
        {
            InitializeComponent();
        }     


        private void btn_ApplyCameraPara_Click(object sender, EventArgs e)
        {
          
            Class_Global.Camera1[0] = txb_CCD1SN.Text;
            Class_Global.Camera1[1] = txtExposureTime.Text;
            Class_Global.Camera1[2] = textB_Gain.Text;


            Class_Global.Camera2[0] = txb_CCD2SN.Text;
            Class_Global.Camera2[1] = txtExposureTime2.Text;
            Class_Global.Camera2[2] = textB_Gain2.Text;

        

        }

        private void btn_SaveCameraPara_Click(object sender, EventArgs e)
        {

         
            
            WritePrivateProfileString("Camera1", "SN", txb_CCD1SN.Text, Class_Global.CameraParaPath);
            WritePrivateProfileString("Camera1", "ExplosureTime", txtExposureTime.Text, Class_Global.CameraParaPath);
            WritePrivateProfileString("Camera1", "Gain ", textB_Gain.Text, Class_Global.CameraParaPath);
            WritePrivateProfileString("Camera2", "SN", txb_CCD2SN.Text, Class_Global.CameraParaPath);
            WritePrivateProfileString("Camera2", "ExplosureTime", txtExposureTime2.Text, Class_Global.CameraParaPath);
            WritePrivateProfileString("Camera2", "Gain", textB_Gain2.Text, Class_Global.CameraParaPath);

        }

        private void FormCameraSetting_Load(object sender, EventArgs e)
        {
           txb_CCD1SN.Text  =Class_Global.Camera1[0] ;
           txtExposureTime.Text = Class_Global.Camera1[1];
            textB_Gain.Text= Class_Global.Camera1[2];

           txb_CCD2SN.Text=   Class_Global.Camera2[0];
           txtExposureTime2.Text=  Class_Global.Camera2[1];
           textB_Gain2.Text = Class_Global.Camera2[2];
           

        }


        public static void ReadCameraSettingini()
        {


            StringBuilder stringBud = new StringBuilder(15);
            string str = "0";

            GetPrivateProfileString("Camera1", "SN", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera1[0] = stringBud.ToString();

            GetPrivateProfileString("Camera1", "ExplosureTime", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera1[1] = stringBud.ToString();

            GetPrivateProfileString("Camera1", "Gain", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera1[2] = stringBud.ToString();


            GetPrivateProfileString("Camera2", "SN", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera2[0] = stringBud.ToString();

            GetPrivateProfileString("Camera2", "ExplosureTime", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera2[1] = stringBud.ToString();

            GetPrivateProfileString("Camera2", "Gain", str, stringBud, 15, Class_Global.CameraParaPath);
            Class_Global.Camera2[2] = stringBud.ToString();












        }


       
    }
}
