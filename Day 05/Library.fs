module Day05
  let func1 (input:int) : int = input + 1
  let func2 (input:int) : int = (if input < 3 then (+) else (-)) input 1

  let phase input func =
    let rec takeStep (input:array<int>) step index =
      let newLoc = input.[index] + index
      input.[index] <- func input.[index]
      if newLoc >= 0 && newLoc < (Array.length input) then
        takeStep input (step+1) newLoc
      else step+1
    takeStep input 0 0

  let run() =
    let input = System.IO.File.ReadAllLines("..\Day 05\input.txt") |> Seq.map int
    printfn "Phase 1: %i" (phase (Seq.toArray input) func1)
    printfn "Phase 2: %i" (phase (Seq.toArray input) func2)