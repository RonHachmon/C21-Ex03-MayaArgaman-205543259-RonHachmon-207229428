namespace Ex03.GarageLogic
{
    public class VehiclesBuilder
    {
        public enum eVehicleType
        {
            FuelCar = 1,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }
        private const int k_MinAmountOfVehicle = 1;
        private const int k_MaxAmountOfVehicle = 5;

        public static int MinAmountOfVehicle
        {
            get
            {
                return k_MinAmountOfVehicle;
            }
        }

        public static int MaxAmountOfVehicle
        {
            get
            {
                return k_MaxAmountOfVehicle;
            }
        }

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_Lisence)
        {
            Vehicle vehicle;

            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                vehicle = new ElectricCar(i_Lisence);
            }
            else if (i_VehicleType == eVehicleType.FuelCar)
            {
                vehicle = new FuelCar(i_Lisence);
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                vehicle = new ElectricMotorcycle(i_Lisence);
            }
            else if (i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                vehicle = new FuelMotorcycle(i_Lisence);
            }
            else
            {
                vehicle = new Truck(i_Lisence);
            }

            return vehicle;
        }
    }
}