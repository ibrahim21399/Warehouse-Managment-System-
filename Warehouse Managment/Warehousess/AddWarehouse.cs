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
    public partial class AddWarehouse : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        public AddWarehouse()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty | textBox2.Text == string.Empty | textBox3.Text == string.Empty)
            {
                MessageBox.Show("please fill Warehouse Data");
            }
            else
            {
                Warehouse w = new Warehouse();
                w.Warhouse_Name = textBox1.Text;
                w.Warhouse_Address = textBox2.Text;
                w.Warhouse_Managers = textBox3.Text;
                db.Warehouses.Add(w);
                db.SaveChanges();
                MessageBox.Show("Store Added");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            }
        }
    }
}
