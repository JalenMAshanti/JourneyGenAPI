using JSMS.Domain.Models;
using JSMS.Persitence.WebScraping.BibleChapter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleChapterController : ControllerBase
    {
        private readonly BibleChapterWebScraper _chapterScraper;
       

        public BibleChapterController(BibleChapterWebScraper chapterScraper)
        {
            _chapterScraper = chapterScraper;
         
        }

        [HttpGet("/GetBibleChapter")]
        public string GetBibleChapter(string book, int chapter) 
        {
            BibleChapter bibleChapter = new BibleChapter();
            string baseAdress = $"https://www.bible.com/bible/111/{book}.{chapter}.NIV";
            string node = "//div[@class='ChapterContent_book__VkdB2']";
            string text = _chapterScraper.Scrape(baseAdress, node);
            bibleChapter.ChapterText = text;
            string result = JsonConvert.SerializeObject(bibleChapter);

            return result;
        }
    }
}

