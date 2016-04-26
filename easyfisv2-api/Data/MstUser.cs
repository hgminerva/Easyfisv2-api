using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstUser
    {
        public Int32 Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FullName { get; set; }
        public String UserId { get; set; }
        public Int32 IncomeAccountId { get; set; }

        public Int32 BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual MstBranch MstBranch { get; set; }

        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        // FK - TrnJournalVoucher
        public virtual ICollection<TrnJournalVoucher> TrnJournalVouchers_PreparedBy { get; set; }
        public virtual ICollection<TrnJournalVoucher> TrnJournalVouchers_CheckedBy { get; set; }
        public virtual ICollection<TrnJournalVoucher> TrnJournalVouchers_ApprovedBy { get; set; }
        
        // Method
        public MstUser()
        {
            this.TrnJournalVouchers_PreparedBy = new HashSet<TrnJournalVoucher>();
            this.TrnJournalVouchers_CheckedBy = new HashSet<TrnJournalVoucher>();
            this.TrnJournalVouchers_ApprovedBy = new HashSet<TrnJournalVoucher>();
        }
    }
}