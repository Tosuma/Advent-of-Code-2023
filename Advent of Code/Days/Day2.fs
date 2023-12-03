module Day2
open System.IO
open System.Text.RegularExpressions
open System


// Extracts the information from the string
let getGameInformation (line: string) = 
    let pattern = "Game ([0-9]+): (.*)"
    let matchRes = Regex.Match(line, pattern)
    [|matchRes.Groups.[1].Value; matchRes.Groups.[2].Value|]


// Returns true if its an ipossible game
let anImpossibleGame (line: string) : bool =
    let redCubes = 12
    let greenCubes = 13
    let blueCubes = 14

    let separatorStrings = [| "; "; ", " |]
    line.Split(separatorStrings, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun draw ->
        let number = draw.Split(' ')[0] |> int
        let color = draw.Split(' ')[1]

        match color with
        | "red" -> number <= redCubes
        | "green" -> number <= greenCubes
        | "blue" -> number <= blueCubes
        | _ -> false
    )
    |> Array.exists (fun value -> not value)


// returns a value if the game is possible
let possibleGames (line: string) =
    let gameInfo = getGameInformation line
    let gameNumber = gameInfo[0] |> int
    let gameDraws = gameInfo[1]

    let conditionIsMet = not (anImpossibleGame gameDraws)
    
    if conditionIsMet then
        Some gameNumber
    else
        None


// Returns the maximum value for red, green and blue multiplied together
let calculatePower (data: (string * int) array) : int =
    data
    |> Array.groupBy fst
    |> Array.map (fun (color, value) ->
        color, value |> Array.maxBy snd |> snd
    )
    |> Array.map snd
    |> Array.fold (*) 1


// Returns an array of tuples contain a string and an int
let findMinCubes (line: string) : (string * int) array =
    let gameInfo = getGameInformation line
    let gameDraws = gameInfo.[1]
    
    let separatorStrings = [| "; "; ", " |]
    gameDraws.Split(separatorStrings, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun colorValue -> 
        let parts = colorValue.Split(' ')
        let value = int parts[0]
        let color = parts[1]
        (color, value)
    )
    


let task1() : int =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day2Task.txt"
    try
        File.ReadAllLines(filePath)
        |> Array.choose possibleGames
        |> Array.sum
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error


let task2() : int =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day2Task.txt"
    try
        File.ReadAllLines(filePath)
        |> Array.map findMinCubes
        |> Array.map calculatePower
        |> Array.sum
        
    with
    | ex ->
        printfn "An error occurred: %s" ex.Message
        0 // Return 0 in case of an error