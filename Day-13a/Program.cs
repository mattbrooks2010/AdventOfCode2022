using System.Text.Json;

var pairs = File.ReadAllText("input.txt")
    .Split("\r\n\r\n")
    .Select(pair => pair.Split("\r\n"))
    .Select(pair => pair.Select(s => JsonSerializer.Deserialize<JsonElement>(s)));

var sum = pairs
    .Select(pair => Compare(pair.First()!, pair.Skip(1).First()!))
    .Select((c, i) => (i + 1) * (c <= 0 ? 1 : 0))
    .Sum();

Console.WriteLine(sum);

int Compare(JsonElement x, JsonElement y)
{
    if (x.ValueKind == JsonValueKind.Number && y.ValueKind == JsonValueKind.Number)
    {
        // If both values are integers, the lower integer should come first.
        // If the left integer is lower than the right integer, the inputs are in the right order.
        // If the left integer is higher than the right integer, the inputs are not in the right order.
        // Otherwise, the inputs are the same integer; continue checking the next part of the input.
        return x.GetInt32() - y.GetInt32();
    }

    // If exactly one value is an integer, convert the integer to a list which contains that integer as its only value, then retry the comparison.
    if (x.ValueKind == JsonValueKind.Number && y.ValueKind == JsonValueKind.Array)
    {
        x = JsonSerializer.Deserialize<JsonElement>("[" + x + "]");
    }
    else if (x.ValueKind == JsonValueKind.Array && y.ValueKind == JsonValueKind.Number)
    {
        y = JsonSerializer.Deserialize<JsonElement>("[" + y + "]");
    }

    // If both values are lists...
    for (var i = 0; i < x.GetArrayLength(); i++)
    {
        if (i >= y.GetArrayLength())
        {
            // If the right list runs out of items first, the inputs are not in the right order.
            return 1;
        }

        // ...compare the first value of each list, then the second value, and so on.
        var comp = Compare(x[i], y[i]);

        if (comp != 0)
        {
            return comp;
        }
    }

    // If the left list runs out of items first, the inputs are in the right order.
    // If the lists are the same length and no comparison makes a decision about the order, continue checking the next part of the input.
    return x.GetArrayLength() - y.GetArrayLength();
}
