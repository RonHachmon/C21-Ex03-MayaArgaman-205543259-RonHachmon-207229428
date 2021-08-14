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

        private const int k_NumOfWheels = 2;
        private const int k_MaxAirPressure = 30;
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacity;

        public Motorcycle(string i_License) : base(i_License, k_NumOfWheels, k_MaxAirPressure)
        {

        }

        public void SetLicenseType()
        {
            string output = "please enter a number between 1-4";
        }

    }
}