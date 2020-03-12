using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2Stima
{
    public partial class Form1 : Form
    {
        public int hu = 0;
        int checkHari;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hu = 1;
            string text;
            text = textBox1.Text;
            int checkHari = int.Parse(text);
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            GraphCity Graf = new GraphCity();
            Graf.inputFromFile();
            Graf.algortimaBFS(checkHari);
            viewer.Graph = Graf.guiGraph;
            panel1.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(viewer);
            panel1.ResumeLayout();
            int count = 0;
            panel2.Controls.Clear();
            foreach (KeyValuePair<string, string> cek in Graf.jalurInfek.Values)
            {
                string val = cek.Value;
                string kal = cek.Key + "=>" + val;
                set_label(kal, count);
                count += 20;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                GraphCity Graf = new GraphCity();
                Graf.inputFromFile();
                Graf.algortimaBFS(checkHari);
                viewer.Graph = Graf.guiGraph;
                panel1.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(viewer);
                panel1.ResumeLayout();

            

            // Adding this control to the form 
        }
        private void set_label(string namaLabel, int koordinat)
        {
            Label mylab = new Label();
            mylab.Text = namaLabel;
            mylab.Location = new Point(30,20+koordinat);
            mylab.AutoSize = true;
            mylab.Font = new Font("Calibri", 10);
            mylab.ForeColor = Color.Green;
            mylab.Padding = new Padding(6);
            panel2.Controls.Add(mylab);

        }
        public void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
