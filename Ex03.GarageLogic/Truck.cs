using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaxAirPressure = 26;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private const float k_MaximumAmountOfFuel = 120;
        private bool m_TransportHazardousMaterials;
        private float m_CargoCapacity;
        private FuelEngine m_FuelEngine;

        public Truck(string i_License) : base(i_License, k_NumOfWheels, k_MaxAirPressure)
        {

            m_FuelEngine = new FuelEngine(k_MaximumAmountOfFuel, k_FuelType);
        }

        public void AddFuel(float i_Fuel, FuelEngine.eFuelType i_FuelType)
        {
            m_FuelEngine.AddFuel(i_Fuel, i_FuelType);
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString() + "Contains Hazardous items: {0}{2}" +
                                                 "Cargo capacity: {1}{2}" +
                                                 m_FuelEngine.ToString(),
                m_TransportHazardousMaterials, m_CargoCapacity, Environment.NewLine);
        }
    }
}