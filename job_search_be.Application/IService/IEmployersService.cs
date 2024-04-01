﻿using job_search_be.Application.Helpers;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Auth;
using job_search_be.Domain.Dto.Employers;
using job_search_be.Domain.Dto.Formofwork;
using job_search_be.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenDto = job_search_be.Domain.Dto.Employers.TokenDto;

namespace job_search_be.Application.IService
{
    public interface IEmployersService
    {
        PagedDataResponse<EmployersQuery> Items(CommonListQuery commonList);
        DataResponse<List<EmployersDto>> ItemsList();
        DataResponse<EmployersQuery> Create(EmployersDto dto);
        DataResponse<EmployersQuery> Update(EmployersDto dto);
        DataResponse<EmployersQuery> Delete(Guid id);
        DataResponse<EmployersQuery> GetById(Guid id);
        DataResponse<TokenDto> Login(EmployersLogin dto);
        DataResponse<TokenDto> Refresh_Token(RefreshTokenSettings token);
    }
}
