using CinemaAppAspNetCoreMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Data.Configuration
{
    public class MovieConfiguration: IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m =>m.Title).IsRequired().HasMaxLength(50);
            builder.Property(m=>m.Director).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(500);

            builder.HasMany(m=>m.Sessions)
                .WithOne(s => s.Movie)
                .HasForeignKey(s=>s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
