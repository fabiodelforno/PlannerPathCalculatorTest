using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner_Path_Calculator
{
    public partial class Start : Form
    {


        public Start()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Engine engine = new Engine();
            engine.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Upload upload = new Upload();
            upload.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Show();
            Create create = new Create();
            create.Show();
        }

        //private void Start_Load(object sender, EventArgs e)
        //{
            
        //}

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uscire dall'applicazione?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
