namespace BlogAPI
{
    public class Blog
    {
        public User.User? User { get; set; }

        public DateTime Date { get; set; }

        public string? Message { get; set; }
    }
}
