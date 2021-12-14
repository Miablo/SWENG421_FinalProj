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
        void ReadLock();
        void WriteLock();
        void Done();
    }
}
