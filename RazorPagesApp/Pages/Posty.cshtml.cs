using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp;

namespace RazorPagesApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly Database _database;
        public List<Post> Posts { get; set; }
        public Dictionary<string, List<Comment>> Comments { get; set; }

        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger, Database liteDbService)
        {
            _logger = logger;
            _database = liteDbService;
        }

        public void OnGet()
        {
            Posts = _database.GetPosts();
            Comments = new Dictionary<string, List<Comment>>();

            foreach (var post in Posts)
            {
                Comments[post.Id.ToString()] = _database.GetComments(post.Id.ToString());
            }
        }
        public void OnPost(string postId, string author, string commentText)
        {
            _database.AddComment(postId, commentText, author);
            OnGet();
        }
    }
}