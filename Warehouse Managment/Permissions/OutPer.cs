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
        int newQ;
        bool check;
        string s;
        public OutPer()
        {
            InitializeComponent();
                

            db = new WarehouseEntities();
            var perno = (from d in db.CusPermissions select d.prem_Num);
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
                        MessageBox.Show("First item added");
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
                    string selectedproduct = comboBox2.SelectedItem.ToString();
                    var it = (from d in db.product_Store where d.Product.prod_Name == selectedproduct select d);
                    if (it.Count() > 0)
                    {
                        check = true;
                    }

                    var sup = db.product_Store.SingleOrDefault(X => X.prd_Id == newproduct.Prod_Id && X.War_Id == newproduct.War_Id);
                    if (check == true&&sup !=null)
                    {
                        if (sup.Quantity >= newproduct.OQuntity)
                        {
                            newQ = (int)(sup.Quantity - newproduct.OQuntity);
                            sup.Quantity = newQ;
                            db.CusPermissions.Add(perm);
                            db.Cus_Requst_Detailes.Add(newproduct);
                            db.SaveChanges();
                            MessageBox.Show(" item added");
                            dataGridView1.DataSource = db.Show_Cus_Permission().ToList();
                        }
                        else
                        {
                            MessageBox.Show("store has only " + sup.Quantity.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("product isn't avilable Now");
                    }


                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var sup = db.CusPermissions.SingleOrDefault(X => X.prem_Num == id);
            sup.Customer.Cus_Name = comboBox4.SelectedItem.ToString();
            sup.Prem_Date = dateTimePicker7.Value;
            var supp = db.Cus_Requst_Detailes.SingleOrDefault(X => X.perem_Num == id && X.Product.prod_Name == s);
            supp.OQuntity = int.Parse(textBox2.Text);
            supp.Product.prod_Name = textBox4.Text;
            supp.Warehouse.Warhouse_Name = comboBox6.SelectedItem.ToString();
            db.SaveChanges();
            dataGridView1.DataSource = db.Show_Cus_Permission().ToList();
            MessageBox.Show("permission updated");
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            s = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //dateTimePicker6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //dateTimePicker5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //pid = (from d in db.Products where d.prod_Name == s select d.prod_Id).First();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
