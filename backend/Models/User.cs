using backend.Abstracts;

namespace backend.Models
{
    public sealed class User
    {
        public string UserName { get; }
        public string Password { get; private set; }
        public string Email { get; }
        public IEnumerable<ToDoTask> ToDoTasks { get; } = new List<ToDoTask>();

        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
