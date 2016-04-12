namespace Planner_Path_Calculator
{
    partial class Engine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Engine));
            this.button1 = new System.Windows.Forms.Button();
            this.init_Vertex = new System.Windows.Forms.TextBox();
            this.end_Vertex = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Attributi = new System.Windows.Forms.ToolStripMenuItem();
            this.attributo1 = new System.Windows.Forms.ToolStripTextBox();
            this.Attributo2 = new System.Windows.Forms.ToolStripTextBox();
            this.Attributo3 = new System.Windows.Forms.ToolStripTextBox();
            this.Attributo4 = new System.Windows.Forms.ToolStripTextBox();
            this.Attributo5 = new System.Windows.Forms.ToolStripTextBox();
            this.tipo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(42, 460);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 54);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // init_Vertex
            // 
            this.init_Vertex.Location = new System.Drawing.Point(340, 202);
            this.init_Vertex.Margin = new System.Windows.Forms.Padding(2);
            this.init_Vertex.Name = "init_Vertex";
            this.init_Vertex.Size = new System.Drawing.Size(110, 20);
            this.init_Vertex.TabIndex = 1;
            // 
            // end_Vertex
            // 
            this.end_Vertex.Location = new System.Drawing.Point(257, 285);
            this.end_Vertex.Margin = new System.Windows.Forms.Padding(2);
            this.end_Vertex.Name = "end_Vertex";
            this.end_Vertex.Size = new System.Drawing.Size(110, 20);
            this.end_Vertex.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 370);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "START ENGINE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Attributi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(716, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Attributi
            // 
            this.Attributi.BackColor = System.Drawing.Color.Transparent;
            this.Attributi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attributo1,
            this.Attributo2,
            this.Attributo3,
            this.Attributo4,
            this.Attributo5});
            this.Attributi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Attributi.Name = "Attributi";
            this.Attributi.Size = new System.Drawing.Size(63, 20);
            this.Attributi.Text = "Attributi";
            // 
            // attributo1
            // 
            this.attributo1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.attributo1.Name = "attributo1";
            this.attributo1.Size = new System.Drawing.Size(100, 23);
            // 
            // Attributo2
            // 
            this.Attributo2.Name = "Attributo2";
            this.Attributo2.Size = new System.Drawing.Size(100, 23);
            // 
            // Attributo3
            // 
            this.Attributo3.Name = "Attributo3";
            this.Attributo3.Size = new System.Drawing.Size(100, 23);
            // 
            // Attributo4
            // 
            this.Attributo4.Name = "Attributo4";
            this.Attributo4.Size = new System.Drawing.Size(100, 23);
            // 
            // Attributo5
            // 
            this.Attributo5.Name = "Attributo5";
            this.Attributo5.Size = new System.Drawing.Size(100, 23);
            // 
            // tipo1
            // 
            this.tipo1.Location = new System.Drawing.Point(483, 244);
            this.tipo1.Name = "tipo1";
            this.tipo1.Size = new System.Drawing.Size(152, 20);
            this.tipo1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo dell\'albero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome degli attributi Case Sensitive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vertici di esempio: v1, v2, v1023, etc...";
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 519);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipo1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.end_Vertex);
            this.Controls.Add(this.init_Vertex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Engine";
            this.Text = "Engine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox init_Vertex;
        private System.Windows.Forms.TextBox end_Vertex;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Attributi;
        private System.Windows.Forms.ToolStripTextBox attributo1;
        private System.Windows.Forms.ToolStripTextBox Attributo2;
        private System.Windows.Forms.ToolStripTextBox Attributo3;
        private System.Windows.Forms.ToolStripTextBox Attributo4;
        private System.Windows.Forms.ToolStripTextBox Attributo5;
        private System.Windows.Forms.TextBox tipo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}