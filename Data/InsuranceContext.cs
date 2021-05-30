using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exercise22.Models;

namespace exercise22.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext (DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }


        public DbSet<PersonModel> Person { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonModel>().ToTable("Person");
        }

        public DbSet<exercise22.Models.PersonModel> PersonModel { get; set; }
    }
}
