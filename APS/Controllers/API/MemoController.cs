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
            // empty
            return null; 
        }

        // GET: api/Memo/5
        public IEnumerable<Memo> Get(int id)
        {
            return memoRepo.GetAllMemos(id);
        }

        // POST: api/Memo
        public Memo Post([FromBody]Memo memo)
        {
            Memo m = memoRepo.CreateMemo(memo);

            return m;
        }

        // PUT: api/Memo/5
        public void Put(int id, [FromBody]Memo memo)
        {
            memo.UID = id;
            memoRepo.UpdateMemo(memo);
        }

        // DELETE: api/Memo/5
        public void Delete(int id)
        {
            memoRepo.DeleteMemo(id);
        }
    }
}
