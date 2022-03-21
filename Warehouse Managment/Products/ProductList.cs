using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Products
{
    public partial class ProductList : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        int id;
        public ProductList()
        {
            InitializeComponent();
            dataGridView1.DataSource= db.show_Products().ToList();
        }
        //public void LoadData()
        //{
        //    this.show_ProductsTableAdapter.Fill(this.warehouseDataSet1.show_Products);
        //}

        private void ProductList_Load(object sender, EventArgs e)
        {
            //LoadData();
        }



        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string[] Units = dataGridView1.CurrentRow.Cells[3].Value.ToString().Split(new[] { ", " }, StringSplitOptions.None);
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = Units[0];
            textBox6.Text = Units[1];
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            List<int> aa = new List<int>();

            var units = (from d in db.Units
                         where d.prod_Id == id
                         select d.Unit_Id);
            var products = db.Products.SingleOrDefault(X => X.prod_Id == id);

            //var units = db.Units.(X => X.prod_Id == id);
            products.Prod_Code = int.Parse( textBox3.Text);
            products.prod_Name = textBox4.Text;
            foreach (var items in units)
            {
                aa.Add(items);

            }
            int a = aa[0];
            int b = aa[1];
            var unit1=db.Units.SingleOrDefault(X => X.Unit_Id == a);
            var unit2=db.Units.SingleOrDefault(X => X.Unit_Id == b);
            unit1.Unit1= textBox5.Text;
            unit2.Unit1 = textBox6.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.show_Products().ToList();
            //try
            //{
            //    this.Validate();
            //    this.showProductsBindingSource.EndEdit();
            //    this.show_ProductsTableAdapter.ClearBeforeFill(this.warehouseDataSet1.show_Products);
            //    MessageBox.Show("Update successful");
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("Update failed");
            //}




        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var result = db.Products.Find(id);
            db.Products.Remove(result);
            db.SaveChanges();
            dataGridView1.DataSource = db.show_Products().ToList();
            MessageBox.Show("deleted");
        }
    }
}
