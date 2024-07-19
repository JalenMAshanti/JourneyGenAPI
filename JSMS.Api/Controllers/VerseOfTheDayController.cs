using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.WebScraping.VerseOfTheDay;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerseOfTheDayController : ControllerBase
    {
        private readonly VerseOfTheDayWebScrapper VOTDscraper;
        private readonly VerseLocationWebScrapper VLscraper;
        public VerseOfTheDayController(VerseOfTheDayWebScrapper verseScraper, VerseLocationWebScrapper locationScraper)
        {
            VOTDscraper = verseScraper;
            VLscraper = locationScraper;
        }

        [HttpGet("/GetVerseOfTheDay")]
        public IActionResult GetVerseOfTheDay()
        {
            var verseOfTheDay = new VerseOfTheDay_DTO();
            verseOfTheDay.Verse = VOTDscraper.Scrape();
            verseOfTheDay.VerseLocation = VLscraper.Scrape(); 
            return Ok(verseOfTheDay);
        }
    }
}
