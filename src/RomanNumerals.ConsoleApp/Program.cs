using System;
using RomanNumerals.Logic;

namespace RomanNumerals.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TitleBanner();

            while (true)
            {
                MainMenu();
            }
        }



        private static void TitleBanner()
        {
            Console.WriteLine();
            Console.WriteLine(
                @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(
                @"|-------------| Welcome To The |-------------|");
            Console.WriteLine(
                @"|----------| Roman Numeral Parser |----------|");
            Console.WriteLine(
                @"//////////////////////////////////////////////");
            Console.WriteLine();
        }

        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(
                @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(
                @"|---------------| Main Menu |----------------|");
            Console.WriteLine(
                @"//////////////////////////////////////////////");
            Console.WriteLine();
            Console.WriteLine("Enter an option: ");
            Console.WriteLine("\t1 - Convert A Roman Numeral to Numbers");
            Console.WriteLine("\t2 - Convert A Number to Roman Numerals");
            Console.WriteLine("\tQ - Quit");
            Console.Write("> ");

            string userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "Q":
                    ExitApplication();
                    break;
                case "1":
                    NumeralToNumber();
                    break;
                case "2":
                    NumberToNumeral();
                    break;
            }
        }

        private static void NumeralToNumber()
        {
            string numeralInput;
            bool run = true;

            Console.WriteLine();
            Console.WriteLine(
                @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(
                @"|------| Numeral to Number Conversion |------|");
            Console.WriteLine(
                @"//////////////////////////////////////////////");
            while (run)
            {
                Console.WriteLine("\nEnter a numeral to convert or 'B' to go back");
                Console.Write("> ");
                numeralInput = Console.ReadLine().ToUpper();

                if (numeralInput.StartsWith("B"))
                {
                    run = false;
                    break;
                }

                try
                {
                    var numeral = new Numeral(numeralInput);

                    Console.WriteLine($"\n{numeral.RomanValue} : {numeral.ArabicValue}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void NumberToNumeral()
        {
            bool run = true;

            Console.WriteLine(
                @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(
                @"|------| Number to Numeral Conversion |------|");
            Console.WriteLine(
                @"//////////////////////////////////////////////");

            while (run)
            {
                Console.WriteLine("\nEnter a number to convert or 'B' to go back");
                Console.Write("> ");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput.StartsWith("B")) run = false;

                int.TryParse(userInput, out int numberToConvert);

                try
                {
                    var numeral = new Numeral(numberToConvert);

                    Console.WriteLine($"\n{numeral.ArabicValue} : {numeral.RomanValue}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ExitApplication()
        {
            Console.WriteLine();
            Console.WriteLine(
                @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(
                @"|---------------| Thank You |----------------|");
            Console.WriteLine(
                @"|----------------| Goodbye |-----------------|");
            Console.WriteLine(
                @"//////////////////////////////////////////////");
            Environment.Exit(0);
        }
    }
}
