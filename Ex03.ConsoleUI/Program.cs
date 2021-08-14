using System;
using Ex03.ConsoleUI;
namespace Ex03.GarageLogic
{
    public class Program
    {
        public static void Main()
        {
            Array array = Enum.GetValues(typeof(FuelEngine.eFuelType));
            foreach (FuelEngine.eFuelType fuelType in array)
            {
                Console.WriteLine(string.Format("for {0} Press {1}", fuelType.ToString(),fuelType.GetHashCode()));
            }
            
            //UserInterface a = new UserInterface();
            //a.Run();
        }
    }
}