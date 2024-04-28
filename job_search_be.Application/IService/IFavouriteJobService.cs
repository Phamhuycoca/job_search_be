using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Auth;
using job_search_be.Domain.Dto.Favourite;
using job_search_be.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.IService
{
    public interface IFavouriteJobService
    {
        DataResponse<TokenDto> Favourite(FavouriteJobDto dto);

    }
}
