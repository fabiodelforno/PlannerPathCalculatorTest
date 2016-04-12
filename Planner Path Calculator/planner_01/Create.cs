using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner_Path_Calculator
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();

            progressBar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
        }

        private async void create_button_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            string nameTree = type_box.Text;
            string path = pathBox.Text;
            int depth = int.Parse(depthBox.Text);
            int splitsize = int.Parse(splitsizebox.Text);

            string[] attrlist = new string[10];
            attrlist[0] = attrNodo1.Text;
            attrlist[1] = attrNodo2.Text;
            attrlist[2] = attrNodo3.Text;
            attrlist[3] = attrNodo4.Text;
            attrlist[4] = attrNodo5.Text;

            attrlist[5] = attrArco1.Text;
            attrlist[6] = attrArco2.Text;
            attrlist[7] = attrArco3.Text;
            attrlist[8] = attrArco4.Text;
            attrlist[9] = attrArco5.Text;

            Create_Component create_tree = new Create_Component();

            await Task.Run(() => create_tree.createJsonFile(nameTree, path, depth, splitsize, attrlist));

            MessageBox.Show("Operazione completata. Controlla il file JSON!");
            progressBar1.Visible = false;
        }
    }
}
