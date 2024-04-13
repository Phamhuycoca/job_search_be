using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace job_search_be.Api.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IJobService _jobService;
        public HomeController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public IActionResult ListJob([FromQuery] CommonQueryByHome queryByHome)
        {
            return Ok(_jobService.ItemsByHome(queryByHome));
        }
        [HttpGet("ItemById/{id}")]
        public IActionResult ItemById(Guid id)
        {
            return Ok(_jobService.ItemById(id));
        }
        [HttpGet("RelatedJobs/{id}")]
        public IActionResult RelatedJobs([FromQuery] CommonQueryByHome queryByHome,Guid id)
        {
            return Ok(_jobService.RelatedJobs(queryByHome,id));
        }

    }
}
