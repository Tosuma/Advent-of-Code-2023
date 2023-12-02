module Day1

open System.IO
open System.Text.RegularExpressions


// Search and replace digit-strings to contain their integer
let searchAndReplace (line: string) : string =
    let replacements = [("one", "o1e"); ("two", "t2o"); ("three", "t3ree"); ("four", "f4ur"); ("five", "f5ve"); ("six", "s6x"); ("seven", "s7ven"); ("eight", "e8ght"); ("nine", "n9ne")]
    replacements
    |> List.fold (fun (acc: string) (search, replace) -> acc.Replace(search, replace)) line


let extractFirstAndLastDigits (line: string) : int =
    let matchResult = Regex.Match(line, "(\d).*(\d).*")
    match matchResult.Success with
    | true ->
        let firstDigit = int (matchResult.Groups.[1].Value)
        let lastDigit = int (matchResult.Groups.[2].Value)
        firstDigit * 10 + lastDigit
    | false -> 
        let singleDigit = Regex.Match(line, ".*(\d).*").Groups.[1].Value |> int
        singleDigit * 10 + singleDigit


let task1() =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day1Task.txt"
    try
        File.ReadAllLines(filePath)
        |> Array.map extractFirstAndLastDigits
        |> Array.sum
    with
    | ex ->
        printfn "An error occurred: %s" ex.Message
        0 // Return 0 in case of an error


let task2() : int=
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day1Task.txt"
    try
        File.ReadAllLines(filePath)
        |> Array.map searchAndReplace
        |> Array.map extractFirstAndLastDigits
        |> Array.sum
    with
    | ex ->
        printfn "An error occurred: %s" ex.Message
        0 // Return 0 in case of an error