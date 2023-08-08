using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportQuestionsController : ControllerBase
    {
        private readonly ISupportQuestionService supportQuestionService;
        public SupportQuestionsController(ISupportQuestionService supportQuestionService)
        {
            this.supportQuestionService = supportQuestionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var questions = supportQuestionService.GetAll();

            return Ok(questions);
        }

        [HttpPost("add")]
        public IActionResult Add(SupportQuestionDto supportQuestionDto)
        {
            var result = supportQuestionService.Add(supportQuestionDto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
