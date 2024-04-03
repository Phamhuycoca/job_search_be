﻿using job_search_be.Domain.Entity;
using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Infrastructure.Repositories
{
    public class JobSeekerRepository : GenericRepository<Job_Seeker>, IJob_SeekerRepository
    {
        public JobSeekerRepository(job_search_DbContext context) : base(context)
        {
        }
    }
}
