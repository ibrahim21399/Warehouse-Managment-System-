using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Customers
{
    public partial class AddCustomer : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        public AddCustomer()
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
                MessageBox.Show("please fill Customer Name");
            }
            else
            {
                Customer S = new Customer();
                S.Cus_Name = textBox1.Text;
                S.Cus_phone = int.Parse(textBox2.Text);
                S.cus_Mobile = int.Parse(textBox3.Text);
                S.Cus_Fax = int.Parse(textBox4.Text);
                S.Cus_Email = textBox5.Text;
                S.cus_Website = textBox6.Text;
                db.Customers.Add(S);
                db.SaveChanges();
                MessageBox.Show("Customer Added");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
            }
        }
    }
}
