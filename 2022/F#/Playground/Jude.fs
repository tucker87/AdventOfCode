module Jude

type Animal =
    | Monkey
    | Human
    | Cat

let rnd = new System.Random()
let choose_animal =
    match rnd.Next(3) with
    | 0 -> Monkey
    | 1 -> Human
    | 2 -> Cat
    | _ -> failwith "HOW?!"

let is_a_monkey =
    let output = 
        match choose_animal with
        | Monkey -> "Jude is a monkey!"
        | x -> $"Jude is not a monkey...Jude is a {x}"

    printf $"{output}" 