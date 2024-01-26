using System;
using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompoundInterestCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Title:
            Console.WriteLine("Compound Interest Calculator:");
            Console.WriteLine("");

            decimal initialInvestment;

            //Asks user for initial investment amount.
            //Trys to catch irregular input from user, if wrong input, it will re-ask for input.
            while (true)
            {
                string inputString;
                Console.WriteLine("Please input your initial investment amount:");
                inputString = (Console.ReadLine());

                if (!decimal.TryParse(inputString, out initialInvestment))
                {
                    Console.WriteLine("Error: Your input was not a number, please try again:");
                    continue;
                }
                break;
            } 
            Console.WriteLine("");

            //Asks user if they'd like to use months or years.
            Console.WriteLine("Compounded monthly or yearly? (1.Months, or 2.Years), enter only \"1\" or \"2\":");
            
            //Method to switch text between "Months" or "Years", also includes execption/invalid input handling.
            string monthsOrYears = MonthsOrYears();

            //Asks user for the time period (number of months or years).
            decimal lengthMonthOrYears;
            while (true)
            {
                string inputString;
                
                inputString = (Console.ReadLine());

                if (!decimal.TryParse(inputString, out lengthMonthOrYears))
                {
                    Console.WriteLine("Error: Your input was not a number, please try again:");
                    continue;
                }
                break;
            }
            Console.WriteLine("");

            //Asks user for the interest rate.

            decimal interestRate;
            Console.WriteLine("Please input your interest rate percentage (0-100):");

            while (true)
            {
                string inputString;
                inputString = (Console.ReadLine());

                if (!decimal.TryParse(inputString, out interestRate))
                {
                    Console.WriteLine("Error: Your input was not a number, please try again:");
                    continue;
                }
                break;
            }

            interestRate = interestRate / 100;
            Console.WriteLine("");

            //Method that does the calculations and prints results.
            Console.Clear();
            Console.WriteLine("Results:");
            Calculation(initialInvestment, lengthMonthOrYears, interestRate, monthsOrYears);

            // Asks user to restart program if they wish:
            Console.WriteLine("Press \"enter\" to restart program:");
            Console.ReadLine();
            Console.Clear();

            // Starts a new instance of the program to try restart program.
            try
            {
                Process.Start("C:\\Users\\Nicolas Spies\\CSharp\\MyProjects\\BeginnerLevel\\CompoundInterestCalculator\\CompoundInterestCalculator\\bin\\Debug\\net8.0\\CompoundInterestCalculator.exe");
            }
            // If there is an error in the file path
            catch
            {
                Console.WriteLine("File path error, could not restart.. Shutting down. Please re-launch application.");
                Console.ReadLine();
            }
           // Closes the current process
            Environment.Exit(0);
        }

        private static void Calculation(decimal initialInvestment, decimal lengthYears, decimal interestRate, string monthsOrYears)
        {
            decimal multiplier = 1 + interestRate;
            decimal finalAmount = initialInvestment;
            decimal totalInterest = 0;


            for (int i = 1; i <= lengthYears; i++)
            {
                decimal finalAmountTemp = finalAmount;

                finalAmount = finalAmount * multiplier;
                decimal periodInterest = finalAmount - finalAmountTemp;

                totalInterest += periodInterest;


                // Adjusting wording for "months" or "years", based on input.
                if (monthsOrYears == "1")
                {
                    Console.WriteLine("Month{0}: {1:C}", i, finalAmount);
                    Console.WriteLine("Month{0} interest: {1:C}", i, periodInterest);
                    Console.WriteLine("");
                }

                else
                {
                    Console.WriteLine("Year{0}: {1:C}", i, finalAmount);
                    Console.WriteLine("Year{0} interest: {1:C}", i, periodInterest);
                    Console.WriteLine("");
                }

            }

            Console.WriteLine("Total Interest: {0:C}", totalInterest);
            Console.WriteLine("");

        }

        private static string MonthsOrYears()
        {
            
            string monthsOrYears = Console.ReadLine();

            // Check to see if use input is valid:
            while (monthsOrYears != "1" || monthsOrYears != "2")
            {
                if (monthsOrYears == "1" || monthsOrYears == "2")
                {
                    break;
                }

                Console.WriteLine("Please input only \"1\" or \"2\"");
                monthsOrYears = Console.ReadLine();

               
            }

            // Adjust below sentance to match user choice (Months vs Years):
            if (monthsOrYears == "1")
                {
                Console.WriteLine("");
                Console.WriteLine("Please input the length of time (Months):");
                }

                else if (monthsOrYears == "2")
                {
                Console.WriteLine("");
                Console.WriteLine("Please input the length of time (Years):");
                }

                return monthsOrYears;
            

            

        }
    }
}