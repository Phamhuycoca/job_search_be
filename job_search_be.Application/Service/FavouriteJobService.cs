using AutoMapper;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Auth;
using job_search_be.Domain.Dto.Favourite;
using job_search_be.Domain.Dto.Job;
using job_search_be.Domain.Entity;
using job_search_be.Domain.Repositories;
using job_search_be.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.Service
{
    public class FavouriteJobService:IFavouriteJobService
    {
        private readonly IFavoufite_JobRepository _favoufite_JobRepository;
        private readonly IMapper _mapper;
        public FavouriteJobService(IFavoufite_JobRepository favoufite_JobRepository, IMapper mapper)
        {
            _favoufite_JobRepository = favoufite_JobRepository;
            _mapper = mapper;
        }

        public DataResponse<FavouriteJobDto> Favourite(FavouriteJobDto dto)
        {
            var obj=new Favoufite_Job();
            var isFavourite = _favoufite_JobRepository.GetAllData().Where(x => x.Favoufite_Job_Id == dto.Favoufite_Job_Id && x.Job_SeekerId == dto.Job_SeekerId).FirstOrDefault();
            if(isFavourite == null)
            {
                obj=_favoufite_JobRepository.Create(_mapper.Map<Favoufite_Job>(dto));
            }
            else
            {
                obj = _favoufite_JobRepository.Update(_mapper.Map<Favoufite_Job>(dto));
            }
            return new DataResponse<FavouriteJobDto>(_mapper.Map<FavouriteJobDto>(obj), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);

        }
    }
}
