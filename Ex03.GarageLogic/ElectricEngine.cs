using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine
    {
        private readonly float r_MaximumEnergyHours;
        private float m_CurrentEnergyHoursLeft;

        public ElectricEngine(float i_MaximumEnergyHours)
        {
            r_MaximumEnergyHours = i_MaximumEnergyHours;
        }

        public static void UpdateVehicleInputsList(List<string> i_VehicleInputsList)
        {
            i_VehicleInputsList.Add("the remaining battery time:");
        }

        public float CurrentEnergyHours
        {
            get
            {
                return m_CurrentEnergyHoursLeft;
            }

            set
            {
                if (value > r_MaximumEnergyHours || value < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaximumEnergyHours - m_CurrentEnergyHoursLeft);
                }

                m_CurrentEnergyHoursLeft = value;
            }
        }

        public float MaxEnergyHours
        {
            get
            {
                return r_MaximumEnergyHours;
            }
        }

        public void ChargeBattery(float i_BatteryCharge)
        {
            this.CurrentEnergyHours += i_BatteryCharge;
        }

        public override string ToString()
        {
            return string.Format("Engine Max hours {0}{2}" + "Current hours left {1}", r_MaximumEnergyHours, m_CurrentEnergyHoursLeft, Environment.NewLine);
        }

        public void UpdateEngine(string i_RemainingBatteryTime)
        {
            float remainingAmountOfEnergy;

            if (float.TryParse(i_RemainingBatteryTime, out remainingAmountOfEnergy) == false)
            {
                throw new FormatException("You must enter a number to the current amount of fuel.");
            }

            this.CurrentEnergyHours = remainingAmountOfEnergy;
        }
    }
}