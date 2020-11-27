using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.BusinessDirectory;
using WebApi.BusinessRatingsDirectory;
using WebApi.EnterpreneurSaleDirectory;
using WebApi.OrganizationDirectory;
using WebApi.ServiceDirectory;
using WebApi.UserDirectory;
using WebApi.VeteranOrganizationDirectory;
using WebApi.VeteranSaleDirectory;

namespace WebApi.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Veteran> Veterans { get; set; }
        public DbSet<Enterpreneur> Enterpreneurs { get; set; }
        public DbSet<VeteranCenter> VeteransCenter { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessRatings> BusinessesRatings { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<EnterpreneurSale> EnterpreneurSales { get; set; }
        public DbSet<VeteranSale> VeteranSales { get; set; }
        public DbSet<VeteranOrganization> VeteranOrganizations { get; set; }
        public DbSet<WebApi.VeteranAwardDirectory.VeteranAward> VeteranAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasDiscriminator<string>("Role")
            .HasValue<Veteran>("veteran")
            .HasValue<VeteranCenter>("veteransCenter")
            .HasValue<VeteranCenter>("enterpreneur");
            builder.Entity<Veteran>().HasMany(s => s.BusinessRatings).WithOne(s => s.Veteran);
        }
    }
}
