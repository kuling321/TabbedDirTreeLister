using System;
using System.IO;

public partial class DirectoryInfo
{
    public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dirInfo, params string[] extensions)
    {
        var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

        return dirInfo.EnumerateFiles()
                      .Where(f => allowedExtensions.Contains(f.Extension));
    }
}
