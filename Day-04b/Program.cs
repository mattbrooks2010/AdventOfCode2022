var count = 0;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    var ranges = line.Split('-', ',');
    var a = int.Parse(ranges[0]);
    var b = int.Parse(ranges[1]);
    var c = int.Parse(ranges[2]);
    var d = int.Parse(ranges[3]);

    if ((b >= c && a <= d) || (a <= d && b >= c))
    {
        count++;
    }
}

Console.WriteLine(count);
