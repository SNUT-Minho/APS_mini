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
    public class CompanyController : ApiController
    {
        CompanyRepository companyRepo = new CompanyRepository();

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            var result = companyRepo.getAllCompany();
            return result;
        }

        // GET: api/Company/5
        public int Get(int id)
        {
            var result = companyRepo.getScureCode(id);

            return result;
        }

        // POST: api/Company
        public Company Post([FromBody]Company company)
        {
            var result = companyRepo.createCompany(company);

            return result;
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
