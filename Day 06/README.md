# [Advent of Code 2017 Day 6 - Memory Reallocation](http://adventofcode.com/2017/day/6)
## Input
Input for this software is a line of numbers delimited by tabs
## Phase 1
Phase 1 calculates how many memory reallocations can be done before an infinite loop is born. Each cycle is processed by searching for the highest value bank. The value of this bank is divided between all banks in order from left to right starting from the divided bank and at the end of array looping to the beginning.
## Phase 2
Phase 2 calculates how cycles there actually are in the infinite loop