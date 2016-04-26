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
    [RoutePrefix("api/TrnJournalVoucher")]
    public class TrnJournalVoucherController : ApiController
    {
        private Data.Easyfisv2DBContext db = new Data.Easyfisv2DBContext();

        // GET api/TrnJournalVoucher/List?transactionDate=2016-04-01&branchId=1
        [Route("List")]
        public List<TrnJournalVoucher> Get(DateTime transactionDate, Int32 branchId)
        {
            var journalVouchers = from d in db.TrnJournalVouchers
                                  where d.JVDate == transactionDate && d.BranchId == branchId
                                  orderby d.JVNumber descending
                                  select new Models.TrnJournalVoucher
                                  {
                                       Id = d.Id,
                                       JVDate = d.JVDate,
                                       JVNumber = d.JVNumber,
                                       BranchId = d.BranchId,
                                       Branch = d.MstBranch.Branch,
                                       Particulars = d.Particulars,
                                       ManualJVNumber = d.ManualJVNumber,
                                       IsLocked = d.IsLocked,
                                       CreatedById = d.CreatedById,
                                       CreatedDateTime = d.CreatedDateTime,
                                       UpdatedById = d.UpdatedById,
                                       UpdatedDateTime = d.UpdatedDateTime
                                  };
            return journalVouchers.ToList();
        }

        // GET api/TrnJournalVoucher/5
        public TrnJournalVoucher Get(Int32 id)
        {
            var journalVoucher = from d in db.TrnJournalVouchers
                                 where d.Id == id
                                 select new Models.TrnJournalVoucher
                                 {
                                      Id = d.Id,
                                      JVDate = d.JVDate,
                                      JVNumber = d.JVNumber,
                                      BranchId = d.BranchId,
                                      Branch = d.MstBranch.Branch,
                                      Particulars = d.Particulars,
                                      ManualJVNumber = d.ManualJVNumber,
                                      IsLocked = d.IsLocked,
                                      CreatedById = d.CreatedById,
                                      CreatedDateTime = d.CreatedDateTime,
                                      UpdatedById = d.UpdatedById,
                                      UpdatedDateTime = d.UpdatedDateTime
                                 };
            return journalVoucher.FirstOrDefault();
        }

    }
}