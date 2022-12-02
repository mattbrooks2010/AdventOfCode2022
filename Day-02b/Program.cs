var scoreMap = new int[3, 3];
scoreMap[0, 0] = 3 + 0;
scoreMap[0, 1] = 1 + 3;
scoreMap[0, 2] = 2 + 6;
scoreMap[1, 0] = 1 + 0;
scoreMap[1, 1] = 2 + 3;
scoreMap[1, 2] = 3 + 6;
scoreMap[2, 0] = 2 + 0;
scoreMap[2, 1] = 3 + 3;
scoreMap[2, 2] = 1 + 6;

var line = string.Empty;
var score = 0;

while ((line = Console.ReadLine()) != null)
{
    // https://en.wikipedia.org/wiki/List_of_Unicode_characters#Basic_Latin
    score += scoreMap[line[0] - 65, line[2] - 88];
}

Console.WriteLine(score);
