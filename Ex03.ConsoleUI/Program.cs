using System;
using System.Reflection;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
    public class Program
    {
        public static void Main()
        {
            UserInterface a = new UserInterface();
            a.Run();
            //bool validInput = false;
            //ElectricMotorcycle a = new ElectricMotorcycle("123");
            //MethodInfo[] allMethods = a.GetType().GetMethods();
            //string setMethod;
            //MethodInfo invokingMethod;
            //string input;
            //foreach (MethodInfo method in allMethods)
            //{
            //    if (method.Name.Contains("GetInput"))
            //    {
            //        try
            //        {
            //            Console.WriteLine(method.Name);
            //            invokingMethod = method;
            //            Console.WriteLine(invokingMethod.Invoke(a, new object[] { }));
            //            input = Console.ReadLine();
            //            setMethod = method.Name;
            //            setMethod=setMethod.Replace("Get", "Set");
            //            Console.WriteLine(setMethod);
            //            invokingMethod = a.GetType().GetMethod(setMethod);
            //            invokingMethod.Invoke(a, new object[] { input });
            //        }
            //        catch (ValueOutOfRangeException e)
            //        {
            //            Console.WriteLine("Number must be between {0} - {1}", e.MinValue, e.MaxValue);
            //        }
            //        catch (TargetInvocationException ex)
            //        {
            //            if (ex.InnerException is ValueOutOfRangeException)
            //            {
            //                ValueOutOfRangeException innerException = ex.InnerException as ValueOutOfRangeException;
            //                Console.WriteLine(string.Format("You must enter a number between {0}-{1}{2}", innerException.MinValue, innerException.MaxValue, Environment.NewLine));
            //            }
            //            else if (ex.InnerException is ArgumentException)
            //            {
            //                ArgumentException innerException = ex.InnerException as ArgumentException;
            //                Console.WriteLine("{0}{1}", innerException.Message, Environment.NewLine);
            //            }
            //        }
            //    }
            //}
        }
    }
}