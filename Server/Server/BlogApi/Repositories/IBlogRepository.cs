using BlogApi.Model;

namespace BlogApi.Repository
{
    public interface IBlogRepository
    {
        public List<BlogModel> AddBlog(BlogModel blog);
        public bool DeleteBlog(int Id);
        public List<BlogModel> GetAll();
        public BlogModel GetBlogById(int Id);
        public List<BlogModel> UpdateBlogById(BlogModel blog);
    }
}
