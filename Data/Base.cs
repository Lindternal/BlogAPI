namespace BlogAPI.Data
{
    public static class Base
    {
        public static List<Blog> Posts = new List<Blog>
        {
            new Blog
            {
                User = new User.User(1, "TestName", 19),
                Date = DateTime.Now,
                Message = "New message"
            },
            new Blog
            {
                User = new User.User(2, "Nameeee", 24),
                Date = DateTime.Now,
                Message = "message"
            },
            new Blog
            {
                User = new User.User(3, "TestName", 45),
                Date = DateTime.Now,
                Message = "gm"
            }
        };
    }
}
