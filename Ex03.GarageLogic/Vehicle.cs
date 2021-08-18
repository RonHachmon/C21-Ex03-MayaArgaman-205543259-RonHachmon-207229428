using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_VehicleModel;
        protected string m_LicensePlate;
        protected float m_RemainingEnergy;
        protected List<Wheel> r_Wheels = new List<Wheel>();

        public Vehicle(string i_License, int i_AmountOfWheels, float i_MaxAirPressure)
        {
            m_LicensePlate = i_License;
            for (int i = 0; i < i_AmountOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public string License
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public string ModelName
        {
            get
            {
                return m_VehicleModel;
            }

            private set
            {
                m_VehicleModel = value;
            }
        }

        public float PercentageOfRemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }

            set
            {
                m_RemainingEnergy = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                       "Vehicle model: {0}{3}" +
                       "License plate: {1}{3}" +
                       "Remaining energy: {2}{3}" +
                       r_Wheels[0].ToString(),
                       m_VehicleModel, m_LicensePlate,  m_RemainingEnergy, Environment.NewLine);
        }

        public void SetModelName(string i_ModelName)
        {
            foreach (char ch in i_ModelName)
            {
                if (!(char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)))
                {
                    throw new FormatException("You must enter characters or digits to the model name.");
                }
            }

            this.ModelName = i_ModelName;
        }

        //***
        public void SetListOfWheels(string i_ManufacturerName, string i_CurrentAirPressure)
        {
            foreach (char ch in i_ManufacturerName)
            {
                if (!(char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)))
                {
                    throw new FormatException("You must enter characters or digits to the manufacturer name.");
                }
            }

            float currAirPressureInput;
            if (float.TryParse(i_CurrentAirPressure, out currAirPressureInput) == false)
            {
                throw new FormatException("You must enter a number to the current air pressure.");
            }

            if (!(currAirPressureInput >= 0 && currAirPressureInput <= r_Wheels[0].MaxAirPressure))
            {
                throw new ValueOutOfRangeException(0, r_Wheels[0].MaxAirPressure);
            }

            for (int i = 0; i < r_Wheels.Count; i++)
            {
                r_Wheels[i].Manufacture = i_ManufacturerName;
                r_Wheels[i].CurrentAirPressure = currAirPressureInput;
            }
        }

        //***
        public virtual List<string> BuildVehicleInputsList()
        {
            List<string> vehicleInputsList = new List<string>();

            vehicleInputsList.Add("the model name of the vehicle:");
            Wheel.UpdateVehicleInputsList(vehicleInputsList);

            return vehicleInputsList;
        }
    }
}