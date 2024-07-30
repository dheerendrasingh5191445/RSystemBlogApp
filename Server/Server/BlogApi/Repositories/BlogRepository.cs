using BlogApi.Helper;
using BlogApi.Model;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace BlogApi.Repository
{
    public class BlogRepository: IBlogRepository
    {
        private readonly IDbcontext dbcontext;
        public BlogRepository(IDbcontext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }

        public List<BlogModel> AddBlog(BlogModel blog)
        {
            try
            {
                List<BlogModel> blogs = dbcontext.AddBlog(blog).ToList();
                return blogs;
            }catch(Exception ex)
            {
                throw new ApplicationException("No Blog Added Due To Some Reason!!");
            }

        }

        public bool DeleteBlog(int Id)
        {
            return dbcontext.DeleteBlog(Id);
        }

        public List<BlogModel> GetAll()
        {
            List<BlogModel> blogs = dbcontext.GetAll().ToList();
            return blogs;
        }

        public BlogModel GetBlogById(int Id)
        {
            List<BlogModel> blogs = dbcontext.GetAll().ToList();
            var blog = blogs.Where(x => x.Id == Id).FirstOrDefault();
            return blog;
        }

        public List<BlogModel> UpdateBlogById(BlogModel blog)
        {
            try { 
            List<BlogModel> blogs = dbcontext.UpdateBlogById(blog).ToList();
            return blogs;
            }catch(Exception ex)
            {
                throw new ApplicationException("No Blog Updated Due To Some Reason!!", ex.InnerException);
            }
        }
    }
}
