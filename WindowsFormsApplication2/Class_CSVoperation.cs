//lsit类的应用


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace LabFuture
{
    class class_CSVFileOperation
    {
        /// <summary>
        /// 将List<string[]>中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        /// 
        public static void SaveCSV(List<string[]> listStrData, string fullPath)
        {
            try
            {
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists) fi.Directory.Create();

                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Append, System.IO.FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                string data = "";
                //写出各行数据
                for (int i = 0; i < listStrData.Count; i++)
                {
                    if (listStrData[i] == null) continue;

                    data = "";
                    for (int j = 0; j < listStrData[i].Length; j++)
                    {
                        string str = listStrData[i][j].ToString();
                        str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                        if (str.Contains(',') || str.Contains('"')
                            || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                        {
                            str = string.Format("\"{0}\"", str);
                        }

                        data += str;
                        if (j < listStrData[i].Length - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();

            }
            catch (Exception exc)
            {
                dhDll.frmMsg.Log("保存List到csv文件出错:" + exc.Message, 1, 2, 0);
            }
        }


    }
}