module Day04
  let phase1 (input:array<string>) : int=
    Array.fold (fun acc (x : string) ->
      let y = x.Split ' '
      acc + (if Array.distinct y = y then 1 else 0)
    ) 0 input


  let phase2 (input:array<string>)=
    Array.fold (fun acc (x : string) ->
      let y = x.Split ' '
      let Y = Array.map (fun (z:string) -> z |> Seq.sort |> System.String.Concat) y |> Array.distinct
      acc + (if Array.length y = Array.length Y then 1 else 0)
    ) 0 input

  let run() =
    let input = System.IO.File.ReadAllLines("..\Day 04\input.txt")
    printfn "Phase 1: %i" (phase1 input)
    printfn "Phase 2: %i" (phase2 input)