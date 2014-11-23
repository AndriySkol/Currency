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
    public partial class Main : Form
    {
        public Main()
        {
            Database.Equals(null, null);
            InitializeComponent();

        }

        private void databaseTable_Click(object sender, EventArgs e)
        {
            databasetable = new DatabaseTable();
            databasetable.Show();
        }

        private void Chosen_Click(object sender, EventArgs e)
        {
            chart = new Graph();
            chart.Show();
        }
    }
}
