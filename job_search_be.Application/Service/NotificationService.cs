using AutoMapper;
using job_search_be.Application.Helpers;
using job_search_be.Application.IService;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Domain.Dto.Notification;
using job_search_be.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Application.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public DataResponse<NotificationQuery> Create(NotificationDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResponse<NotificationQuery> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<NotificationQuery> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public PagedDataResponse<NotificationQuery> Items(CommonListQuery commonList)
        {
            throw new NotImplementedException();
        }

        public DataResponse<List<NotificationQuery>> ItemsList()
        {
            throw new NotImplementedException();
        }

        public DataResponse<NotificationQuery> Update(NotificationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
