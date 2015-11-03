using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiggerLibrary
{
    public class Digger
    {
        public Digger()
        {

        }

        public void Dig(DirectoryInfo dir, IDiggerInf inf)
        {
            foreach (DirectoryInfo item in dir.EnumerateDirectories())
            {
                //TreeNode t = parent.Nodes.Add(item.FullName, item.Name);
                inf.DirectoryFound(item);
                Dig(item, inf);
            }
        }
    }
}
