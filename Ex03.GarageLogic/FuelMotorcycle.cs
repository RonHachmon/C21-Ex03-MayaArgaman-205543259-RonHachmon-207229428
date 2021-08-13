namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaximumAmountOfFuel = 6;
        private FuelEngine m_FuelEngine;
    }
}