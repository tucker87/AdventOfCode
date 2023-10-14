public static class Day7B
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

        var neededSpace = 70_000_000 - root.FolderSize();

        return folders
            .Select(f => f.FolderSize())
            .Where(s => s < 100_000)
            .Where(s => neededSpace + s >= 30_000_000)
            .Order()
            .FirstOrDefault();
    }
}