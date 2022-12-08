var map = new int[99, 99];
var score = 0;
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
        var up = 0;
        var down = 0;
        var left = 0;
        var right = 0;

        // left
        for (var k = i - 1; k >= 0; k--)
        {
            left++;

            if (map[k, j] >= height)
            {
                break;
            }
        }

        // right
        for (var k = i + 1; k < map.GetLength(0); k++)
        {
            right++;

            if (map[k, j] >= height)
            {
                break;
            }
        }

        // up
        for (var k = j - 1; k >= 0; k--)
        {
            up++;

            if (map[i, k] >= height)
            {
                break;
            }
        }

        // down
        for (var k = j + 1; k < map.GetLength(1); k++)
        {
            down++;

            if (map[i, k] >= height)
            {
                break;
            }
        }

        score = Math.Max(score, up * down * left * right);
    }
}

Console.WriteLine(score);
