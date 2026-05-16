using backend.Abstracts;

namespace backend.Models
{
    public sealed class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; } = new List<ToDoTask>();
    }
}
