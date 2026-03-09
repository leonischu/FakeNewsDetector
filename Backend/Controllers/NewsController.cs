using Backend.DTOs;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IFakeNewsService _service;
        private readonly INewsRepository _repo;

        public NewsController(IFakeNewsService service, INewsRepository repo)
        {
            _service = service;
            _repo = repo;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze(NewsRequestDto dto)
        {
            var result = await _service.AnalyzeAsync(dto.ArticleText);

            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> History()
        {
            var data = await _repo.GetAllAsync();

            return Ok(data);
        }
    }
}
