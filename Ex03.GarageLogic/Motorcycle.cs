using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            B1,
            AA,
            BB
        }

        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacity;
        private const int k_NumOfWheels = 2;
        private const int k_MaxAirPressure = 30;
        public Motorcycle(string i_License) : base(i_License, k_NumOfWheels, k_MaxAirPressure)
        {
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString() +
                "License Type: {0}{1}" +
                                 "Engine Capacity: {2}{1}",
                m_LicenseType, Environment.NewLine, m_EngineCapacity);
        }

        //public string GetInputEngineCapacity()
        //{
        //    string inputRequest = "Please enter engine capacity";
        //    return inputRequest;
        //}

        //public void SetInputEngineCapacity(string i_EngineCapacity)
        //{
        //    int engineCapacity = int.Parse(i_EngineCapacity);
        //    m_EngineCapacity = engineCapacity;
        //}
        //public void SetLicenseType()
        //{
        //    string output = "please enter a number between 1-4";
        //}

        public override List<string> BuildVehicleInputsList()
        {
            List<string> vehicleInputsList = base.BuildVehicleInputsList();

            vehicleInputsList.Add("the license type. choose one of 'A', 'A1', 'AA' or 'B':");
            vehicleInputsList.Add("the engine capacity of the motorcycle:");

            return vehicleInputsList;
        }

        public void SetEngineCapacity(string i_EngineCapacity)
        {
            int engineCapacity;

            if (int.TryParse(i_EngineCapacity, out engineCapacity) == false)
            {
                throw new FormatException("You must enter an integer number to the engine capacity.");
            }

            if (engineCapacity < 0)
            {
                throw new ArgumentException("engine's capacity can not be negative.");
            }

            m_EngineCapacity = engineCapacity;
        }

        public void SetLicenseType(string i_LicenseType)
        {
            Dictionary<string, eLicenseType> licenseTypeDictionary = new Dictionary<string, eLicenseType>();

            licenseTypeDictionary.Add("A", eLicenseType.A);
            licenseTypeDictionary.Add("A1", eLicenseType.AA);
            licenseTypeDictionary.Add("AA", eLicenseType.B1);
            licenseTypeDictionary.Add("B", eLicenseType.BB);

            if (!licenseTypeDictionary.ContainsKey(i_LicenseType))
            {
                throw new FormatException("you must choose one of 'A', 'AA', 'B1' or 'BB' to the license type.");
            }

            m_LicenseType = licenseTypeDictionary[i_LicenseType];
        }
    }
}