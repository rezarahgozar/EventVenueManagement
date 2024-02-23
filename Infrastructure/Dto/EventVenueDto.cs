using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class EventVenueDto
    {
        public List<EventDto>? Events { get; set; }
        public List<VenueDto>? Venues { get; set; }
    }
}
