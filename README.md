# Advent of Code 2015

Online Resources:
- [Advent of Code 2015 Website][l1]
- [Nice online Regex editor][regex101]

## Day01 Solution

[Source Code][Day01SC] | 
[Unit Tests][Day01UT]

Nothing special except I should have put the input string in a file.

## Day02 Solution

[Source Code][Day02SC] | 
[Unit Tests][Day02UT]

I should have put the input string in a file.

I created a **Box** class which handles all the needed calculations for the:
- wrapping paper (in square feet)
- ribbon (in feet)

## Day03 Solution

[Source Code][Day03SC] | 
[Unit Tests][Day03UT]

Once again, I should have put the input string in a file. :p

I created a **HousesGrid** object which handles the positions of both Santa and RoboSanta in the grid. It also handles who should move during each turn.
You can specify at the instanciation of the grid if you would like to use RoboSanta or not.

## Day04 Solution

[Source Code][Day04SC] | 
[Unit Tests][Day04UT]

Nothing special. Pretty straight forward.

## Day05 Solution

[Source Code][Day05SC] | 
[Unit Tests][Day05UT]

I used many Regex to detect if a string:
- has at least three vowels **([^aeiou]*[aeiou]){3,}**
- does not contain certain strings of characters **(ab|cd|pq|xy)**
- does contain a letter twice in a row **([a-z])\1**
- does contain one letter which repeats with exactly one letter between them **(.).\1**
- does contain any pair of two letters appearing twice without overlapping **([a-z]{2})[a-z]*\1**

I also leveraged the [Extension Methods][l2] of the C# framework.

## Day06 Solution

[Source Code][Day06SC] | 
[Unit Tests][Day06UT]

I've put the input string in a file. :)

Nota Bene: I could have done a solution faster than the one I developped. I wanted to produce a solution based on an simple, extensible Object model.
Indeed, I've developped it on a TDD way and I've included many unit tests.

Therefore, I used the following Object model to represent how the system works:
- an abstract **LightsGrid** class which will be the base class (only three methods are declared abstract: *TurnOnLights*, *TurnOffLights*, *ToggleLights*)
- a **BinaryLightsGrid** class which implements the three methods based on the Part 1 behavior (a light is on or off)
- a **GradientLightsGrid** class which implements the three methods based on the Part 1 behavior (a light gets a specific brightness)

I could also have put the abstract method within an Interface but I did not see the needs at this time. I wanted to produce an elegant solution without overengineering it. It could have been part of a future refactoring if the puzzle had evolved with a more complex behavior with an hypothetical but currently unexisting part 3.

## Day07 Solution

[Source Code][Day07SC] | 
[Unit Tests][Day07UT]

##Day10 Solution

[Source Code][Day10SC] | 
[Unit Tests][Day10UT]

##Day11 Solution

[Source Code][Day11SC] | 
[Unit Tests][Day11UT]

##Day12 Solution

[Source Code][Day12SC] | 
[Unit Tests][Day12UT]

##Day20 Solution

[Source Code][Day20SC] | 
[Unit Tests][Day20UT]

## Day21 Solution

[Source Code][Day21SC] | 
[Unit Tests][Day21UT]

- No TDD = No Unit Tests (to be added)
- Refactoring needed

## Day23 Solution

[Source Code][Day23SC] | 
[Unit Tests][Day23UT]

I've put the input string in a file. :)

Nota Bene: I could have done a solution faster than the one I developped. I wanted to produce a solution based on an simple, extensible Object model.
Indeed, I've developped it on a TDD way and I've included many unit tests (coverage is certainly not optimal but it answers the needs very well).

Therefore, I used the following Object model to represent how the computer works:
- a **Box** class
- a **Register** class
- an abstract **Instruction** class which will be the base class to represent each of the six (6) original supported instructions
- a **ProgramCursor** class to represent which line the computer is currently processing

Also, the computer is composed by:
- a set of registers (two in our case: A and B)
- a set of available instructions (six in our case: hlf, inc, tpl, jmp, jio, jie)
- a cursor
- a program listing which consists of an Array of strings, each string reprensenting a program code (i.e. *hlf a* or *jmp +21* or *jie b, -7*, etc.)

You can instanciate a **Computer** Object instance by specifying a value for the register A (default is 0 if nothing is specified).
You can load a program listing into the computer via two (2) methods: directly from a string or from a file.
The program loaded within the computer can be executed via the **Run** method.

## Day25 Solution

[Source Code][Day25SC] | 
[Unit Tests][Day25UT]

- Use of Delegate Func
- Use of yield


[l1]:http://adventofcode.com/
[l2]:https://msdn.microsoft.com/en-CA/library/bb383977.aspx
[regex101]:https://regex101.com/

[Day01SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day01.cs
[Day02SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day02.cs
[Day03SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day03.cs
[Day04SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day04.cs
[Day05SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day05.cs
[Day06SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day06.cs
[Day07SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day07.cs

[Day10SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day10.cs
[Day11SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day11.cs
[Day12SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day12.cs

[Day20SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day20.cs
[Day21SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day21.cs
[Day23SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day23.cs
[Day25SC]:https://github.com/Elgolfin/adventofcode-2015/blob/master/Day25.cs



[Day01UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day01_UnitTest.cs
[Day02UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day02_UnitTest.cs
[Day03UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day03_UnitTest.cs
[Day04UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day04_UnitTest.cs
[Day05UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day05_UnitTest.cs
[Day06UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day06_UnitTest.cs
[Day07UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day07_UnitTest.cs

[Day10UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day10_UnitTest.cs
[Day11UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day11_UnitTest.cs
[Day12UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day12_UnitTest.cs

[Day20UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day20_UnitTest.cs
[Day21UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day21_UnitTest.cs
[Day23UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day23_UnitTest.cs
[Day25UT]:https://github.com/Elgolfin/adventofcode-2015/blob/master/AdventOfCode2015UnitTests/Day23_UnitTest.cs