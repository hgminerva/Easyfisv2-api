using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class Easyfisv2DBContext : DbContext
    {

        public Easyfisv2DBContext()
            : base("Easyfisv2DBContext")
        {
        }

        public DbSet<MstAccountCategory> MstAccountCategories { get; set; }
        public DbSet<MstAccountCashFlow> MstAccountCashFlows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}