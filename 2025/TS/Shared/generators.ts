import { asyncReduce } from 'iter-tools'

export type AnyGenerator<T> = Iterable<T> | AsyncIterable<T>

export const reduce = async <TAcc, TCurr>(f: (acc: TAcc, curr: TCurr) => TAcc, i: TAcc, it: AnyGenerator<TCurr>) =>
   await asyncReduce(i, f, it)

export const sum = async <T>(it: AnyGenerator<T>, f: (s: T) => number) =>
   await asyncReduce(0, (acc: number, curr: T): any => acc + f(curr), it)
