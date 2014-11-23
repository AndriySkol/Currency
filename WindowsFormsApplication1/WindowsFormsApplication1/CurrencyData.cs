using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
   
    public interface IComponent
    {
        void AddComponent(IComponent comp);
     
      
        string GetStringValue();
        void Accept(IVisitor visit);
    }
    public class CurrencyDatabase
    {
        Dictionary<string, IComponent> childs = new Dictionary<string, IComponent>();
        public void addRecord(IComponent comp)
        {
            if (childs.ContainsKey(comp.GetStringValue()) == true)
            {
                childs[comp.GetStringValue()].AddComponent(comp);
            }
            else
            {
                childs.Add(comp.GetStringValue(), comp);
            }
        }
       
        public void CopyTo(List<currencies> listOfCur, List<Names> listOfNames)
        {
            CopyToVisitor visit = new CopyToVisitor(listOfCur, listOfNames);
            foreach (var x in childs)
            {
                x.Value.Accept(visit);
            }
        }


    }
    public class Currency:IComponent
    {
        public List<IComponent> childs = new List<IComponent>();
        public string Name { get; set; }
        public int ID { get; set; }

        public Currency(string _name = "")
        {
            Name = _name;
        }
        public void AddComponent(IComponent comp)
        {
            if (comp is Currency && comp.GetStringValue().Equals(GetStringValue()))
            {
                Merge((Currency)comp);
            }
            else
            {
                childs.Add(comp);
            }
        }
        public void Merge(Currency c)
        {
            foreach(var x in c.childs)
            {
                childs.Add(x);
            }
        }

       

        public string GetStringValue()
        {
            return Name;
        }

        public void Accept(IVisitor visit)
        {
            visit.Accept(this);
        }




   


      
    }
    public class CurrencyData:IComponent
    {
        
        public Nullable<double> Value { get; set; }
        public Nullable<double> Change { get; set; }
        public Nullable<double> ChangePercent { get; set; }
        public Nullable<int> IsChangeDown { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

     
        public void AddComponent(IComponent comp)
        {
            throw new NotImplementedException();
        }

       

        public string GetStringValue()
        {
            return Convert.ToString(Date);
        }


        
        public void Accept(IVisitor visit)
        {
            visit.Accept(this);
        }
    }

}
