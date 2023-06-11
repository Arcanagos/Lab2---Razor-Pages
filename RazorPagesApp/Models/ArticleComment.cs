using LiteDB;

namespace RazorPagesApp.Models
{
    public class ArticleComment
    {
        public ObjectId Id { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
