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
    public partial class FormSystemSetting : Form
    {


      //  public static IniFileData _iniData;//声明ini数据对象
        //通讯开启以否

        public static bool IsCommunicate = true;

        public FormSystemSetting()
        {

  
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            // FolderBrowserDialog 类提供一种方法，它提示用户浏览、创建并最终选择一个文件夹。
            //如果只允许用户选择文件夹而非文件，则可使用此类。文件夹的浏览通过树控完成。只能选择文件系统中的文件夹；不能选择虚拟文件夹

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonSelectNGPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtNGPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            //对于窗口字体重绘，使得字体横向显示

            Graphics g = e.Graphics;
            Brush textBrush;

            // Get the item from the collection.
            TabPage tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font tabFont = new Font("Arial", (float)20.0, FontStyle.Bold, GraphicsUnit.Pixel);
            // Draw string. Center the text.
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, new StringFormat(stringFlags));
        }

        private void chkSaveImage_Click(object sender, EventArgs e)
        {
            if (chkSaveImage.CheckState == CheckState.Checked)
            {
                MessageBox.Show("选中保存图像");
                Class_Global.SaveOKimg = true;
                Class_Global.Saveimg = true;

            }
            else
            {
                MessageBox.Show("未选中保存图像");
                Class_Global.SaveOKimg = false;
                Class_Global.Saveimg = false;

            }
        }

        private void checkSaveNGImage_Click(object sender, EventArgs e)
        {
            if (checkSaveNGImage.CheckState == CheckState.Checked)
            {
                MessageBox.Show("选中保存NG图像");
                Class_Global.SaveNGimg = true;
            }
            else
            {
                MessageBox.Show("未选中保存NG图像");
                Class_Global.SaveNGimg = false;
            }
        }

        private void FormSystemSetting_Load(object sender, EventArgs e)
        {


            
            if (FormMain._iniData.CheckInifilesExist() == true)
            {
                //_iniData.ReadComportSection();//若ini文件存在，则从文件中读取文档参数到程序参数
                //_iniData.ReadEtherNetSection();
                LoadPara();                          //从程序参数到界面参数
            }
            else  //若ini文件丢失，则重新对于程序参数赋值，并显示到界面参数
            {

                //InitParaComandEtherNet();    //初始化程序参数
                LoadPara();            //从程序参数到界面参数
                try
                {
                    FormMain._iniData.WriteComportSection();//界面参数到文档参数
                    FormMain._iniData.WriteEtherNetSection();
                }
                catch
                {

                }
            }
            if(IsCommunicate==true)
            {
                chkDefaultOnlineEnabled.CheckState = CheckState.Checked;
            }



        }
        private void LoadPara()
        {


            //串口通讯  程序运行参数————〉界面参数
            //串口1
        


        }

        private void btnsavecommmunication_Click(object sender, EventArgs e)
        {

            Class_IniOperation _iniOperation = new Class_IniOperation(Class_Global.SocketParaPath);
            _iniOperation.WriteValue("Socket", "IP", text_IP.Text);     
            _iniOperation.WriteValue("Socket", "Port", text_Port.Text);
                



        }


        private void btnConfigSave_Click(object sender, EventArgs e)
        {

        }

        private void btnapplycommmunication_Click(object sender, EventArgs e)
        {
            
         //界面参数————〉程序参数
            
        
        }


        private void comboCommunicationMode_SelectedValueChanged(object sender, EventArgs e)
        {

            if (comboCommunicationMode.Text == "串口")
            {
                Class_Global.ComunicationMethod = 1;

            }
            if (comboCommunicationMode.Text == "网口")
            {
                Class_Global.ComunicationMethod = 2;
            }

        }
        //通讯开启
        private void chkDefaultOnlineEnabled_Click(object sender, EventArgs e)
        {
            if (chkDefaultOnlineEnabled.CheckState == CheckState.Checked)
            { 
                IsCommunicate = true; 
                
            
            }
            else 
            { 
                IsCommunicate = false;
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateMachineCode_Click(object sender, EventArgs e)
        {

        }

        private void chkSaveImage_CheckedChanged(object sender, EventArgs e)
        {

        }

  



    }
}
