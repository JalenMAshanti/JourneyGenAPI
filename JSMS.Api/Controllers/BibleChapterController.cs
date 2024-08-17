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
			//string baseAdress = $"https://www.bible.com/bible/111/{book}.{chapter}.NIV";
			//string node = "//div[@class='ChapterContent_chapter__uvbX']";
			string baseAdress = $"https://www.biblestudytools.com/{book}/{chapter}.html";
			string node = "//div[@class='py-5 px-3 md:px-12 text-xl']";
			string text = _chapterScraper.Scrape(baseAdress, node);
            bibleChapter.ChapterText = text;
            string result = JsonConvert.SerializeObject(bibleChapter);

            return result;
        }
    }
}

