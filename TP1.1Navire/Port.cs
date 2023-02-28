using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1._1Navire.Exceptions;
using TP1._1Navire.ClassesMetier;

namespace TP1._1Navire
{
    class Port
    {
        private string nom;
        private int nbNaviresMax = 5;
        private Dictionary<string, Navire> navires = new Dictionary<string, Navire>();
        private List<Stockage> stockages = new List<Stockage>();

        public Port(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; }
        public int NbNaviresMax { get => nbNaviresMax; set => nbNaviresMax = value; }
        internal Dictionary<string, Navire> Navires { get => navires; set => navires = value; }

        public void EnregistrerArrivee(Navire navire)
        {
            try
            {
                if (this.nbNaviresMax > this.navires.Count)
                {
                    this.navires.Add(navire.Imo, navire);
                }
                else
                {
                    throw new GestionPortException("Impossible, le port est plein");
                }
            }
            catch (ArgumentException) { throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré."); }


        }

        public bool EstPresent(string imo)
        {
            return this.navires.ContainsKey(imo);
        }


        //public int RecupPosition(string imo)
        //{
        //    for (int i = 0; i < this.navires.Count; i++)
        //    {
        //        if (this.navires[i].Imo == imo)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public int RecupPosition(Navire navire)
        //{
        //    if (this.navires.Contains(navire))
        //    {
        //        return this.navires.IndexOf(navire);
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        public void EnregistrerDepart(string imo)
        {
            if (this.EstPresent(imo))
            {
                this.navires.Remove(imo);
            }
            else
            {
                throw new GestionPortException("Le navire spécifié n'est pas présent dans le port");
            }
        }


        //public void TestRecupPosition()
        //{
        //    Navire test1 = new Navire("IMO1564879", "SS Test1");
        //    Navire test2 = new Navire("IMO1564880", "SS Test2");
        //    Navire test3 = new Navire("IMO1564881", "SS Test3");
        //    Navire test4 = new Navire("IMO1564882", "SS Test4");

        //    this.EnregistrerArrivee(test1);
        //    this.EnregistrerArrivee(test2);
        //    this.EnregistrerArrivee(test3);

        //    Console.WriteLine("Indice du SS Test1 (" + test1.Imo + ") : " + this.RecupPosition(test1.Imo));
        //    Console.WriteLine("Indice du SS Test2 (" + test3.Imo + ") : " + this.RecupPosition(test3.Imo));
        //    Console.WriteLine("Indice du SS Test4 (" + test4.Imo + ") : " + this.RecupPosition(test4.Imo));
        //}

        //public void TestRecupPositionV2()
        //{
        //    Navire test1 = new Navire("IMO1564879", "SS Test1");
        //    Navire test2 = new Navire("IMO1564880", "SS Test2");
        //    Navire test3 = new Navire("IMO1564881", "SS Test3");
        //    Navire test4 = new Navire("IMO1564882", "SS Test4");

        //    this.EnregistrerArrivee(test1);
        //    this.EnregistrerArrivee(test2);
        //    this.EnregistrerArrivee(test3);

        //    Console.WriteLine("Indice du SS Test1 (" + test1.Imo + ") : " + this.RecupPosition(test1));
        //    Console.WriteLine("Indice du SS Test2 (" + test3.Imo + ") : " + this.RecupPosition(test3));
        //    Console.WriteLine("Indice du SS Test4 (" + test4.Imo + ") : " + this.RecupPosition(test4));
        //}


        public void Dechargement(string imo)
        {
            if(this.EstPresent(imo))
            {
                Navire navire = this.navires[imo];
                if (navire.LibelleFret == "Porte-conteneurs")
                {
                    for(int i=0; i<this.stockages.Count; i++)
                    {
                        if (navire.QteFret >= this.stockages[i].CapaciteDispo)
                        {
                            navire.Decharger(this.stockages[i].CapaciteDispo);
                        }
                        else { navire.Decharger(navire.QteFret); }
                        
                    }
                    if (navire.QteFret > 0)
                    {
                        throw new GestionPortException($"Le navire {imo} n'a pas pu être entièrement déchargé, il reste {navire.QteFret} tonnes.");

                    }
                }
                else { throw new GestionPortException("Le navire ne peut pas être dééchargé ici"); }
            }
            else { throw new GestionPortException("Le navire n'est pas dans le port"); }
        }


        public void AjoutStockage(Stockage stockage)
        {
            this.stockages.Add(stockage);
        }

        public Navire GetNavire(string imo)
        {
            if (EstPresent(imo))
            {
                return this.navires[imo];
            }
            else { return null; }
        }
    }
}
