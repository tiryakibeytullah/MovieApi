using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieProject.Core.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new Collection<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Movie> Movies { get; set; } // Bir kategoriye ait birden fazla film olabilir.
    }
}
