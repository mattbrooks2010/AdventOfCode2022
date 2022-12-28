var input = File.ReadAllLines("input.txt");
var sensors = new HashSet<((int x, int y) sensor, (int x, int y) beacon)>();
var maxRange = 4000000;

foreach (var line in input)
{
    var parts = line.Split(' ', ',', '=', ':');
    var sensor = (x: int.Parse(parts[3]), y: int.Parse(parts[6]));
    var beacon = (x: int.Parse(parts[13]), y: int.Parse(parts[16]));

    sensors.Add((sensor, beacon));
}

Search();

void Search()
{
    foreach (var (sensor, beacon) in sensors)
    {
        var range = Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y) + 1;

        for (var i = -range; i <= range; i++)
        {
            var y = sensor.y + i;

            if (y >= 0 && y <= maxRange)
            {
                var x = sensor.x - (range + i);

                if (x >= 0 && x <= maxRange)
                {
                    if (!IsInRange((x, y)))
                    {
                        Console.WriteLine((x * 4000000L) + y);
                        return;
                    }
                }
            }
        }
    }
}

bool IsInRange((int x, int y) p)
{
    foreach (var (sensor, beacon) in sensors)
    {
        if (Math.Abs(sensor.x - p.x) + Math.Abs(sensor.y - p.y) <= Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y))
        {
            return true;
        }
    }

    return false;
}