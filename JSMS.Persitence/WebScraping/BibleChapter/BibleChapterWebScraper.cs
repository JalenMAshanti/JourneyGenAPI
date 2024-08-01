using HtmlAgilityPack;

namespace JSMS.Persitence.WebScraping.BibleChapter
{
    public class BibleChapterWebScraper : WebScraperUnique
    {
        public BibleChapterWebScraper(HttpClient client, HtmlDocument document) : base(client, document)
        {
        }
    }
}
