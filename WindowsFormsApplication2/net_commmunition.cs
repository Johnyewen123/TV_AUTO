

////网口通讯类


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
 #region
    ///
    /// 作服务器
    ///
  public   class net_commmunition
    {
        Socket server, client;
        bool connectok=false ;
       

        public void Open(string ip, string port)
        {
           
            if (server ==null)  
            {
                
                IPAddress IP = IPAddress.Parse(ip);
                Int32 PORT = Convert.ToInt16(port);
                IPEndPoint SERVER = new IPEndPoint(IP, PORT);//生成服务器网络端点
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // 构造一个socket
                server.Bind(SERVER); //将socket和服务器绑定
                server.Listen(8); //开始监听，允许连接队列的长度为8
                AsyncCallback callback = new AsyncCallback(OnConnectRequest);
                server.BeginAccept(callback, server);//开始接受一个异步操作来接受传入的连接尝试
            }
          
        }
        public bool connect()
        {
            try
            {
                if (client != null && client.Connected)
                {
                    connectok = true;
                    return true;
                }
                else
                {
                    connectok = false;
                    return false;

                }
            }

            catch
            {
                connectok = false;
                return false;
            
            }

           
        }
        private void OnConnectRequest(IAsyncResult result)
        {
            if (server != null)
            {
                client = server.EndAccept(result);
                AsyncCallback callback = new AsyncCallback(OnConnectRequest);
                server.BeginAccept(callback, server);//开始接受一个异步操作来接受传入的连接尝试
            }
        }
        public string[] Read()
        {
            string[] str=new  string [4];
            string a=string.Empty;
            byte[] data = new byte[1024];
            try
            {
                if (client != null && client.Available > 0)
                {
                    client.Receive(data);
                    a = Encoding.ASCII.GetString(data);
                    str = a.Split(';');
                    Class_Excell.P_JXS = str;
                }
            }
            catch
            {
                AsyncCallback callback = new AsyncCallback(OnConnectRequest);
                server.BeginAccept(callback, server);//开始接受一个异步操作来接受传入的连接尝试
                MessageBox.Show("与机械手通信连接中断");
            }
           
            return str;
        }


         

        public void Write(string str)
        {
            try
            {
                client.Send(Encoding.ASCII.GetBytes(str.ToCharArray()));
                
            }
            catch
            {
                AsyncCallback callback = new AsyncCallback(OnConnectRequest);
                server.BeginAccept(callback, server);//开始接受一个异步操作来接受传入的连接尝试
                MessageBox.Show("与机械手通信连接中断");
            }
        }
        public void Close()
        {
            
            //client = null;
            //server.Disconnect(false);
            //server.Close();
            //server.Dispose();
            //server = null;
            if (client != null && client.Connected)
            {
                client.Disconnect(true  );
                client.Close();
                client = null;
                server.Close();
                server = null;
              
            }
 
            //System.GC.Collect();
            
        }

        /// <summary>
        /// 那智机器人坐标数据输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertStringTo7(string value)
        {

            string result = "00";
            double a = double.Parse(value);
            if (a > 0)
            {
                byte[] temp = Encoding.Default.GetBytes(value);
                if (temp.Length < 8)
                {
                    string temp_s = "";
                    int count = 7 - temp.Length;
                    for (int i = 0; i < count; i++)
                    {
                        temp_s += "0";
                    }
                    value = "+" + temp_s + value;
                    result = value;
                }
            }
            if (a < 0)
            {

                double b = Math.Abs(a);
                string bString = b.ToString("0.000");
                byte[] tempNa = Encoding.Default.GetBytes(bString);

                if (tempNa.Length < 8)
                {
                    string temp_s = "";
                    int count = 7 - tempNa.Length;
                    for (int i = 0; i < count; i++)
                    {
                        temp_s += "0";
                    }
                    value = "-" + temp_s + bString;
                    result = value;
                }

                if (a == 0)
                {
                    value = "+" + "000.000";
                    result = value;
                }

            }

            //result = "+" + "000.000";
            return result;
        }





    }
    #endregion
  //}
#region
    /////
    ///// 作客户端
    /////
    //class net_commmunition
    //{
    //    TcpClient tclient = new TcpClient();
    //    public void Open(string ip, string port)
    //    {
    //        try
    //        {
    //            Int32 PORT = Int32.Parse(port);
    //            tclient.Connect(ip, PORT);
    //        }
    //        catch
    //        {
            
    //            MessageBox.Show("连接远程主机出错");

    //        }
    //    }
    //    public string Read()
    //    {
    //        string str = string.Empty;
    //        try
    //        {
    //            NetworkStream ns = tclient.GetStream();
    //            if (tclient.Available > 0)
    //            {
    //                byte[] data = new byte[1024];
    //                ns.Read(data, 0, 1024);
    //                str = Encoding.ASCII.GetString(data);
    //            }
    //        }
    //        catch
    //        {
    //            MessageBox.Show("通信连接中断");
    //        }

    //        return str;
    //    }
    //    public void Write(string str)
    //    {
    //        try
    //        {
    //            NetworkStream ns = tclient.GetStream();
    //            byte[] data = Encoding.ASCII.GetBytes(str);
    //            ns.Write(data, 0, data.Length);
    //        }
    //        catch
    //        {
    //            MessageBox.Show("通信连接中断");
    //        }

    //    }
    //    public void Close()
    //    {
    //        tclient.Close();
    //    }

  //}
#endregion
 //那智机器人通讯




}
