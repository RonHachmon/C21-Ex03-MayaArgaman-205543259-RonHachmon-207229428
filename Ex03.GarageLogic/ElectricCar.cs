using System.Collections.Generic;

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
            this.m_RemainingEnergy = (m_ElectricEngine.CurrentEnergyHours / m_ElectricEngine.MaxEnergyHours) * 100;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + m_ElectricEngine.ToString());
        }

        //***
        public override List<string> BuildVehicleInputsList()
        {
            List<string> vehicleInputsList = base.BuildVehicleInputsList();
            ElectricEngine.UpdateVehicleInputsList(vehicleInputsList);

            return vehicleInputsList;
        }

        public void SetEngine(string i_RemainingBatteryTime)
        {
            m_ElectricEngine.UpdateEngine(i_RemainingBatteryTime);
            this.PercentageOfRemainingEnergy = (m_ElectricEngine.CurrentEnergyHours / m_ElectricEngine.MaxEnergyHours) * 100;
        }
    }
}