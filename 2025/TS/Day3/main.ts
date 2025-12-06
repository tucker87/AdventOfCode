import { sum } from '../Shared/generators.ts'

export const _largestJoltage = (batteries: string, offset: number, depth: number, maxDepth: number) => {
   if (batteries.length === 0 || depth === maxDepth)
      return ''

   let max = { a: -1, combo: -1 }
   for (let a = offset; a <= batteries.length - maxDepth + depth; a++) {
      let combo = Number(batteries[a])
      if (combo > max.combo)
         max = { a, combo }
   }

   return max.combo + _largestJoltage(batteries, max.a + 1, depth + 1, maxDepth)
}

export const makeLargestJoltage =
   (maxDepth: number) =>
      (batteries: string) =>
         Number(_largestJoltage(batteries, 0, 0, maxDepth))

export const main = async (lines: AsyncGenerator<string, void, unknown>, maxDepth: number = 2) => {
   const largestJoltage = makeLargestJoltage(maxDepth)
   return await sum(lines, largestJoltage)
}

