using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Job;
using job_search_be.Domain.Dto.Profession;
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
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public DataResponse<JobQuery> Create(JobDto dto)
        {
            dto.JobId = Guid.NewGuid();
            var newData = _jobRepository.Create(_mapper.Map<Job>(dto));
            if (newData != null)
            {
                return new DataResponse<JobQuery>(_mapper.Map<JobQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }

        public DataResponse<JobQuery> Delete(Guid id)
        {
            var item = _jobRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _jobRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<JobQuery>(_mapper.Map<JobQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<JobQuery> GetById(Guid id)
        {
            var item = _jobRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<JobQuery>(_mapper.Map<JobQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<JobQuery> Items(CommonListQuery commonListQuery)
        {
            var query = _mapper.Map<List<JobQuery>>(_jobRepository.GetAllData());
            if (!string.IsNullOrEmpty(commonListQuery.keyword))
            {
                query = query.Where(x => x.JobName.Contains(commonListQuery.keyword) ||
                                         x.WorkingTime.Contains(commonListQuery.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<JobQuery>.ToPageList(query, commonListQuery.page, commonListQuery.limit);
            return new PagedDataResponse<JobQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<JobQuery> Update(JobDto dto)
        {
            var item = _jobRepository.GetById(dto.JobId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _jobRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<JobQuery>(_mapper.Map<JobQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }
    }
}
