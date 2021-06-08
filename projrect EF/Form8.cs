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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession3 = new project_1_linqEntities7();
            var st = (from d in premession3.stores select new { d, Name = d.name, id = d.id}).ToList();
            comboBox1.DataSource = st;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            //tostore
            var t = (from z in premession3.stores select new { z, Name =z.name, id =z.id}).ToList();
            comboBox2.DataSource = t;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";
           
            var it = (from d in premession3.item1 select new { d, Name = d.name, id = d.id }).ToList();
            comboBox3.DataSource = it;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "id";
            
            var s = (from d in premession3.suppliers select new { d, Name = d.name, id = d.id}).ToList();
            comboBox4.DataSource = s;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            project_1_linqEntities7 premession3 = new project_1_linqEntities7();
            var i = premession3.item1.Where(x => x.name == comboBox3.Text).First();
            // type tp = new type();
            // int id, sid,spid;
            int tostore, itemid, supid;
            itemid = Convert.ToInt32(i.id);
            var s = premession3.stores.Where(x => x.name == comboBox2.Text).First();
            tostore = s.id;
            item1 t = (from f in premession3.item1
                      where f.id == itemid.ToString()
                      select f).First();
            t.store_id = tostore;
            var sp = premession3.suppliers.Where(x => x.name == comboBox4.Text).First();
            supid = sp.id;

            Random rd = new Random();
            premession3.supply_premision.Add(new supply_premision
            {
                premmission_no = rd.Next(200,500),
                premmision_date = DateTime.Today,
                store_id = tostore,
                item_id = itemid.ToString(),
                quantity = Convert.ToInt32(textBox1.Text),
                supplier_id = supid,
                production_date = Convert.ToDateTime(textBox2.Text),
                expire_date = Convert.ToDateTime(textBox3.Text)

            });
            premession3.SaveChanges();
            MessageBox.Show("Transformation is done succesfully");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
        }
    }
}
     