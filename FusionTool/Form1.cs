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
        
        TextBox textBox1;
        PictureBox picBox1;
        
        public Form1()
        {
            InitializeComponent();
            textBox1 = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream wacFile = null;
            
            OpenFileDialog ofd1 = new OpenFileDialog();

            ofd1.Filter = "WAC Files (.WAC)|*.WAC";
            ofd1.FilterIndex = 1;

            ofd1.Multiselect = false;


            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                wacFile = ofd1.OpenFile();
                String fn = ofd1.FileName;
                
                initTreeView(wacFile, fn);
            }
        }

        private void initTreeView(Stream stream, String fn)
        {
            
            WAC.FOLDER root;
            wac = new WAC(stream, fn);
            
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            root = wac.GetRoot();
            TreeNode node = new TreeNode(root.fileName);
            treeView1.Nodes.Add(AddFolderChildren(root));

            treeView1.EndUpdate();
            //wac.Close();
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

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                contextMenuStrip1.Items.Clear(); 
                AddMenuItem(contextMenuStrip1, "Extract", e.Node.Tag);
                contextMenuStrip1.Show(treeView1, e.Location);
               

            }
        }

        private ToolStripMenuItem AddMenuItem(ContextMenuStrip cm, String text, Object tag)
        {
           
            ToolStripMenuItem tsi = new ToolStripMenuItem();
            
            tsi.Tag = tag;
            tsi.Text = text;
            cm.Items.Add(tsi);
            
            
            return( tsi );
        }

        private void WriteExtract(WAC.FILE test)
        {

            byte[] buf = wac.ExtractFile(test);
            Stream outFile = File.Open(test.fileName, FileMode.Create);
            outFile.Write(buf, 0, (int)test.size);
            outFile.Close();
        }
        

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            if (!e.Node.Text.Contains("\\"))
            {
                WAC.FILE test = (WAC.FILE)e.Node.Tag;
                
                String path = Path.GetDirectoryName(e.Node.FullPath);
                // this needs to be fixed
                // will add an option to save to a particular directory
                //System.IO.Directory.CreateDirectory(path);
                   


                // handle opening files and dynamically adding a widget to the right half of the splitview
                // to support said file
                if (e.Node.Text.Contains("INI") || e.Node.Text.Contains("BAT") || e.Node.Text.Contains("TXT"))
                {

                    Panel rightPanel = splitContainer1.Panel2;

                    if (textBox1 == null)
                        textBox1 = new TextBox();
                    //rightPanel.Controls.Remove(textBox1);                        
                    
                    //textBox1.Text = "test";
                    textBox1.Dock = DockStyle.Fill;
                    textBox1.Multiline = true;
                    byte[] buf = wac.ExtractFile(test);
                    textBox1.Text = System.Text.Encoding.UTF8.GetString(buf);
                    textBox1.ScrollBars = ScrollBars.Both;
                    rightPanel.Controls.Add(textBox1);
                    
                    
                }
                else if (e.Node.Text.Contains("MUN"))
                {
                    MemoryStream imgStream = null;
                    // read data
                    // deswizzle
                    // MemoryStream imgStream = new MemoryStream(deswizData);
                    //Image.FromStream(imgStream);
                    //picBox1 = new PictureBox();
                    //picBox1.Dock = DockStyle.Fill;
                    //MUN mun = new MUN();
                }
                else if (e.Node.Text.Contains("TRI"))
                {
                    // load and parse vertex data
                    // instance an opengl widget and do all the magic
                    // will want some rotation etc interface for this
                }
            }
            return;
        }

        private void testToolStripMenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            WAC.FILE file = (WAC.FILE)clickedItem.Tag;
            WriteExtract(file);
        }


       

 



    
        
        
    }
}
