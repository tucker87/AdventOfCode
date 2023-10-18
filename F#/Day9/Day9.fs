module Day9

let enable_draw = false

let data = System.IO.File.ReadAllLines("./Inputs/Day9.txt")

type Location = int * int

type Movement =
    | Up
    | Down
    | Left
    | Right

let movement = function
    | "U" -> Up
    | "D" -> Down
    | "L" -> Left
    | "R" -> Right
    | _ -> failwith "unknown movement"

let parse_movement (s:string) =
    let parts = s.Split ' '
    let move = movement parts.[0]
    List.init (int parts.[1]) (fun _ -> move)

let exec_move move elem =
    let x, y = elem
    match move with
    | Up -> (x+1, y)
    | Down -> (x-1, y)
    | Left -> (x, y-1)
    | Right -> (x, y+1)

let sub (ax, ay) (bx, by) =
    (ax-bx, ay-by)

let exec_follow h t =
    let p = sub t h
    let a, b = t

    match p with
    | (1, 1)
    | (-1, -1)
    | (1, -1)
    | (-1, 1) -> t

    | (x, y) when x < 0 && y < 0 -> (a+1, b+1)
    | (x, y) when x > 0 && y > 0 -> (a-1, b-1)
    | (x, y) when x < 0 && y > 0 -> (a+1, b-1)
    | (x, y) when x > 0 && y < 0 -> (a-1, b+1)

    | (x, _) when x = 2 -> (a-1, b)
    | (x, _) when x = -2 -> (a+1, b)
    | (_, y) when y = 2 -> (a, b-1)
    | (_, y) when y = -2 -> (a, b+1)

    | (x, y) when x > -2 && x < 2 && y > -2 && y < 2 -> t
    | (x, y) -> failwithf "unknown move %d %d" x y

let format_pos (a, b) =
    string a + " " + string b

let maxX = Seq.map fst >> Seq.max
let maxY = Seq.map snd >> Seq.max

let rec shift elems = 
    let found = elems |> List.fold (fun f x -> f && (fst x >= 0 && snd x >= 0)) true
    if found
    then elems
    else
        shift (elems |> List.map (fun (x, y) -> (x+1, y+1)))

let char_format (arr: char array2d) i (x, y) =
    let c = if i = 0 then 'H' else (string >> char) i
    arr[x, y] <- c

let draw elems =
    let shifted = shift elems

    let topX = maxX shifted
    let topY = maxY shifted
    let arr = Array2D.create (topX + 1) (topY + 1) '.'

    shifted |> List.iteri (char_format arr)

    for r = Array2D.length1 arr - 1 downto 0 do
             printfn "%A " arr[r, *]

    printfn "---------------------"

let follow_all x y = 
    let nt = exec_follow x y
    (nt, nt)

let rec do_big_moves h ts pos moves =
    match moves with
    | [] -> pos
    | hd::rest -> 
        let newHeadPos = exec_move hd h
        let newTailsPos, realTail = ts |> List.mapFold follow_all newHeadPos
        if enable_draw then
            let elems = newHeadPos::newTailsPos
            draw elems
        do_big_moves newHeadPos newTailsPos (realTail::pos) rest

let solve1 =
    let movements = data |> Seq.collect parse_movement |> List.ofSeq
    let positions = do_big_moves (0, 0) [(0, 0)] List.empty movements |> List.distinct
    positions |> List.length

let solve2 =
    let movements = data |> Seq.collect parse_movement |> List.ofSeq
    let tails = List.init 9 (fun _ -> (0,0))
    let positions = do_big_moves (0, 0) tails List.empty movements |> List.distinct
    positions |> List.length