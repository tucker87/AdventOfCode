module Day11

let data = System.IO.File.ReadAllLines("../Inputs/Day11Test.txt")

type Val =
    | Number of int
    | Self

type Monkey =
    { items: int list
      operation: char * Val
      test: int
      true_op: int
      false_op: int }

let get_operation (arr: string array) =
    let n = arr[0]
    let c = arr[1]

    match n with
    | "old" -> (c[0], Self)
    | _ -> (c[0], Number(int n))

let get_nums_at_end (x: string) =
    let x = x.Split ':' |> Seq.skip 1 |> Seq.head
    x.Split ',' |> Seq.map int |> Seq.toList

let get_num_at_end (x: string) =
    x.Split ' ' |> Array.rev |> Array.head |> int

let gather_monkies (d: string array) =
    let d = Array.skip 1 d

    { items = get_nums_at_end d[0]
      operation = d[1].Split ' ' |> Array.rev |> Array.take 2 |> get_operation
      test = get_num_at_end d[2]
      true_op = get_num_at_end d[3]
      false_op = get_num_at_end d[4] }

// let worry monkey i =
//     match monkey.operation with
//     | ('*', Self) -> (i * i) / 3
//     | ('+', Self) -> (i + i) / 3

//     | ('*', x) -> (i * x) / 3
//     | ('+', x) -> (i + x) / 3
//     | _ -> failwithf $"What opeation is this? {monkey.operation}"

// let handle_item monkey i =
//     let worry_level = worry monkey i

//     if worry_level % monkey.test = 0 then
//         (worry_level, monkey.true_op)
//     else
//         (worry_level, monkey.false_op)

// let toss_item monkies i, (worry_level, target_monkey) =


// let handle_items monkey =
//     let passes = List.map (handle_item monkey) monkey.items

//     ()

// let run_sim monkies monkey =
//     List.iter handle_items monkies
//     0

// let solve1 =
//     let monkies = data |> Array.chunkBySize 7 |> Array.map gather_monkies

//     let result = Array.fold run_sim monkies monkies

//     "hi"
