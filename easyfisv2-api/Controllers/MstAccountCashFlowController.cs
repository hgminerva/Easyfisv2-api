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

        // GET api/AccountCashFlow/5
        public MstAccountCashFlow Get(int id)
        {
            var accountCashFlow = from d in db.MstAccountCashFlows
                                  where d.Id == id
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
            return accountCashFlow.FirstOrDefault();
        }

        // POST api/AccountCashFlow
        public HttpResponseMessage Post([FromBody]MstAccountCashFlow value)
        {
            try
            {
                var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                Data.MstAccountCashFlow newAccountCashFlow = new Data.MstAccountCashFlow();

                newAccountCashFlow.AccountCashFlowCode = value.AccountCashFlowCode;
                newAccountCashFlow.AccountCashFlow = value.AccountCashFlow;
                newAccountCashFlow.IsLocked = true;
                newAccountCashFlow.CreatedById = user.Id;
                newAccountCashFlow.CreatedDateTime = DateTime.Now;
                newAccountCashFlow.UpdatedById = user.Id;
                newAccountCashFlow.UpdatedDateTime = DateTime.Now;

                db.MstAccountCashFlows.Add(newAccountCashFlow);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // PUT api/AccountCashFlow/5
        public HttpResponseMessage Put(int id, [FromBody]MstAccountCashFlow value)
        {
            try
            {
                var accountCashFlow = from d in db.MstAccountCashFlows where d.Id == id select d;
                if (accountCashFlow.Any())
                {
                    var editAccountCashFlow = accountCashFlow.FirstOrDefault();

                    var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                    editAccountCashFlow.AccountCashFlowCode = value.AccountCashFlowCode;
                    editAccountCashFlow.AccountCashFlow = value.AccountCashFlow;
                    editAccountCashFlow.IsLocked = true;
                    editAccountCashFlow.UpdatedById = user.Id;
                    editAccountCashFlow.UpdatedDateTime = DateTime.Now;

                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // DELETE api/AccountCashFlow/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var accountCashFlow = from d in db.MstAccountCashFlows where d.Id == id select d;
                if (accountCashFlow.Any())
                {
                    var deleteAccountCashFlow = accountCashFlow.FirstOrDefault();
                    db.MstAccountCashFlows.Remove(deleteAccountCashFlow);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }
    }
}