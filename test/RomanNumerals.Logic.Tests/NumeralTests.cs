namespace RomanNumerals.Logic.Tests
{
    using System;
    using Xunit;

    public class NumeralTests
    {
        [Fact]
        public void Numeral_I_Has_A_Value_Of_1()
        {
            //Given
            var sut = new Numeral("I");
            string expectedString = "I";
            int expectedInt = 1;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_V_Has_A_Value_Of_5()
        {
            //Given
            var sut = new Numeral('V');
            string expectedString = "V";
            int expectedInt = 5;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_X_Has_A_Value_Of_10()
        {
            //Given
            var sut = new Numeral('X');
            string expectedString = "X";
            int expectedInt = 10;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_L_Has_A_Value_Of_50()
        {
            //Given
            var sut = new Numeral('L');
            string expectedString = "L";
            int expectedInt = 50;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_C_Has_A_Value_Of_100()
        {
            //Given
            var sut = new Numeral('C');
            string expectedString = "C";
            int expectedInt = 100;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_D_Has_A_Value_Of_500()
        {
            //Given
            var sut = new Numeral('D');
            string expectedString = "D";
            int expectedInt = 500;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_M_Has_A_Value_Of_1000()
        {
            //Given
            var sut = new Numeral('M');
            string expectedString = "M";
            int expectedInt = 1000;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Invalid_Input_Throws_An_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Numeral('Z'));
        }

        [Fact]
        public void A_Numeral_Initialised_With_Lowercase_Char_Is_Valid()
        {
            //Given
            var sut = new Numeral('d');
            string expectedString = "D";
            int expectedInt = 500;

            //When
            string actualString = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedString, actualString);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Passing_Numerals_As_A_String_Gives_Correct_Value()
        {
            //Given
            var sut = new Numeral("XXII");
            int expectedInt = 22;

            //When
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Subtractive_Notation_Works_As_Expected()
        {
            //Given
            var sut = new Numeral("CMXLIX");
            int expectedInt = 949;

            //When
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void An_Incorrectly_Ordered_Numeral_Throws_An_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Numeral("MCCCIVXL"));
            Assert.Throws<ArgumentException>(() => new Numeral("IIII"));
            Assert.Throws<ArgumentException>(() => new Numeral("IVXLCDM"));
            Assert.Throws<ArgumentException>(() => new Numeral("IIIV"));
            Assert.Throws<ArgumentException>(() => new Numeral("VIIII"));
            Assert.Throws<ArgumentException>(() => new Numeral("IL"));
            Assert.Throws<ArgumentException>(() => new Numeral("XIXXX"));
            Assert.Throws<ArgumentException>(() => new Numeral("IC"));
            Assert.Throws<ArgumentException>(() => new Numeral("ID"));
            Assert.Throws<ArgumentException>(() => new Numeral("IM"));
            Assert.Throws<ArgumentException>(() => new Numeral("XD"));
            Assert.Throws<ArgumentException>(() => new Numeral("XM"));
            Assert.Throws<ArgumentException>(() => new Numeral("IXIX"));
            Assert.Throws<ArgumentException>(() => new Numeral("IVIV"));
        }

        [Fact]
        public void A_numeral_cannot_be_below_1_or_above_3999()
        {
            Assert.Throws<ArgumentException>(() => new Numeral(0));
            Assert.Throws<ArgumentException>(() => new Numeral(-1));
            Assert.Throws<ArgumentException>(() => new Numeral(-1345));
            Assert.Throws<ArgumentException>(() => new Numeral(4000));
            Assert.Throws<ArgumentException>(() => new Numeral(5235));
        }

        [Fact]
        public void A_Numeral_Can_Be_Built_with_thousands()
        {
            //Given
            var sut = new Numeral(3000);

            //When
            var expected = "MMM";

            //Then
            Assert.Equal(expected, sut.RomanValue);
        }

        [Fact]
        public void A_Numeral_Can_Be_Built_with_Hundreds()
        {
            //Given
            var sut = new Numeral(1400);

            //When
            var expected = "MCD";

            //Then
            Assert.Equal(expected, sut.RomanValue);
        }

        [Fact]
        public void A_Numeral_Can_Be_Built_with_Tens()
        {
            //Given
            var sut = new Numeral(2790);

            //When
            var expected = "MMDCCXC";

            //Then
            Assert.Equal(expected, sut.RomanValue);
        }

        [Fact]
        public void A_Numeral_Can_Be_Built_with_Ones()
        {
            //Given
            var sut = new Numeral(683);

            //When
            var expected = "DCLXXXIII";

            //Then
            Assert.Equal(expected, sut.RomanValue);
        }
    }
}
