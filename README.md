# Advent of Code 2015

Online Resources:
- [Advent of Code 2015 Website][l1]
- [Nice online Regex editor][regex101]

## Day01 Solution

Nothing special except I should have put the input string in a file.

## Day02 Solution

I should have put the input string in a file.

I created a **Box** class which handles all the needed calculations for the:
- wrapping paper (in square feet)
- ribbon (in feet)

## Day03 Solution

Once again, I should have put the input string in a file. :p

I created a **HousesGrid** object which handles the positions of both Santa and RoboSanta in the grid. It also handles who should move during each turn.
You can specify at the instanciation of the grid if you would like to use RoboSanta or not.

## Day04 Solution

Nothing special. Pretty straight forward.

## Day05 Solution

I used two Regex to detect if a string:
- does contain a letter twice in a row
- does contain one letter which repeats with exactly one letter between them

I also used a custom method to handle if a string does contain any pair of two letters appearing twice without overlapping. Not really sure if we can do that with a Regex (I will do some further research).

I leveraged the [Extension Methods][l2] of the C# framework.

##Day10 Solution

##Day11 Solution

##Day12 Solution

## Day21 Solution

- No TDD = No Unit Tests (to be added)
- Refactoring needed

## Day23 Solution

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

You can instanciate a **Computer** Object instance by specifying a value for the register A (default is 0 if nothing is specified).
You can load a program listing into the computer via two (2) methods: directly from a string or from a file.
The program loaded within the computer can be executed via the **Run** method.


[l1]:http://adventofcode.com/
[l2]:https://msdn.microsoft.com/en-CA/library/bb383977.aspx
[regex101]:https://regex101.com/