var cpuX = 1;
var addX = 0;
var cycle = 0;
var signal = 0;

var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    var clock = 0;

    if (line == "noop")
    {
        clock = 1;
        addX = 0;
    }
    else if (line.StartsWith("addx "))
    {
        clock = 2;
        addX = int.Parse(line.Substring(5));
    }

    while (clock > 0)
    {
        clock--;
        cycle++;

        if (cycle == 20 || (cycle % 40) + 20 == 40)
        {    
            signal += cycle * cpuX;
        }

        if (clock == 0)
        {
            cpuX += addX;
        }
    }
}

Console.WriteLine(signal);