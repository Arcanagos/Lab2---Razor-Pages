using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class NowyPostModel : PageModel
    {
        private readonly Database _database;
        private readonly ILogger<NowyPostModel> _logger;
        public NowyPostModel(ILogger<NowyPostModel> logger, Database liteDbService)
        {
            _logger = logger;
            _database = liteDbService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string title, string content, string author)
        {
            _database.AddPost(title, content, author);
            return RedirectToPage("/Posty");
        }
    }
}
