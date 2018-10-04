/////
///三菱PLC mc协议
////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace WindowsFormsApplication2
{
    public class PLCSocketMCProtocol
    {
        public string ErrorMessage = "";
        public Socket m_Socket = null;
        public string state = "";
        public List<byte> Bdata = new List<byte>();
        public static byte[] buffer = new byte[1024];

        public string m_IP = "";
        public int m_port = 0;
        public bool SocketConnect(string IP, int port)///////////////////////////////////////////////
        {
            IPAddress ip = IPAddress.Parse(IP);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            m_IP = IP;
            m_port = port;

            if (m_Socket != null)
            {
                m_Socket.Close();
            }
            ////此处将 PC端作为客户端
            //创建Socket并连接到服务器
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                m_Socket.Connect(ipe);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool ReadData(Int16 addr, ref string ReceiveSn, Int16 lenght)//16位
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len = 0;
            Byte[] SendData = new byte[21]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x0c, //0C标志
                        0x00, 0x10, 0x00,0x01, 0x04, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16  低位在前
                        0x00, 0xa8, 
                        0x01, 0x00  //长度1
            };
            byte[] hex = BitConverter.GetBytes(addr);
            byte[] Lenght = BitConverter.GetBytes(lenght);
            SendData[15] = hex[0];
            SendData[16] = hex[1];
            SendData[19] = Lenght[0];
            SendData[20] = Lenght[1];
            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);
                    byte[] SnByte = new byte[len];
                    for (int i = 0; i + 11 < len; i++)
                    {
                        SnByte[i] = recBuffer[i + 11];
                    }
                    string[] ReceiveSN = Encoding.ASCII.GetString(SnByte).Split('\0');
                    ReceiveSn = ReceiveSN[0];
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }
        public bool ReadSingleInt16Data(Int16 addr, ref int value)//16位
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len = 0;
            Byte[] SendData = new byte[21]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x0c, //0C标志
                        0x00, 0x10, 0x00,0x01, 0x04, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16  低位在前
                        0x00, 0xa8, 
                        0x01, 0x00  //长度1
            };
            byte[] hex = BitConverter.GetBytes(addr);
            SendData[15] = hex[0];
            SendData[16] = hex[1];
            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);

                    value = recBuffer[12] * 256 + recBuffer[11];
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }
        public bool ReadSingleInt32Data(Int16 addr, ref double value)//32位
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len = 0;

            Byte[] SendData = new byte[21]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x0c, //0c标志
                        0x00, 0x10, 0x00,0x01, 0x04, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16  低位在前
                        0x00, 0xa8, 
                        0x02, 0x00  //长度1
            };

            byte[] hex = BitConverter.GetBytes(addr);
            SendData[15] = hex[0];
            SendData[16] = hex[1];
            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);

                    value = recBuffer[14] * 256 * 256 * 256 + recBuffer[13] * 256 * 256 + recBuffer[12] * 256 + recBuffer[11];
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }


        public bool WriteSingleInt16Data(Int16 addr, Int16 value)
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len;

            Byte[] SendData = new byte[23]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x0E, //0e标志
                        0x00, 0x10, 0x00,0x01, 0x14, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16 低位在前
                        0x00, 0xa8, 
                        0x01, 0x00, //长度 19、20 低位在前
                        0x00, 0x00, //值   21、22 低位在前
                    };

            byte[] hexaddr = BitConverter.GetBytes(addr);
            SendData[15] = hexaddr[0];
            SendData[16] = hexaddr[1];

            byte[] hexvalue = BitConverter.GetBytes(value);
            SendData[21] = hexvalue[0];
            SendData[22] = hexvalue[1];

            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    //Trace.WriteLine(string.Format("{0} - {1}", JGlobal.Time, ex.Message));
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }
        public bool WriteSingleInt32Data(Int16 addr, Int32 value)
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len;

            Byte[] SendData = new byte[25]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x10, 
                        0x00, 0x10, 0x00,0x01, 0x14, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16 低位在前
                        0x00, 0xa8, 
                        0x02, 0x00, //长度 19、20 低位在前
                        0x00, 0x00, //值   21、22 低位在前
                        0x00, 0x00, //值   21、22 低位在前
                    };

            byte[] hexaddr = BitConverter.GetBytes(addr);
            SendData[15] = hexaddr[0];
            SendData[16] = hexaddr[1];

            byte[] hexvalue = BitConverter.GetBytes(value);
            SendData[21] = hexvalue[0];
            SendData[22] = hexvalue[1];
            SendData[23] = hexvalue[2];
            SendData[24] = hexvalue[3];

            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }
        public bool WriteData(Int16 addr, string value, int Lenght)
        {
            byte[] recBuffer = new byte[1024];
            byte[] recData = new byte[1024];
            int len;

            Byte[] SendData = new byte[25]{
                        0x50, 0x00, 0x00, 0xff, 0xff, 0x03, 
                        0x00, 0x10, 
                        0x00, 0x10, 0x00,0x01, 0x14, 0x00, 0x00, 
                        0x00, 0x00, //地址 15、16 低位在前
                        0x00, 0xa8, 
                        0x03, 0x00, //长度 19、20 低位在前
                        0x00, 0x00, //值   21、22 低位在前
                        0x00, 0x00, //值   21、22 低位在前
                    };

            byte[] hexaddr = BitConverter.GetBytes(addr);

            SendData[15] = hexaddr[0];
            SendData[16] = hexaddr[1];

            byte[] hexvalue = Encoding.ASCII.GetBytes(value);


            


            SendData[21] = hexvalue[0];
            SendData[22] = hexvalue[1];
            SendData[23] = hexvalue[2];
            SendData[24] = hexvalue[3];

            if (m_Socket != null)
            {
                try
                {
                    m_Socket.Send(SendData, SendData.Length, 0);
                    len = m_Socket.Receive(recBuffer, recBuffer.Length, 0);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    m_Socket.Close();
                    m_Socket = null;
                    return false;
                }
            }
            else
            {
                SocketConnect(m_IP, m_port);
                return false;
            }
        }
        public void SocketClose()
        {
            if (m_Socket != null)
            {
                m_Socket.Close();
            }
        }
        /***********************************异步通讯**************************************/
        public bool Open()
        {
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
          //  IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(Global.Settings.Line1BufferIP[0].ToString()), int.Parse(Global.Settings.Line1BufferPort[0].ToString()));
       //     m_Socket.Connect(ipep);
            m_Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), m_Socket);

            //Console.Read();
            return true;
        }

        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var length = socket.EndReceive(ar);

                state = ASCIIEncoding.ASCII.GetString(buffer, 0, length);
                if (state.Contains("+wpo") || state.Contains("+spo"))
                {
                    for (int i = 4; i < length - 1; i++)
                    {
                        Bdata.Add(buffer[i]);
                    }
                }
                if (state.Contains("+alarm"))
                {
                    for (int i = 6; i < length - 1; i++)
                    {
                        Bdata.Add(buffer[i]);
                    }
                }

                // 接收下一条消息，因为是地柜调用，所以这样就一直可以接收消息
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteLine(string data)
        {
            byte[] sendBuffer = ASCIIEncoding.ASCII.GetBytes(data);
            m_Socket.Send(sendBuffer, 0, sendBuffer.Length, SocketFlags.None);
        }
        public void UpConfig()
        {
            //byte[] cmd = new byte[19];
            //cmd[0] = 0x2B;
            //cmd[1] = 0x63;
            //cmd[2] = 0x6F;
            //cmd[3] = 0x6E;
            //cmd[18] = 0x2D;

            //int index = JGlobal.Settings.configIndex;
            //Int16 s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_workP[index] * 100));
            //cmd[4] = Convert.ToByte(s1 / 256);
            //cmd[5] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_upTrip[index] * 100));
            //cmd[6] = Convert.ToByte(s1 / 256);
            //cmd[7] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_safeP[index] * 100));
            //cmd[8] = Convert.ToByte(s1 / 256);
            //cmd[9] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_downSpeed[index] * 100));
            //cmd[10] = Convert.ToByte(s1 / 256);
            //cmd[11] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_pressSpeed[index] * 100));
            //cmd[12] = Convert.ToByte(s1 / 256);
            //cmd[13] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_unPressSpeed[index] * 100));
            //cmd[14] = Convert.ToByte(s1 / 256);
            //cmd[15] = Convert.ToByte(s1 % 256);

            //s1 = Convert.ToInt16(Math.Ceiling(JGlobal.Settings.con_upSpeed[index] * 100));
            //cmd[16] = Convert.ToByte(s1 / 256);
            //cmd[17] = Convert.ToByte(s1 % 256);

            //m_Socket.Send(cmd, 0, 19, SocketFlags.None);
        }

        // 设置jog速度
        public void SetJogSpeed(double speed)
        {
            byte[] cmd = new byte[5] { 0x2B, 0x76, 0x00, 0x00, 0x2D };
            Int32 s1 = Convert.ToInt32(Math.Ceiling(speed * 100));
            cmd[2] = Convert.ToByte(s1 / 256);
            cmd[3] = Convert.ToByte(s1 % 256);
            m_Socket.Send(cmd, 0, 5, SocketFlags.None);
        }



        /// <summary>
        /// 向地址中的某一位写1或0
        /// </summary>
        /// <param name="addr PLC地址"></param>
        /// <param name="Index 写地址的位"></param>
        /// <param name="value 写地址1或0"></param>
        /// <returns></returns>
        //public bool WriteBit(Int16 addr, int Index, bool value)
        //{
        //    try 
        //    {
        //        int ValueWritebefore = 0;
        //        ReadSingleInt16Data(addr, ref ValueWritebefore);
        //        int ValueWrite= setIntegerSomeBit(ValueWritebefore, Index, value);
        //        return true;
        //    }
        //    catch 
        //    {
        //        return false;
        //    }

        //}

        //public bool ReadBit(Int16 addr, int Index,int value)
        //{
        //    try 
        //    {
        //        int Temp=0;
        //        ReadSingleInt16Data(addr, ref Temp);
        //        value= getIntegerSomeBit(Temp, Index);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

        public void ReadBit(short Add, byte bit, ref int value)
        {
            if (bit >= 16)
                return;
            int OrigValue = 0;

            ReadSingleInt16Data(Add, ref OrigValue);       
            Int16 dataRef = (Int16)(1 << bit);
            value = (dataRef & OrigValue) != 0 ? 1 : 0;
        }
        public void WriteBit(short Add, byte bit, int value)
        {
                            
            if (bit >= 16)
                return;
            int OrigValue = 0;
            ReadSingleInt16Data(Add, ref OrigValue);

            Int16 dataToSend = (Int16)(1 << bit);
            if (value != 0)
                dataToSend = (Int16)(dataToSend | (Int16)OrigValue);
            else
                dataToSend = (Int16)((~dataToSend) & (Int16)OrigValue);

            Thread.Sleep(5);

            WriteSingleInt16Data(Add, dataToSend);
        }





        /// <summary>  
        /// 取整数的某一位  
        /// </summary>  
        /// <param name="_Resource">要取某一位的整数</param>  
        /// <param name="_Mask">要取的位置索引，自右至左为0-7</param>  
        /// <returns>返回某一位的值（0或者1）</returns>  
        public static int getIntegerSomeBit(int _Resource, int _Mask)
        {
            return _Resource >> _Mask & 1;
        }

        /// <summary>  
        /// 将整数的某位置为0或1  
        /// </summary>  
        /// <param name="_Mask 设置的位">整数的某位</param>  
        /// <param name="a    原始值">整数</param>  
        /// <param name="flag  ">是否置1，TURE表示置1，FALSE表示置0</param>  
        /// <returns>返回修改过的值</returns>  
        public static int setIntegerSomeBit(int a, int _Mask, bool flag)
        {
            if (flag)
            {
                a |= (0x1 << _Mask);
            }
            else
            {
                a &= ~(0x1 << _Mask);
            }
            return a;
        }  


    }
}
