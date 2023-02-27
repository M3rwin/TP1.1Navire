using System;
using System.Text.RegularExpressions;

namespace TP1._1Navire
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExpressionReguliere();
                Console.WriteLine("Fin normale du programme");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        private static void Instanciations()
        {
            try
            {
                Navire navire = new Navire("IMO0000001", "Bateau1", "Cargaison1", 65412);
                navire = new Navire("IMO0000002", "Bateau2", "Cargaison1", 123684);
                navire = new Navire("IMO0000003", "Bateau3", "Cargaison1", -56);
                navire = new Navire("IMO0000004", "Bateau4", "Cargaison1", 8546);
                navire = new Navire("IMO0000005", "Bateau5", "Cargaison1", 6541462);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ExpressionReguliere()
        {
            Navire navire = new Navire("IMO0000001", "Bateau1");
            Console.WriteLine($"Premier bateau enregistré, IMO : {navire.Imo}, Nom : {navire.Nom}, Fret : {navire.LibelleFret}, Qte : {navire.QteFretMaxi}");
            
            navire = new Navire("IMO0000002", "Bateau2", "Cargaison1", 123684);
            Console.WriteLine($"Deuxième bateau enregistré, IMO : {navire.Imo}, Nom : {navire.Nom}, Fret : {navire.LibelleFret}, Qte : {navire.QteFretMaxi}");
            navire = new Navire("IMO0000003", "Bateau3", "Cargaison1", 56);
            navire = new Navire("IMO0000004", "Bateau4", "Cargaison1", 8546);
            navire = new Navire("IMO0000005", "Bateau5", "Cargaison1", 6541462);
        }
    }
}
