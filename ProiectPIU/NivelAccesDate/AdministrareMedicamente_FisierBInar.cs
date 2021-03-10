using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareMedicamente_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMedicamente_FisierBinar(string numeFisier)
        {
            this.NumeFisier = numeFisier;
        }
        public void AddMedicament(Medicament s)
        {
            throw new Exception("Optiunea AddMedicament nu este implementata");
        }
        public void Stergere()
        {
            throw new Exception("Optiunea Stergere nu este implementata");
        }
        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            throw new Exception("Optiunea GetMedicamente nu este implementata");
        }
        public List<Medicament> GetMedicament(string numeVanzator, string tip)
        {
            throw new Exception("Optiunea GetMedicament nu este implementata");
        }
        public List<Medicament> GetMedicamente()
        {
            throw new Exception("Optiunea GetMedicamente nu este implementata");

        }
        public Medicament GetMedicamentByIndex(int Index)
        {
            throw new Exception("Optiunea GetMedicamentById nu este implementata");
        }
        public bool UpdateMedicament(Medicament med)
        {
            throw new Exception("Optiunea UpdateMedicament nu este implemantata");
        }
    }
}

