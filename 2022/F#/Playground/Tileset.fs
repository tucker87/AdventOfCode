module Tileset

let foldi (folder: int -> int -> 'S -> 'T -> 'S) (state: 'S) (array: 'T[,]) =
    let mutable state = state
    for x in 0 .. Array2D.length1 array - 1 do
        for y in 0 .. Array2D.length2 array - 1 do
            state <- folder x y state (array.[x, y])
    state

let fst3 (x,_,_) = x

type Tile =
    | Water
    | Shore
    | Forest
    | ForestEdge
    | Grassland
    | Wall

let tile_string = function
    | Water -> "w"    
    | Shore -> "s"
    | Forest -> "f"
    | ForestEdge -> "e"
    | Grassland -> "g"
    | Wall -> "w"

let tile_compat = function
    | Water -> [Shore]
    | Shore -> [Grassland;Water]
    | Forest -> [Forest;ForestEdge]
    | ForestEdge -> [Grassland;Forest]
    | Grassland -> [Shore;Grassland;ForestEdge;Wall]
    | Wall -> [Grassland;Wall]

let rnd = new System.Random()
let get_random (a: 'a list) =
    if a.Length = 0 then
        printf "low"
    List.item (rnd.Next a.Length) a

type Cell = { entropy: int; tile_options: Tile list }
let init_cell = { entropy = 6; tile_options = [Water; Shore; Forest; ForestEdge; Grassland; Wall] }

type Board =
    val x: int
    val y: int
    val tiles: Cell array2d
    new(x, y) = { x = x; y = y; tiles = Array2D.init x y (fun _ _ -> init_cell) }
    
    member this.get_low_cells =
        let get_low_aux idx1 idx2 state elem = 
            match state with
            | [] when elem.entropy <> 1 -> (elem.entropy, idx1, idx2)::state
            | [hd]
            | hd::_ when elem.entropy <> 1 && elem.entropy <= fst3 hd -> (elem.entropy, idx1, idx2)::state
            | _ -> state
        
        foldi get_low_aux [] this.tiles
    
    member this.gen_complete = 
        this.get_low_cells.Length = 0
        

    
    member this.update_neighbor c (x, y, n)  =
        if n.entropy <> 1 then
            let compat_tiles = tile_compat c.tile_options.Head
            // let new_tile_options = List.fold (fun s o -> ) set n.tile_options
            let new_tile_options = Set.intersect (set compat_tiles) (set n.tile_options) |> Set.toList
            if new_tile_options.Length = 0 then 
                printf "oops"
            this.tiles[x, y] <- {n with entropy = new_tile_options.Length; tile_options = new_tile_options }
            //if we changed update neighbors neighbors
            let nn = this.get_neighbors x y
            nn |> List.iter (this.update_neighbor n)

    member this.set_tile =
        //Get Random Cell with lowest Entropy
        let (_, low_x, low_y) = get_random this.get_low_cells

        //Update cell
        let cell_to_update = this.tiles[low_x, low_y]
        let cell = { entropy = 1; tile_options = get_random cell_to_update.tile_options::[] }
        this.tiles[low_x, low_y] <- cell

        //Update Neighbors
        let n = this.get_neighbors low_x low_y
        n |> List.iter (this.update_neighbor cell)
    
    member this.get_neighbors x y =
        let result = []
        let result = if x > 0 then (x-1, y, this.tiles[x-1, y]) :: result else result
        let result = if y > 0 then (x, y-1, this.tiles[x, y-1]) :: result else result
        let result = if x < Array2D.base1 this.tiles - 1 then (x+1, y, this.tiles[x+1, y]) :: result else result
        let result = if y < Array2D.base2 this.tiles - 1 then 
                        (x, y+1, this.tiles[x, y+1]) :: result else result
        result

let print_cell x =
    printf "%s " (tile_string x.tile_options.Head)

let print_row r =
    Seq.iter print_cell r
    printfn ""

let print_board (b: Board) =
    b.tiles 
    |> Seq.cast<Cell> 
    |> Seq.chunkBySize 10
    |> Seq.iter print_row

let generate_world =
    let b = Board (10, 10)
    while not b.gen_complete do
        b.set_tile
        print_board b
        printfn ""

    printfn "Done"
    print_board b
    b

