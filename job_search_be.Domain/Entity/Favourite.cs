using job_search_be.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_search_be.Domain.Entity
{
    public class Favourite : BaseEntity
    {
        public Guid FavouriteId { get; set; }
        public Guid Job_SeekerId { get; set; }
        public bool IsFavourite { get; set; }
        public Guid JobId { get; set; }
        public Job? Job { get; set; }
        public Job_Seeker? Job_Seeker { get; set; }
        public Favourite()
        {
            IsFavourite = false;
        }

    }
}
