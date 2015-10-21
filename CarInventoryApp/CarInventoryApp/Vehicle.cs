using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    abstract class Vehicle
    {
        private int nbWheel;
        public int NbWheel
        {
            get { return nbWheel; }
            set { nbWheel = value; }
        }

        private String brand;
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private String model;
        public String Model
        {
            get { return model; }
            set { model = value; }
        }


        public abstract String Drive();
        public abstract String Park();

    }
}
