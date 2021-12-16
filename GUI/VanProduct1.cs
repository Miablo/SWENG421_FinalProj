using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class VanProduct1 : Product1, VanInventoryIF
    {
        public Product1 vp1;
        public int count;

        public void SetCount(int c)
        {
            count = c;
        }

        public void stock()
        {
            if (count == 0)
            {

            }
            else
            {
                count--;
                //vp1.Add();
            }

        }

        public void take()
        {
            count++;
           // vp1.Use();
        }
    }
}
