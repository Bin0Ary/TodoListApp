using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoListLibrary.Models
{
    public class TodoListItemModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset? DueDate { get; set; } = null;
        public bool IsChecked { get; set; } = false;
        public TodoListItemModel(string title, string description, string dueDate)
        {
            Title = title;
            Description = description;
            DueDate = DateTime.ParseExact(dueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

    }
}
