using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    class Car:MotorVehicle
    {
        public enum TrunkType { Tailgate, Hatch, None}

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

        public virtual String OpenTrunk()
        {
            throw new NotImplementedException();
        }

        public virtual String CloseTrunk()
        {
            throw new NotImplementedException();
        }

        public override string Start()
        {
            throw new NotImplementedException();
        }

        public override string Stop()
        {
            throw new NotImplementedException();
        }

        public override string Drive()
        {
            throw new NotImplementedException();
        }

        public override string Park()
        {
            throw new NotImplementedException();
        }
    }
}
