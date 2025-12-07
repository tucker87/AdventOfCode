type Operator = '*' | '+'
type Questions = number[] & { operator: Operator }

export const toQuestions = (a: number[] = [], o: Operator = '+'): Questions => {
   const q: Questions = <Questions>a
   q.operator = o
   return <Questions>q
}

export const toOperator = (x: string) => {
   if (x == '*' || x == '+')
      return x

   throw 'wat?'
}

export const readInput = async (path: string) => {
   let file = await Bun.file(path).text()

   let data = file.split('\n')
   data.pop()
   const inputs = data.map(r => r.split(' ').filter(s => s.length > 0))

   const questions: Questions[] = []

   for (let i = 0; i < inputs[0].length; i++) {
      const d = inputs.slice(0, inputs.length - 1).map(a => Number(a[i]))
      const o = toOperator(inputs[inputs.length - 1][i])

      questions.push(toQuestions(d, o))
   }

   return questions
}

export const readInput2 = async (path: string) => {
   let file = await Bun.file(path).text()

   let data = file.split('\n')
   data.pop()

   const questions: Questions[] = []
   let nums: Questions = toQuestions()
   for (let x = 0; x < data[0].length; x++) {
      let n = ''
      for (let y = 0; y < data.length; y++) {
         const a = data[y][x]
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
         nums = toQuestions()
      }
   }
   questions.push(nums)

   return questions
}

export const main = (questions: Questions[]) => {
   return questions.reduce((total, question) => {
      if (question.operator === '*')
         return total + question.reduce((acc, curr) => acc * curr, 1)

      if (question.operator === '+')
         return total + question.reduce((acc, curr) => acc + curr, 0)

      throw 'no valid operator'
   }, 0)
}

