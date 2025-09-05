using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity___Framework
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampi_EntityFramework_dbEntities1 db = new EgitimKampi_EntityFramework_dbEntities1();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            
            
            lblLocationCount.Text = db.Locations.Count().ToString();

            lblTotalCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = db.Guides.Count().ToString();

            lblAverageCapacity.Text = ((int)db.Locations.Average(x => x.Capacity)).ToString();

            lblAveragePrice.Text =decimal.Ceiling((decimal)db.Locations.Average(x => x.Price)).ToString();

            int latestId = db.Locations.Max(x => x.LocationId);
            lblLatestCounrty.Text = db.Locations.Find(latestId).Country;

            lblSarajevoCapaciy.Text =db.Locations.Where(x=> x.City=="Sarajevo").First().Capacity.ToString();
            lblTurkeyCapacity.Text = db.Locations.Where(x => x.Country == "Turkey").Average(y => y.Capacity).ToString();

            lblTokyoTourGuide.Text = db.Locations.Where(X => X.City == "Tokyo").Select(y => y.Guide.GuideName + " " + y.Guide.GuideSurname).FirstOrDefault();

            int maxCapacity = (int)db.Locations.Max(x => x.Capacity);
             lblHighestCapacityLocation.Text= db.Locations.Where(x=> x.Capacity==maxCapacity).Select(y=> y.Country + "/" + y.City).FirstOrDefault();

            lblExpensiveCity.Text = db.Locations.OrderByDescending(x => x.Price).Select(y => y.City).FirstOrDefault();

            //lblZehraTours.Text = db.Guides.Where(x => x.GuideName == "Zehra").Select(y => y.Locations.Count).FirstOrDefault().ToString();
            lblZehraTours.Text = db.Locations.Count(x => x.Guide.GuideName == "Zehra").ToString();


        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
