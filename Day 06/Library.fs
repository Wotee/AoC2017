module Day06

  let updateSingleBank (bank : (int * int), maxBank : (int * int), bankCount : int) =
    let bankId = fst bank
    let maxBankId = fst maxBank
    let maxBankValue = snd maxBank
    let dividedValue = maxBankValue / bankCount
    let overhead = maxBankValue % bankCount
    
    (bankId, 
      match bankId with
        | _ when bankId = maxBankId -> dividedValue
        | _ when bankId < maxBankId && bankId < overhead - (bankCount - maxBankId - 1) -> dividedValue+ snd bank + 1
        | _ when bankId > maxBankId && bankId <= maxBankId + overhead -> dividedValue + snd bank + 1
        | _ -> dividedValue + snd bank  
    )    

  let rec updateBanks banks states count : (int*int) =
    // Calulate new state of banks from current "banks"
    let newState = Array.map(fun x -> updateSingleBank (x, Array.maxBy snd banks, count)) banks
    if (List.contains newState states) then      
      (List.length states, List.findIndex (fun x -> x = newState) states + 1)
    else      
      updateBanks newState (newState::states) count

  let run() =
    let input = System.IO.File.ReadAllText("..\Day 06\input.txt").Split '\t'|> Array.mapi (fun i x -> (i, int x))
    let result = updateBanks input [input] input.Length
    printfn "Phase 1: %i" (fst result)
    printfn "Phase 2: %i" (snd result)