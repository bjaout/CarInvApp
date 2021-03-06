﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInventoryApp
{
    [Serializable]
    abstract class MotorVehicle:Vehicle, IMotorized
    {
        public enum DrivetrainType { RearWheel, FrontWheel };
        public enum GearboxType { Manual, Automatic };

        private int nbGearRation;
        public int NbGearRatio
        {
            get { return nbGearRation; }
            set { nbGearRation = value; }
        }

        private int horsePower;
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        
        private DrivetrainType drivetrain;
        public DrivetrainType Drivetrain
        {
            get { return drivetrain; }
            set { drivetrain = value; }
        }

        private GearboxType gearbox;
        public GearboxType Gearbox
        {
            get { return gearbox; }
            set { gearbox = value; }
        }

        public abstract string Start();
        public abstract string Stop();
    }
}
