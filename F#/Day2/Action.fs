module Action
type Action =
    | Loss
    | Draw
    | Win

let of_char = function
    | 'X' -> Loss
    | 'Y' -> Draw
    | 'Z' -> Win
    | _ -> Loss

let points = function
    | Win -> 6
    | Draw -> 3
    | _ -> 0