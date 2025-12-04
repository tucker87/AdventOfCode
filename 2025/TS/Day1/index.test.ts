import { describe, it, expect } from "vitest";
import { makeWrap } from './makeWrap.ts'

const wrap0 = () => makeWrap(true, 0)
const wrap2 = () => makeWrap(true, 2)

describe('wrapping', () => {
   it('should work from 0', () => {
      expect(wrap0()("R", 1)).toBe(0);
      expect(wrap0()("L", 1)).toBe(0);
      expect(wrap0()("R", 200)).toBe(2);
      expect(wrap0()("L", 200)).toBe(2);
   });

   it('should work from 2', () => {
      expect(wrap2()("R", 98)).toBe(1)
      expect(wrap2()("R", 198)).toBe(2)
      expect(wrap2()("L", 2)).toBe(1)
      expect(wrap2()("L", 202)).toBe(3)
   })

   it('should pass the basic example', () => {
      const wrap = makeWrap(true, 50)
      let password = wrap("L", 68)
      expect(password).toBe(1)

      password = wrap("L", 30)
      expect(password).toBe(1)

      password = wrap("R", 48)
      expect(password).toBe(2)

      password = wrap("L", 5)
      expect(password).toBe(2)

      password = wrap("R", 60)
      expect(password).toBe(3)

      password = wrap("L", 55)
      expect(password).toBe(4)

      password = wrap("L", 1)
      expect(password).toBe(4)

      password = wrap("L", 99)
      expect(password).toBe(5)

      password = wrap("R", 14)
      expect(password).toBe(5)

      password = wrap("L", 82)
      expect(password).toBe(6)
   })
})
