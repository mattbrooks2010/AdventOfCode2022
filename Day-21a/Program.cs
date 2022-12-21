var input = File.ReadAllLines("input.txt")
    .Select(line => line.Split(": "))
    .Select(parts => new
    {
        name = parts[0].Substring(0, 4),
        job = parts[1]
    })
    .ToArray();

var monkeys = new Dictionary<string, Func<long>>();

foreach (var monkey in input)
{
    var job = monkey.job;

    if (job.IndexOf(' ') >= 0)
    {
        monkeys[monkey.name] = () =>
        {
            var expr = job.Split(' ');
            var lhs = expr[0];
            var op = expr[1][0];
            var rhs = expr[2];

            switch (op)
            {
                case '+':
                    return monkeys[lhs]() + monkeys[rhs]();
                case '-':
                    return monkeys[lhs]() - monkeys[rhs]();
                case '*':
                    return monkeys[lhs]() * monkeys[rhs]();
                case '/':
                    return monkeys[lhs]() / monkeys[rhs]();
            }

            return 0;
        };
    }
    else
    {
        monkeys[monkey.name] = () => long.Parse(job);
    }
}

Console.WriteLine(monkeys["root"]());