﻿using job_search_be.Application.IService;
using job_search_be.Domain.Dto.Auth;
using job_search_be.Domain.Dto.Employers;
using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Exceptions;
using job_search_be.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace job_search_be.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmployersService _employersService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEmployers_Refresh_TokenRepository _employers_Refresh_TokenRepository;
        public AuthController(IAuthService authService, IEmployersService employersService, IEmployers_Refresh_TokenRepository employers_Refresh_TokenRepository,IRefreshTokenRepository refreshTokenRepository)
        {
            _authService = authService;
            _employersService = employersService;
            _employers_Refresh_TokenRepository = employers_Refresh_TokenRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(_authService.Login(dto));
        }
        [HttpPost("Refresh_token")]
        public IActionResult Refresh_token([FromBody] RefreshTokenSettings refreshToken)
        {
            var check1 = _refreshTokenRepository.GetAllData().Where(x => x.RefreshToken == refreshToken.Refresh_Token).FirstOrDefault();
            if (check1!=null)
            {
                return Ok(_authService.Refresh_Token(refreshToken));
            }
            var check2=_employers_Refresh_TokenRepository.GetAllData().Where(x=>x.RefreshToken == refreshToken.Refresh_Token).FirstOrDefault();
            if (check2!=null)
            {
                return Ok(_employersService.Refresh_Token(refreshToken));
            }
            throw new ApiException(HttpStatusCode.NOT_FOUND, HttpStatusMessages.NotFound);
        }
        [Authorize]
        [HttpGet("Hello")]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
        [HttpPost("EmployersLogin")]
        public IActionResult Employers_Login(EmployersLogin dto)
        {
            return Ok(_employersService.Login(dto));
        }
       /* [HttpPost("Employers_Refresh_token")]
        public IActionResult Employers_Refresh_token([FromBody] RefreshTokenSettings refreshToken)
        {
            return Ok(_employersService.Refresh_Token(refreshToken));
        }*/
    }
}
