using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    //串口类实例
    public class ComPortSection
    {
        public string PortName;//串口名
        public string DataBits;//串口位
        public string BaudRate;//波特率
        public string Parity;  //极性
        public string StopBits;//停止位
        public string PortName2;
        public string DataBits2;
        public string BaudRate2;
        public string Parity2;
        public string StopBits2;
    }

    //网口类实例
    public class EthernetSection
    {
        public string IP;
        public string Port;
        public string Rack;
        public string Slot;
    }
    public class IniFileData
    {

        #region
        //声明变量
         private string _path;
         private ComPortSection _comPort;
         private EthernetSection _ethernet;
          Class_IniOperation _iniOperation;

         #endregion
         #region Property
        //设计类属性
         public ComPortSection ComPort
         {
             get { return _comPort; }
             set { _comPort = value; }
         }
         public EthernetSection Ethernet
         {
             get { return _ethernet; }
             set { _ethernet = value; }
         }

        #endregion
        //类的构造函数
          public IniFileData(string  path)
         {

             _comPort = new ComPortSection();
             _ethernet = new EthernetSection();
          
              _path = path;
              _iniOperation = new Class_IniOperation(path);
         }
        //运行参数————〉ini文件

          public void WriteComportSection()
          {        
              _iniOperation.WriteValue("ComPort", "PortName", _comPort.PortName);
              _iniOperation.WriteValue("ComPort", "BaudRate", _comPort.BaudRate);
              _iniOperation.WriteValue("ComPort", "DataBits", _comPort.DataBits);
              _iniOperation.WriteValue("ComPort", "Parity", _comPort.Parity);
              _iniOperation.WriteValue("ComPort", "StopBits", _comPort.StopBits);
              _iniOperation.WriteValue("ComPort", "PortName2", _comPort.PortName2);
              _iniOperation.WriteValue("ComPort", "BaudRate2", _comPort.BaudRate2);
              _iniOperation.WriteValue("ComPort", "DataBits2", _comPort.DataBits2);
              _iniOperation.WriteValue("ComPort", "Parity2", _comPort.Parity2);
              _iniOperation.WriteValue("ComPort", "StopBits2", _comPort.StopBits2);
          }
        //ini文件——————〉运行参数
        public void ReadComportSection()
        {
             _comPort.PortName = _iniOperation.ReadValue("ComPort", "PortName");
             _comPort.BaudRate = _iniOperation.ReadValue("ComPort", "BaudRate");
             _comPort.DataBits = _iniOperation.ReadValue("ComPort", "DataBits");
            _comPort.Parity = _iniOperation.ReadValue("ComPort", "Parity");
            _comPort.StopBits = _iniOperation.ReadValue("ComPort", "StopBits");
            _comPort.PortName2 = _iniOperation.ReadValue("ComPort", "PortName2");
            _comPort.BaudRate2 = _iniOperation.ReadValue("ComPort", "BaudRate2");
            _comPort.DataBits2 = _iniOperation.ReadValue("ComPort", "DataBits2");
            _comPort.Parity2 = _iniOperation.ReadValue("ComPort", "Parity2");
            _comPort.StopBits2 = _iniOperation.ReadValue("ComPort", "StopBits2");

          }

        public  void ReadEtherNetSection()
        {
            string sectionName = "EtherNet";

            _ethernet.IP = _iniOperation.ReadValue(sectionName, "IP");
            _ethernet.Rack = _iniOperation.ReadValue(sectionName, "Rack");
            _ethernet.Slot = _iniOperation.ReadValue(sectionName, "Slot");



        }

        public void WriteEtherNetSection()
        {
            string sectionName = "EtherNet";

            _iniOperation.WriteValue(sectionName, "IP", _ethernet.IP);
            _iniOperation.WriteValue(sectionName, "Rack", _ethernet.Rack);
            _iniOperation.WriteValue(sectionName, "Slot", _ethernet.Slot);
        }
        public bool CheckInifilesExist()
        {

            bool CheckInifilesExist = _iniOperation.CheckIniFileExist();
            return CheckInifilesExist;
        
        }


             
    }





   
}
