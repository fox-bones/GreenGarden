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
        public DbSet<TopCrop> TopCrops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gardeners>().HasData(
                new Gardeners
                {
                    ID = 1,
                    FirstName = "Freya",
                    LastName = "Greene",
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
            modelBuilder.Entity<TopCrop>().HasData(
                new TopCrop
                {
                    CropId = 1,
                    Name = "Eggplant",
                    Description = "Native to Asia. Part of the nightshade family."
                },
                new TopCrop
                {
                    CropId = 2,
                    Name = "Tomato",
                    Description = "Part of the nightshade family. Native to the Andes of South America, around Peru."
                },
                new TopCrop
                {
                    CropId = 3,
                    Name = "Potato",
                    Description = "Part of the nightshade family. Native to the Andes of South America."
                }
            );
        }
    }
}
