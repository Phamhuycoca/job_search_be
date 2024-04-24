using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Favourite;
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
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        public readonly IMapper _mapper;
        public FavouriteService(IFavouriteRepository favouriteRepository, IMapper mapper)
        {
            _favouriteRepository = favouriteRepository;
            _mapper = mapper;
        }

        public PagedDataResponse<FavouriteDto> Items(CommonListQuery commonList, Guid id)
        {
            var query = _mapper.Map<List<FavouriteDto>>(_favouriteRepository.GetAllData().Where(x=>x.Job_SeekerId==id));
           
            var paginatedResult = PaginatedList<FavouriteDto>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<FavouriteDto>(paginatedResult, 200, query.Count());
        }

        public DataResponse<FavouriteDto> Create(FavouriteDto dto)
        {
            dto.FavouriteId = Guid.NewGuid();
            var newData = _favouriteRepository.Create(_mapper.Map<Favourite>(dto));
            if (newData != null)
            {
                return new DataResponse<FavouriteDto>(_mapper.Map<FavouriteDto>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }

        public DataResponse<FavouriteDto> Update(FavouriteDto dto)
        {
            var item = _favouriteRepository.GetById(dto.FavouriteId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _favouriteRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<FavouriteDto>(_mapper.Map<FavouriteDto>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }

        public DataResponse<FavouriteDto> Delete(Guid id)
        {
            var item = _favouriteRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _favouriteRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<FavouriteDto>(_mapper.Map<FavouriteDto>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<FavouriteDto> GetById(Guid id)
        {
            var item = _favouriteRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<FavouriteDto>(_mapper.Map<FavouriteDto>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }
    }
}
