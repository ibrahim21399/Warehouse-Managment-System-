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
    public partial class productQuntity : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        public productQuntity()
        {
            InitializeComponent();
            var stores = from d in db.Warehouses
                         select d.Warhouse_Name;
            foreach (var dd in stores)
            {
                comboBox1.Items.Add(dd);
            }
            dataGridView1.DataSource = db.showstoreproductsAvaliablequantity2().ToList();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.showstoreproductsAvaliablequantity(comboBox1.SelectedItem.ToString()).ToList();
        }
    }
}
