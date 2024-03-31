﻿using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using job_search_be.Infrastructure.Common.Utilities;
using System.ComponentModel.Design;

namespace job_search_be.Infrastructure.Module
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IWorkexperienceRepository, WorkexperienceRepository>();
            services.AddScoped<IFormofworkRepository, FormofworkRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            return services;
        }
    }
}
