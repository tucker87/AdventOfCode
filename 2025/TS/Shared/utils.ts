export const sum = (arr: any[]) =>
   arr.reduce((acc, curr) => acc + curr, 0)

export const max = (arr: any[]) =>
   arr.reduce((acc: number, curr: number) => Math.max(acc, curr), 0)
