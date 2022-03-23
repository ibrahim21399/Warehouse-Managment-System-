using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Warehousess
{
    public partial class ListWarehouses : Form
    {
        int id;
        WarehouseEntities db = new WarehouseEntities();

        public ListWarehouses()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.showstoresss().ToList();
            

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {

                var warhouses = db.Warehouses.SingleOrDefault(X => X.Warhouse_Id == id);
                warhouses.Warhouse_Name = textBox3.Text;
                warhouses.Warhouse_Address = textBox4.Text;
                warhouses.Warhouse_Managers = textBox5.Text;
                db.SaveChanges();
                dataGridView1.DataSource = db.showstoresss().ToList();
                MessageBox.Show("store updated");
            }
            else
            {

                MessageBox.Show("select store from table");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                var result = db.Warehouses.Find(id);
                db.Warehouses.Remove(result);
                db.SaveChanges();
                dataGridView1.DataSource = db.showstoresss().ToList();
                MessageBox.Show("deleted");

            }
            else
            {
                MessageBox.Show("select store from table");
            }



        }


    }
}
