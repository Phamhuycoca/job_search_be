using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Domain.Dto.Favourite
{
    public class FavouriteDto
    {
        public Guid FavouriteId { get; set; }
        public Guid Job_SeekerId { get; set; }
        public bool IsFavourite { get; set; }
        public Guid JobId { get; set; }
    }
}
