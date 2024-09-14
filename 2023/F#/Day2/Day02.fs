module Day2

open Common

let data = System.IO.File.ReadAllLines("../Inputs/Day2.txt") |> List.ofArray

type Color =
  | Red of int
  | Green of int
  | Blue of int

  static member is_valid c =
    match c with
    | Red r -> r <= 12
    | Green g -> g <= 13
    | Blue b -> b <= 14

type Set = 
  { Colors: Color list }
  static member processColor c (data: string array) =
      match data[1] with
      | "red" -> { c with Colors = Red (int data[0]) :: c.Colors }
      | "green" -> { c with Colors = Green (int data[0]) :: c.Colors }
      | "blue" -> { c with Colors = Blue (int data[0]) :: c.Colors }
      | _ -> c

  static member fromString (line: string) =
      line 
      |> splitByCharArray [|',';' '|]
      |> Array.windowed 2
      |> Array.fold Set.processColor { Colors = [] }

  static member is_valid s =
      s.Colors |> List.forall (fun c -> Color.is_valid c)

type PowerSet = { Red: int; Green: int; Blue: int; }

type Game = 
  { Id: int; Sets: Set array }
  static member fromString(line: string) =
    let parts = line |> splitByString ": "
    let sets = parts[1] |> splitByString ";" |> Array.map Set.fromString
    {Id = int parts.[0].[5..]; Sets = sets}

  static member isValid g =
    g.Sets |> Array.forall Set.is_valid

  static member power g =
    let getColors s =
      Array.ofList s.Colors
    let bigSet acc s =
      match s with
      | Red a -> { acc with Red = max acc.Red a }
      | Green a -> { acc with Green = max acc.Green a }
      | Blue a -> { acc with Blue = max acc.Blue a }
    g.Sets 
    |> Array.collect getColors 
    |> Array.fold bigSet { Red = 0; Blue = 0; Green = 0 }
    |> (fun ps -> ps.Red * ps.Green * ps.Blue)


let sample = 
    [
      "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
      "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
      "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
      "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
      "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
    ]

let solve1 = 
  data
  |> List.map Game.fromString
  |> List.filter Game.isValid
  |> List.sumBy (fun g -> g.Id)

let solve2 =
  data
  |> List.map Game.fromString
  |> List.map Game.power
  |> List.sumBy (fun ps -> ps)
