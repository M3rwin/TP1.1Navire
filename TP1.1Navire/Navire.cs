using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TP1._1Navire.Exceptions;

namespace TP1._1Navire
{
    class Navire
    {
        // PRIVATE ATTRIBUTES
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;
        private int qteFret;


        // CONSTRUCTOR
        public Navire(string imo, string nom)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = "null";
            this.QteFretMaxi = 0;
        }

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi, int qteFret)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
            this.QteFret= qteFret;
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
                    throw new GestionPortException("Erreur : IMO invalide");
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
                    throw new GestionPortException("Erreur, quantité de fret non valide");
                }
            }
        }

        public int QteFret 
        { 
            get => qteFret;
            private set
            {
                if (value < 0 || value > this.qteFretMaxi)
                {
                    throw new GestionPortException("Valeur incohérente pour la quantité de fret stockée dans le navire");
                }
                else { this.qteFret = value; }
            }
        }



        //METHODES

        public int Decharger(int quantite)
        {
            if(quantite<0) { throw new GestionPortException("la quantité à décharger ne peut être négative ou nulle"); }
            else if (quantite>this.qteFret) { throw new GestionPortException("Impossible, fret insuffisant"); }
            else 
            {
                this.QteFret -= quantite;
                return quantite;
            }
        }

        
        public bool EstDecharge()
        {
            return this.qteFret == 0;
        }

    }
}
