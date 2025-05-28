    using CinemaAppAspNetCoreMVC.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CinemaAppAspNetCoreMVC.Data.Context
    {
        public class CinemaDbContext : DbContext
        {
            public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
            {

            }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Session> Sessions { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
                base.OnModelCreating(modelBuilder);
            }
        } 
}
