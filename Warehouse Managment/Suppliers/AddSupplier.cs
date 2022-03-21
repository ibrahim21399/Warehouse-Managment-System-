using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment.Suppliers
{
    public partial class AddSupplier : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty | textBox2.Text == string.Empty | textBox3.Text == string.Empty)
            {
                MessageBox.Show("please fill Supplier Name");
            }
            else
            {
                supplier S = new supplier();
                S.Sup_Name = textBox1.Text;
                S.Sup_phone=int.Parse( textBox2.Text);
                S.Sup_Mobile = int.Parse(textBox3.Text);
                S.Sup_Fax = int.Parse(textBox4.Text);
                S.Sup_Email =textBox5.Text;
                S.Sup_Website = textBox6.Text;
                db.suppliers.Add(S);
                db.SaveChanges();
                MessageBox.Show("Supplier Added");
                textBox1.Text = textBox2.Text = textBox3.Text=textBox4.Text=textBox5.Text=textBox6.Text = string.Empty;
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
