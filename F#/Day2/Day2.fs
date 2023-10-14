module Day2
open Action

let data = System.IO.File.ReadAllLines("./Inputs/Day2.txt") |> Array.toList

let solve1 =
    let part1 acc (s:string) =
        let theirs = s[0] |> RPS.of_char 
        let ours =  s[2] |> RPS.toTheirFormat |> RPS.of_char 
        let played = RPS.pointsFromChoice ours
        let result = RPS.pointsFromGame (theirs, ours)
        acc + played + result
    Seq.fold part1 0 data

let solve2 =
    let part2 acc (s:string) =
        let theirs = RPS.of_char s[0]
        let outcome = Action.of_char s[2]
        let our_move =
            match outcome with
            | Loss -> RPS.get_lose theirs
            | Draw -> theirs
            | Win -> RPS.get_win theirs
        acc + Action.points outcome + RPS.pointsFromChoice our_move 
    Seq.fold part2 0 data