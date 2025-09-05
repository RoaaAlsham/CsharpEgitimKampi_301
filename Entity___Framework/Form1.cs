using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity___Framework
{
    public partial class Form1 : Form
    {
        EgitimKampi_EntityFramework_dbEntities1 db = new EgitimKampi_EntityFramework_dbEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName= txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Guide has been added");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
           
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Guide guide = db.Guides.Find(id);
            db.Guides.Remove(guide);
            db.SaveChanges();
            MessageBox.Show("Guide has been deleted");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Guide g = db.Guides.Find(id);
            g.GuideName = txtName.Text;
            g.GuideSurname= txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Guide has been updated", "info", MessageBoxButtons.OK ,MessageBoxIcon.Information );
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value= db.Guides.Where(x=> x.GuideId == id).ToList();
            dataGridView1.DataSource = value;

        }
    }
}
