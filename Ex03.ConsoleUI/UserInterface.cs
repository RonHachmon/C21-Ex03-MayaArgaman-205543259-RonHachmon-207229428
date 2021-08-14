﻿using System;
using Ex03.GarageLogic;
using System.Reflection;
namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
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

        private const int k_MinMenuSelectionRange = 1;
        private const int k_MaxMenuSelectionRange = 8;
        private Garage m_Garage = new Garage();

        public void Run()
        {
            bool keepRunning = true;
            eMenuSelection userChoice;
            printOptions();
            userChoice = (eMenuSelection) getUserChoice(k_MinMenuSelectionRange, k_MaxMenuSelectionRange);
            while (keepRunning)
            {
                switch (userChoice)
                {
                    case eMenuSelection.InsertNewVehicle:
                        insertVehicle();
                        break;

                    case eMenuSelection.LicenseList:
                        viewListOfLicenseNumbers();
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
                    //Vehicle.CheckLicenseLength(licenseInput);
                    //Vehicle.CheckLicenseLetters(licenseInput);

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
            throw new NotImplementedException();
        }

        private void viewListOfLicenseNumbers()
        {
            throw new NotImplementedException();
        }
        private void changeVehicleStatusInGarage()
        {
            throw new NotImplementedException();
        }

        private void inflateToMax()
        {
            throw new NotImplementedException();
        }

        private void printVehicleDetails()
        {
            throw new NotImplementedException();
        }

        private void rechargeVehicle()
        {
            float amountToCharge;
            string licenseNumber = getLicenseFromUser();
            bool isValid = false;
            Vehicle currentVehicle;
            //To Do:
            m_Garage.GetVehicleInGarage(licenseNumber, out currentVehicle);

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
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(string.Format("You must enter a number between {0}-{1}", ex.MinValue, ex.MaxValue));
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
            //To Do:
            m_Garage.GetVehicleInGarage(licenseNumber, out currentVehicle);

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
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(string.Format("You must enter a number between {0}-{1}", ex.MinValue, ex.MaxValue));
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

        private FuelEngine.eFuelType getFuelType()
        {
            FuelEngine.eFuelType userFuelType;
            Array array = Enum.GetValues(typeof(FuelEngine.eFuelType));
            Console.WriteLine("Please choose fuel type:");
            foreach (FuelEngine.eFuelType fuelType in array)
            {
                Console.WriteLine(string.Format("for {0} Press {1}", fuelType.ToString(), fuelType.GetHashCode()));
            }

            userFuelType = (FuelEngine.eFuelType) getUserChoice(k_MinMenuSelectionRange, k_MaxMenuSelectionRange);
            return userFuelType;
        }

        private int getUserChoice(int startRange, int endRange)
        {
            Console.WriteLine(string.Format("Please enter a number between {0}-{1}", startRange, endRange));
            string userChoice;
            bool validInput = false;
            int input = 0;
            do
            {
                userChoice = Console.ReadLine();
                try
                {
                    input = int.Parse(userChoice);
                    if (startRange <= input && input <= endRange)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("This number is not between {0}-{1}", startRange, endRange));
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

        //private void insertVehicle()
        //{
        //    string licensePlate;
        //    try
        //    {
        //        m_Garage.AddVehicle(licensePlate);
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //}
        //private void insertVehicle()
        //{
        //    VehiclesCreator.eVehicleType vehicleType = getTypeFromUser();
        //    string licenseNumber = getLicenseFromUser();
        //    Vehicle newVehicle;

        //    if (m_Garage.IsVehicleExistInGarage(licenseNumber, out newVehicle))
        //    {
        //        Console.WriteLine("This vehicle is already exist in the garage.");
        //        m_Garage[newVehicle, Garage.eCarDetails.CarStatusInGarage] = Garage.eCarStatusInGarage.InRepair;
        //    }
        //    else
        //    {
        //        newVehicle = VehiclesCreator.CreateVehicle(vehicleType, licenseNumber);
        //        insertDetailsToNewVehicle(newVehicle);
        //        insertVehicleToGarage(newVehicle);
        //        Console.WriteLine("The vehicle was successfully put into the garage.");
        //    }
        //}
    }
}