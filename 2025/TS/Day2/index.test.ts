import { describe, it, expect } from "vitest";
import { isValid, readInput, day1 } from './index.ts'


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

describe('day1', () => {
   it('should work on the sample', async () => {
      const day1Sample = await readInput('../Inputs/Day2.sample.txt')
      expect(day1(day1Sample)).toBe(1227775554)
   })
   it('should work', () => {
      expect(day1(['10-11'])).toBe(11)
      expect(day1(['123-123', '12345-12345'])).toBe(0)
      expect(day1(['11-44'])).toBe(110)
      expect(day1(['11-22'])).toBe(33)
      expect(day1(['11-44', '11-22'])).toBe(143)
   })
})


