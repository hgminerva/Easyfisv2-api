using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstAccountType
    {
        public MstAccountType()
        {
            this.MstAccounts = new HashSet<MstAccount>();
        }
        public Int32 Id { get; set; }
        public String AccountTypeCode { get; set; }
        public String AccountType { get; set; }
        public Int32 AccountCategoryId { get; set; }

        [ForeignKey("AccountCategoryId")]
        public virtual MstAccountCategory MstAccountCategories { get; set; }
        public String SubCategoryDescription { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public virtual ICollection<MstAccount> MstAccounts { get; set; }
    }
}