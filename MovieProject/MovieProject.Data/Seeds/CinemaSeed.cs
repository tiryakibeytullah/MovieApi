using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data.Seeds
{
    public class CinemaSeed : IEntityTypeConfiguration<Cinema>
    {
        private readonly int[] _ids;
        public CinemaSeed(int[] ids)
        {
            this._ids = ids;
        }
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(
                    new Cinema { Id = _ids[0], Name = "Beylikdüzü Sinema Salonu", Address = "Beylikdüzü / İstanbul", Capacity = 250, NumberOfHalls = 5 },
                    new Cinema { Id = _ids[1], Name = "Beykoz Sinema Salonu", Address = "Beykoz / İstanbul", Capacity = 500, NumberOfHalls = 10 }
                );
        }
    }
}
