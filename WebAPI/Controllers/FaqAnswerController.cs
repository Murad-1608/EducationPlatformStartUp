using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqAnswerController : ControllerBase
    {
        private readonly IFaqAnswerService _faqAnswerService;

        public FaqAnswerController(IFaqAnswerService faqAnswerService)
        {
            _faqAnswerService = faqAnswerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        => Ok(_faqAnswerService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var faqAnswer = _faqAnswerService.GetById(id);
            if (!faqAnswer.Success)
            {
                return BadRequest(_faqAnswerService);
            }
            return Ok(faqAnswer);
        }

        [HttpPost]
        public IActionResult CreateAnswer(FaqAnswerCreateDto? faqAnswerCreateDto)
        {
            var createdAnswer = _faqAnswerService.Add(faqAnswerCreateDto);
            
            if (!createdAnswer.Success)
            {
                return BadRequest(createdAnswer);
            }

            return Ok(createdAnswer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnswer(int id)
        {
            var deletedAnswer = _faqAnswerService.Delete(id);

            if (!deletedAnswer.Success)
            {
                return BadRequest(deletedAnswer);
            }

            return Ok(deletedAnswer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FaqAnswerUpdateDto? faqAnswerUpdateDto)
        {
            var updatedAnswer = _faqAnswerService.UpdateFaqAnswer(id, faqAnswerUpdateDto);

            if (!updatedAnswer.Success)
            {
                return BadRequest(updatedAnswer);
            }

            return Ok(updatedAnswer);
        }

    }
}
