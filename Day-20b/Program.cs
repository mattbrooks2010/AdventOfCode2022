var key = 811589153;

var input = File.ReadAllLines("input.txt")
    .Select((line, index) => (num: long.Parse(line) * key, idx: index))
    .ToArray();

var decrypted = input.ToList();

for (var i = 1; i <= 10; i++)
{
    foreach (var item in input)
    {
        var index = decrypted.IndexOf(item);
        decrypted.RemoveAt(index);
        decrypted.Insert(((int)(index + item.num % decrypted.Count) + decrypted.Count) % decrypted.Count, item);
    }
}

var index0 = decrypted.FindIndex(o => o.num == 0);
var index1 = decrypted[(index0 + 1000) % decrypted.Count].num;
var index2 = decrypted[(index0 + 2000) % decrypted.Count].num;
var index3 = decrypted[(index0 + 3000) % decrypted.Count].num;

Console.WriteLine(index1 + index2 + index3);