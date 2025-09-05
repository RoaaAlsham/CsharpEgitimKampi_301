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
    public partial class FrmLocations : Form
    {
        public FrmLocations()
        {
            InitializeComponent();
        }

        EgitimKampi_EntityFramework_dbEntities1 db = new EgitimKampi_EntityFramework_dbEntities1();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1.DataSource = values;

        }

        private void FrmLocations_Load(object sender, EventArgs e)
        {
             var guides = db.Guides.Select(x => new 
            {
                Fullname = x.GuideName + " " + x.GuideSurname , x.GuideId
            }).ToList();
            comboBox1.DisplayMember = "Fullname" ;   
            comboBox1.ValueMember = "GuideId";
            comboBox1.DataSource = guides;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location l = new Location();
            l.Country = txtCountry.Text;
            l.City = txtCity.Text;
            l.Capacity = (byte?)numericUpDown1.Value;
            l.Price = decimal.Parse(txtPrice.Text);
            l.DayNight = txtDayNight.Text;
            l.GuidId = (int)(comboBox1.SelectedValue);
            db.Locations.Add(l);
            db.SaveChanges();
            MessageBox.Show("Location Added");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Location l = db.Locations.Find(id);
            db.Locations.Remove(l);
            db.SaveChanges();
            MessageBox.Show("Location Deleted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Location l  = db.Locations.Find(id);
            l.Country = txtCountry.Text;
            l.City = txtCity.Text;
            l.Capacity = (byte?)numericUpDown1.Value;
            l.Price = decimal.Parse(txtPrice.Text);
            l.DayNight = txtDayNight.Text;
            l.GuidId = (int)(comboBox1.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Location Updated");
        }
    }
}
