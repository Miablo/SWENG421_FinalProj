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

        string[] temp = new string[50];

        public string[] GetInventory()
        {
           
            temp[0] = ("Product1,Warehouse," + p1.count + ",Van," + vp1.count);
            temp[1] = ("Product2,Warehouse," + p2.count + ",Van," + vp2.count);
            temp[2] = ("Product3,Warehouse," + p3.count + ",Van," + vp3.count);
            return temp;
        }
        
        public void ChangeCount(string pro, string loc, int count)
        {
            if(pro == "Product1")
            {
                if(loc == "Van")
                {
                    if(count == 1)
                    {
                        if (p1.count != 0)
                        vp1.take();
                        p1.Use();
                    }
                    else
                    {
                        if (vp1.count != 0)
                        {
                            vp1.stock();
                            p1.Add();
                        }
                    }
                }
                else if(loc == "Warehouse")
                {
                    if (count == 1)
                    {
                        p1.Add();
                    }
                    else
                    {
                        p1.Use();
                    }
                }
            }
            else if (pro == "Product2")
            {
                if (loc == "Van")
                {
                    if (count == 1)
                    {
                        if(p2.count != 0)
                        vp2.take();
                        p2.Use();
                    }
                    else
                    {
                        if (vp2.count != 0)
                        {
                            vp2.stock();
                            p2.Add();
                        }
                    }
                }
                else if (loc == "Warehouse")
                {
                    if (count == 1)
                    {
                        p2.Add();
                    }
                    else
                    {
                        p2.Use();
                    }
                }
            }
            else if (pro == "Product3")
            {
                if (loc == "Van")
                {
                    if (count == 1)
                    {
                        if(p3.count != 0)
                        vp3.take();
                        p3.Use();
                    }
                    else
                    {
                        if (vp3.count != 0)
                        {
                            vp3.stock();
                            p3.Add();
                        }
                    }
                }
                else if (loc == "Warehouse")
                {
                    if (count == 1)
                    {
                        p3.Add();
                    }
                    else
                    {
                        p3.Use();
                    }
                }
            }
        }

        public void SetCount(string[] list)
        {
            temp = list;
            foreach (string r in list)
            {
                if (r != null)
                {
                    string[] values = r.Split(',');
 
                        if(values[0] == "Product1")
                        {
                            p1.SetCount(int.Parse(values[2]));
                            vp1.SetCount(int.Parse(values[4]));
                        }
                        else if (values[0] == "Product2")
                        {
                            p2.SetCount(int.Parse(values[2]));
                            vp2.SetCount(int.Parse(values[4]));
                        }
                        else if (values[0] == "Product3")
                        {
                            p3.SetCount(int.Parse(values[2]));
                            vp3.SetCount(int.Parse(values[4]));
                        }
                }

            }
        }
    }
}
