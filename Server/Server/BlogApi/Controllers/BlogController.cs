using BlogApi.Helper;
using BlogApi.Model;
using BlogApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;
        public BlogController(IBlogRepository _blogRepository)
        {
            this.blogRepository = _blogRepository;
        }

        // GET: api/<BlogController>
        [HttpGet]
        public IActionResult Get()
        {
            List<BlogModel> blogModels =  blogRepository.GetAll();
            if(blogModels.Count == 0)
            {
                throw new ApplicationException("No Blogs are present in the system. Please Add some!!");
            }
            return Ok(blogModels);
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BlogModel blog = blogRepository.GetBlogById(id);
            if (blog == null)
            {
                throw new ApplicationException("No Record Found For This Id");
            }

            return Ok(blog);
        }

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogModel blog)
        {
            List<BlogModel> blogModels = blogRepository.AddBlog(blog);
            if (blogModels.Count == 0)
            {
                throw new ApplicationException("No Blogs are present in the system. Please Add some!!");
            }

            return Ok(blogModels);
        }

        // PUT api/<BlogController>/5
        [HttpPut]
        public IActionResult Put([FromBody] BlogModel blog)
        {
            List<BlogModel> blogModels = blogRepository.UpdateBlogById(blog);
            if (blogModels.Count == 0)
            {
                throw new ApplicationException("No Blogs are present in the system. Please Add some!!");
            }

            return Ok(blogModels);
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result =  blogRepository.DeleteBlog(id);
            if (!result)
            {
                throw new ApplicationException("Not able Perform Deletion");
            }

            return Ok(result);
        }
    }
}
