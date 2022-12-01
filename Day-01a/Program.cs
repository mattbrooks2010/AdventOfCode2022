var calories = 0;
var max = 0;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    if (line.Length > 0)
    {
        calories += int.Parse(line);
        max = Math.Max(max, calories);
    }
    else
    {
        calories = 0;
    }
}

Console.WriteLine(max);
