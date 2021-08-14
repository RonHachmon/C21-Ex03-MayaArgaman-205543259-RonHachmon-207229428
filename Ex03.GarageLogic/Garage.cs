using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static Ex03.GarageLogic.VehicleDetails;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        //public enum eCarDetails
        //{
        //    NameOfOwner, PhoneNumberOfOwner, CarStatusInGarage
        //}

       // public enum eCarStatusInGarage
        //{
          //  InRepair = 1, Repaired, Paied
        //}

        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;
        private readonly Dictionary<string, VehicleDetails> r_VehiclesInGarage = new Dictionary<string, VehicleDetails>();


        

        public void AddVehicle(string i_LicensePlate)
        {
            VehicleDetails temp;
            if(r_VehiclesInGarage.TryGetValue(i_LicensePlate, out temp))
            {
                temp.CarStatus = VehicleDetails.eCarStatusInGarage.InRepair;
                throw new ArgumentException("License already Exist");
            }
            else
            {
                r_VehiclesInGarage.Add(i_LicensePlate, temp);
            }
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

        public List<string> GetLicensePlateByStatus(eCarStatusInGarage status)
        {
            List<string> licensePlateList = new List<string>();
            foreach (string licensePlate in r_VehiclesInGarage.Keys)
            {
                if(r_VehiclesInGarage[licensePlate].CarStatus == status)
                {
                    licensePlateList.Add(licensePlate);
                }
            }

            return licensePlateList;
        }

        public void ChangeCarStatus(string licensePlate, eCarStatusInGarage status)
        {
            r_VehiclesInGarage[licensePlate].CarStatus = status;
        }

        public void InflateAirToMax(string licensePlate)
        {
            List<Wheel> wheels = r_VehiclesInGarage[licensePlate].Vehicle.Wheels;
            float maxPressure = r_VehiclesInGarage[licensePlate].Vehicle.Wheels[0].MaxAirPressure;
            foreach (Wheel wheel in wheels)
            {
                wheel.CurrentAirPressure = maxPressure;
            }
        }
    }
}