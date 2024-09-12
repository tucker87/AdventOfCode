
public static class Day4B
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day4.txt");

    public static int Run()
    {
        var count = 0;
        foreach(var x in _data)
        {
            var y = x.Split(',');
            var a = y[0].Split('-').Select(int.Parse).ToList();
            var b = y[1].Split('-').Select(int.Parse).ToList();

            var r1 = Enumerable.Range(a[0], a[1] - a[0] + 1).ToHashSet();
            var r2 = Enumerable.Range(b[0], b[1] - b[0] + 1).ToHashSet();

            if(r1.Intersect(r2).Any())
                count++;
        }
        return count;
    }
}