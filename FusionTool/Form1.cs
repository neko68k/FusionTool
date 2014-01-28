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

        private  WAC wac;
        private int depth;
        
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
            
            WAC.FOLDER root;
            WAC.FOLDER currentFolder;
            WAC.FOLDER[] folderChildren;
            depth = -1;
            wac = new WAC(stream);
            
            // read root entry from WAC and use its folderCount as a limiter 
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            root = wac.GetRoot();
            TreeNode node = new TreeNode(root.fileName);
            //node.Tag = root;
            //treeView1.Nodes.Add(node);
            //currentFolder = root;
           
            treeView1.Nodes.Add(AddFolderChildren(root));
            
            //WAC.FOLDER[] test2 = wac.GetFolders(test[0]);
            //WAC.FILE[] test3 = wac.GetFiles(test2[0]);

            
            

            treeView1.EndUpdate();
        }

        private TreeNode AddFolderChildren(WAC.FOLDER folderInfo)
        {
            WAC.FILE[] fileChildren;
            TreeNode dirNode = new TreeNode(folderInfo.fileName);
            foreach (WAC.FOLDER folder in wac.GetFolders(folderInfo))
            {
                dirNode.Nodes.Add(AddFolderChildren(folder));
            }
            foreach (WAC.FILE file in wac.GetFiles(folderInfo))
            {
                dirNode.Nodes.Add(new TreeNode(file.fileName));
            }
            
            return dirNode;
        }
        
        
    }
}
