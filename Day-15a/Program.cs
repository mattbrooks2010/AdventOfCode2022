var input = File.ReadAllLines("input.txt");
var beacons = new HashSet<int>();
var signals = new HashSet<int>();
var y = 2000000;

foreach (var line in input)
{
    var parts = line.Split(' ', ',', '=', ':');
    var sensor = (x: int.Parse(parts[3]), y: int.Parse(parts[6]));
    var beacon = (x: int.Parse(parts[13]), y: int.Parse(parts[16]));
    var range = Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y);

    if (beacon.y == y)
    {
        beacons.Add(beacon.x);
    }

    if (sensor.y - range <= y && sensor.y + range >= y)
    {
        signals.Add(sensor.x);

        var dy = range - Math.Abs(sensor.y - y);

        for (var i = 1; i <= dy; i++)
        {
            signals.Add(sensor.x + i);
            signals.Add(sensor.x - i);
        }
    }
}

Console.WriteLine(signals.Count - beacons.Count);