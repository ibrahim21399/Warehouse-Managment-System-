using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Customers
{
    

    public partial class ListCustomers : Form
    {
        int id;
        WarehouseEntities db = new WarehouseEntities();
        public ListCustomers()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Customers.ToList();

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            var Cus = db.Customers.SingleOrDefault(X => X.Cus_Id == id);
            Cus.Cus_Name = textBox1.Text;
            Cus.Cus_phone = int.Parse(textBox2.Text);
            Cus.cus_Mobile = int.Parse(textBox3.Text);
            Cus.Cus_Fax = int.Parse(textBox4.Text);
            Cus.Cus_Email = textBox5.Text;
            Cus.cus_Website = textBox6.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.Customers.ToList();
            MessageBox.Show("Customer updated");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var result = db.Customers.Find(id);
            db.Customers.Remove(result);
            db.SaveChanges();
            dataGridView1.DataSource = db.Customers.ToList();
            MessageBox.Show("deleted");
        }
    }
}
