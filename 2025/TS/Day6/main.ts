export const readInput = async (path: string) => {
   let file = await Bun.file(path).text()

   let data = file.split('\n')
   data.pop()
   return data.map(r => r.split(' ').filter(s => s.length > 0))
}

console.log(await readInput('../Inputs/Day6.sample.txt'))


export const main = (inputs: string[][]) => {
   let total = 0
   for (let i = 0; i < inputs[0].length; i++) {
      const d = inputs.slice(0, inputs.length - 1).map(a => Number(a[i]))
      const o = inputs[inputs.length - 1][i]

      let answer = 0
      if (o === '*')
         answer = d.reduce((acc, curr) => acc * curr, 1)
      if (o === '+')
         answer = d.reduce((acc, curr) => acc + curr, 0)

      total += answer
   }
   return total
}

export const readInput2 = async (path: string) => {
   let file = await Bun.file(path).text()

   let data = file.split('\n')
   data.pop()

   const questions: number[][] = []
   let nums: number[] = []
   for (let x = 0; x < data[0].length; x++) {
      let n = ''
      for (let y = 0; y < data.length; y++) {
         const a = data[y][x]
         if (a != '')
            if (a == '*' || a == '+')
               nums.operator = a
            else
               n += a
      }
      if (n.trim().length > 0) {
         nums.push(Number(n))
      }
      else {
         questions.push(nums)
         nums = []
      }
   }

   return questions
}
