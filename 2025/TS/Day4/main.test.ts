import { describe, it, expect } from "vitest";
import { canBePicked, part1, part2 } from './main.ts'

const subsplit = x => x.split('')
const readMap = async (path: string) => {
   let file = (await Bun.file(path).text()).split('\n')
   file.pop()
   return file.map(subsplit)
}

const sample = await readMap('../Inputs/Day4.sample.txt')
const input = await readMap('../Inputs/Day4.txt')

describe('canBePicked', () => {
   it('should work', () => {
      expect(canBePicked(["@@@", "@@@", "@@@"].map(subsplit), { x: 1, y: 1 })).toBe(false);
      expect(canBePicked(["...", ".@.", "..."].map(subsplit), { x: 1, y: 1 })).toBe(true);
      expect(canBePicked([
         ".@@",
         ".@@",
         "..@"].map(subsplit), { x: 1, y: 1 })).toBe(false);
      expect(canBePicked([
         ".@.",
         ".@@",
         "..@"].map(subsplit), { x: 1, y: 1 })).toBe(true);
   })

   it('should work with the sample', () => {
      expect(canBePicked(sample, { x: 0, y: 1 })).toBe(true)
      expect(canBePicked(sample, { x: 1, y: 1 })).toBe(false)
      expect(canBePicked(sample, { x: 3, y: 1 })).toBe(false)
      expect(canBePicked(sample, { x: 4, y: 4 })).toBe(false)
   })

})

describe('part1', () => {

   it('should work on the sample', () => {
      expect(part1(sample).sum).toBe(13)
   })

   it('should work on the input', () => {
      expect(part1(input).sum).toBe(1351)
   })
})

describe('part2', () => {

   it('should work on the sample', () => {
      expect(part2(sample)).toBe(43)
   })

   it('should work on the input', () => {
      expect(part2(input)).toBe(8345)
   })
})
