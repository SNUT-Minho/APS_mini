using APS.Models.Repositories;
using APS.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APS.Controllers.API
{
    public class MemoController : ApiController
    {
        MemoRepository memoRepo = new MemoRepository();

        // GET: api/Memo
        public IEnumerable<Memo> Get()
        {
            return memoRepo.GetAllMemos(); 
        }

        // GET: api/Memo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Memo
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Memo/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Memo/5
        public void Delete(int id)
        {
            memoRepo.DeleteMemo(id);
        }
    }
}
