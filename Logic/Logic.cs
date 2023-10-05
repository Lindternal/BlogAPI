using BlogAPI.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BlogAPI.Logic
{
    public static class Logic
    {
        public static List<Blog> GetBaseList()
        {
            return Data.Base.Posts;
        }

        public static int GetBaseCount()
        {
            return Data.Base.Posts.Count;
        }

        public static void AddToBase(Blog blog)
        {
            Data.Base.Posts.Add(blog);
        }

        public static Blog? GetBlogByID(int id)
        {
            return Data.Base.Posts[id];
        }

        public static void SetBlogByID(int id, Blog value)
        {
            Data.Base.Posts[id] = value;
        }

        public static void RemoveBlogByID(int id)
        {
            Data.Base.Posts.RemoveAt(id);
        }
    }
}
