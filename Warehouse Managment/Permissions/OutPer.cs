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
    public partial class OutPer : Form
    {
        WarehouseEntities db;
        int x;
        int id;
        int pid;
        int newQ;
        public OutPer()
        {
            InitializeComponent();

            db = new WarehouseEntities();
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
            var sup = from d in db.Customers
                      select d.Cus_Name;
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
            var supp = from d in db.Customers
                       select d.Cus_Name;
            foreach (var dd in sup)
            {
                comboBox4.Items.Add(dd);
            }
            dataGridView1.DataSource = db.Show_Cus_Permission().ToList();

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please fill date");
            }
            else
            {
                int p = int.Parse(textBox1.Text);
                var permNo = (from d in db.CusPermissions
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
                    Cus_Requst_Detailes newproduct = new Cus_Requst_Detailes();
                    newproduct.perem_Num = int.Parse(textBox1.Text);
                    var wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox1.SelectedItem.ToString() select d.Warhouse_Id);
                    foreach (var dd in wid)
                    {
                        newproduct.War_Id = dd;
                    }
                    newproduct.OQuntity = int.Parse(textBox6.Text);
                    var Pid = (from d in db.Products where d.prod_Name == comboBox2.SelectedItem.ToString() select d.prod_Id);
                    foreach (var dd in Pid)
                    {
                        newproduct.Prod_Id = dd;
                    }
                    var sup = db.product_Store.SingleOrDefault(X => X.prd_Id == newproduct.Prod_Id && X.War_Id == newproduct.War_Id);
                    if (sup.Quantity >= newproduct.OQuntity)
                    {
                        newQ =(int)(sup.Quantity - newproduct.OQuntity);
                        sup.Quantity = newQ;
                        db.Cus_Requst_Detailes.Add(newproduct);
                        db.SaveChanges();
                        MessageBox.Show("per aDded first item added");
                        dataGridView1.DataSource = db.Show_Cus_Permission().ToList();
                    }
                    else
                    {
                        MessageBox.Show("store has only " + sup.Quantity.ToString());
                    }


                }
                else
                {
                    CusPermission perm = new CusPermission();
                    perm.prem_Num = int.Parse(textBox1.Text);
                    perm.Prem_Date = dateTimePicker2.Value;
                    var supid = (from d in db.Customers where d.Cus_Name == comboBox3.SelectedItem.ToString() select d.Cus_Id);
                    foreach (var dd in supid)
                    {
                        perm.Cus_Id = dd;
                    }
                    Cus_Requst_Detailes newproduct = new Cus_Requst_Detailes();
                    newproduct.perem_Num = int.Parse(textBox1.Text);
                    var wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox1.SelectedItem.ToString() select d.Warhouse_Id);
                    foreach (var dd in wid)
                    {
                        newproduct.War_Id = dd;
                    }
                    newproduct.OQuntity = int.Parse(textBox6.Text);
                    var Pid = (from d in db.Products where d.prod_Name == comboBox2.SelectedItem.ToString() select d.prod_Id);
                    foreach (var dd in Pid)
                    {
                        newproduct.Prod_Id = dd;
                    }
                    var sup = db.product_Store.SingleOrDefault(X => X.prd_Id == newproduct.Prod_Id && X.War_Id == newproduct.War_Id);
                    if (sup.Quantity >= newproduct.OQuntity)
                    {
                        newQ = (int)(sup.Quantity - newproduct.OQuntity);
                        sup.Quantity = newQ;
                        db.CusPermissions.Add(perm);
                        db.Cus_Requst_Detailes.Add(newproduct);
                        db.SaveChanges();
                        MessageBox.Show("per added first item added");
                        dataGridView1.DataSource = db.Show_Cus_Permission().ToList();
                    }
                    else
                    {
                        MessageBox.Show("store has only " + sup.Quantity.ToString());
                    }

                }
            }
        }
    }
}
