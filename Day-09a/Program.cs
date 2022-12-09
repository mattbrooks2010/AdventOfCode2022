using System.Drawing;

var rope = new Point[2];
var visited = new HashSet<Point>();
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    var direction = line[0];
    var distance = int.Parse(line.Substring(2));

    switch (direction)
    {
        case 'U':
            Move(0, 1, distance);
            break;
        case 'D':
            Move(0, -1, distance);
            break;
        case 'L':
            Move(-1, 0, distance);
            break;
        case 'R':
            Move(1, 0, distance);
            break;
    }
}

void Move(int x, int y, int distance)
{
    rope[0].X += x;
    rope[0].Y += y;

    var offset = new
    {
        X = rope[0].X - rope[1].X,
        Y = rope[0].Y - rope[1].Y
    };

    void MoveX()
    {
        if (offset.X > 0)
        {
            rope[1].X++;
        }
        else if (offset.X < 0)
        {
            rope[1].X--;
        }
    }

    void MoveY()
    {
        if (offset.Y > 0)
        {
            rope[1].Y++;
        }
        else if (offset.Y < 0)
        {
            rope[1].Y--;
        }
    }

    if (offset.X > 1)
    {
        rope[1].X++;
        MoveY();
    }
    else if (offset.X < -1)
    {
        rope[1].X--;
        MoveY();
    }
    else if (offset.Y > 1)
    {
        rope[1].Y++;
        MoveX();
    }
    else if (offset.Y < -1)
    {
        rope[1].Y--;
        MoveX();
    }

    visited.Add(rope[^1]);

    if (distance > 1)
    {
        Move(x, y, distance - 1);
    }
}

Console.WriteLine(visited.Count);