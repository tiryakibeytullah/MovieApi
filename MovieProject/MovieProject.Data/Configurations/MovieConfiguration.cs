using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ImageUrl).HasMaxLength(20);
            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.InnerBarkod).HasMaxLength(50);
            builder.ToTable("Movies");
        }
    }
}
