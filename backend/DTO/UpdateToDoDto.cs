using backend.Models.Enums;

namespace backend.DTO
{
    public class UpdateToDoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskProgress Progress { get; set; }
    }
}
