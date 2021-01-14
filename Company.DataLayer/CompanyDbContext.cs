using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using UdemyMVC5UltimateGuide.Migrations;
using Company.DomainModels;

namespace Company.DataLayer
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("MyConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products {get; set; }
    }
}


