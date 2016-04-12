using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Planner_Path_Calculator
{
    public partial class Engine : Form
    {
        String initVertex = "";
        String endVertex = "";
        String attr1 = "";
        String attr2 = "";
        String attr3 = "";
        String attr4 = "";
        String attr5 = "";
        String tipo = "";
        




        public Engine()
        {
            InitializeComponent();           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initVertex = init_Vertex.Text;
            endVertex = end_Vertex.Text;
            attr1 = attributo1.Text;

            if (Attributo2.Text != "")
            {
                attr2 = Attributo2.Text;
            }
            if (Attributo3.Text != "")
            {
                attr3 = Attributo3.Text;
            }

            if (Attributo4.Text != "")
            {
                attr4 = Attributo4.Text;
            }
            if (Attributo5.Text != "")
            {
                attr5 = Attributo5.Text;
            }
            if (tipo1.Text != "")
            {
                tipo = tipo1.Text;
            }
            else
            {
                MessageBox.Show("inserisci il tipo");
            }
            
            String input = tipo + " " + initVertex + " " + endVertex + " " + attr1 + " " + attr2 + " " + attr3 + " " + attr4 + " " + attr5;

            System.IO.DirectoryInfo dir = System.IO.Directory.GetParent(Environment.CurrentDirectory);
            String enginePath = dir.FullName;
            enginePath = enginePath + @"\Engine\engine.exe";
            Process.Start(enginePath, input);
            
            attr1 = attr2 = attr3 = attr4 = attr5 = "";
        }

        //private String openFileConfig(String conf)
        //{
        //    string path = pathConf.Text;
        //    FileStream fs = File.Open(pathConf.Text + "confing.txt", FileMode.CreateNew);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.WriteLine(sdw);

        //    fs.Close();
        //}
    }
}