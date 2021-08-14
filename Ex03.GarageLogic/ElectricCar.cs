namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxHoursOfEngine = 3.2f;
        private ElectricEngine m_ElectricEngine;

        public ElectricCar(string i_License) : base(i_License)
        {
            m_ElectricEngine = new ElectricEngine(k_MaxHoursOfEngine);
        }

        public float CurrentEnergyHours
        {
            get
            {
                return m_ElectricEngine.CurrentEnergyHours;
            }
        }

        public void ChargeEngine(float i_BatteryHours)
        {
            m_ElectricEngine.ChargeBattery(i_BatteryHours);
        }
    }
}