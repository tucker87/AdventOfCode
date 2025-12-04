async function* readLines(file: string) {
   const stream = Bun.file(file).stream()
   const decoder = new TextDecoder('utf-8');

   for await (const chunk of stream) {
      const str = decoder.decode(chunk)
      const lines = str.split('\n')

      for (const line of lines) {
         yield line
      }

   }
}

export { readLines }
