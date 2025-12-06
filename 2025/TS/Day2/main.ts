import { reduce } from '../Shared/generators.ts'
import { range, asyncFilter } from 'iter-tools'

export const isValid = (n: string) => {
   if (n.length % 2 !== 0)
      return true

   const mid = n.length / 2
   const a = n.slice(0, mid)
   const b = n.slice(mid)

   return a !== b
}

export const part1 = (inputs: string[]) => main(isValid, inputs)

export const isValid2 = (n: string) => !n.match(/^(\d+)\1+$/g)
export const part2 = (inputs: string[]) => main(isValid2, inputs)

export const readInput = async (path: string) =>
   (await Bun.file(path).text())
      .split(',')
      .map(s => s.trim())

export const main = async (validCheck: Function, inputs: string[]) => {
   const ranges = inputs
      .map(i => {
         const [a, b] = i.split('-');
         return range(Number(a), Number(b) + 1)
      })

   let answer = ranges.reduce(async (answer: Promise<number>, r: Iterable<number>) => {
      const invalids = asyncFilter((n: number) => !validCheck("" + n), r)

      const sum = await reduce((acc: number, curr: number) => acc + Number(curr), 0, invalids)
      return await answer + sum
   }, Promise.resolve(0))

   return answer
}
