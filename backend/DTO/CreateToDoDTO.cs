using backend.Models.Enums;

namespace backend.DTO
{
    public sealed class CreateToDoDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
