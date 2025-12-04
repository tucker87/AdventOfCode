import { ref } from '../Shared/ref.ts'

function* takeSteps(direction: string, steps: number, start: number) {
   const step = direction === "L" ? -1 : 1
   while (steps-- > 0) {
      start += step
      if (start < 0)
         start += 100

      if (start > 99)
         start -= 100

      yield start
   }
}

const makeWrap = (includeZeroPasses: boolean, current: number = 50) => {
   const answer = ref(0)
   const wrap = (direction: string, i: number) => {
      const step = takeSteps(direction, i, current)
      for (const click of step) {
         if (includeZeroPasses && click === 0)
            answer.value++

         current = click
      }

      if (!includeZeroPasses && current === 0)
         answer.value++
   }
   return { answer, wrap }
}

export { makeWrap }
