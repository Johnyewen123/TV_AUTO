using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class FormCali_brate : Form
    {

        public string CameraPointspath;
        public string RobotPointspath;
        public string[,] content_temp123;
        public string[,] content_temp456;
        /// <summary>
        /// 相机1与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
        /// </summary>
        public double[] Result;
        public FormCali_brate()
        {
            InitializeComponent();
            Result = new double[6];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确认导入数据是否为n行4列", "导入数据", MessageBoxButtons.YesNoCancel);
            string[] content;
            OpenFileDialog OpendlgCameraP = new OpenFileDialog();
            OpendlgCameraP.InitialDirectory =
            OpendlgCameraP.Filter = "txt files (*.csv)|*.csv|All files (*.*)|*.*";
            if (OpendlgCameraP.ShowDialog() == DialogResult.OK)
            {
                CameraPointspath = OpendlgCameraP.FileName;
                content = File.ReadAllLines(CameraPointspath);
                content_temp123 = new string[content.Length, 4];

                for (int i = 0; i < content.Length; i++)
                {
                    string[] content_temp = new string[content[i].Length - 1];
                    //分割字符串
                    string[] content_tempArray = content[i].Split(',');
                    for (int j = 0; j < content_tempArray.Length; j++)
                    {
                        content_temp123[i, j] = content_tempArray[j];
                    }
                }
                for (int k = 0; k < content.Length; k++)
                {
                    string[] temp1 = new string[4];
                    temp1[0] = content_temp123[k, 0];
                    temp1[1] = content_temp123[k, 1];
                    temp1[2] = content_temp123[k, 2];
                    temp1[3] = content_temp123[k, 3];

                    dataGridView1.Rows.Add(temp1);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = 0;
            //content_temp123.GetLength(num);
            //num = content_temp123.GetLength(1);
            num = content_temp123.Length;

            HTuple CameraX = new HTuple(num / 4);
            HTuple CameraY = new HTuple(num / 4);

            HTuple robotX = new HTuple(num / 4);
            HTuple robotY = new HTuple(num / 4);

            for (int i = 0; i < num / 4; i++)
            {
                CameraX[i] = Convert.ToDouble(content_temp123[i, 0]);
                CameraY[i] = Convert.ToDouble(content_temp123[i, 1]);
                robotX[i] = Convert.ToDouble(content_temp123[i, 2]);
                robotY[i] = Convert.ToDouble(content_temp123[i, 3]);

            }
            HTuple hv_Mat2d = null;
            HOperatorSet.VectorToHomMat2d(CameraX, CameraY, robotX, robotY, out hv_Mat2d);

            //相机1与机械手转换关系 1.X方向放缩系数Sx 、2.Y方向放缩系数Sy、3.X方向平移Tx、4.Y方向平移Ty、5.旋转角度Phi、6.坐标系倾斜Theta
            ///生成新的标定矩阵
            HTuple Sx = new HTuple(); HTuple Sy = new HTuple(); HTuple Tx = new HTuple(); HTuple Ty = new HTuple(); HTuple Phi = new HTuple(); HTuple Theta = new HTuple();
            ///计算出平移、旋转、放缩、坐标系倾斜系数
            HOperatorSet.HomMat2dToAffinePar(hv_Mat2d, out Sx, out Sy, out Phi, out Theta, out Tx, out Ty);
            Result[0] = Sx[0]; Result[1] = Sy[0]; Result[2] = Phi[0]; Result[3] = Theta[0]; Result[4] = Tx[0]; Result[5] = Ty[0];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string path = @"c:\temp\MyTest.txt";

            string path1 = AppDomain.CurrentDomain.BaseDirectory + @"Data" + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
            System.IO.DirectoryInfo info1 = System.IO.Directory.CreateDirectory(path1);
            string path = path1 + "\\" + "1.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            string[] hv_mat2d = { "Sx", "Sy", "Phi", "theta", "Tx", "Ty", "Mat2d" };

            using (FileStream fs = File.Create(path))
            {
                for (int i = 0; i < 6; i++)
                {

                    byte[] info = new UTF8Encoding(true).GetBytes(hv_mat2d[i] + "=" + Result[i].ToString() + "  ");
                    fs.Write(info, 0, info.Length);

                }
            }
        }
    }
}
