import { stepper, reduce, filter } from '../Shared/generators.ts'

const isValid = (n: string) => {
   if (n.length % 2 !== 0)
      return true

   const mid = n.length / 2
   const a = n.slice(0, mid)
   const b = n.slice(mid)

   return a !== b
}

const day1 = (inputs: string[]) => {
   const ranges = inputs
      .map(i => {
         const [a, b] = i.split('-');
         return stepper(Number(a), Number(b))
      })

   let answer = ranges.reduce((answer: number, range: Generator<number, void, unknown>) => {
      const invalids = filter((n: number) => !isValid("" + n), range)

      const sum = reduce((acc: number, curr: number) => acc + Number(curr), 0, invalids)
      return answer + sum
   }, 0)

   return answer
}

const readInput = async (path: string) =>
   (await Bun.file(path).text())
      .split(',')
      .map(s => s.trim())

const day1Input = await readInput('../Inputs/Day2.txt')
console.log(day1(day1Input))

export { isValid, readInput, day1 }
