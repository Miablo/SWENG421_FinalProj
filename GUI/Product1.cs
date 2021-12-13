using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Product1 : InventoryIF
    {
        //Attributes that will be seen on the inventory list:
        public String name;
        public int id;
        public int count;//how many of the product are in stock
        public String[] location;//the warehouse location(s) where the product can be found

        public void SetCount(int c)
        {
            count = c;
        }

        public void Add()//add the product to the inventory list
        {
            throw new NotImplementedException();
        }

        public void Use()//update the product in the inventory list
        {
            throw new NotImplementedException();
        }
    }
}
