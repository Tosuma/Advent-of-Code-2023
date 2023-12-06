module Program

open System
open System.Diagnostics

let announceResult(testNumber: int) (result: int) =
    printfn "The result of task %d: %d" testNumber result

let beginDay dayNumber =
    printfn "+-------- Day %2d is beginning --------+" dayNumber

let main() =
    let task1 = 1
    let task2 = 2
    
    beginDay 1
    Day1.task1() |> announceResult task1
    Day1.task2() |> announceResult task2

    beginDay 2
    Day2.task1() |> announceResult task1
    Day2.task2() |> announceResult task2

    beginDay 3
    Day3.task1() |> announceResult task1
    //Day3.task2() |> announceResult task2

    beginDay 4
    Day4.task1() |> announceResult task1
    //Day4.task2() |> announceResult task2

    beginDay 6
    let sw = Stopwatch.StartNew()
    Day6.task1() |> announceResult task1
    sw.Stop()
    let sw1 = Stopwatch.StartNew()
    Day6.task2() |> announceResult task2
    sw1.Stop()
    printfn "Time taken: %f milliseconds" (sw.Elapsed.TotalMilliseconds)
    printfn "Time taken: %f milliseconds" (sw1.Elapsed.TotalMilliseconds)
    

main()