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
    public class MstAccountCategoryController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/MstAccountCategory
        public List<MstAccountCategory> Get()
        {
            var accountCategories = from d in db.MstAccountCategories
                                    select new Models.MstAccountCategory
                                    {
                                       Id = d.Id,
                                       AccountCategoryCode = d.AccountCategoryCode,
                                       AccountCategory = d.AccountCategory,
                                       IsLocked = d.IsLocked,
                                       CreatedById = d.CreatedById,
                                       CreatedDateTime = d.CreatedDateTime,
                                       UpdatedById = d.UpdatedById,
                                       UpdatedDateTime = d.UpdatedDateTime
                                    };
            return accountCategories.ToList();
        }

        // GET api/MstAccountCategory/5
        public MstAccountCategory Get(int id)
        {
            var accountCategory = from d in db.MstAccountCategories
                                  where d.Id == id
                                  select new Models.MstAccountCategory
                                  {
                                      Id = d.Id,
                                      AccountCategoryCode = d.AccountCategoryCode,
                                      AccountCategory = d.AccountCategory,
                                      IsLocked = d.IsLocked,
                                      CreatedById = d.CreatedById,
                                      CreatedDateTime = d.CreatedDateTime,
                                      UpdatedById = d.UpdatedById,
                                      UpdatedDateTime = d.UpdatedDateTime
                                  };
            return accountCategory.FirstOrDefault();
        }

        // POST api/MstAccountCategory
        public HttpResponseMessage Post([FromBody]MstAccountCategory value)
        {
            try
            {
                var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                Data.MstAccountCategory newAccountCategory = new Data.MstAccountCategory();

                newAccountCategory.AccountCategoryCode = value.AccountCategoryCode;
                newAccountCategory.AccountCategory = value.AccountCategory;
                newAccountCategory.IsLocked = true;
                newAccountCategory.CreatedById = user.Id;
                newAccountCategory.CreatedDateTime = DateTime.Now;
                newAccountCategory.UpdatedById = user.Id;
                newAccountCategory.UpdatedDateTime = DateTime.Now;

                db.MstAccountCategories.Add(newAccountCategory);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // PUT api/MstAccountCategory/5
        public HttpResponseMessage Put(int id, [FromBody]MstAccountCategory value)
        {
            try
            {
                var accountCategory = from d in db.MstAccountCategories where d.Id == id select d;
                if (accountCategory.Any())
                {
                    var editAccountCategory = accountCategory.FirstOrDefault();

                    var user = (from d in db.MstUsers where d.UserName == User.Identity.Name select d).SingleOrDefault();

                    editAccountCategory.AccountCategoryCode = value.AccountCategoryCode;
                    editAccountCategory.AccountCategory = value.AccountCategory;
                    editAccountCategory.IsLocked = true;
                    editAccountCategory.UpdatedById = user.Id;
                    editAccountCategory.UpdatedDateTime = DateTime.Now;

                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // DELETE api/MstAccountCategory/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var accountCategory = from d in db.MstAccountCategories where d.Id == id select d;
                if (accountCategory.Any())
                {
                    var deleteAccountCategory = accountCategory.FirstOrDefault();
                    db.MstAccountCategories.Remove(deleteAccountCategory);
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