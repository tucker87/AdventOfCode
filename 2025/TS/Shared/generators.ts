export type AnyGenerator<T> = Iterable<T> | AsyncIterable<T>

export function* stepper(start: number, end: number) {
   while (start <= end) {
      yield start++
   }
}

export async function* filter<T>(p: Function, it: Generator<T>): AnyGenerator<T> {
   for await (const x of it) {
      if (p(x))
         yield x
   }
}

export const reduce = async <TAcc, TCurr>(f: (acc: TAcc, curr: TCurr) => TAcc, i: TAcc, it: AnyGenerator<TCurr>) => {
   let o = i

   for await (const x of it)
      o = f(o, x)

   return o
}

export const sum = async <T>(it: AnyGenerator<T>, f: (s: T) => number) =>
   await reduce((acc: number, curr: T): any => acc + f(curr), 0, it)
