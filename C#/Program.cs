var days = typeof(Program).Assembly.GetTypes()
    .Where(t => t.Name.StartsWith("Day"));

foreach(var day in days)
    Console.WriteLine($"{day.Name}: {day.GetMethod("Run")?.Invoke(null, null)}");