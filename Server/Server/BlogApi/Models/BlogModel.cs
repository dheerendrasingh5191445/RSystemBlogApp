namespace BlogApi.Model
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}
