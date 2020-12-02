using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayerWeb
{
    public partial class _60_2018 : System.Web.UI.Page
    {
        private VetBusiness vetBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.vetBusiness = new VetBusiness();
            RefreshData();
        }
        public void RefreshData()
        {
            List<Vet> vets = this.vetBusiness.GetAllVets();

            
            foreach (Vet s in vets)
            {
                listBox1.Items.Add("Ime:\t" + s.FullName + "\tSpecijalnost:\t" + s.Specialty + "\tGodine iskustva:  " + s.YearsExperience);

            }
        }

        
    }
}