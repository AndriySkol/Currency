using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Settings
    {
        static private Settings ptr = new Settings();
        static public WindowsFormsApplication1.Settings SettingObj
        {
            get { return ptr; }
        }
        private string xmlAdress;
        public string XmlAdress
        {
            get { return xmlAdress; }
        }
        private bool shouldLoad;
        public bool ShouldLoad
        {
            get { return shouldLoad; }
        }
        private Settings()
        {
            if(System.IO.File.Exists("settings.txt"))
            {
	            System.IO.StreamReader file = new System.IO.StreamReader("settings.txt");
	            xmlAdress = file.ReadLine();
	            shouldLoad = Convert.ToBoolean(file.ReadLine());
            }
            else
            {
                MessageBox.Show("settings file not found");
                Environment.Exit(0);
            }
        }
        


      
      
    }
}
