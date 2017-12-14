module Day02
  let phase1 (input:seq<seq<int>>)=
    input
    |> Seq.map (fun row -> ((Seq.max row) - (Seq.min row)))
    |> Seq.sum
  
  let rowChecksum (row:seq<int>) : int = 
    row
    |> Seq.map(fun x -> x, Seq.tryFind(fun y -> x > y && x % y = 0) row)
    |> Seq.filter (fun (_, y) -> y.IsSome)
    |> Seq.map(fun (x,y) -> (x / (Option.get y)))
    |> Seq.item(0)    

  let phase2 (input:seq<seq<int>>)=
    input
    |> Seq.map(Seq.sortDescending)
    |> Seq.map (fun row -> rowChecksum row)
    |> Seq.sum

  let run() =
    // Read all lines, map lines to sequences, split lines with tab, and map to int
    let input =      
      System.IO.File.ReadAllLines("..\Day 02\input.txt")
      |> Seq.map(fun line -> line.Split('\t') |> Seq.map int)            
        
    printfn "Phase 1: %i" (phase1 input)
    printfn "Phase 2: %i" (phase2 input)