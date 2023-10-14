
public static class Day6A
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day6.txt");

    public static int Run()
    {
        var stack = new Stack<char>();
        for(var i = 0; i < _data[0].Length; i++)
        {
            var d = _data[0][i];
            if (stack.Count < 3)
            {
                stack.Push(d);
                continue;
            }

            var c = stack.Pop();
            var b = stack.Pop();
            var a = stack.Pop();

            if (a != b && a != c && a != d && b != c && b != d && c != d)
                return i + 1;

            stack.Push(b);
            stack.Push(c);
            stack.Push(d);

        }

        return -1;
    }
}