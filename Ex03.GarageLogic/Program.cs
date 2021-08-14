 using System;
 using System.Reflection;

 namespace Ex03.GarageLogic
{
    public class Program
    {
        public static void Main()
        {
            Vehicle a = new ElectricCar("123");
            ElectricCar b = new ElectricCar("123");
            string className = a.ToString();
            Console.WriteLine(((ElectricCar)a).CurrentEnergyHours);

            if (className.Contains("Electric"))
            {
                Console.WriteLine("YAY");
            }

            MethodInfo FuelMethod = a.GetType().GetMethod("ChargeEngine");
            FuelMethod.Invoke(a, new object[] { 1.2f });
            Console.WriteLine(((ElectricCar)a).CurrentEnergyHours);

            //FuelEngine a = new FuelEngine();
            //a.CurrentAmountFuel = 10;
            //try
            //{
            //    a.AddFuel(20 , FuelEngine.eFuelType.Octan95);
            //    Console.WriteLine("Hello");

            //}
            //catch(Exception ValueOutOfRangeException)
            //{
            //    Console.WriteLine(ValueOutOfRangeException);
            //    throw;
            //}
        }
    }
}
