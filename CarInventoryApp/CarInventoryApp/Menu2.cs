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
            Console.WriteLine("\t- 1 : Ajouter une Voiture");
            Console.WriteLine("\t- 2 : Ajouter une Moto");
            Console.WriteLine("\t- 3 : Ajouter un Vélo");
            Console.WriteLine("\t- 4 : Supprimer un véhicule");
            Console.WriteLine("\t- 5 : Vider la liste des véhicules");
            Console.WriteLine("\t- 6 : Quitter le programme");
        }

        /// <summary>
        /// Get all car data necessary to add it in the inventory
        /// </summary>
        /// <returns>Boolean to indicate that data is ok</returns>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="nbDoors">Number of doors (trunk count has one)</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="trunk">Trunk type</param>
        private bool GetCarDatas(out string brand, out string model, out int nbGearRatio, out int nbDoors, out int horsePower, out Car.TrunkType trunk)
        {
            bool ok = true;
            bool stop = false;
            nbGearRatio = 0;
            nbDoors = 0;
            horsePower = 0;
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
            try
            {
                nbGearRatio = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ok = false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le nombre de portes");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                nbDoors = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ok = false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la puissance du véhicule");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                horsePower = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ok = false;
            }
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
            return ok;
        }

        /// <summary>
        /// Get all moto data necessary to add it in the inventory
        /// </summary>
        /// <returns>Boolean to indicate if data is ok</returns>
        /// <param name="brand">Moto brand</param>
        /// <param name="model">Moto model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="storage">Do moto storage exist ?</param>
        private bool GetMotoDatas(out string brand, out string model, out int nbGearRatio, out int horsePower, out bool storage)
        {
            bool ok = true;
            bool stop = false;
            nbGearRatio = 0;
            horsePower = 0;
            string readData = "";
            storage = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la marque de la moto");
            Console.ForegroundColor = ConsoleColor.White;
            brand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le modèle de la moto");
            Console.ForegroundColor = ConsoleColor.White;
            model = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le nombre de vitesses");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                nbGearRatio = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ok = false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la puissance du véhicule");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                horsePower = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ok = false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez indiquer si la moto à un stockage : Y pour oui, N pour non");
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                readData = Console.ReadLine();
                switch (readData)
                {
                    case "Y":
                        storage = true;
                        stop = true;
                        break;

                    case "N":
                        storage = false;
                        stop = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Veuillez saisir une information valide : Y pour oui ou N pour non");
                        stop = false;
                        break;
                }
            } while (!stop);
            return ok;
        }

        /// <summary>
        /// Get all moto data necessary to add it in the inventory
        /// </summary>
        /// <param name="brand">Moto brand</param>
        /// <param name="model">Moto model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="crutch">Do crutch crutch exist ?</param>
        private void GetVeloDatas(out string brand, out string model, out bool crutch)
        {
            bool stop = false;
            string readData = "";
            crutch = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir la marque du vélo");
            Console.ForegroundColor = ConsoleColor.White;
            brand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez saisir le modèle du vélo");
            Console.ForegroundColor = ConsoleColor.White;
            model = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Veuillez indiquer si le vélo à une béquille : Y pour oui, N pour non");
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                readData = Console.ReadLine();
                switch (readData)
                {
                    case "Y":
                        crutch = true;
                        stop = true;
                        break;

                    case "N":
                        crutch = false;
                        stop = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Veuillez saisir une information valide : Y pour oui ou N pour non");
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
                Console.WriteLine(elem);
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
        private void AddCar(string brand, string model, int nbGearRatio, int nbDoors, int horsePower, Car.TrunkType trunk)
        {
            inventory.Add(new Car(brand, model, nbGearRatio, nbDoors, horsePower, trunk));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Véhicule ajouté");
        }

        /// <summary>
        /// Add a specific moto to inventory
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="nbGearRatio">Number of speed on gearbox</param>
        /// <param name="horsePower">Motor horse power</param>
        /// <param name="storage">Does moto have a storage ?</param>
        private void AddMoto(string brand, string model, int nbGearRatio, int horsePower, bool storage)
        {
            inventory.Add(new Moto(brand, model, nbGearRatio, horsePower, storage));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Véhicule ajouté");
        }

        /// <summary>
        /// Add a specific vélo to inventory
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="crutch">Does velo have a crutch ?</param>
        private void AddVelo(string brand, string model, bool crutch)
        {
            inventory.Add(new Velo(brand, model, crutch));
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
