using ChallengeWirolsut.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.DataAccess
{
    public class ChallengeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ChallengeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Challenge"]);
        }

        public DbSet<City> City { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
