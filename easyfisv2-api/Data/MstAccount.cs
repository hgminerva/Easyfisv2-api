using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstAccount
    {
        public Int32 Id { get; set; }
        public String AccountCode { get; set; }
        public String Account { get; set; }

        public Int32 AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public virtual MstAccountType MstAccountType { get; set; }

        public Int32 AccountCashFlowId { get; set; }

        [ForeignKey("AccountCashFlowId")]
        public virtual MstAccountCashFlow MstAccountCashFlow { get; set; }

        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}