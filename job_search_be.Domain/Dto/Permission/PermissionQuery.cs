﻿using job_search_be.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Domain.Dto.Permission
{
    public class PermissionQuery:BaseEntity
    {
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
}
