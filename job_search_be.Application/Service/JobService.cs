using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Formofwork;
using job_search_be.Domain.Dto.Job;
using job_search_be.Domain.Dto.Levelwork;
using job_search_be.Domain.Dto.Profession;
using job_search_be.Domain.Dto.Salary;
using job_search_be.Domain.Dto.Workexperience;
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
        private readonly IFormofworkRepository _formofworkRepository;
        private readonly ILevelworkRepository _levelworkRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly ISalaryRepository _aryRepository;
        private readonly IWorkexperienceRepository _workexperienceRepository;
        public JobService(IJobRepository jobRepository, IMapper mapper,
            IFormofworkRepository formofworkRepository, 
            ILevelworkRepository levelworkRepository, 
            ICityRepository cityRepository, 
            IProfessionRepository professionRepository, 
            ISalaryRepository aryRepository, 
            IWorkexperienceRepository workexperienceRepository)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _formofworkRepository = formofworkRepository;
            _levelworkRepository = levelworkRepository;
            _cityRepository = cityRepository;
            _professionRepository = professionRepository;
            _aryRepository = aryRepository;
            _workexperienceRepository = workexperienceRepository;
        }

        public PagedDataResponse<JobQuery> Items(CommonListQuery commonListQuery, Guid objId)
        {
            var query = _mapper.Map<List<JobQuery>>(_jobRepository.GetAllData().Where(x => x.EmployersId == objId).ToList());
            var salaries = _mapper.Map<List<SalaryDto>>(_aryRepository.GetAllData());
            var formofworks= _mapper.Map<List<FormofworkDto>>(_formofworkRepository.GetAllData());
            var levelworks=_mapper.Map<List<LevelworkDto>>(_levelworkRepository.GetAllData());
            var workexperiences = _mapper.Map<List<WorkexperienceDto>>(_workexperienceRepository.GetAllData());
            var professions=_mapper.Map<List<ProfessionDto>>(_professionRepository.GetAllData());
            var cities=_mapper.Map<List<CityDto>>(_cityRepository.GetAllData());           
            var items = from jobs in query
                        join salary in salaries on jobs.SalaryId equals salary.SalaryId
                        join
                       formofwork in formofworks on jobs.FormofworkId equals formofwork.FormofworkId
                        join
                       levelwork in levelworks on jobs.LevelworkId equals levelwork.LevelworkId
                        join
                       workexperience in workexperiences on jobs.WorkexperienceId equals workexperience.WorkexperienceId
                        join
                       profession in professions on jobs.ProfessionId equals profession.ProfessionId
                        join
                       city in cities on jobs.CityId equals city.CityId
                        select new JobQuery
                        {
                            JobId=jobs.JobId,
                            JobName=jobs.JobName,
                            RequestJob=jobs.RequestJob,
                            BenefitsJob=jobs.BenefitsJob,
                            AddressJob=jobs.AddressJob,
                            WorkingTime=jobs.WorkingTime,
                            ExpirationDate=jobs.ExpirationDate,
                            WorkexperienceName=workexperience.WorkexperienceName,
                            FormofworkName=formofwork.FormofworkName,
                            CityName=city.CityName,
                            SalaryPrice=salary.SalaryPrice,
                            ProfessionName=profession.ProfessionName,
                            LevelworkName=levelwork.LevelworkName,
                        };
            if (!string.IsNullOrEmpty(commonListQuery.keyword))
            {
                items = items.Where(x => x.CityName.Contains(commonListQuery.keyword) ||
                x.JobName.Contains(commonListQuery.keyword) ||
                x.SalaryPrice.Contains(commonListQuery.keyword)).ToList();
            }

            var paginatedResult = PaginatedList<JobQuery>.ToPageList(_mapper.Map<List<JobQuery>>(items), commonListQuery.page, commonListQuery.limit);
            return new PagedDataResponse<JobQuery>(paginatedResult, 200, items.Count());
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

       

        public DataResponse<List<JobQuery>> ItemsNoQuery()
        {
            var query = _jobRepository.GetAllData();
            if (query != null && query.Any())
            {
                var cityDtos = _mapper.Map<List<LevelworkDto>>(query);
                return new DataResponse<List<JobQuery>>(_mapper.Map<List<JobQuery>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
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
