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
    public class AccountCategoryController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/AccountCategory
        public List<AccountCategory> Get()
        {
            var accountCategories = from d in db.MstAccountCategories
                                    select new Models.AccountCategory
                                    {
                                       Id = d.Id,
                                       AccountCategoryCode = d.AccountCategoryCode,
                                       AccountCategoryDescription = d.AccountCategory,
                                       IsLocked = d.IsLocked,
                                       CreatedById = d.CreatedById,
                                       CreatedDateTime = d.CreatedDateTime,
                                       UpdatedById = d.UpdatedById,
                                       UpdatedDateTime = d.UpdatedDateTime
                                    };
            return accountCategories.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}