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
    public partial class AddProducts : Form
    {

        WarehouseEntities db = new WarehouseEntities();
        public AddProducts()
        {
            InitializeComponent();
            

               
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)

        { 
            int hh = int.Parse(textBox1.Text);
            var pcode = (from d in db.Products where d.Prod_Code ==hh select d);

            if (textBox1.Text ==string.Empty | textBox2.Text == string.Empty | textBox3.Text ==string.Empty)
            {
                MessageBox.Show("please fill product Data");
            }
            else if(pcode.Count()>0)
            {
                MessageBox.Show("this code already taken by other product");
            }
            else
            {
               
                //Product p = new Product();
                //p.Prod_Code =int.Parse( textBox1.Text);
                //p.prod_Name = textBox2.Text;
                //Unit U1 = new Unit();
                //U1.prod_Id = p.prod_Id;
                //U1.Unit1 = textBox3.Text;
                //Unit U2 = new Unit();
                //U2.prod_Id = p.prod_Id;
                //U2.Unit1 = textBox4.Text;
                //db.Products.Add(p);
                //db.Units.Add(U1);
                //db.Units.Add(U2);
                //db.SaveChanges();
                db.Add_Prodect(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("product Added");
                textBox1.Text = textBox2.Text = textBox3.Text =textBox4.Text= string.Empty;

            }

        }
    }
}
