export function* stepper(start: number, end: number) {
   while (start <= end) {
      yield start++
   }
}

export function* filter<T>(p: Function, it: Generator<T, void, unknown>): Generator<T, void, unknown> {
   for (const x of it) {
      if (p(x))
         yield x
   }
}

export const reduce = <TCurr, TAcc>(f: Function, i: TAcc, it: Generator<TCurr, void, unknown>) => {
   let o = i

   for (const x of it)
      o = f(o, x)

   return o
}

