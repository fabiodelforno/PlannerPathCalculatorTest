namespace Planner_Path_Calculator
{
    partial class Create
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create));
            this.create_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.type_box = new System.Windows.Forms.TextBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.depthBox = new System.Windows.Forms.TextBox();
            this.splitsizebox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.attributiNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attrNodo1 = new System.Windows.Forms.ToolStripTextBox();
            this.attrNodo2 = new System.Windows.Forms.ToolStripTextBox();
            this.attrNodo3 = new System.Windows.Forms.ToolStripTextBox();
            this.attrNodo4 = new System.Windows.Forms.ToolStripTextBox();
            this.attrNodo5 = new System.Windows.Forms.ToolStripTextBox();
            this.attributiArcoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attrArco1 = new System.Windows.Forms.ToolStripTextBox();
            this.attrArco2 = new System.Windows.Forms.ToolStripTextBox();
            this.attrArco3 = new System.Windows.Forms.ToolStripTextBox();
            this.attrArco4 = new System.Windows.Forms.ToolStripTextBox();
            this.attrArco5 = new System.Windows.Forms.ToolStripTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // create_button
            // 
            this.create_button.BackColor = System.Drawing.Color.Transparent;
            this.create_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("create_button.BackgroundImage")));
            this.create_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.create_button.Location = new System.Drawing.Point(351, 353);
            this.create_button.Margin = new System.Windows.Forms.Padding(2);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(72, 37);
            this.create_button.TabIndex = 0;
            this.create_button.UseVisualStyleBackColor = false;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(38, 435);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 41);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // type_box
            // 
            this.type_box.Location = new System.Drawing.Point(362, 245);
            this.type_box.Name = "type_box";
            this.type_box.Size = new System.Drawing.Size(72, 20);
            this.type_box.TabIndex = 2;
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(250, 296);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(289, 20);
            this.pathBox.TabIndex = 3;
            this.pathBox.Text = "Inserire qui il percorso in cui salvare il file JSON";
            // 
            // depthBox
            // 
            this.depthBox.Location = new System.Drawing.Point(278, 245);
            this.depthBox.Name = "depthBox";
            this.depthBox.Size = new System.Drawing.Size(42, 20);
            this.depthBox.TabIndex = 4;
            // 
            // splitsizebox
            // 
            this.splitsizebox.Location = new System.Drawing.Point(466, 245);
            this.splitsizebox.Name = "splitsizebox";
            this.splitsizebox.Size = new System.Drawing.Size(41, 20);
            this.splitsizebox.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(250, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(289, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo dell\'albero";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attributiNodoToolStripMenuItem,
            this.attributiArcoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // attributiNodoToolStripMenuItem
            // 
            this.attributiNodoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attrNodo1,
            this.attrNodo2,
            this.attrNodo3,
            this.attrNodo4,
            this.attrNodo5});
            this.attributiNodoToolStripMenuItem.Name = "attributiNodoToolStripMenuItem";
            this.attributiNodoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.attributiNodoToolStripMenuItem.Text = "Attributi Nodo";
            // 
            // attrNodo1
            // 
            this.attrNodo1.Name = "attrNodo1";
            this.attrNodo1.Size = new System.Drawing.Size(100, 23);
            // 
            // attrNodo2
            // 
            this.attrNodo2.Name = "attrNodo2";
            this.attrNodo2.Size = new System.Drawing.Size(100, 23);
            // 
            // attrNodo3
            // 
            this.attrNodo3.Name = "attrNodo3";
            this.attrNodo3.Size = new System.Drawing.Size(100, 23);
            // 
            // attrNodo4
            // 
            this.attrNodo4.Name = "attrNodo4";
            this.attrNodo4.Size = new System.Drawing.Size(100, 23);
            // 
            // attrNodo5
            // 
            this.attrNodo5.Name = "attrNodo5";
            this.attrNodo5.Size = new System.Drawing.Size(100, 23);
            // 
            // attributiArcoToolStripMenuItem
            // 
            this.attributiArcoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attrArco1,
            this.attrArco2,
            this.attrArco3,
            this.attrArco4,
            this.attrArco5});
            this.attributiArcoToolStripMenuItem.Name = "attributiArcoToolStripMenuItem";
            this.attributiArcoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.attributiArcoToolStripMenuItem.Text = "Attributi Arco";
            // 
            // attrArco1
            // 
            this.attrArco1.Name = "attrArco1";
            this.attrArco1.Size = new System.Drawing.Size(100, 23);
            // 
            // attrArco2
            // 
            this.attrArco2.Name = "attrArco2";
            this.attrArco2.Size = new System.Drawing.Size(100, 23);
            // 
            // attrArco3
            // 
            this.attrArco3.Name = "attrArco3";
            this.attrArco3.Size = new System.Drawing.Size(100, 23);
            // 
            // attrArco4
            // 
            this.attrArco4.Name = "attrArco4";
            this.attrArco4.Size = new System.Drawing.Size(100, 23);
            // 
            // attrArco5
            // 
            this.attrArco5.Name = "attrArco5";
            this.attrArco5.Size = new System.Drawing.Size(100, 23);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gli attributi possono essere inseriti tramite il menu in alto.";
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(721, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.splitsizebox);
            this.Controls.Add(this.depthBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.type_box);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Create";
            this.Text = "Create";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox type_box;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.TextBox depthBox;
        private System.Windows.Forms.TextBox splitsizebox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem attributiNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox attrNodo1;
        private System.Windows.Forms.ToolStripTextBox attrNodo2;
        private System.Windows.Forms.ToolStripTextBox attrNodo3;
        private System.Windows.Forms.ToolStripTextBox attrNodo4;
        private System.Windows.Forms.ToolStripTextBox attrNodo5;
        private System.Windows.Forms.ToolStripMenuItem attributiArcoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox attrArco1;
        private System.Windows.Forms.ToolStripTextBox attrArco2;
        private System.Windows.Forms.ToolStripTextBox attrArco3;
        private System.Windows.Forms.ToolStripTextBox attrArco4;
        private System.Windows.Forms.ToolStripTextBox attrArco5;
        private System.Windows.Forms.Label label2;
    }
}