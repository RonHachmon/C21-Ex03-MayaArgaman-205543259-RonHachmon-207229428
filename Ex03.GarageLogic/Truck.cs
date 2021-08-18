using System;
using System.Collections.Generic;

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
            this.m_RemainingEnergy = (m_FuelEngine.CurrentAmountFuel / m_FuelEngine.MaxAmountOfFuel) * 100;
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString() + "Contains Hazardous items: {0}{2}" +
                                                 "Cargo capacity: {1}{2}" +
                                                 m_FuelEngine.ToString(),
                m_TransportHazardousMaterials, m_CargoCapacity, Environment.NewLine);
        }

        public override List<string> BuildVehicleInputsList()
        {
            List<string> vehicleInputsList = base.BuildVehicleInputsList();

            vehicleInputsList.Add("1 if it transport hazardous materials. else, enter 2.");
            vehicleInputsList.Add("the cargo capacity of the truck");
            FuelEngine.UpdateVehicleInputsList(vehicleInputsList);

            return vehicleInputsList;
        }

        public void SetEngine(string i_RemainingAmountOfFuel)
        {
            m_FuelEngine.UpdateEngine(i_RemainingAmountOfFuel);
            this.PercentageOfRemainingEnergy = (m_FuelEngine.CurrentAmountFuel / m_FuelEngine.MaxAmountOfFuel) * 100;
        }

        public void SetCargoCapacity(string i_CargoCapacity)
        {
            float cargoCapacity;

            if (float.TryParse(i_CargoCapacity, out cargoCapacity) == false)
            {
                throw new FormatException("You must enter a number to the cargo capacity.");
            }

            if (cargoCapacity < 0)
            {
                throw new ArgumentException("cargo's capacity can not be negative.");
            }

            m_CargoCapacity = cargoCapacity;
        }

        public void SetTransportHazardousMaterials(string i_IsTransportHazardousMaterials)
        {
            int isTransportHazardousMaterials;

            if (int.TryParse(i_IsTransportHazardousMaterials, out isTransportHazardousMaterials) == false)
            {
                throw new FormatException("Invalid input - You must write an integer number.");
            }

            if (isTransportHazardousMaterials == 1)
            {
                m_TransportHazardousMaterials = true;
            }
            else if (isTransportHazardousMaterials == 2)
            {
                m_TransportHazardousMaterials = false;
            }
            else
            {
                throw new ArgumentException("Invalid input - wrong choice. You must enter 1 if it transport hazardous materials. else, 2.");
            }
        }
    }
}