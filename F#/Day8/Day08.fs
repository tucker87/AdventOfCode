module Day08

let data = System.IO.File.ReadAllLines("./Inputs/Day8.txt")

let getTrees (d: string array) =
    d 
    |> Array.map (fun x -> x.Trim()) 
    |> Array.map Array.ofSeq
    |> array2D
    |> Array2D.map (fun x -> int x - int '0')

let north x y (t: int array2d) = t.[..x-1,y] |> Array.rev
let south x y (t: int array2d) = t.[x+1..,y]
let west x y (t: int array2d) = t.[x,..y-1] |> Array.rev
let east x y (t: int array2d) = t.[x,y+1..]

let all_directions = [north; south; west; east]

let edge_check (trees: int array2d) a =
    match a with
    | (0, _) -> true
    | (_, 0) -> true
    | (x, _) when x = trees.[0, *].Length - 1 -> true
    | (_, y) when y = trees.[*, 0].Length - 1 -> true
    | _ -> false

let hidden_check trees x y height direction =
    direction x y trees |> Array.exists (fun z -> z >= height)

let is_visible trees x y value  =
    let isEdge = edge_check trees (x, y)
    let hidden = hidden_check trees x y value
    not isEdge && hidden north && hidden south && hidden west && hidden east

let rec score h acc a =
    match a with
    | [] -> acc
    | hd::_ when hd = h -> acc + 1
    | hd::rest when hd < h -> score h (acc + 1) rest
    | _ -> acc + 1

let score_check trees x y height direction =
    let trees = direction x y trees |> List.ofArray
    trees
    |> score height 0

let calc_scenic trees x y value =
    let score_direction =
        score_check trees x y value

    let isEdge = edge_check trees (x, y)
    if isEdge
    then 0
    else 
        List.map score_direction all_directions |> List.reduce (*)

let solve1 =
    let trees = getTrees data

    trees 
    |> Array2D.mapi (is_visible trees)
    |> Seq.cast<bool> 
    |> Seq.filter not
    |> Seq.length

let solve2 =
    let trees = getTrees data

    trees
    |> Array2D.mapi (calc_scenic trees)
    |> Seq.cast<int>
    |> Seq.max