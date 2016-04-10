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
        public Boolean IsLocked { get; set; }
        public Int32 CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Int32 UpdatedById { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}