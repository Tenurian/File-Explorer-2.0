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

namespace FIleExplorerWF
{
    public partial class FileExplorer : Form
    {
        Button btnSearch;
        TextBox txtDirectory;
        TreeView trvDirectories;
        public FileExplorer()
        {
            InitializeComponent();
            txtDirectory = textBox1;
            trvDirectories = treeView1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(txtDirectory.Text);
            TreeNode t = trvDirectories.Nodes.Add(d.FullName, d.Name);
            Dig(d, t);
        }


        private void Dig(DirectoryInfo dir, TreeNode parent)
        {
            foreach (DirectoryInfo item in dir.EnumerateDirectories())
            {
                TreeNode t = parent.Nodes.Add(item.FullName, item.Name);
                Dig(item, t);
            }
        }

    }

}
