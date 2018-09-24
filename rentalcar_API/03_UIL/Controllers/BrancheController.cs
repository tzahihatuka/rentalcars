using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_UIL.Controllers
{
  
    [AuthenticationFilter]
    public class BrancheController : ApiController
    {
        // GET: api/CarType
       
        public IHttpActionResult Get()
        {
            List<BOLBranch> value = RentBranches.GetBranchFrom_db();
            return Ok(value);
        }

        // POST: api/CarType
       
        [Authorize(Roles = "admin,worker")]
        public IHttpActionResult Post([FromBody]BOLBranch branch)
        {
            RentBranches.AddBranchTo_db(branch);
            return Ok();
        }

        // PUT: api/CarType/5
  
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody] List<BOLBranch> branch)
        {
            RentBranches.UpDataTo_db(branch[0], branch[1]);
            return Ok();
        }

        // DELETE: api/CarType/5

        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(BOLBranch branch)
        {
            RentBranches.deleteFrom_db(branch);
            return Ok();
        }
    }
}
