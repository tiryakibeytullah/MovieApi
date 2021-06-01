using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            this._ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category { Id = _ids[0], Name = "Drama" },
                    new Category { Id = _ids[1], Name = "Bilim Kurgu" },
                    new Category { Id = _ids[2], Name = "Aksiyon" },
                    new Category { Id = _ids[3], Name = "Komedi" }
                );
        }
    }
}
