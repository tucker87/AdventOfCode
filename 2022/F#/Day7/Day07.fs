module Day07

let data = System.IO.File.ReadAllLines("../Inputs/Day7.txt")

type Folder = { parent: Option<Folder>; children: List<Folder>; name: string; files: List<int> }

type Command = { Name: string; Args: string }

type Dir = { Name: string }

type File = { Name: string; Size: int }

type Output =
    | Dir of Dir
    | File of File

type Line =
    | Command of Command
    | Output of Output

type State =
    { CurrentPath: string list
      Tree: Map<string list, Output list> }

let split (separators: string) (x: string) = x.Split(separators) |> List.ofArray

let parseLine line =
    let parts = line |> split " "

    let result: Line =
        match parts with
        | [ "$"; name; args ] -> Command { Name = name; Args = args }
        | [ "$"; name ] -> Command { Name = name; Args = "" } 
        | [ "dir"; name ] -> Output(Dir { Name = name })
        | [ size; name ] -> Output(File { Name = name; Size = int size })
        | _ -> failwith "unknown"

    result

let insert tree path node =
    let atPath = tree |> Map.tryFind path

    let updated =
        match atPath with
        | None -> [ node ]
        | Some things -> node :: things

    tree |> Map.add path updated

let initialState = { CurrentPath = []; Tree = Map.empty }

let processLine (state: State) line =
    let result =
        match line with
        | Command c when c.Name = "cd" && c.Args = ".." -> { state with CurrentPath = state.CurrentPath |> List.skip 1 }
        | Command c when c.Name = "cd" -> { state with CurrentPath = c.Args :: state.CurrentPath }
        | Output o -> { state with Tree = insert state.Tree state.CurrentPath o }
        | _ -> state

    result

let getOutputSize = function
    | Dir _ -> 0 
    | File f -> f.Size

let calculateSize_aux  acc _ z = acc + List.sumBy getOutputSize z

let calculateSize (tree:Map<string list, Output list>) (path: string list) =
    let folders = tree |> Map.filter (fun k _ -> 
        if k.Length >= path.Length then
            let pairs = Seq.zip (Seq.rev path) (Seq.rev k)
            pairs |> Seq.exists (fun (x, y) -> x <> y) |> not
        else
            false)

    let total = folders |> Map.fold calculateSize_aux 0
    total

let solve1 =
    let lines = data |> List.ofArray |> List.map (fun x -> parseLine x)
    let state = lines |> List.fold processLine initialState
    let paths = state.Tree |> Map.keys |> Seq.toList
    let sizes = paths |> List.map (fun dir -> dir, dir |> calculateSize state.Tree)
    let filtered = sizes |> List.filter (fun (_, s) -> s <= 100000)
    let result = filtered |> List.sumBy snd
    result

let solve2 =
    let capacity = 70_000_000
    let target = 30_000_000
    let lines = data |> List.ofArray |> List.map (fun x -> parseLine x)
    let state = lines |> List.fold processLine initialState
    let paths = state.Tree |> Map.keys |> Seq.toList
    let sizes = paths |> List.map (fun dir -> dir, dir |> calculateSize state.Tree) |> List.sortBy snd
    let used = sizes |> List.find (fun (x,_) -> x = ["/"]) |> snd
    let deleteMe = sizes |> List.find (fun (_, x) -> capacity - used + x >= target) |> snd

    deleteMe
