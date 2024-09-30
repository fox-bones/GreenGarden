using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenGarden.Models
{
    public class GardenerContext : DbContext
    {
        public GardenerContext(DbContextOptions<GardenerContext> options) : base(options) 
        { }
        public DbSet<Gardeners> Gardenership { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gardeners>().HasData(
                new Gardeners
                {
                    ID = 1,
                    FirstName = "Freya",
                    LastName = "Greene"
                },
                new Gardeners
                {
                    ID = 2,
                    FirstName = "Victor",
                    LastName = "Harwood",
                    Email = "victorharwood@gmail.com"
                },
                new Gardeners
                {
                    ID = 3,
                    FirstName = "Luis",
                    LastName = "Greene"
                }

            );
        }
    }
}
