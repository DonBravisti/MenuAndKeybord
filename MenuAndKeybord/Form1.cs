using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAndKeybord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelCentral.BackColor = colorDialog1.Color;
            }            
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(panelCentral.BackColor.ToString());
                file.Close();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter file = new StreamWriter("setting.dat");
            file.WriteLine(panelCentral.BackColor.ToString());
            file.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("setting.dat");
            panelCentral.BackColor = Color.FromArgb(Convert.ToInt32(file.ReadLine()));
            file.Close();
        }
    }
}
