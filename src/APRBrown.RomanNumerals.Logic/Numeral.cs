namespace APRBrown.RomanNumerals.Logic
{
    using System;

    public class Numeral
    {
        private char[] r_value;

        private int a_value;

        public string RomanValue
        {
            get
            {
                string r_value = "";
                foreach (var r in r_value)
                {
                    r_value += r;
                }
                return r_value;
            }
            private set
            {
                r_value = value.ToCharArray();
            }
        }

        public int ArabicValue
        {
            get => a_value;
            private set => a_value = value;
        }

        public Numeral(char romanNumeral)
        {
            romanNumeral = Char.ToUpper(romanNumeral);
            if (ValidateNumeral(romanNumeral))
            {
                this.RomanValue = romanNumeral.ToString();
                int arabicNumeral;
                GetNumeralValue(romanNumeral, out arabicNumeral);
                this.ArabicValue = arabicNumeral;
            }
            else throw new ArgumentException("Not a valid Roman Numeral");
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