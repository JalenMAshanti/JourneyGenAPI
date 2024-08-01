using HtmlAgilityPack;
using JSMS.Persitence.Abstractions;

namespace JSMS.Persitence.WebScraping
{
    public abstract class WebScraperUnique : IWebScraper
    {
        private readonly HttpClient _httpClient;
        private readonly HtmlDocument _document;


        public WebScraperUnique(HttpClient client, HtmlDocument document)
        {
            _httpClient = client;
            _document = document;
        }

        public string Scrape(string _url, string _node)
        {
            try
            {
                var html = _httpClient.GetStringAsync(_url).Result;
                _document.LoadHtml(html);
                var verseElement = _document.DocumentNode.SelectSingleNode(_node);

                if (verseElement != null)
                {
                    var verse = verseElement.InnerText;
                    return verse;
                }
                else 
                {
                    return "";
                }
                                            
            }
            catch (Exception ex) 
            {
                return string.Empty;
            }
            
        }
    }
}
