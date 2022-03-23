using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Managment.Products;
using Warehouse_Managment.Warehousess;
using Warehouse_Managment.Suppliers;
using Warehouse_Managment.Customers;
using Warehouse_Managment.Permissions;



namespace Warehouse_Managment
{
    public partial class Ware : Form
    {
        public Ware()
        {
            InitializeComponent();
        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void SuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProducts addprod = new AddProducts();
            addprod.Show();
        }


        private void AddWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWarehouse addware = new AddWarehouse();
            addware.Show();
        }


        private void EditProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList prodlist = new ProductList();
            prodlist.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProductList prodlist = new ProductList();
            prodlist.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ListWarehouses lstw = new ListWarehouses();
            lstw.Show();
        }

        private void EditWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListWarehouses lstw = new ListWarehouses();
            lstw.Show();
        }

        private void AddSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier ads = new AddSupplier();
            ads.Show();
        }

        private void EditSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListSuppliers ls = new ListSuppliers();
            ls.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ListSuppliers ls = new ListSuppliers();
            ls.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ListCustomers lc = new ListCustomers();
            lc.Show();
        }

        private void EditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCustomers lc = new ListCustomers();
            lc.Show();
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer Ac = new AddCustomer();
            Ac.Show();
        }

        private void SupplyPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplyPermission sp = new SupplyPermission();
            sp.Show();
        }

        private void WithdrawPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutPer op = new OutPer();
            op.Show();
        }

        private void TransferPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transfer t = new transfer();
            t.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SupplyPermission t = new SupplyPermission();
            t.Show();
        }

        private void WarhouseProductsQuntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productQuntity pQ = new productQuntity();
            pQ.Show();
        }
    }
}
