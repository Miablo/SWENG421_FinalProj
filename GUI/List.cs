using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class List
    {
        private VanProduct1 vp1 = new VanProduct1();
        private VanProduct2 vp2 = new VanProduct2();
        private VanProduct3 vp3 = new VanProduct3();
        private Product1 p1 = new Product1();
        private Product2 p2 = new Product2();
        private Product3 p3 = new Product3();

        public string[] GetInventory()
        {

            string[] temp = new string[50];
            return temp;
        }

        public void SetCount(string[] list)
        {
            foreach (string r in list)
            {
                if (r != null)
                {
                    string[] values = r.Split(',');
 
                        if(values[0] == "Product1")
                        {

                        }
                        else if (values[0] == "Product2")
                        {

                        }
                        else if (values[0] == "Product3")
                        {

                        }
                        else if (values[0] == "VanProduct1")
                        {
                            vp1.SetCount(int.Parse(values[1]));
                        }
                        else if (values[0] == "VanProduct2")
                        {
                            vp2.SetCount(int.Parse(values[1]));
                        }
                        else if (values[0] == "VanProduct3")
                        {
                            vp3.SetCount(int.Parse(values[1]));
                        }
                }

            }
        }
    }
}
