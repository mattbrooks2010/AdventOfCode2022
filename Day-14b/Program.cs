var lines = new List<(int x, int y)[]>();
var min = (x: int.MaxValue, y: 0);
var max = (x: 0, y: 0);
var src = (x: 500, y: 0);
var units = 0;
var input = File.ReadAllLines("input.txt");

foreach (var line in input)
{
    var coords = line
        .Split(" -> ")
        .Select(c => c.Split(','))
        .Select(c => (x: int.Parse(c[0]), y: int.Parse(c[1])))
        .Select(c =>
        {
            if (c.x < min.x)
            {
                min.x = c.x;
            }

            if (c.x > max.x)
            {
                max.x = c.x;
            }

            if (c.y > max.y)
            {
                max.y = c.y;
            }

            return c;
        })
        .ToArray();

    lines.Add(coords);
}

var map = new char[(max.x - min.x + 1) + 296, max.y + 3];
src.x = src.x - min.x + 125; // translate x

// Initialize map
for (var y = 0; y < map.GetLength(1); y++)
{
    for (var x = 0; x < map.GetLength(0); x++)
    {
        map[x, y] = '.';
    }
}

// Sand source
map[src.x, src.y] = '+';

// Draw lines
foreach (var p in lines)
{
    p[0].x = p[0].x - min.x + 125; // translate x

    for (var i = 1; i < p.Length; i++)
    {
        p[i].x = p[i].x - min.x + 125; // translate x

        var (dx, dy) = (Math.Abs(p[i].x - p[i - 1].x), Math.Abs(p[i].y - p[i - 1].y));

        // Straight line, so either `x1 == x2` or `y1 == y2`
        if (dx != 0)
        {
            var ox = Math.Min(p[i].x, p[i - 1].x);

            for (var x = 0; x <= dx; x++)
            {
                map[ox + x, p[i].y] = '#';
            }
        }
        else
        {
            var oy = Math.Min(p[i].y, p[i - 1].y);

            for (var y = 0; y <= dy; y++)
            {
                map[p[i].x, oy + y] = '#';
            }
        }
    }
}

for (var x = 0; x < map.GetLength(0); x++)
{
    map[x, map.GetLength(1) - 1] = '#';
}

// Possible next sand movements, in order
var deltas = new (int x, int y)[] { (x: 0, y: 1), (x: -1, y: 1), (x: 1, y: 1) };

void GameLoop()
{
    while (true)
    {
        var sand = (src.x, y: src.y);
        var isMoving = true;

        do
        {
            for (var i = 0; i < deltas.Length; i++)
            {
                var (dx, dy) = (sand.x + deltas[i].x, sand.y + deltas[i].y);

                if (map[dx, dy] == '.')
                {
                    if ((sand.x, sand.y) != src)
                    {
                        map[sand.x, sand.y] = '.';
                    }

                    map[dx, dy] = 'o';

                    sand.x = dx;
                    sand.y = dy;

                    break;
                }
                else if (i == 2)
                {
                    isMoving = false;
                    units++;

                    if (sand == src)
                    {
                        // ...simulate the falling sand until the source of the sand becomes blocked.
                        return;
                    }
                }
            }
        }
        while (isMoving);

        if (units % 500 == 0)
        {
            DrawMap();
        }
    }
}

void DrawMap()
{
    Console.SetCursorPosition(0, 0);

    for (var y = 0; y < map.GetLength(1); y++)
    {
        Console.Write(y.ToString().PadLeft(3));
        Console.Write(' ');

        for (var x = 0; x < map.GetLength(0); x++)
        {
            Console.Write(map[x, y]);
        }

        if (y + 1 == map.GetLength(1))
        {
            Console.Write(' ');
            Console.Write(units.ToString().PadLeft(5));
        }

        Console.WriteLine();
    }
}

Console.CursorVisible = false;
Console.Clear();

GameLoop();
DrawMap();
