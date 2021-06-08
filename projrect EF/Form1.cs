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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void store_Click(object sender, EventArgs e)
        {
            Form2 store = new Form2();
            store.ShowDialog();
        }

        private void item_Click(object sender, EventArgs e)
        {
            Form3 store = new Form3();
            store.ShowDialog();
        }

        private void supplier_Click(object sender, EventArgs e)
        {
            Form4 store = new Form4();
            store.ShowDialog();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            Form5 store = new Form5();
            store.ShowDialog();
        }

        private void supplypremession_Click(object sender, EventArgs e)
        {
            Form6 store = new Form6();
            store.ShowDialog();
        }

        private void sellpremession_Click(object sender, EventArgs e)
        {
            Form7 store = new Form7();
            store.ShowDialog();
        }

        private void convert_item_Click(object sender, EventArgs e)
        {
            Form8 store = new Form8();
            store.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 store = new Form9();
            store.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 store = new Form10();
            store.ShowDialog();
        }
    }
}
