export type Ref<T> = {
   value: T
}

export const ref = <T>(v: T): Ref<T> => ({
   value: v
})
