using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Factory : FactoryIF
    {
        // NOTE: current code is based on M5.1 Factory Method (Implementation)
        HashMap<String, String> hm = new HashMap<>( );     // hm is a HashMap

        public Factory() {
            // add <key, value> pair data, saved in file or storage, to the HashMap.
            File f = new File(fn);          // fn represents file name.
            BufferedReader br = new BufferedReader(FileReader(f));
            String text = br.readLine( );
            while (text != null){
                String[ ] sa = text.split(“,”);
                hm.put(sa[0], sa[1]);    // sa[0] is key and sa[1] is value.
                text = br.readLine( );
            }
        }

        public InventoryIF createProduct(string pro)
        {
            //throw new NotImplementedException();
            String value = hm.get(pro);
            Class c = Class.forName(value);     
            return (InventoryIF) c.newInstance( );
        }
    }
}
