using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VetBusiness
    {
        private readonly VetRepository vetRepository;

        public VetBusiness()
        {
            this.vetRepository = new VetRepository();
        }

        public List<Vet> GetAllVets()
        {
            return this.vetRepository.GetAllVets();
        }
        public bool InsertVet(Vet s)
        {
            if (this.vetRepository.InsertVet(s) > 0)
                return true;
            else
                return false;
        }

        public List<Vet> GetVetsYEARSEXP(int Yexp) //metoda koja vraca veterinare sa vise godina iskustva od prosledjenih godna
        {
            return this.vetRepository.GetAllVets().Where(s => s.YearsExperience > Yexp).ToList();
        }
    }
}
