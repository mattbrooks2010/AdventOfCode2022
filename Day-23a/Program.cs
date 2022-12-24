var map = File.ReadAllLines("input.txt")
    .Select(line => line.ToList())
    .ToList();

GrowMap(10);

var elves = map
    .Select((row, y) => row.Select((col, x) => (pos: (x, y), cell: col, move: (x: 0, y: 0))))
    .SelectMany(o => o)
    .Where(o => o.cell == '#')
    .ToArray();

var dirs = new List<(int x, int y)[]>
{
    { new[] { (0, -1), (1, -1), (-1, -1) } },
    { new[] { (0, 1), (1, 1), (-1, 1) } },
    { new[] { (-1, 0), (-1, -1), (-1, 1) } },
    { new[] { (1, 0), (1, -1), (1, 1) } },
};

for (var i = 1; i <= 10; i++)
{
    var moves = new Dictionary<(int x, int y), int>();

    for (var j = 0; j < elves.Length; j++)
    {
        if (CanMove(elves[j].pos))
        {
            elves[j].move = ProposeMove(elves[j].pos);

            if (elves[j].move != (0, 0))
            {
                if (moves.ContainsKey(elves[j].move))
                {
                    moves[elves[j].move]++;
                }
                else
                {
                    moves.Add(elves[j].move, 1);
                }
            }
        }
    }

    for (var j = 0; j < elves.Length; j++)
    {
        if (moves.ContainsKey(elves[j].move) && moves[elves[j].move] == 1)
        {
            map[elves[j].pos.y][elves[j].pos.x] = '.';
            map[elves[j].move.y][elves[j].move.x] = '#';

            elves[j].pos = elves[j].move;
        }

        elves[j].move = (0, 0);
    }

    dirs.Add(dirs[0]);
    dirs.RemoveAt(0);
}

var min = (x: map[0].Count, y: map.Count);
var max = (x: 0, y: 0);

foreach (var elf in elves)
{
    if (elf.pos.x < min.x)
    {
        min.x = elf.pos.x;
    }
    
    if (elf.pos.y < min.y)
    {
        min.y = elf.pos.y;
    }
    
    if (elf.pos.x > max.x)
    {
        max.x = elf.pos.x;
    }
    
    if (elf.pos.y > max.y)
    {
        max.y = elf.pos.y;
    }
}

WriteMap();

Console.WriteLine((1 + max.x - min.x) * (1 + max.y - min.y) - elves.Length);

bool CanMove((int x, int y) elf)
{
    foreach (var dir in dirs)
    {
        foreach (var pos in dir)
        {
            var dx = elf.x + pos.x;
            var dy = elf.y + pos.y;

            if (map[dy][dx] == '#')
            {
                return true;
            }
        }
    }

    return false;
}

(int x, int y) ProposeMove((int x, int y) elf)
{
    foreach (var dir in dirs)
    {
        var clear = true;

        foreach (var pos in dir)
        {
            var dx = elf.x + pos.x;
            var dy = elf.y + pos.y;

            if (map[dy][dx] == '#')
            {
                clear = false;
                break;
            }
        }

        if (clear)
        {
            return (elf.x + dir[0].x, elf.y + dir[0].y);
        }
    }

    return (0, 0);
}

void GrowMap(int size = 1)
{
    for (var i = 0; i < size; i++)
    {
        foreach (var row in map)
        {
            row.Insert(0, '.');
            row.Add('.');
        }

        map.Insert(0, Enumerable.Repeat('.', map[0].Count).ToList());
        map.Add(Enumerable.Repeat('.', map[0].Count).ToList());
    }
}

void WriteMap()
{
    foreach (var row in map)
    {
        foreach (var col in row)
        {
            Console.Write(col);
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}