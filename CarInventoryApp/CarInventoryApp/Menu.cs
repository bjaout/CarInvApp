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
            Car.TrunkType trunk = Car.TrunkType.None;

            string dir = @"c:\temp";
            file = Path.Combine(dir, "vehicles.bin");

            Console.WriteLine("Bonjour. Bienvenu dans l'outil de gestion des stock d'INSA Car");
            ReadData();

            while (!stop)
            {
                DisplayMenu();
                Console.ForegroundColor = ConsoleColor.White;
                switch (Console.ReadLine())
                {
                    case "0":
                        PrintList();
                        break;

                    case "1":
                        GetCarDatas(out brand, out model, out nbGearRatio, out nbDoors, out horsePower, out trunk);
                        AddVehicle(brand,model,nbGearRatio,nbDoors,horsePower,trunk);
                        break;

                    case "2":
                        DeleteVehicle();
                        break;

                    case "3":
                        ClearList();
                        break;

                    case "4":
                        SaveData();
                        stop = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
