﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class VenueDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public string? Location { get; set; }

    }
}
