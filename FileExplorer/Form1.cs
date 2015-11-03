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
using DiggerLibrary;


namespace FileExplorer
{
    public partial class FileExplorer : Form, IDiggerInf
    {
        public FileExplorer()
        {
            InitializeComponent();
            txtDirectory.Text = @"C:\Users\Tenurian\Tester";
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(txtDirectory.Text);
            SizeGetter sg1 = new SizeGetter();
            TreeNode t = trvDirectories.Nodes.Add(d.FullName, d.Name + " (" + (int)sg1.GetDirectorySize(d.FullName) / 1000 + "K)");
            Digger digger = new Digger();
            digger.Dig(d, this);
        }

        public void DirectoryFound(DirectoryInfo item)
        {
            TreeNode[] foundnodes = trvDirectories.Nodes.Find(item.Parent.FullName, true);
            SizeGetter sg = new SizeGetter();
            if (foundnodes.Length == 1)
            {
                foundnodes[0].Nodes.Add(item.FullName, item.Name + " (" + (int)sg.GetDirectorySize(item.FullName) / 1000 + "K)");
            }
            else
            {
                trvDirectories.Nodes.Add(item.FullName, item.Name + " (" + (int)sg.GetDirectorySize(item.FullName) / 1000 + "K)");
            }
        }
    }
}
