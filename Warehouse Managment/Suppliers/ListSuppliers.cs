using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Suppliers
{
    public partial class ListSuppliers : Form
    {
        int id;
        WarehouseEntities db = new WarehouseEntities();

        public ListSuppliers()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.suppliers.ToList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            var Supp = db.suppliers.SingleOrDefault(X => X.Sup_Id == id);
            Supp.Sup_Name = textBox1.Text;
            Supp.Sup_phone = int.Parse(textBox2.Text);
            Supp.Sup_Mobile = int.Parse(textBox3.Text);
            Supp.Sup_Fax = int.Parse(textBox4.Text);
            Supp.Sup_Email = textBox5.Text;
            Supp.Sup_Website = textBox6.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.suppliers.ToList();
            MessageBox.Show("Supplier updated");
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var result = db.suppliers.Find(id);
            db.suppliers.Remove(result);
            db.SaveChanges();
            dataGridView1.DataSource = db.suppliers.ToList();
            MessageBox.Show("deleted");
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
