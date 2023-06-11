using LiteDB;

namespace RazorPagesApp.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
