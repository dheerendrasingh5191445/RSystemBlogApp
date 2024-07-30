using BlogApi.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection.Metadata;

namespace BlogApi.Helper
{
    public class JsonHelper : IDbcontext
    {
        private static readonly string JsonFilePath = "blog.json";
        public IEnumerable<BlogModel> AddBlog(BlogModel blog)
        {
            int newId = 1;
            List<BlogModel> blogList = (List<BlogModel>)GetAll();
            if(blogList.Count > 0)
            {
                newId = blogList.Max(x => x.Id);
                ++newId;
            }

            blogList.Add(new BlogModel
            {
                Id= newId,
                Text = blog.Text,
                DateCreated = blog.DateCreated,
                Username = blog.Username,

            });
            File.WriteAllText(JsonFilePath, String.Empty);
            using (StreamWriter sw = File.AppendText(JsonFilePath))
            {
                sw.Write(JsonConvert.SerializeObject(blogList));
            }
            return blogList;
        }

        public bool DeleteBlog(int Id)
        {
            List<BlogModel> blogList = (List<BlogModel>)GetAll();

            if (blogList.Count > 0)
            {
                BlogModel blog = blogList.Where(x => x.Id == Id).SingleOrDefault();
                blogList.Remove(blog);
                File.WriteAllText(JsonFilePath, String.Empty);
                using (StreamWriter sw = File.AppendText(JsonFilePath))
                {
                    sw.Write(JsonConvert.SerializeObject(blogList));
                }
            }
            return true;
        }

        public IEnumerable<BlogModel> GetAll()
        {
            IEnumerable<BlogModel> blogList = new List<BlogModel>();

            if (!File.Exists(JsonFilePath))
            {
                File.Create(JsonFilePath).Close();
            }
            using (StreamReader sr = new StreamReader(JsonFilePath))
            {
                string jsonString = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonString);
                if (list != null)
                {
                    blogList = list;
                }
            }

            return blogList;
        }

        public IEnumerable<BlogModel> UpdateBlogById(BlogModel blog)
        {
            List<BlogModel> blogList = (List<BlogModel>)GetAll();

            if (blogList.Count > 0)
            {
                BlogModel updateblog = blogList.Where(x => x.Id == blog.Id).SingleOrDefault();
                updateblog.Text = blog.Text;
                updateblog.Username = blog.Username;
                updateblog.DateCreated = blog.DateCreated;
                File.WriteAllText(JsonFilePath, String.Empty);
                using (StreamWriter sw = File.AppendText(JsonFilePath))
                {
                    sw.Write(JsonConvert.SerializeObject(blogList));
                }
            }
            return blogList;
        }
    }
}
