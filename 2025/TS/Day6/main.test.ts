import { describe, it, expect } from "vitest";
import { readInput, readInput2, main } from './main.ts'

const sample = await readInput('../Inputs/Day6.sample.txt')
const input = await readInput('../Inputs/Day6.txt')

const sample2 = await readInput2('../Inputs/Day6.sample.txt')
const input2 = await readInput2('../Inputs/Day6.txt')

describe('part1', () => {
   it('should work with the sample', () => {
      expect(main(sample)).toBe(4277556)
   })

   it('should work with the input', () => {
      expect(main(input)).toBe(5977759036837)
   })
})

describe('part2', () => {
   it('should work with the sample', () => {
      expect(main(sample2)).toBe(4277556)
   })

   it('should work with the input', () => {
      expect(main(input2)).toBe(5977759036837)
   })
})
