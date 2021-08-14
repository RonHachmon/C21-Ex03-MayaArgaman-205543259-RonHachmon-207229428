using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_VehicleModel;
        protected string m_LicensePlate;
        protected float m_RemainingEnergy;
        protected readonly List<Wheel> r_Wheels = new List<Wheel>();

        public Vehicle(string i_License, int i_AmountOfWheels, float i_MaxAirPressure)
        {
            m_LicensePlate = i_License;
            for(int i = 0; i < i_AmountOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }
    }
}