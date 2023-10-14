module Day3

let data = System.IO.File.ReadAllLines("./Inputs/Day3.txt")

let char_value c =
    match System.Char.IsLower c with
    | true -> (int)c - 96
    | false -> (int)c - 38


let solve1 =
    let split_halves (s:string) =
        let front = s[0..s.Length/2-1]
        let back = s[s.Length/2..]
        (Set front, back)

    let score ((hash: Set<char>), str) =
        let get_value (acc, (hash: Set<char>)) c =
            let newValue =
                match Set.contains c hash with
                | true -> char_value c
                | false -> 0

            match newValue with
            | a when a > 0 -> (acc + newValue, hash.Remove c)
            | _ -> (acc, hash)
        let (result, _) = str |> Seq.fold get_value (0, hash)
        result
        
    data 
    |> Seq.map split_halves
    |> Seq.sumBy score

let solve2 = 
    let to_sets = function
        | [|a; b; c|] -> [Set a; Set b; Set c]
        | _ -> []
    
    data
    |> Array.chunkBySize 3
    |> Seq.map to_sets
    |> Seq.collect Set.intersectMany
    |> Seq.sumBy char_value

