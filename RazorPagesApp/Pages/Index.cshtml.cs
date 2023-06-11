using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp;
using RazorPagesApp.Models;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Database _database;

    public List<Article> Articles { get; set; }
    public Dictionary<string, List<ArticleComment>> ArticleComments { get; set; }

    public IndexModel(ILogger<IndexModel> logger, Database liteDbService)
    {
        _logger = logger;
        _database = liteDbService;
    }

    public void OnGet()
    {
        Articles = _database.GetArticles();
        ArticleComments = new Dictionary<string, List<ArticleComment>>();

        foreach (var article in Articles)
        {
            ArticleComments[article.Id.ToString()] = _database.GetArticleComments(article.Id.ToString());
        }
    }

    public void OnPost(string articleId, string author, string commentText)
    {
        _database.AddArticleComment(articleId, commentText, author);
        OnGet();
    }
}