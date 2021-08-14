namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }

        protected const int k_NumOfWheels = 2;
        protected const int k_MaxAirPressure = 30;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_License) : base(i_License, k_NumOfWheels, k_MaxAirPressure)
        {

        }

    }
}