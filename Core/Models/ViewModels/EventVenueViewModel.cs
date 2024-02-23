using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ViewModels
{
    public class EventVenueViewModel
    {
        public List<EventViewModel>? Events { get; set; }
        public List<VenueViewModel>? Venues { get; set; }
    }
}
