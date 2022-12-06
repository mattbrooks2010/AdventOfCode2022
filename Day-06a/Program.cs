var pos = 0;
var buffer = new List<char>();
var bufferSize = 4;
var read = char.MinValue;

while ((read = (char)Console.Read()) != -1)
{
    buffer.Add(read);
    pos++;
    
    if (buffer.Count > bufferSize)
    {
        buffer.RemoveAt(0);
    }
    
    if (buffer.Distinct().Count() == bufferSize)
    {
        break;
    }
}

Console.WriteLine(pos);
