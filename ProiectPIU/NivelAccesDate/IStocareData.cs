using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddMedicament(Medicament m);
        void Stergere();
        List<Medicament> GetMedicamente();
        Medicament[] GetMedicamente(out int nrMedicamente);
        List <Medicament>GetMedicament(string NumeMedicament, string NumeProducator);
        Medicament GetMedicamentByIndex(int index);
        bool UpdateMedicament(Medicament med);

    }
}
