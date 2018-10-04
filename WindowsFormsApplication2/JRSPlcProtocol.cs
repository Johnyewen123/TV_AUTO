using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public enum PLCMemRegion
    {
        WREGION = 0,
        DREGION = 1,
        DREGIONBIT = 2,
        CIOREGION = 3
    };
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    //[DataContract]
    public class JRSFinsProtocal_UDP : IJRSPlcProtocol
    {
        private int m_port = 9600;
        private string m_IP = "192.168.250.1";
        private int RcvTimeOut = 5000;  // 超时设置
        private byte m_IPSelf = 11;
        private byte m_IPPLC = 10;

        private byte[] m_receiveData = null;
        private Socket m_client;


        private void short2byte(short num, out byte highByte, out byte lowByte)
        {
            highByte = (byte)(num >> 8);
            lowByte = (byte)(num & 0xFF);
        }
        public void setIPConfig(string ip, byte node_plc, byte node_self, int port)
        {
            m_IP = ip;
            m_port = port;
            m_IPPLC = node_plc;
            m_IPSelf = node_self;
        }
        public bool Open()
        {
            if (m_receiveData == null)
            {
                m_receiveData = new byte[2048];
            }
            IPAddress ipAddress = IPAddress.Parse(m_IP);
            var addrPort = new KeyValuePair<IPAddress, int>(ipAddress, m_port);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, m_port);
            // Create a TCP/IP socket.
            Close();
            m_client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            m_client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, RcvTimeOut);
            // Connect to the remote endpoint.
            m_client.Connect(remoteEP);
            SendHandshakeData();
            CheckHandshakeData();
            return true;
        }
        public bool Open(string ip, int port, byte node_plc, byte node_self)
        {
            setIPConfig(ip, node_plc, node_self, port);
            return Open();
        }
        public void Close()
        {
            if (null != m_client)
            {
                m_client.Shutdown(SocketShutdown.Both);
                m_client.Close();
            }
            m_client = null;
        }
        public byte[] Read(long Address, int iLen, PLCMemRegion menRegion, bool Is32Data)
        {
            byte[] rcvData = null;
            short AddressMajor;
            byte AddressMinor;
            switch (menRegion)
            {
                case PLCMemRegion.DREGION:
                    SendData(null, out rcvData, iLen, false, (short)Address, 0, PLCMemRegion.DREGION, Is32Data);
                    break;
                case PLCMemRegion.WREGION:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(null, out rcvData, iLen, false, AddressMajor, AddressMinor, PLCMemRegion.WREGION, false);
                    break;
                case PLCMemRegion.DREGIONBIT:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(null, out rcvData, iLen, false, AddressMajor, AddressMinor, PLCMemRegion.DREGIONBIT, false);
                    break;
                case PLCMemRegion.CIOREGION:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(null, out rcvData, iLen, false, AddressMajor, AddressMinor, PLCMemRegion.CIOREGION, false);
                    break;
            }
            return rcvData;
        }
        public void Write(byte[] data, long Address, PLCMemRegion menRegion, bool Is32Data)
        {
            byte[] rcvData;
            short AddressMajor;
            byte AddressMinor;
            switch (menRegion)
            {
                case PLCMemRegion.DREGION:
                    SendData(data, out rcvData, data.Length, true, (short)Address, 0, PLCMemRegion.DREGION, Is32Data);
                    break;
                case PLCMemRegion.WREGION:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(data, out rcvData, data.Length, true, AddressMajor, AddressMinor, PLCMemRegion.WREGION, Is32Data);
                    break;
                case PLCMemRegion.DREGIONBIT:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(data, out rcvData, data.Length, true, AddressMajor, AddressMinor, PLCMemRegion.DREGIONBIT, Is32Data);
                    break;
                case PLCMemRegion.CIOREGION:
                    AddressTranslation(Address, out AddressMajor, out AddressMinor);
                    SendData(data, out rcvData, data.Length, true, AddressMajor, AddressMinor, PLCMemRegion.CIOREGION, Is32Data);
                    break;
            }
        }

        private void AddressTranslation(long FullAddress, out short AddressMajor, out byte AddressMinor)
        {
            const int modBase = 100;
            AddressMajor = (short)(FullAddress / modBase);
            AddressMinor = (byte)(FullAddress % modBase);
        }

        public void SendData(byte[] PLCCommand, out byte[] recvData, int commandLen,
            bool isWrite,
            short startAddrInt,
            byte startAddrFraction,
            PLCMemRegion memRegion,//内存区域,
            bool is32Data
            )
        {
            recvData = null;
            byte m_highAddr;
            byte m_lowAddr;
            byte m_higLen;
            byte m_lowLen;
            int commandLenAlign;
            short dataLen;

            if (!is32Data)
            {
                if (isWrite)
                {
                    if (PLCMemRegion.DREGION == memRegion)
                    {
                        dataLen = (short)(commandLen / 2);
                    }
                    else
                    {
                        dataLen = (short)commandLen;
                    }
                }
                else
                {
                    dataLen = (short)commandLen;
                }
            }
            else
            {
                if (!isWrite)
                {
                    dataLen = (short)commandLen;
                }
                else
                {
                    dataLen = (short)(commandLen / 2);
                }
            }
            commandLenAlign = dataLen * 2;


            short2byte(dataLen, out m_higLen, out m_lowLen);
            short2byte(startAddrInt, out m_highAddr, out m_lowAddr);

            byte[] fins_cmnd;
            if (isWrite)
            {
                fins_cmnd = new byte[18 + commandLen];
            }
            else
                fins_cmnd = new byte[18];
            //for (int i = 0; i < 16; i++)
            //{
            //    fins_cmnd[i] = sendHeader[i];
            //}

            fins_cmnd[0] = 0x80;/*ICF*/
            fins_cmnd[1] = 0x00;/*RSV*/
            fins_cmnd[2] = 0x02;/*GCT*/
            fins_cmnd[3] = 0x00;/*DNA*/
            //fins_cmnd[20] = 0x6E;/*DA1*/
            fins_cmnd[4] = m_IPPLC;
            fins_cmnd[5] = 0x00;/*DA2*/
            fins_cmnd[6] = 0x00;/*SNA*/
            //fins_cmnd[23] = 0xEF;/*SA1*/
            fins_cmnd[7] = m_IPSelf;
            fins_cmnd[8] = 0x00;/*SID*/
            fins_cmnd[9] = 0x00;
            fins_cmnd[10] = 0x01;/*MRC*/
            if (isWrite)
            {
                fins_cmnd[11] = 0x02;/*SRC*/
            }
            else
            {
                fins_cmnd[11] = 0x01;/*SRC*/
            }
            // fins_cmnd[27] = (byte)readWrite;/*SRC--2代表写*/
            /*READ START ADDRESS:DM 01*/

            fins_cmnd[13] = m_highAddr;/*ICF*/
            fins_cmnd[14] = m_lowAddr;/*ICF*/

            fins_cmnd[16] = m_higLen;/*WORDS READ:150*/
            fins_cmnd[17] = m_lowLen;
            //fins_cmnd[31] = startAddrFraction;
            switch (memRegion)
            {
                case PLCMemRegion.WREGION:
                    fins_cmnd[12] = 0x31;/*VARIABLE TYPE:DM*/  // 31表示W区
                    fins_cmnd[15] = startAddrFraction;
                    break;
                case PLCMemRegion.DREGION:
                    fins_cmnd[12] = 0x82;/*VARIABLE TYPE:DM*/   // 82表示D区
                    fins_cmnd[15] = 0x00;
                    break;
                case PLCMemRegion.DREGIONBIT:
                    fins_cmnd[12] = 0x02;       // 02表示bit位读取D区
                    fins_cmnd[15] = startAddrFraction;
                    break;
                case PLCMemRegion.CIOREGION:
                    fins_cmnd[12] = 0x30;     // 30表示读取CIO的bit位
                    fins_cmnd[15] = startAddrFraction;
                    break;
            }

            if (isWrite)
            {
                var commandBuffer = SwapHLByte(PLCCommand, memRegion, is32Data);
                for (int i = 0; i < commandBuffer.Length; i++)
                {
                    fins_cmnd[i + 18] = commandBuffer[i];
                }
            }
            Send(fins_cmnd);
            int recvLen;
            Receive(m_receiveData, out recvLen);
            if (recvLen < 14)
            {
                throw new Exception(string.Format("Failed to receive data in Fins protocal. Received {0} bytes.", recvLen));
            }
            //if (m_receiveData[13] != 0x00 || m_receiveData[12] != 0x00)
            //    throw new FormatException(string.Format("Received data doesn't match required format. Byte [8-11]! must be 00 00 00 02. Recieved {0}",
            //        string.Join(" ", m_receiveData.Skip(8).Take(4).Select((x) => x.ToString("X2")))));
            if (!isWrite)
            {
                // Read
                if (PLCMemRegion.DREGION == memRegion || PLCMemRegion.WREGION == memRegion)
                {
                    recvData = SwapHLByte(m_receiveData.Take(recvLen).Skip(recvLen - commandLenAlign).ToArray(), memRegion, is32Data);
                }
                else
                {
                    recvData = m_receiveData.Take(recvLen).Skip(recvLen - commandLenAlign / 2).ToArray();
                }
                //if (commandLen != recvData.Length)
                //{
                //    Array.Resize(ref recvData, commandLen);
                //}
            }
        }

        private byte[] SwapHLByte(byte[] data, PLCMemRegion region, bool Is32Data)
        {
            var result = new byte[data.Length];
            if (PLCMemRegion.DREGION == region || PLCMemRegion.WREGION == region)
            {
                if (!Is32Data)
                {
                    for (int i = 0; i < data.Length - 1; i += 2)
                    {
                        result[i] = data[i + 1];
                        result[i + 1] = data[i];
                    }
                }
                else
                {
                    for (int i = 0; i < data.Length - 1; i += 4)
                    {
                        result[i] = data[i + 3];
                        result[i + 1] = data[i + 2];
                        result[i + 2] = data[i + 1];
                        result[i + 3] = data[i];
                    }
                }

                if (data.Length % 2 != 0)
                {
                    result[data.Length - 1] = data[data.Length - 1];
                }
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    result[i] = data[i];
                }
            }
            return result;
        }

        private bool CheckHandshakeData()
        {
            // Receive the response from the remote device.
            int recvLen;
            Receive(m_receiveData, out recvLen);
            if (0x00 != m_receiveData[12] || 0x00 != m_receiveData[13])
                return false;
            return true;
            // throw new Exception("Error header command!"); 
            //m_cli_node_no = m_receiveData[4];
            //m_srv_node_no = m_receiveData[7];
        }

        private void SendHandshakeData()
        {
            // 80 00 02 00 03 00 00 D6 00 00 01 01 82 00 00 00 00 01
            byte[] handHeader = new byte[] { 0x80, 0x00, 0x02, 0x00, m_IPPLC, 0x00, 0x00, m_IPSelf, 0x00, 0x00, 0x01, 0x01, 0x82, 0x00, 0x00, 0x00, 0x00, 0x01 };
            // Send test data to the remote device.
            Send(handHeader);
        }

        private void Receive(byte[] receiveData, out int recvLen)
        {
            DateTime tm = DateTime.Now;
            while (true)
            {
                // Begin receiving the data from the remote device.
                recvLen = m_client.Receive(receiveData);
                if (recvLen > 0)
                    break;
                double elapsedTime = (DateTime.Now - tm).TotalSeconds;
                if (elapsedTime >= RcvTimeOut)
                    throw new TimeoutException(string.Format("Time out when receiving FINS data. Timeout setting {0} ms. Elapsed {1} ms.", RcvTimeOut, elapsedTime));
            }
        }

        private void Send(byte[] byteData)
        {
            // Begin sending the data to the remote device.
            m_client.Send(byteData, 0, byteData.Length, 0);
        }

        public void WriteByte(long Address, byte[] data)
        {
            Write(data, Address, PLCMemRegion.DREGION, false);
        }

        public byte[] ReadByte(long Address, int iLen)
        {
            return Read(Address, (iLen + 1) / 2, PLCMemRegion.DREGION, false);
        }
        public void ReadBit(int port, byte bit, ref int value)
        {
            if (bit >= 16)
                return;
            int OrigValue = 0;
            ReadInt16(port, ref OrigValue);

            Int16 dataRef = (Int16)(1 << bit);
            value = (dataRef & OrigValue) != 0 ? 1 : 0;
        }
        public void WriteBit(int port, byte bit, int value)
        {
            if (bit >= 16)
                return;
            int OrigValue = 0;
            ReadInt16(port, ref OrigValue);

            Int16 dataToSend = (Int16)(1 << bit);
            if (value != 0)
                dataToSend = (Int16)(dataToSend | (Int16)OrigValue);
            else
                dataToSend = (Int16)((~dataToSend) & (Int16)OrigValue);

            Thread.Sleep(5);
            WriteInt16(port, dataToSend);
        }

        /// <summary>
        /// 读取一个端口 16位的值 
        /// </summary>
        /// <param name="port"></param>
        /// 参数为端口号，整数
        /// <returns></returns>
        /// 返回值为Int16
        public void ReadInt16(int port, ref int value)
        {
            value = BitConverter.ToInt16(Read(port, 1, PLCMemRegion.DREGION, false), 0);
        }

        public void ReadInt16_C(int port, int len, ref Int16[] data)
        {
            byte[] result = Read(port, len, PLCMemRegion.DREGION, false);
            for (int i = 0; i < len; i++)
            {
                data[i] = BitConverter.ToInt16(result, i * 2);
            }
        }

        public void WriteInt16(int port, Int16 Data)
        {
            Write(BitConverter.GetBytes(Data), port, PLCMemRegion.DREGION, false);
        }

        public void WriteInt16_C(int port, Int16[] Data)
        {
            byte[] data = new byte[Data.Length * 2];
            for (int i = 0; i < Data.Length; i++)
            {
                byte[] result = BitConverter.GetBytes(Data[i]);
                data[i * 2] = result[0];
                data[i * 2 + 1] = result[1];
            }
            Write(data, port, PLCMemRegion.DREGION, false);
        }

        /// <summary>
        /// 读取一个端口32位的值
        /// </summary>
        /// <param name="port"></param>
        /// 参数端口号为整形
        /// <returns></returns>
        /// 返回值为Int32
        public void ReadInt32(int port, ref int value)
        {
            byte[] result = Read(port, 2, PLCMemRegion.DREGION, true);
            value = BitConverter.ToInt16(result, 0) * 256 * 256 + BitConverter.ToInt16(result, 2);
        }
        public void ReadFloat(int port, ref float value)
        {
            byte[] result = Read(port, 2, PLCMemRegion.DREGION, true);
            byte[] temp = new byte[4];
            temp[0] = result[2];
            temp[1] = result[3];
            temp[2] = result[0];
            temp[3] = result[1];
            value = BitConverter.ToSingle(temp, 0);
        }

        public void ReadFloat_C(int port, int len, ref float[] data)
        {
            byte[] result = Read(port, len * 2, PLCMemRegion.DREGION, true);
            for (int i = 0; i < len; i++)
            {
                byte[] temp = new byte[4];
                temp[0] = result[2 + i * 4];
                temp[1] = result[3 + i * 4];

                temp[2] = result[0 + i * 4];

                temp[3] = result[1 + i * 4];
                data[i] = BitConverter.ToSingle(temp, 0);
            }
        }
        public void ReadInt32_C(int port, int len, ref Int32[] data)
        {
            byte[] result = Read(port, len * 2, PLCMemRegion.DREGION, true);
            for (int i = 0; i < len; i++)
            {
                byte[] temp = new byte[4];
                temp[0] = result[2 + i * 4];
                temp[1] = result[3 + i * 4];

                temp[2] = result[0 + i * 4];

                temp[3] = result[1 + i * 4];
                data[i] = BitConverter.ToInt32(temp, 0);
            }
        }

        public void Write(uint port, byte[] data)
        {
            Write(data, port, PLCMemRegion.DREGION, true);
        }
        public void Write(byte[] data, uint port)
        {
            Write(data, port, PLCMemRegion.DREGION, true);
        }
        public void WriteInt32(int port, Int32 Data)
        {
            byte[] data = BitConverter.GetBytes(Data);
            byte[] data1 = new byte[4];
            data1[0] = data[2];
            data1[1] = data[3];
            data1[2] = data[0];
            data1[3] = data[1];
            Write(data1, port, PLCMemRegion.DREGION, true);
        }
        public void WriteFloat(int port, float Data)
        {
            byte[] data = BitConverter.GetBytes(Data);
            byte[] data1 = new byte[4];
            data1[0] = data[2];
            data1[1] = data[3];
            data1[2] = data[0];
            data1[3] = data[1];
            Write(data1, port, PLCMemRegion.DREGION, true);
        }

        public void WriteInt32_C(int port, Int32[] Data)
        {
            byte[] data = new byte[Data.Length * 4];
            for (int i = 0; i < Data.Length; i++)
            {
                byte[] result = BitConverter.GetBytes(Data[i]);
                data[i * 4] = result[2];
                data[i * 4 + 1] = result[3];
                data[i * 4 + 2] = result[0];
                data[i * 4 + 3] = result[1];
            }
            Write(data, port, PLCMemRegion.DREGION, true);
        }
        public void WriteFloat_C(int port, float[] Data)
        {
            byte[] data = new byte[Data.Length * 4];
            for (int i = 0; i < Data.Length; i++)
            {
                byte[] result = BitConverter.GetBytes(Data[i]);
                data[i * 4] = result[2];
                data[i * 4 + 1] = result[3];
                data[i * 4 + 2] = result[0];
                data[i * 4 + 3] = result[1];
            }
            Write(data, port, PLCMemRegion.DREGION, true);
        }
    }

    public interface IJRSPlcProtocol
    {
        void Close();
        bool Open();
        bool Open(string ip, int port, byte node_plc, byte node_self);
        byte[] ReadByte(long Address, int iLen);
        void WriteByte(long Address, byte[] data);
        void ReadBit(int port, byte bit, ref int value);
        void ReadFloat(int port, ref float value);
        void ReadFloat_C(int port, int len, ref float[] data);
        void ReadInt16(int port, ref int value);
        void ReadInt16_C(int port, int len, ref short[] data);
        void ReadInt32(int port, ref int value);
        void ReadInt32_C(int port, int len, ref int[] data);
        void Write(byte[] data, uint port);
        void Write(uint port, byte[] data);
        void WriteBit(int port, byte bit, int value);
        void WriteFloat(int port, float Data);
        void WriteFloat_C(int port, float[] Data);
        void WriteInt16(int port, short Data);
        void WriteInt16_C(int port, short[] Data);
        void WriteInt32(int port, int Data);
        void WriteInt32_C(int port, int[] Data);
    }
}
