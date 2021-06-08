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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            project_1_linqEntities7 addcustomer = new project_1_linqEntities7();
            try
            {
                addcustomer.customers.Add(new customer { id = int.Parse(textBox1.Text), name = textBox2.Text, phone = (textBox3.Text), fax = textBox4.Text, mobile = textBox5.Text, email = textBox6.Text, website = textBox7.Text });
                addcustomer.SaveChanges();
                MessageBox.Show("successfully add");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot add with this id");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 updatecustomer = new project_1_linqEntities7();
                int id = int.Parse(textBox1.Text);

                customer update = (from d in updatecustomer.customers where d.id == id select d).First();
                update.name = textBox2.Text;
                update.phone = (textBox3.Text);
                update.fax = textBox4.Text;
                update.mobile = textBox5.Text;
                update.email = textBox6.Text;
                update.website = textBox7.Text;
                updatecustomer.SaveChanges();
                MessageBox.Show("update successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch (Exception)
            {

                MessageBox.Show("cannot update with this id");
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
