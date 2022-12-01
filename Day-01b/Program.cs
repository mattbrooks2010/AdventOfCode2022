var totals = new int[1];
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    if (line.Length > 0)
    {
        totals[^1] += int.Parse(line);
    }
    else
    {
        Array.Resize(ref totals, totals.Length + 1);
    }
}

Array.Sort(totals);

Console.WriteLine(totals[^3..].Sum());
