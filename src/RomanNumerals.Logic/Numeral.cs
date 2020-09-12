using System;
using System.Collections.Generic;

namespace RomanNumerals.Logic
{
	public class Numeral
	{
		private readonly Dictionary<char, int> _numeralValueDict = new Dictionary<char, int>
		{
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000}
		};

		private char[] _rValue;

		public Numeral(char numeralSymbol)
		{
			numeralSymbol = char.ToUpper(numeralSymbol);
			if (_numeralValueDict.ContainsKey(numeralSymbol))
			{
				RomanValue = numeralSymbol.ToString();
				_numeralValueDict.TryGetValue(numeralSymbol, out var arabicNumeral);
				ArabicValue = arabicNumeral;
			}
			else
			{
				throw new ArgumentException("Not a valid Roman Numeral", numeralSymbol.ToString());
			}
		}

		public Numeral(string numeralSymbols)
		{
			var symbolsUpper = numeralSymbols.ToUpper();
			var sequence = symbolsUpper.ToCharArray();
			var totalValue = 0;
			var valid = true;

			foreach (var c in sequence)
				if (!_numeralValueDict.ContainsKey(c))
					valid = false;

			if (!Validate(sequence)) valid = false;

			if (valid)
			{
				for (var i = 0; i < sequence.Length; i++)
				{
					_numeralValueDict.TryGetValue(sequence[i], out var val);
					if (i < sequence.Length - 1)
					{
						_numeralValueDict.TryGetValue(sequence[i + 1], out var nextVal);
						if (val < nextVal)
						{
							totalValue += nextVal - val;
							i++;
							continue;
						}
					}

					totalValue += val;
				}

				RomanValue = symbolsUpper;
				ArabicValue = totalValue;
			}
			else
			{
				throw new ArgumentException("Not a valid Roman Numeral", numeralSymbols);
			}
		}

		public Numeral(int value)
		{
			if (value < 1 || value > 3999)
				throw new ArgumentException(
					"A Roman Numeral can only be between the values of 1 and 3999",
					value.ToString());

			var numeral = "";

			var thousands = value / 1000;
			var hundreds = value % 1000 / 100;
			var tens = value % 100 / 10;
			var ones = value % 10;

			for (var i = 0; i < thousands; i++) numeral += "M";

			var hundredsSymbols = "";

			for (var i = 0; i < hundreds; i++)
				switch (i)
				{
					case 3:
						hundredsSymbols = "CD";
						continue;
					case 4:
						hundredsSymbols = "D";
						continue;
					case 8:
						hundredsSymbols = "CM";
						continue;
					default:
						hundredsSymbols += "C";
						break;
				}

			numeral += hundredsSymbols;

			var tensSymbols = "";

			for (var i = 0; i < tens; i++)
				switch (i)
				{
					case 3:
						tensSymbols = "XL";
						continue;
					case 4:
						tensSymbols = "L";
						continue;
					case 8:
						tensSymbols = "XC";
						continue;
					default:
						tensSymbols += "X";
						break;
				}

			numeral += tensSymbols;

			var onesSymbols = "";

			for (var i = 0; i < ones; i++)
				switch (i)
				{
					case 3:
						onesSymbols = "IV";
						continue;
					case 4:
						onesSymbols = "V";
						continue;
					case 8:
						onesSymbols = "IX";
						continue;
					default:
						onesSymbols += "I";
						break;
				}

			numeral += onesSymbols;

			RomanValue = numeral;
			ArabicValue = value;
		}

		public string RomanValue
		{
			get => new string(_rValue);
			private set => _rValue = value.ToCharArray();
		}

		public int ArabicValue { get; }

		private bool Validate(IReadOnlyList<char> seq)
		{
			if (seq.Count <= 1) return true;
			var values = new List<int>();
			var repeatCount = 0;
			int[] invalidRepeats = {4, 9, 40, 90, 400, 900};

			for (var i = 0; i < seq.Count - 1; i++)
			{
				_numeralValueDict.TryGetValue(seq[i], out var currentValue);
				_numeralValueDict.TryGetValue(seq[i + 1], out var nextValue);

				if (currentValue != nextValue) repeatCount = 0;

				if (currentValue == nextValue) repeatCount++;

				if (repeatCount == 3) return false;

				if (currentValue >= nextValue) values.Add(currentValue);

				if (currentValue < nextValue && repeatCount == 0)
				{
					if (nextValue / 10 == currentValue && currentValue != 50 ||
					    nextValue / 5 == currentValue)
					{
						values.Add(nextValue - currentValue);
						i++;
					}
					else
					{
						return false;
					}
				}

				if (i == seq.Count - 2) values.Add(nextValue);
			}

			for (var i = 0; i < values.Count - 1; i++)
			{
				var currentValue = values[i];
				var nextValue = values[i + 1];

				if (currentValue < nextValue) return false;

				if (currentValue == nextValue &&
				    Array.Exists(invalidRepeats, e => e.Equals(currentValue))
				) return false;
			}

			return true;
		}
	}
}