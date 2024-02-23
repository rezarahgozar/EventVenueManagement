using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class EventDto
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? StartDate { get; set; }
            public string? Month { get; set; }
            public string? Year { get; set; }
            public int VenueId { get; set; }

    }
}
