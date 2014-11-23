using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IVisitor
    {

        void Accept(Currency obj);
        void Accept(CurrencyData obj);
        

    }
    class CopyToVisitor:IVisitor
    {
        List<currencies> listOfCur {get; set;}
        List<Names> listOfNames {get; set;}
        public CopyToVisitor( List<currencies> listOfCurIn, List<Names> listOfNamesIn)
        {
            listOfCur = listOfCurIn;
            listOfNames = listOfNamesIn;
        }
        public void Accept(Currency obj)
        {
            listOfNames.Add(new Names { ID = obj.ID, name = obj.Name });
            foreach(var i in obj.childs)
            {
                i.Accept(this);  
            }
        }

        public void Accept(CurrencyData obj)
        {
            listOfCur.Add(new currencies
            {
                Name = listOfNames.Last().ID,
                Value = obj.Value,
                IsChangeDown = obj.IsChangeDown,
                Change = obj.Change,
                ChangePercent = obj.ChangePercent,
                Date = obj.Date
            });
        }
    }
}
