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
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            loadingProgress1.Start();
        }
        int ipking = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ipking++;
                if (ipking % 12 == 0) label6.Text = "加载中";
                if (ipking % 12 == 4) label6.Text = "加载中...";
                if (ipking % 12 == 8) label6.Text = "加载中......";

                long lk = System.Threading.Interlocked.Read(ref FormMain.lClosingLoading);
                if (lk == 1)
                {
                    timer1.Enabled = false; loadingProgress1.Stop();
                    this.Close();
                }

            }
            catch (Exception exc)
            {

            }
        }


    }
}
