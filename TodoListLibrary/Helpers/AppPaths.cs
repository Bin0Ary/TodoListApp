using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListLibrary.Helpers
{
    public static class AppPaths
    {
        public static readonly string ApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TodoApp");
        public static readonly string SettingPath = Path.Combine(ApplicationDataPath, "Settings");
        public static readonly string ListPath = Path.Combine(ApplicationDataPath, "List");
    }
}
