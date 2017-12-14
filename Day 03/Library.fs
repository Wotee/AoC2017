module Day03
  
  let phase1 input =
    // Check on which ring input is
    let ring = int ((ceil((sqrt (float input) + 1.0) / 2.0))-1.0)    
    // Add distance to "nearest center" to ring
    ring + (Array.min (Array.init 4 (fun i -> abs(2*ring*(2*ring+2+i)+1-ring-input))))

  let nextIndicesFromCorner array =
    let n = Array.length array / 4
    Array.init 4 (fun i -> (i+1)*n)

  let getCornerIndices array = 
    nextIndicesFromCorner array |> Array.map (fun x -> x-1)

  let rec OuterRingInit innerRing side =
    let sideLength = (Array.length innerRing + 8) / 4
    [|
      yield! Array.init sideLength (fun i -> 
      match i with
      // First value
      | 0 when side = 0 -> (Array.head innerRing) + (Array.last innerRing)
      // Second value
      | 1 when side = 0 -> (Array.last innerRing) + Array.sum innerRing.[0..1]
      // First of side
      | 0 -> let x = Array.item (side-1) (getCornerIndices innerRing)
             Array.sum innerRing.[x..x+1]
      // Corner
      | i when i = sideLength-1 -> innerRing.[((getCornerIndices innerRing).[side])]
      // One before corner
      | i when i = sideLength-2 -> let x = (getCornerIndices innerRing).[side]
                                   Array.sum innerRing.[x-1..x]
      // Others
      | _ -> let x = i+(side*(sideLength-2))
             innerRing.[x-2] + innerRing.[x-1] + innerRing.[x]
      )
      if side < 3 then
        yield! OuterRingInit innerRing (side+1)
    |]

  let rec CalculateOuterRec (ring:array<int>) side prev1 prev2 i : array<int>=
    let current = 
      match i with
      | 0 when side = 0 -> ring.[0]
      | 1 when side = 0 -> Array.sum ring.[0..1]
      | i when Array.contains i (nextIndicesFromCorner ring) && i >= Array.length ring - 2 -> ring.[i] + prev1 + prev2 + ring.[0]
      | i when Array.contains i (nextIndicesFromCorner ring) -> ring.[i] + prev1 + prev2
      | i when i >= Array.length ring - 2 -> ring.[i] + prev1 + ring.[0]
      | _ -> ring.[i] + prev1
    [|
      yield current
      if i < Array.length ring - 1 then
        yield! CalculateOuterRec ring (side+1) current prev1 (i+1)
    |]
  
  let CalculateOuter ring = 
    CalculateOuterRec ring 0 0 0 0

  let CalculateNextRing innerRing=
    CalculateOuter (
      if Array.length innerRing = 1 then
        Array.create 8 1
      else
        OuterRingInit innerRing 0
    )

  let phase2 input =
    let rec calculateNextRingUntilBiggerThan array input =
      if Array.max array > input then
        array |> Array.filter(fun x -> x > input) |> Array.min
      else
        calculateNextRingUntilBiggerThan (CalculateNextRing array) input
    calculateNextRingUntilBiggerThan [|1|] input
  
  let run() =
    let input = 312051
    printfn "Phase 1: %i" (phase1 input)
    printfn "Phase 2: %i" (phase2 input) // The answer is 312453