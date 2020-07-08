namespace APRBrown.RomanNumerals.Logic.Tests
{
    using System;
    using Xunit;

    public class NumeralsTests
    {
        [Fact]
        public void Numeral_I_Has_A_Value_Of_1()
        {
            //Given
            var sut = new Numeral('I');
            char expectedChar = 'I';
            int expectedInt = 1;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_V_Has_A_Value_Of_5()
        {
            //Given
            var sut = new Numeral('V');
            char expectedChar = 'V';
            int expectedInt = 5;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_X_Has_A_Value_Of_10()
        {
            //Given
            var sut = new Numeral('X');
            char expectedChar = 'X';
            int expectedInt = 10;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_L_Has_A_Value_Of_50()
        {
            //Given
            var sut = new Numeral('L');
            char expectedChar = 'L';
            int expectedInt = 50;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_C_Has_A_Value_Of_100()
        {
            //Given
            var sut = new Numeral('C');
            char expectedChar = 'C';
            int expectedInt = 100;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_D_Has_A_Value_Of_500()
        {
            //Given
            var sut = new Numeral('D');
            char expectedChar = 'D';
            int expectedInt = 500;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }

        [Fact]
        public void Numeral_M_Has_A_Value_Of_1000()
        {
            //Given
            var sut = new Numeral('M');
            char expectedChar = 'M';
            int expectedInt = 1000;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
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
            char expectedChar = 'D';
            int expectedInt = 500;

            //When
            char actualChar = sut.RomanValue;
            int actualInt = sut.ArabicValue;

            //Then
            Assert.Equal(expectedChar, actualChar);
            Assert.Equal(expectedInt, actualInt);
        }
    }
}
