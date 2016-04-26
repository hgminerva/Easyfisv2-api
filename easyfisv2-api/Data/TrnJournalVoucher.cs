using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class TrnJournalVoucher
    {
        public Int32 Id { get; set; }

        public Int32 BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual MstBranch MstBranch { get; set; }

        public String JVNumber { get; set; }
        public DateTime JVDate { get; set; }
        public String Particulars { get; set; }
        public String ManualJVNumber { get; set; }

        public Int32 PreparedById { get; set; }
        [ForeignKey("PreparedById")]
        public virtual MstUser MstUser_PreparedBy { get; set; }

        public Int32 CheckedById { get; set; }
        [ForeignKey("CheckedById")]
        public virtual MstUser MstUser_CheckedBy { get; set; }

        public Int32 ApprovedById { get; set; }
        [ForeignKey("ApprovedById")]
        public virtual MstUser MstUser_ApprovedBy { get; set; }

        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}