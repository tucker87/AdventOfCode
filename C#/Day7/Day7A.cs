public static class Day7A
{
    private static readonly string[] _data = File.ReadAllLines("./Inputs/Day7.txt");

    public static int Run()
    {
        var folders = new HashSet<Folder>();
        var root = new Folder();
        folders.Add(root);
        var currentFolder = root;
        foreach (var x in _data)
        {
            if(currentFolder is null)
                throw new Exception("We ended up at an invalid folder");

            var arr = x.Split(' ');
            switch (arr[0])
            {
                case "$":
                    switch (arr[1])
                    {
                        case "cd":
                            currentFolder = arr[2] switch
                            {
                                "/" => root,
                                ".." => currentFolder.Parent,
                                _ => currentFolder.NavigateTo(arr[2]),
                            };
                            folders.Add(currentFolder!);
                            break;
                    }
                    break;
                case "dir":
                    break;
                default:
                    currentFolder.Files.Add(arr[1], int.Parse(arr[0]));
                    break;
            }
        }
        return folders.Select(f => f.FolderSize()).Where(s => s < 100000).Sum();
    }
}

public class Folder
{
    public Folder()
    {
        
    }

    public Folder(Folder parent)
    {
        Parent = parent;
    }

    public Folder? Parent;
    public Dictionary<string, Folder> Children { get; } = new();
    public Dictionary<string, int> Files { get; } = new();
    public int FolderSize() => Files.Values.Sum() + Children.Values.Select(c => c.FolderSize()).Sum();

    public Folder NavigateTo(string name)
    {
        if(Children.ContainsKey(name))
            return Children[name];

        var folder = new Folder(this);
        Children.Add(name, folder);
        return folder;
    }
}