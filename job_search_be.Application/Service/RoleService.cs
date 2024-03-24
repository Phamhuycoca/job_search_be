using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Permission;
using job_search_be.Domain.Dto.Role;
using job_search_be.Domain.Entity;
using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Exceptions;
using job_search_be.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;
        public RoleService(IRoleRepository roleRepository, IMapper mapper, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public DataResponse<RoleQuery> Create(RoleDto dto)
        {
            dto.RoleId=Guid.NewGuid();
            foreach (var item in dto.Permissions)
            {
                var permission = _permissionRepository.GetByString(item);
                if (permission == null)
                {
                    throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.NotFound);
                }
            }

            dto.PermissionId = string.Join(", ", dto.Permissions);

            var newData = _roleRepository.Create(_mapper.Map<Role>(dto));
            if(newData != null)
            {
                return new DataResponse<RoleQuery>(_mapper.Map<RoleQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);


        }

        public DataResponse<RoleQuery> Delete(Guid id)
        {
            var item = _roleRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _roleRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<RoleQuery>(_mapper.Map<RoleQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public PagedDataResponse<RoleQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<RoleQuery>>(_roleRepository.GetAllData());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.RoleName.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<RoleQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<RoleQuery>(paginatedResult, 200, paginatedResult.Count());
        }

        public DataResponse<RoleQuery> Update(RoleDto dto)
        {
            var item =_roleRepository.GetById(dto.RoleId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _roleRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<RoleQuery>(_mapper.Map<RoleQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }
    }
}
