import { describe, it, expect } from "vitest";
import { readInput, part1, part2, filterRanges, mergeRanges } from './main.ts'

const sample = await readInput('../Inputs/Day5.sample.txt')
const input = await readInput('../Inputs/Day5.txt')

describe('filterRanges', () => {
   it('should filter ranges', () => {
      expect(filterRanges([{ min: 2, max: 10 }, { min: 2, max: 10 }]).length).toBe(1)
   })
})

describe('mergeRanges', () => {
   it('should alter ranges', () => {
      expect(mergeRanges([{ min: 2, max: 10 }, { min: 4, max: 30 }, { min: 50, max: 60 }]))
         .toEqual([{ min: 2, max: 30 }, { min: 2, max: 30 }, { min: 50, max: 60 }])
      expect(mergeRanges([{ min: 2, max: 10 }, { min: 4, max: 12 }]))
         .toEqual([{ min: 2, max: 12 }, { min: 2, max: 12 }])
   })
})

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
