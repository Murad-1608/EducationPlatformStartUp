using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCourseForStarters")]
        public IActionResult GetCourseForStarters()
        {
            var result = _courseService.GetCoursesForStarters();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _courseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update(int id)
        {
            var course = _courseService.GetById(id);
            var result = _courseService.Update(course.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _courseService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("homesearch")]
        public IActionResult HomeSearch(string name)
        {
            var values = _courseService.GetByName(name);

            return Ok(values);
        }

        [HttpGet("getforcoursepage")]
        public IActionResult GetForCoursePage()
        {
            var values = _courseService.GetForCoursePage();

            return Ok(values);
        }
    }
}
