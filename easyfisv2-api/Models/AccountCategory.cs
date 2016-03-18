using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyfisv2_api.Models
{
    public class AccountCategory
    {
        public Int32 Id { get; set; }
        public String AccountCategoryCode { get; set; }
        public String AccountCategoryDescription { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}