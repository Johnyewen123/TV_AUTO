using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace WindowsFormsApplication2
{
    static class Class_Excell
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        public static bool bFind = false;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //程序开启界面设置
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "ThisShouldOnlyRunOnce");
            bool Running = !mutex.WaitOne(0, true);
            if (!Running)
            {
                Action action = new Action(StartClient);
                //Task.Factory.StartNew(action);
                taskk = new Task(action);
                taskk.Start();//将task 安排到system.threading.tasks.taskSchesuler中执行，与主线程同时执行
                bFind = true;//授权获取
                if (!bFind) return;
                else
                {
                    Application.Run(new FormMain());
                }
            }
            else
            {
                MessageBox.Show("程序已在运行！");
            }

        }

        public static string[] JXS = new string[10];
        public static string[] P_JXS
        {
            get
            {
                return JXS;
            }
            set
            {
                JXS = value;
            }
        }
        static Task taskk;//表示异步基元操作
        static void StartClient()
        {

            FormLoading formload = new FormLoading();
            formload.ShowDialog();
        }

        static void StopClient()
        {
            if (taskk.Status == TaskStatus.Running)
                taskk.Dispose();
        }


    }
}
