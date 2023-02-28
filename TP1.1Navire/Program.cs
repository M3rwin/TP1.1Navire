using System;
using System.Text.RegularExpressions;
using TP1._1Navire.Exceptions;

namespace TP1._1Navire
{
    class Program
    {
        private static Port port;

        static void Main(string[] args)
        {
            try
            {

                port = new Port("Toulon");

                try { Instanciations(); }
                catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                

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
                Navire navire = new Navire("IMO0000001", "Bateau1", "Cargaison1", 65412, 0);
                navire = new Navire("IMO0000002", "Bateau2", "Cargaison1", 123684, -1);
                navire = new Navire("IMO0000003", "Bateau3", "Cargaison1", 56, 1);
                navire = new Navire("IMO0000004", "Bateau4", "Cargaison1", 8546, 1);
                navire = new Navire("IMO0000005", "Bateau5", "Cargaison1", 6541462, 1);
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
            
            navire = new Navire("IMO0000002", "Bateau2", "Cargaison1", 123684, 1);
            Console.WriteLine($"Deuxième bateau enregistré, IMO : {navire.Imo}, Nom : {navire.Nom}, Fret : {navire.LibelleFret}, Qte : {navire.QteFretMaxi}");
            navire = new Navire("IMO0000003", "Bateau3", "Cargaison1", 56, 1);
            navire = new Navire("IMO0000004", "Bateau4", "Cargaison1", 8546, 1);
            navire = new Navire("IMO0000005", "Bateau5", "Cargaison1", 6541462, 1);
        }


        static void TestEnregistrerArrivee()
        {
            try
            {
                Navire navire = new Navire("IMO0000001", "Navire1");
                port.EnregistrerArrivee(navire);
                Navire navire2 = new Navire("IMO0000002", "Navire2");
                port.EnregistrerArrivee(navire2);
                Navire navire3 = new Navire("IMO0000002", "Navire3");
                port.EnregistrerArrivee(navire3);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }


        static void TestEnregistrerArriveeV2()
        {
            Navire navire = null;
            try
            {
                port.EnregistrerArrivee(new Navire("IMO0000001", "Navire1"));
                port.EnregistrerArrivee(new Navire("IMO0000002", "Navire2"));
                port.EnregistrerArrivee(new Navire("IMO0000003", "Navire3"));
                port.EnregistrerArrivee(new Navire("IMO0000004", "Navire4"));
                port.EnregistrerArrivee(new Navire("IMO0000005", "Navire5"));
                port.EnregistrerArrivee(new Navire("IMO0000006", "Navire6"));
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException) { throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré."); }
        }


        static void TestEnregistrerDepart()
        {
            Navire navire = null;
            try
            {
                navire = new Navire("IMO0000001", "Navire1");
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO0000002", "Navire2");
                port.EnregistrerArrivee(navire);
                port.EnregistrerDepart("IMO0000002");
                Console.WriteLine($"{navire.Imo} est bien partit.");


            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }
    }
}
