namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxHoursOfEngine = 3.2f;
        private ElectricEngine m_ElectricEngine;

        public void AddEngine(float i_BatteryHours)
        {
            m_ElectricEngine.ChargeBattery(i_BatteryHours);
        }

    }
}