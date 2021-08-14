namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eNumOfDoors
        {
            twoDoors = 2,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        protected const int k_MinDoors = 2;
        protected const int k_MaxDoors = 5;
        protected const int k_NumOfWheels = 4;
        protected const int k_MaxAirPressure = 32;
        protected eNumOfDoors m_NumOfDoors;
        protected eCarColor m_CarColor;

        public Car(string i_License) : base(i_License, k_NumOfWheels, k_MaxAirPressure)
        {
        }
    }
}