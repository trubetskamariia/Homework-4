using System;

namespace Task3_Converter
{
    public class Converter
    {
        private decimal _usdRate;
        private decimal _eurRate;

        public Converter(decimal usd, decimal eur)
        {
            _usdRate = usd;
            _eurRate = eur;
        }

        public decimal ConvertFromUahToUsd(decimal uah) => uah / _usdRate;
        public decimal ConvertFromUahToEur(decimal uah) => uah / _eurRate;
        public decimal ConvertFromUsdToUah(decimal usd) => usd * _usdRate;
        public decimal ConvertFromEurToUah(decimal eur) => eur * _eurRate;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Converter converter = new Converter(44.8m, 50.3m);
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. UAH to USD");
                Console.WriteLine("2. UAH to EUR");
                Console.WriteLine("3. USD to UAH");
                Console.WriteLine("4. EUR to UAH");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                bool isExit = choice == "0";
                if (isExit)
                {
                    isRunning = false;
                    continue;
                }

                bool isOption1 = choice == "1";
                bool isOption2 = choice == "2";
                bool isOption3 = choice == "3";
                bool isOption4 = choice == "4";

                bool isValidChoice = isOption1 || isOption2 || isOption3 || isOption4;
                if (!isValidChoice)
                {
                    Console.WriteLine("Error: Invalid choice.");
                    continue;
                }

                try
                {
                    Console.Write("Enter amount: ");
                    string input = Console.ReadLine() ?? string.Empty;
                    decimal amount = decimal.Parse(input);

                    bool isNegative = amount < 0;
                    if (isNegative)
                    {
                        throw new Exception("Amount cannot be negative.");
                    }

                    if (isOption1)
                    {
                        decimal result = converter.ConvertFromUahToUsd(amount);
                        Console.WriteLine($"Result: {result:F2} USD");
                    }
                    else if (isOption2)
                    {
                        decimal result = converter.ConvertFromUahToEur(amount);
                        Console.WriteLine($"Result: {result:F2} EUR");
                    }
                    else if (isOption3)
                    {
                        decimal result = converter.ConvertFromUsdToUah(amount);
                        Console.WriteLine($"Result: {result:F2} UAH");
                    }
                    else if (isOption4)
                    {
                        decimal result = converter.ConvertFromEurToUah(amount);
                        Console.WriteLine($"Result: {result:F2} UAH");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
