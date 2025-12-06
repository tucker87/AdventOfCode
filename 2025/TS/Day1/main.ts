import { makeWrap } from './makeWrap';

export const main = async (includePassZero: boolean, lines: AsyncGenerator<string, void, unknown>) => {
   const { wrap, answer } = makeWrap(includePassZero)

   for await (const line of lines) {
      wrap(line[0], Number(line.substring(1)))
   }

   console.log(answer.value)
}
