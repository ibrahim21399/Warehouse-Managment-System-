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
    public partial class transfer : Form
    {
        int quentity;
        int quentity2;
        string productname;


        WarehouseEntities db = new WarehouseEntities();
        public transfer()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.show_productsStoresQuentity().ToList();
            var stores = from d in db.Warehouses
                          select d.Warhouse_Name;
            foreach (var dd in stores)
            {
                comboBox1.Items.Add(dd);
                comboBox2.Items.Add(dd);
            }
            var Products = from d in db.Products
                           select d.prod_Name;
            foreach (var dd in Products)
            {
                comboBox3.Items.Add(dd);
            }
            var sup = from d in db.suppliers
                      select d.Sup_Name;
            foreach (var dd in sup)
            {
                comboBox4.Items.Add(dd);
            }

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int QQ = int.Parse(textBox1.Text);
            int pidh = (from d in db.Products where d.prod_Name == comboBox3.SelectedItem.ToString() select d.prod_Id).First();
            var items = (from d in db.Sup_Requst_Detailes
                         join m in db.SupPermissions on d.perem_Num equals m.prem_Num
                         where d.Prod_Id==pidh  /*&& d.production_Date == dateTimePicker1.Value*/
                         //  && m.supplier.Sup_Name == comboBox4.SelectedItem.ToString()
                         //where d.Warehouse.Warhouse_Name == comboBox1.SelectedItem.ToString()
                         select d);
            
            foreach (var dd in items)
            {
                if (dd.Product.prod_Name == comboBox3.SelectedItem.ToString())
                {
                     productname = dd.Product.prod_Name;
                    
                }
            }
            MessageBox.Show(productname);
            if (productname== comboBox3.SelectedItem.ToString())
            {

                var qresult = (from d in db.product_Store
                               where d.Product.prod_Name == comboBox3.SelectedItem.ToString()
                               && d.Warehouse.Warhouse_Name == comboBox1.SelectedItem.ToString()
                               select d.Quantity);
                if (qresult.Count() > 0)
                {
                    foreach (var dd in qresult)
                    {
                        quentity = dd.Value;
                        MessageBox.Show(quentity.ToString());
                    }
                }

                var qresult2 = (from d in db.product_Store
                               where d.Product.prod_Name == comboBox3.SelectedItem.ToString()
                               && d.Warehouse.Warhouse_Name == comboBox2.SelectedItem.ToString()
                               select d.Quantity);
                if (qresult2.Count() > 0)
                {
                    foreach (var dd in qresult2)
                    {
                        quentity2 = dd.Value;
                        MessageBox.Show(quentity2.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("please fill data");
                }

                if (quentity == int.Parse(textBox1.Text))
                {
                    int pqid = (from d in db.product_Store where d.Product.prod_Name == comboBox3.SelectedItem.ToString()
                                && d.Warehouse.Warhouse_Name == comboBox1.SelectedItem.ToString()
                                select d.ps_Id).First();


                       var edit= db.product_Store.SingleOrDefault(X => X.Warehouse.Warhouse_Name == comboBox2.SelectedItem.ToString()&&X.Product.prod_Name==comboBox3.SelectedItem.ToString());
                    if (edit == null)
                    {
                        int wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox2.SelectedItem.ToString() select d.Warhouse_Id).First();
                        int pid = (from d in db.Products where d.prod_Name == comboBox3.SelectedItem.ToString() select d.prod_Id).First();
                        product_Store ps = new product_Store();
                        ps.prd_Id = pid;
                        ps.War_Id = wid;
                        ps.Quantity = QQ;
                        db.product_Store.Add(ps);

                    }
                    else
                    {
                          edit.Quantity = quentity2 + QQ;
                         
                    }
                    var r = db.product_Store.Find(pqid);
                    db.product_Store.Remove(r);

                    db.SaveChanges();
                        dataGridView1.DataSource = db.show_productsStoresQuentity().ToList();
                        MessageBox.Show("product transfered successful");
                  
                    

                }
                else if (quentity > int.Parse(textBox1.Text))
                {
                    var edit2 = db.product_Store.SingleOrDefault(X => X.Warehouse.Warhouse_Name == comboBox1.SelectedItem.ToString() && X.Product.prod_Name == comboBox3.SelectedItem.ToString());
                    edit2.Quantity = quentity - QQ;

                    var edit = db.product_Store.SingleOrDefault(X=>X.Warehouse.Warhouse_Name==comboBox2.SelectedItem.ToString()&& X.Product.prod_Name==comboBox3.SelectedItem.ToString());
                    if (edit == null)
                    {
                        int wid = (from d in db.Warehouses where d.Warhouse_Name == comboBox2.SelectedItem.ToString() select d.Warhouse_Id).First();
                        int pid = (from d in db.Products where d.prod_Name == comboBox3.SelectedItem.ToString() select d.prod_Id).First();
                            
                        product_Store ps = new product_Store();
                        ps.prd_Id = pid; 
                        ps.War_Id = wid;
                        ps.Quantity = QQ;
                        db.product_Store.Add(ps);

                    }
                    else
                    {
                        edit.Quantity = quentity2 + QQ;
                    }

                    db.SaveChanges();
                    MessageBox.Show("product transfered successful");
                   


                    
                    dataGridView1.DataSource = db.show_productsStoresQuentity().ToList();

                }
                else if (quentity < int.Parse(textBox1.Text))
                {
                    MessageBox.Show("the avaliable qutity is" + quentity);
                }

             }
            else
            {
                MessageBox.Show("product not found in this store");
            }
            product_Movement pm = new product_Movement();
            pm.Warhouse_from = comboBox1.SelectedItem.ToString();
            pm.Warhouse_To = comboBox2.SelectedItem.ToString();
            pm.productname = comboBox3.SelectedItem.ToString();
            pm.transferQuntity = int.Parse(textBox1.Text);
            pm.productiondate = dateTimePicker2.Value;
            pm.supplier = comboBox4.SelectedItem.ToString();
            pm.dateoftransfer = DateTime.Now;
            db.product_Movement.Add(pm);
            db.SaveChanges();

           
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
