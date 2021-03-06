﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstAccountCashFlow
    {

        public Int32 Id { get; set; }
        public String AccountCashFlowCode { get; set; }
        public String AccountCashFlow { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        // FK
        public virtual ICollection<MstAccount> MstAccounts { get; set; }

        // Method
        public MstAccountCashFlow()
        {
            this.MstAccounts = new HashSet<MstAccount>();
        }
    }
}