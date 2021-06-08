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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession1 = new project_1_linqEntities7();
            var obj = (from d in premession1.stores select new { d, name = d.name, id = d.id }).ToList();
            comboBox1.DataSource = obj;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            project_1_linqEntities7 premession3 = new project_1_linqEntities7();
            dataGridView1.DataSource = (from em in premession3.stores
                                        where em.name == comboBox1.Text
                                        select new { em.id, em.name, em.address, em.admin }).ToList();

            
        }
    }
}
