using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    partial class Menu
    {
        /// <summary>
        /// Display main application menu
        /// </summary>
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Veuillez sélectionner l'action que vous souhaitez exécuter.");
            Console.WriteLine("La liste des différents modes est la suivante :");
            Console.WriteLine("\t- 0 : Afficher la liste des véhicules");
            Console.WriteLine("\t- 1 : Ajouter un véhicule");
            Console.WriteLine("\t- 2 : Supprimer un véhicule");
            Console.WriteLine("\t- 3 : Vider la liste des véhicules");
            Console.WriteLine("\t- 4 : Quitter le programme");
        }

        /// <summary>
        /// Get all car data necessary to add it in the inventory
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="nbDoors">Number of doors (trunk count has one)</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="trunk">Trunk type</param>
        private void GetCarDatas(out string brand, out string model, out int nbGearRatio, out int nbDoors, out int horsePower, out Car.TrunkType trunk)
        {
            bool stop = false;
            string readData = "";

            trunk = Car.TrunkType.None;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la marque de la voiture");
            Console.ForegroundColor = ConsoleColor.White;
            brand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le modèle de la voiture");
            Console.ForegroundColor = ConsoleColor.White;
            model = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le nombre de vitesses");
            Console.ForegroundColor = ConsoleColor.White;
            nbGearRatio = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le nombre de portes");
            Console.ForegroundColor = ConsoleColor.White;
            nbDoors = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la puissance du véhicule");
            Console.ForegroundColor = ConsoleColor.White;
            horsePower = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez donner le type de coffre : 0 pas de coffre, 1 coffre ou 2 hayon");
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                readData = Console.ReadLine();
                switch (readData)
                {
                    case "0":
                        trunk = Car.TrunkType.None;
                        stop = true;
                        break;

                    case "1":
                        trunk = Car.TrunkType.Hatch;
                        stop = true;
                        break;

                    case "2":
                        trunk = Car.TrunkType.Tailgate;
                        stop = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Veuillez donner un type de coffre valide : 0 pas de coffre, 1 coffre ou 2 hayon");
                        stop = false;
                        break;
                }
            } while (!stop);
        }

        /// <summary>
        /// Display full inventory
        /// </summary>
        private void PrintList()
        {
            foreach (Vehicle elem in inventory)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(elem.ToString());
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Add a specific car to inventory
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="nbDoors">Number of doors (trunk count has one)</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="trunk">Trunk type</param>
        private void AddVehicle(string brand, string model, int nbGearRatio, int nbDoors, int horsePower, Car.TrunkType trunk)
        {
            inventory.Add(new Car(brand, model, nbGearRatio, nbDoors, horsePower, trunk));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Véhicule ajouté");
        }

        /// <summary>
        /// Delete one car from inventory
        /// </summary>
        private void DeleteVehicle()
        {
            int index = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez indiquer l'index du véhicule à supprimer");
            Console.ForegroundColor = ConsoleColor.White;
            index = Convert.ToInt32(Console.ReadLine());
            try
            {
                inventory.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Véhicule supprimé avec succès");
            }
            // If out of bound display a warning message and leave
            catch (ArgumentOutOfRangeException e)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Désolé cette voiture n'est pas dans la liste");
            }
        }

        /// <summary>
        /// Clear inventory from all car
        /// </summary>
        private void ClearList()
        {
            inventory.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Liste vidée");
        }

        /// <summary>
        /// Save data to binary file
        /// </summary>
        private void SaveData()
        {
            using (Stream stream = File.Open(file, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, inventory);
            }
        }

        private void ReadData()
        {
            try
            {
                // Read data saved from previous execution
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    inventory = (List<Vehicle>)bformatter.Deserialize(stream);
                }
            }
            // If file is not found then create it and close it afterwards or there will be an error when saving
            catch (FileNotFoundException e)
            {
                Stream stream = File.Open(file, FileMode.Create);
                stream.Close();
            }
            // If file contains no data or bad data then just consider that inventory is empty
            catch (System.Runtime.Serialization.SerializationException e)
            {
                inventory.Clear();
            }
        }
    }
}
