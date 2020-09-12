using System;
using Xunit;

namespace RomanNumerals.Logic.Tests
{
	public class NumeralTests
	{
		[Fact]
		public void Numeral_I_Has_A_Value_Of_1()
		{
			//Given
			var sut = new Numeral("I");
			var expectedString = "I";
			var expectedInt = 1;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_V_Has_A_Value_Of_5()
		{
			//Given
			var sut = new Numeral('V');
			var expectedString = "V";
			var expectedInt = 5;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_X_Has_A_Value_Of_10()
		{
			//Given
			var sut = new Numeral('X');
			var expectedString = "X";
			var expectedInt = 10;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_L_Has_A_Value_Of_50()
		{
			//Given
			var sut = new Numeral('L');
			var expectedString = "L";
			var expectedInt = 50;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_C_Has_A_Value_Of_100()
		{
			//Given
			var sut = new Numeral('C');
			var expectedString = "C";
			var expectedInt = 100;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_D_Has_A_Value_Of_500()
		{
			//Given
			var sut = new Numeral('D');
			var expectedString = "D";
			var expectedInt = 500;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Numeral_M_Has_A_Value_Of_1000()
		{
			//Given
			var sut = new Numeral('M');
			var expectedString = "M";
			var expectedInt = 1000;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

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
			var expectedString = "D";
			var expectedInt = 500;

			//When
			var actualString = sut.RomanValue;
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedString, actualString);
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Passing_Numerals_As_A_String_Gives_Correct_Value()
		{
			//Given
			var sut = new Numeral("XXII");
			var expectedInt = 22;

			//When
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Subtractive_Notation_Works_As_Expected()
		{
			//Given
			var sut = new Numeral("CMXLIX");
			var expectedInt = 949;

			//When
			var actualInt = sut.ArabicValue;

			//Then
			Assert.Equal(expectedInt, actualInt);
		}

		[Fact]
		public void Creating_Valid_Numerals_Does_Not_Throw_Exceptions()
		{
			var sut = new Numeral("MM");
			sut = new Numeral("II");
			sut = new Numeral("XIX");
			sut = new Numeral("MMMCLII");
			sut = new Numeral("CCI");
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