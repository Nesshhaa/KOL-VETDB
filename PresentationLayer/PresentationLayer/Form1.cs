using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private VetBusiness vetBusiness;
        public Form1()
        {
            InitializeComponent();
            this.vetBusiness = new VetBusiness();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            List<Vet> vets = this.vetBusiness.GetAllVets();

            listBox1.Items.Clear();
            foreach(Vet s in vets)
            {
                listBox1.Items.Add("Ime:\t" + s.FullName + "\tSpecijalnost:\t" + s.Specialty + "\tGodine iskustva:  " + s.YearsExperience);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vet s = new Vet();
            s.FullName = textBox1.Text;
            s.Specialty = textBox2.Text;
            s.YearsExperience = int.Parse(textBox3.Text);

            if (this.vetBusiness.InsertVet(s))
            {
                RefreshData();
                MessageBox.Show("Uspesno ste uneli veterinara u bazu!");
            }
            else
                MessageBox.Show("Veterinar nije unet u bazu");
        }
    }
}
