namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxHoursOfEngine = 1.8f;
        private ElectricEngine m_ElectricEngine;

        public ElectricMotorcycle(string i_License) : base(i_License)
        {
            m_ElectricEngine = new ElectricEngine(k_MaxHoursOfEngine);
        }

        public void ChargeEngine(float i_BatteryHours)
        {
            m_ElectricEngine.ChargeBattery(i_BatteryHours);
        }
    }
}