using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExEf6.Model;
using System.Data.Entity;


namespace ExEf6
{
    class Program
    {
        public static void PullDataFromTheDatabase()
        {
            var lstPosts = new List<Post>();
            using (var db = new BlogContext())
            {
                lstPosts = db.Posts.ToList();
            }

            foreach (var p in lstPosts)
            {
                Console.WriteLine($"Post with id {p.Id} has the title {p.Title}.");
            }

            Console.ReadKey();
        }

        public static void InsertDataToTheDatabase()
        {
            int papaId;
            using (var db = new BlogContext())
            {
                papaId = db.Users.FirstOrDefault(x => x.FullName == "Michalis Papadakis").Id;
            }
            var blog = new Blog()
            {
                Title = "My test Ef Blog",
                Posts = new List<Post>()
                {
                    new Post() { Title = "Test Post One", UserId = papaId },
                    new Post() { Title = "Test Post Two", UserId = papaId },
                }
            };
            using (var db = new BlogContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

        }

        public static void FindDataAndUpdate()
        {
            using (var db = new BlogContext())
            {
                var blog = db.Blogs.Where(b => b.Title == "My Ef Blog").FirstOrDefault();
                blog.Title = "My Awesome Ef Blog";
                db.SaveChanges();
            }
        }

        public static void FindDataAndDelete()
        {
            using (var db = new BlogContext())
            {
                var post = db.Posts.FirstOrDefault(p => p.Title == "Post Two");
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }

        public static void ASimpleJoin()
        {
            var lstBlogs = new List<Blog>();
            using (var db = new BlogContext())
            {
                lstBlogs = db.Blogs.Include(b => b.Posts).ToList();
            }

            foreach (var b in lstBlogs)
            {
                Console.WriteLine($"This blog {b.Title} has this posts : ");
                foreach (var p in b.Posts)
                {
                    Console.WriteLine($"This is a post title : {p.Title}");
                }
            }
            Console.ReadKey();
        }

        public static void CounAllPosts()
        {
            using (var db = new BlogContext())
            {

                var totalPost = db.Posts.Count();
                Console.WriteLine($"Total posts {totalPost}");

                var sumTotalLikesInPosts = db.Posts.Sum(x => x.Likes);
                Console.WriteLine($"Total posts likes {sumTotalLikesInPosts}");

            }
            Console.ReadKey();
        }



            static void Main(string[] args)
        {
            //PullDataFromTheDatabase();
            //InsertDataToTheDatabase();
            //FindDataAndUpdate();
            //FindDataAndDelete();
            ASimpleJoin();
            //CounAllPosts();
        }
    }
}
