
public static class Day2B
{
    private static string[] _data = File.ReadAllLines("./Inputs/Day2.txt");

    private static Dictionary<string, Func<string, string>> _howToWin = new (){
        ["X"] = a => a switch { "A" => "Z", "B" => "X", "C" => "Y", _ => throw new ArgumentException() },
        ["Y"] = a => a switch { "A" => "X", "B" => "Y", "C" => "Z", _ => throw new ArgumentException() },
        ["Z"] = a => a switch { "A" => "Y", "B" => "Z", "C" => "X", _ => throw new ArgumentException() }
    };
    public static int Run()
    {
        var points = 0;
        foreach(var x in _data)
        {
            var y = x.Split(' ');
            var a = y[0];
            var b = y[1];

            b = _howToWin[b](a);

            var isWin = DoesBWin(a, b);
            var winPoints = 0;
            if(isWin is null)
                winPoints = 3;
            else if(isWin == true)
                winPoints = 6;

            var pickPoints = b switch {
                "X" => 1,
                "Y" => 2,
                "Z" => 3,
                _ => throw new ArgumentException()
            };

            points += winPoints + pickPoints;
        }

        return points;
    }

    private static bool? DoesBWin(string a, string b)
    {
        return (a, b) switch {
            ("A", "X") => null,  //Rock vs Rock
            ("A", "Y") => true,  //Rock vs Paper
            ("A", "Z") => false, //Rock vs Scissors

            ("B", "X") => false,  //Paper vs Rock
            ("B", "Y") => null,  //Paper vs Paper
            ("B", "Z") => true,  //Paper vs Scissors

            ("C", "X") => true,  //Scissors vs Rock
            ("C", "Y") => false,  //Scissors vs Paper
            ("C", "Z") => null,  //Scissors vs Scissors
            _ => throw new ArgumentException()
        };
    }
}