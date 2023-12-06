module Day6
open System.IO
open System.Text.RegularExpressions
open System

//Extract the numbers from the strings
let getNumbers (line : string) : bigint array =
    Regex.Matches(line, @"(\d+)")
    |> Seq.toArray
    |> Array.map (fun m -> m.Groups.[1].Value |> float |> bigint)


//Brute force through all numbers
let calculateWaysToBeatRecord (time : bigint) (distance : bigint) : int =
    seq { for holdTime in 0I .. time - 1I -> min holdTime (time - holdTime) }
    |> Seq.filter (fun holdTime -> holdTime * (time - holdTime) > distance)
    |> Seq.length


//Calculate the determinant
let findDeterminant (b : bigint) (c : bigint) : bigint =
    b * b - 4I * -1I * c


//Calculates the two roots from the determinant
let findRoots (b : bigint) (d : bigint) : bigint * bigint =
    let sqrtD = d |> float |> sqrt
    let fb = b |> float
    let minRoot = (-fb + sqrtD) / -2.
    let maxRoot = (-fb - sqrtD) / -2.
    let actualMin = Math.Floor(minRoot + 1.) |> bigint
    let acutalMax = Math.Ceiling(maxRoot) |> bigint

    actualMin, acutalMax


//Calculates the product of amount of solutions for each race
let findAmountOfOptimals arr1 arr2 =
    Array.map2 (fun time distance ->
        let d = findDeterminant time (-distance)
        let x1, x2 = findRoots time d
        let delta = x2 - x1
        delta
    ) arr1 arr2
    |> Array.fold (fun acc x -> acc * x) 1I
    |> int


//Returns the concatenated number of array of bigints
let concatenateNumbers (numbers : bigint array) : bigint=
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
        
        findAmountOfOptimals times distances

        //Old way
        //Array.map2 calculateWaysToBeatRecord times distances
        //|> Array.reduce (*)
        
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

        findAmountOfOptimals [|times|] [|distances|]

        //Old way
        //calculateWaysToBeatRecord times distances
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error