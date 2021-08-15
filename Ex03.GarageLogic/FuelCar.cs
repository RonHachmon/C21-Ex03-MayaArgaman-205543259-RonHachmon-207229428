namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxAmountOfFuel = 45;
        private FuelEngine m_Engine;

        public FuelCar(string i_License) : base(i_License)
        {
            m_Engine = new FuelEngine(k_MaxAmountOfFuel, k_FuelType);
        }

        public void AddFuel(float i_Fuel, FuelEngine.eFuelType i_FuelType)
        {
            m_Engine.AddFuel(i_Fuel, i_FuelType);
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + m_Engine.ToString());
        }
    }
}