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
        private WAD wad;
        private int depth;
        Stream wadFile;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream wacFile = null;
            if (wad != null)
                wad.Close();
            wad = null;
            wadFile = null;
            OpenFileDialog ofd1 = new OpenFileDialog();

            ofd1.Filter = "WAC Files (.WAC)|*.WAC";
            ofd1.FilterIndex = 1;

            ofd1.Multiselect = false;


            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                wacFile = ofd1.OpenFile();
                String fn = ofd1.FileName;
                wadFile = File.Open(Path.GetDirectoryName(fn) + "\\FILESYS.WAD", FileMode.Open);
                wad = new WAD(wadFile);
                initTreeView(wacFile);
            }
        }

        private void initTreeView(Stream stream)
        {
            
            WAC.FOLDER root;
            wac = new WAC(stream);
            
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            root = wac.GetRoot();
            TreeNode node = new TreeNode(root.fileName);
            treeView1.Nodes.Add(AddFolderChildren(root));

            treeView1.EndUpdate();
            wac.Close();
        }

        private TreeNode AddFolderChildren(WAC.FOLDER folderInfo)
        {
            TreeNode dirNode = new TreeNode(folderInfo.fileName);
            foreach (WAC.FOLDER folder in wac.GetFolders(folderInfo))
            {
                TreeNode foldernode = AddFolderChildren(folder);
                foldernode.Tag = folder;
                dirNode.Nodes.Add(foldernode);
            }
            foreach (WAC.FILE file in wac.GetFiles(folderInfo))
            {
                TreeNode filenode = new TreeNode(file.fileName);
                filenode.Tag = file;
                dirNode.Nodes.Add(filenode);
            }
            
            return dirNode;
        }


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.Text.Contains("\\"))
            {
                WAC.FILE test = (WAC.FILE)e.Node.Tag;
                String path = Path.GetDirectoryName(e.Node.FullPath);
                // this needs to be fixed
                // will add an option to save to a particular directory
                //System.IO.Directory.CreateDirectory(path);
                byte[] buf = wad.GetFileFromOfs(test.offset, test.size);
                Stream outFile = File.Open(test.fileName, FileMode.Create);
                outFile.Write(buf, 0, (int)test.size);
                outFile.Close();                
            }
            return;
        }

    
        
        
    }
}
