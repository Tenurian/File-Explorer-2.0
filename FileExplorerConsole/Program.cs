using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiggerLibrary;

namespace FileExplorerConsole
{
    class FileExplorerConsole : IDiggerInf
    {
        Dictionary<String, int> spacers = new Dictionary<String, int>();
        static void Main(string[] args)
        {
            FileExplorerConsole FEC = new FileExplorerConsole();
        }

        public FileExplorerConsole()
        {
            //String foldername = @"C:\Users\Tenurian\Tester";
            String foldername = @"C:\Users\Tenurian\Documents\Visual Studio 2015\Projects\FileExplorerConsole";
            Digger digger = new Digger();
            spacers.Add(foldername, 1);
            DirectoryFound(new DirectoryInfo(foldername)); //this is here to ensure the top folder appears
            digger.Dig(new DirectoryInfo(foldername), this);
            Console.ReadLine();
        }

        public void DirectoryFound(DirectoryInfo item)
        {
            int spaces;
            if (spacers.ContainsKey(item.Parent.FullName))
            {
                spaces = spacers[item.Parent.FullName];
            }
            else
            {
                spaces = 0;
            }
            SizeGetter sg = new SizeGetter();
            Console.WriteLine((new String(' ', (spaces + 1)*2)) + item.Name +" ("+(int)sg.GetDirectorySize(item.FullName) / 1000+"K)");
            if (!spacers.ContainsKey(item.FullName))
            {
                spacers.Add(item.FullName, spaces + 1);
            }
        }

    }

}
