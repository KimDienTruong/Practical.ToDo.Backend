using backend.Abstracts;

namespace backend.Models
{
    public sealed class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<ToDoTask> ToDoTasks { get; } = new List<ToDoTask>();

        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public User() { }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
