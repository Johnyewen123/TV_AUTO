using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using   System.IO;

namespace WindowsFormsApplication2
{
    class Class_Writelog
    {
       //public string m_LogPath;
        public string m_currentTIme;
    //    public string error_mesg;
        FileStream fs1;
        StreamWriter sw1;
        public Class_Writelog(string LogPath)
        {
            System.DateTime curerntTime = new System.DateTime();
            curerntTime = System.DateTime.Now;
            string[] DatatimeStr = new string[7];
            DatatimeStr[0] = curerntTime.Year.ToString();
            DatatimeStr[1] = curerntTime.Month.ToString();
            DatatimeStr[2] = curerntTime.Day.ToString();
            DatatimeStr[3] = curerntTime.Hour.ToString();
            DatatimeStr[4] = curerntTime.Minute.ToString();
            DatatimeStr[5] = curerntTime.Second.ToString();
            DatatimeStr[6] = curerntTime.Millisecond.ToString();
            string CurrentTimeStr = null;
            for (int i = 0; i < 7; i++)
            {
                string SeperatorStr = "-";
                if (i == 6)
                {
                    SeperatorStr = ":";
                }
                CurrentTimeStr = CurrentTimeStr + DatatimeStr[i] + SeperatorStr;

            }
            m_currentTIme = CurrentTimeStr;


           fs1 = new FileStream(LogPath, FileMode.Create, FileAccess.Write);
           sw1 = new StreamWriter(fs1); 

        }
        
       public  void WriteLogFile(string error_mesg)
       {
                 
           sw1.WriteLine(m_currentTIme+error_mesg);
           sw1.Close();
           fs1.Close();
         
        }             
    }












    
}

