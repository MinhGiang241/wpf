using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfBasic
{
    public static class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

        }

        public static string GetFileFolderName(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath)) return string.Empty;

            var normalizedPath = dirPath.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0) return dirPath;

            return dirPath.Substring(lastIndex + 1);
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch { }


            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0) items.AddRange(fs.Select(f => new DirectoryItem { FullPath = f, Type = DirectoryItemType.File }));
            }
            catch { }


            return items;
        }

    }
}
