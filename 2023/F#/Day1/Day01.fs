module Day1

open System

let data = System.IO.File.ReadAllLines("../Inputs/Day1.txt") |> List.ofArray

let getNumbers s = String.filter Char.IsDigit s

let rec getFirstAndLast (xs: string) : string =
    let a = xs[0]
    let b = xs |> Seq.last
    [a;b] |> String.Concat

let (|Prefix|_|) (p:string) (s:string) =
    if s.StartsWith(p) then
        Some(s.Substring(p.Length))
    else
        None

let rec subInNumbers (s: string) =
  match s with
  | Prefix "one" rest -> "1" + subInNumbers rest
  | Prefix "two" rest -> "2" + subInNumbers rest
  | Prefix "three" rest -> "3" + subInNumbers rest
  | Prefix "four" rest -> "4" + subInNumbers rest
  | Prefix "five" rest -> "5" + subInNumbers rest
  | Prefix "six" rest -> "6" + subInNumbers rest
  | Prefix "seven" rest -> "7" + subInNumbers rest
  | Prefix "eight" rest -> "8" + subInNumbers rest
  | Prefix "nine" rest -> "9" + subInNumbers rest
  | s when s.Length = 0 -> s
  | _ -> string s[0] + subInNumbers s[1..]

let solve input = 
  input 
  |> List.map getNumbers
  |> List.map getFirstAndLast
  |> List.map Int32.Parse 
  |> List.sum

let solve1 = data |> solve

let solve2 =
    data
    |> List.map subInNumbers
    |> solve
