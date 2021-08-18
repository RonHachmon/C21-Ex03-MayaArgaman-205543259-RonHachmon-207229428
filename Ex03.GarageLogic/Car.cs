using System;
using System.Collections.Generic;

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

        public override List<string> BuildVehicleInputsList()
        {
            List<string> vehicleInputsList = base.BuildVehicleInputsList();

            vehicleInputsList.Add("the number of doors: 2,3,4 or 5:");
            vehicleInputsList.Add("the color of the car in small letters- red, black, white or silver:");

            return vehicleInputsList;
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString() +
                "Number of doors: {0}{1}" +
                "Color: {2}{1}",
                m_NumOfDoors, Environment.NewLine, m_CarColor);
        }

        public void SetCarColor(string i_CarColor)
        {
            Dictionary<string, eCarColor> carColorsDictionary = new Dictionary<string, eCarColor>();

            carColorsDictionary.Add("red", eCarColor.Red);
            carColorsDictionary.Add("black", eCarColor.Black);
            carColorsDictionary.Add("white", eCarColor.White);
            carColorsDictionary.Add("silver", eCarColor.Silver);

            if (!carColorsDictionary.ContainsKey(i_CarColor))
            {
                throw new FormatException("you must choose one of red, black, white or silver.");
            }

            m_CarColor = carColorsDictionary[i_CarColor];
        }

        public void SetNumOfDoors(string i_NumOfDoors)
        {
            int numOfDoorsInput;

            if (int.TryParse(i_NumOfDoors, out numOfDoorsInput) == false)
            {
                throw new FormatException("You must enter an integer to the num of doors.");
            }
            else if (!(k_MinDoors <= numOfDoorsInput && numOfDoorsInput <= k_MaxDoors))
            {
                throw new ValueOutOfRangeException(k_MinDoors, k_MaxDoors);
            }

            m_NumOfDoors = (eNumOfDoors)numOfDoorsInput;
        }
    }
}