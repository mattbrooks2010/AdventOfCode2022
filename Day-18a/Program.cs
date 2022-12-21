var input = File.ReadAllLines("input.txt")
    .Select(line => line.Split(','))
    .Select(coords => coords.Select(c => int.Parse(c)).ToArray())
    .Select(coords => (x: coords[0], y: coords[1], z: coords[2]))
    .ToArray();

var count = 0;
var visited = new HashSet<(int x, int y, int z)>();

foreach (var cube in input)
{
    visited.Add(cube);
    count += 6; // assume all sides are exposed

    foreach (var pos in GetAdjPos(cube))
    {
        if (visited.Contains(pos))
        {
            count -= 2; // each pair of adjacent cubes has 2 covered sides
        }
    }
}

Console.WriteLine(count);

(int x, int y, int z)[] GetAdjPos((int x, int y, int z) cube)
{
    var (x, y, z) = cube;

    return new[]
    {
        (x - 1, y, z),
        (x + 1, y, z),
        (x, y - 1, z),
        (x, y + 1, z),
        (x, y, z - 1),
        (x, y, z + 1)
    };
}