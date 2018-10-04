using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;


namespace WindowsFormsApplication2
{
    public partial class FormPassward : Form
    {
        public FormPassward()
        {
            InitializeComponent();
        }

        [DllImport("kernel32")]

        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]

        public static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        private void btn_ok_Click(object sender, EventArgs e)
        {


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
