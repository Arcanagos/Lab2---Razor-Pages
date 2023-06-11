using LiteDB;

namespace RazorPagesApp.Models
{
    public class Article
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
