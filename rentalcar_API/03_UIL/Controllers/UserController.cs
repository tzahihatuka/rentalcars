using _01_BOL;
using _02_BLL;
using _03_UIL.Filter;
using _03_UIL.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_UIL.Controllers
{
   
    [Authorize]
    [AuthenticationFilter]
   
    public class UserController : ApiController
    {
        // GET: api/User/5
        public IHttpActionResult Get()
        {

            var re = Request;
            var headers = re.Headers;
          
            int user = RentUser.GetLogin(headers.Authorization.Scheme, headers.Authorization.Parameter);
            return Ok(user);
        }
        [Authorize(Roles = "admin")]
        public IHttpActionResult Get(string id)
        {

            BOLUserInfo user = RentUser.GetLoginUserFrom_db(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }
        [Authorize(Roles = "admin")]
        [Route("api/GetuserById")]
        [HttpGet]
        public IHttpActionResult GetuserById(string userNumber)
        {

            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            BOLUserInfo user = RentUser.GetLoginUserFrom_db(userNumber);

            if (user != null)
            {

                UserModel convertedUsers = convertUser.convertUserFromBOLtoModel(user);
                if (convertedUsers.UserPic != null)
                    convertedUsers.UserPic = baseUrl + @"/image/" + convertedUsers.UserPic;
                return Ok(convertedUsers);
            }
            else
            {
                return NotFound();
            }

        }
        // GET: api/User/5

        [Authorize(Roles = "admin")]
        [Route("api/GetAllusers")]
        [HttpGet]
        public IHttpActionResult GetAllusers()
        {

            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            List<BOLUserInfo> users = RentUser.GetAllUsers();
            List <UserModel> convertedUsers= convertUser.convertFromBOLtoModel(users);
            foreach (var item in convertedUsers)
            {
                if(item.UserPic!=null)
                item.UserPic = baseUrl + @"/image/" + item.UserPic;
            }
            return Ok(convertedUsers);

        }

        // POST: api/User
        [Authorize(Roles = "admin")]
        [Route("api/AddingusersByAdmin")]
        [HttpPost]
        [AddRegister]
        public IHttpActionResult AddingusersByAdmin([FromBody]UserModel value)
        {
            BOLUserInfo users = convertUser.convertUserFromModeltoBOL(value);
            string res = RentUser.AddUserTo_db(users);
            return Ok(res);
        }
        [AllowAnonymous]
        [AddRegister]
        public IHttpActionResult Post([FromBody]BOLUserInfo value)
        {
             RentUser.AddUserTo_db(value);
            return Ok();
        }

        // PUT: api/User/5
        [AddRegister]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Put([FromBody]UserModel[] value)
        {
            BOLUserInfo olduserInfo = convertUser.convertUserFromModeltoBOL(value[0]);
            BOLUserInfo newuserInfo = convertUser.convertUserFromModeltoBOL(value[1]);

            string res = RentUser.UpDataTo_db( olduserInfo, newuserInfo);
            return Ok(res);
        }

        // DELETE: api/User/5
        [AddRegister]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(string UserIdNumber)
        {
          string res=  RentUser.deleteFrom_db(UserIdNumber);
            return Ok(res);
        }
    }
}
