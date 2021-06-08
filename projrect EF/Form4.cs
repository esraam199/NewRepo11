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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            project_1_linqEntities7 addsupplier = new project_1_linqEntities7();
            try
            {
                addsupplier.suppliers.Add(new supplier { id = int.Parse(textBox1.Text), name = textBox2.Text, phonne = (textBox3.Text), fax = textBox4.Text, mobile = (textBox5.Text), email = textBox6.Text, website = textBox7.Text });
                addsupplier.SaveChanges();
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
                project_1_linqEntities7 updatesupplier = new project_1_linqEntities7();
                int id = int.Parse(textBox1.Text);

                supplier update = (from d in updatesupplier.suppliers where d.id == id select d).First();
                update.name = textBox2.Text;
                update.phonne = (textBox3.Text);
                update.fax = textBox4.Text;
                update.mobile = (textBox5.Text);
                update.email = textBox6.Text;
                update.website = textBox7.Text;
                updatesupplier.SaveChanges();
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
