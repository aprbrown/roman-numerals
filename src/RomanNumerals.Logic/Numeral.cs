namespace RomanNumerals.Logic
{
    using System;
    using System.Collections.Generic;

    public class Numeral
    {
        private char[] r_value;

        private int a_value;

        private Dictionary<char, int> numeralValueDict = new Dictionary<char, int>
        {
           { 'I', 1 },
           { 'V', 5 },
           { 'X', 10 },
           { 'L', 50 },
           { 'C', 100 },
           { 'D', 500 },
           { 'M', 1000 }
        };

        public string RomanValue
        {
            get => new String(r_value);
            private set => r_value = value.ToCharArray();
        }

        public int ArabicValue
        {
            get => a_value;
            private set => a_value = value;
        }

        public Numeral(char numeralSymbol)
        {
            numeralSymbol = Char.ToUpper(numeralSymbol);
            if (numeralValueDict.ContainsKey(numeralSymbol))
            {
                this.RomanValue = numeralSymbol.ToString();
                numeralValueDict.TryGetValue(numeralSymbol, out int arabicNumeral);
                this.ArabicValue = arabicNumeral;
            }
            else throw new ArgumentException("Not a valid Roman Numeral", numeralSymbol.ToString());
        }

        public Numeral(string numeralSymbols)
        {
            string symbolsUpper = numeralSymbols.ToUpper();
            char[] sequence = symbolsUpper.ToCharArray();
            int totalValue = 0;
            bool valid = true;

            foreach (var c in sequence)
            {
                if (!numeralValueDict.ContainsKey(c))
                {
                    valid = false;
                }
            }

            if (!Validate(sequence)) valid = false;

            if (valid)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    int val;
                    numeralValueDict.TryGetValue(sequence[i], out val);
                    if (i < sequence.Length - 1)
                    {
                        int nextVal;
                        numeralValueDict.TryGetValue(sequence[i + 1], out nextVal);
                        if (val < nextVal)
                        {
                            totalValue += (nextVal - val);
                            i++;
                            continue;
                        }
                    }
                    totalValue += val;
                }
                this.RomanValue = symbolsUpper;
                this.ArabicValue = totalValue;
            }
            else throw new ArgumentException("Not a valid Roman Numeral", numeralSymbols);
        }

        public Numeral(int value)
        {
            if (value < 1 || value > 3999) throw new ArgumentException(
                "A Roman Numeral can only be between the values of 1 and 3999",
                value.ToString());

            string numeral = "";
            int thousands, hundreds, tens, ones;

            thousands = value / 1000;
            hundreds = value % 1000 / 100;
            tens = value % 100 / 10;
            ones = value % 10;

            for (int i = 0; i < thousands; i++)
            {
                numeral += "M";
            }

            string hundredsSymbols = "";

            for (int i = 0; i < hundreds; i++)
            {
                if (i == 3) { hundredsSymbols = "CD"; continue; }
                if (i == 4) { hundredsSymbols = "D"; continue; }
                if (i == 8) { hundredsSymbols = "CM"; continue; }
                hundredsSymbols += "C";
            }

            numeral += hundredsSymbols;

            string tensSymbols = "";

            for (int i = 0; i < tens; i++)
            {
                if (i == 3) { tensSymbols = "XL"; continue; }
                if (i == 4) { tensSymbols = "L"; continue; }
                if (i == 8) { tensSymbols = "XC"; continue; }
                tensSymbols += "X";
            }

            numeral += tensSymbols;

            string onesSymbols = "";

            for (int i = 0; i < ones; i++)
            {
                if (i == 3) { onesSymbols = "IV"; continue; }
                if (i == 4) { onesSymbols = "V"; continue; }
                if (i == 8) { onesSymbols = "IX"; continue; }
                onesSymbols += "I";
            }

            numeral += onesSymbols;

            this.RomanValue = numeral;
            this.ArabicValue = value;
        }

        private bool Validate(char[] seq)
        {
            if (seq.Length > 1)
            {
                var values = new List<int>();
                int repeatCount = 0;
                int[] invalidRepeats = { 4, 9, 40, 90, 400, 900 };

                for (int i = 0; i < seq.Length - 1; i++)
                {
                    numeralValueDict.TryGetValue(seq[i], out int currentValue);
                    numeralValueDict.TryGetValue(seq[i + 1], out int nextValue);

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
                        else return false;
                    }

                    if (i == seq.Length - 2) values.Add(nextValue);
                }

                for (int i = 0; i < values.Count - 1; i++)
                {
                    int currentValue = values[i];
                    int nextValue = values[i + 1];

                    if (currentValue < nextValue) return false;

                    if (currentValue == nextValue &&
                        Array.Exists(invalidRepeats, e => e.Equals(currentValue))
                        ) return false;
                }
            }
            return true;
        }
    }
}