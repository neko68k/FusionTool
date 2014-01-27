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

namespace FusionTool
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream WAC = null;
            OpenFileDialog ofd1 = new OpenFileDialog();

            ofd1.Filter = "WAC Files (.WAC)|*.WAC";
            ofd1.FilterIndex = 1;

            ofd1.Multiselect = false;


            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                WAC = ofd1.OpenFile();
                initTreeView(WAC);
            }
        }

        private void initTreeView(Stream stream)
        {
            WAC wac = new WAC(stream);
            // read root entry from WAC and use its folderCount as a limiter 
            
            treeView1.BeginUpdate();
        }
    }
}
