var map = new int[99, 99];
var count = (map.GetLength(0) * 2) + (map.GetLength(1) * 2) - 4; // outer edge
var lineIndex = 0;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    for (var i = 0; i < map.GetLength(0); i++)
    {
        map[i, lineIndex] = Convert.ToInt32(line[i]);
    }

    lineIndex++;
}

for (var i = 1; i < map.GetLength(0) - 1; i++)
{
    for (var j = 1; j < map.GetLength(1) - 1; j++)
    {
        var height = map[i, j];
        var visible = false;

        // left
        for (var k = i - 1; k >= 0; k--)
        {
            if (map[k, j] >= height)
            {
                break;
            }
            else if (k == 0)
            {
                visible = true;
                count++;
            }
        }

        if (!visible)
        {
            // right
            for (var k = i + 1; k < map.GetLength(0); k++)
            {
                if (map[k, j] >= height)
                {
                    break;
                }
                else if (k == map.GetLength(0) - 1)
                {
                    visible = true;
                    count++;
                }
            }
        }

        if (!visible)
        {
            // up
            for (var k = j - 1; k >= 0; k--)
            {
                if (map[i, k] >= height)
                {
                    break;
                }
                else if (k == 0)
                {
                    visible = true;
                    count++;
                }
            }
        }

        if (!visible)
        {
            // down
            for (var k = j + 1; k < map.GetLength(1); k++)
            {
                if (map[i, k] >= height)
                {
                    break;
                }
                else if (k == map.GetLength(1) - 1)
                {
                    visible = true;
                    count++;
                }
            }
        }
    }
}

Console.WriteLine(count);
