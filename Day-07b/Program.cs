var root = new FileSystemEntry
{
    Name = "/"
};

var cd = root;

var allDirs = new List<FileSystemEntry>();
allDirs.Add(root);

var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    if (line == "$ cd /" || line == "$ ls")
    {
        // https://en.wikipedia.org/wiki/NOP_(code)
    }
    else if (line == "$ cd ..")
    {
        cd = cd.Parent!;
    }
    else if (line.StartsWith("$ cd "))
    {
        var name = line.Substring(5);
        cd = cd.Children[name];

        allDirs.Add(cd);
    }
    else
    {
        var parts = line.Split(' ');

        var entry = new FileSystemEntry
        {
            Name = parts[1],
            Size = parts[0] == "dir" ? 0 : int.Parse(parts[0]),
            Parent = cd
        };

        cd.Children.Add(entry.Name, entry);
    }
}

var unused = 70000000 - root.GetSize();
var required = 30000000 - unused;
var candidate = root;

foreach (var dir in allDirs)
{
    var size = dir.GetSize();
    
    if (size >= required && size < candidate.GetSize())
    {
        candidate = dir;
    }
}

Console.WriteLine(candidate.GetSize());

class FileSystemEntry
{
    public string Name { get; init; } = string.Empty;
    public int Size { get; init; }
    public FileSystemEntry? Parent { get; init; }
    public SortedList<string, FileSystemEntry> Children { get; init; } = new SortedList<string, FileSystemEntry>();

    public int GetSize()
    {
        var size = Size;

        foreach (var child in Children.Values)
        {
            size += child.GetSize();
        }

        return size;
    }
}
