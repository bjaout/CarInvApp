using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    [Serializable]
    abstract class Vehicle
    {
        private int nbWheel;
        public int NbWheel
        {
            get { return nbWheel; }
            set { nbWheel = value; }
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public abstract string Drive();
        public abstract string Park();

    }
}
