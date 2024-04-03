using job_search_be.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace job_search_be.Api.Controllers.Job_Seeker
{
    [Route("api/[controller]")]
    [ApiController]
    public class Job_SeekerController : ControllerBase
    {
        private readonly IJob_SeekerService job_SeekerService;
        public Job_SeekerController(IJob_SeekerService job_SeekerService)
        {
            this.job_SeekerService = job_SeekerService;
        }
    }
}
