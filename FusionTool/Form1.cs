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
            UInt32 depth = 1;
            WAC.FOLDER root;
            WAC.FOLDER[] folderChildren;
            WAC.FILE[] fileChildren;
            WAC wac = new WAC(stream);
            
            // read root entry from WAC and use its folderCount as a limiter 
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            root = wac.GetRoot();
            TreeNode node = new TreeNode(wac.GetName(root));
            node.Tag = root;
            treeView1.Nodes.Add(node);


            while (depth >= 1)
            {
                
            }

            treeView1.EndUpdate();
        }
    }
}
