namespace Ex03.GarageLogic
{
    public class VehicleDetails
    {
        public enum eCarStatusInGarage
        {
            InRepair = 1, Repaired, Paied
        }

        private eCarStatusInGarage m_CarStatus;
        private Vehicle m_Vehicle;
        private string m_NameOfOwner;
        private string m_PhoneNumberOfOwner;

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

    }
}