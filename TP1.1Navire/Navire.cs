using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TP1._1Navire
{
    class Navire
    {
        // PRIVATE ATTRIBUTES
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;


        // CONSTRUCTOR
        public Navire(string imo, string nom)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = "null";
            this.QteFretMaxi = 0;
        }

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
        }
        // SETTERS GETTERS
        public string Imo
        {
            get => imo;
            set
            {
                string pattern = @"^[I][M][O][0-9]{7}";
                if (Regex.IsMatch(value, pattern))
                {
                    this.imo = value;
                }
                else
                {
                    throw new Exception("Erreur : IMO invalide");
                }
            }
        }
        public string Nom { get => nom; set => nom = value; }
        public string LibelleFret { get => libelleFret; set => libelleFret = value; }
        public int QteFretMaxi
        {
            get => qteFretMaxi;
            set
            {
                if(value >= 0)
                {
                    this.qteFretMaxi = value;
                }
                else
                {
                    throw new Exception("Erreur, quantité de fret non valide");
                }
            }
        }


        //METHODES
    }
}
