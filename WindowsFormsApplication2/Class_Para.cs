using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

using System.ComponentModel;

using System.Collections;

using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public class Class_Para
    {


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

        /// <summary> 
        ///D301.0  机械手报警
        ///D301.1  机械手吸附真空异常
        ///D301.2 旋转轴报警
        ///D301.3 安全门报警
        ///D301.4 PLC与机械手通信未连接
        ///D301.5  真空信号1
        ///D301.6  真空信号2
        /// </summary>

        /// <summary>
        ///1.D310  显示位置  双字Dint 32位  ///plc写给pc 
        ///2.D312 设置速度   双字 Dint   ///PC写给plc  32位
        ///3.D314  点动速度   双字 Dint  //////PC写给plc  32位
        /// </summary>







        ///D300
        private string m_enableAxiAdd = "300.0";///1.D300.0 使能 值：0或1 切换开关
        private string m_zeroAdd = "300.1";    ///2.D300.1 回原点     值：0或1  自动复位
        private string m_forward = "300.2";   ///3.D300.2  正转     值：0或1  自动复位
        private string m_backward = "300.3";///4.D300.3  反转     值：0或1  自动复位
        private string m_Trigger = "300.4";////5.D300.4  定位触发  值：0或1  自复位
        ///
        private string m_SafeDoor = "300.7";///6.D300.7  安全门屏蔽         切换开关
        private string m_Reset = "300.8";///7.D300.8   机械手复位         自动复位
        private string m_Enable = "300.9";///8.D300.9  机械手使能          切换开关
        private string m_vacuum1 = "300.10";//9. D300.10 真空1开启 值：0或1  切换开关
        private string m_vacuum2 = "300.7";//10. D300.11 真空2开启 值：0或1 切换开关   
        private string m_Differentialcylinder = "300.7";///11. D300.12 高度差气缸 值：0或1 切换开关     



        private string m_GetPosition = "310";  ///1.D310  显示位置  双字Dint 32位  ///plc写给pc读 
        private string m_SetSpeed = "312";///2.D312 设置位置   双字 Dint   ///PC写给plc  32位                                         
        private string m_GoAimPosition = "314";/// ///3.D314  点动速度   双字 Dint  //////PC写给plc  32位
        ///
        ///D301
        private string m_RobotAlarm = "301.0";///D301.0  机械手报警
        private string m_RobotVcuumAlarm = "301.1";///D301.1  机械手吸附真空异常                                 ///
        private string m_CircleAxiAlarm = "301.2";///D301.2 旋转轴报警                               /// 
        private string m_SaveDoorAlarm = "301.3";////D301.3 安全门报警                                 /// 
        private string m_SocketRobortAlarm = "301.4";///D301.4 PLC与机械手通信未连接
        private string m_vacuum1_Now = "301.5";///D301.5  真空信号1                                  ///
        private string m_vacuum2_Now = "301.6";///D301.6  真空信号2





        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,0")]
        public string EnableAxiAdd
        {
            get { return m_enableAxiAdd; }
            set { m_enableAxiAdd = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,1")]
        public string Zero
        {
            get { return m_zeroAdd; }
            set { m_zeroAdd = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,2")]
        public string Forward
        {
            get { return m_forward; }
            set { m_forward = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,3")]
        public string backward
        {
            get { return m_backward; }
            set { m_backward = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,4")]
        public string Trigger
        {
            get { return m_Trigger; }
            set { m_Trigger = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string SafeDoor
        {
            get { return m_SafeDoor; }
            set { m_SafeDoor = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string Reset
        {
            get { return m_Reset; }
            set { m_Reset = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string Enable
        {
            get { return m_Enable; }
            set { m_Enable = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string vacuum1
        {
            get { return m_vacuum1; }
            set { m_vacuum1 = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string vacuum2
        {
            get { return m_vacuum2; }
            set { m_vacuum2 = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string Differentialcylinder
        {
            get { return m_Differentialcylinder; }
            set { m_Differentialcylinder = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string GetPosition
        {
            get { return m_GetPosition; }
            set { m_GetPosition = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string SetSpeed
        {
            get { return m_SetSpeed; }
            set { m_SetSpeed = value; }
        }
        [CategoryAttribute("PLC操作地址设置"), DefaultValueAttribute("300,7")]
        public string GoAimPosition
        {
            get { return m_GoAimPosition; }
            set { m_GoAimPosition = value; }
        }


        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string RobotAlarm
        {
            get { return m_RobotAlarm; }
            set { m_RobotAlarm = value; }
        }

        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string RobotVcuumAlarm
        {
            get { return m_RobotVcuumAlarm; }
            set { m_RobotVcuumAlarm = value; }
        }

        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string CircleAxiAlarm
        {
            get { return m_CircleAxiAlarm; }
            set { m_CircleAxiAlarm = value; }
        }
        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300.7")]
        public string SaveDoorAlarm
        {
            get { return m_SaveDoorAlarm; }
            set { m_SaveDoorAlarm = value; }
        }
        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string SocketRobortAlarm
        {
            get { return m_SocketRobortAlarm; }
            set { m_SocketRobortAlarm = value; }
        }
        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string vacuum1_Now
        {
            get { return m_vacuum1_Now; }
            set { m_vacuum1_Now = value; }
        }
        [CategoryAttribute("PLC报警地址设置"), DefaultValueAttribute("300,7")]
        public string vacuum2_Now
        {
            get { return m_vacuum2_Now; }
            set { m_vacuum2_Now = value; }
        }

    }



}
