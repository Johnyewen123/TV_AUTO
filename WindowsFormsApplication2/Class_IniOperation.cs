 ///该类主要实现对于ini文件的读取以及写入功能，其中使用了File类，该类对于文件的读写很方便 


///使用DllImport 调用c++动态库以使用其中方法
///extern 修饰符用于声明在外部实现的方法。 
///extern 修饰符的常见用法是在使用 Interop 服务调入非托管代码时与 DllImport 属性一起使用。 在这种情况下，还必须将方法声明为 static

///结合List类对于程序参数进行存储
///1参数功能分类  文档存储参数、程序实际运行参数、界面显示参数
/// 初始化类时候 通过ini read函数 使文档参数->程序运行参数和界面显示参数    运行过程中修改 界面参数-〉程序运行参数和界面参数



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;//
namespace WindowsFormsApplication2
{
    class Class_IniOperation
    {


         // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        private string sPath = null;

        public Class_IniOperation(string fileName)
        {
         // Class_IniOperation类的构造函数
            fileName = Class_Global.SocketParaPath;
            this.sPath = fileName;
            
        }

        public void WriteValue(string section, string key, string value)
        {
            // section=配置节，key=键名，value=键值，path=路径
            WritePrivateProfileString(section, key, value, sPath);
        }

        public string ReadValue(string section, string key)
        {
            if (!CheckIniFileExist())
            {
                throw new ApplicationException( "文件不存在");
            }
            // 每次从ini中读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            //System.Text.StringBuilder temp = new System.Text.StringBuilder(500);
            // section=配置节，key=键名，temp=上面，path=路径
            GetPrivateProfileString(section, key, "", temp, 255, sPath);
            return temp.ToString();

        }

    public  bool CheckIniFileExist()
        {
            bool ret = false;
            ret = File.Exists(sPath);
            return ret;

        }
    }
}
