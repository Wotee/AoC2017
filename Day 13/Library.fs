// Valtteri Tarvus
// Advent of Code 2017 http://adventofcode.com/2017
// Challenge day 13 - 

// Input for this software is 
// Phase 1 calculates 
// Phase 2 calculates 

module Day13
  let phase1 (input:string)=
     0

  let phase2 (input:string)=
    0

  let run() =
    let input = System.IO.File.ReadAllText("..\Day 02\input.txt")
    printfn "Phase 1: %i" (phase1 input)
    printfn "Phase 2: %i" (phase2 input)