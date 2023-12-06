module Day6
open System.IO
open System.Text.RegularExpressions
open System

let getNumbers (line : string) : bigint array =
    Regex.Matches(line, @"(\d+)")
    |> Seq.toArray
    |> Array.map (fun m -> m.Groups.[1].Value |> float |> bigint)


let calculateWaysToBeatRecord (time : bigint) (distance : bigint) : int =
    seq { for holdTime in 0I .. time - 1I -> min holdTime (time - holdTime) }
    |> Seq.filter (fun holdTime -> holdTime * (time - holdTime) > distance)
    |> Seq.length


let concatenateNumbers (numbers : bigint array) =
    numbers
    |> Array.map string
    |> String.concat ""
    |> float
    |> bigint


let task1() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day6Task.txt"
    
    try
        let content = File.ReadAllLines(filePath)
        let times = content.[0] |> getNumbers
        let distances = content.[1] |> getNumbers
        
        Array.map2 calculateWaysToBeatRecord times distances
        |> Array.reduce (*)
        
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error



let task2() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day6Task.txt"
    try
        let content = File.ReadAllLines(filePath)
        let times = content.[0] |> getNumbers |> concatenateNumbers
        let distances = content.[1] |> getNumbers |> concatenateNumbers

        calculateWaysToBeatRecord times distances
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error