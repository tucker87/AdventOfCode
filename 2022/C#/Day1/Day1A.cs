public static class Day1A
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day1.txt");
    public static int Run()
    {
        var max = 0;
        var elf = 0;
        foreach (var x in _data)
        {
            if(x.Length == 0)
            {
                if(elf > max)
                    max = elf;

                elf = 0;
                continue;
            }

            elf += int.Parse(x);
        }
        return  max;
    }
}