using System;
using System.Collections.Generic;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private const int k_MinMenuSelectionRange = 1;
        private const int k_MaxMenuSelectionRange = 8;
        private readonly Garage r_Garage = new Garage();

        public enum eMenuSelection
        {
            InsertNewVehicle = 1,
            LicenseList,
            ModifyStatus,
            InflateAir,
            FuelVehicle,
            ChargeBattery,
            ViewAllInfo,
            Quit
        }

        public void Run()
        {
            bool keepRunning = true;
            eMenuSelection userChoice;
            printOptions();
            userChoice = (eMenuSelection)getUserChoice(k_MinMenuSelectionRange, k_MaxMenuSelectionRange);
            while (keepRunning)
            {
                switch (userChoice)
                {
                    case eMenuSelection.InsertNewVehicle:
                        insertVehicle();
                        break;

                    case eMenuSelection.LicenseList:
                        showListOfLicenseNumbers();
                        break;

                    case eMenuSelection.ModifyStatus:
                        changeVehicleStatusInGarage();
                        break;

                    case eMenuSelection.InflateAir:
                        inflateToMax();
                        break;

                    case eMenuSelection.FuelVehicle:
                        refuelVehicle();
                        break;

                    case eMenuSelection.ChargeBattery:
                        rechargeVehicle();
                        break;

                    case eMenuSelection.ViewAllInfo:
                        printVehicleDetails();
                        break;

                    case eMenuSelection.Quit:
                        Console.WriteLine("Have a nice day :)");
                        keepRunning = false;
                        break;
                }

                if (keepRunning)
                {
                    printOptions();
                    userChoice = (eMenuSelection)getUserChoice(k_MinMenuSelectionRange, k_MaxMenuSelectionRange);
                }
            }
        }

        private void printStatusOptions()
        {
            Console.WriteLine(
                @"
Please choose one of the following options : 
1. InRepair.
2. Repaired.
3. Paid. 
");
        }

        private void printOptionsofFilteringStatus()
        {
            Console.WriteLine(@"
Please choose one of the following options : 
1. All licenses
2. Select specific status   
");
        }

        private void printOptions()
        {
            Console.WriteLine(@"
Please choose one of the following options : 
1. Insert a new vehicle into the garage.
2. View the list of license numbers of the vehicles in the garage.
3. Modify a vehicle's status. 
4. Inflate the air of the wheels of the vehicles to the maximum.
5. Refuel a fuel-driven vehicle.
6. Recharge electric vehicle.
7. View full vehicle data by license number.
8. Quit program.
");
        }

        private VehicleDetails.eCarStatusInGarage getNewStatusFromUser()
        {
            bool keepRunning = true;
            printStatusOptions();
            VehicleDetails.eCarStatusInGarage userChoice = (VehicleDetails.eCarStatusInGarage)getUserChoice(1, 3);
            while (keepRunning)
            {
                switch (userChoice)
                {
                    case VehicleDetails.eCarStatusInGarage.InRepair:
                        keepRunning = false;
                        break;

                    case VehicleDetails.eCarStatusInGarage.Repaired:
                        keepRunning = false;

                        break;

                    case VehicleDetails.eCarStatusInGarage.Paid:
                        keepRunning = false;
                        break;
                }

                if (keepRunning)
                {
                    Console.WriteLine("Invalid Input, Please try again");
                    printStatusOptions();
                }
            }

            return userChoice;
        }

        private void showListOfLicenseNumbers()
        {
            printOptionsofFilteringStatus();
            int userChoice = getUserChoice(1, 2);
            if (userChoice == 1)
            {
                r_Garage.GetAllLicensePlate();
            }
            else if (userChoice == 2)
            {
                printStatusOptions();
                userChoice = getUserChoice(1, 3);
                r_Garage.GetLicensePlateByStatus((VehicleDetails.eCarStatusInGarage)userChoice);
            }
        }

        private string getLicenseFromUser()
        {
            bool validChoice = false;
            string licenseInput = null;

            Console.WriteLine(@"
Please enter the license number of the vehicle:");

            while (!validChoice)
            {
                try
                {
                    licenseInput = Console.ReadLine();
                    validChoice = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("{0}Invalid Input. License number must be with {1} letters.", Environment.NewLine, ex.MaxValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}Invalid Input. The license consists only upper cases lettes and digits.", Environment.NewLine);
                }
            }

            return licenseInput;
        }

        private void insertVehicle()
        {
            string lisencePlate = getLicenseFromUser();
            string customerPhoneNumber;
            string name;
            VehiclesBuilder.eVehicleType vehicleType;
            Vehicle currentVehicle = null;
            r_Garage.GetVehicleInGarage(lisencePlate, out currentVehicle);
            if (currentVehicle == null)
            {
                vehicleType = getVehicleType();
                currentVehicle = VehiclesBuilder.CreateVehicle(vehicleType, lisencePlate);
                insertDetailsToNewVehicle(currentVehicle);
                VehicleDetails customVehicleDetails = new VehicleDetails(currentVehicle);
                UpdateDetails(customVehicleDetails);
                r_Garage.AddVehicle(customVehicleDetails);
            }
            else
            {
                r_Garage.ChangeCarStatus(lisencePlate, VehicleDetails.eCarStatusInGarage.InRepair);
            }
        }

        private void UpdateDetails(VehicleDetails i_VehicleDetails)
        {
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Please enter your name");
                    i_VehicleDetails.NameOfOwner = Console.ReadLine();
                    Console.WriteLine("Please enter your phone number");
                    i_VehicleDetails.PhoneNumberOfOwner = Console.ReadLine();
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void insertDetailsToNewVehicle(Vehicle i_NewVehicle)
        {
            List<string> vehicleInputsList = i_NewVehicle.BuildVehicleInputsList();
            Type typeOfObject = i_NewVehicle.GetType();
            MethodInfo[] allMethodsOfObj = typeOfObject.GetMethods();
            Array.Reverse(allMethodsOfObj);
            int i = 0;
            foreach (MethodInfo method in allMethodsOfObj)
            {
                if (isSetMethod(method))
                {
                    bool isValidInputToMethod = false;
                    ParameterInfo[] allParams = method.GetParameters();

                    while (!isValidInputToMethod)
                    {
                        isValidInputToMethod = useSetMethod(i_NewVehicle, method, vehicleInputsList, allParams, ref i);
                    }
                }
            }
        }

        private bool useSetMethod(Vehicle i_NewVehicle, MethodInfo i_Method, List<string> i_VechileInputsList, ParameterInfo[] i_AllParams, ref int io_Index)
        {
            bool isValidInput = false;
            int j = io_Index;

            try
            {
                List<object> setMethodInputsList = new List<object>();

                foreach (ParameterInfo param in i_AllParams)
                {
                    Console.WriteLine("Please enter {0}", i_VechileInputsList[io_Index]);
                    setMethodInputsList.Add(Console.ReadLine());
                    io_Index++;
                }

                i_Method.Invoke(i_NewVehicle, setMethodInputsList.ToArray());
                isValidInput = true;
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException is ValueOutOfRangeException)
                {
                    ValueOutOfRangeException innerException = ex.InnerException as ValueOutOfRangeException;
                    Console.WriteLine("You must enter a number between {0}-{1}{2}", innerException.MinValue, innerException.MaxValue, Environment.NewLine);
                }
                else if (ex.InnerException is FormatException)
                {
                    FormatException innerException = ex.InnerException as FormatException;
                    Console.WriteLine("{0}{1}", innerException.Message, Environment.NewLine);
                }
                else if (ex.InnerException is ArgumentException)
                {
                    ArgumentException innerException = ex.InnerException as ArgumentException;
                    Console.WriteLine("{0}{1}", innerException.Message, Environment.NewLine);
                }

                io_Index = j;
            }

            return isValidInput;
        }

        private bool isSetMethod(MethodInfo i_Method)
        {
            string methodName = i_Method.Name;

            return methodName.Contains("Set");
        }

        private void changeVehicleStatusInGarage()
        {
            string lisencePlate = getLicenseFromUser();
            if (r_Garage.CheckIfVehicleInGarage(lisencePlate))
            {
                VehicleDetails.eCarStatusInGarage newStatus = getNewStatusFromUser();
                r_Garage.ChangeCarStatus(lisencePlate, newStatus);
            }
        }

        private void inflateToMax()
        {
            string lisencePlate = getLicenseFromUser();
            if (r_Garage.CheckIfVehicleInGarage(lisencePlate))
            {
                r_Garage.InflateAirToMax(lisencePlate);
            }
        }

        private void printVehicleDetails()
        {
            string licenseNumber = getLicenseFromUser();
            Console.WriteLine(r_Garage.ToString(licenseNumber));
        }

        private void rechargeVehicle()
        {
            float amountToCharge;
            string licenseNumber = getLicenseFromUser();
            bool isValid = false;
            Vehicle currentVehicle;
            r_Garage.GetVehicleInGarage(licenseNumber, out currentVehicle);
            MethodInfo engineFillMethod = currentVehicle.GetType().GetMethod("ChargeEngine");
            if (engineFillMethod != null)
            {
                while (!isValid)
                {
                    try
                    {
                        Console.WriteLine("Please enter Amount of Hours to Charge");
                        amountToCharge = getAmountOfEnergyToFill();
                        engineFillMethod.Invoke(currentVehicle, new object[] { amountToCharge });
                        isValid = true;
                        Console.WriteLine("Vehicle successfully charged");
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException is ValueOutOfRangeException)
                        {
                            ValueOutOfRangeException innerException = ex.InnerException as ValueOutOfRangeException;
                            Console.WriteLine("You must enter a number between {0}-{1}{2}", innerException.MinValue, innerException.MaxValue, Environment.NewLine);
                        }
                        else if (ex.InnerException is ArgumentException)
                        {
                            ArgumentException innerException = ex.InnerException as ArgumentException;
                            Console.WriteLine("{0}{1}", innerException.Message, Environment.NewLine);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Vehicle doesn't have electric engine,returning to main menu");
            }
        }

        private float getAmountOfEnergyToFill()
        {
            return float.Parse(Console.ReadLine());
        }

        private void refuelVehicle()
        {
            float amountToCharge;
            string licenseNumber = getLicenseFromUser();
            bool isValid = false;
            Vehicle currentVehicle;
            FuelEngine.eFuelType fuelType;
            r_Garage.GetVehicleInGarage(licenseNumber, out currentVehicle);
            MethodInfo engineFillMethod = currentVehicle.GetType().GetMethod("AddFuel");
            if (engineFillMethod != null)
            {
                while (!isValid)
                {
                    try
                    {
                        Console.WriteLine("Please enter Amount of Fuel to Fill");
                        amountToCharge = getAmountOfEnergyToFill();
                        fuelType = getFuelType();
                        engineFillMethod.Invoke(currentVehicle, new object[] { amountToCharge, fuelType });
                        isValid = true;
                        Console.WriteLine("Vehicle successfully charged");
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException is ValueOutOfRangeException)
                        {
                            ValueOutOfRangeException innerException = ex.InnerException as ValueOutOfRangeException;
                            Console.WriteLine("You must enter a number between {0}-{1}{2}", innerException.MinValue, innerException.MaxValue, Environment.NewLine);
                        }
                        else if (ex.InnerException is ArgumentException)
                        {
                            ArgumentException innerException = ex.InnerException as ArgumentException;
                            Console.WriteLine("{0}{1}", innerException.Message, Environment.NewLine);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Vehicle doesn't have fuel engine,returning to main menu");
            }
        }

        private VehiclesBuilder.eVehicleType getVehicleType()
        {
            VehiclesBuilder.eVehicleType userVehicleType;
            Array array = Enum.GetValues(typeof(VehiclesBuilder.eVehicleType));
            Console.WriteLine("Please choose vehicle type:");
            foreach (VehiclesBuilder.eVehicleType vehicleType in array)
            {
                Console.WriteLine("for {0} Press {1}", vehicleType.ToString(), vehicleType.GetHashCode());
            }

            userVehicleType = (VehiclesBuilder.eVehicleType)getUserChoice(VehiclesBuilder.MinAmountOfVehicle, VehiclesBuilder.MaxAmountOfVehicle);

            return userVehicleType;
        }

        private FuelEngine.eFuelType getFuelType()
        {
            FuelEngine.eFuelType userFuelType;
            Array array = Enum.GetValues(typeof(FuelEngine.eFuelType));
            Console.WriteLine("Please choose fuel type:");
            foreach (FuelEngine.eFuelType fuelType in array)
            {
                Console.WriteLine("for {0} Press {1}", fuelType.ToString(), fuelType.GetHashCode());
            }

            userFuelType = (FuelEngine.eFuelType)getUserChoice(k_MinMenuSelectionRange, k_MaxMenuSelectionRange);
            return userFuelType;
        }

        private int getUserChoice(int i_StartRange, int i_EndRange)
        {
            Console.WriteLine("Please enter a number between {0}-{1}", i_StartRange, i_EndRange);
            string userChoice;
            bool validInput = false;
            int input = 0;
            do
            {
                userChoice = Console.ReadLine();
                try
                {
                    input = int.Parse(userChoice);
                    if (i_StartRange <= input && input <= i_EndRange)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("This number is not between {0}-{1}", i_StartRange, i_EndRange);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input. Please enter an integer.");
                }
            }
            while (!validInput);

            return input;
        }
    }
}