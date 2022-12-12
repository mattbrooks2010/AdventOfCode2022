var map = new List<char[]>();
var s = (x: 0, y: 0);
var e = (x: 0, y: 0);

var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    map.Add(line.ToCharArray());

    var start = line.IndexOf('S');
    var end = line.IndexOf('E');

    if (start >= 0)
    {
        s = (start, map.Count - 1);
        map[^1][start] = 'a';
    }

    if (end >= 0)
    {
        e = (end, map.Count - 1);
        map[^1][end] = 'z';
    }
}

var visited = new bool[map[0].Length, map.Count];
var queue = new Queue<((int x, int y) pos, int length)>();
var deltas = new (int x, int y)[] { (0, -1), (0, 1), (-1, 0), (1, 0) };
var minLength = int.MaxValue;

visited[s.x, s.y] = true;
queue.Enqueue(((s.x, s.y), 0));

while (queue.Count > 0)
{
    var v = queue.Dequeue();

    if (v.pos == e)
    {
        if (v.length < minLength)
        {
            minLength = v.length;
        }

        continue;
    }

    foreach (var d in deltas)
    {
        var dx = v.pos.x + d.x;
        var dy = v.pos.y + d.y;

        if (dx < 0 || dx > map[0].Length - 1 || dy < 0 || dy > map.Count - 1)
        {
            continue;
        }

        if (visited[dx, dy])
        {
            continue;
        }

        if (map[v.pos.y][v.pos.x] + 1 >= map[dy][dx])
        {
            visited[dx, dy] = true;
            queue.Enqueue(((dx, dy), v.length + 1));
        }
    }
}

Console.WriteLine(minLength);