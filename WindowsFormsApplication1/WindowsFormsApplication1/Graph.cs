using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Graph : Form, IObserver
    {
        DateTime x1 = new System.DateTime(2010, 5, 18, 0, 0, 0);
        DateTime x2 = new System.DateTime(2010, 5, 18, 23, 59, 59);
        public Graph()
        {
            
            InitializeComponent();
            if(Database.Data.IsReady)
            {
                labelDatabaseIsNtReady.Hide();
            }
            this.FormClosing += Graph_FormClosing;
            Database.Data.Subscribe(this);
            CreateBox();
            InitializeChart(comboBox1.Text, x1, x2);
            CreateTable(comboBox1.Text, x1, x2);
           
        }
        void Graph_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Database.Data.Unscribe(this);
        }
        void InitializeChart(string name, DateTime x1, DateTime x2)
        {
            
            if (Database.Data.IsReady)
            {
	            var query = (from x in Database.Data.Currencies
	                         where x.Names.name == name && x.Date >=  x1 && x.Date <= x2
	                         select new { x.Date, x.ChangePercent });
	            var j = query.Take(0).ToList();
	            var t = query.ToList();
                if (t.Count != 0)
                {
                    DateTime temp = t.First().Date.Value;
                    var cr = (t.Last().Date.Value - t.First().Date.Value).TotalHours / 100;
                    foreach (var l in t)
                    {

                        if ((l.Date.Value - temp).TotalHours >= cr)
                        {
                            j.Add(l);
                            temp = l.Date.Value;
                        }
                    }
                }
	            chart1.DataSource = j;
	            
	            
	           
	            
	            
	            label3.Update();
	            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd-MM-yyyy \n H:mm";
	            chart1.Series.First().XValueMember = "Date";
	            chart1.Series.First().YValueMembers = "ChangePercent";
	            chart1.DataBind();
	            chart1.Update();
            }


        }
        public void CreateTable(string name, DateTime x1, DateTime x2)
        {
            if (Database.Data.IsReady)
            {
	            mainTable.AutoGenerateColumns = true;
                int searchNameID = Database.Data.Names.Find(b => b.name == name).ID;
	            var querry = (from el in Database.Data.Currencies
	                         
	                          where el.Name == searchNameID  && el.Date >= x1 && el.Date <= x2
	                          select new
	                          {
	                              ID = el.ID,
                                  Name = Database.Data.Names.Where(b => b.ID == el.Name).Select(b => b.name).FirstOrDefault(),
	                              Value = el.Value,
	                              Change = el.Change,
	                              ChangePercent = el.ChangePercent,
	                              IsChangeDown = el.IsChangeDown,
	                              Date = el.Date
	                          });
	            double? sum = 0;
                var arr = querry.Take(3000).ToList();
                if (arr.Count != 0)
                {
                    sum = (arr.Last().Value / arr.First().Value - 1) * 100;
                }
	            label3.Text = Convert.ToString(sum);
	            mainTable.DataSource = arr;
	           
	            mainTable.Update();
            }
        }
        public void CreateBox()
        {
            var querry = (from x in Database.Data.DataBaseRef.Names
                          select x.name);

            comboBox1.DataSource = querry.ToList();
            comboBox1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBox1.Text;
                x1 = dateTimePicker1.Value.Date;
                x2 = dateTimePicker2.Value.Date;
                InitializeChart(name, x1, x2);
                CreateTable(name, x1, x2);

            }
            catch(Exception)
            {
                MessageBox.Show("something is wrong");
                return;
            }
        }

        public void UpdatedObservable()
        {
            Invoke((MethodInvoker)delegate
            {
                string name = comboBox1.Text;
                try
                {
                    x1 = dateTimePicker1.Value.Date;
                    x2 = dateTimePicker2.Value.Date;
                }
                catch(Exception)
                {
                }
                labelDatabaseIsNtReady.Hide();
                
                InitializeChart(name, x1, x2);
                CreateTable(name, x1, x2);
                Update();
               

            });
        }


    }
}
