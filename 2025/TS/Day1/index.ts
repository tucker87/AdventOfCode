import nReadlines from 'n-readlines'

const lines = new nReadlines('../../Inputs/Day1.txt');

const dir = {
   L: (a: number, b: number) => a - b,
   R: (a: number, b: number) => a + b
}
const makeWrap = (start: number) => (direction: string, i: number) => {
   console.log(start, direction, i)
   start = dir[direction](start, i)
   while (start < 0)
      start += 100

   while (start > 99)
      start -= 100

   return start
}

const wrap = makeWrap(50)
let line: string;
let zeroCount: number = 0
while (line = lines.next()) {
   line = line.toString()
   const i = wrap(line[0], Number(line.substring(1)))
   if (i === 0)
      zeroCount++
}

console.log(zeroCount)
