type MinMax = { min: number, max: number }

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

const isFresh = (ranges: MinMax[]) => (id: number) =>
   ranges.some((r: MinMax) => id >= r.min && id <= r.max)

export const part1 = ({ ranges, ids }: { ranges: MinMax[], ids: number[] }) =>
   ids
      .filter(isFresh(ranges))
      .length

export const isContained = (n: number, r: MinMax) =>
   n >= r.min && n <= r.max

export const mergeRanges = (ranges: MinMax[]): MinMax[] => {
   return ranges.map(r => {
      for (const r2 of ranges) {
         if (r == r2)
            continue

         if (isContained(r.min, r2))
            r.min = r2.min

         if (isContained(r.max, r2))
            r.max = r2.max

      }
      return r
   })
}

export const filterRanges = (ranges: MinMax[]) => {
   const uniqueMap = new Map()
   ranges.forEach(r => {
      const key = `${r.min} - ${r.max}`
      if (!uniqueMap.has(key)) {
         uniqueMap.set(key, r)
      }
   })
   return [...uniqueMap.values()]
}

export const part2 = ({ ranges }: { ranges: MinMax[] }) => {
   let change = 0
   do {
      const rangeCount = ranges.length

      ranges = mergeRanges(ranges)
      ranges = filterRanges(ranges)

      change = rangeCount - ranges.length
   } while (change > 0)

   return ranges.reduce((acc, curr) =>
      acc + curr.max - curr.min + 1, 0)
}

