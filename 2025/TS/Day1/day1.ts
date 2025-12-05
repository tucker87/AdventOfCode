import { makeWrap } from './makeWrap';

export const main = async (includePassZero: boolean, lines: any) => {
   const { wrap, answer } = makeWrap(includePassZero)

   for await (const line of await lines) {
      wrap(line[0], Number(line.substring(1)))
   }

   console.log(answer.value)
}
