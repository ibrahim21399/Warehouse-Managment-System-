using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Permissions
{
    public partial class SupplyPermission : Form
    {
        WarehouseEntities db;
        int x;
        int id;
        int pid;
        public bool TextWasChanged = false;
        int counter =0;


        public SupplyPermission()
        {
            InitializeComponent();
            
            db = new WarehouseEntities();
            var perno = (from d in db.SupPermissions select d.prem_Num);
            if (perno.Count() > 0)
            {
                int h = perno.Count() + 1;
                textBox1.Text = h.ToString();
            }
            else
            {
                textBox1.Text = "1";
            }

            var stores = from d in db.Warehouses
                      select d.Warhouse_Name;
            foreach (var dd in stores)
            {
                comboBox1.Items.Add(dd);
            }
            var Products = from d in db.Products
                         select d.prod_Name;
            foreach (var dd in Products)
            {
                comboBox2.Items.Add(dd);
            }
            var sup = from d in db.suppliers
                           select d.Sup_Name;
            foreach (var dd in sup)
            {
                comboBox3.Items.Add(dd);
            }


            var storess = from d in db.Warehouses
                         select d.Warhouse_Name;
            foreach (var dd in stores)
            {
                comboBox6.Items.Add(dd);
            }
            var Productss = from d in db.Products
                           select d.prod_Name;
            foreach (var dd in Products)
            {
                comboBox5.Items.Add(dd);
            }
            var supp = from d in db.suppliers
                      select d.Sup_Name;
            foreach (var dd in sup)
            {
                comboBox4.Items.Add(dd);
            }
            dataGridView1.DataSource = db.Show_Sup_Permission().ToList();

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
            counter++;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            if(textBox1.Text==string.Empty)
            {
                MessageBox.Show("Please fill date");
            }
            else
            {
                int p = int.Parse(textBox1.Text);
                var permNo = (from d in db.SupPermissions
                              where d.prem_Num == p
                              select d.prem_Num);
                if (permNo.Count() > 0)
                {
                    foreach (var dd in permNo)
                    {
                        x = dd;
                    }
                }




                if (int.Parse(textBox1.Text) == x)
                {
                    Sup_Requst_Detailes newproduct = new Sup_Requst_Detailes();
                    newproduct.perem_Num = int.Parse(textBox1.Text);
                    var wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox1.SelectedItem.ToString() select d.Warhouse_Id);
                    foreach (var dd in wid)
                    {
                        newproduct.War_Id = dd;
                    }
                    newproduct.IQuntity = int.Parse(textBox6.Text);
                    newproduct.production_Date = dateTimePicker3.Value;
                    newproduct.Expire = dateTimePicker4.Value;
                    var Pid = (from d in db.Products where d.prod_Name == comboBox2.SelectedItem.ToString() select d.prod_Id);
                    foreach (var dd in Pid)
                    {
                        newproduct.Prod_Id = dd;
                    }
                    product_Store ps = new product_Store();
                    ps.prd_Id = newproduct.Prod_Id;
                    ps.War_Id = newproduct.War_Id;
                    ps.Quantity = newproduct.IQuntity;
                    db.Sup_Requst_Detailes.Add(newproduct);
                    db.product_Store.Add(ps);
                    db.SaveChanges();
                    MessageBox.Show("per aDded first item added");
                    dataGridView1.DataSource = db.Show_Sup_Permission().ToList();

                }
                else
                {
                    SupPermission perm = new SupPermission();
                    perm.prem_Num = int.Parse(textBox1.Text);
                    perm.Prem_Date = dateTimePicker2.Value;
                    var supid = (from d in db.suppliers where d.Sup_Name == comboBox3.SelectedItem.ToString() select d.Sup_Id);
                    foreach (var dd in supid)
                    {
                        perm.Sup_Id = dd;
                    }
                    Sup_Requst_Detailes newproduct = new Sup_Requst_Detailes();
                    newproduct.perem_Num = int.Parse(textBox1.Text);
                    var wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox1.SelectedItem.ToString() select d.Warhouse_Id);
                    foreach (var dd in wid)
                    {
                        newproduct.War_Id = dd;
                    }
                    newproduct.IQuntity = int.Parse(textBox6.Text);
                    newproduct.production_Date = dateTimePicker3.Value;
                    newproduct.Expire = dateTimePicker4.Value;
                    var Pid = (from d in db.Products where d.prod_Name == comboBox2.SelectedItem.ToString() select d.prod_Id);
                    foreach (var dd in Pid)
                    {
                        newproduct.Prod_Id = dd;
                    }
                    product_Store ps = new product_Store();
                    ps.prd_Id = newproduct.Prod_Id;
                    ps.War_Id = newproduct.War_Id;
                    ps.Quantity = newproduct.IQuntity;
                    db.SupPermissions.Add(perm);
                    db.Sup_Requst_Detailes.Add(newproduct);
                    db.product_Store.Add(ps);
                    db.SaveChanges();
                    MessageBox.Show("per aDded first item added");
                    dataGridView1.DataSource = db.Show_Sup_Permission().ToList();
                }

            }
               
            //if (TextWasChanged==true)//first Time
            //{


            //}
            //else if(TextWasChanged==true &&counter==2)
            //{
            //    Sup_Requst_Detailes newproduct = new Sup_Requst_Detailes();
            //    newproduct.perem_Num = int.Parse(textBox1.Text);
            //    var wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox1.SelectedItem.ToString() select d.Warhouse_Id);
            //    foreach (var dd in wid)
            //    {
            //        newproduct.War_Id = dd;
            //    }
            //    newproduct.IQuntity = int.Parse(textBox6.Text);
            //    newproduct.production_Date = dateTimePicker3.Value;
            //    newproduct.Expire = dateTimePicker4.Value;
            //    var Pid = (from d in db.Products where d.prod_Name == comboBox2.SelectedItem.ToString() select d.prod_Id);
            //    MessageBox.Show(comboBox2.SelectedItem.ToString());
            //    foreach (var dd in Pid)
            //    {
            //        newproduct.Prod_Id = dd;
            //        MessageBox.Show(dd.ToString());
            //    }
            //    db.Sup_Requst_Detailes.Add(newproduct);
            //    db.SaveChanges();
            //    MessageBox.Show("product added");
            //    dataGridView1.DataSource = db.Show_Sup_Permission().ToList();
            //}








        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string s = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //pid = (from d in db.Products where d.prod_Name == s select d.prod_Id).First();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var sup = db.SupPermissions.SingleOrDefault(X => X.prem_Num == id);
            sup.supplier.Sup_Name = comboBox4.SelectedItem.ToString();
            sup.Prem_Date =dateTimePicker7.Value;
            var supp = db.Sup_Requst_Detailes.SingleOrDefault(X => X.perem_Num == id);
            supp.IQuntity = int.Parse(textBox2.Text);
            supp.Product.prod_Name = comboBox5.SelectedItem.ToString();
            supp.Warehouse.Warhouse_Name = comboBox6.SelectedItem.ToString();
            supp.production_Date = dateTimePicker6.Value;
            supp.Expire = dateTimePicker5.Value;
            db.SaveChanges();
            dataGridView1.DataSource = db.Show_Sup_Permission().ToList();
            MessageBox.Show("permission updated");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var result = db.Sup_Requst_Detailes.Find(id);
            db.Sup_Requst_Detailes.Remove(result);
            db.SaveChanges();
            var result2 = db.SupPermissions.Find(id);
            db.SupPermissions.Remove(result2);
            db.SaveChanges();

            dataGridView1.DataSource = db.Show_Sup_Permission().ToList();
            MessageBox.Show("deleted");
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
