using System;
using System.Globalization;

namespace TodoListLibrary.Models
{
    public class TodoListItemModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset? DueDate { get; set; } = null;
        public bool IsChecked { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public string TimeRemaining
        {
            get
            {
                if (DueDate == null)
                    return "No due date";

                var timeSpan = DueDate.Value - DateTimeOffset.Now;

                if (timeSpan.TotalSeconds < 0)
                    return "Overdue";

                int days = (int)timeSpan.TotalDays;
                int hours = timeSpan.Hours;
                int minutes = timeSpan.Minutes;

                return $"{days}d {hours}h {minutes}m";
            }
        }

        public TodoListItemModel() { }

        public TodoListItemModel(string title, string description, string dueDate, string dueTime)
        {
            Title = title;
            Description = description;
            if (!(string.IsNullOrEmpty(dueDate) || string.IsNullOrWhiteSpace(dueDate)) && !(string.IsNullOrEmpty(dueTime) || string.IsNullOrWhiteSpace(dueTime)))
                DueDate = DateTime.ParseExact($"{dueDate} {dueTime}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
