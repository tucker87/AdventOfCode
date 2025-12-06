import { describe, it, expect } from "vitest";
import { largestJoltage, main } from './main.ts'
import { readLines } from '../Shared/readLines.ts'

const sample = () => readLines('../Inputs/Day3.sample.txt')

describe('largestJoltage', () => {
   it('should work', () => {
      expect(largestJoltage("987654321111111", 2)).toBe(98);
      expect(largestJoltage("811111111111119", 2)).toBe(89);
      expect(largestJoltage("234234234234278", 2)).toBe(78);
      expect(largestJoltage("818181911112111", 2)).toBe(92);
   })
})

describe('part1', () => {
   it('should work with the sample', async () => {
      expect(await main(sample())).toBe(357);
   })
})

describe('part2', () => {
   it('should work with the sample', async () => {
      expect(await main(sample(), 12)).toBe(3121910778619);
   })
})
