module Day06

let data = System.IO.File.ReadAllLines("./Inputs/Day6.txt").[0]

let solve1 =
    let rec solve1_aux index input =
        match input with
        | a::b::c::d::_ when a <> b && a <> c && a <> d && b <> c && b <> d && c <> d -> index + 4
        | _ :: rest -> solve1_aux (index+1) rest
        | _ -> -1

    solve1_aux 0 (data |> Array.ofSeq |> List.ofArray)

let solve2 =
    let rec solve2_aux index (input:char[]) =
        let r = input[..13]
        let s = set r
        if s.Count = 14 then 
            index + 14
        else 
            solve2_aux (index+1) input[1..]

    solve2_aux 0 (data |> Array.ofSeq)