using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public interface SourceIF
    {
        string[] GetData();
        string[] readLock();
        void saveLock(string[] str);
    }
}
