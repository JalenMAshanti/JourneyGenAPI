using HtmlAgilityPack;

namespace JSMS.Persitence.WebScraping.VerseOfTheDay
{
    public class VerseOfTheDayWebScrapper : WebScraper
    {
        public VerseOfTheDayWebScrapper(string url, string node) : base(url, node)
        {
        }
    }
}
