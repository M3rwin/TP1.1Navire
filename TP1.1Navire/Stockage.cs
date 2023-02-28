using System;
using System.Collections.Generic;
using System.Text;
using TP1._1Navire.Exceptions;

namespace TP1._1Navire.ClassesMetier
{
    internal class Stockage
    {


        //PROPRIETE
        private readonly int numero;
        private int capaciteMaxi;
        private int capaciteDispo;




        //CONSTRUCTEUR
        public Stockage(int numero, int capaciteMaxi, int capaciteDispo)
        {
            this.numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.CapaciteDispo = capaciteDispo;
        }

        public Stockage(int numero, int capaciteMaxi)
        {
            this.numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.CapaciteDispo = capaciteMaxi;
        }





        //GET SET
        public int CapaciteMaxi { get => capaciteMaxi;
            set 
            {
                if (value <= 0)
                {
                    throw new GestionPortException("La capacité maximale doit être supérieure à 0");
                }
                else { capaciteMaxi = value; } 
            } 
        }


        public int CapaciteDispo
        {
            get => capaciteDispo;
            private set
            {
                if (value > this.CapaciteMaxi)
                {
                    throw new GestionPortException("La capacité restente ne peut pas être supérieure au maximum");
                }
                else if(value < 0)
                {
                    throw new GestionPortException("La capacité ne peut pas être négative");
                }
                else { capaciteDispo = value; }
            }
        }

        public int Numero => numero;


        //METHODES

        public void Stocker(int quantite)
        {
            if (quantite < 0)
            {
                throw new GestionPortException("La quantité ne peut pas être négative");
            }
            else if(quantite > this.capaciteDispo)
            {
                throw new GestionPortException("Capacité de stockage insuffisante");
            }
            else
            {
                this.capaciteDispo -= quantite;
            }
        }
    }
}
