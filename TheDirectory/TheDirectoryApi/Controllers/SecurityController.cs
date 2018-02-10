using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TheDirectoryApi.Providers;
using TheDirectoryDAL;

namespace TheDirectoryApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SecurityController : ApiController
    {
        TheDirectoryEntities db;

        public SecurityController()
        {
            db = new TheDirectoryEntities();
        }

        [HttpPost]
        public bool Login(User input)
        {
            string encodedPwd = PasswordManager.Base64Encode(input.Password);
            User user = db.Users.FirstOrDefault(p=>p.Username==input.Username && p.Password==encodedPwd);
            if(user!=null)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool CreateUser(User input)
        {
            if(input.Username!="" && input.Password!="" && input.FirstName!="" && input.LastName!="")
            {
                input.Password = PasswordManager.Base64Encode(input.Password);
                db.Users.Add(input);
                if(db.SaveChanges()>0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
