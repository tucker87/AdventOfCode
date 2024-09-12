
public static class Day3A
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day3.txt");

    public static int Run()
    {
        var points = 0;
        foreach(var x in _data)
        {
            var a = string.Join("", x.Take(x.Length / 2)).ToList();
            var b = string.Join("", x.Skip(x.Length / 2)).ToList();

            var hash = new HashSet<char>();
            foreach(var c in a)
                hash.Add(c);
                
            foreach(var c in b)
            {
                if(!hash.Contains(c))
                    continue;

                hash.Remove(c);

                if(char.IsLower(c))
                    points += c - 96;
                else
                    points += c - 38;
            }
        }

        return points;
    }
}