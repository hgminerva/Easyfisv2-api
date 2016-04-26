﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstCompany
    {
        public Int32 Id { get; set; }
        public String Company { get; set; }
        public String Address { get; set; }
        public String ContactNumber { get; set; }
        public String TaxNumber { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        // FK
        public virtual ICollection<MstBranch> MstBranches { get; set; }

        // Method
        public MstCompany()
        {
            this.MstBranches = new HashSet<MstBranch>();
        }
    }
}