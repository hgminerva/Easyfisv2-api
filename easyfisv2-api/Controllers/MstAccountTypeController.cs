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
    public class MstAccountTypeController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstAccountType
        public List<MstAccountType> Get()
        {
            var accountTypes = from d in db.MstAccountTypes
                               select new Models.MstAccountType
                               {
                                    Id = d.Id,
                                    AccountTypeCode = d.AccountTypeCode,
                                    AccountType = d.AccountType,
                                    AccountCategoryId = d.AccountCategoryId,
                                    AccountCategory = d.MstAccountCategories.AccountCategory,
                                    SubCategoryDescription = d.SubCategoryDescription,
                                    IsLocked = d.IsLocked,
                                    CreatedById = d.CreatedById,
                                    CreatedDateTime = d.CreatedDateTime,
                                    UpdatedById = d.UpdatedById,
                                    UpdatedDateTime = d.UpdatedDateTime
                               };
            return accountTypes.ToList();
        }

        // GET api/MstAccountType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/MstAccountType
        public void Post([FromBody]string value)
        {
        }

        // PUT api/MstAccountType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/MstAccountType/5
        public void Delete(int id)
        {
        }
    }
}