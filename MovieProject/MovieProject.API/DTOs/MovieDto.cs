using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public int Time { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Subject { get; set; }
        public int CategoryId { get; set; }
    }
}
