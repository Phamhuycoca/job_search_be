using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Service;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Recruitment;
using job_search_be.Infrastructure.Exceptions;
using job_search_be.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace job_search_be.Api.Controllers.Recruitment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentService _recruitmentService;
        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_recruitmentService.Items(query,Guid.Parse(objId)));
        }
        [HttpPost]
        public IActionResult Create(RecruitmentDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            dto.Job_SeekerId = Guid.Parse(objId);
            return Ok(_recruitmentService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(RecruitmentDto dto)
        {
            return Ok(_recruitmentService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_recruitmentService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_recruitmentService.GetById(id));
        }
        [Authorize(Roles = "Employer")]
        [HttpGet("ItemsByEmployer")]
        public IActionResult ItemsByEmployer([FromQuery] CommonListQuery query)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_recruitmentService.ItemsByEmployer(query, Guid.Parse(objId)));
        }
    }
}
