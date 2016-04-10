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
    public class MstAccountController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstAccount
        public List<MstAccount> Get()
        {
            var accounts = from d in db.MstAccounts
                           select new Models.MstAccount
                           {
                                Id = d.Id,
                                AccountCode = d.AccountCode,
                                Account = d.Account,
                                AccountTypeId = d.AccountTypeId,
                                AccountType = d.MstAccountType.AccountType,
                                AccountCashFlowId = d.AccountCashFlowId,
                                AccountCashFlow = d.MstAccountCashFlow.AccountCashFlow,
                                IsLocked = d.IsLocked,
                                CreatedById = d.CreatedById,
                                CreatedDateTime = d.CreatedDateTime,
                                UpdatedById = d.UpdatedById,
                                UpdatedDateTime = d.UpdatedDateTime
                           };
            return accounts.ToList();
        }

        // GET api/MstAccount/5
        public MstAccount Get(int id)
        {
            var account = from d in db.MstAccounts
                          where d.Id == id
                          select new Models.MstAccount
                          {
                               Id = d.Id,
                               AccountCode = d.AccountCode,
                               Account = d.Account,
                               AccountTypeId = d.AccountTypeId,
                               AccountType = d.MstAccountType.AccountType,
                               AccountCashFlowId = d.AccountCashFlowId,
                               AccountCashFlow = d.MstAccountCashFlow.AccountCashFlow,
                               IsLocked = d.IsLocked,
                               CreatedById = d.CreatedById,
                               CreatedDateTime = d.CreatedDateTime,
                               UpdatedById = d.UpdatedById,
                               UpdatedDateTime = d.UpdatedDateTime
                          };
            return account.FirstOrDefault();
        }

        // POST api/MstAccount
        public void Post([FromBody]MstAccount value)
        {
            var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

            Data.MstAccount newAccount = new Data.MstAccount();

            newAccount.AccountCode = value.AccountCode;
            newAccount.Account = value.Account;
            newAccount.AccountTypeId = value.AccountTypeId;
            newAccount.AccountCashFlowId = value.AccountCashFlowId;
            newAccount.IsLocked = true;
            newAccount.CreatedById = user.Id;
            newAccount.CreatedDateTime = DateTime.Now;
            newAccount.UpdatedById = user.Id;
            newAccount.UpdatedDateTime = DateTime.Now;

            db.MstAccounts.Add(newAccount);
            db.SaveChanges();
        }

        // PUT api/MstAccount/5
        public void Put(int id, [FromBody]MstAccount value)
        {
            var account = from d in db.MstAccounts where d.Id == id select d;
            if (account.Any())
            {
                var editAccount = account.FirstOrDefault();

                var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                editAccount.AccountCode = value.AccountCode;
                editAccount.Account = value.Account;
                editAccount.AccountTypeId = value.AccountTypeId;
                editAccount.AccountCashFlowId = value.AccountCashFlowId;
                editAccount.IsLocked = true;
                editAccount.UpdatedById = user.Id;
                editAccount.UpdatedDateTime = DateTime.Now;

                db.SaveChanges();
            }
        }

        // DELETE api/MstAccount/5
        public void Delete(int id)
        {
            var account = from d in db.MstAccounts where d.Id == id select d;
            if (account.Any())
            {
                var deleteAccount = account.FirstOrDefault();
                db.MstAccounts.Remove(deleteAccount);
                db.SaveChanges();
            }
        }
    }
}
