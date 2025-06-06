using CinemaAppAspNetCoreMVC.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppAspNetCoreMVC.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BookingDate)
                .IsRequired();

            builder.HasOne(b => b.Session)
                .WithMany()  
                .HasForeignKey(b => b.SessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}