using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Core.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int NumberOfHalls { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarkod { get; set; }
        public ICollection<Movie> Movies { get; set; } // Bir sinemaya ait, birden fazla film olabilir.
    }
}
