# Roman Numerals Parsing #

Inspired by a comment by [Zac Braddy](https://twitter.com/ZackerTheHacker) on episode 7 of the [Tabs and Spaces Podcast](https://tabsandspaces.io/), this project intends to explore how I might solve the task of parsing Roman Numerals in code.

## Contents ##

- [Background](#Background)
- [Goals](#Goals)
- [Progress](#Progress)
- [License](#License)

## Background ##

[Roman numerals](https://en.wikipedia.org/wiki/Roman_numerals) can be difficult to decipher compared to Arabic numeral notation. Though roman numerals are rarely used, they are still seen on plaques and monuments, and even in the credit sequences of films and television shows. This project will allow the user to enter a Roman numeral and return the value in Arabic numerals.

There are 7 symbols used when depicting whole numbers in the Roman Numeral system.

| Roman | Arabic    |
|:---:  |       --: |
| I     | 1         |
| V     | 5         |
| X     | 10        |
| L     | 50        |
| C     | 100       |
| D     | 500       |
| M     | 1000      |

Each power of 10 digit in a number is represented by between one and four Roman symbols with the largest value appearing as the left most digit, in the same manner as in Arabic notation e.g. 1551 = MDLI.

Some numbers introduce subtractive notation to the numeral system. Where 1 = I, 2 = II and 3 = III, 4 is not noted as IIII, but instead noted as IV (one less than five).

### Restrictions ###

The number zero (0) is not represented in Roman Numerals.

The range of available numbers to display in Roman Numerals is between 1 and 3999. This is due to M being the largest number and the nature of subtractive notation. To reach 4000 there would need to be a symbol representing 5000.

## Goals ##

A user should be able to enter a roman number such as MDCCCXXVII and see the parsed value of 1827.

Entering a value in arabic notation should return the Roman numeral notation e.g. 349 should return CCCXLIX.

## Progress ##

Under the project of RomanNumerals.Logic and its related test project I have developed a class to represent a Roman Numeral. A Numeral object can be instantiated with a char, string or integer, as long as the input is valid for a Roman Numeral i.e. symbols are in the correct order or an integer is between 1 and 3999.

A Numeral object contains the roman representation of that number along with the arabic representation which are available as callable methods on the class.

Along with this class and its test cases, I have created a simple console application which allows the user to enter a numeral or a number and have it converted to the other.

## License ##

This project is licenced under the MIT License, see the [LICENSE](./LICENSE) file for full details.
