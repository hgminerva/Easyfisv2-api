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
    public class MstBranchController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstBranch
        public List<MstBranch> Get()
        {
            var branches = from d in db.MstBranches
                           select new Models.MstBranch
                           {
                                Id = d.Id,
                                BranchCode = d.BranchCode,
                                Branch = d.Branch,
                                Address = d.Address,
                                ContactNumber = d.ContactNumber,
                                CompanyId = d.CompanyId,
                                Company = d.MstCompany.Company,
                                IsLocked = d.IsLocked,
                                CreatedById = d.CreatedById,
                                CreatedDateTime = d.CreatedDateTime,
                                UpdatedById = d.UpdatedById,
                                UpdatedDateTime = d.UpdatedDateTime
                           };
            return branches.ToList();
        }
    }
}