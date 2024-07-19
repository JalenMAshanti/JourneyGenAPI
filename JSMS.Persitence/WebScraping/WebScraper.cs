using HtmlAgilityPack;
using JSMS.Persitence.Abstractions;

namespace JSMS.Persitence.WebScraping
{
    public abstract class WebScraper : IWebScraper
    {
        private readonly HttpClient? _httpClient = new HttpClient();
        private readonly HtmlDocument? _document = new HtmlDocument();
        private readonly string? _url;
        private readonly string? _node;

        public WebScraper(string url, string node)
        {
            _url = url;
            _node = node;
        }

        public string Scrape()
        {
            var html = _httpClient.GetStringAsync(_url).Result;
            _document.LoadHtml(html);
            var verseElement = _document.DocumentNode.SelectSingleNode(_node);
            var verse = verseElement.InnerText.Trim();
            return verse;
        }
    }
}
