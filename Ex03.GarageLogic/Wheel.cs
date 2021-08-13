namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_Manufacture;
        private float m_CurrentAirPressure;

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
    }
}