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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession2 = new project_1_linqEntities7();
            sell_premission sell = new sell_premission();
            sell.premission_no = int.Parse(textBox1.Text.ToString());
            sell.premmision_date = Convert.ToDateTime(textBox2.Text);
            sell.customer_id =int.Parse(comboBox1.SelectedValue.ToString());
            sell.store_id = int.Parse(comboBox2.SelectedValue.ToString());
            sell.item_id = comboBox3.SelectedValue.ToString();
            sell.quantity = int.Parse(textBox3.Text);
            premession2.sell_premission.Add(sell);
            item1 it = new item1();
            it.quantity = it.quantity - int.Parse(textBox3.Text);
           
            premession2.SaveChanges();
            var v = premession2.SaveChanges();
            MessageBox.Show("New OutGoing Permission is Added Successfully");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession2 = new project_1_linqEntities7();

           
            //customer
            var cl = (from d in premession2.customers select new { d, Name = d.name, id = d.id}).ToList();
            comboBox1.DataSource = cl;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            //store
            var st = (from d in premession2.stores select new { d, Name = d.name, id = d.id}).ToList();
            comboBox2.DataSource = st;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";
            //item
            var tp = (from d in premession2.item1 select new { d, Name = d.name, id = d.id}).ToList();
            comboBox3.DataSource = tp;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "id";



        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 premession2 = new project_1_linqEntities7();
                int op_N = int.Parse(textBox1.Text);
                sell_premission sp = (from d in premession2.sell_premission
                                      where d.premission_no == op_N
                                      select d).First();
                sp.premmision_date = Convert.ToDateTime(textBox2.Text);
                sp.customer_id = int.Parse(comboBox1.SelectedValue.ToString());
                sp.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                sp.item_id = comboBox3.SelectedValue.ToString();
                sp.quantity = int.Parse(textBox3.Text);

                premession2.SaveChanges();
                MessageBox.Show("OutGoing Permission Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            }

            catch (Exception)
            {
                MessageBox.Show("cannot add with this id");
            }


        }

        //cancle
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
