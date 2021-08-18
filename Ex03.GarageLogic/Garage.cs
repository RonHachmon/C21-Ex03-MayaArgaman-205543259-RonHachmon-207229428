using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.VehicleDetails;
namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleDetails> r_VehiclesInGarage =
            new Dictionary<string, VehicleDetails>();

        public void AddVehicle(VehicleDetails i_CustomerDetails)
        {
            r_VehiclesInGarage.Add(i_CustomerDetails.Vehicle.License, i_CustomerDetails);
        }

        public List<string> GetAllLicensePlate()
        {
            List<string> allLicensePlateList = new List<string>();
            foreach (string licensePlate in r_VehiclesInGarage.Keys)
            {
                allLicensePlateList.Add(licensePlate);
            }

            return allLicensePlateList;
        }

        public List<string> GetLicensePlateByStatus(eCarStatusInGarage i_Status)
        {
            List<string> licensePlateList = new List<string>();
            foreach (string licensePlate in r_VehiclesInGarage.Keys)
            {
                if (r_VehiclesInGarage[licensePlate].CarStatus == i_Status)
                {
                    licensePlateList.Add(licensePlate);
                }
            }

            return licensePlateList;
        }

        public void ChangeCarStatus(string i_LicensePlate, eCarStatusInGarage i_Status)
        {
            r_VehiclesInGarage[i_LicensePlate].CarStatus = i_Status;
        }

        public void InflateAirToMax(string i_LicensePlate)
        {
            List<Wheel> wheels = r_VehiclesInGarage[i_LicensePlate].Vehicle.Wheels;
            float maxPressure = r_VehiclesInGarage[i_LicensePlate].Vehicle.Wheels[0].MaxAirPressure;
            foreach (Wheel wheel in wheels)
            {
                wheel.CurrentAirPressure = maxPressure;
            }
        }

        public bool CheckIfVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public void GetVehicleInGarage(string i_LicenseNumber, out Vehicle i_CurrentVehicle)
        {
            i_CurrentVehicle = null;
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                i_CurrentVehicle = r_VehiclesInGarage[i_LicenseNumber].Vehicle;
            }
        }

        public string ToString(string i_LicensePlate)
        {
           return this.r_VehiclesInGarage[i_LicensePlate].ToString();
        }
    }
}
