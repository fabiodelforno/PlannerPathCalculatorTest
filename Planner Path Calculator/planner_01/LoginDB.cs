using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner_Path_Calculator
{
    public partial class LoginDB : Form
    {
        public SqlConnection sdwDBConnection { get; set; }
       // public string sdwConnectionString { get; set; }
        public LoginDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sdwConnectionString = @"Data Source = " + nameServer.Text + ";" + "user id=" + user.Text + ";" +
                  "password=" + password.Text + ";" + "Initial Catalog = " + database.Text + ";";

            configFileConnect(sdwConnectionString);

            Console.WriteLine("connessione aperta");
            this.Hide();
            Start start = new Start();
           
            start.Show();

        }

        private void configFileConnect(String sdw)
        {
            
            FileStream fs = File.Open("config.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(sdw);
            sw.Flush();
            fs.Close();
            
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openfd = new OpenFileDialog();
        //    DialogResult dr = openfd.ShowDialog();
        //}
    }
}
