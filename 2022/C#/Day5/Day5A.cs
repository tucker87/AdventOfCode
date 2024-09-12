
public static class Day5A
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day5.txt");

    public static string Run()
    {
        var stacks = new List<Stack<char>>();
        
        var first = _data[0];
        for(var k = 0; k < first.Length; k+=4)
        {
            stacks.Add(new Stack<char>());
        }

        var i = 0;
        for(;;i++)
        {
            var x = _data[i];
            var a = x[1];
            if(a == '1')
                break;

            var s = 0;
            for(var k = 1; k < x.Length; k+=4)
            {
                if(x[k] == ' ')
                {
                    s++;
                    continue;
                }
                    
                stacks[s++].Push(x[k]);
            }
        }

        for(var z = 0; z < stacks.Count; z++)
        {
            var stack = stacks[z];
            var arr = new char[stack.Count];
            stack.CopyTo(arr, 0);
            stack.Clear();
            foreach(var c in arr)
                stack.Push(c);
        }

        i+=2;
        for(;i<_data.Length;i++)
        {
            var x = _data[i];

            var y = x.Split(' ');
            var n = int.Parse(y[1]);
            var a = int.Parse(y[3]);
            var b = int.Parse(y[5]);

            while(n-- > 0)
            {
                var t = stacks[a-1].Pop();
                stacks[b-1].Push(t);
            }
        }

        return string.Join("", stacks.Select(s => s.Pop()));
    }
}