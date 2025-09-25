# unique — Unique, Sorted Integers (C#)
A tiny console app that reads a single line of input, validates it as integers only, removes duplicates, and prints the sorted unique values.

It includes multiple de-dup strategies (hash set, dictionary, etc.) and a simple in-place sorter so you can study tradeoffs and complexity.

## What it does
- Reads one line from stdin (standard input).
- Splits on any whitespace (spaces/tabs/newlines).
- Parses integers (supports negatives). If any token is not a whole integer (e.g., 7.5 or "abc"), it’s treated as invalid input.
- Removes duplicates.
- Prints the unique numbers in ascending order separated by spaces.

Current Program.cs calls HashSetDuplicateSearch by default.
Switch the commented lines to try other approaches.

## Project layout
.
├── Program.cs    // input parsing, error handling, choose algorithm
└── Function.cs   // duplicate-removal strategies, simple sorter/printer

## Usage
Input (one line):
            42 -17 0 42 99 -17 13 0 99 -5 13 42

Output:
-17 -5 0 13 42 99

Invalid input examples (any non-integer token):
1 2 5 8 7.5 6

## Algorithms provided

You have a pile of numbers and you want one of each number, nicely in order.

Time = how many moves you make (how long it feels).
Space = how many extra "boxes" you need to hold stuff while you work.

ISort is a quadratic bubble sort, and IPrint does repeated string concatenation (quadratic in output length). 
ISort(), IPrint() = O(k^2)

n = length of the input array
k = number of distinct values in the input

StupidDuplicateSearch
What it does: keeps picking a random numbers you haven’t looked at yet; before keeping it, 
it checks your album to see if you already have that number.

Time: lots of checking and randomness → often very slow. Time(including helpers): O(n log n + k^2) 
(quadratic dominates when k is large)
Space: you keep a visited list (big as your pile) O(n) and an album of uniques O(k) → about one big box + one smaller box. = O(n)

LinearDuplicateSearch
What it does: Walks once to keep only new numbers and then sorts the whole pile.

Time: the clumsy sorter makes it very slow. Time (including helpers) O((n^2) + (k^2))
Space: you make a new album with one of each number → one extra box. O(k)

HashSetDuplicateSearch
What it does: tosses numbers into a box that refuses duplicates (so you only keep one of each), 
then you sort the kept numbers with the clumsy sorter.

Time: putting into the magic box is fast, but the clumsy sort at the end can still make the whole thing slow. 
Time (including helpers): O(n + k^2) 
Space: the box holds one of each number → one extra box. O(k)

DictionaryDuplicateSearch
What it does: uses a notebook to count how many of each number you saw, then keeps just the names of the numbers 
and sorts them with the clumsy sorter.

Time: counting is fast, but the clumsy sort can make it slow if there are lots of different numbers. 
Time (including helpers): O(n + k^2)
Space: the notebook has one line per different number → one extra box. O(k)

LinqDuplicateSearch
What it does: uses a built-in box (Distinct) to drop duplicates, then sorts with the clumsy sorter.

Time: dropping duplicates is fast, but the clumsy sort can make it slow if many different numbers.
Time (including helpers): O(n + k^2)
Space: keeps one of each number → one extra box. O(k)
