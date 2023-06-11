using LiteDB;
using Microsoft.Extensions.Hosting;
using RazorPagesApp.Models;
using System.Xml.Linq;

namespace RazorPagesApp
{
    public class Database
    {
        private readonly string _connectionString = "siteDatabase.db";

        public void AddComment(string parentId, string commentText, string author)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var comments = db.GetCollection<Comment>("comments");
                comments.Insert(new Comment { ParentId = parentId, Text = commentText, Author = author });
            }
        }

        public void AddPost(string title, string content, string author)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var posts = db.GetCollection<Post>("posts");
                posts.Insert(new Post { Title = title, Content = content, Author = author });
            }
        }
        public void AddArticleComment(string parentId, string commentText, string author)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var comments = db.GetCollection<Comment>("articlecomments");
                comments.Insert(new Comment { ParentId = parentId, Text = commentText, Author = author });
            }
        }

        public List<Comment> GetComments(string articleId)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var comments = db.GetCollection<Comment>("comments");
                return comments.Find(c => c.ParentId == articleId).ToList();
            }
        }
        public List<ArticleComment> GetArticleComments(string articleId)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var comments = db.GetCollection<ArticleComment>("articlecomments");
                return comments.Find(c => c.ParentId == articleId).ToList();
            }
        }

        public List<Post> GetPosts()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var posts = db.GetCollection<Post>("posts");
                return posts.FindAll().ToList();
            }
        }
        public List<Article> GetArticles()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var articles = db.GetCollection<Article>("articles");
                return articles.FindAll().ToList();
            }
        }
        public void Seed()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var articles = db.GetCollection<Article>("articles");

                if (articles.Count() == 0)
                {
                    var article1 = new Article { Title = "Hit majówki, top 10 wróżb z grilla. Numer 4 cię zaskoczy!", Content = "Numer 1:  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tristique libero lacus, nec dictum velit aliquet quis. Nunc semper eros et tortor tincidunt aliquet. Curabitur fringilla auctor felis, eu dapibus quam laoreet et. In dapibus placerat metus a interdum. Nunc orci arcu, congue ac eleifend in, auctor non nisl. Duis volutpat condimentum gravida. Duis commodo nisi diam, at tristique erat ullamcorper id.\r\n\r\nVivamus iaculis finibus placerat. In ut enim nec nibh convallis elementum. In lectus purus, maximus ac mollis vitae, consectetur ut diam. Proin gravida quam in est laoreet, non ultricies nulla rutrum. Curabitur vitae luctus elit. Nulla quis nisl imperdiet, rhoncus nulla non, congue enim. Aliquam aliquam commodo ex et maximus. Curabitur odio arcu, dapibus vel posuere vitae, pharetra eu eros. Ut finibus purus sed imperdiet molestie.\r\n\r\nDuis egestas tincidunt diam a maximus. Maecenas mollis purus vitae lacus condimentum, eu viverra eros dignissim. Donec rutrum maximus turpis, sit amet cursus urna malesuada sed. Nam in condimentum massa, non convallis magna. Pellentesque nec porttitor lacus. Maecenas maximus scelerisque risus, et vulputate risus porta id. Aenean at elementum sem. In vitae enim magna. Suspendisse feugiat purus id tortor accumsan auctor. Etiam convallis aliquet metus, lacinia elementum nisi fermentum pharetra. Duis nec placerat magna. Aliquam dapibus tellus in justo luctus dictum. Integer in sem rutrum, aliquam urna at, vehicula arcu. " };
                    var article2 = new Article { Title = "Drożdżówka uratowała mi życie", Content = "Jechałem sobie tramwajem kiedy z krzaków wyskoczył Sed massa mauris, interdum malesuada consequat at, lacinia vel purus. Fusce cursus felis vehicula feugiat congue. Proin in viverra nibh, non ullamcorper sapien. Praesent et metus non nibh convallis ultricies. Proin sed elementum dolor, sit amet feugiat mi. Nunc et lectus malesuada, interdum lectus et, tristique felis. Etiam rhoncus, augue sit amet malesuada tempor, libero mauris fringilla urna, ut semper augue felis ac orci. Proin quis fringilla massa. Integer porttitor mauris tortor, vitae malesuada est tincidunt sit amet. Mauris sapien leo, vestibulum vitae pulvinar in, luctus at ex. Aliquam ultricies consequat velit vel euismod. In eget orci nibh. Curabitur feugiat fringilla mi, in pretium mauris iaculis ut. Nullam in nibh eu quam volutpat tincidunt. " };
                    var article3 = new Article { Title = "Wrabiał krowę w oszustwa podatkowe. Zobacz jak >>>", Content = "Genialny oszust od 12 lat uchodził urzędnikom dzięki Quisque consectetur enim vel lectus iaculis rhoncus. Nam ultrices ante sed gravida pulvinar. Vestibulum quis scelerisque nisl. Sed suscipit a justo at hendrerit. Integer tempus mi ex, in tristique enim convallis ut. Integer velit tortor, rhoncus aliquet tristique non, posuere posuere quam. Sed a leo nunc. Praesent accumsan, sem at tristique tempor, dui augue finibus enim, at porttitor neque sapien at ligula. Mauris a pulvinar ligula, in sodales metus. Maecenas nec ipsum luctus, ullamcorper est quis, condimentum magna. Pellentesque libero ante, pharetra sed est sed, tempus tempus ligula. In hac habitasse platea dictumst. Cras suscipit augue at mauris dignissim venenatis. Pellentesque sed venenatis felis. " };

                    articles.InsertBulk(new List<Article> { article1, article2, article3 });

                    var comments = db.GetCollection<Comment>("articlecomments");

                    if (comments.Count() == 0)
                    {
                        comments.Insert(new Comment { ParentId = article1.Id.ToString(), Text = "Mnie wyszła marstkość wątroby", Author = "Władysław68" });
                    }

                }

                var posts = db.GetCollection<Post>("posts");

                if (posts.Count() == 0)
                {
                    var post1 = new Post { Title = "Zjadłem zupe", Content = "Była smaczna", Author = "Maćko" };
                    var post2 = new Post { Title = "Jakie kwiaty na bukiet", Content = "Idzie wiosna i zastanawiam się jakie kwiaty fajnie wyglądają w bukiecie", Author = "Maryśka77" };

                    posts.InsertBulk(new List<Post> { post1, post2 });

                    var comments = db.GetCollection<Comment>("comments");

                    if (comments.Count() == 0)
                    {
                        comments.InsertBulk(new List<Comment>
                        {
                        new Comment { ParentId = post1.Id.ToString(), Text = "Fajnie", Author = "KrzychuMielnijczyk" },
                        new Comment { ParentId = post2.Id.ToString(), Text = "Żonkile są spoko", Author = "Adam Mickiewicz" },
                        });
                    }
                }
            }
        }
    }
}
