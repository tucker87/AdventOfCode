async function asyncReduce(asyncIterable, reducer, initialValue) {
   let accumulator = initialValue;

   for await (const item of asyncIterable) {
      accumulator = await reducer(accumulator, item);
   }

   return accumulator;
}

export { asyncReduce }
