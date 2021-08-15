using System;

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

        public override string ToString()
        {
            return string.Format(base.ToString() + m_ElectricEngine.ToString());
        }

        public string GetInputEngineCurrentHours()
        {
            string inputRequest = "Please enter current hours left on engine ";
            return inputRequest;
        }

        public void SetInputEngineCurrentHours(string i_currentEngineHoursLeft)
        {
            Console.WriteLine("Hello");
            float currentEngineHoursLeft = float.Parse(i_currentEngineHoursLeft);
            m_ElectricEngine.CurrentEnergyHours = currentEngineHoursLeft;
        }
    }
}
