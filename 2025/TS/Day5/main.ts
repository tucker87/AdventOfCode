import { range } from 'iter-tools'

export const readInput = async (path: string) => {
   const [rangesStr, idsStr] = (await Bun.file(path).text())
      .split("\n\n")
      .map(s => s.split('\n').filter(m => m.length > 0))

   const ranges = rangesStr.map(r => {
      const [a, b] = r.split('-')
      return { min: Number(a), max: Number(b) }
   })

   const ids = idsStr.map(Number)

   return { ranges, ids }
}

const isFresh = (ranges) => (id: number) =>
   ranges.some((r: { min: number; max: number }) => id >= r.min && id <= r.max)

export const part1 = ({ ranges, ids }) =>
   ids
      .map(isFresh(ranges))
      .filter(Boolean)
      .length

export const part2 = ({ ranges }) => {
   var fresh = {}

   for (const r of ranges) {
      const all = range(r.min, r.max + 1)

      for (const id of all) {
         fresh[id] = 1
      }
   }
   return Object.keys(fresh).length
}

