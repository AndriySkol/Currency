using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Settings
    {
        static private Settings ptr = new Settings();
        private string xmlAdress;
        private bool shouldLoad;
        private Settings()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\Test\\settings.txt");
            xmlAdress = file.ReadLine();
            shouldLoad = Convert.ToBoolean(file.ReadLine());
        }
        static public Settings getObj() {return ptr;}
        public string getXmlAdress() { return xmlAdress; }
        public bool getShouldLoad() { return shouldLoad; }

        

    }
}
