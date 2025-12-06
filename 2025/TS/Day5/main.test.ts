import { describe, it, expect } from "vitest";
import { readInput, part1, part2 } from './main.ts'

const sample = await readInput('../Inputs/Day5.sample.txt')
const input = await readInput('../Inputs/Day5.txt')

describe('part1', () => {
   it('should work on the sample', () => {
      expect(part1(sample)).toBe(3)
   })

   it('should work on the input', () => {
      expect(part1(input)).toBe(505)
   })
})

describe('part2', () => {
   it('should work on the sample', () => {
      expect(part2(sample)).toBe(14)
   })

   it('should work on the input', () => {
      expect(part2(input)).toBe(0)
   })
})
