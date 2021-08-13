 using System;

namespace Ex03.GarageLogic
{
    public class Program
    {
        public static void Main()
        {
            FuelEngine a = new FuelEngine();
            a.CurrentAmountFuel = 10;
            try
            {
                a.AddFuel(20 , FuelEngine.eFuelType.Octan95);
                Console.WriteLine("Hello");

            }
            catch(Exception ValueOutOfRangeException)
            {
                Console.WriteLine(ValueOutOfRangeException);
                throw;
            }
        }
    }
}
