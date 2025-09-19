using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z_Financial_CRM.Models;

namespace Z_Financial_CRM
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        EgitimKampi_Financial_CRM_dbEntities db = new EgitimKampi_Financial_CRM_dbEntities();

        void updateTABLE()
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }
        private void button1_Click(object sender, EventArgs e)
        {
         updateTABLE();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {updateTABLE();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtAmount.Text);
            string period = txtPeriod.Text;
           
            db.Bills.Add(new Bill { BillTitle = title, BillAmount = amount, BillPeriod = period });
            db.SaveChanges();
            updateTABLE();

            MessageBox.Show("bill added sucessfully");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Bill b =db.Bills.Find(id);
            b.BillPeriod = txtPeriod.Text;
            b.BillAmount = decimal.Parse(txtAmount.Text);
            b.BillTitle = txtTitle.Text;
            db.SaveChanges();
            updateTABLE();
            MessageBox.Show("bill updated sucessfully");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Bill b = db.Bills.Find(id);
            db.Bills.Remove(b);
            db.SaveChanges();
            updateTABLE();
            MessageBox.Show("bill deleted sucessfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
