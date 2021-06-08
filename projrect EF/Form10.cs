using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projrect_EF
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
          

            project_1_linqEntities7 premession3 = new project_1_linqEntities7();
            var Items = (from d in premession3.item1 select new { d, Name = d.name, id = d.id }).ToList();
            comboBox1.DataSource = Items;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession3 = new project_1_linqEntities7();
            var it = Convert.ToDateTime(comboBox1.Text);
            var date = premession3.supply_premision.Where(d => d.premmision_date == it).First();
            int item = Convert.ToInt32(date.item_id);
            dataGridView1.DataSource = (from em in premession3.item1 where em.id == item.ToString()
                                        select new { em.name, em.measure_unit, em.quantity, em.store_id }).ToList();
                                         
        }
    }
}
