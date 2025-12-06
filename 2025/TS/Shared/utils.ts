import { reduce } from 'iter-tools'

export const sum = (arr: any[]) =>
   reduce(0, (acc, curr) => acc + curr, arr)

export const max = (arr: any[]) =>
   reduce(0, (acc: number, curr: number) => Math.max(acc, curr), arr)
