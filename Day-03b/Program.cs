var priority = 0;
var group = new List<string>();
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    group.Add(line);
    
    if (group.Count == 3)
    {
        priority += GetPriority(group);
        group.Clear();
    }
}

int GetPriority(List<string> group)
{
    for (var i = 0; i < group[0].Length; i++)
    {
        for (var j = 0; j < group[1].Length; j++)
        {
            for (var k = 0; k < group[2].Length; k++)
            {
                var item = group[0][i];

                if (item == group[1][j] && item == group[2][k])
                {
                    return item - (char.IsUpper(item) ? 38 : 96);
                }
            }
        }
    }

    return 0;
}

Console.WriteLine(priority);
