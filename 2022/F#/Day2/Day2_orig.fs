module orig_Day2

let data = System.IO.File.ReadAllLines("./Day2/Input.txt") |> Array.toList

type Throw =
    | Rock = 'A'
    | Paper = 'B'
    | Scissors = 'C'

let pointsFromChoice c =
    match c with
    | Throw.Rock -> 1
    | Throw.Paper -> 2
    | Throw.Scissors -> 3
    | _ -> 0

let pointsFromGame op my =
    match (op, my) with
    | (Throw.Rock, Throw.Paper)
    | (Throw.Paper, Throw.Scissors)
    | (Throw.Scissors, Throw.Rock) -> 6
    | (a, b) when a = b -> 3
    | (_, _) -> 0

let toTheirFormat c =
    match c with
    | 'X' -> 'A'
    | 'Y' -> 'B'
    | 'Z' -> 'C'
    | _ -> '0'

let toThrow c =
    LanguagePrimitives.EnumOfValue<char, Throw> c

let solve1 =
    data
    |> Seq.map (fun x -> x.Split(' '))
    |> Seq.map (fun x -> (x[0][0], x[1][0]))
    |> Seq.map (fun (op, my) -> (op, toTheirFormat my))
    |> Seq.map (fun (op, my) -> (toThrow op, toThrow my))
    |> Seq.map (fun (op, my) -> pointsFromChoice my + pointsFromGame op my)
    |> Seq.sum