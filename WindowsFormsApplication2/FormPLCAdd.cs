using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;



namespace WindowsFormsApplication2
{
    public partial class FormPLCAdd : Form
    {
      //  Class_Para m_para = new Class_Para();
        public FormPLCAdd()
        {
            InitializeComponent();

            //XmlSerializer serializer = new XmlSerializer(m_para.GetType());
            //FileStream stream = new FileStream("Department.xml", FileMode.Open);
            //m_para = (Class_Para)serializer.Deserialize(stream);
            //stream.Close();　　
            propertyGrid1.SelectedObject = FormMain.m_para;
               


        }

        private void btn_SaveXML_Click(object sender, EventArgs e)
        {

          //  string xml = XmlUtil.Serializer(typeof(Class_Para), m_para);
            XmlSerializer serializer = new XmlSerializer(FormMain.m_para.GetType());
            TextWriter writer = new StreamWriter("Department.xml");
            serializer.Serialize(writer, FormMain.m_para);
            writer.Close();



        }


    }



    


}
