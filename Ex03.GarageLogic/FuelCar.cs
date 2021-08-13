namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxAmountOfFuel=45;
        private FuelEngine m_engine;

        public void AddFuel(float i_Fuel, FuelEngine.eFuelType i_FuelType)
        {
            m_engine.AddFuel(i_Fuel, i_FuelType);
        }

    }
}