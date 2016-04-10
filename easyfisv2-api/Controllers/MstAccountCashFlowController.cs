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
    public class MstAccountCashFlowController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/AccountCashFlow
        public List<MstAccountCashFlow> Get()
        {
            var accountCashFlows = from d in db.MstAccountCashFlows
                                    select new Models.MstAccountCashFlow
                                    {
                                       Id = d.Id,
                                       AccountCashFlowCode = d.AccountCashFlowCode,
                                       AccountCashFlow = d.AccountCashFlow,
                                       IsLocked = d.IsLocked,
                                       CreatedById = d.CreatedById,
                                       CreatedDateTime = d.CreatedDateTime,
                                       UpdatedById = d.UpdatedById,
                                       UpdatedDateTime = d.UpdatedDateTime
                                    };
            return accountCashFlows.ToList();
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