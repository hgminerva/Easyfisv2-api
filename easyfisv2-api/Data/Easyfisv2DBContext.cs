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

        // Masters
        public DbSet<MstAccount> MstAccounts { get; set; }
        public DbSet<MstAccountCategory> MstAccountCategories { get; set; }
        public DbSet<MstAccountCashFlow> MstAccountCashFlows { get; set; }
        public DbSet<MstAccountType> MstAccountTypes { get; set; }
        public DbSet<MstUser> MstUsers { get; set; }
        public DbSet<MstBranch> MstBranches { get; set; }
        public DbSet<MstCompany> MstCompanies { get; set; }

        // Transactions
        public DbSet<TrnJournalVoucher> TrnJournalVouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrnJournalVoucher>()
                        .HasRequired(m => m.MstUser_PreparedBy)
                        .WithMany(t => t.TrnJournalVouchers_PreparedBy)
                        .HasForeignKey(m => m.PreparedById)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<TrnJournalVoucher>()
                        .HasRequired(m => m.MstUser_CheckedBy)
                        .WithMany(t => t.TrnJournalVouchers_CheckedBy)
                        .HasForeignKey(m => m.CheckedById)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<TrnJournalVoucher>()
                        .HasRequired(m => m.MstUser_ApprovedBy)
                        .WithMany(t => t.TrnJournalVouchers_ApprovedBy)
                        .HasForeignKey(m => m.ApprovedById)
                        .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}