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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        EgitimKampi_Financial_CRM_dbEntities db = new EgitimKampi_Financial_CRM_dbEntities();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtname.Text;
                string password = txtpass.Text;
                List<Admin> admins = db.Admins.Where(x => x.username == username && x.password == password).ToList();
                if (admins.Count != 1)
                {
                    MessageBox.Show("invalid username or password"); return;
                }
                else
                {

                    FrmDashboard frmDashboard = new FrmDashboard();
                    frmDashboard.Show(); this.Hide();
                }
            }
            catch (Exception ex) {
            MessageBox.Show("Error" + ex.Message);
                this.Show();
            }

        }
    }
}
