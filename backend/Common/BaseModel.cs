namespace backend.Abstracts
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
