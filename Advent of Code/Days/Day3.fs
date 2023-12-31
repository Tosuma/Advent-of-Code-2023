﻿module Day3
open System.IO
open System.Text.RegularExpressions
open System



open System
open System.Collections.Generic
open System.Linq

// Transforms an array of strings into a 2d char array
let to2DCharArray (arrayOfStrings: string[]) : char[,] =
    let numRows = arrayOfStrings.Length
    let numCols = arrayOfStrings.[0].Length

    Array2D.init numRows numCols (fun i j -> arrayOfStrings.[i].[j])


let getGearsInLine (line: string) : Match seq =
    Regex.Matches(line, @"\*+")


// Extracts the numbers in a string
let getNumbersInLine (line: string) : Match seq =
    Regex.Matches(line, "\\d+")


// Checks if cells with the same row and different columns is surrounded by a symbol
let isSurroundedBySymbol (array: char[,]) (row: int) (cols: int list) : bool =
    let rowLength, colLength = Array2D.length1 array, Array2D.length2 array

    let isValidIndex r c =
        r >= 0 && r < rowLength && c >= 0 && c < colLength

    let neighbors r c =
        [
            (r-1, c-1); (r-1, c); (r-1, c+1)
            (r, c-1);             (r, c+1)
            (r+1, c-1); (r+1, c); (r+1, c+1)
        ]

    let isNonDigitOrDot r c =
        isValidIndex r c && (not (Char.IsDigit array.[r, c] || array.[r, c] = '.'))

    let checkCellSurroundings r c =
        neighbors r c |> List.exists (fun (nr, nc) -> isNonDigitOrDot nr nc)

    cols |> List.exists(fun c -> checkCellSurroundings row c)


// Returns the value of the number if it is surrounded by a symbol
let processNumber (rowNumber: int) (numberData: Match) (array: char [,]) : int =
    let number = int numberData.Value
    let sizeOfNumber = numberData.Value.Length
    let cols = List.init sizeOfNumber (fun i -> i + numberData.Index)
    
    if isSurroundedBySymbol array rowNumber cols then number else 0



//let isNextToGear (array: char [,]) (row: int) (cols: int list) : bool =
//    let rowLength, colLength = Array2D.length1 array, Array2D.length2 array
    
//    let isValidIndex r c =
//        r >= 0 && r < rowLength && c >= 0 && c < colLength

//    let neighbors r c =
//        [
//            (r-1, c-1); (r-1, c); (r-1, c+1)
//            (r, c-1);             (r, c+1)
//            (r+1, c-1); (r+1, c); (r+1, c+1)
//        ]

//    let isAGear r c =
//        isValidIndex r c && array[r, c] = '*'

//    let checkCellSurroundings r c =
//        neighbors r c |> List.exists (fun (nr, nc) -> isAGear nr nc)

//    cols |> List.exists(fun c -> checkCellSurroundings row c)


//let getGearLocation (array: char [,]) (row: int) (cols: int list) : int * int =
//    let rowLength, colLength = Array2D.length1 array, Array2D.length2 array
//    let neighbors r c =
//        [
//            (r-1, c-1); (r-1, c); (r-1, c+1)
//            (r, c-1);             (r, c+1)
//            (r+1, c-1); (r+1, c); (r+1, c+1)
//        ]

//    let isAGear r c =
//        isValidIndex r c && array[r, c] = '*'

//    let checkCellSurroundings r c =
//        neighbors r c |> List.exists (fun (nr, nc) -> isAGear nr nc)

//    cols |>


//let processGear (rowNumber: int) (gearData: Match) (array: char [,]) : int =
//    let number = int gearData.Value
//    let sizeOfNumber = gearData.Value.Length
//    let cols = List.init sizeOfNumber (fun i -> i + gearData.Index)
    
    
//    if not (isNextToGear array rowNumber cols) then 0
//    else
//        let stuff = getGearLocation
        

    
//    1



let task1 () =
    let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day3Task.txt"
    try
        let content = File.ReadAllLines(filePath)
        let matches = content |> Array.map getNumbersInLine
        let inputAsArray: char [,] = to2DCharArray content

        matches
        |> Array.mapi (fun row ms ->
            ms
            |> Seq.toArray
            |> Array.map (fun m -> processNumber row m inputAsArray)
            |> Array.sum
        )
        |> Array.sum
        
    with
    | ex ->
        printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
        0 // Return 0 in case of an error



let task2 () = 
    //let filePath = @"C:\Coding-Git\Advent-of-Code-2023\Advent of Code\tasks\Day3Task.txt"
    //try
    //    let content = File.ReadAllLines(filePath)
    //    let test = [|
    //        "467..114.."
    //        "...*......"
    //        "..35..633."
    //        "......#..."
    //        "617*......"
    //        ".....+.58."
    //        "..592....."
    //        "......755."
    //        "...$.*...."
    //        ".664.598.."
    //    |]
    //    let matches = test |> Array.map getNumbersInLine
    //    let inputAsArray: char [,] = to2DCharArray content

    //    let test2 = to2DCharArray test

    //    matches
    //    |> Array.mapi (fun row ms ->
    //        ms
    //        |> Seq.toArray
    //        |> Array.map (fun m -> printfn "%A" m.Groups; processGear row m test2)
    //        |> Array.sum
    //    )
    //    |> Array.sum
        
    //with
    //| ex ->
    //    printfn "An error occurred: %s -->\n%s" ex.Message ex.StackTrace
    //    0 // Return 0 in case of an error
    0
