using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Employers;
using job_search_be.Domain.Entity;
using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Exceptions;
using job_search_be.Infrastructure.Repositories;
using job_search_be.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.Service
{
    public class EmployersService : IEmployersService
    {
        private readonly IEmployersRepository _employersRepository;
        private readonly IMapper _mapper;
        public EmployersService(IEmployersRepository employersRepository, IMapper mapper)
        {
            _employersRepository = employersRepository;
            _mapper = mapper;
        }
        public DataResponse<EmployersQuery> Create(EmployersDto dto)
        {
            dto.EmployersId = Guid.NewGuid();
            var newData = _employersRepository.Create(_mapper.Map<Employers>(dto));
            if (newData != null)
            {
                return new DataResponse<EmployersQuery>(_mapper.Map<EmployersQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }

        public DataResponse<EmployersQuery> Delete(Guid id)
        {
            var item = _employersRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _employersRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<EmployersQuery>(_mapper.Map<EmployersQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<EmployersQuery> GetById(Guid id)
        {
            var item = _employersRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<EmployersQuery>(_mapper.Map<EmployersQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<EmployersQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<EmployersQuery>>(_employersRepository.GetAllData());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.CompanyName.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<EmployersQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<EmployersQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<List<EmployersDto>> ItemsList()
        {
            var query = _employersRepository.GetAllData();
            if (query != null && query.Any())
            {
                var cityDtos = _mapper.Map<List<EmployersDto>>(query);
                return new DataResponse<List<EmployersDto>>(_mapper.Map<List<EmployersDto>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
        }

        public DataResponse<EmployersQuery> Update(EmployersDto dto)
        {
            var item = _employersRepository.GetById(dto.EmployersId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _employersRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<EmployersQuery>(_mapper.Map<EmployersQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }
    }
}
