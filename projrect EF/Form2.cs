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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        


        

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 addstore = new project_1_linqEntities7();
                addstore.stores.Add(new store { id = int.Parse(textBox1.Text), name = textBox2.Text, address = textBox3.Text, admin = textBox4.Text });
                addstore.SaveChanges();
                MessageBox.Show("successfully add");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot add with this id");
            }
        }

        //update store
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 updatestore = new project_1_linqEntities7();
                int id = int.Parse(textBox1.Text);
                
                store update = (from d in updatestore.stores where d.id == id select d).First();
                update.name = textBox2.Text;
                update.address = textBox3.Text;
                update.admin = textBox4.Text;
                updatestore.SaveChanges();
                MessageBox.Show("update successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot update with this id");
            }

        }

        private void cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
