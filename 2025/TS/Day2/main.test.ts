import { describe, it, expect } from "vitest";
import { isValid, isValid2, part1, part2, readInput } from './main.ts'


describe('isValid', () => {
   it('should work on two digits', () => {
      expect(isValid("22")).toBe(false);
      expect(isValid("12")).toBe(true);
   })

   it('should work on three digits', () => {
      expect(isValid("223")).toBe(true);
      expect(isValid("111")).toBe(true);
   })

   it('should work on four digits', () => {
      expect(isValid("2222")).toBe(false);
      expect(isValid("1234")).toBe(true);
      expect(isValid("1212")).toBe(false);
   })
})

describe('part1', () => {
   it('should work', async () => {
      expect(await part1(['10-11'])).toBe(11)
      expect(await part1(['123-123', '12345-12345'])).toBe(0)
      expect(await part1(['11-44'])).toBe(110)
      expect(await part1(['11-22'])).toBe(33)
      expect(await part1(['11-44', '11-22'])).toBe(143)
   })

   it('should work on the sample', async () => {
      const sample = await readInput('../Inputs/Day2.sample.txt')
      expect(await part1(sample)).toBe(1227775554)
   })

   it('should work on the input', async () => {
      const input = await readInput('../Inputs/Day2.txt')
      expect(await part1(input)).toBe(44487518055)
   })
})

describe('part2', () => {
   it('should work', () => {
      expect(isValid2('11')).toBe(false)
      expect(isValid2('12')).toBe(true)
      expect(isValid2('13')).toBe(true)
      expect(isValid2('14')).toBe(true)
      expect(isValid2('15')).toBe(true)
      expect(isValid2('22')).toBe(false)
      expect(isValid2('23')).toBe(true)
      expect(isValid2('1188511885')).toBe(false)
   })

   it('should work on the sample', async () => {
      const sample = await readInput('../Inputs/Day2.sample.txt')
      expect(await part2(sample)).toBe(4174379265)
   })

   it('should work on the input', async () => {
      const input = await readInput('../Inputs/Day2.txt')
      expect(await part2(input)).toBe(53481866137)
   })
})
