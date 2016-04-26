using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Data
{
    public class MstAccountCategory
    {
        public Int32 Id { get; set; }
        public String AccountCategoryCode { get; set; }
        public String AccountCategory { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        // FK
        public virtual ICollection<MstAccountType> MstAccountTypes { get; set; }

        // Method
        public MstAccountCategory()
        {
            this.MstAccountTypes = new HashSet<MstAccountType>();
        }
    }
}