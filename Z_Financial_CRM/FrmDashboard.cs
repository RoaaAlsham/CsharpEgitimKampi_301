using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z_Financial_CRM.Models;
namespace Z_Financial_CRM
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        static EgitimKampi_Financial_CRM_dbEntities db= new EgitimKampi_Financial_CRM_dbEntities();
        int  count1 = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            string balance = db.Banks.Sum(x => x.BankBalance).ToString();
            lblTotalBalance.Text = balance;
            //char1
         var bankData= db.Banks.Select(x=> new { x.BankName,x.BankBalance }).ToList();
            chartBanks.Series.Clear();
            chartBanks.Series.Add("Bank");
            foreach (var item in bankData) {

                chartBanks.Series["Bank"].Points.AddXY(item.BankName, item.BankBalance);
            }
            //chartBanks.Series["Bank"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            //char2
            var spendingData = db.Spendings.Select(x => new { x.SpendingTitle, x.SpendingAmount }).ToList();
            chart1.Series.Clear();
            chart1.Series.Add("Spending");
            foreach (var item in spendingData)
            {
                chart1.Series["Spending"].Points.AddXY(item.SpendingTitle, item.SpendingAmount);
                chart1.Series["Spending"].ChartType= System.Windows.Forms.DataVisualization.Charting.SeriesChartType.
                    Pie;
            }
        }


   
        private void timerBill_Tick(object sender, EventArgs e)
        {
            count1++;
          
            int billsCount = db.Bills.Count();
            List<Bill> bills = db.Bills.ToList();
            for (int i=0; i < billsCount; i++)
            {
                if (count1 == i * 4) {
                 lblBillAmount.Text = bills[i].BillAmount.ToString() ;
                    billTitle.Text= bills[i].BillTitle.ToString();
                }
                if(count1 == billsCount*4)
                {
                    count1 = 0;
                }
            }

        }
        int count2 = 0;
        private void timerSpending_Tick(object sender, EventArgs e)
        {
            count2++;
            int processCount = db.BankProcesses.Count();
            List<BankProcess> processes = db.BankProcesses.ToList();
            for (int i = 0; i< processCount; i++)
            {
               if(count2==i*4)
                {
                    lblSpendingAmount.Text = processes[i].Amount.ToString();
                    spendingTitle.Text = processes[i].Description;
                    lblProcessType.Text = processes[i].ProcessType;
                }
                if (count2 == processCount * 4)
                {
                    count2 = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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
 