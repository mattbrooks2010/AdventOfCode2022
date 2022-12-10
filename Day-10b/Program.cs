var cpuX = 1;
var addX = 0;
var cycle = 0;

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
        var pos = cycle % 40;
        
        if (pos >= cpuX - 1 && pos <= cpuX + 1)
        {
            Console.Write('#');
        }
        else
        {
            Console.Write('.');
        }

        if (pos == 39)
        {
            Console.WriteLine(); 
        }

        clock--;
        cycle++;

        if (clock == 0)
        {
            cpuX += addX;
        }
    }
}