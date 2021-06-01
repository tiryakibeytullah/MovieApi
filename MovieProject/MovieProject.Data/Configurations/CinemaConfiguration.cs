using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.NumberOfHalls).IsRequired();
            builder.ToTable("Cinemas");
        }
    }
}
