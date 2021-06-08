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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            project_1_linqEntities7 additem = new project_1_linqEntities7();
            try
            {
                additem.item1.Add(new item1 { id = (textBox1.Text), name = textBox2.Text, measure_unit = textBox3.Text ,quantity=0});
                additem.SaveChanges();
                MessageBox.Show("successfully add");
                textBox1.Text = textBox2.Text = textBox3.Text= string.Empty;
            }
            catch(Exception)
            {
                MessageBox.Show("cannot add with this id");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                project_1_linqEntities7 updateitem = new project_1_linqEntities7();
                string id = textBox1.Text;
         
                item1 update = (from d in updateitem.item1 where d.id==id select d).First();
                update.name = textBox2.Text;
                update.measure_unit = textBox3.Text;
                

                updateitem.SaveChanges();
                MessageBox.Show("update successfully");
                textBox1.Text = textBox2.Text = textBox3.Text= string.Empty;
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
