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
        public MstAccountType Get(int id)
        {
            var accountType = from d in db.MstAccountTypes
                              where d.Id == id
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
            return accountType.FirstOrDefault();
        }

        // POST api/MstAccountType
        public HttpResponseMessage Post([FromBody]MstAccountType value)
        {
            try
            {
                var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                Data.MstAccountType newAccountType = new Data.MstAccountType();

                newAccountType.AccountTypeCode = value.AccountTypeCode;
                newAccountType.AccountType = value.AccountCategory;
                newAccountType.AccountCategoryId = value.AccountCategoryId;
                newAccountType.SubCategoryDescription = value.SubCategoryDescription;
                newAccountType.IsLocked = true;
                newAccountType.CreatedById = user.Id;
                newAccountType.CreatedDateTime = DateTime.Now;
                newAccountType.UpdatedById = user.Id;
                newAccountType.UpdatedDateTime = DateTime.Now;

                db.MstAccountTypes.Add(newAccountType);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // PUT api/MstAccountType/5
        public HttpResponseMessage Put(int id, [FromBody]MstAccountType value)
        {
            try
            {
                var accountType = from d in db.MstAccountTypes where d.Id == id select d;
                if (accountType.Any())
                {
                    var editAccountType = accountType.FirstOrDefault();

                    var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                    editAccountType.AccountTypeCode = value.AccountTypeCode;
                    editAccountType.AccountType = value.AccountType;
                    editAccountType.AccountCategoryId = value.AccountCategoryId;
                    editAccountType.SubCategoryDescription = value.SubCategoryDescription;
                    editAccountType.IsLocked = true;
                    editAccountType.UpdatedById = user.Id;
                    editAccountType.UpdatedDateTime = DateTime.Now;

                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // DELETE api/MstAccountType/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var accountType = from d in db.MstAccountTypes where d.Id == id select d;
                if (accountType.Any())
                {
                    var deleteAccountType = accountType.FirstOrDefault();
                    db.MstAccountTypes.Remove(deleteAccountType);
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