using Calend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace Calend.Data
{
    public class DBContext: IdentityDbContext<AppUser>
    {


        public DBContext()
        {
        }


        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Location> Locations { get; set } 


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder().Build();
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("Default"));
        }
    }
}
