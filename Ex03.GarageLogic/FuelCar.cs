using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxAmountOfFuel = 45;
        private FuelEngine m_FuelEngine;

        public FuelCar(string i_License) : base(i_License)
        {
            m_FuelEngine = new FuelEngine(k_MaxAmountOfFuel, k_FuelType);
        }

        public void AddFuel(float i_Fuel, FuelEngine.eFuelType i_FuelType)
        {
            m_FuelEngine.AddFuel(i_Fuel, i_FuelType);
            this.m_RemainingEnergy = (m_FuelEngine.CurrentAmountFuel / m_FuelEngine.MaxAmountOfFuel) * 100;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + m_FuelEngine.ToString());
        }

        public override List<string> BuildVehicleInputsList()
        {
            List<string> vehicleDictionary = base.BuildVehicleInputsList();
            FuelEngine.UpdateVehicleInputsList(vehicleDictionary);

            return vehicleDictionary;
        }

        public void SetEngine(string i_RemainingAmountOfFuel)
        {
            m_FuelEngine.UpdateEngine(i_RemainingAmountOfFuel);
            this.PercentageOfRemainingEnergy = (m_FuelEngine.CurrentAmountFuel / m_FuelEngine.MaxAmountOfFuel) * 100;
        }
    }
}