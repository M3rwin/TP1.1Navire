using System;
using System.Text.RegularExpressions;
using TP1._1Navire.Exceptions;
using TP1._1Navire.ClassesMetier;
using TP1._1Navire;

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

                try { TestEnregistrerArrivee(); }
                catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                try { TestEnregistrerArriveeV2(); }
                catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                Console.WriteLine("-----------------------------");
                Console.WriteLine("---Début des déchargements---");
                Console.WriteLine("-----------------------------");
                AjouterStockage();
                TesterDechargerNavire();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("----Fin des déchargement----");
                Console.WriteLine("-----------------------------");
                try { TestEnregistrerDepart(); }
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
                Navire navire = new Navire("IMO0000001", "Navire1", "Porte-conteneurs", 10000, 120);
                port.EnregistrerArrivee(navire);
                Navire navire2 = new Navire("IMO0000002", "Navire2", "Porte-conteneurs", 10000, 240);
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
                navire = new Navire("IMO0000003", "Navire3");
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO0000002", "Navire2");
                port.EnregistrerArrivee(navire);
                port.EnregistrerDepart("IMO0000002");
                Console.WriteLine($"{navire.Imo} est bien partit.");


            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }


        static void TestInstanciationsStockage()
        {
            try { new Stockage(1, 15000); } catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try { new Stockage(2, 12000, 10000); } catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try { new Stockage(3, -25000, -10000); } catch(GestionPortException ex) { Console.WriteLine(ex.Message); }
            try { new Stockage(4, 15000, 20000); } catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }

        static void AjouterStockage()
        {
            port.AjoutStockage(new Stockage(1, 160000));
            port.AjoutStockage(new Stockage(2, 120000));
            port.AjoutStockage(new Stockage(3, 250000));
            port.AjoutStockage(new Stockage(4, 150000));
            port.AjoutStockage(new Stockage(5, 160000));
            port.AjoutStockage(new Stockage(6, 160000));
            port.AjoutStockage(new Stockage(7, 160000));
            port.AjoutStockage(new Stockage(8, 160000));
            port.AjoutStockage(new Stockage(9, 350000));
            port.AjoutStockage(new Stockage(10, 190000));
        }

        static void TesterDechargerNavire() {
            try
            {
                String imo = "IMO0000002";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                string imo = "IMO1111111";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                string imo = "IMO9574004";
                port.Dechargement(imo);
                Console.WriteLine("Navire “ + imo + “ déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9786841", "EVER GLOBE", "Porte-conteneurs", 198937, 190000));
                string imo = "IMO9786841";
                port.Dechargement(imo);
                Console.WriteLine("Navire “ + imo + “ déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9776432", "CMACGM LOUIS BLERIOT", "Porte-conteneurs", 19000000, 19000000));
                string imo = "IMO9776432";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }

            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }
        }

    }
