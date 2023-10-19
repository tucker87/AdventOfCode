module Day05
open System
let data = System.IO.File.ReadAllLines("./Inputs/Day5.txt")


let replace (s1: string) (s2: string) (x: string) = x.Replace(s1, s2)
let removeEmptyValues x = x |> List.filter ((<>) ' ')
let split (separators: string) (x: string) = x.Split(separators)
let remove i x = x |> List.take (x.Length - i)

let parseState x =
    x
    |> replace "    " "-"
    |> replace " " ""
    |> replace "-" " "
    |> replace "[" ""
    |> replace "]" ""

let parseInstruction x =
    let result = x |> split " "
    (int result[1], int result[3] - 1, int result[5] - 1)

let parseInput (data:string[]) = 
    let emptyRowIndex = data |> Array.findIndex (fun x -> String.IsNullOrEmpty x)
    let parts = data |> Array.splitAt emptyRowIndex
    
    let state =
        fst parts
        |> Array.toList
        |> remove 1
        |> List.map parseState
        |> List.map List.ofSeq
        |> List.transpose
        |> List.map removeEmptyValues
        |> List.map List.rev

    let instructions =
        snd parts
        |> (fun x -> x[1..])
        |> Array.map parseInstruction
        |> Array.toList

    (state, instructions)

let applyInstruction9000 (x: list<list<char>>) (amount, src, dst) =

    let a, c = x[src] |> List.rev |> List.splitAt amount
    let b = x[dst] @ a
    let d = x |> List.updateAt dst b |> List.updateAt src (List.rev c)

    d

let applyInstruction9001 (x: list<list<char>>) (amount, src, dst) =

    let a = x[src] |> List.rev |> List.take amount |> List.rev
    let b = x[dst] @ a

    let c = List.updateAt dst b x
    let d = x[src] |> remove amount
    let e = List.updateAt src d c

    e

let solve1 =
    let state, instructions = data |> parseInput 
    let foo =
        instructions
        |> List.fold applyInstruction9000 state
        |> List.map List.rev
        |> List.map List.head
        |> Array.ofList 
        |> String

    foo
    
let solve2 =
    let state, instructions = data |> parseInput 

    let foo =
        instructions
        |> List.fold applyInstruction9001 state
        |> List.map List.rev
        |> List.map List.head
        |> Array.ofList 
        |> String

    foo