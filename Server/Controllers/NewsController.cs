using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class NewsController: BaseController
    {
        private readonly ArticlesRepoService _service;
        public NewsController(ArticlesRepoService service)
        {
            this._service = service;
        }
        [HttpGet("Get all news")]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpGet("Get all news from today – {n} days")]
        public async Task<IActionResult> GetnewsfromDay(int days)
        {
            var result = await _service.GetnewsfromDay(days);
            return Ok(result);
        }
        [HttpGet("Get all news per instrument name include news limit")]
        public async Task<IActionResult> GetnewsByInstrument(string instrument)
        {
            var result = await _service.GetnewsByInstrument(instrument);
            return Ok(result);
        }
        [HttpGet("Get all news")]
        public async Task<IActionResult> GetnewsContainsText(string instrument)
        {
            var result = await _service.GetnewsContainsText(instrument);
            return Ok(result);
        }
    }
}
