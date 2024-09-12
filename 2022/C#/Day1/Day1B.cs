public static class Day1B
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day1.txt");
    public static int Run()
    {
        var maxs = new []{0,0,0};
        var elf = 0;
        foreach (var x in _data)
        {
            if(x.Length == 0)
            {
                if(elf > maxs[0])
                {
                    maxs[2] = maxs[1];
                    maxs[1] = maxs[0];
                    maxs[0] = elf;
                    elf = 0;
                    continue;
                }

                if(elf > maxs[1])
                {
                    maxs[2] = maxs[1];
                    maxs[1] = elf;
                    elf = 0;
                    continue;
                }

                if(elf > maxs[2])
                    maxs[2] = elf;

                elf = 0;
                continue;
            }

            elf += int.Parse(x);
        }
        return maxs.Sum();
    }
}