module Day01
  let phase1 (input:string) : int =
     // Create pairwise tuples with first letter of the string added to the end to fake circularity
    Seq.pairwise (input + string input.[0])
     // Filter where characters of the tuple match
    |> Seq.filter (fun (a, b) -> a = b)
     // Sum by first values in tuple after ASCII Conversion
    |> Seq.sumBy (fun x -> int (fst x) - 48)

  let phase2 (input:string) : int =
    // Create indexed dataset, with duplicate input to fake circularity
    let doubleData = Seq.mapi (fun i x -> i, x) (input + input)
    let size = input.Length
    // Process the original values, where same number is halfway aroung the circle
    Seq.filter(fun(i, x) -> i < size && x = snd (Seq.item (i + size / 2) doubleData)) doubleData
    // Sum by second values after ASCII Conversion
    |> Seq.sumBy (fun x -> int (snd x) - 48)

  let run() =
    let input = System.IO.File.ReadAllText("..\Day 01\input.txt")
    printfn "Phase 1: %i" (phase1 input)
    printfn "Phase 2: %i" (phase2 input)