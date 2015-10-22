using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    [Serializable]
    class Car:MotorVehicle
    {
        public enum TrunkType { Tailgate = 2, Hatch = 1, None = 0}

        private int nbDoors;
        public int NbDoors
        {
            get { return nbDoors; }
            set { nbDoors = value; }
        }

        private TrunkType trunk;
        public TrunkType Trunk
        {
            get { return trunk; }
            set { trunk = value; }
        }

        public Car()
        {
            this.Brand = "Unknown";
            this.Model = "Unknown";
            this.HorsePower = 65;
            this.NbGearRatio = 5;
            this.NbDoors = 5;
            this.NbWheel = 4;
            this.Trunk = TrunkType.Hatch;
        }

        public Car(string brand, string model, int nbGearRatio, int nbDoors, int horsePower, TrunkType trunk)
        {
            this.Brand = brand;
            this.Model = model;
            this.NbGearRatio = nbGearRatio;
            this.NbDoors = nbDoors;
            this.HorsePower = horsePower;
            this.Trunk = trunk;
            this.NbWheel = 4;
        }

        public virtual string OpenTrunk()
        {
            return "Ouverture du coffre";
        }

        public virtual string CloseTrunk()
        {
            return "Fermeture du coffre";
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
            string typeTrunk="inconnu";
            switch(this.Trunk)
            {
                case TrunkType.Hatch:
                    typeTrunk = "coffre";
                    break;

                case TrunkType.Tailgate:
                    typeTrunk = "hayon";
                    break;

                case TrunkType.None:
                    typeTrunk = "inconnu";
                    break;
            }
            textValue = "Je suis une voiture de marque " + this.Brand + " de modèle " + this.Model + " avec " + this.NbDoors + " portes.\n";
            textValue += "Je possède une puissance de " + this.HorsePower + " chevaux, avec " + NbGearRatio + " vitesses.\n";
            textValue += "Mon coffre est de type " + typeTrunk;
            return textValue;
        }
    }
}
