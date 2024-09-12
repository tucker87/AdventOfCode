module Day01

let data = System.IO.File.ReadAllLines("../Inputs/Day1.txt")

let caloriesPerElf =
    data
    |> Seq.splitOnExclusive ((=) "")
    |> Seq.map (Seq.map System.Int32.Parse)
    |> Seq.map Seq.sum
    |> Seq.toList

let solve1 =
    caloriesPerElf
    |> Seq.max


let solve2 =
    let rec solve2aux input (m1, m2, m3) =
        match input with
        | [] -> (m1, m2, m3)
        | hd :: rest ->
            solve2aux rest
                (match (m1, m2, m3) with
                | m1, m2, _ when hd > m1 -> (hd, m1, m2)
                | m1, m2, _ when hd > m2 -> (m1, hd, m2)
                | m1, m2, m3 when hd > m3 -> (m1, m2, hd)
                | _ -> (m1, m2, m3))
    let (a,b,c) = solve2aux caloriesPerElf (0, 0, 0)
    a+b+c

let solve2Simple =
    caloriesPerElf
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum
