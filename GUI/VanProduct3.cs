using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class VanProduct3 : Product3, VanInventoryIF
    {
        public Product3 vp3;
        public int count;

        public void SetCount(int c)
        {
            count = c;
        }

        public void stock()
        {
            vp3.Add();

        }

        public void take()
        {
            vp3.Use();
        }
    }
}
