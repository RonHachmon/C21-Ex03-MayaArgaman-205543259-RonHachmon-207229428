using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private const int k_MinFuelRange = 1;
        private const int k_MaxFuelRange = 4;
        private readonly eFuelType r_FuelType;
        private readonly float r_MaximumAmountOfFuel;
        private float m_CurrentAmountFuel;

        public FuelEngine(float i_MaximumAmountOfFuel, eFuelType i_FuelType)
        {
            r_FuelType = i_FuelType;
            r_MaximumAmountOfFuel = i_MaximumAmountOfFuel;
        }

        public int MinFuelRange
        {
            get
            {
                return k_MinFuelRange;
            }
        }

        public int MaxFuelRange
        {
            get
            {
                return k_MaxFuelRange;
            }
        }

        public float CurrentAmountFuel
        {
            get
            {
                return m_CurrentAmountFuel;
            }

            set
            {
                if (value > r_MaximumAmountOfFuel)
                {
                    throw new ValueOutOfRangeException(0, r_MaximumAmountOfFuel- m_CurrentAmountFuel);
                }

                m_CurrentAmountFuel = value;
            }
        }

        public void AddFuel(float i_AmountOfFuel, eFuelType i_FuelType)
        {
            if (i_FuelType == r_FuelType)
            {
               this.CurrentAmountFuel += i_AmountOfFuel;
            }
            else
            {
                throw new ArgumentException("Error - You entered a wrong fuel type.");
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Fuel type: {0}{3}" +
                                 "Max amount of fuel: {1}{3}" +
                                 "Current amount of fuel: {2}{3}",
                r_FuelType, r_MaximumAmountOfFuel, m_CurrentAmountFuel, Environment.NewLine);
        }
    }
}