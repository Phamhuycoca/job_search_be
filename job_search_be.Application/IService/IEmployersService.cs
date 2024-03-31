using job_search_be.Application.Helpers;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Employers;
using job_search_be.Domain.Dto.Formofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
