module Day04

let data = System.IO.File.ReadAllLines("./Inputs/Day4.txt")

let to_ranges (x:string array) = 
        let two_ints (s:string) =
            s.Split '-' 
            |> Array.map System.Int32.Parse
            |> (fun z -> Set [z[0]..z[1]] )

        (two_ints x[0], two_ints x[1])

let to_sets d =
    data 
    |> Seq.map (fun x -> x.Split ',')
    |> Seq.map to_ranges

let solve1 =
    let is_subset (s1, s2) =
        if Set.isSubset s1 s2 || Set.isSubset s2 s1 then 1 else 0

    data
    |> to_sets 
    |> Seq.sumBy is_subset

let solve2 =
    let is_inter (s1, s2) =
        if (Set.intersect s1 s2).Count > 0 then 1 else 0

    data
    |> to_sets 
    |> Seq.sumBy is_inter