using Microsoft.EntityFrameworkCore;
using SynopScience.Models;

namespace SynopScience.Data
{
    public class DatasetContext : DbContext
    {
        public DatasetContext(DbContextOptions<DatasetContext> options) : base(options) { }

        //overriding the default function settings of OnModelCreating to adjust the settings of our Models relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Dataset>().HasData(
                //new Dataset {Id = 4, ItemCode = "TST04", ItemName = "TST-000-04", ItemDescription = "howdy", ItemType = "Brass", ItemCount=15, ItemPrice=34.56F, ItemShelfLife=30, ItemActive=true, SerialNumberId=4}
                //);

            //modelBuilder.Entity<SerialNumber>().HasData(
                //new SerialNumber { Id = 4, Name = "TST04", DataId=4 }
                //);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dataset> Dataset { get; set; }

        //create context for SerialNumber Class
        public DbSet<SerialNumber> SerialNumbers { get; set; }  
    }
}
