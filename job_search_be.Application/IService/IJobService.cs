﻿using job_search_be.Application.Helpers;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.IService
{
    public interface IJobService
    {
        PagedDataResponse<JobQuery> Items(CommonListQuery commonListQuery);
        DataResponse<JobQuery> Create(JobDto dto);
        DataResponse<JobQuery> Update(JobDto dto);
        DataResponse<JobQuery> Delete(Guid id);
        DataResponse<JobQuery> GetById(Guid id);
    }
}