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
    public class MstCompanyController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstCompany
        public List<MstCompany> Get()
        {
            var companies = from d in db.MstCompanies
                            select new Models.MstCompany
                            {
                                Id = d.Id,
                                Company = d.Company,
                                ContactNumber = d.ContactNumber,
                                IsLocked = d.IsLocked,
                                CreatedById = d.CreatedById,
                                CreatedDateTime = d.CreatedDateTime,
                                UpdatedById = d.UpdatedById,
                                UpdatedDateTime = d.UpdatedDateTime
                            };
            return companies.ToList();
        }
    }
}