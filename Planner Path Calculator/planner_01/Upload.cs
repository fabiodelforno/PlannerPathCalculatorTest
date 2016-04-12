using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Planner_Path_Calculator
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();

            progressBar1.Visible = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "json only.|*.json;";
            DialogResult dr = openfd.ShowDialog();
            url.Text = openfd.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }

        private void upload_button_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            loadJson();
        }


        private Tree readJsonFile(string fileJson)
        {
            StreamReader sr = File.OpenText(fileJson);
            JsonTextReader jr = new JsonTextReader(sr);
            JsonSerializer serializer = new JsonSerializer();
            Tree jsonToTree = serializer.Deserialize<Tree>(jr);
            //nel caso non funzioni ancora, commenta la riga di sopra e decommenta questa
            //Tree jsonToTree = (Tree)serializer.Deserialize(sr, typeof(Tree));
            return jsonToTree;
        }

        private async void loadJson()
        {
            label1.Text = "Deserializzazione JSON in corso...";
            //string fileJson = File.ReadAllText(pathBox.Text);

            //Tree albero = await Task.Run(() => JsonConvert.DeserializeObject<Tree>(fileJson));    

            //deserializza da file.json a oggetto tree 
            Tree albero = await Task.Run(() => readJsonFile(url.Text));


            label1.Text = "Caricamento sul Database in corso...";
            Upload_Component upTOdb = new Upload_Component();

            if (upTOdb.start_upload(albero))
            {
                label1.Text = "Operazione completata. Controlla il Database.";
            }
            else
            {
                label1.Text = "Esiste già un albero di tipo: " + albero.NameTree + " sul DB.";
            }

            progressBar1.Visible = false;
        }

        

        
    }
}
