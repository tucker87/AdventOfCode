import { readLines } from '../Shared/readLines.ts'
import { makeWrap } from './makeWrap';

const main = async (includePassZero: boolean, lines: any) => {
   const { wrap, answer } = makeWrap(includePassZero)

   for await (const line of await lines) {
      wrap(line[0], Number(line.substring(1)))
   }

   console.log(answer.value)
}

main(false, readLines('../Inputs/Day1.txt'));
main(true, readLines('../Inputs/Day1.txt'));

export { makeWrap }
