using backend.Abstracts;
using backend.Models.Enums;

namespace backend.Models
{
    public sealed class ToDoTask : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskProgress Progress { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
