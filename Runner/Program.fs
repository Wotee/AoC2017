open System.Diagnostics

let Timer func = 
  let sw = System.Diagnostics.Stopwatch.StartNew()
  func()
  sw.Stop()
  printfn "Elapsed: %i ms" sw.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
  match argv with
  | [|"1"|] -> Timer Day01.run
  | [|"2"|] -> Timer Day02.run
  | [|"3"|] -> Timer Day03.run
  | [|"4"|] -> Timer Day04.run
  | [|"5"|] -> Timer Day05.run
  | [|"6"|] -> Timer Day06.run
  | [|"7"|] -> Timer Day07.run
  | [|"8"|] -> Timer Day08.run
  | [|"9"|] -> Timer Day09.run
  | [|"10"|] -> Timer Day10.run
  | [|"11"|] -> Timer Day11.run
  | [|"12"|] -> Timer Day12.run
  | [|"13"|] -> Timer Day13.run
  | [|"14"|] -> Timer Day14.run
  | [|"15"|] -> Timer Day15.run
  | [|"16"|] -> Timer Day16.run
  | [|"17"|] -> Timer Day17.run
  | [|"18"|] -> Timer Day18.run
  | [|"19"|] -> Timer Day19.run
  | [|"20"|] -> Timer Day20.run
  | [|"21"|] -> Timer Day21.run
  | [|"22"|] -> Timer Day22.run
  | [|"23"|] -> Timer Day23.run
  | [|"24"|] -> Timer Day24.run
  | [|"25"|] -> Timer Day25.run
  | _ -> printfn "No parameters given!"
  System.Console.ReadKey() |> ignore
  0