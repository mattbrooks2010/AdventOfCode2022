var priority = 0;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    priority += GetPriority(line);
}

int GetPriority(string line)
{
    for (var i = 0; i < line.Length / 2; i++)
    {
        for (var j = line.Length / 2; j < line.Length; j++)
        {
            var item = line[i];

            if (item == line[j])
            {
                return item - (char.IsUpper(item) ? 38 : 96);
            }
        }
    }

    return 0;
}

Console.WriteLine(priority);
