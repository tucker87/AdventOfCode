module Day10

let data = System.IO.File.ReadAllLines("./Inputs/Day10.txt")

type Addx = { value: int; steps_left: int }

type Instruction =
    | Noop
    | Addx of Addx

type State = { 
    cycle: int; 
    register: int; 
    instructions: Instruction list; 
    running: Instruction Option;
    history: (int * int) list
}

let init_state = { cycle = 1; register = 1; instructions = []; running = None; history = [] }

let parse_instruction (i: string) =
    let parts = i.Split ' '
    match parts with
    | [|"addx"; v|] -> Addx { value = int v; steps_left = 2 }
    | _ -> Noop

let rec run_code (state:State) =
    let state = 
        match state.running with
        | None
        | Some Noop -> { state with running = None }
        | Some (Addx i) when i.steps_left = 2 -> { state with running = Some(Addx { i with steps_left = 1 }) }
        | Some (Addx i) -> { state with register = state.register + i.value; running = None }

    let state = { state with history = (state.cycle, state.register)::state.history }
    let state = { state with cycle = state.cycle + 1; }
    
    match state.instructions with
    | [] when state.running <> None -> run_code state
    | [] -> state.history |> List.skip 1 |> List.rev
    | hd::rest when state.running = None -> run_code { state with running = Some(hd); instructions = rest }
    | _ -> run_code state

let solve1 =
    let ins = data |> Seq.map parse_instruction |> List.ofSeq
    let history = run_code { init_state with instructions = ins }
    
    history
    |> List.filter (fun x -> fst x % 20 = 0)
    |> List.mapi (fun i x -> if i % 2 = 0 then Some x else None) |> List.choose id
    |> List.fold (fun acc (c, r) -> acc + c * r ) 0

let solve2 =
    let ins = data |> Seq.map parse_instruction |> List.ofSeq
    let history = run_code { init_state with instructions = ins }

    history
    |> List.map (fun (c, r) -> (c - 1, r))
    |> List.map (fun (c, r) -> (c % 40, r))
    |> List.map (fun (c, r) -> if c = r || c = r-1 || c = r+1 then '#' else '.')
    |> List.chunkBySize 40
    |> List.fold (fun acc c -> acc + (System.String (List.toArray c) + "\n" )) "\n"
    