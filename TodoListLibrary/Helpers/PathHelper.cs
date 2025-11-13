namespace TodoListLibrary.Helpers
{
    public static class PathHelper
    {

        public static string GetCategoryPath(string categoryName)
        {

            if (!IsValidName(categoryName) && !(categoryName == ""))
                throw new ArgumentException("Directory name is invalid", nameof(categoryName));

            var path = Path.Combine(AppPaths.ListPath ?? throw new InvalidOperationException("ListPath was not set"), categoryName);
            CreateDirectory(path);
            return path;

        }

        public static string GetFilePath(string fileName, string categoryName = "")
        {
            if (!IsValidName(fileName))
                throw new ArgumentException("File name is invalid", nameof(fileName));
            if (!fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                fileName += ".json";
            var path = Path.Combine(GetCategoryPath(categoryName), fileName);
            CreateFile(path);
            return path;
        }
        public static void CreateFile(string path)
        {
            var directory = Path.GetDirectoryName(path);
            if(!string.IsNullOrEmpty(directory))
                CreateDirectory(directory);
            if(!File.Exists(path))
            {
                try
                {
                    using (File.Create(path)) { }
                }
                catch (IOException)
                {
                    if (!File.Exists(path))
                        throw;
                }
            }
        }
        public static void CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public static readonly string[] invalidCrossPlatformDirs =
        {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
        };
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
                return false;
            if (invalidCrossPlatformDirs.Any(dir => name.Equals(dir, StringComparison.OrdinalIgnoreCase)))
                return false;
            if (name.EndsWith(" ") || name.EndsWith("."))
                return false;
            var invalidChars = Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) >= 0)
                return false;
            return true;
        }
    }
}
