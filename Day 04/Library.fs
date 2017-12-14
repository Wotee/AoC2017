module Day04
  let func1 input = (if Array.distinct input = input then 1 else 0)

  let func2 input =
    let parsed = Array.map (fun (z:string) -> z |> Seq.sort |> System.String.Concat) input |> Array.distinct
    (if Array.length input = Array.length parsed then 1 else 0)

  let phase input func=
    Array.fold (fun acc (x:string) ->
      let y = x.Split ' '
      acc + func y
    ) 0 input
  
  let run() =
    let input = System.IO.File.ReadAllLines("..\Day 04\input.txt")
    printfn "Phase 1: %i" (phase input func1)
    printfn "Phase 2: %i" (phase input func2)