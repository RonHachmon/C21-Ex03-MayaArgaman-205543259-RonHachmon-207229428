using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine
    {
        private readonly float r_MaximumEnergyHours;
        private float m_CurrentEnergyHoursLeft;

        public float CurrentEneryHours
        {
            get
            {
                return m_CurrentEnergyHoursLeft;
            }

            set
            {
                if (value > r_MaximumEnergyHours)
                {
                    throw new ValueOutOfRangeException(0, r_MaximumEnergyHours);
                }

                m_CurrentEnergyHoursLeft = value;
            }
        }

        public void ChargeBattery(float i_BatteryCharge)
        {
            this.CurrentEneryHours += i_BatteryCharge;
        }
    }
}