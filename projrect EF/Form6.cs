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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form6_Load(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession1 = new project_1_linqEntities7();
            var obj = (from d in premession1.stores select new { d, name = d.name, id = d.id }).ToList();
            comboBox1.DataSource = obj;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

            var Items = (from d in premession1.item1 select new { d, Name = d.name, id = d.id }).ToList();
            comboBox2.DataSource = Items;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";

            var supplier = (from d in premession1.suppliers select new { d, Name = d.name, id = d.id }).ToList();
            comboBox3.DataSource = supplier;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "id";




        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 premession1 = new project_1_linqEntities7();
                supply_premision premision = new supply_premision();
                premision.premmission_no = int.Parse(textBox4.Text);
                premision.premmision_date = Convert.ToDateTime(textBox1.Text);
                premision.item_id = (comboBox3.SelectedValue.ToString());
                premision.quantity = int.Parse(textBox2.Text);
                premision.store_id = int.Parse(comboBox1.SelectedValue.ToString());
                premision.production_date = Convert.ToDateTime(textBox3.Text);
                premision.expire_date = Convert.ToDateTime(textBox5.Text);
                premision.supplier_id = int.Parse(comboBox2.SelectedValue.ToString());
                premession1.supply_premision.Add(premision);

                item1 it = new item1();
                it.quantity = it.quantity + int.Parse(textBox2.Text);
                var v = premession1.SaveChanges();
                MessageBox.Show("New Supply Permission is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

            }
            catch (Exception)
            {
                MessageBox.Show("cannot add with this id");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 premession1 = new project_1_linqEntities7();

                //EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                int text = int.Parse(textBox4.Text);
                supply_premision s = (from d in premession1.supply_premision
                                      where d.premmission_no == text
                                      select d).First();
                s.premmision_date = Convert.ToDateTime(textBox1.Text);
                s.supplier_id = int.Parse(comboBox1.SelectedValue.ToString());
                s.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                s.item_id = comboBox3.SelectedValue.ToString();
                s.quantity = int.Parse(textBox2.Text);
                s.production_date = Convert.ToDateTime(textBox3.Text);
                s.expire_date = Convert.ToDateTime(textBox5.Text);

                premession1.SaveChanges();
                MessageBox.Show(" Update succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

            }

            catch (Exception)
            {
                MessageBox.Show("cannot add with this id");
            }





        }
    }
}