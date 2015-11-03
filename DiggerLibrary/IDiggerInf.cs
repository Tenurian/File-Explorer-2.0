using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiggerLibrary
{
    public interface IDiggerInf
    {
        void DirectoryFound(DirectoryInfo item);
    }
}
