using System;

namespace Ex03.GarageLogic
{
    public class VehicleDetails
    {
        public enum eCarStatusInGarage
        {
            InRepair = 1,
            Repaired,
            Paid
        }

        private eCarStatusInGarage m_CarStatus;
        private Vehicle m_Vehicle;
        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;

        public VehicleDetails(Vehicle i_OwnerVehicle, string i_NameOfOwner, string i_PhoneNumberOfOwner)
        {
            Vehicle = i_OwnerVehicle;
            NameOfOwner = i_NameOfOwner;
            PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            m_CarStatus = eCarStatusInGarage.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public eCarStatusInGarage CarStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }

        public string PhoneNumberOfOwner
        {
            get
            {
                return m_PhoneNumberOfOwner;
            }

            set
            {
                m_PhoneNumberOfOwner = value;
            }
        }

        public string NameOfOwner
        {
            get
            {
                return m_NameOfOwner;
            }

            set
            {
                m_NameOfOwner = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Owner name {0}{1}" +
                "Owner Phone {2}{1}" +
                Vehicle.ToString(),
                m_NameOfOwner, Environment.NewLine, m_PhoneNumberOfOwner);
        }

    }
}