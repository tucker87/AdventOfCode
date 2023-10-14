let isDay (t: System.Type) =
    not <| t.Name.StartsWith "$"
    && t.Name.StartsWith "Day"

let runFunc (day: System.Type) (funcName: string) =
    let AorB = if funcName.EndsWith "1" then "A" else "B"
    let method = day.GetMethod funcName
    if method = null then
        printfn $"{day.Name}{AorB}: missing"
    else
        let output = method.Invoke(null, null)
        printfn $"{day.Name}{AorB}: {output}"

let bothSolves day =
    runFunc day "get_solve1"
    runFunc day "get_solve2"

System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
|> Seq.filter isDay
|> Seq.sortBy (fun t -> t.Name)
|> Seq.iter bothSolves
