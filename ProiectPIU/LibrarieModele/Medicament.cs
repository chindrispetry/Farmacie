using System;
using System.Collections.Generic;

namespace LibrarieModele
{
    public class Medicament
    { 
        //Constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        //proprietati auto-implemented
        public static int IdUltimMedicament { get; set; } = 0;
        public List<string> categorieVarsta { get; set; }
        public int IdMedicament { get; set; }
        public string anFabricatie { get; set; }
        public string pret { get; set; }
        public string cantitate { get; set; }
        public string NumeProducator { get; set; }
        public string NumeMedicament { get; set; }
        public DateTime DataAdaugare { get; set; }
        public DateTime DataActualizare { get; set; }
        //constructor implicit
        public Medicament()
        {
            anFabricatie = pret =  cantitate = NumeMedicament = NumeProducator = string.Empty;
        }
        //constructor cu parametri
        public Medicament(string numeMedicament,string numeProducator, string Cantitate ,string an_Fabricatie, string Pret)
        {
            anFabricatie = an_Fabricatie;
            pret = Pret;
            cantitate = Cantitate;
            NumeProducator = numeProducator;
            NumeMedicament = numeMedicament;
        }
        //constructor ce primeste un string ca parametru 
        public Medicament(string SirInfo)
        {
            string[] info = SirInfo.Split(SEPARATOR_PRINCIPAL_FISIER);
            IdMedicament = int.Parse(info[(int)CampuriMedicament.IdMedicament]);
            NumeMedicament = info[(int)CampuriMedicament.numeMedicament];
            NumeProducator = info[(int)CampuriMedicament.numeProducator];
            cantitate = info[(int)CampuriMedicament.Cantitate];
            anFabricatie = info[(int)CampuriMedicament.anFabricare];
            pret = info[(int)CampuriMedicament.Pret];
            categorieVarsta = new List<string>();
            categorieVarsta.AddRange(info[(int)CampuriMedicament.CategorieVarsta].Split(SEPARATOR_SECUNDAR_FISIER));
        }
        public string ConversieLaSir()
        { 
            string sir;
            sir = IdMedicament +" "+ anFabricatie + " " + pret + " " + cantitate + " " + NumeProducator + " " + NumeMedicament +" "+categorieVarsta ;
            return sir;
        }
        public static bool ComparaDouaMedicamente(Medicament med1,Medicament med2)
        {
            bool comp = false;
            if (med1.NumeMedicament.ToUpper() == med2.NumeMedicament.ToUpper() && med1.NumeProducator.ToUpper() == med2.NumeProducator.ToUpper())
                comp = true;
            return comp;
        }
        public string OptiuneAsString
        {
            get
            {
                string sOptiune = string.Empty;

                foreach (string optiune in categorieVarsta)
                {
                    if (sOptiune != string.Empty)
                    {
                        sOptiune += SEPARATOR_SECUNDAR_FISIER;
                    }
                    sOptiune += optiune;
                }

                return sOptiune;
            }
        }
        public string Afisare()
        {
            return string.Format(" Nume: {0} \n Cantitate: {1} \n Pret: {2} LEI  \n Nume Producator: {3} \n An Fabricatie:{4}\n", NumeMedicament, cantitate, pret, NumeProducator, anFabricatie);
        }
        public string ConversieSirPentruForma()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}",SEPARATOR_PRINCIPAL_FISIER,IdMedicament,(NumeMedicament ?? "necunoscut"),(NumeProducator ?? "necunoscut"),(cantitate ?? "necunoscut"),(anFabricatie ?? "necunoscut"),(pret ?? "necunoscut"),OptiuneAsString,DataAdaugare,DataActualizare);
        }
        public override string ToString()
        {
            return ConversieSirPentruForma();
        }
    }
}