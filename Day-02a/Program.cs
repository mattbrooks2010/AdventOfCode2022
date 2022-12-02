var scoreMap = new int[3, 3];
scoreMap[0, 0] = 1 + 3;
scoreMap[0, 1] = 2 + 6;
scoreMap[0, 2] = 3 + 0;
scoreMap[1, 0] = 1 + 0;
scoreMap[1, 1] = 2 + 3;
scoreMap[1, 2] = 3 + 6;
scoreMap[2, 0] = 1 + 6;
scoreMap[2, 1] = 2 + 0;
scoreMap[2, 2] = 3 + 3;

var score = 0;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    // https://en.wikipedia.org/wiki/List_of_Unicode_characters#Basic_Latin
    score += scoreMap[line[0] - 65, line[2] - 88];
}

Console.WriteLine(score);
