using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public enum CategorieVarsta
    {
        Necunoscut = 0,
        Copil = 1,
        Adult = 2,
        InVarsta = 3

    }
    public enum CampuriMedicament
    {   
        IdMedicament = 0,
        numeMedicament = 1,
        numeProducator = 2,
        Cantitate = 3,
        anFabricare =4,
        Pret = 5,
        CategorieVarsta=6
    }
}
