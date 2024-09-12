module Common

open System

let splitByCharArray (sep: char array) (line: string) =
    line.Split(sep, StringSplitOptions.RemoveEmptyEntries)

let splitByString (sep: string) (line: string) =
  line.Split(sep, StringSplitOptions.RemoveEmptyEntries)
