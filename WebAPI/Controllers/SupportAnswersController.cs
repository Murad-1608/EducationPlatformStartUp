using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportAnswersController : ControllerBase
    {
        private readonly ISupportAnswerService supportAnswerService;
        public SupportAnswersController(ISupportAnswerService supportAnswerService)
        {
            this.supportAnswerService = supportAnswerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() => Ok(supportAnswerService.GetAll());

        [HttpPost("add")]
        public IActionResult Add(SupportAnswerDto supportAnswerDto)
        {
            var result = supportAnswerService.Add(supportAnswerDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
