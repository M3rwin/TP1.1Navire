using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1._1Navire
{
    class Port
    {
        private string nom;
        private int nbNaviresMax = 5;
        private List<Navire> navires = new List<Navire>();

        public Port(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; }
        public int NbNaviresMax { get => nbNaviresMax; set => nbNaviresMax = value; }
        internal List<Navire> Navires { get => navires; set => navires = value; }

        public void EnregistrerArrivee(Navire navire)
        {
            if (this.nbNaviresMax > this.navires.Count)
            {
                this.navires.Add(navire);
            }
            else
            {
                throw new Exception("Impossible, le port est plein");
            }

        }

        public bool EstPresent(string imo)
        {
            Navire temoin = new Navire(imo, "Temoin");
            for (int i = 0; i < this.navires.Count() ; i++)
            {
                if (this.navires[i].Imo == imo)
                {
                    return true;
                }
            }
            return false;
        }


        public int RecupPosition(string imo)
        {
            for (int i = 0; i < this.navires.Count; i++)
            {
                if (this.navires[i].Imo == imo)
                {
                    return i;
                }
            }
            return -1;
        }

        public int RecupPosition(Navire navire)
        {
            if (this.navires.Contains(navire))
            {
                return this.navires.IndexOf(navire);
            }
            else
            {
                return -1;
            }
        }

        public void EnregistrerDepart(string imo)
        {
            if (EstPresent(imo))
            {
                int indice = RecupPosition(imo);
                if (indice != -1)
                {
                    this.navires.RemoveAt(indice);
                }
                else
                {
                    throw new Exception("Le port ne contient pas de bateau comportant cet IMO");
                }

            }
        }

        public void TestRecupPosition()
        {
            Navire test1 = new Navire("IMO1564879", "SS Test1");
            Navire test2 = new Navire("IMO1564880", "SS Test2");
            Navire test3 = new Navire("IMO1564881", "SS Test3");
            Navire test4 = new Navire("IMO1564882", "SS Test4");

            this.EnregistrerArrivee(test1);
            this.EnregistrerArrivee(test2);
            this.EnregistrerArrivee(test3);

            Console.WriteLine("Indice du SS Test1 (" + test1.Imo + ") : " + this.RecupPosition(test1.Imo));
            Console.WriteLine("Indice du SS Test2 (" + test3.Imo + ") : " + this.RecupPosition(test3.Imo));
            Console.WriteLine("Indice du SS Test4 (" + test4.Imo + ") : " + this.RecupPosition(test4.Imo));
        }

        public void TestRecupPositionV2()
        {
            Navire test1 = new Navire("IMO1564879", "SS Test1");
            Navire test2 = new Navire("IMO1564880", "SS Test2");
            Navire test3 = new Navire("IMO1564881", "SS Test3");
            Navire test4 = new Navire("IMO1564882", "SS Test4");

            this.EnregistrerArrivee(test1);
            this.EnregistrerArrivee(test2);
            this.EnregistrerArrivee(test3);

            Console.WriteLine("Indice du SS Test1 (" + test1.Imo + ") : " + this.RecupPosition(test1));
            Console.WriteLine("Indice du SS Test2 (" + test3.Imo + ") : " + this.RecupPosition(test3));
            Console.WriteLine("Indice du SS Test4 (" + test4.Imo + ") : " + this.RecupPosition(test4));
        }
    }
}
