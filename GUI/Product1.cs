using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Product1 : InventoryIF
    {
        public int count;

        public void SetCount(int c)
        {
            count = c;
        }
        public void Add()
        {
            count++;
        }

        public void Use()
        {
            if(count != 0)
            count--;
        }
    }
}
