using System;
using RomanNumerals.Logic;

namespace RomanNumerals.ConsoleApp
{
	internal class Program
	{
		private static void Main()
		{
			TitleBanner();

			while (true) MainMenu();
		}

		private static void TitleBanner()
		{
			Console.WriteLine();
			Console.WriteLine(
				@"|-------------| Welcome To The |-------------|");
			Console.WriteLine(
				@"|----------| Roman Numeral Parser |----------|");
			Console.WriteLine();
		}

		private static void MainMenu()
		{
			Console.WriteLine();
			Console.WriteLine(
				@"|---------------| Main Menu |----------------|");
			Console.WriteLine();
			Console.WriteLine("Enter an option: ");
			Console.WriteLine("\t1 - Convert A Roman Numeral to Numbers");
			Console.WriteLine("\t2 - Convert A Number to Roman Numerals");
			Console.WriteLine("\tQ - Quit");
			Console.Write("> ");

			var userInput = Console.ReadLine()?.ToUpper();

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
			Console.WriteLine();
			Console.WriteLine(
				@"|------| Numeral to Number Conversion |------|");
			while (true)
			{
				Console.WriteLine("\nEnter a numeral to convert or 'B' to go back");
				Console.Write("> ");
				var numeralInput = Console.ReadLine()?.ToUpper();

				if (numeralInput != null && numeralInput.StartsWith("B")) break;

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
			Console.WriteLine(
				@"|------| Number to Numeral Conversion |------|");

			while (true)
			{
				Console.WriteLine("\nEnter a number to convert or 'B' to go back");
				Console.Write("> ");
				var userInput = Console.ReadLine()?.ToUpper();

				if (userInput != null && userInput.StartsWith("B")) break;

				int.TryParse(userInput, out var numberToConvert);

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
				@"|---------------| Thank You |----------------|");
			Console.WriteLine(
				@"|----------------| Goodbye |-----------------|");
			Environment.Exit(0);
		}
	}
}