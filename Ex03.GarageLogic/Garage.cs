using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        //public enum eCarDetails
        //{
        //    NameOfOwner, PhoneNumberOfOwner, CarStatusInGarage
        //}

        public enum eCarStatusInGarage
        {
            InRepair = 1, Repaired, Paied
        }

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

        public void GetVehicleInGarage(string licenseNumber, out Vehicle currentVehicle)
        {
            throw new NotImplementedException();
        }
    }
}