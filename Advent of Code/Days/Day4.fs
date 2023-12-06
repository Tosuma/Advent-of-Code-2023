module Day4
open System.IO
open System.Text.RegularExpressions
open System


let convertToInt (input: string array) : int array array =
    input
    |> Array.map (fun s -> s.Split(' '))
    |> Array.map (fun a -> 
        a
        |> Array.filter (fun s -> not (String.IsNullOrWhiteSpace(s)))
        |> Array.map (fun s -> int s)
    )


let getParts(input: string array) =
    let parts = 
            input
            |> Array.map (fun s -> s.Split(" | "))
    let firstPart =
        parts
        |> Array.map (fun s -> s.[0])
        |> Array.map (fun s -> Regex.Replace(s, @"Card\s*\d+:", ""))
        |> convertToInt

    let secondPart =
        parts
        |> Array.map (fun s -> s.[1])
        |> convertToInt

    firstPart, secondPart



let countMatchingNumbers (arr1: int array) (arr2: int array) =
    arr1
    |> Array.filter (fun num -> Array.exists (fun x -> x = num) arr2)
    |> Array.length


// 10 winner, 25 number to look at
let task1() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day4Task.txt"
    
    try
        let firstPart, secondPart =
            File.ReadAllLines(filePath)
            |> getParts
        
        
        firstPart
        |> Array.mapi (fun index arr1 ->
                countMatchingNumbers arr1 secondPart.[index]
        )
        |> Array.map (fun num -> 2.0 ** float (num - 1) |> int)
        |> Array.sum
        
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error



let task2() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day4Task.txt"
    let testInput = [|
        "Card   1: 18 39  5 97 33 74 70 35 40 72 | 62 23 33 94 18  5 91 74 86 88 82 72 51 39 95 35 44 87 65 15 46 10  3  2 84"
        "Card   2: 58 50 13 61 80 48 99 86 45 31 | 61 32 19  6 72 31 52 79 93 45 85 67 56 80  8  9 60 42 73 17 99 13 58 92 50"
        "Card   3: 65 10 18 47  8  4 99 51 71 48 | 85 87 88  8 48 18 47 67 95  4 99 86 53 51 65 44 61 10 28 14 77 71 21 58 42"
        "Card   4: 22 99 16 18 81  3 62 43  2 42 |  8 55 39 83 29 10 87 27 25 70 19 30 80 12  1 41 85 14 34 82 90 76  5 89 15"
        "Card   5: 23 45 94 25 59 75 22 97 62 57 | 75 87 97 22  5 74 99 42 92 57 66 55 89 56 71 30 25 90 35 20 23 62 59 65 16"
    |]
    try
        let firstPart, secondPart =
            File.ReadAllLines(filePath)
            //testInput
            |> getParts

        //let numOfMatches = firstPart
        //|> Array.mapi (fun index arr1 -> countMatchingNumbers arr1 secondPart.[index])

        0
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error
    