namespace RomanNumerals.Logic
{
    using System;
    using System.Collections.Generic;

    public class Numeral
    {
        private char[] r_value;

        private int a_value;

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
            if (ValidateSymbol(numeralSymbol))
            {
                this.RomanValue = numeralSymbol.ToString();
                int arabicNumeral = GetValue(numeralSymbol);
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

            foreach (var c in sequence) if (!ValidateSymbol(c)) valid = false;
            if (!Validate(sequence)) valid = false;

            if (valid)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    int val = GetValue(sequence[i]);
                    if (i < sequence.Length - 1)
                    {
                        int nextVal = GetValue(sequence[i + 1]);
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

        private bool Validate(char[] seq)
        {
            if (seq.Length > 1)
            {
                var values = new List<int>();
                int repeatCount = 0;

                for (int i = 0; i < seq.Length - 1; i++)
                {
                    int currentValue = GetValue(seq[i]);
                    int nextValue = GetValue(seq[i + 1]);

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

                    if (currentValue == nextValue)
                    {
                        if (currentValue % 4 == 0 ||
                            currentValue % 9 == 0) return false;
                    }
                }
            }
            return true;
        }

        private bool ValidateSymbol(char n)
        {
            if (
                n == 'I' ||
                n == 'V' ||
                n == 'X' ||
                n == 'L' ||
                n == 'C' ||
                n == 'D' ||
                n == 'M'
            ) return true;
            else return false;
        }

        private int GetValue(char numeral)
        {
            switch (Char.ToUpper(numeral))
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}