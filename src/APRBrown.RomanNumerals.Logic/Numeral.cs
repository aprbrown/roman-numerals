namespace APRBrown.RomanNumerals.Logic
{
    using System;

    public class Numeral
    {
        private char rValue;
        private int aValue;
        public char RomanValue
        {
            get => rValue;
            private set
            {
                var val = Char.ToUpper(value);
                if (ValidateNumeral(val))
                    rValue = val;
            }
        }
        public int ArabicValue
        {
            get => aValue;
            private set
            {
                aValue = value;
            }
        }

        private bool ValidateNumeral(char n)
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

        public Numeral(char romanNumeral)
        {
            var r_val = Char.ToUpper(romanNumeral);
            int a_val;
            if (ValidateNumeral(r_val))
            {
                this.RomanValue = r_val;
                GetNumeralValue(r_val, out a_val);
                this.ArabicValue = a_val;
            }
            else throw new ArgumentException("Not a valid Roman Numeral");
        }

        private void GetNumeralValue(char numeral, out int arabic)
        {
            switch (Char.ToUpper(numeral))
            {
                case 'I':
                    arabic = 1;
                    break;
                case 'V':
                    arabic = 5;
                    break;
                case 'X':
                    arabic = 10;
                    break;
                case 'L':
                    arabic = 50;
                    break;
                case 'C':
                    arabic = 100;
                    break;
                case 'D':
                    arabic = 500;
                    break;
                case 'M':
                    arabic = 1000;
                    break;
                default:
                    arabic = 0;
                    break;
            }
        }
    }
}