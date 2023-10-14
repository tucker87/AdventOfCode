module Day3

let data = System.IO.File.ReadAllLines("./Inputs/Day3.txt")

let solve1 =
    let value (hash: Set<char>) str =
        let get_value (acc, (hash: Set<char>)) c =
            let newValue =
                match Set.contains c hash with
                | true when System.Char.IsLower c -> (int)c - 96
                | true -> (int)c - 38
                | false -> 0

            match newValue with
            | a when a > 0 -> (acc + newValue, hash.Remove c)
            | _ -> (acc, hash)
        let (result, _) = str |> Seq.fold get_value (0, hash)
        result

    let aux (s:string) =
        let front = s[0..s.Length/2-1]
        let back = s[s.Length/2..]
        value (Set front) back
        
    data |> Seq.sumBy aux

let solve2 = 
    let get_value c =
        match System.Char.IsLower c with
        | true -> (int)c - 96
        | false -> (int)c - 38

    let to_sets = function
        | [|a; b; c|] -> [Set a; Set b; Set c]
        | _ -> []
    
    data 
    |> Array.chunkBySize 3
    |> Seq.map to_sets
    |> Seq.collect Set.intersectMany
    |> Seq.sumBy get_value

