using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_Manufacture;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public string Manufacture
        {
            get
            {
                return m_Manufacture;
            }

            set
            {
                m_Manufacture = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void AddPressure(float i_PressureToAdd)
        {
            m_CurrentAirPressure += i_PressureToAdd;
        }

        public override string ToString()
        {
            return string.Format(
                "Wheel manufacture: {0}{3}" +
                "Max air pressure: {1}{3}" +
                "Current air pressure {2}{3}",
                m_Manufacture, r_MaxAirPressure, m_CurrentAirPressure, Environment.NewLine);
        }
    }
}