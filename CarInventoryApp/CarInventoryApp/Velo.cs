using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    [Serializable]
    class Velo : Vehicle
    {
        public bool Crutch { get; set; }

        public Velo()
        {
            this.Brand = "Unknown";
            this.Model = "Unknown";
            this.NbWheel = 2;
            this.Crutch = false;
        }

        public Velo(string brand, string model, bool crutch)
        {
            this.Brand = brand;
            this.Model = model;
            this.NbWheel = 2;
            this.Crutch = crutch;
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
            if (Crutch)
            {
                textValue += "Je possède une béquille.";
            }
            return textValue;
        }
    }
}
