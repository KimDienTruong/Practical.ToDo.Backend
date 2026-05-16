using backend.Abstracts;
using backend.Models.Enums;

namespace backend.Models
{
    public sealed class ToDoTask : BaseModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskProgress Progress { get; private set; } = TaskProgress.BackLog;
        public string UserName { get; private set; }
        public User? User { get; private set; }

        public ToDoTask(string title, string description, string userName)
        {
            Title = title;
            Description = description;
            UserName = userName;
        }

        public void UpdateToDo(string? title, string? description, TaskProgress taskProgress = TaskProgress.BackLog)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }

            Progress = taskProgress;
            UpdateAt = DateTime.Now;
        }
    }
}
