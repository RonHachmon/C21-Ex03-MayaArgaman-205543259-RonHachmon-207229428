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
        }
    }
}
