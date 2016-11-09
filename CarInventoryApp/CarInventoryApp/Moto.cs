using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    [Serializable]
    class Moto:MotorVehicle
    {
        public bool Storage { get; set; }

        public Moto()
        {
            this.Brand = "Unknown";
            this.Model = "Unknown";
            this.HorsePower = 50;
            this.NbGearRatio = 5;
            this.NbWheel = 2;
            this.Storage = false;
        }

        public Moto(string brand, string model, int nbGearRatio, int horsePower, bool storage)
        {
            this.Brand = brand;
            this.Model = model;
            this.NbGearRatio = nbGearRatio;
            this.HorsePower = horsePower;
            this.NbWheel = 2;
            this.Storage = storage;
        }

        public virtual string OpenStorage()
        {
            return "Ouverture du rangement";
        }

        public virtual string CloseStorage()
        {
            return "Fermeture du rangement";
        }

        public override string Start()
        {
            return "Je démarre";
        }

        public override string Stop()
        {
            return "Je m'arrête";
        }

        public override string Drive()
        {
            return "Je roule";
        }

        public string Drive(int speed)
        {
            return "Je roule à " + speed + " km/h";
        }

        public override string Park()
        {
            return "Je me gare";
        }
        public override string ToString()
        {
            string textValue;
            textValue = "Je suis une moto de marque " + this.Brand + " de modèle " + this.Model + "\n";
            textValue += "Je possède une puissance de " + this.HorsePower + " chevaux, avec " + NbGearRatio + " vitesses.\n";
            if (Storage)
            {
                textValue += "Je possède un rangement";
            }
            return textValue;
        }
    }
}
