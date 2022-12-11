var monkeys = new List<Monkey>();
var commonDivisor = 1ul;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    if (line.StartsWith("Monkey "))
    {
        monkeys.Add(new Monkey());
    }
    else if (line.StartsWith("  Starting items: "))
    {
        monkeys[^1].Items.AddRange(line.Substring(18).Split(",").Select(i => ulong.Parse(i)));
    }
    else if (line.StartsWith("  Operation: "))
    {
        var expr = line.Substring(13).Split(' ');

        monkeys[^1].Operation = old =>
        {
            ulong rhs()
            {
                if (expr[4] == "old")
                {
                    return old;
                }

                return ulong.Parse(expr[4]);
            }

            if (expr[3] == "*")
            {
                return old * rhs();
            }

            return old + rhs();
        };
    }
    else if (line.StartsWith("  Test: "))
    {
        var divisor = ulong.Parse(line.Substring(21));
        commonDivisor *= divisor;

        monkeys[^1].Test = n => (n % divisor) == 0;
    }
    else if (line.StartsWith("    If true: "))
    {
        var s = line;
        monkeys[^1].ThrowToIfTrue = int.Parse(s.Substring(29));
    }
    else if (line.StartsWith("    If false: "))
    {
        var s = line;
        monkeys[^1].ThrowToIfFalse = int.Parse(s.Substring(30));
    }
}

for (var r = 1; r <= 10000; r++)
{
    for (var m = 0; m < monkeys.Count; m++)
    {
        for (var i = 0; i < monkeys[m].Items.Count; i++)
        {
            var item = monkeys[m].Items[i];
            item = monkeys[m].Operation(item) % commonDivisor;
            
            monkeys[m].Inspections++;
            monkeys[m].Items.RemoveAt(i);

            if (monkeys[m].Test(item))
            {
                monkeys[monkeys[m].ThrowToIfTrue].Items.Add(item);
            }
            else 
            {
                monkeys[monkeys[m].ThrowToIfFalse].Items.Add(item);
            }

            i--;
        }
    }
}

monkeys.Sort((x, y) => x.Inspections.CompareTo(y.Inspections));
Console.WriteLine(monkeys[^1].Inspections * monkeys[^2].Inspections);

class Monkey
{
    public List<ulong> Items { get; init; } = new List<ulong>();
    public Func<ulong, ulong> Operation { get; set; } = n => 0;
    public Func<ulong, bool> Test { get; set; } = n => false;
    public int ThrowToIfTrue { get; set; }
    public int ThrowToIfFalse { get; set; }
    public ulong Inspections { get; set; }
}