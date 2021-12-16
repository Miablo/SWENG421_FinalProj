using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class VanProduct2 : Product2, VanInventoryIF
    {
        public Product2 vp2;
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
                //vp2.Add();
            }

        }

        public void take()
        {
            count++;
            //vp2.Use();
        }
    }
}
