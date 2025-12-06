import { readLines } from '../Shared/readLines.ts'
import { main } from './main.ts'

const readInput = () => readLines('../Inputs/Day3.txt')
console.log(await main(readInput()))
console.log(await main(readInput(), 12))
