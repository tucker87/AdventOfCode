import { asyncReduce, AsyncWrappable } from 'iter-tools'


export const reduce = async <TAcc, TCurr>(f: (acc: TAcc, curr: TCurr) => TAcc, i: TAcc, it: AsyncWrappable<TCurr>) =>
   await asyncReduce(i, f, it)

export const sum = async<T>(it: AsyncWrappable<T>, f: (s: T) => number | any = x => x) =>
   await asyncReduce(0, (acc: number, curr: T): any => acc + f(curr), it)
