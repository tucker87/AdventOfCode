import { describe, it, expect } from "vitest";
import { makeLargestJoltage, main } from './main.ts'
import { readLines } from '../Shared/readLines.ts'

const sample = () => readLines('../Inputs/Day3.sample.txt')
const largestJoltage = makeLargestJoltage(2)

const input = () => readLines('../Inputs/Day3.txt')

describe('largestJoltage', () => {
   it('should work', () => {
      expect(largestJoltage("987654321111111")).toBe(98);
      expect(largestJoltage("811111111111119")).toBe(89);
      expect(largestJoltage("234234234234278")).toBe(78);
      expect(largestJoltage("818181911112111")).toBe(92);
   })
})

describe('part1', () => {
   it('should work with the sample', async () => {
      expect(await main(sample())).toBe(357);
   })

   it('should work with the input', async () => {
      expect(await main(input())).toBe(17107);
   })
})

describe('part2', () => {
   it('should work with the sample', async () => {
      expect(await main(sample(), 12)).toBe(3121910778619);
   })

   it('should work with the input', async () => {
      expect(await main(input(), 12)).toBe(169349762274117);
   })
})
