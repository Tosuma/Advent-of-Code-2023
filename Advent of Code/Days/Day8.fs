module Day8

open System.IO
open System.Text.RegularExpressions
open System

let testInput = [|
    "LRLLLRRLRRLRRLRRLLRRLRRLLRRRLLRRLRRLRRLRRL"
    ""
    "RLP = (BMK, PCM)"
    "JTJ = (TVN, CJQ)"
    "PFR = (MMX, BQC)"
    "JGM = (NDJ, PCV)"
    "LVD = (TCK, PVR)"
    "SVS = (CDL, RNX)"
    "QDF = (XFG, NDX)"
    "TBH = (THM, DBC)"
|]

//Extracts the information from input array
let getInformation (input: string array) =
    let movement = input.[0]
    let data =
        input
        |> Array.map (fun s -> Regex.Match (s, @"(\w+) = \((\w+), (\w+)\)"))
        |> Array.filter (fun s -> not(s.Groups.[1].Value = ""))
        // |> Array.map (fun m -> m.Groups)
    printfn "%A" data.[0].Groups
    movement, data


let rec makeHashMap (input : Match array) (map : Map<string, string * string>) =
    0



//let rec something













let task1() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day6Task.txt"
    
    try
        let content = File.ReadAllLines(filePath)
        let movement, data =
            testInput
            |> Array.filter (fun s -> not(s = ""))
            |> getInformation


        0
        
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error



let task2() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day6Task.txt"
    try
        let content = File.ReadAllLines(filePath)
        0
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error