using job_search_be.Application.Helpers;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.City;
using job_search_be.Domain.Dto.Favourite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.IService
{
    public interface IFavouriteService
    {
        PagedDataResponse<FavouriteDto> Items(CommonListQuery commonList,Guid id);
        DataResponse<FavouriteDto> Create(FavouriteDto dto);
        DataResponse<FavouriteDto> Update(FavouriteDto dto);
        DataResponse<FavouriteDto> Delete(Guid id);
        DataResponse<FavouriteDto> GetById(Guid id);
    }
}
