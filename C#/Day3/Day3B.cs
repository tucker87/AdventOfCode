
public static class Day3B
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day3.txt");

    public static int Run()
    {
        var points = 0;
        foreach(var batchE in _data.Batch(3))
        {
            var batch = batchE.ToList();

            var shared = 'a';
            foreach(var c in "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")
            {
                if(batch[0].Contains(c) && batch[1].Contains(c) && batch[2].Contains(c))
                {
                    shared = c;
                    break;
                }
            }

            if(char.IsLower(shared))
                points += shared - 96;
            else
                points += shared - 38;
        }

        return points;
    }
}

public static class Extensions
{
    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
    {
        TSource[]? bucket = null;
        var count = 0;

        foreach (var item in source)
        {
            bucket ??= new TSource[size];

            bucket[count++] = item;
            if (count != size)
                continue;

            yield return bucket;

            bucket = null;
            count = 0;
        }

        if (bucket != null && count > 0)
            yield return bucket.Take(count).ToArray();
    }
}