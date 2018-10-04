using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
   
   
    
    public partial class FormPLC : Form
    {
      
        #region  PLC地址 
        
     //1.D300.0 使能   值：0&1  切换开关
     //2.D300.1 回原点     值：0&1  自动复位
     //3.D300.2  正转     值：0&1  自动复位
      //4.D300.3  反转     值：0&1  自复位
     //5.D300.4  定位触发  值：0&1  自复位

        //6.D300.7  安全门屏蔽   值：0&1  切换开关
        //7.D300.8   机械手复位  0&1  自动复位
        //8.D300.9  机械手使能  ：0&1  切换开关
     //9. D300.10 真空1开启   值：0&1  切换开关
     //10. D300.11 真空2开启  值：0&1 切换开关
     //11. D300.12 高度差气缸  值：0&1 切换开关

        #endregion


        /// <summary>
        ///1.D300.0 使能 值：0或1 切换开关
        ///2.D300.1 回原点     值：0或1  自动复位
        ///3.D300.2  正转     值：0或1  自动复位
        ///4.D300.3  反转     值：0或1  自动复位
        ///5.D300.4  定位触发  值：0或1  自复位
        ///6.D300.7  安全门屏蔽         切换开关
        ///7.D300.8   机械手复位         自动复位
        ///8.D300.9  机械手使能          切换开关
        ///9. D300.10 真空1开启 值：0或1  切换开关
        ///10. D300.11 真空2开启 值：0或1 切换开关
        ///11. D300.12 高度差气缸 值：0或1 切换开关     
        /// </summary>
        byte  [] D300byte = { 0, 1, 2, 3, 4, 7, 8, 9, 10, 11, 12 };
        /// <summary> 
        ///D301.0  机械手报警
        ///D301.1  机械手吸附真空异常
        ///D301.2 旋转轴报警
        ///D301.3 安全门报警
        ///D301.4 PLC与机械手通信未连接
        ///D301.5  真空信号1
        ///D301.6  真空信号2
        /// </summary>
        byte[] D301byte = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12,13,14,15 };
        /// <summary>
        ///1.D310  显示位置  双字Dint   ///plc写给pc 
        ///2.D312 设置速度   双字 Dint   ///PC写给plc  32位
        ///3.D314  点动速度   双字 Dint  //////PC写给plc  32位
        /// </summary>
        short[] Add = { 310, 312, 314 };  
      
        public FormPLC()
        {
            InitializeComponent();
        }
        private void btn_EnableMotion_Click(object sender, EventArgs e)
        {
           
            
            
            byte m_bit = D300byte[0];
            if (btn_EnableMotion.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_EnableMotion.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_EnableMotion.BackColor = Color.Red;
            }  
                 
        }

        private void btn_Zero_Click(object sender, EventArgs e)
        {
            //byte m_bit = D300byte[1];
            //if (btn_Zero.BackColor == Color.Red)
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            //    btn_Zero.BackColor = Color.Green;
            //}
            //else
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            //    btn_Zero.BackColor = Color.Red;
            //}    
        }

        private void btn_Zero_MouseDown(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[1];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            btn_Zero.BackColor = Color.Green;
        }
        private void btn_Zero_MouseUp(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[1];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            btn_Zero.BackColor = Color.Silver;


        }








        private void btn_forward_Click(object sender, EventArgs e)
        {
            //byte m_bit = D300byte[2];
            //if (btn_forward.BackColor == Color.Red)
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            //    btn_forward.BackColor = Color.Green;
            //}
            //else
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            //    btn_forward.BackColor = Color.Red;
            //}    
        }


        private void btn_forward_MouseDown(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[2];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            btn_forward.BackColor = Color.Green;

        }

        private void btn_forward_MouseUp(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[2];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            btn_forward.BackColor = Color.Silver;
        }







        private void btn_backward_Click(object sender, EventArgs e)
        {

            //byte m_bit = D300byte[3];
            //if (btn_backward.BackColor == Color.Red)
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            //    btn_backward.BackColor = Color.Green;
            //}
            //else
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            //    btn_backward.BackColor = Color.Red;
            //}    
        }


        private void btn_backward_MouseDown(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[3];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            btn_backward.BackColor = Color.Green;
        }

        private void btn_backward_MouseUp(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[3];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            btn_backward.BackColor = Color.Silver;
        }



















        private void btn_Trigger_Click(object sender, EventArgs e)
        {
            //byte m_bit = D300byte[4];
            //if (btn_Trigger.BackColor == Color.Red)
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            //    btn_Trigger.BackColor = Color.Green;
            //}
            //else
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            //    btn_Trigger.BackColor = Color.Red;
            //}     
        }

        private void btn_Trigger_MouseDown(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[4];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            btn_Trigger.BackColor = Color.Green;

        }

        private void btn_Trigger_MouseUp(object sender, MouseEventArgs e)
        {

            byte m_bit = D300byte[4];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            btn_Trigger.BackColor = Color.Silver;



        }






        private void btn_SafeDoor_Click(object sender, EventArgs e)
        {
            byte m_bit = D300byte[5];
            if (btn_SafeDoor.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_SafeDoor.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_SafeDoor.BackColor = Color.Red;
            }   
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            //byte m_bit = D300byte[6];
            //if (btn_Reset.BackColor == Color.Red)
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            //    btn_Reset.BackColor = Color.Green;
            //}
            //else
            //{
            //    FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            //    btn_Reset.BackColor = Color.Red;
            //}   
        }

        private void btn_Reset_MouseDown(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[6];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
            btn_Reset.BackColor = Color.Green;

        }

        private void btn_Reset_MouseUp(object sender, MouseEventArgs e)
        {
            byte m_bit = D300byte[6];
            FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
            btn_Reset.BackColor = Color.Silver;
        }






        private void btn_EnableRobot_Click(object sender, EventArgs e)
        {
            byte m_bit = D300byte[7];
            if (btn_EnableRobot.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_EnableRobot.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_EnableRobot.BackColor = Color.Red;
            }   
        }

        private void btn_vacuum1_Click(object sender, EventArgs e)
        {
            byte m_bit = D300byte[8];
            if (btn_vacuum1.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_vacuum1.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_vacuum1.BackColor = Color.Red;
            }  
        }

        private void btn_vacuum2_Click(object sender, EventArgs e)
        {
            byte m_bit = D300byte[9];
            if (btn_vacuum2.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_vacuum2.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_vacuum2.BackColor = Color.Red;
            }  
        }
        private void btn_Differentialcylinder_Click(object sender, EventArgs e)
        {
            byte m_bit = D300byte[10];
            if (btn_Differentialcylinder.BackColor == Color.Red)
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 1);
                btn_Differentialcylinder.BackColor = Color.Green;
            }
            else
            {
                FormMain.m_FinsConnecor.WriteBit(300, m_bit, 0);
                btn_Differentialcylinder.BackColor = Color.Red;
            }  
        }

        int[] State = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void timer1_Tick(object sender, EventArgs e)
        {
         
            for (int i = 0; i < 16;i++ )
            {              
                FormMain.m_FinsConnecor.ReadBit(301, D301byte[i], ref State[i]);
            }
            if(State[0]==1)
            {
                btn_RobotAlarm.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_RobotAlarm.BackColor = Color.Red;
            }


            if (State[1] == 1)
            {
                btn_RobotVcuumAlarm.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_RobotVcuumAlarm.BackColor = Color.Red;
            }


            if (State[2] == 1)
            {
                btn_CrcleAxiAlarm.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_CrcleAxiAlarm.BackColor = Color.Red;
            }


            if (State[3] == 1)
            {
                btn_SaveDoorAlarm.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_SaveDoorAlarm.BackColor = Color.Red;
            }
          
             if (State[4] == 1)
            {
                btn_SocketRobortAlarm.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                btn_SocketRobortAlarm.BackColor = Color.Red;
            }


             if (State[5] == 1)
             {
                 btn_vacuum1_Now.BackColor = Color.FromArgb(0, 192, 0);
             }
             else
             {
                 btn_vacuum1_Now.BackColor = Color.Red;
             }


             if (State[6] == 1)
             {
                 btn_vacuum2_Now.BackColor = Color.FromArgb(0, 192, 0);
             }
             else
             {
                 btn_vacuum2_Now.BackColor = Color.Red;
             }
            
        }

        private void btn_GetPositionNow_Click(object sender, EventArgs e)
        {
           int position=0;

           FormMain.m_FinsConnecor.ReadInt16(Add[0], ref position);
 
           label_PositionNow.Text = position.ToString();

        }

        private void btn_SetSpeed_Click(object sender, EventArgs e)
        {
            try 
            {
                short speed=0;
                speed = Convert.ToInt16(txB_Speed.Text);

                FormMain.m_FinsConnecor.WriteInt16(Add[1], speed);
               
            }
            catch
            {

            }
        }

        private void btn_GoAimPosition_Click(object sender, EventArgs e)
        {
            try
            {
                short AimPosition = 0;
                AimPosition = Convert.ToInt16(txB_AimPosition.Text);
                FormMain.m_FinsConnecor.WriteInt16(Add[1], AimPosition);
               
            }
            catch
            {

            }
        }

        private void btn_PLCAddPara_Click(object sender, EventArgs e)
        {
            FormPLCAdd frm = new FormPLCAdd();
            frm.ShowDialog();
        }

        private void btn_angle_Click(object sender, EventArgs e)
        {
            try 
            {
                float adc = float.Parse(txb_angle.Text);

                ///接受放料ok信号，让电机回零。
                ///
                FormMain.m_FinsConnecor.WriteFloat(322, adc);

                FormMain.m_FinsConnecor.WriteInt32(320, 100);



            }
            catch
            {



            }
   
        }

        private void btn_angleZero_Click(object sender, EventArgs e)
        {
            ///接受放料ok信号，让电机回零。
            ///
            FormMain.m_FinsConnecor.WriteFloat(322, 0);

            FormMain.m_FinsConnecor.WriteInt32(320, 100);
        
        }

      

       

      

      

    

      

    
    }
}
