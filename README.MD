# Roman Numerals Parsing #

Inspired by a comment by [Zac Braddy](https://twitter.com/ZackerTheHacker) on episode 7 of the [Tabs and Spaces Podcast](https://tabsandspaces.io/), this project intends to explore how I might solve the task of parsing Roman Numerals in code.

## Contents ##

- [Introduction](#Introduction)
  - [Background](#Background)
  - [Goals](#Goals)
- [License](#License)

## Introduction ##

### Background ###

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

### Goals ###

A user should be able to enter a roman number such as MDCCCXXVII and see the parsed value of 1827.

Entering a value in arabic notation should return the Roman numeral notation e.g. 349 should return CCCXLIX.

## License ##

This project is licenced under the MIT License, see the [LICENSE](./LICENSE) file for full details.
