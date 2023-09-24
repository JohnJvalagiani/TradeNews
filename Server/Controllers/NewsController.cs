using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class NewsController: BaseController
    {
        private readonly INewsService _service;
        public NewsController(INewsService service)
        {
            this._service = service;
        }
        //[HttpGet("Get all news")]
        //public async Task<IActionResult> GetAllNews()
        //{
        //    var result = await _service.GetAllNews();
        //    return Ok(result);
        //}
        //[HttpGet("Get all news")]
        //public async Task<IActionResult> GetAllNewFromToday(int days)
        //{
        //    var result = await _service.GetAllNews();
        //    return Ok(result);
        //}
        //[HttpGet("Get all news")]
        //public async Task<IActionResult> CreateTask()
        //{
        //    var result = await _service.GetAllNews();
        //    return Ok(result);
        //}
        //[HttpGet("Get all news")]
        //public async Task<IActionResult> CreateTask()
        //{
        //    var result = await _service.GetAllNews();
        //    return Ok(result);
        // }
    }
}
