import { readLines } from '../Shared/readLines.ts'
import { main } from './main.ts'
import { describe, it, expect } from "vitest";
import { makeWrap } from './makeWrap.ts'

const wrap0 = () => makeWrap(true, 0)
const wrap2 = () => makeWrap(true, 2)

const test = ({ wrap, answer }, direction: string, n: number) => {
   wrap(direction, n);
   return answer.value
}

const test0 = (direction: string, n: number) => test(wrap0(), direction, n)
const test2 = (direction: string, n: number) => test(wrap2(), direction, n)

describe('wrapping', () => {
   it('should work from 0', () => {
      expect(test0("R", 1)).toBe(0);
      expect(test0("L", 1)).toBe(0);
      expect(test0("R", 200)).toBe(2);
      expect(test0("L", 200)).toBe(2);
   });

   it('should work from 2', () => {
      expect(test2("R", 98)).toBe(1)
      expect(test2("R", 198)).toBe(2)
      expect(test2("L", 2)).toBe(1)
      expect(test2("L", 202)).toBe(3)
   })

   it('should pass the basic example', () => {
      const { answer, wrap } = makeWrap(true, 50)
      wrap("L", 68)
      expect(answer.value).toBe(1)

      wrap("L", 30)
      expect(answer.value).toBe(1)

      wrap("R", 48)
      expect(answer.value).toBe(2)

      wrap("L", 5)
      expect(answer.value).toBe(2)

      wrap("R", 60)
      expect(answer.value).toBe(3)

      wrap("L", 55)
      expect(answer.value).toBe(4)

      wrap("L", 1)
      expect(answer.value).toBe(4)

      wrap("L", 99)
      expect(answer.value).toBe(5)

      wrap("R", 14)
      expect(answer.value).toBe(5)

      wrap("L", 82)
      expect(answer.value).toBe(6)
   })
})

describe('part1', () => {
   it('should work with the input', async () => {
      expect(await main(false, readLines('../Inputs/Day1.txt'))).toBe(1145)
   })
})

describe('part2', () => {
   it('should work with the input', async () => {
      expect(await main(true, readLines('../Inputs/Day1.txt'))).toBe(6561)
   })
})
