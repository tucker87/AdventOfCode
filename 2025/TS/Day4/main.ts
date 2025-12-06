type Vec2 = { x: number, y: number }

const neighbors = (v: Vec2) => [
   { x: v.x, y: v.y - 1 },
   { x: v.x + 1, y: v.y - 1 },
   { x: v.x + 1, y: v.y },
   { x: v.x + 1, y: v.y + 1 },
   { x: v.x, y: v.y + 1 },
   { x: v.x - 1, y: v.y + 1 },
   { x: v.x - 1, y: v.y },
   { x: v.x - 1, y: v.y - 1 },
]

export const canBePicked = (map: string[][], location: Vec2) => {
   if (map[location.y][location.x] === '.')
      return false

   const neighborCount = neighbors(location).reduce((acc, curr) => {
      const { x, y } = curr
      const mapHeight = map.length - 1
      const mapWidth = map[0].length - 1
      if (x < 0 || x > mapWidth || y < 0 || y > mapHeight || map[y][x] === '.')
         return acc + 0

      return acc + 1
   }, 0)

   return neighborCount < 4
}

export const part1 = (map: string[][]) => {
   const newMap = structuredClone(map)
   let sum = 0
   for (let y = 0; y < map.length; y++)
      for (let x = 0; x < map[0].length; x++) {
         if (canBePicked(map, { x, y })) {
            newMap[y][x] = '.'
            sum++
         }
      }

   return { sum, newMap }
}

export const part2 = (map: string[][]) => {
   let sum = 0
   let change = 0

   do {
      let { sum: newChange, newMap } = part1(map)
      change = newChange
      map = newMap
      sum += change
   } while (change !== 0)

   return sum
}


