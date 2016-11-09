using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    /// <summary>
    /// Main fuinctional class
    /// </summary>
    partial class Menu
    {
        /// <summary>
        /// The car inventory that will be used 
        /// </summary>
        private List<Vehicle> inventory = new List<Vehicle>();
        private string file;

        /// <summary>
        /// Main method of app displaying menu and allowing user to choose next action
        /// </summary>
        public void Run()
        {
            bool stop = false;

            string brand = "";
            string model = "";
            int nbGearRatio = 0;
            int nbDoors = 0;
            int horsePower = 0;
            bool storage = false;
            bool crutch = false;
            Car.TrunkType trunk = Car.TrunkType.None;

            string dir = Path.GetTempPath();
            file = Path.Combine(dir, "vehicles.bin");

            Console.WriteLine("Bonjour. Bienvenu dans l'outil de gestion des stock d'INSA Car");
            ReadData();

            while (!stop)
            {
                DisplayMenu();
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "0":
                            PrintList();
                            break;

                        case "1":
                            if (GetCarDatas(out brand, out model, out nbGearRatio, out nbDoors, out horsePower, out trunk))
                            {
                                AddCar(brand, model, nbGearRatio, nbDoors, horsePower, trunk);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("La voiture n'a pas pu être ajoutée à cause de paramètres corrompus.");
                            }
                            break;

                        case "2":
                            if (GetMotoDatas(out brand, out model, out nbGearRatio, out horsePower, out storage))
                            {
                                AddMoto(brand, model, nbGearRatio, horsePower, storage);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("La moto n'a pas pu être ajoutée à cause de paramètres corrompus.");
                            }
                            break;

                        case "3":
                            GetVeloDatas(out brand, out model, out crutch);
                            AddVelo(brand, model, crutch);
                            break;

                        case "4":
                            DeleteVehicle();
                            break;

                        case "5":
                            ClearList();
                            break;

                        case "6":
                            SaveData();
                            stop = true;
                            break;

                        default:
                            break;
                    }
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Impossible de réaliser cette action car la "
                        + "fonctionnalité n'est pas implémentée.");
                }
            }
        }
    }
}
