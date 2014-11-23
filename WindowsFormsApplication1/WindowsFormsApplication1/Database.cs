using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using EntityFramework.BulkInsert.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Threading;


namespace WindowsFormsApplication1
{
    class Database:IObservable
    {
        bool isReady = false;
        public currencyEntities DataBaseRef { get; set; }

        public bool IsReady
        {
            get { return isReady; }
        }
        static public Database Data { get; set; }

        protected List<currencies> currencies = new List<currencies>();
        protected List<Names> names = new List<Names>();
        List<IObserver> observers = new List<IObserver>();
        public List<Names> Names
        {
            get { return names; }
            set { names = value; }
        }
        public List<currencies> Currencies
        {
            get { return currencies; }
            set { currencies = value;
            
            }
        }
        static Database()
        {
            Data = new Database();
            
        }
        Database()
        {
            DataBaseRef = new currencyEntities();

            CurrencyDatabase dat = new CurrencyDatabase();

            if (Settings.SettingObj.ShouldLoad)
            {
                LoadFromXml(Settings.SettingObj.XmlAdress);
            }
            Thread load = new Thread(delegate()
            {
                currencyEntities newData = new currencyEntities();

                List<Names> tempNames = newData.Names.ToList();

                lock (names)
                {
                    Names = tempNames;
                }
                
                List<currencies> currenciesTemp = newData.currencies.ToList();
                lock(currencies)
                {
                    Currencies = currenciesTemp;
                }
                
                isReady = true;
                NotifyMessengers();

            });
            load.Name = "Loading";
            load.IsBackground = true;
            load.Start();
           
            
        }
        void LoadFromXml(string path)
        {

           var doc = XDocument.Load(path);
           CurrencyDatabase dat = new CurrencyDatabase();

           HashSet<string> names = new HashSet<string>();
      
           foreach (var el in doc.Descendants("Rate"))
           {
               if (el.Element("Currency") != null && el.Element("Currency").Value != "")
               {
                   names.Add(el.Element("Currency").Value);
                   
               }
           }

           var i = (DataBaseRef.Names.Select(b=>b.ID)).ToArray().LastOrDefault() + 1;

           foreach(var el in names)
           {
               if(el != null)
                 dat.addRecord(new Currency(el) { ID = i });
                 ++i;
           }

           
            i = 0;
          
            foreach (var el in doc.Descendants("Rate"))
            {
                if (el.Element("Currency") != null && (el.Ancestors("Rates") != null && el.Ancestors("Rates").First().Element("DateTime") != null)
                    && (el.Element("Change") != null) && el.Element("ChangePercent") != null
                    && el.Element("IsChangeDown") != null && el.Element("Value") != null && el.Element("Currency").Value != "")
                {
                    var comp = el.Element("Currency").Value;
                    XElement el2 = (el.Ancestors("Rates")).First().Element("DateTime");
                    Currency c = new Currency(comp);
                    c.AddComponent(new CurrencyData
                    {
                        Change = float.Parse(el.Element("Change").Value, System.Globalization.CultureInfo.InvariantCulture),
                        ChangePercent = float.Parse(el.Element("ChangePercent").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Date = Convert.ToDateTime(el2.Value),
                        IsChangeDown = Convert.ToInt32(Convert.ToBoolean(el.Element("IsChangeDown").Value)),
                        Value = float.Parse(el.Element("Value").Value, System.Globalization.CultureInfo.InvariantCulture)
                    });
                    dat.addRecord(c);
                    i++;
                    if (i == -1)
                        break;
                }
            }
            
            List<currencies> check1 = new List<currencies>();
            List<Names> check2 = new List<Names>();
            dat.CopyTo(check1, check2);
            DataBaseRef.BulkInsert(check2);
            DataBaseRef.BulkInsert(check1);

        }

        public void Subscribe(IObserver observ)
        {
            observers.Add(observ);
            
        }

        public void Unscribe(IObserver observ)
        {
            observers.Remove(observ);
        }

        public void NotifyMessengers()
        {
            foreach(var x in observers)
            {
                x.UpdatedObservable();
            }
        }
       
    }
}
