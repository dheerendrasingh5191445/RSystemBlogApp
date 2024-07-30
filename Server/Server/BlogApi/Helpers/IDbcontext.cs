using BlogApi.Model;

namespace BlogApi.Helper
{
    public interface IDbcontext
    {
        public IEnumerable<BlogModel> AddBlog(BlogModel blog);
        public bool DeleteBlog(int Id);
        public IEnumerable<BlogModel> GetAll();
        public IEnumerable<BlogModel> UpdateBlogById(BlogModel blog);
    }
}
