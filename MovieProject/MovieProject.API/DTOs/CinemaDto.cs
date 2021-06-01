using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int NumberOfHalls { get; set; }
    }
}
