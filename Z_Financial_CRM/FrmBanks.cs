using System;
using System.Linq;
using System.Windows.Forms;
using Z_Financial_CRM.Models;

namespace Z_Financial_CRM
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        EgitimKampi_Financial_CRM_dbEntities dbEntities =
            new EgitimKampi_Financial_CRM_dbEntities();

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraat = dbEntities.Banks.Where(x => x.BankName == "Ziraat").Select(y => y.BankBalance).FirstOrDefault();
            lblZiraat.Text =ziraat.ToString() + " ₺";
            var vakif = dbEntities.Banks.Where(x => x.BankName == "Vakif").Select(y => y.BankBalance).FirstOrDefault();
            lblVakif.Text= vakif.ToString()+ " ₺";
            var akbank = dbEntities.Banks.Where(x => x.BankName == "Akbank").Select(y => y.BankBalance).FirstOrDefault();
            lblAkbank.Text= akbank.ToString() + " ₺";

            var transaction1 = dbEntities.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault(); 
            txtTrans1.Text = transaction1.Description + " | " +transaction1.ProcessType+ " | " + transaction1.Amount + " ₺ | "+transaction1.ProcessDate ;

            var transaction2 = dbEntities.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            txtTrans2.Text = transaction2.Description + " | " + transaction2.ProcessType + " | " + transaction2.Amount + " ₺ | " + transaction2.ProcessDate;

            var transaction3 = dbEntities.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            txtTran3.Text = transaction3.Description + " | " + transaction3.ProcessType + " | " + transaction3.Amount + " ₺ | " + transaction3.ProcessDate;

            var transaction4 = dbEntities.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            txtTran4.Text = transaction4.Description + " | " + transaction4.ProcessType + " | " + transaction4.Amount + " ₺ | " + transaction4.ProcessDate;


            var transaction5 = dbEntities.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            txtTran5.Text = transaction5.Description + " | " + transaction5.ProcessType + " | " + transaction5.Amount + " ₺ | " + transaction5.ProcessDate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
