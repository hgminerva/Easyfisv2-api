using easyfisv2_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace easyfisv2_api.Controllers
{
    [Authorize]
    [RoutePrefix("api/MstUser")]
    public class MstUserController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstUser
        public List<Models.MstUser> Get()
        {
            var users = from d in db.MstUsers
                        select new Models.MstUser
                        {
                            Id = d.Id,
                            UserName = d.UserName,
                            FullName = d.FullName,
                            UserId = d.UserId,
                            BranchId = d.BranchId,
                            IncomeAccountId = d.IncomeAccountId,
                            IsLocked = d.IsLocked,
                            CreatedById = d.CreatedById,
                            CreatedDateTime = d.CreatedDateTime,
                            UpdatedById = d.UpdatedById,
                            UpdatedDateTime = d.UpdatedDateTime
                        };
            return users.ToList();
        }

        // GET api/MstUser/Default?username=admin
        [Route("Defaults")]
        public Models.MstUser Get(string username)
        {
            var users = from d in db.MstUsers
                        where d.UserName == username
                        select new Models.MstUser
                        {
                            Id = d.Id,
                            UserName = d.UserName,
                            FullName = d.FullName,
                            UserId = d.UserId,
                            BranchId = d.BranchId,
                            Branch = d.MstBranch.Branch,
                            Company = d.MstBranch.MstCompany.Company,
                            IncomeAccountId = d.IncomeAccountId,
                            IsLocked = d.IsLocked,
                            CreatedById = d.CreatedById,
                            CreatedDateTime = d.CreatedDateTime,
                            UpdatedById = d.UpdatedById,
                            UpdatedDateTime = d.UpdatedDateTime
                        };
            return users.FirstOrDefault();
        }

    }
}
