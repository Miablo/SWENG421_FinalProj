using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    interface VanInventoryIF
    {
        void SetCount(int c);
        void stock();
        void take();
    }
}
