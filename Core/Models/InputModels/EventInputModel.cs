using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.InputModels
{
    public class EventInputModel
    {
        public int VenueId { get; set; }
        public string? SelectedDate { get; set; }
    }
}
