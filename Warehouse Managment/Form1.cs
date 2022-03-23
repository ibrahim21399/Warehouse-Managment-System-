using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Managment
{
    public partial class Form1 : Form
    {
        WarehouseEntities db = new WarehouseEntities();
        string s,m;
        public Form1()
        {
            InitializeComponent();
            var stores = from d in db.Warehouses
                         select d.Warhouse_Name;
            foreach (var dd in stores)
            {
                checkedListBox1.Items.Add(dd);
                checkedListBox2.Items.Add(dd);
                comboBox1.Items.Add(dd);
            }
            var Products = from d in db.Products
                           select d.prod_Name;
            foreach (var dd in Products)
            {
                comboBox3.Items.Add(dd);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.productDurationTableAdapter.Fill(this.WarehouseDataSet6.productDuration);
            this.reportViewer4.RefreshReport();
         
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.warehouseDetailsTableAdapter1.Fill(this.warehouseDataSet9.WarehouseDetails,comboBox1.SelectedItem.ToString(), dateTimePicker1.Value, dateTimePicker2.Value);



            this.reportViewer1.RefreshReport();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            List<string> strs = new List<string>();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                //if (i == checkedListBox1.CheckedItems.Count-1)
                //{ 
                //string m = checkedListBox1.CheckedItems[i].ToString();
                
                strs.Add(checkedListBox1.CheckedItems[i].ToString());
                //}
                //else
                //{
                //    strs.Add(checkedListBox1.CheckedItems[i].ToString() + ",");
                //}                
          
                
            }

            s = string.Join(",",strs);

            this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1,dateTimePicker4.Value.ToString(), dateTimePicker3.Value.ToString(), comboBox3.SelectedItem.ToString(), s);


            this.reportViewer2.RefreshReport();


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.expiredTableAdapter.Fill(this.WarehouseDataSet7.expired,int.Parse(textBox1.Text));
            this.reportViewer5.RefreshReport();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            List<string> strs = new List<string>();
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {


                strs.Add(checkedListBox2.CheckedItems[i].ToString());


            }

            m = string.Join(",", strs);
            this.DataTable5TableAdapter.Fill(this.DataSet4.DataTable5, m);

            this.reportViewer3.RefreshReport();
        }
    }
}
