using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Service;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Favourite;
using job_search_be.Infrastructure.Exceptions;
using job_search_be.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace job_search_be.Api.Controllers.Favoufite
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoufiteController : ControllerBase
    {
        public readonly IFavouriteService _favouriteService;
        public FavoufiteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                    throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_favouriteService.Items(query,Guid.Parse(objId)));
        }

        [HttpPost]
        public IActionResult Create(FavouriteDto dto)
        {
            return Ok(_favouriteService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(FavouriteDto dto)
        {
            return Ok(_favouriteService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_favouriteService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_favouriteService.GetById(id));
        }
    }
}
