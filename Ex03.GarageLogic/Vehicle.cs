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
            for(int i = 0; i < i_AmountOfWheels; i++)
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

        public override string ToString()
        {
            return string.Format(
                       "Vehicle model: {0}{3}" +
                       "License plate: {1}{3}" +
                       "Remaining energy: {2}{3}" +
                       r_Wheels[0].ToString(),
                       m_VehicleModel, m_LicensePlate,  m_RemainingEnergy, Environment.NewLine);
        }

        //public virtual List<string> BuildVehicleInputsList()
        //{
        //    List<string> vehicleInputsList = new List<string>();

        //    vehicleInputsList.Add("the model name of the vehicle:");
        //    Wheel.UpdateVehicleInputsList(vehicleInputsList);

        //    return vehicleInputsList;
        //}
    }
}