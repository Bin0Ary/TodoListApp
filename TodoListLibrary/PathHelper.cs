namespace TodoListLibrary
{
    public static class PathHelper
    {

        public static string GetCategoryPath(string categoryName)
        {
            if(IsValidName(categoryName))
            {
                var path = Path.Combine(AppPaths.ListPath, categoryName);
                EnsureDirectory(path);
                return path;
            }
            else return "Invalid directory name.";
        }

        public static string GetFilePath(string fileName, string categoryName = "")
        {
            if( IsValidName(fileName))
            {
                var path = Path.Combine(AppPaths.ListPath, categoryName, $"{fileName}.json");
                EnsureFile(path);
                return path;
            }
            else return "Invalid file name.";
        }
        public static void EnsureFile(string path)
        {
            if(!File.Exists(path)) File.Create(path);
        }
        public static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public static readonly string[] invalidCrossPlatformChar =
        {
             "<", ">", ":", "\"", "/", "\\", "|", "?", "*",
            "\0" 
        };
        public static readonly string[] invalidCrossPlatformDirs = 
        {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
        };
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 255) return false;
            else if (invalidCrossPlatformDirs.Contains(name.ToUpper())) return false;
            else if (name.EndsWith(" ") || name.EndsWith(".")) return false;
                foreach (var c in invalidCrossPlatformChar)
                {
                    if (name.Contains(c)) return false;
                }
            return true;
        }
    }
}
