using System.Drawing;

var rope = new Point[10];
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

    for (var i = 1; i < rope.Length; i++)
    {
        var offset = new
        {
            X = rope[i - 1].X - rope[i].X,
            Y = rope[i - 1].Y - rope[i].Y
        };

        void MoveX()
        {
            if (offset.X > 0)
            {
                rope[i].X++;
            }
            else if (offset.X < 0)
            {
                rope[i].X--;
            }
        }

        void MoveY()
        {
            if (offset.Y > 0)
            {
                rope[i].Y++;
            }
            else if (offset.Y < 0)
            {
                rope[i].Y--;
            }
        }

        if (offset.X > 1)
        {
            rope[i].X++;
            MoveY();
        }
        else if (offset.X < -1)
        {
            rope[i].X--;
            MoveY();
        }
        else if (offset.Y > 1)
        {
            rope[i].Y++;
            MoveX();
        }
        else if (offset.Y < -1)
        {
            rope[i].Y--;
            MoveX();
        }
    }

    visited.Add(rope[^1]);

    if (distance > 1)
    {
        Move(x, y, distance - 1);
    }
}

Console.WriteLine(visited.Count);