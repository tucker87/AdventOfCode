module RPS 
type RPS =
    | Rock
    | Paper
    | Scissors

let of_char = function
    | 'A' -> Rock
    | 'B' -> Paper
    | 'C' -> Scissors
    | _ -> Rock

let toTheirFormat = function
    | 'X' -> 'A'
    | 'Y' -> 'B'
    | 'Z' -> 'C'
    | _ -> '0'

let pointsFromChoice = function
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let pointsFromGame = function
    | (Rock, Paper)
    | (Paper, Scissors)
    | (Scissors, Rock) -> 6
    | (a, b) when a = b -> 3
    | _ -> 0

let get_win = function
    | Rock -> Paper
    | Paper -> Scissors
    | Scissors -> Rock

let get_lose = function
    | Rock -> Scissors
    | Paper -> Rock
    | Scissors -> Paper