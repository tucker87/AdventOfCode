
public static class Day6B
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day6.txt");

    public static int Run()
    {
        var stack = new Stack<char>();
        for(var i = 0; i < _data[0].Length; i++)
        {
            var d = _data[0][i];
            if (stack.Count < 14)
            {
                stack.Push(d);
                continue;
            }

            var list = new List<char>();

            for(var k = 0; k < 14; k++)
                list.Add(stack.Pop());

            if(list.Count == list.Distinct().Count())
                return i;
            
            list.Reverse();
            foreach(var c in list.Skip(1))
                stack.Push(c);

            stack.Push(d);
        }

        return -1;
    }
}