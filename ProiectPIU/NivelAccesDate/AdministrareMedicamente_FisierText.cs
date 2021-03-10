using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareMedicamente_FisierText : IStocareData
    {
        private const int PAS_ALOCARE = 2;
        private const int IdPrimulMedicament = 0;
        private const int INCREMENT = 1;
        string NumeFisier { get; set; }
        public AdministrareMedicamente_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void Stergere()
        {
            File.WriteAllText(NumeFisier, String.Empty);
        }
        public void AddMedicament(Medicament m)
        {
            m.IdMedicament = GetId();
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(m.ConversieSirPentruForma());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica.Mesaj: " + eGen.Message);
            }
        }


        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            Medicament[] medicamente = new Medicament[PAS_ALOCARE];

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrMedicamente = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        medicamente[nrMedicamente++] = new Medicament(line);
                        if (nrMedicamente == PAS_ALOCARE)
                        {
                            Array.Resize(ref medicamente, nrMedicamente + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return medicamente;
        }
        public List<Medicament> GetMedicament(string pret, string categorie)
        {
            string pretMic = string.Empty;
            string pretMare = string.Empty;
            bool LimitaAtinsa = true;
            List <Medicament> medicamente = new List<Medicament>();

            for (int i = 0; i < pret.Length; i++) 
            {
                if (pret[i] == '-')
                    LimitaAtinsa = false;
                if (pret[i] != '-' & LimitaAtinsa)
                {
                    pretMic += pret[i];
                }
                if (!LimitaAtinsa & pret[i]!='-')
                {
                    pretMare += pret[i];
                }
            }

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Medicament pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Medicament medicament = new Medicament(line);
                        if (int.Parse(medicament.pret) >= int.Parse(pretMic) && int.Parse(medicament.pret) <= int.Parse(pretMare))
                            for (int i = 0; i < medicament.categorieVarsta.Count; i++)
                                if (categorie == medicament.categorieVarsta[i])
                                    medicamente.Add(medicament);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return medicamente;
        }
        public List<Medicament> GetMedicamente()
        {
            List<Medicament> medicamente = new List<Medicament>();

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Medicament s = new Medicament(line);
                        medicamente.Add(s);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return medicamente;
        }
        public Medicament GetMedicamentByIndex(int index)
        {
                try
                {
                    // instructiunea 'using' va apela sr.Close()
                    using (StreamReader sr = new StreamReader(NumeFisier))
                    {
                        string line;
                        int contor = 0;
                        //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                        while ((line = sr.ReadLine()) != null)
                        {
                            Medicament med= new Medicament(line);
                        if (contor == index)
                            return med;
                            contor++;
                        }
                    }
                }
                catch (IOException eIO)
                {
                    throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
                }
                catch (Exception eGen)
                {
                    throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
                }
                return null;

            }
        public bool UpdateMedicament(Medicament med)
        {
            List<Medicament> medicamente = GetMedicamente();
            bool actualizareCuSucces = false;
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Medicament m in medicamente)
                    {
                        //informatiile despre Medicamentul actualizat vor fi preluate din parametrul "med"
                        if (m.IdMedicament !=med.IdMedicament)
                        {
                            swFisierText.WriteLine(m.ConversieSirPentruForma());
                        }
                        else
                        {
                            swFisierText.WriteLine(med.ConversieSirPentruForma());
                        }
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }
        private int GetId()
        {
            int IdMedicament = IdPrimulMedicament;
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Medicament m = new Medicament(line);
                        IdMedicament = m.IdMedicament + INCREMENT;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return IdMedicament;
        }
    }
}
