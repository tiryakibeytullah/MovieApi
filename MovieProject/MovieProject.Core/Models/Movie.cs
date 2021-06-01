using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Time { get; set; }
        public string Subject { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarkod { get; set; }
        public virtual Category Category { get; set; } // Bir filme ait bir kategori olur.
    }
}
