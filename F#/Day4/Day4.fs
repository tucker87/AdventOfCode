module Day4

let data = System.IO.File.ReadAllLines("./Inputs/Day4.txt")

let solve1 =
    let to_ranges (x:string array) = 
        let two_tuple a =
            match a with
            | [|j;k|] -> (j, k)
            | _ -> (0, 0)

        let two_ints (s:string) =
            s.Split '-' |> Array.map System.Int32.Parse

        let (a, b) = 
            match x with
            | [|a;b|] -> (two_ints a, two_ints b)
            | _ -> ([||], [||])
        
        let (start1, stop1) = two_tuple a
        let (start2, stop2) = two_tuple b
        let set1 = Set [start1..stop1]
        let set2 = Set [start2..stop2]
        (set1, set2)


    data 
    |> Seq.map (fun x -> x.Split ',')
    |> Seq.map to_ranges

    |> Seq.sumBy (fun (s1, s2) -> 
        if s2.IsSubsetOf s1 
        || s1.IsSubsetOf s2 
            then 1 
            else 0)
