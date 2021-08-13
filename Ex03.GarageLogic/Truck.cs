namespace Ex03.GarageLogic
{
    public class Truck :Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaxAirPressure = 26;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private const float k_MaximumAmountOfFuel = 120;
        private bool m_TransportHazardousMaterials;
        private float m_CargoCapacity;
        private FuelEngine m_FuelEngine;

    }
}