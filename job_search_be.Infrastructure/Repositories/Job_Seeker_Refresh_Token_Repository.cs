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
    public class Job_Seeker_Refresh_Token_Repository : GenericRepository<Job_Seeker_Refresh_Token>, IJob_Seeker_Refresh_Token_Repository
    {
        public Job_Seeker_Refresh_Token_Repository(job_search_DbContext context) : base(context)
        {
        }
    }
}
